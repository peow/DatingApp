using System;
using System.Collections.Generic;
using DomainLayer.Likes.Model;
using DomainLayer.Messaging.Models;
using DomainLayer.Photos.Model;

namespace DomainLayer.Users.Model
{
    /// <summary>
    ///     Describes the user
    /// </summary>
    public class User
    {
        /// <summary>
        ///     The birthday of the user
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        
        /// <summary>
        ///     The nickname of the user
        /// </summary>
        public string KnownAs { get; set; }

        /// <summary>
        ///     The gender of the user
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        ///     The introduction of the user
        /// </summary>
        public string Introduction { get; set; }
        
        /// <summary>
        ///     Describes what the User is looking for
        ///     e.g. Male, Female, Both, Friendship, etc.
        /// </summary>
        public string LookingFor { get; set; }
        
        /// <summary>
        ///     Describes the interests of the user
        /// </summary>
        public string Interests { get; set; }
        
        /// <summary>
        ///     describes which country the user is coming from
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        ///     Describes which city the user is living
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        ///     When was the user created 
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        /// <summary>
        ///     When was the user changed 
        /// </summary>
        public DateTime ChangedAt { get; set; } = DateTime.Now;
        
        /// <summary>
        ///     States when the user was last active
        /// </summary>
        public DateTime LastActive { get; set; } = DateTime.Now; 
        
        /// <summary>
        ///     The photos a user have
        /// </summary>
        public ICollection<Photo> Photos { get; set; }
        
        /// <summary>
        ///     The likes a user have
        /// </summary>
        public ICollection<Like> LikedByUsers { get; set; }
        
        /// <summary>
        ///     The likes a user gave
        /// </summary>
        public ICollection<Like> LikedUser { get; set; }
        
        /// <summary>
        ///     The messages a user have sent
        /// </summary>
        public ICollection<Message> MessagesSent { get; set; }
        
        /// <summary>
        ///     The messages a user received
        /// </summary>
        public ICollection<Message> MessagesReceived { get; set; }
    }
}