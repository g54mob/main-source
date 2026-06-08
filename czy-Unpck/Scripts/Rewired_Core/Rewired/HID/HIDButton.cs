using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDButton : HIDControllerElement
	{
		public bool rawValue;

		public double timestamp;

		public HIDButton(byte reportId, HIDInfo hidInfo)
			: base(reportId, hidInfo)
		{
		}

		public void SetValue(bool rawValue, double timestamp)
		{
			this.rawValue = rawValue;
			this.timestamp = timestamp;
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (inputReport[0] == reportId)
				{
					num = 2035944162;
					num2 = num;
				}
				else
				{
					num = 2035944160;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x795A0AE1)
					{
					case 0:
						goto IL_0004;
					case 2:
						break;
					case 1:
						return;
					default:
						this.timestamp = timestamp;
						return;
					}
					break;
					IL_0004:
					num = 2035944163;
				}
			}
		}
	}
}
