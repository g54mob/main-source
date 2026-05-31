using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class UnknownControllerHat
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public class HatButtons
		{
			private int[] aJtpRSRHtDeqCDIJtCvHanoFDlsc;

			public int this[int index] => aJtpRSRHtDeqCDIJtCvHanoFDlsc[index];

			public HatButtons(int[] buttons)
			{
				aJtpRSRHtDeqCDIJtCvHanoFDlsc = buttons;
			}

			public void GetNeighbors(int button, out int neighbor1, out int neighbor2)
			{
				int num = IndexOf(button);
				if (num < 0)
				{
					neighbor1 = -1;
					neighbor2 = -1;
					return;
				}
				if (num > 0)
				{
					neighbor1 = aJtpRSRHtDeqCDIJtCvHanoFDlsc[num - 1];
				}
				else
				{
					neighbor1 = aJtpRSRHtDeqCDIJtCvHanoFDlsc[aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length - 1];
				}
				if (num >= aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length - 1)
				{
					neighbor2 = aJtpRSRHtDeqCDIJtCvHanoFDlsc[0];
				}
				else
				{
					neighbor2 = aJtpRSRHtDeqCDIJtCvHanoFDlsc[num + 1];
				}
			}

			public bool IsCardinal(int button)
			{
				int num = IndexOf(button);
				if (num < 0)
				{
					return false;
				}
				return MathTools.IsEven(num);
			}

			public bool IsCorner(int button)
			{
				int num = IndexOf(button);
				if (num < 0)
				{
					return false;
				}
				return !MathTools.IsEven(num);
			}

			public int IndexOf(int button)
			{
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					if (aJtpRSRHtDeqCDIJtCvHanoFDlsc[i] == button)
					{
						return i;
					}
				}
				return -1;
			}

			public bool Contains(int button)
			{
				return IndexOf(button) >= 0;
			}
		}

		private HatButtons aJtpRSRHtDeqCDIJtCvHanoFDlsc;

		public UnknownControllerHat(HatButtons buttons)
		{
			aJtpRSRHtDeqCDIJtCvHanoFDlsc = buttons;
		}

		public bool ContainsButtonIndex(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (aJtpRSRHtDeqCDIJtCvHanoFDlsc.Contains(index))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsButtonIndexCardinal(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (aJtpRSRHtDeqCDIJtCvHanoFDlsc.IsCardinal(index))
				{
					return true;
				}
			}
			return false;
		}

		public HatButtons GetButtons()
		{
			return aJtpRSRHtDeqCDIJtCvHanoFDlsc;
		}
	}
}
