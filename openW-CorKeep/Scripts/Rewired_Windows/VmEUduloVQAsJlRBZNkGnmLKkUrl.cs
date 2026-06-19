using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;

internal abstract class VmEUduloVQAsJlRBZNkGnmLKkUrl : tNSBtIwTqUeWpGtNoXsrdaEOoFDcA
{
	internal abstract class CxEGtVMeVpFRaBPfjZXhvTsiHkbd
	{
		private int LhWuwjmKVIRKIBXVITMdoyJagIug;

		private int[] cPLllZekSdkkItlrqBHVgAObgBiHA;

		protected qwGVNLfmgMjKfJEWYWjvPqxjawnKA[] uiidvpRndWcSRgsJKyqyuDmmCJXh;

		public qwGVNLfmgMjKfJEWYWjvPqxjawnKA urFWHNAbkPUOJwlLQSRrpQppsPNm;

		private int RNlEUiteQLxHMjfhfFceVCumcqmx;

		private int ghClomrCGzrdoIKvGDOXWMxzgtBT = -1;

		private bool chetdvOvrrTSvoRZuynnMNlyvWw;

		protected int vnzuTeJkcLQCQjsgBEDfAswsrhMR => LhWuwjmKVIRKIBXVITMdoyJagIug;

		protected int[] lTmrYrKmAsLUXBAJBUnOfOJPbsHQ => cPLllZekSdkkItlrqBHVgAObgBiHA;

		public UpdateLoopType xAEXqIqTtITRUpnhkhFIKJYlVzSo
		{
			set
			{
				if (ghClomrCGzrdoIKvGDOXWMxzgtBT != (int)updateLoopType)
				{
					ghClomrCGzrdoIKvGDOXWMxzgtBT = (int)updateLoopType;
					RNlEUiteQLxHMjfhfFceVCumcqmx = cPLllZekSdkkItlrqBHVgAObgBiHA[(int)updateLoopType];
					urFWHNAbkPUOJwlLQSRrpQppsPNm = uiidvpRndWcSRgsJKyqyuDmmCJXh[RNlEUiteQLxHMjfhfFceVCumcqmx];
				}
			}
		}

		public CxEGtVMeVpFRaBPfjZXhvTsiHkbd()
		{
		}

		public void lmwRKHZvmyJKbMZCFlrQtMXPVrOU(UpdateLoopSetting P_0, Func<UpdateLoopType, qwGVNLfmgMjKfJEWYWjvPqxjawnKA> P_1)
		{
			if (chetdvOvrrTSvoRZuynnMNlyvWw)
			{
				Logger.LogError("Already initialized!");
				return;
			}
			cPLllZekSdkkItlrqBHVgAObgBiHA = new int[3];
			LhWuwjmKVIRKIBXVITMdoyJagIug = 0;
			List<qwGVNLfmgMjKfJEWYWjvPqxjawnKA> list = new List<qwGVNLfmgMjKfJEWYWjvPqxjawnKA>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					cPLllZekSdkkItlrqBHVgAObgBiHA[(int)list2[i]] = LhWuwjmKVIRKIBXVITMdoyJagIug;
					LhWuwjmKVIRKIBXVITMdoyJagIug++;
					list.Add(P_1(list2[i]));
				}
			}
			uiidvpRndWcSRgsJKyqyuDmmCJXh = list.ToArray();
			urFWHNAbkPUOJwlLQSRrpQppsPNm = uiidvpRndWcSRgsJKyqyuDmmCJXh[0];
			chetdvOvrrTSvoRZuynnMNlyvWw = true;
		}

		private void yBnstZpmoKHvqHsYzCjCABCwsZqeb(UpdateLoopType P_0, qwGVNLfmgMjKfJEWYWjvPqxjawnKA P_1)
		{
			uiidvpRndWcSRgsJKyqyuDmmCJXh[cPLllZekSdkkItlrqBHVgAObgBiHA[(int)P_0]] = P_1;
		}

		public virtual void kwljHwCCynhUVUIySXQsStdhxKgm(UpdateLoopType P_0)
		{
			if (ghClomrCGzrdoIKvGDOXWMxzgtBT != (int)P_0)
			{
				xAEXqIqTtITRUpnhkhFIKJYlVzSo = P_0;
			}
		}

		public void KavVICxOsYPekqaPTFEthhcbWmqc()
		{
			for (int i = 0; i < LhWuwjmKVIRKIBXVITMdoyJagIug; i++)
			{
				uiidvpRndWcSRgsJKyqyuDmmCJXh[i].GhkKTJtnyfyiNbfNlGVRHIbFQKkcA();
			}
		}
	}

	internal abstract class qwGVNLfmgMjKfJEWYWjvPqxjawnKA
	{
		public readonly UpdateLoopType AMYpvVbByPapvSFCcyMoaDioovhg;

		public qwGVNLfmgMjKfJEWYWjvPqxjawnKA(UpdateLoopType P_0)
		{
			AMYpvVbByPapvSFCcyMoaDioovhg = P_0;
		}

		public abstract void GhkKTJtnyfyiNbfNlGVRHIbFQKkcA();
	}

	internal CxEGtVMeVpFRaBPfjZXhvTsiHkbd ETIRbqhvfdoZksbqIAoSALpMXnyRA;

	public VmEUduloVQAsJlRBZNkGnmLKkUrl(CxEGtVMeVpFRaBPfjZXhvTsiHkbd P_0, byte P_1, HIDInfo P_2)
		: base(P_1, P_2)
	{
		ETIRbqhvfdoZksbqIAoSALpMXnyRA = P_0;
	}

	public virtual void lNHoZFtFBSWWbbsWnqsHLgAtoHIN(UpdateLoopType P_0)
	{
		if (ETIRbqhvfdoZksbqIAoSALpMXnyRA != null)
		{
			ETIRbqhvfdoZksbqIAoSALpMXnyRA.kwljHwCCynhUVUIySXQsStdhxKgm(P_0);
		}
	}
}
