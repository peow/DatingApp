import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastrService: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if(error) {
          switch (error.status) {
            case 400:
              if(error.error.errors) {
                const modalStateErrors = [];
                for (const key in error.error.errors) {
                  if(error.error.errors[key]) {
                    modalStateErrors.push(error.error.errors[key]);
                  }
                }
                throw modalStateErrors.flat();                
              } else {
                this.toastrService.error(error.statusText, error.status);
              }                            
              break;
            case 401: 
              this.toastrService.error(error.statusText, error.status);
              break;
            case 404: 
              this.router.navigateByUrl('/not-found')              
              break;
            case 500: 
              const navigationExtras: NavigationExtras = {state: {error: error.error}};
              this.router.navigateByUrl('/server-error');
              break;
            default:
              this.toastrService.error('Something went wrong!');
              console.log(error);
              break;
          }
        }
        return throwError(error);
        
      })
    );
  }
}
