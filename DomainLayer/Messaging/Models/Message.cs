using System;
using System.Text.Json.Serialization;

namespace DomainLayer.Messaging.Models
{
    /// <summary>
    ///     Describes the message
    /// </summary>
    public class Message
    {
        /// <summary>
        ///     the message id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        ///     the sender id
        /// </summary>
        public int SenderId { get; set; }
        
        /// <summary>
        ///     the recipient id
        /// </summary>
        public int RecipientId { get; set; }
        
        /// <summary>
        ///     the sender user name
        /// </summary>
        public string SenderUsername { get; set; }
        
        /// <summary>
        ///     the sender photo url
        /// </summary>
        public string SenderPhotoUrl { get; set; }

        /// <summary>
        ///     the recipient user name
        /// </summary>
        public string RecipientUsername { get; set; }
        
        /// <summary>
        ///     the recipient photo url
        /// </summary>
        public string RecipientPhotoUrl { get; set; }
        
        /// <summary>
        ///     the message content
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        ///     the date when the message was read
        /// </summary>
        public DateTime? DateRead { get; set; }
        
        /// <summary>
        ///     the date when the message was sent
        /// </summary>
        public DateTime MessageSent { get; set; }

        /// <summary>
        ///     describes if the sender has deleted the message
        /// </summary>
        [JsonIgnore]
        public bool HasSenderDeleted { get; set; }
        
        /// <summary>
        ///     describes if the recipient has deleted the message
        /// </summary>
        [JsonIgnore]
        public bool HasRecipientDeleted { get; set; }
        
        /// <summary>
        ///     When has the message created 
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        /// <summary>
        ///     When has the message changed 
        /// </summary>
        public DateTime ChangedAt { get; set; } = DateTime.Now;
    }
}