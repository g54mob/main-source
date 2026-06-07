using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDButton : HIDControllerElement
	{
		public bool rawValue;

		public float timestamp;

		public HIDButton(byte reportId, HIDInfo hidInfo)
			: base(reportId, hidInfo)
		{
		}

		public void SetValue(bool rawValue, float timestamp)
		{
			this.rawValue = rawValue;
			this.timestamp = timestamp;
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (inputReport == null)
			{
				goto IL_0003;
			}
			goto IL_0031;
			IL_0003:
			int num = -1641594872;
			goto IL_0008;
			IL_0008:
			switch (num ^ -1641594870)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 3:
				goto IL_0031;
			case 4:
				goto IL_0048;
			case 1:
				return;
			}
			goto IL_0003;
			IL_0031:
			if (inputReport[0] != reportId)
			{
				return;
			}
			goto IL_0048;
			IL_0048:
			this.timestamp = timestamp;
			num = -1641594869;
			goto IL_0008;
		}
	}
}
