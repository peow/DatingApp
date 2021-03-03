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
        
    }
}