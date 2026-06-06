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
			private int[] mOqyfVWOVDqOZdDpfGSYXEsWluNL;

			public int this[int index] => mOqyfVWOVDqOZdDpfGSYXEsWluNL[index];

			public HatButtons(int[] P_0)
			{
				mOqyfVWOVDqOZdDpfGSYXEsWluNL = P_0;
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
					neighbor1 = mOqyfVWOVDqOZdDpfGSYXEsWluNL[num - 1];
				}
				else
				{
					neighbor1 = mOqyfVWOVDqOZdDpfGSYXEsWluNL[mOqyfVWOVDqOZdDpfGSYXEsWluNL.Length - 1];
				}
				if (num >= mOqyfVWOVDqOZdDpfGSYXEsWluNL.Length - 1)
				{
					neighbor2 = mOqyfVWOVDqOZdDpfGSYXEsWluNL[0];
				}
				else
				{
					neighbor2 = mOqyfVWOVDqOZdDpfGSYXEsWluNL[num + 1];
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
				for (int i = 0; i < mOqyfVWOVDqOZdDpfGSYXEsWluNL.Length; i++)
				{
					if (mOqyfVWOVDqOZdDpfGSYXEsWluNL[i] == button)
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

		private HatButtons ogjCauEibfOEyMXLqFVGkfCxEyAy;

		public UnknownControllerHat(HatButtons P_0)
		{
			ogjCauEibfOEyMXLqFVGkfCxEyAy = P_0;
		}

		public bool ContainsButtonIndex(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (ogjCauEibfOEyMXLqFVGkfCxEyAy.Contains(index))
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
				if (ogjCauEibfOEyMXLqFVGkfCxEyAy.IsCardinal(index))
				{
					return true;
				}
			}
			return false;
		}

		public HatButtons GetButtons()
		{
			return ogjCauEibfOEyMXLqFVGkfCxEyAy;
		}
	}
}
