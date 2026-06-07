namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class UnknownControllerHat
	{
		[CustomClassObfuscation]
		[CustomObfuscation]
		public class HatButtons
		{
			private int[] zFmIGEcgkzIiDEanGTlyrhktlIxn;

			public int Item => 0;

			public HatButtons(int[] buttons)
			{
			}

			public void GetNeighbors(int button, out int neighbor1, out int neighbor2)
			{
				neighbor1 = default(int);
				neighbor2 = default(int);
			}

			public bool IsCardinal(int button)
			{
				return false;
			}

			public bool IsCorner(int button)
			{
				return false;
			}

			public int IndexOf(int button)
			{
				return 0;
			}

			public bool Contains(int button)
			{
				return false;
			}
		}

		private HatButtons zFmIGEcgkzIiDEanGTlyrhktlIxn;

		public UnknownControllerHat(HatButtons buttons)
		{
		}

		public bool ContainsButtonIndex(int index)
		{
			return false;
		}

		public bool IsButtonIndexCardinal(int index)
		{
			return false;
		}

		public HatButtons GetButtons()
		{
			return null;
		}
	}
}
