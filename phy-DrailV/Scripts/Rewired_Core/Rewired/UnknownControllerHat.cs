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
			private int[] TfXhkdHigndULcPdipMrFYFFSpcge;

			public int this[int index] => TfXhkdHigndULcPdipMrFYFFSpcge[index];

			public HatButtons(int[] P_0)
			{
				TfXhkdHigndULcPdipMrFYFFSpcge = P_0;
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
					neighbor1 = TfXhkdHigndULcPdipMrFYFFSpcge[num - 1];
				}
				else
				{
					neighbor1 = TfXhkdHigndULcPdipMrFYFFSpcge[TfXhkdHigndULcPdipMrFYFFSpcge.Length - 1];
				}
				if (num >= TfXhkdHigndULcPdipMrFYFFSpcge.Length - 1)
				{
					neighbor2 = TfXhkdHigndULcPdipMrFYFFSpcge[0];
				}
				else
				{
					neighbor2 = TfXhkdHigndULcPdipMrFYFFSpcge[num + 1];
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
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					if (TfXhkdHigndULcPdipMrFYFFSpcge[i] == button)
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

		private HatButtons TfXhkdHigndULcPdipMrFYFFSpcge;

		public UnknownControllerHat(HatButtons P_0)
		{
			TfXhkdHigndULcPdipMrFYFFSpcge = P_0;
		}

		public bool ContainsButtonIndex(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (TfXhkdHigndULcPdipMrFYFFSpcge.Contains(index))
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
				if (TfXhkdHigndULcPdipMrFYFFSpcge.IsCardinal(index))
				{
					return true;
				}
			}
			return false;
		}

		public HatButtons GetButtons()
		{
			return TfXhkdHigndULcPdipMrFYFFSpcge;
		}
	}
}
