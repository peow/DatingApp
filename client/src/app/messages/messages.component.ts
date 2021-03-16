import { Component, OnInit } from '@angular/core';
import { Message } from '../_models/message';
import { Pagination } from '../_models/pagination';
import { MessageService } from '../_services/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  messages: Message[] = [];
  pagination: Pagination;
  container ='Unread';
  pageNumber = 1;
  pageSize = 5;
  loading = false;

  constructor(private messageSerice: MessageService) { }

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages(){
    this.loading = true;
    this.messageSerice.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages = response.result;
      this.pagination = response.pagination;
      this.loading = false;
    });
  }

  deleteMessage(id: number) {
    this.messageSerice.deleteMessage(id).subscribe(message => {
      this.messages.splice(this.messages.findIndex(m => m.id === id), 1);
    })
  }
  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadMessages();
  }

}
