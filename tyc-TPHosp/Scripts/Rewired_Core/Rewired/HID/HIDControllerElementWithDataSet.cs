using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class HIDControllerElementWithDataSet : HIDControllerElement
	{
		internal abstract class VyZzBpiHJLkhAHpaGkbcnAcCPHA
		{
			private int OQKWIRnZOwKHQfiXziZkpzWHVAZ;

			private int[] hvFUSUtOJacBUHSvEPiJftflbey;

			protected luZKkhRZZopiVCbznmPqyHYFeyA[] cXZAhDQESebRdBDchpsjrHPyUmL;

			public luZKkhRZZopiVCbznmPqyHYFeyA bAihUPOaQoqOwOHZvtGkVuGzqqW;

			private int FMfGoswTmMzBNBPokzjvUBjQbHe;

			private int RFSYGBGRLVeGSLPVJdbBAFXGYxhL = -1;

			private bool SqipAxIcjKKBSnKUcHhsIAAfbiWH;

			protected int dataCount => OQKWIRnZOwKHQfiXziZkpzWHVAZ;

			protected int[] updateLoopIndex => hvFUSUtOJacBUHSvEPiJftflbey;

			public UpdateLoopType updateLoop
			{
				set
				{
					if (RFSYGBGRLVeGSLPVJdbBAFXGYxhL != (int)value)
					{
						RFSYGBGRLVeGSLPVJdbBAFXGYxhL = (int)value;
						FMfGoswTmMzBNBPokzjvUBjQbHe = hvFUSUtOJacBUHSvEPiJftflbey[(int)value];
						bAihUPOaQoqOwOHZvtGkVuGzqqW = cXZAhDQESebRdBDchpsjrHPyUmL[FMfGoswTmMzBNBPokzjvUBjQbHe];
					}
				}
			}

			public VyZzBpiHJLkhAHpaGkbcnAcCPHA()
			{
			}

			public void EmrltXEvsiAKZaBKIKCsFzXVHJ(UpdateLoopSetting P_0, Func<UpdateLoopType, luZKkhRZZopiVCbznmPqyHYFeyA> P_1)
			{
				if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
				{
					Logger.LogError("Already initialized!");
					return;
				}
				hvFUSUtOJacBUHSvEPiJftflbey = new int[3];
				OQKWIRnZOwKHQfiXziZkpzWHVAZ = 0;
				List<luZKkhRZZopiVCbznmPqyHYFeyA> list = new List<luZKkhRZZopiVCbznmPqyHYFeyA>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list2 = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0, list2);
					for (int i = 0; i < list2.Count; i++)
					{
						hvFUSUtOJacBUHSvEPiJftflbey[(int)list2[i]] = OQKWIRnZOwKHQfiXziZkpzWHVAZ;
						OQKWIRnZOwKHQfiXziZkpzWHVAZ++;
						list.Add(P_1(list2[i]));
					}
				}
				cXZAhDQESebRdBDchpsjrHPyUmL = list.ToArray();
				SqipAxIcjKKBSnKUcHhsIAAfbiWH = true;
			}

			private void hmIlRSJmuDqDroUtsGnoRqfyDfF(UpdateLoopType P_0, luZKkhRZZopiVCbznmPqyHYFeyA P_1)
			{
				cXZAhDQESebRdBDchpsjrHPyUmL[hvFUSUtOJacBUHSvEPiJftflbey[(int)P_0]] = P_1;
			}

			public virtual void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
			{
				if (RFSYGBGRLVeGSLPVJdbBAFXGYxhL != (int)P_0)
				{
					updateLoop = P_0;
				}
			}

			public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
			{
				for (int i = 0; i < OQKWIRnZOwKHQfiXziZkpzWHVAZ; i++)
				{
					cXZAhDQESebRdBDchpsjrHPyUmL[i].QjNHfjHnCmaQyvCGKbwODraSxUWC();
				}
			}
		}

		internal abstract class luZKkhRZZopiVCbznmPqyHYFeyA
		{
			public readonly UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

			public luZKkhRZZopiVCbznmPqyHYFeyA(UpdateLoopType updateLoop)
			{
				iTlZorELHQDCESPLUCqUXMAKNVy = updateLoop;
			}

			public abstract void QjNHfjHnCmaQyvCGKbwODraSxUWC();
		}

		internal VyZzBpiHJLkhAHpaGkbcnAcCPHA dataSet;

		public HIDControllerElementWithDataSet(VyZzBpiHJLkhAHpaGkbcnAcCPHA dataSet, byte reportId, HIDInfo hidInfo)
			: base(reportId, hidInfo)
		{
			this.dataSet = dataSet;
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet != null)
			{
				dataSet.QTPiZFmnRsxmyQYmMuIoBQkOtfg(updateLoop);
			}
		}
	}
}
