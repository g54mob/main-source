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

			private bool[] BamRxaLWHLkzKcWgBUgkzkrAZAB;

			private int YwXLxFUugBvKEpnDMHMqjfVrpYf;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						sMWbNQXhIkNLKhmlgyHQAecxNoX();
					}
					return BamRxaLWHLkzKcWgBUgkzkrAZAB;
				}
			}

			public ButtonData(int count, UpdateLoopType updateLoop)
			{
				this.updateLoop = updateLoop;
				values = new bool[count];
				wasTrueThisFrame = new bool[count];
				BamRxaLWHLkzKcWgBUgkzkrAZAB = new bool[count];
				YwXLxFUugBvKEpnDMHMqjfVrpYf = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					sMWbNQXhIkNLKhmlgyHQAecxNoX();
					goto IL_000f;
				}
				goto IL_002d;
				IL_0049:
				BamRxaLWHLkzKcWgBUgkzkrAZAB[index] = value | wasTrueThisFrame[index];
				return;
				IL_000f:
				int num = -1889981484;
				goto IL_0014;
				IL_0014:
				switch (num ^ -1889981483)
				{
				case 0:
					break;
				case 1:
					goto IL_002d;
				default:
					goto IL_0049;
				}
				goto IL_000f;
				IL_002d:
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					num = -1889981481;
					goto IL_0014;
				}
				goto IL_0049;
			}

			public void ClearWasTrueThisFrame()
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < values.Length)
					{
						num2 = 771327972;
						num3 = num2;
					}
					else
					{
						num2 = 771327969;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x2DF987E0)
						{
						case 2:
							num2 = 771327972;
							continue;
						default:
							return;
						case 4:
							wasTrueThisFrame[num] = false;
							num2 = 771327971;
							continue;
						case 3:
							BamRxaLWHLkzKcWgBUgkzkrAZAB[num] = values[num];
							num++;
							num2 = 771327968;
							continue;
						case 0:
							break;
						case 1:
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
				Array.Clear(BamRxaLWHLkzKcWgBUgkzkrAZAB, 0, BamRxaLWHLkzKcWgBUgkzkrAZAB.Length);
				while (true)
				{
					int num = 1443911520;
					while (true)
					{
						switch (num ^ 0x56105761)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_005a;
						case 2:
							return;
						}
						break;
						IL_005a:
						YwXLxFUugBvKEpnDMHMqjfVrpYf = ReInput.timeScalePauseChangedCount;
						num = 1443911523;
					}
				}
			}

			public void Import(ButtonData source)
			{
				if (source == null)
				{
					goto IL_0006;
				}
				goto IL_0091;
				IL_0006:
				int num = -1896402400;
				goto IL_000b;
				IL_000b:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -1896402399)
					{
					case 4:
						break;
					default:
						return;
					case 7:
						wasTrueThisFrame[num2] = source.wasTrueThisFrame[num2];
						BamRxaLWHLkzKcWgBUgkzkrAZAB[num2] = source.BamRxaLWHLkzKcWgBUgkzkrAZAB[num2];
						YwXLxFUugBvKEpnDMHMqjfVrpYf = source.YwXLxFUugBvKEpnDMHMqjfVrpYf;
						num2++;
						num = -1896402399;
						continue;
					case 2:
						num = -1896402399;
						continue;
					case 0:
						goto IL_0079;
					case 5:
						goto IL_0091;
					case 1:
						return;
					case 3:
						values[num2] = source.values[num2];
						num = -1896402394;
						continue;
					case 6:
						return;
					}
					break;
					IL_0079:
					int num4;
					if (num2 < num3)
					{
						num = -1896402398;
						num4 = num;
					}
					else
					{
						num = -1896402393;
						num4 = num;
					}
				}
				goto IL_0006;
				IL_0091:
				num3 = MathTools.Min(values.Length, source.values.Length);
				num2 = 0;
				num = -1896402397;
				goto IL_000b;
			}

			private void sMWbNQXhIkNLKhmlgyHQAecxNoX()
			{
				if (ReInput.timeScalePauseChangedCount != YwXLxFUugBvKEpnDMHMqjfVrpYf)
				{
					ClearWasTrueThisFrame();
					YwXLxFUugBvKEpnDMHMqjfVrpYf = ReInput.timeScalePauseChangedCount;
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
				int num = 1009273931;
				while (true)
				{
					switch (num ^ 0x3C284C4A)
					{
					case 3:
						break;
					case 1:
						this.buttonCount = buttonCount;
						num2 = 0;
						num = 1009273930;
						continue;
					case 2:
						base[num2] = new ButtonData(buttonCount, GetUpdateLoopType(num2));
						num2++;
						num = 1009273930;
						continue;
					default:
						if (num2 >= base.Count)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public void SetValue(int index, bool value, float timestamp)
		{
			int count = base.Count;
			int num = 0;
			while (true)
			{
				int num2 = -1084782821;
				while (true)
				{
					switch (num2 ^ -1084782817)
					{
					case 5:
						break;
					default:
						return;
					case 1:
					{
						int num3;
						if (num >= count)
						{
							num2 = -1084782819;
							num3 = num2;
						}
						else
						{
							num2 = -1084782820;
							num3 = num2;
						}
						continue;
					}
					case 0:
						num++;
						num2 = -1084782818;
						continue;
					case 3:
						base[num].SetValue(index, value);
						num2 = -1084782817;
						continue;
					case 4:
						num2 = -1084782818;
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
			int count = base.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					base[num].Clear();
					int num2 = 573138991;
					while (true)
					{
						switch (num2 ^ 0x2229682F)
						{
						case 2:
							num2 = 573138988;
							continue;
						case 3:
							break;
						case 0:
							num++;
							num2 = 573138990;
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
				throw new ArgumentNullException("set");
			}
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (set.buttonCount != buttonCount)
				{
					num = 243851176;
					num2 = num;
				}
				else
				{
					num = 243851181;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0xE88DFA9)
					{
					case 6:
						num = 243851178;
						continue;
					case 3:
						break;
					case 2:
						num = 243851180;
						continue;
					case 0:
						base[num3].Import(set[num3]);
						num3++;
						num = 243851180;
						continue;
					case 1:
						throw new Exception("Cannot import from a set with a different button count.");
					case 4:
						num3 = 0;
						num = 243851179;
						continue;
					default:
						if (num3 >= base.Count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}
	}
}
