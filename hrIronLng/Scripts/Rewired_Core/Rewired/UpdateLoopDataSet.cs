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
		private class yABdzmHkOFyqPcFvtvRNPjLtizZl
		{
			public readonly UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

			public T afRqPnGQripoBdEmFTzWwSWESMg;

			public yABdzmHkOFyqPcFvtvRNPjLtizZl(UpdateLoopType updateLoop)
			{
				ENXLJBnoaLplSRNpPerVNetoNsG = updateLoop;
			}
		}

		private const int cgnEGIICjWaOulFGLOwcnqoSfZvI = 0;

		private yABdzmHkOFyqPcFvtvRNPjLtizZl ebqMllgvTXosawRQUJDKypELGsL;

		private int SDCgUCruwiFPrvEHpfWQvKptOso;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] XerEfwYGynpiGSfHXXeWxTOBLoO;

		private readonly yABdzmHkOFyqPcFvtvRNPjLtizZl[] SJOgMWGirqgoByjouUivofMkIEMB;

		private UpdateLoopType WDNhHRJrgnXmJsDxQnXLKohbrFSw = (UpdateLoopType)(-1);

		public T Current => ebqMllgvTXosawRQUJDKypELGsL.afRqPnGQripoBdEmFTzWwSWESMg;

		public int Count => SDCgUCruwiFPrvEHpfWQvKptOso;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= SDCgUCruwiFPrvEHpfWQvKptOso)
				{
					throw new IndexOutOfRangeException();
				}
				return SJOgMWGirqgoByjouUivofMkIEMB[index].afRqPnGQripoBdEmFTzWwSWESMg;
			}
			set
			{
				if (index < 0 || index >= SDCgUCruwiFPrvEHpfWQvKptOso)
				{
					throw new IndexOutOfRangeException();
				}
				SJOgMWGirqgoByjouUivofMkIEMB[index].afRqPnGQripoBdEmFTzWwSWESMg = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops)
			: this(updateLoops, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops, Func<T> instantiatorDelegate)
		{
			XerEfwYGynpiGSfHXXeWxTOBLoO = new int[3];
			ArrayTools.Fill(XerEfwYGynpiGSfHXXeWxTOBLoO, -1);
			List<yABdzmHkOFyqPcFvtvRNPjLtizZl> list = new List<yABdzmHkOFyqPcFvtvRNPjLtizZl>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoops, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					yABdzmHkOFyqPcFvtvRNPjLtizZl yABdzmHkOFyqPcFvtvRNPjLtizZl2 = new yABdzmHkOFyqPcFvtvRNPjLtizZl(list2[i]);
					if (instantiatorDelegate != null)
					{
						T afRqPnGQripoBdEmFTzWwSWESMg = instantiatorDelegate();
						yABdzmHkOFyqPcFvtvRNPjLtizZl2.afRqPnGQripoBdEmFTzWwSWESMg = afRqPnGQripoBdEmFTzWwSWESMg;
					}
					list.Add(yABdzmHkOFyqPcFvtvRNPjLtizZl2);
					XerEfwYGynpiGSfHXXeWxTOBLoO[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			SJOgMWGirqgoByjouUivofMkIEMB = list.ToArray();
			SDCgUCruwiFPrvEHpfWQvKptOso = SJOgMWGirqgoByjouUivofMkIEMB.Length;
			SetUpdateLoop(SJOgMWGirqgoByjouUivofMkIEMB[0].ENXLJBnoaLplSRNpPerVNetoNsG);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (WDNhHRJrgnXmJsDxQnXLKohbrFSw != updateLoop)
			{
				WDNhHRJrgnXmJsDxQnXLKohbrFSw = updateLoop;
				ebqMllgvTXosawRQUJDKypELGsL = SJOgMWGirqgoByjouUivofMkIEMB[XerEfwYGynpiGSfHXXeWxTOBLoO[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= SDCgUCruwiFPrvEHpfWQvKptOso)
			{
				throw new IndexOutOfRangeException();
			}
			return SJOgMWGirqgoByjouUivofMkIEMB[index].afRqPnGQripoBdEmFTzWwSWESMg;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return SJOgMWGirqgoByjouUivofMkIEMB[XerEfwYGynpiGSfHXXeWxTOBLoO[(int)updateLoop]].afRqPnGQripoBdEmFTzWwSWESMg;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= SDCgUCruwiFPrvEHpfWQvKptOso)
			{
				throw new IndexOutOfRangeException();
			}
			SJOgMWGirqgoByjouUivofMkIEMB[index].afRqPnGQripoBdEmFTzWwSWESMg = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= SDCgUCruwiFPrvEHpfWQvKptOso)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return SJOgMWGirqgoByjouUivofMkIEMB[index].ENXLJBnoaLplSRNpPerVNetoNsG;
		}
	}
}
