using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UnknownControllerHat
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class HatButtons
		{
			private int[] kQeebSuCnZqpjUcRuFKzWVkxenTF;

			public int this[int index] => kQeebSuCnZqpjUcRuFKzWVkxenTF[index];

			public HatButtons(int[] P_0)
			{
				kQeebSuCnZqpjUcRuFKzWVkxenTF = P_0;
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
					neighbor1 = kQeebSuCnZqpjUcRuFKzWVkxenTF[num - 1];
				}
				else
				{
					neighbor1 = kQeebSuCnZqpjUcRuFKzWVkxenTF[kQeebSuCnZqpjUcRuFKzWVkxenTF.Length - 1];
				}
				if (num >= kQeebSuCnZqpjUcRuFKzWVkxenTF.Length - 1)
				{
					neighbor2 = kQeebSuCnZqpjUcRuFKzWVkxenTF[0];
				}
				else
				{
					neighbor2 = kQeebSuCnZqpjUcRuFKzWVkxenTF[num + 1];
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
				for (int i = 0; i < kQeebSuCnZqpjUcRuFKzWVkxenTF.Length; i++)
				{
					if (kQeebSuCnZqpjUcRuFKzWVkxenTF[i] == button)
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

		private HatButtons idjidmLBreCSbBhnrUjliISPzQK;

		public UnknownControllerHat(HatButtons P_0)
		{
			idjidmLBreCSbBhnrUjliISPzQK = P_0;
		}

		public bool ContainsButtonIndex(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (idjidmLBreCSbBhnrUjliISPzQK.Contains(index))
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
				if (idjidmLBreCSbBhnrUjliISPzQK.IsCardinal(index))
				{
					return true;
				}
			}
			return false;
		}

		public HatButtons GetButtons()
		{
			return idjidmLBreCSbBhnrUjliISPzQK;
		}
	}
}
