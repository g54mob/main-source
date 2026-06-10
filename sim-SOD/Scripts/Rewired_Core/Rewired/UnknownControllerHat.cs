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
			private int[] cDSkhPASHMpLgclAHWYeTJNQMrq;

			public int this[int index] => 0;

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

		private HatButtons cDSkhPASHMpLgclAHWYeTJNQMrq;

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
