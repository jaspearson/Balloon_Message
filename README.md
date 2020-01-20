# Balloon_Message
UiPath Custom Activity - Shows a windows style balloon tip message.

Accepts 5 Input Arguments:
- **Balloon Message (string)** - The message you would like to be displayed. 
- **Icon Type (ToolTipIcon)** - ToolTipIcon.Info, ToolTipIcon.Warning, ToolTipIcon.Error
**Note** - You may need to import System.Windows.Forms in the UiPath interface to be able to access the ToolTipIcon type. 
- **Send Balloon Message (Boolean)** - True or False value. If the value of this field is true the balloon message is sent so it can be shown. If it is false, no message is sent to the windows operating system. 
- **Timeout (Integer/milliseconds)** - Note anything over 30000 milliseconds is truncated and returned to the max of 30000. This is default behavior of the windows balloon tip messages. 
- **Title (String)** - The short title to display on the balloon tip message. 

Windows 8.1
<img src="/images/Demo.png" width="800" /> 

Windows 10
<img src="/images/Demo2.png" width="800" /> 
