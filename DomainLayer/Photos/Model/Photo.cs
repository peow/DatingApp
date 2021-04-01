using DomainLayer.Users.Model;

namespace DomainLayer.Photos.Model
{
    /// <summary>
    ///     Describes the user
    /// </summary>
    public class Photo
    {
        /// <summary>
        ///     The photo id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        ///     the url of the photo
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        ///     Describes if the photo is the main user photo
        /// </summary>
        public bool IsMain { get; set; }
        
        /// <summary>
        ///     the public id of the photo
        /// </summary>
        public string PublicId { get; set; }
        
        /// <summary>
        ///     the user(owner) of the photo
        /// </summary>
        public User User { get; set; }
        
        /// <summary>
        ///     the user id
        /// </summary>
        public int UserId { get; set; }
    }
}