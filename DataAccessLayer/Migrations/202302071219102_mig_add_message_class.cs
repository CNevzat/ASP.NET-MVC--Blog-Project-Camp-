namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_message_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        messageID = c.Int(nullable: false, identity: true),
                        senderMail = c.String(maxLength: 50),
                        receiverMail = c.String(maxLength: 50),
                        subject = c.String(maxLength: 100),
                        messageContent = c.String(),
                        messageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.messageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
