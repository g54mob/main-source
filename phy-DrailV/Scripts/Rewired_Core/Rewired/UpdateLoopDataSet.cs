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
		private class DudRIXFvXrBCEBoHrAqhWFmkRxXU
		{
			public readonly UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA;

			public T VwpBgMvWwAXYQzeWHeKuTetHBYkFA;

			public DudRIXFvXrBCEBoHrAqhWFmkRxXU(UpdateLoopType P_0)
			{
				duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_0;
			}
		}

		private const int RSHnhxxOugJibPisZsZYLfZJbTfX = 0;

		private DudRIXFvXrBCEBoHrAqhWFmkRxXU BmKvSKNqYdAInmnyOqwkFOfGayFo;

		private int dPaZjxYVpAOrsrCjtxboEyCaVuap;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] qBPyKTtMpLyIJSozDZTyShrEsyEL;

		private readonly DudRIXFvXrBCEBoHrAqhWFmkRxXU[] pAccjjftkSoAMvoMwnZTEXrzHEChb;

		private UpdateLoopType vipPggMIzNnCONoHGIardNQyJDAXA = (UpdateLoopType)(-1);

		public T Current => BmKvSKNqYdAInmnyOqwkFOfGayFo.VwpBgMvWwAXYQzeWHeKuTetHBYkFA;

		public int Count => dPaZjxYVpAOrsrCjtxboEyCaVuap;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= dPaZjxYVpAOrsrCjtxboEyCaVuap)
				{
					throw new IndexOutOfRangeException();
				}
				return pAccjjftkSoAMvoMwnZTEXrzHEChb[index].VwpBgMvWwAXYQzeWHeKuTetHBYkFA;
			}
			set
			{
				if (index < 0 || index >= dPaZjxYVpAOrsrCjtxboEyCaVuap)
				{
					throw new IndexOutOfRangeException();
				}
				pAccjjftkSoAMvoMwnZTEXrzHEChb[index].VwpBgMvWwAXYQzeWHeKuTetHBYkFA = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			qBPyKTtMpLyIJSozDZTyShrEsyEL = new int[3];
			ArrayTools.Fill(qBPyKTtMpLyIJSozDZTyShrEsyEL, -1);
			List<DudRIXFvXrBCEBoHrAqhWFmkRxXU> list = new List<DudRIXFvXrBCEBoHrAqhWFmkRxXU>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					DudRIXFvXrBCEBoHrAqhWFmkRxXU dudRIXFvXrBCEBoHrAqhWFmkRxXU = new DudRIXFvXrBCEBoHrAqhWFmkRxXU(list2[i]);
					if (P_1 != null)
					{
						T vwpBgMvWwAXYQzeWHeKuTetHBYkFA = P_1();
						dudRIXFvXrBCEBoHrAqhWFmkRxXU.VwpBgMvWwAXYQzeWHeKuTetHBYkFA = vwpBgMvWwAXYQzeWHeKuTetHBYkFA;
					}
					list.Add(dudRIXFvXrBCEBoHrAqhWFmkRxXU);
					qBPyKTtMpLyIJSozDZTyShrEsyEL[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			pAccjjftkSoAMvoMwnZTEXrzHEChb = list.ToArray();
			dPaZjxYVpAOrsrCjtxboEyCaVuap = pAccjjftkSoAMvoMwnZTEXrzHEChb.Length;
			SetUpdateLoop(pAccjjftkSoAMvoMwnZTEXrzHEChb[0].duvdeoIMbviHBoTTDYZbkoEpbLKZA);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (vipPggMIzNnCONoHGIardNQyJDAXA != updateLoop)
			{
				vipPggMIzNnCONoHGIardNQyJDAXA = updateLoop;
				BmKvSKNqYdAInmnyOqwkFOfGayFo = pAccjjftkSoAMvoMwnZTEXrzHEChb[qBPyKTtMpLyIJSozDZTyShrEsyEL[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= dPaZjxYVpAOrsrCjtxboEyCaVuap)
			{
				throw new IndexOutOfRangeException();
			}
			return pAccjjftkSoAMvoMwnZTEXrzHEChb[index].VwpBgMvWwAXYQzeWHeKuTetHBYkFA;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return pAccjjftkSoAMvoMwnZTEXrzHEChb[qBPyKTtMpLyIJSozDZTyShrEsyEL[(int)updateLoop]].VwpBgMvWwAXYQzeWHeKuTetHBYkFA;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= dPaZjxYVpAOrsrCjtxboEyCaVuap)
			{
				throw new IndexOutOfRangeException();
			}
			pAccjjftkSoAMvoMwnZTEXrzHEChb[index].VwpBgMvWwAXYQzeWHeKuTetHBYkFA = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= dPaZjxYVpAOrsrCjtxboEyCaVuap)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return pAccjjftkSoAMvoMwnZTEXrzHEChb[index].duvdeoIMbviHBoTTDYZbkoEpbLKZA;
		}
	}
}
