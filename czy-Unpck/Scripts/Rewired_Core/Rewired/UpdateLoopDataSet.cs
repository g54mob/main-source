using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UpdateLoopDataSet<T> where T : class
	{
		private class MZuSDdTIOgtbfjmxBbsNVwaZQMs
		{
			public readonly UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

			public T KEojvyjKrFDfpXOmrgEOERpcrbV;

			public MZuSDdTIOgtbfjmxBbsNVwaZQMs(UpdateLoopType updateLoop)
			{
				cmiDdQAFcgEckBbjnNTFEbMKLqrn = updateLoop;
			}
		}

		private const int QEMyeBrbdntDAhkIvUZuYHRiRqO = 0;

		private MZuSDdTIOgtbfjmxBbsNVwaZQMs UbTTHsFpTcFdMEpIqqgECzhjvFu;

		private int ierooXELkRVWTXdTXUdETEGRnJZ;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] zFEnZxjygCrlikqPzBDIAJpbLBfQ;

		private readonly MZuSDdTIOgtbfjmxBbsNVwaZQMs[] sJdOmJvatNYzjWUiYrFrMflMurn;

		private UpdateLoopType gDqAdQbSeGBvnGtzHomNZYImTexl = (UpdateLoopType)(-1);

		public T Current => UbTTHsFpTcFdMEpIqqgECzhjvFu.KEojvyjKrFDfpXOmrgEOERpcrbV;

		public int Count => ierooXELkRVWTXdTXUdETEGRnJZ;

		public T this[int index]
		{
			get
			{
				if (index >= 0)
				{
					if (index < ierooXELkRVWTXdTXUdETEGRnJZ)
					{
						goto IL_0038;
					}
					while (true)
					{
						switch (0x4757676D ^ 0x4757676C)
						{
						case 2:
							break;
						case 1:
							goto end_IL_000d;
						default:
							goto IL_0038;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				throw new IndexOutOfRangeException();
				IL_0038:
				return sJdOmJvatNYzjWUiYrFrMflMurn[index].KEojvyjKrFDfpXOmrgEOERpcrbV;
			}
			set
			{
				if (index < 0)
				{
					goto IL_002f;
				}
				if (index >= ierooXELkRVWTXdTXUdETEGRnJZ)
				{
					goto IL_000d;
				}
				goto IL_003c;
				IL_002f:
				throw new IndexOutOfRangeException();
				IL_000d:
				int num = -2028072854;
				goto IL_0012;
				IL_0012:
				switch (num ^ -2028072855)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					goto IL_002f;
				case 1:
					goto IL_003c;
				case 2:
					return;
				}
				goto IL_000d;
				IL_003c:
				sJdOmJvatNYzjWUiYrFrMflMurn[index].KEojvyjKrFDfpXOmrgEOERpcrbV = value;
				num = -2028072853;
				goto IL_0012;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops)
			: this(updateLoops, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops, Func<T> instantiatorDelegate)
		{
			zFEnZxjygCrlikqPzBDIAJpbLBfQ = new int[3];
			ArrayTools.Fill(zFEnZxjygCrlikqPzBDIAJpbLBfQ, -1);
			List<MZuSDdTIOgtbfjmxBbsNVwaZQMs> list = new List<MZuSDdTIOgtbfjmxBbsNVwaZQMs>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoops, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					MZuSDdTIOgtbfjmxBbsNVwaZQMs mZuSDdTIOgtbfjmxBbsNVwaZQMs = new MZuSDdTIOgtbfjmxBbsNVwaZQMs(list2[i]);
					if (instantiatorDelegate != null)
					{
						T kEojvyjKrFDfpXOmrgEOERpcrbV = instantiatorDelegate();
						mZuSDdTIOgtbfjmxBbsNVwaZQMs.KEojvyjKrFDfpXOmrgEOERpcrbV = kEojvyjKrFDfpXOmrgEOERpcrbV;
					}
					list.Add(mZuSDdTIOgtbfjmxBbsNVwaZQMs);
					zFEnZxjygCrlikqPzBDIAJpbLBfQ[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			sJdOmJvatNYzjWUiYrFrMflMurn = list.ToArray();
			ierooXELkRVWTXdTXUdETEGRnJZ = sJdOmJvatNYzjWUiYrFrMflMurn.Length;
			SetUpdateLoop(sJdOmJvatNYzjWUiYrFrMflMurn[0].cmiDdQAFcgEckBbjnNTFEbMKLqrn);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (gDqAdQbSeGBvnGtzHomNZYImTexl == updateLoop)
			{
				return;
			}
			while (true)
			{
				gDqAdQbSeGBvnGtzHomNZYImTexl = updateLoop;
				int num = -135904656;
				while (true)
				{
					switch (num ^ -135904656)
					{
					case 2:
						goto IL_000a;
					case 1:
						break;
					default:
						UbTTHsFpTcFdMEpIqqgECzhjvFu = sJdOmJvatNYzjWUiYrFrMflMurn[zFEnZxjygCrlikqPzBDIAJpbLBfQ[(int)updateLoop]];
						return;
					}
					break;
					IL_000a:
					num = -135904655;
				}
			}
		}

		public T Get(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -1506041098;
					while (true)
					{
						switch (num ^ -1506041097)
						{
						case 2:
							break;
						case 1:
							goto IL_0026;
						case 3:
							goto end_IL_0004;
						default:
							return sJdOmJvatNYzjWUiYrFrMflMurn[index].KEojvyjKrFDfpXOmrgEOERpcrbV;
						}
						break;
						IL_0026:
						int num2;
						if (index < ierooXELkRVWTXdTXUdETEGRnJZ)
						{
							num = -1506041097;
							num2 = num;
						}
						else
						{
							num = -1506041100;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new IndexOutOfRangeException();
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return sJdOmJvatNYzjWUiYrFrMflMurn[zFEnZxjygCrlikqPzBDIAJpbLBfQ[(int)updateLoop]].KEojvyjKrFDfpXOmrgEOERpcrbV;
		}

		public void Set(int index, T item)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -300441152;
					while (true)
					{
						switch (num ^ -300441151)
						{
						case 3:
							break;
						case 1:
							goto IL_0026;
						case 0:
							goto end_IL_0004;
						default:
							sJdOmJvatNYzjWUiYrFrMflMurn[index].KEojvyjKrFDfpXOmrgEOERpcrbV = item;
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index < ierooXELkRVWTXdTXUdETEGRnJZ)
						{
							num = -300441149;
							num2 = num;
						}
						else
						{
							num = -300441151;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new IndexOutOfRangeException();
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 213920591;
					while (true)
					{
						switch (num ^ 0xCC02B4D)
						{
						case 3:
							break;
						case 2:
							goto IL_0026;
						case 1:
							goto end_IL_0004;
						default:
							return sJdOmJvatNYzjWUiYrFrMflMurn[index].cmiDdQAFcgEckBbjnNTFEbMKLqrn;
						}
						break;
						IL_0026:
						int num2;
						if (index >= ierooXELkRVWTXdTXUdETEGRnJZ)
						{
							num = 213920588;
							num2 = num;
						}
						else
						{
							num = 213920589;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}
	}
}
