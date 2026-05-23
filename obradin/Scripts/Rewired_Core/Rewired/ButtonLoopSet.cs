using System;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public class ButtonData
		{
			public readonly UpdateLoopType updateLoop;

			public readonly bool[] values;

			public readonly bool[] wasTrueThisFrame;

			private bool[] yLcKyplATDtKpQJbbiiakCnWHNWK;

			private int xiHhuAwNmZupzBiSwIQaUwPddBu;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						RMIeREvbpeqeiLrGQwrVlkuuGFx();
					}
					return yLcKyplATDtKpQJbbiiakCnWHNWK;
				}
			}

			public ButtonData(int count, UpdateLoopType updateLoop)
			{
				this.updateLoop = updateLoop;
				values = new bool[count];
				wasTrueThisFrame = new bool[count];
				yLcKyplATDtKpQJbbiiakCnWHNWK = new bool[count];
				xiHhuAwNmZupzBiSwIQaUwPddBu = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					RMIeREvbpeqeiLrGQwrVlkuuGFx();
					goto IL_000f;
				}
				goto IL_0031;
				IL_0031:
				values[index] = value;
				int num;
				int num2;
				if (!value)
				{
					num = 1459931461;
					num2 = num;
				}
				else
				{
					num = 1459931460;
					num2 = num;
				}
				goto IL_0014;
				IL_000f:
				num = 1459931463;
				goto IL_0014;
				IL_0014:
				while (true)
				{
					switch (num ^ 0x5704C944)
					{
					case 2:
						break;
					case 3:
						goto IL_0031;
					case 0:
						wasTrueThisFrame[index] = true;
						num = 1459931461;
						continue;
					default:
						yLcKyplATDtKpQJbbiiakCnWHNWK[index] = value | wasTrueThisFrame[index];
						return;
					}
					break;
				}
				goto IL_000f;
			}

			public void ClearWasTrueThisFrame()
			{
				int num = 0;
				while (true)
				{
					int num2 = -1475835075;
					while (true)
					{
						switch (num2 ^ -1475835079)
						{
						case 0:
							break;
						default:
							return;
						case 4:
							num2 = -1475835080;
							continue;
						case 1:
						{
							int num3;
							if (num >= values.Length)
							{
								num2 = -1475835077;
								num3 = num2;
							}
							else
							{
								num2 = -1475835078;
								num3 = num2;
							}
							continue;
						}
						case 3:
							wasTrueThisFrame[num] = false;
							yLcKyplATDtKpQJbbiiakCnWHNWK[num] = values[num];
							num++;
							num2 = -1475835080;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				while (true)
				{
					int num = -666767296;
					while (true)
					{
						switch (num ^ -666767294)
						{
						case 0:
							break;
						case 2:
							goto IL_0046;
						default:
							xiHhuAwNmZupzBiSwIQaUwPddBu = ReInput.timeScalePauseChangedCount;
							return;
						}
						break;
						IL_0046:
						Array.Clear(yLcKyplATDtKpQJbbiiakCnWHNWK, 0, yLcKyplATDtKpQJbbiiakCnWHNWK.Length);
						num = -666767293;
					}
				}
			}

			public void Import(ButtonData source)
			{
				if (source == null)
				{
					goto IL_0003;
				}
				goto IL_003c;
				IL_0003:
				int num = 913969570;
				goto IL_0008;
				IL_0008:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ 0x367A11A4)
					{
					case 5:
						break;
					case 6:
						return;
					case 2:
						goto IL_003c;
					case 3:
						xiHhuAwNmZupzBiSwIQaUwPddBu = source.xiHhuAwNmZupzBiSwIQaUwPddBu;
						num = 913969572;
						continue;
					case 4:
						values[num2] = source.values[num2];
						wasTrueThisFrame[num2] = source.wasTrueThisFrame[num2];
						yLcKyplATDtKpQJbbiiakCnWHNWK[num2] = source.yLcKyplATDtKpQJbbiiakCnWHNWK[num2];
						num = 913969575;
						continue;
					case 0:
						num2++;
						num = 913969573;
						continue;
					default:
						if (num2 >= num3)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
				goto IL_0003;
				IL_003c:
				num3 = MathTools.Min(values.Length, source.values.Length);
				num2 = 0;
				num = 913969573;
				goto IL_0008;
			}

			private void RMIeREvbpeqeiLrGQwrVlkuuGFx()
			{
				if (ReInput.timeScalePauseChangedCount == xiHhuAwNmZupzBiSwIQaUwPddBu)
				{
					return;
				}
				while (true)
				{
					int num = -1223877489;
					while (true)
					{
						switch (num ^ -1223877491)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_002b;
						case 1:
							return;
						}
						break;
						IL_002b:
						ClearWasTrueThisFrame();
						xiHhuAwNmZupzBiSwIQaUwPddBu = ReInput.timeScalePauseChangedCount;
						num = -1223877492;
					}
				}
			}
		}

		public readonly int buttonCount;

		public ButtonLoopSet(UpdateLoopSetting updateLoops, int buttonCount)
			: base(updateLoops)
		{
			this.buttonCount = buttonCount;
			for (int i = 0; i < base.Count; i++)
			{
				base[i] = new ButtonData(buttonCount, GetUpdateLoopType(i));
			}
		}

		public void SetValue(int index, bool value, float timestamp)
		{
			int count = base.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					base[num].SetValue(index, value);
					num++;
					int num2 = -2112371720;
					while (true)
					{
						switch (num2 ^ -2112371719)
						{
						case 0:
							num2 = -2112371717;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0029;
						}
						break;
					}
					continue;
					end_IL_0029:
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
					num++;
					int num2 = -2034425921;
					while (true)
					{
						switch (num2 ^ -2034425922)
						{
						case 0:
							num2 = -2034425924;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0029;
						}
						break;
					}
					continue;
					end_IL_0029:
					break;
				}
			}
		}

		public void Import(ButtonLoopSet set)
		{
			if (set == null)
			{
				throw new ArgumentNullException("set");
			}
			while (true)
			{
				if (set.buttonCount != buttonCount)
				{
					throw new Exception("Cannot import from a set with a different button count.");
				}
				while (true)
				{
					IL_0072:
					int num = 0;
					int num2 = 332121698;
					while (true)
					{
						switch (num2 ^ 0x13CBC662)
						{
						case 3:
							num2 = 332121699;
							continue;
						case 1:
							break;
						case 2:
							base[num].Import(set[num]);
							num++;
							num2 = 332121698;
							continue;
						case 4:
							goto IL_0072;
						default:
							if (num >= base.Count)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
					break;
				}
			}
		}
	}
}
