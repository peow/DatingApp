using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Messaging.Models;

namespace DomainLayer.Messaging.Interfaces
{
    /// <summary>
    ///     Describes the Message
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        ///     Adds a new message
        /// </summary>
        /// <param name="message">the message content</param>
        void Add(Message message);
        
        /// <summary>
        ///     Deletes a message
        /// </summary>
        /// <param name="message">the message content</param>
        void Delete(Message message);
        
        /// <summary>
        ///     Gets a message by their messageId
        /// </summary>
        /// <param name="messageId">the message id</param>
        /// <returns>the message</returns>
        Task<Message> GetMessage(int messageId);
        
        /// <summary>
        ///     Gets all messages by an userId
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <returns>all messages of the user</returns>
        Task<List<Message>> GetMessagesByUserId(int userId);
    }
}