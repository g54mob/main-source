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
			private int[] xIIOtOIuEykpnAueUtuKVMbkTfu;

			public int this[int index]
			{
				get
				{
					return xIIOtOIuEykpnAueUtuKVMbkTfu[index];
				}
			}

			public HatButtons(int[] buttons)
			{
				xIIOtOIuEykpnAueUtuKVMbkTfu = buttons;
			}

			public void GetNeighbors(int button, out int neighbor1, out int neighbor2)
			{
				int num = IndexOf(button);
				while (true)
				{
					int num2 = 876796736;
					while (true)
					{
						switch (num2 ^ 0x3442DB46)
						{
						case 0:
							break;
						default:
							return;
						case 9:
							neighbor1 = xIIOtOIuEykpnAueUtuKVMbkTfu[xIIOtOIuEykpnAueUtuKVMbkTfu.Length - 1];
							num2 = 876796740;
							continue;
						case 3:
							neighbor2 = -1;
							return;
						case 7:
							neighbor2 = xIIOtOIuEykpnAueUtuKVMbkTfu[num + 1];
							num2 = 876796750;
							continue;
						case 6:
							if (num < 0)
							{
								neighbor1 = -1;
								num2 = 876796741;
								continue;
							}
							goto case 4;
						case 5:
							neighbor2 = xIIOtOIuEykpnAueUtuKVMbkTfu[0];
							return;
						case 2:
						{
							int num3;
							if (num >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length - 1)
							{
								num2 = 876796739;
								num3 = num2;
							}
							else
							{
								num2 = 876796737;
								num3 = num2;
							}
							continue;
						}
						case 1:
							num2 = 876796740;
							continue;
						case 4:
							if (num > 0)
							{
								neighbor1 = xIIOtOIuEykpnAueUtuKVMbkTfu[num - 1];
								num2 = 876796743;
								continue;
							}
							goto case 9;
						case 8:
							return;
						}
						break;
					}
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
				int num = 0;
				while (num < xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
				{
					while (true)
					{
						if (xIIOtOIuEykpnAueUtuKVMbkTfu[num] == button)
						{
							return num;
						}
						num++;
						int num2 = 1200389891;
						while (true)
						{
							switch (num2 ^ 0x478C7F03)
							{
							case 2:
								num2 = 1200389890;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0022;
							}
							break;
						}
						continue;
						end_IL_0022:
						break;
					}
				}
				return -1;
			}

			public bool Contains(int button)
			{
				return IndexOf(button) >= 0;
			}
		}

		private HatButtons xIIOtOIuEykpnAueUtuKVMbkTfu;

		public UnknownControllerHat(HatButtons buttons)
		{
			while (true)
			{
				int num = -1228282741;
				while (true)
				{
					switch (num ^ -1228282743)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0024;
					case 1:
						return;
					}
					break;
					IL_0024:
					xIIOtOIuEykpnAueUtuKVMbkTfu = buttons;
					num = -1228282744;
				}
			}
		}

		public bool ContainsButtonIndex(int index)
		{
			int num = 0;
			while (true)
			{
				int num2 = 1643424342;
				while (true)
				{
					switch (num2 ^ 0x61F4AA57)
					{
					case 2:
						break;
					case 1:
						num2 = 1643424340;
						continue;
					case 4:
						if (xIIOtOIuEykpnAueUtuKVMbkTfu.Contains(index))
						{
							num2 = 1643424343;
							continue;
						}
						num++;
						num2 = 1643424340;
						continue;
					case 0:
						return true;
					default:
						if (num >= 8)
						{
							return false;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public bool IsButtonIndexCardinal(int index)
		{
			int num = 0;
			while (num < 8)
			{
				while (true)
				{
					int num2;
					if (xIIOtOIuEykpnAueUtuKVMbkTfu.IsCardinal(index))
					{
						num2 = 1300092104;
					}
					else
					{
						num++;
						num2 = 1300092105;
					}
					while (true)
					{
						switch (num2 ^ 0x4D7DD4CB)
						{
						case 0:
							num2 = 1300092106;
							continue;
						case 1:
							break;
						case 3:
							return true;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					end_IL_0026:
					break;
				}
			}
			return false;
		}

		public HatButtons GetButtons()
		{
			return xIIOtOIuEykpnAueUtuKVMbkTfu;
		}
	}
}
