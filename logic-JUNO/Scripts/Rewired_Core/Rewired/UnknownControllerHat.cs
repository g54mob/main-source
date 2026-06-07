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
			private int[] qKyNyfGQDkghzXuvgnShGHbLZNYO;

			public int this[int index] => qKyNyfGQDkghzXuvgnShGHbLZNYO[index];

			public HatButtons(int[] P_0)
			{
				qKyNyfGQDkghzXuvgnShGHbLZNYO = P_0;
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
					neighbor1 = qKyNyfGQDkghzXuvgnShGHbLZNYO[num - 1];
				}
				else
				{
					neighbor1 = qKyNyfGQDkghzXuvgnShGHbLZNYO[qKyNyfGQDkghzXuvgnShGHbLZNYO.Length - 1];
				}
				if (num >= qKyNyfGQDkghzXuvgnShGHbLZNYO.Length - 1)
				{
					neighbor2 = qKyNyfGQDkghzXuvgnShGHbLZNYO[0];
				}
				else
				{
					neighbor2 = qKyNyfGQDkghzXuvgnShGHbLZNYO[num + 1];
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
				for (int i = 0; i < qKyNyfGQDkghzXuvgnShGHbLZNYO.Length; i++)
				{
					if (qKyNyfGQDkghzXuvgnShGHbLZNYO[i] == button)
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

		private HatButtons kajLiGEgnSGTSiaVlyFhIrVcsMPY;

		public UnknownControllerHat(HatButtons P_0)
		{
			kajLiGEgnSGTSiaVlyFhIrVcsMPY = P_0;
		}

		public bool ContainsButtonIndex(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (kajLiGEgnSGTSiaVlyFhIrVcsMPY.Contains(index))
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
				if (kajLiGEgnSGTSiaVlyFhIrVcsMPY.IsCardinal(index))
				{
					return true;
				}
			}
			return false;
		}

		public HatButtons GetButtons()
		{
			return kajLiGEgnSGTSiaVlyFhIrVcsMPY;
		}
	}
}
