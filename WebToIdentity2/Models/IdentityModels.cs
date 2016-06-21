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


        // TODO Step5 Code insert here

        /// <summary>
        /// 新增 手機 欄位
        /// </summary>
        public string Mobile { get; set; }

        // TODO Step9 Code insert here

        // Code First Migrations 異動更新資料庫
        // 1 開啟套件管理器主控台
        // 2 輸入「Enable-Migrations」
        // 3 再輸入「Add-Migration Init」
        // 4 最後使用「Update-Database」完成資料庫合併
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