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
		private class QALVTeoPOHMdqSIQFbSeVEaSacSHA
		{
			public readonly UpdateLoopType nXWVIOaHopsWRedTroCkZTAlZFhI;

			public T EEeweDFMmKAwWdoltcNjtBbzDgZN;

			public QALVTeoPOHMdqSIQFbSeVEaSacSHA(UpdateLoopType P_0)
			{
				nXWVIOaHopsWRedTroCkZTAlZFhI = P_0;
			}
		}

		private const int hfyvILCiKRXhrfMdaFBOLRjlJFBl = 0;

		private QALVTeoPOHMdqSIQFbSeVEaSacSHA HXpeqDMudTBEMqiNJNHnNMnyqFz;

		private int DehqfqETEtuJGHekUfSKXPmtQSEA;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] UOqcSuFpUwuDlNHoVsFativTELEJA;

		private readonly QALVTeoPOHMdqSIQFbSeVEaSacSHA[] FdidMRHZtYkjlyBFeLwMuHdEGJYi;

		private UpdateLoopType hMbveTEfBjuNeySAiCdSbyYSPZuH = (UpdateLoopType)(-1);

		public T Current => HXpeqDMudTBEMqiNJNHnNMnyqFz.EEeweDFMmKAwWdoltcNjtBbzDgZN;

		public int Count => DehqfqETEtuJGHekUfSKXPmtQSEA;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= DehqfqETEtuJGHekUfSKXPmtQSEA)
				{
					throw new IndexOutOfRangeException();
				}
				return FdidMRHZtYkjlyBFeLwMuHdEGJYi[index].EEeweDFMmKAwWdoltcNjtBbzDgZN;
			}
			set
			{
				if (index < 0 || index >= DehqfqETEtuJGHekUfSKXPmtQSEA)
				{
					throw new IndexOutOfRangeException();
				}
				FdidMRHZtYkjlyBFeLwMuHdEGJYi[index].EEeweDFMmKAwWdoltcNjtBbzDgZN = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			UOqcSuFpUwuDlNHoVsFativTELEJA = new int[3];
			ArrayTools.Fill(UOqcSuFpUwuDlNHoVsFativTELEJA, -1);
			List<QALVTeoPOHMdqSIQFbSeVEaSacSHA> list = new List<QALVTeoPOHMdqSIQFbSeVEaSacSHA>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					QALVTeoPOHMdqSIQFbSeVEaSacSHA qALVTeoPOHMdqSIQFbSeVEaSacSHA = new QALVTeoPOHMdqSIQFbSeVEaSacSHA(list2[i]);
					if (P_1 != null)
					{
						T eEeweDFMmKAwWdoltcNjtBbzDgZN = P_1();
						qALVTeoPOHMdqSIQFbSeVEaSacSHA.EEeweDFMmKAwWdoltcNjtBbzDgZN = eEeweDFMmKAwWdoltcNjtBbzDgZN;
					}
					list.Add(qALVTeoPOHMdqSIQFbSeVEaSacSHA);
					UOqcSuFpUwuDlNHoVsFativTELEJA[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			FdidMRHZtYkjlyBFeLwMuHdEGJYi = list.ToArray();
			DehqfqETEtuJGHekUfSKXPmtQSEA = FdidMRHZtYkjlyBFeLwMuHdEGJYi.Length;
			SetUpdateLoop(FdidMRHZtYkjlyBFeLwMuHdEGJYi[0].nXWVIOaHopsWRedTroCkZTAlZFhI);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (hMbveTEfBjuNeySAiCdSbyYSPZuH != updateLoop)
			{
				hMbveTEfBjuNeySAiCdSbyYSPZuH = updateLoop;
				HXpeqDMudTBEMqiNJNHnNMnyqFz = FdidMRHZtYkjlyBFeLwMuHdEGJYi[UOqcSuFpUwuDlNHoVsFativTELEJA[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= DehqfqETEtuJGHekUfSKXPmtQSEA)
			{
				throw new IndexOutOfRangeException();
			}
			return FdidMRHZtYkjlyBFeLwMuHdEGJYi[index].EEeweDFMmKAwWdoltcNjtBbzDgZN;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return FdidMRHZtYkjlyBFeLwMuHdEGJYi[UOqcSuFpUwuDlNHoVsFativTELEJA[(int)updateLoop]].EEeweDFMmKAwWdoltcNjtBbzDgZN;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= DehqfqETEtuJGHekUfSKXPmtQSEA)
			{
				throw new IndexOutOfRangeException();
			}
			FdidMRHZtYkjlyBFeLwMuHdEGJYi[index].EEeweDFMmKAwWdoltcNjtBbzDgZN = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= DehqfqETEtuJGHekUfSKXPmtQSEA)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return FdidMRHZtYkjlyBFeLwMuHdEGJYi[index].nXWVIOaHopsWRedTroCkZTAlZFhI;
		}
	}
}
