using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebToIdentity2.Models
{
    // 您可以在 ApplicationUser 類別新增更多屬性，為使用者新增設定檔資料，請造訪 http://go.microsoft.com/fwlink/?LinkID=317594 以深入了解。
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;
        }

        // TODO Step1 Code insert here

        /// <summary>
        /// 新增 生日 欄位
        /// </summary>
        public System.DateTime? BirthDay { get; set; }
        /// <summary>
        /// 新增 暱稱 欄位
        /// </summary>
        public string NickName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}