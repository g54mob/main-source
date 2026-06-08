using System;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class ButtonData
		{
			public readonly UpdateLoopType updateLoop;

			public readonly bool[] values;

			public readonly bool[] wasTrueThisFrame;

			private bool[] yVaaUbramFwaBRfFShJrDfLFdVuJ;

			private int xsNOiUmdRRIZLObmBVxvdOvciJQ;

			private readonly bool[] OrhvImkDmRrHQFLoFOyUwKvxiAc;

			private readonly bool[] tKEkBPrDmnuamuMGsOykHIoAbLZ;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						HpMWOErVUokKOCSHpFXEQbKtFSRj();
					}
					return yVaaUbramFwaBRfFShJrDfLFdVuJ;
				}
			}

			public ButtonData(int count, UpdateLoopType updateLoop)
			{
				this.updateLoop = updateLoop;
				values = new bool[count];
				tKEkBPrDmnuamuMGsOykHIoAbLZ = new bool[count];
				wasTrueThisFrame = new bool[count];
				OrhvImkDmRrHQFLoFOyUwKvxiAc = new bool[count];
				yVaaUbramFwaBRfFShJrDfLFdVuJ = new bool[count];
				xsNOiUmdRRIZLObmBVxvdOvciJQ = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					HpMWOErVUokKOCSHpFXEQbKtFSRj();
					goto IL_000f;
				}
				goto IL_0031;
				IL_0060:
				yVaaUbramFwaBRfFShJrDfLFdVuJ[index] = value | OrhvImkDmRrHQFLoFOyUwKvxiAc[index];
				tKEkBPrDmnuamuMGsOykHIoAbLZ[index] = value;
				int num = 850976955;
				goto IL_0014;
				IL_000f:
				num = 850976953;
				goto IL_0014;
				IL_0014:
				switch (num ^ 0x32B8E0BA)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					goto IL_0031;
				case 0:
					goto IL_0060;
				case 1:
					return;
				}
				goto IL_000f;
				IL_0031:
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!tKEkBPrDmnuamuMGsOykHIoAbLZ[index])
					{
						OrhvImkDmRrHQFLoFOyUwKvxiAc[index] = true;
						num = 850976954;
						goto IL_0014;
					}
				}
				goto IL_0060;
			}

			public void ClearWasTrueThisFrame()
			{
				int num = 0;
				while (true)
				{
					int num2 = 258293272;
					while (true)
					{
						switch (num2 ^ 0xF653E1B)
						{
						case 2:
							break;
						case 3:
							num2 = 258293274;
							continue;
						case 0:
							wasTrueThisFrame[num] = false;
							num2 = 258293279;
							continue;
						case 4:
							OrhvImkDmRrHQFLoFOyUwKvxiAc[num] = false;
							yVaaUbramFwaBRfFShJrDfLFdVuJ[num] = values[num];
							num++;
							num2 = 258293274;
							continue;
						default:
							if (num >= values.Length)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(tKEkBPrDmnuamuMGsOykHIoAbLZ, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(OrhvImkDmRrHQFLoFOyUwKvxiAc, 0, OrhvImkDmRrHQFLoFOyUwKvxiAc.Length);
				Array.Clear(yVaaUbramFwaBRfFShJrDfLFdVuJ, 0, yVaaUbramFwaBRfFShJrDfLFdVuJ.Length);
				while (true)
				{
					int num = -643351206;
					while (true)
					{
						switch (num ^ -643351205)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0082;
						case 2:
							return;
						}
						break;
						IL_0082:
						xsNOiUmdRRIZLObmBVxvdOvciJQ = ReInput.timeScalePauseChangedCount;
						num = -643351207;
					}
				}
			}

			public void Import(ButtonData source)
			{
				if (source == null)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					int num2 = -1090486902;
					while (true)
					{
						switch (num2 ^ -1090486898)
						{
						case 0:
							num2 = -1090486897;
							continue;
						case 1:
							break;
						case 2:
							values[num3] = source.values[num3];
							tKEkBPrDmnuamuMGsOykHIoAbLZ[num3] = source.tKEkBPrDmnuamuMGsOykHIoAbLZ[num3];
							wasTrueThisFrame[num3] = source.wasTrueThisFrame[num3];
							OrhvImkDmRrHQFLoFOyUwKvxiAc[num3] = source.OrhvImkDmRrHQFLoFOyUwKvxiAc[num3];
							yVaaUbramFwaBRfFShJrDfLFdVuJ[num3] = source.yVaaUbramFwaBRfFShJrDfLFdVuJ[num3];
							xsNOiUmdRRIZLObmBVxvdOvciJQ = source.xsNOiUmdRRIZLObmBVxvdOvciJQ;
							num3++;
							num2 = -1090486899;
							continue;
						case 4:
							num3 = 0;
							num2 = -1090486899;
							continue;
						default:
							if (num3 >= num)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			private void HpMWOErVUokKOCSHpFXEQbKtFSRj()
			{
				if (ReInput.timeScalePauseChangedCount != xsNOiUmdRRIZLObmBVxvdOvciJQ)
				{
					ClearWasTrueThisFrame();
					xsNOiUmdRRIZLObmBVxvdOvciJQ = ReInput.timeScalePauseChangedCount;
				}
			}
		}

		public readonly int buttonCount;

		public ButtonLoopSet(UpdateLoopSetting updateLoops, int buttonCount)
			: base(updateLoops)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 353452382;
				while (true)
				{
					switch (num ^ 0x1511415B)
					{
					case 2:
						break;
					default:
						return;
					case 5:
						this.buttonCount = buttonCount;
						num = 353452383;
						continue;
					case 1:
						base[num2] = new ButtonData(buttonCount, GetUpdateLoopType(num2));
						num2++;
						num = 353452379;
						continue;
					case 4:
						num2 = 0;
						num = 353452379;
						continue;
					case 0:
					{
						int num3;
						if (num2 >= base.Count)
						{
							num = 353452376;
							num3 = num;
						}
						else
						{
							num = 353452378;
							num3 = num;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		public void SetValue(int index, bool value, double timestamp)
		{
			int count = base.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					base[num].SetValue(index, value);
					int num2 = 217464304;
					while (true)
					{
						switch (num2 ^ 0xCF63DF0)
						{
						case 3:
							num2 = 217464305;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = 217464306;
							continue;
						default:
							goto end_IL_002d;
						}
						break;
					}
					continue;
					end_IL_002d:
					break;
				}
			}
		}

		public void Clear()
		{
			int count = base.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					base[num].Clear();
					int num2 = -5291897;
					while (true)
					{
						switch (num2 ^ -5291897)
						{
						case 2:
							num2 = -5291898;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = -5291900;
							continue;
						default:
							goto end_IL_002d;
						}
						break;
					}
					continue;
					end_IL_002d:
					break;
				}
			}
		}

		public void Import(ButtonLoopSet set)
		{
			if (set == null)
			{
				goto IL_0006;
			}
			goto IL_00a6;
			IL_0006:
			int num = -970775718;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -970775720)
				{
				case 6:
					break;
				default:
					return;
				case 1:
					num2 = 0;
					num = -970775717;
					continue;
				case 3:
					goto IL_0044;
				case 2:
					throw new ArgumentNullException("set");
				case 5:
					base[num2].Import(set[num2]);
					num2++;
					num = -970775717;
					continue;
				case 0:
					throw new Exception("Cannot import from a set with a different button count.");
				case 7:
					goto IL_00a6;
				case 4:
					return;
				}
				break;
				IL_0044:
				int num3;
				if (num2 >= base.Count)
				{
					num = -970775716;
					num3 = num;
				}
				else
				{
					num = -970775715;
					num3 = num;
				}
			}
			goto IL_0006;
			IL_00a6:
			int num4;
			if (set.buttonCount == buttonCount)
			{
				num = -970775719;
				num4 = num;
			}
			else
			{
				num = -970775720;
				num4 = num;
			}
			goto IL_000b;
		}
	}
}
