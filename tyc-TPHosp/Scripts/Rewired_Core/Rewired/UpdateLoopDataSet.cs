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
		private class MOtNOOTHzIjLLCcZmnFEfHmDalxg
		{
			public readonly UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

			public T KBzfyXGfCzjBFAaMHStTNgtCuSIR;

			public MOtNOOTHzIjLLCcZmnFEfHmDalxg(UpdateLoopType updateLoop)
			{
				iTlZorELHQDCESPLUCqUXMAKNVy = updateLoop;
			}
		}

		private const int AZTonopAOVAzkAQyOdivPcDqRNVq = 0;

		private MOtNOOTHzIjLLCcZmnFEfHmDalxg ONUYKXZlkIBZynTkLCJLGehveafN;

		private int mkqVdeEMZbmmfgIzkIQXzOUNaiC;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] hvFUSUtOJacBUHSvEPiJftflbey;

		private readonly MOtNOOTHzIjLLCcZmnFEfHmDalxg[] kGuVfeffObwXFfTMvrqgyDrQrQy;

		private UpdateLoopType kNbrmpAVPmPZZEGPDuNIawAXTVy = (UpdateLoopType)(-1);

		public T Current => ONUYKXZlkIBZynTkLCJLGehveafN.KBzfyXGfCzjBFAaMHStTNgtCuSIR;

		public int Count => mkqVdeEMZbmmfgIzkIQXzOUNaiC;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= mkqVdeEMZbmmfgIzkIQXzOUNaiC)
				{
					throw new IndexOutOfRangeException();
				}
				return kGuVfeffObwXFfTMvrqgyDrQrQy[index].KBzfyXGfCzjBFAaMHStTNgtCuSIR;
			}
			set
			{
				if (index < 0 || index >= mkqVdeEMZbmmfgIzkIQXzOUNaiC)
				{
					throw new IndexOutOfRangeException();
				}
				kGuVfeffObwXFfTMvrqgyDrQrQy[index].KBzfyXGfCzjBFAaMHStTNgtCuSIR = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops)
			: this(updateLoops, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops, Func<T> instantiatorDelegate)
		{
			hvFUSUtOJacBUHSvEPiJftflbey = new int[3];
			ArrayTools.Fill(hvFUSUtOJacBUHSvEPiJftflbey, -1);
			List<MOtNOOTHzIjLLCcZmnFEfHmDalxg> list = new List<MOtNOOTHzIjLLCcZmnFEfHmDalxg>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoops, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					MOtNOOTHzIjLLCcZmnFEfHmDalxg mOtNOOTHzIjLLCcZmnFEfHmDalxg = new MOtNOOTHzIjLLCcZmnFEfHmDalxg(list2[i]);
					if (instantiatorDelegate != null)
					{
						T kBzfyXGfCzjBFAaMHStTNgtCuSIR = instantiatorDelegate();
						mOtNOOTHzIjLLCcZmnFEfHmDalxg.KBzfyXGfCzjBFAaMHStTNgtCuSIR = kBzfyXGfCzjBFAaMHStTNgtCuSIR;
					}
					list.Add(mOtNOOTHzIjLLCcZmnFEfHmDalxg);
					hvFUSUtOJacBUHSvEPiJftflbey[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			kGuVfeffObwXFfTMvrqgyDrQrQy = list.ToArray();
			mkqVdeEMZbmmfgIzkIQXzOUNaiC = kGuVfeffObwXFfTMvrqgyDrQrQy.Length;
			SetUpdateLoop(kGuVfeffObwXFfTMvrqgyDrQrQy[0].iTlZorELHQDCESPLUCqUXMAKNVy);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (kNbrmpAVPmPZZEGPDuNIawAXTVy != updateLoop)
			{
				kNbrmpAVPmPZZEGPDuNIawAXTVy = updateLoop;
				ONUYKXZlkIBZynTkLCJLGehveafN = kGuVfeffObwXFfTMvrqgyDrQrQy[hvFUSUtOJacBUHSvEPiJftflbey[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= mkqVdeEMZbmmfgIzkIQXzOUNaiC)
			{
				throw new IndexOutOfRangeException();
			}
			return kGuVfeffObwXFfTMvrqgyDrQrQy[index].KBzfyXGfCzjBFAaMHStTNgtCuSIR;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return kGuVfeffObwXFfTMvrqgyDrQrQy[hvFUSUtOJacBUHSvEPiJftflbey[(int)updateLoop]].KBzfyXGfCzjBFAaMHStTNgtCuSIR;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= mkqVdeEMZbmmfgIzkIQXzOUNaiC)
			{
				throw new IndexOutOfRangeException();
			}
			kGuVfeffObwXFfTMvrqgyDrQrQy[index].KBzfyXGfCzjBFAaMHStTNgtCuSIR = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= mkqVdeEMZbmmfgIzkIQXzOUNaiC)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return kGuVfeffObwXFfTMvrqgyDrQrQy[index].iTlZorELHQDCESPLUCqUXMAKNVy;
		}
	}
}
