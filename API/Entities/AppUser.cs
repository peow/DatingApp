using System;
using System.Collections.Generic;
using API.Extensions;

namespace API.Entities
{
    /// <summary>
    ///     Beschreibt einen Application User
    /// </summary>
    public class AppUser
    {
        /// <summary>
        ///     Die User Id
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        ///     Der Username
        /// </summary>        
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now; 
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }                
        public ICollection<UserLike> LikedByUsers { get; set; }
        public ICollection<UserLike> LikedUser { get; set; }
    }
}