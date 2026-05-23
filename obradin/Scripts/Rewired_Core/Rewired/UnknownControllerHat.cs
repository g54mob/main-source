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
			private int[] USQZpFcFQqBJUckpyitMKctsvSza;

			public int this[int index]
			{
				get
				{
					return USQZpFcFQqBJUckpyitMKctsvSza[index];
				}
			}

			public HatButtons(int[] buttons)
			{
				USQZpFcFQqBJUckpyitMKctsvSza = buttons;
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
				while (true)
				{
					int num2;
					if (num > 0)
					{
						neighbor1 = USQZpFcFQqBJUckpyitMKctsvSza[num - 1];
						num2 = -1712260401;
						goto IL_0018;
					}
					goto IL_0050;
					IL_0018:
					while (true)
					{
						switch (num2 ^ -1712260401)
						{
						case 4:
							num2 = -1712260402;
							continue;
						case 1:
							break;
						case 3:
							goto IL_0050;
						case 0:
							if (num >= USQZpFcFQqBJUckpyitMKctsvSza.Length - 1)
							{
								neighbor2 = USQZpFcFQqBJUckpyitMKctsvSza[0];
								return;
							}
							goto default;
						default:
							neighbor2 = USQZpFcFQqBJUckpyitMKctsvSza[num + 1];
							return;
						}
						break;
					}
					continue;
					IL_0050:
					neighbor1 = USQZpFcFQqBJUckpyitMKctsvSza[USQZpFcFQqBJUckpyitMKctsvSza.Length - 1];
					num2 = -1712260401;
					goto IL_0018;
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
				while (true)
				{
					int num2 = -353430988;
					while (true)
					{
						switch (num2 ^ -353430992)
						{
						case 0:
							break;
						case 4:
							num2 = -353430990;
							continue;
						case 3:
							return num;
						case 1:
							if (USQZpFcFQqBJUckpyitMKctsvSza[num] != button)
							{
								num++;
								num2 = -353430990;
							}
							else
							{
								num2 = -353430989;
							}
							continue;
						default:
							if (num >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
							{
								return -1;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			public bool Contains(int button)
			{
				return IndexOf(button) >= 0;
			}
		}

		private HatButtons USQZpFcFQqBJUckpyitMKctsvSza;

		public UnknownControllerHat(HatButtons buttons)
		{
			USQZpFcFQqBJUckpyitMKctsvSza = buttons;
		}

		public bool ContainsButtonIndex(int index)
		{
			int num = 0;
			while (num < 8)
			{
				while (true)
				{
					if (USQZpFcFQqBJUckpyitMKctsvSza.Contains(index))
					{
						return true;
					}
					num++;
					int num2 = -282641036;
					while (true)
					{
						switch (num2 ^ -282641034)
						{
						case 0:
							num2 = -282641033;
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
			return false;
		}

		public bool IsButtonIndexCardinal(int index)
		{
			int num = 0;
			while (num < 8)
			{
				while (true)
				{
					if (USQZpFcFQqBJUckpyitMKctsvSza.IsCardinal(index))
					{
						return true;
					}
					num++;
					int num2 = 1732061514;
					while (true)
					{
						switch (num2 ^ 0x673D294B)
						{
						case 0:
							num2 = 1732061513;
							continue;
						case 2:
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
			return false;
		}

		public HatButtons GetButtons()
		{
			return USQZpFcFQqBJUckpyitMKctsvSza;
		}
	}
}
