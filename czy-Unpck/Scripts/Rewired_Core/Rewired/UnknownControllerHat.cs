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
			private int[] YHGHlHoNtkOhmbsNDxUBNKVvRCH;

			public int this[int index] => YHGHlHoNtkOhmbsNDxUBNKVvRCH[index];

			public HatButtons(int[] buttons)
			{
				YHGHlHoNtkOhmbsNDxUBNKVvRCH = buttons;
			}

			public void GetNeighbors(int button, out int neighbor1, out int neighbor2)
			{
				int num = IndexOf(button);
				while (true)
				{
					int num2 = 497866460;
					while (true)
					{
						switch (num2 ^ 0x1DACD6DF)
						{
						case 0:
							break;
						case 4:
						{
							int num3;
							if (num < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length - 1)
							{
								num2 = 497866456;
								num3 = num2;
							}
							else
							{
								num2 = 497866461;
								num3 = num2;
							}
							continue;
						}
						case 2:
							neighbor2 = YHGHlHoNtkOhmbsNDxUBNKVvRCH[0];
							num2 = 497866458;
							continue;
						case 6:
							neighbor1 = YHGHlHoNtkOhmbsNDxUBNKVvRCH[YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length - 1];
							num2 = 497866459;
							continue;
						case 3:
							if (num < 0)
							{
								neighbor1 = -1;
								neighbor2 = -1;
								return;
							}
							goto case 1;
						case 5:
							return;
						case 1:
							if (num > 0)
							{
								neighbor1 = YHGHlHoNtkOhmbsNDxUBNKVvRCH[num - 1];
								num2 = 497866459;
								continue;
							}
							goto case 6;
						default:
							neighbor2 = YHGHlHoNtkOhmbsNDxUBNKVvRCH[num + 1];
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
				while (num < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
				{
					while (true)
					{
						if (YHGHlHoNtkOhmbsNDxUBNKVvRCH[num] == button)
						{
							return num;
						}
						num++;
						int num2 = -1109550419;
						while (true)
						{
							switch (num2 ^ -1109550417)
							{
							case 0:
								num2 = -1109550418;
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

		private HatButtons YHGHlHoNtkOhmbsNDxUBNKVvRCH;

		public UnknownControllerHat(HatButtons buttons)
		{
			YHGHlHoNtkOhmbsNDxUBNKVvRCH = buttons;
		}

		public bool ContainsButtonIndex(int index)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= 8)
				{
					num2 = 518097424;
					num3 = num2;
				}
				else
				{
					num2 = 518097427;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x1EE18A11)
					{
					case 0:
						num2 = 518097427;
						continue;
					case 2:
						if (YHGHlHoNtkOhmbsNDxUBNKVvRCH.Contains(index))
						{
							return true;
						}
						num++;
						num2 = 518097426;
						continue;
					case 3:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public bool IsButtonIndexCardinal(int index)
		{
			int num = 0;
			while (true)
			{
				int num2 = 1054608553;
				while (true)
				{
					switch (num2 ^ 0x3EDC0CA8)
					{
					case 0:
						break;
					case 1:
						num2 = 1054608555;
						continue;
					case 2:
						if (YHGHlHoNtkOhmbsNDxUBNKVvRCH.IsCardinal(index))
						{
							return true;
						}
						num++;
						num2 = 1054608555;
						continue;
					default:
						if (num >= 8)
						{
							return false;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public HatButtons GetButtons()
		{
			return YHGHlHoNtkOhmbsNDxUBNKVvRCH;
		}
	}
}
