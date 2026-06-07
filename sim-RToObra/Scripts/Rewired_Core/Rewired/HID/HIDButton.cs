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
				while (true)
				{
					switch (0x4039F0EA ^ 0x4039F0EB)
					{
					case 3:
						break;
					case 1:
						return;
					case 2:
						goto end_IL_0003;
					default:
						goto IL_0044;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			if (inputReport[0] != reportId)
			{
				return;
			}
			goto IL_0044;
			IL_0044:
			this.timestamp = timestamp;
		}
	}
}
