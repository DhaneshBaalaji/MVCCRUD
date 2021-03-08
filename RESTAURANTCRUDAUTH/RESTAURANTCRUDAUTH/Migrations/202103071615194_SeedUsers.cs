namespace RESTAURANTCRUDAUTH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'34be774f-6549-4bd3-8057-01e8d6258498', N'operator@crud.com', 0, N'AFrP7VBS9KGSgvrFwfb/cmO1u+t+UsGlBh9L3FZlPOxeqdM/5eflTvmCiTpsnhpHNg==', N'4ae06d40-c7f4-4c10-8570-8400aa8b6861', NULL, 0, 0, NULL, 1, 0, N'operator@crud.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd9bd1bc8-ba41-4ebd-9ab8-a9bc2affc2ec', N'admin@crud.com', 0, N'AHE4eI9W+JfUijmqRd9Bhz57ZUhdqcvWnZCnT20gPuyH/Q20P1P9bINqXvTOgKzwtg==', N'624988c8-7e53-4cd4-9d18-8a0a0659c6f8', NULL, 0, 0, NULL, 1, 0, N'admin@crud.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'41622f4e-5e3a-45c4-8a08-45e082cf930e', N'CanViewDetails')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34be774f-6549-4bd3-8057-01e8d6258498', N'41622f4e-5e3a-45c4-8a08-45e082cf930e')


");
        }
        
        public override void Down()
        {
        }
    }
}
