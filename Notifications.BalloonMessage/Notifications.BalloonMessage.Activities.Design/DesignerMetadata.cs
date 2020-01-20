using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Notifications.BalloonMessage.Activities.Design.Properties;

namespace Notifications.BalloonMessage.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute =  new CategoryAttribute($"{Resources.Category}");


            //builder.AddCustomAttributes(typeof(ParentScope), categoryAttribute);
            //builder.AddCustomAttributes(typeof(ParentScope), new DesignerAttribute(typeof(ParentScopeDesigner)));
            //builder.AddCustomAttributes(typeof(ParentScope), new HelpKeywordAttribute("https://go.uipath.com"));

            builder.AddCustomAttributes(typeof(BalloonMessage), categoryAttribute);
            builder.AddCustomAttributes(typeof(BalloonMessage), new DesignerAttribute(typeof(ChildActivityDesigner)));
            builder.AddCustomAttributes(typeof(BalloonMessage), new HelpKeywordAttribute("https://go.uipath.com"));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
