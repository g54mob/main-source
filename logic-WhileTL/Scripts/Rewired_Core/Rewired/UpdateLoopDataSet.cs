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
		private class qxxBXOzvlxnGyeHvQSpJDTPbpaHL
		{
			public readonly UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

			public T yMxlTPVDIQhbwEFgwysEQZOQcWuo;

			public qxxBXOzvlxnGyeHvQSpJDTPbpaHL(UpdateLoopType P_0)
			{
				KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_0;
			}
		}

		private const int yjTgakZdOaHTTarKcdaoWrsUTWfG = 0;

		private qxxBXOzvlxnGyeHvQSpJDTPbpaHL spQZBZhOifdYHVLQtOnCUJOTaSJg;

		private int USiqMcuTBQSoQSZBWJUYFnznqukH;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] RsTJDGRaBRixhxMPkHrGBMADHsES;

		private readonly qxxBXOzvlxnGyeHvQSpJDTPbpaHL[] GesyYeBpGYjhiPhqJvunCCEmAIOj;

		private UpdateLoopType ELbpqvmNTTbNqytzfOJDQhXxNJQC = (UpdateLoopType)(-1);

		public T Current => spQZBZhOifdYHVLQtOnCUJOTaSJg.yMxlTPVDIQhbwEFgwysEQZOQcWuo;

		public int Count => USiqMcuTBQSoQSZBWJUYFnznqukH;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= USiqMcuTBQSoQSZBWJUYFnznqukH)
				{
					throw new IndexOutOfRangeException();
				}
				return GesyYeBpGYjhiPhqJvunCCEmAIOj[index].yMxlTPVDIQhbwEFgwysEQZOQcWuo;
			}
			set
			{
				if (index < 0 || index >= USiqMcuTBQSoQSZBWJUYFnznqukH)
				{
					throw new IndexOutOfRangeException();
				}
				GesyYeBpGYjhiPhqJvunCCEmAIOj[index].yMxlTPVDIQhbwEFgwysEQZOQcWuo = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			RsTJDGRaBRixhxMPkHrGBMADHsES = new int[3];
			ArrayTools.Fill(RsTJDGRaBRixhxMPkHrGBMADHsES, -1);
			List<qxxBXOzvlxnGyeHvQSpJDTPbpaHL> list = new List<qxxBXOzvlxnGyeHvQSpJDTPbpaHL>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					qxxBXOzvlxnGyeHvQSpJDTPbpaHL qxxBXOzvlxnGyeHvQSpJDTPbpaHL2 = new qxxBXOzvlxnGyeHvQSpJDTPbpaHL(list2[i]);
					if (P_1 != null)
					{
						T yMxlTPVDIQhbwEFgwysEQZOQcWuo = P_1();
						qxxBXOzvlxnGyeHvQSpJDTPbpaHL2.yMxlTPVDIQhbwEFgwysEQZOQcWuo = yMxlTPVDIQhbwEFgwysEQZOQcWuo;
					}
					list.Add(qxxBXOzvlxnGyeHvQSpJDTPbpaHL2);
					RsTJDGRaBRixhxMPkHrGBMADHsES[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			GesyYeBpGYjhiPhqJvunCCEmAIOj = list.ToArray();
			USiqMcuTBQSoQSZBWJUYFnznqukH = GesyYeBpGYjhiPhqJvunCCEmAIOj.Length;
			SetUpdateLoop(GesyYeBpGYjhiPhqJvunCCEmAIOj[0].KKlbldiDPbDuxfifcGjVGpjaqJEqB);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (ELbpqvmNTTbNqytzfOJDQhXxNJQC != updateLoop)
			{
				ELbpqvmNTTbNqytzfOJDQhXxNJQC = updateLoop;
				spQZBZhOifdYHVLQtOnCUJOTaSJg = GesyYeBpGYjhiPhqJvunCCEmAIOj[RsTJDGRaBRixhxMPkHrGBMADHsES[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= USiqMcuTBQSoQSZBWJUYFnznqukH)
			{
				throw new IndexOutOfRangeException();
			}
			return GesyYeBpGYjhiPhqJvunCCEmAIOj[index].yMxlTPVDIQhbwEFgwysEQZOQcWuo;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return GesyYeBpGYjhiPhqJvunCCEmAIOj[RsTJDGRaBRixhxMPkHrGBMADHsES[(int)updateLoop]].yMxlTPVDIQhbwEFgwysEQZOQcWuo;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= USiqMcuTBQSoQSZBWJUYFnznqukH)
			{
				throw new IndexOutOfRangeException();
			}
			GesyYeBpGYjhiPhqJvunCCEmAIOj[index].yMxlTPVDIQhbwEFgwysEQZOQcWuo = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= USiqMcuTBQSoQSZBWJUYFnznqukH)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return GesyYeBpGYjhiPhqJvunCCEmAIOj[index].KKlbldiDPbDuxfifcGjVGpjaqJEqB;
		}
	}
}
