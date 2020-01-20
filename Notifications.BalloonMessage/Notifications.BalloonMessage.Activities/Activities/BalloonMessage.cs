using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using Notifications.BalloonMessage.Activities.Properties;
using UiPath.Shared.Activities;
using System.Windows.Forms;
using System.Drawing;

namespace Notifications.BalloonMessage.Activities
{
	[LocalizedDisplayName(nameof(Resources.BalloonMessageDisplayName))]
	[LocalizedDescription(nameof(Resources.BalloonMessageDescription))]
	public class BalloonMessage : AsyncTaskCodeActivity
	{
        #region Properties

        [LocalizedDisplayName(nameof(Resources.BalloonMessageTitleDisplayName))]
        [LocalizedDescription(nameof(Resources.BalloonMessageTitleDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<string> Title { get; set; }

        [LocalizedDisplayName(nameof(Resources.BalloonMessageMessageDisplayName))]
        [LocalizedDescription(nameof(Resources.BalloonMessageMessageDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<string> Message { get; set; }

        [LocalizedDisplayName(nameof(Resources.BalloonMessageDisplayTimeoutDisplayName))]
        [LocalizedDescription(nameof(Resources.BalloonMessageDisplayTimeoutDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<int> Timeout { get; set; }

        [LocalizedDisplayName(nameof(Resources.BalloonMessageIconTypeDisplayName))]
        [LocalizedDescription(nameof(Resources.BalloonMessageIconTypeDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<ToolTipIcon> IconType { get; set; }

        [LocalizedDisplayName(nameof(Resources.BalloonMessageShowBaloonMessageDisplayName))]
        [LocalizedDescription(nameof(Resources.BalloonMessageShowBalloonMessageDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<Boolean> ShowBalloonMessage { get; set; }

        [LocalizedDisplayName("Success")]
        [LocalizedDescription("Boolean Value")]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Boolean> Success { get; set; }

        #endregion

        public BalloonMessage()
        {

        }

        #region Protected Methods

        /// <summary>
        /// Validates properties at design-time.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (Title == null) metadata.AddValidationError(string.Format(Resources.MetadataValidationError, nameof(Title)));
            if (Message == null) metadata.AddValidationError(string.Format(Resources.MetadataValidationError, nameof(Message)));
            if (Timeout == null) metadata.AddValidationError(string.Format(Resources.MetadataValidationError, nameof(Timeout)));
            if (IconType == null) metadata.AddValidationError(string.Format(Resources.MetadataValidationError, nameof(IconType)));
            base.CacheMetadata(metadata);
        }

        /// <summary>
        /// Runs the main logic of the activity. Has access to the context, 
        /// which holds the values of properties for this activity and those from the parent scope.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            //var property = context.DataContext.GetProperties()[ParentScope.ApplicationTag];
            //var app = property.GetValue(context.DataContext) as Application;
            if (ShowBalloonMessage.Get(context) == true)
            {
                System.Windows.Forms.NotifyIcon notifyIcon1 = new System.Windows.Forms.NotifyIcon();
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.BalloonTipTitle = Title.Get(context);
                notifyIcon1.BalloonTipText = Message.Get(context);
                notifyIcon1.BalloonTipIcon = IconType.Get(context);
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(Timeout.Get(context));
            }



            return ctx =>
            {
                Success.Set(ctx, true);
            };
        }

        #endregion
    }
}