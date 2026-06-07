using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class UpdateLoopDataSet<T> where T : class
	{
		private class zmkyqApdiyumZYCEYXSCBGAYRDY
		{
			public readonly UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

			public T rAkUsdTnKPsjogOHmtoXScXdcVa;

			public zmkyqApdiyumZYCEYXSCBGAYRDY(UpdateLoopType updateLoop)
			{
				NigWaDmPBoxUjERAcsoKpawNrzS = updateLoop;
			}
		}

		private const int hXCXUXHQHtOZvGnfqedROlXbddx = 0;

		private zmkyqApdiyumZYCEYXSCBGAYRDY pcVFijrvkqFyLhAbvkXHMUHuNUD;

		private int DfhXuMaZHXFIKwxsAEGTRtoUKDe;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] GGUmNuLERIewxJGyglaRVORwSAG;

		private readonly zmkyqApdiyumZYCEYXSCBGAYRDY[] HgdVUQPGOJaacdFXVfmkaGDFLgE;

		private UpdateLoopType JWmORTeXAYeHkYUnfXCOKcgEbWM = (UpdateLoopType)(-1);

		public T Current
		{
			get
			{
				return pcVFijrvkqFyLhAbvkXHMUHuNUD.rAkUsdTnKPsjogOHmtoXScXdcVa;
			}
		}

		public int Count
		{
			get
			{
				return DfhXuMaZHXFIKwxsAEGTRtoUKDe;
			}
		}

		public T this[int index]
		{
			get
			{
				if (index >= 0)
				{
					if (index < DfhXuMaZHXFIKwxsAEGTRtoUKDe)
					{
						goto IL_0038;
					}
					while (true)
					{
						switch (0x3A5D8C37 ^ 0x3A5D8C36)
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
				return HgdVUQPGOJaacdFXVfmkaGDFLgE[index].rAkUsdTnKPsjogOHmtoXScXdcVa;
			}
			set
			{
				if (index >= 0)
				{
					if (index < DfhXuMaZHXFIKwxsAEGTRtoUKDe)
					{
						goto IL_0038;
					}
					while (true)
					{
						switch (-1398928711 ^ -1398928709)
						{
						case 0:
							break;
						case 2:
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
				HgdVUQPGOJaacdFXVfmkaGDFLgE[index].rAkUsdTnKPsjogOHmtoXScXdcVa = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops)
			: this(updateLoops, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops, Func<T> instantiatorDelegate)
		{
			GGUmNuLERIewxJGyglaRVORwSAG = new int[3];
			ArrayTools.Fill(GGUmNuLERIewxJGyglaRVORwSAG, -1);
			List<zmkyqApdiyumZYCEYXSCBGAYRDY> list = new List<zmkyqApdiyumZYCEYXSCBGAYRDY>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoops, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					zmkyqApdiyumZYCEYXSCBGAYRDY zmkyqApdiyumZYCEYXSCBGAYRDY2 = new zmkyqApdiyumZYCEYXSCBGAYRDY(list2[i]);
					if (instantiatorDelegate != null)
					{
						T rAkUsdTnKPsjogOHmtoXScXdcVa = instantiatorDelegate();
						zmkyqApdiyumZYCEYXSCBGAYRDY2.rAkUsdTnKPsjogOHmtoXScXdcVa = rAkUsdTnKPsjogOHmtoXScXdcVa;
					}
					list.Add(zmkyqApdiyumZYCEYXSCBGAYRDY2);
					GGUmNuLERIewxJGyglaRVORwSAG[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			HgdVUQPGOJaacdFXVfmkaGDFLgE = list.ToArray();
			DfhXuMaZHXFIKwxsAEGTRtoUKDe = HgdVUQPGOJaacdFXVfmkaGDFLgE.Length;
			SetUpdateLoop(HgdVUQPGOJaacdFXVfmkaGDFLgE[0].NigWaDmPBoxUjERAcsoKpawNrzS);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (JWmORTeXAYeHkYUnfXCOKcgEbWM == updateLoop)
			{
				return;
			}
			while (true)
			{
				JWmORTeXAYeHkYUnfXCOKcgEbWM = updateLoop;
				pcVFijrvkqFyLhAbvkXHMUHuNUD = HgdVUQPGOJaacdFXVfmkaGDFLgE[GGUmNuLERIewxJGyglaRVORwSAG[(int)updateLoop]];
				int num = -2037715815;
				while (true)
				{
					switch (num ^ -2037715816)
					{
					case 0:
						goto IL_000a;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000a:
					num = -2037715814;
				}
			}
		}

		public T Get(int index)
		{
			if (index >= 0)
			{
				if (index < DfhXuMaZHXFIKwxsAEGTRtoUKDe)
				{
					goto IL_0038;
				}
				while (true)
				{
					switch (-570852156 ^ -570852155)
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
			return HgdVUQPGOJaacdFXVfmkaGDFLgE[index].rAkUsdTnKPsjogOHmtoXScXdcVa;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return HgdVUQPGOJaacdFXVfmkaGDFLgE[GGUmNuLERIewxJGyglaRVORwSAG[(int)updateLoop]].rAkUsdTnKPsjogOHmtoXScXdcVa;
		}

		public void Set(int index, T item)
		{
			if (index >= 0)
			{
				if (index < DfhXuMaZHXFIKwxsAEGTRtoUKDe)
				{
					goto IL_0038;
				}
				while (true)
				{
					switch (0x13498E01 ^ 0x13498E03)
					{
					case 0:
						break;
					case 2:
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
			HgdVUQPGOJaacdFXVfmkaGDFLgE[index].rAkUsdTnKPsjogOHmtoXScXdcVa = item;
		}

		protected UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index >= 0)
			{
				if (index < DfhXuMaZHXFIKwxsAEGTRtoUKDe)
				{
					goto IL_003d;
				}
				while (true)
				{
					switch (0x26BAA062 ^ 0x26BAA063)
					{
					case 0:
						break;
					case 1:
						goto end_IL_000d;
					default:
						goto IL_003d;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_003d:
			return HgdVUQPGOJaacdFXVfmkaGDFLgE[index].NigWaDmPBoxUjERAcsoKpawNrzS;
		}
	}
}
