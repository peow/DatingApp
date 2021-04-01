using DomainLayer.Users.Model;

namespace DomainLayer.Likes.Model
{
    /// <summary>
    ///     Describes the like
    /// </summary>
    public class Like
    {
        /// <summary>
        ///     The user where the like comes from
        /// </summary>
        public User SourceUser { get; set; }
        
        /// <summary>
        ///     The userid where the like comes from
        /// </summary>
        public int SourceUserId { get; set; }
        
        /// <summary>
        ///     the likes the user gave
        /// </summary>
        public User LikedUser { get; set; }
        
        /// <summary>
        ///     the likes the userid gave
        /// </summary>
        public int LikedUserId { get; set; }
    }
}