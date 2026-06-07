using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class UnknownControllerHat
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class HatButtons
		{
			private int[] yiLCnoEiYpxfzsmLEpoLBCiFaluJA;

			public int this[int index] => yiLCnoEiYpxfzsmLEpoLBCiFaluJA[index];

			public HatButtons(int[] P_0)
			{
				yiLCnoEiYpxfzsmLEpoLBCiFaluJA = P_0;
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
					neighbor1 = yiLCnoEiYpxfzsmLEpoLBCiFaluJA[num - 1];
				}
				else
				{
					neighbor1 = yiLCnoEiYpxfzsmLEpoLBCiFaluJA[yiLCnoEiYpxfzsmLEpoLBCiFaluJA.Length - 1];
				}
				if (num >= yiLCnoEiYpxfzsmLEpoLBCiFaluJA.Length - 1)
				{
					neighbor2 = yiLCnoEiYpxfzsmLEpoLBCiFaluJA[0];
				}
				else
				{
					neighbor2 = yiLCnoEiYpxfzsmLEpoLBCiFaluJA[num + 1];
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
				for (int i = 0; i < yiLCnoEiYpxfzsmLEpoLBCiFaluJA.Length; i++)
				{
					if (yiLCnoEiYpxfzsmLEpoLBCiFaluJA[i] == button)
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

		private HatButtons yiLCnoEiYpxfzsmLEpoLBCiFaluJA;

		public UnknownControllerHat(HatButtons P_0)
		{
			yiLCnoEiYpxfzsmLEpoLBCiFaluJA = P_0;
		}

		public bool ContainsButtonIndex(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (yiLCnoEiYpxfzsmLEpoLBCiFaluJA.Contains(index))
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
				if (yiLCnoEiYpxfzsmLEpoLBCiFaluJA.IsCardinal(index))
				{
					return true;
				}
			}
			return false;
		}

		public HatButtons GetButtons()
		{
			return yiLCnoEiYpxfzsmLEpoLBCiFaluJA;
		}
	}
}
