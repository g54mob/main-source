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
		private class EkSEJQhBBIhNJymXcdhSkPXOGufn
		{
			public readonly UpdateLoopType jbHIConMbuKIoCGUWoBAcTfniXUr;

			public T GGlDtnHInFKgrSXqCdDTxSYpDqwqA;

			public EkSEJQhBBIhNJymXcdhSkPXOGufn(UpdateLoopType P_0)
			{
				jbHIConMbuKIoCGUWoBAcTfniXUr = P_0;
			}
		}

		private const int xVfIcfFJDYabQPxyLjkimQYdNDcO = 0;

		private EkSEJQhBBIhNJymXcdhSkPXOGufn TqCOxYVaridjzAAdcKmpkmnzNaigb;

		private int NjnOpHDtOZbCwpFxPfWiaqeqMEjlA;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] IspwRUEhRpbtUtpnskcAKOCLbZzQ;

		private readonly EkSEJQhBBIhNJymXcdhSkPXOGufn[] XebwmfEmwNeSEgAOBLiojFMFWElLb;

		private UpdateLoopType hqaEsnXWEsjEBIHRTPfmKzdIpHPv = (UpdateLoopType)(-1);

		public T Current => TqCOxYVaridjzAAdcKmpkmnzNaigb.GGlDtnHInFKgrSXqCdDTxSYpDqwqA;

		public int Count => NjnOpHDtOZbCwpFxPfWiaqeqMEjlA;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= NjnOpHDtOZbCwpFxPfWiaqeqMEjlA)
				{
					throw new IndexOutOfRangeException();
				}
				return XebwmfEmwNeSEgAOBLiojFMFWElLb[index].GGlDtnHInFKgrSXqCdDTxSYpDqwqA;
			}
			set
			{
				if (index < 0 || index >= NjnOpHDtOZbCwpFxPfWiaqeqMEjlA)
				{
					throw new IndexOutOfRangeException();
				}
				XebwmfEmwNeSEgAOBLiojFMFWElLb[index].GGlDtnHInFKgrSXqCdDTxSYpDqwqA = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			IspwRUEhRpbtUtpnskcAKOCLbZzQ = new int[3];
			ArrayTools.Fill(IspwRUEhRpbtUtpnskcAKOCLbZzQ, -1);
			List<EkSEJQhBBIhNJymXcdhSkPXOGufn> list = new List<EkSEJQhBBIhNJymXcdhSkPXOGufn>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					EkSEJQhBBIhNJymXcdhSkPXOGufn ekSEJQhBBIhNJymXcdhSkPXOGufn = new EkSEJQhBBIhNJymXcdhSkPXOGufn(list2[i]);
					if (P_1 != null)
					{
						T gGlDtnHInFKgrSXqCdDTxSYpDqwqA = P_1();
						ekSEJQhBBIhNJymXcdhSkPXOGufn.GGlDtnHInFKgrSXqCdDTxSYpDqwqA = gGlDtnHInFKgrSXqCdDTxSYpDqwqA;
					}
					list.Add(ekSEJQhBBIhNJymXcdhSkPXOGufn);
					IspwRUEhRpbtUtpnskcAKOCLbZzQ[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			XebwmfEmwNeSEgAOBLiojFMFWElLb = list.ToArray();
			NjnOpHDtOZbCwpFxPfWiaqeqMEjlA = XebwmfEmwNeSEgAOBLiojFMFWElLb.Length;
			SetUpdateLoop(XebwmfEmwNeSEgAOBLiojFMFWElLb[0].jbHIConMbuKIoCGUWoBAcTfniXUr);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (hqaEsnXWEsjEBIHRTPfmKzdIpHPv != updateLoop)
			{
				hqaEsnXWEsjEBIHRTPfmKzdIpHPv = updateLoop;
				TqCOxYVaridjzAAdcKmpkmnzNaigb = XebwmfEmwNeSEgAOBLiojFMFWElLb[IspwRUEhRpbtUtpnskcAKOCLbZzQ[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= NjnOpHDtOZbCwpFxPfWiaqeqMEjlA)
			{
				throw new IndexOutOfRangeException();
			}
			return XebwmfEmwNeSEgAOBLiojFMFWElLb[index].GGlDtnHInFKgrSXqCdDTxSYpDqwqA;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return XebwmfEmwNeSEgAOBLiojFMFWElLb[IspwRUEhRpbtUtpnskcAKOCLbZzQ[(int)updateLoop]].GGlDtnHInFKgrSXqCdDTxSYpDqwqA;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= NjnOpHDtOZbCwpFxPfWiaqeqMEjlA)
			{
				throw new IndexOutOfRangeException();
			}
			XebwmfEmwNeSEgAOBLiojFMFWElLb[index].GGlDtnHInFKgrSXqCdDTxSYpDqwqA = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= NjnOpHDtOZbCwpFxPfWiaqeqMEjlA)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return XebwmfEmwNeSEgAOBLiojFMFWElLb[index].jbHIConMbuKIoCGUWoBAcTfniXUr;
		}
	}
}
