using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDControllerElementWithDataSet : HIDControllerElement
	{
		internal abstract class FwfVunHdepBCPjnxolyzjMjQIqwcb
		{
			private int GFbZYVlHSCHYvzIhBrqpLNIUWVdt;

			private int[] xteFFlzAQpidnZrDpNkFVPsTbqtEA;

			protected vXlvtpgwbYXdIiFwJYmfVQDFFroL[] bPXpBLGvvGQnkOZdZAVqLPMAldAu;

			public vXlvtpgwbYXdIiFwJYmfVQDFFroL hduUspHviDUBuOOrZDjpiODZaJYRA;

			private int MaCAaWFqiDfshmFVmnmeceWfGHdeB;

			private int vnxODGidKjiuJmdHVQxVluBJDCGV = -1;

			private bool bhLgTNfXfjiUrpOfMJDldQfHBQTSA;

			protected int mPSlhYIiwBJyrJSuWihitMxAWHUB => GFbZYVlHSCHYvzIhBrqpLNIUWVdt;

			protected int[] wjVqyZRbYkHJoxEbWOXCQvndPHCm => xteFFlzAQpidnZrDpNkFVPsTbqtEA;

			public UpdateLoopType uBlOEezirCUOhZeDngwUnFcLtYJm
			{
				set
				{
					if (vnxODGidKjiuJmdHVQxVluBJDCGV != (int)updateLoopType)
					{
						vnxODGidKjiuJmdHVQxVluBJDCGV = (int)updateLoopType;
						MaCAaWFqiDfshmFVmnmeceWfGHdeB = xteFFlzAQpidnZrDpNkFVPsTbqtEA[(int)updateLoopType];
						hduUspHviDUBuOOrZDjpiODZaJYRA = bPXpBLGvvGQnkOZdZAVqLPMAldAu[MaCAaWFqiDfshmFVmnmeceWfGHdeB];
					}
				}
			}

			public FwfVunHdepBCPjnxolyzjMjQIqwcb()
			{
			}

			public void sBTgxlWjumZDCwCaMMxUSfdrGQZW(UpdateLoopSetting P_0, Func<UpdateLoopType, vXlvtpgwbYXdIiFwJYmfVQDFFroL> P_1)
			{
				if (bhLgTNfXfjiUrpOfMJDldQfHBQTSA)
				{
					Logger.LogError("Already initialized!");
					return;
				}
				xteFFlzAQpidnZrDpNkFVPsTbqtEA = new int[3];
				GFbZYVlHSCHYvzIhBrqpLNIUWVdt = 0;
				List<vXlvtpgwbYXdIiFwJYmfVQDFFroL> list = new List<vXlvtpgwbYXdIiFwJYmfVQDFFroL>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list2 = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0, list2);
					for (int i = 0; i < list2.Count; i++)
					{
						xteFFlzAQpidnZrDpNkFVPsTbqtEA[(int)list2[i]] = GFbZYVlHSCHYvzIhBrqpLNIUWVdt;
						GFbZYVlHSCHYvzIhBrqpLNIUWVdt++;
						list.Add(P_1(list2[i]));
					}
				}
				bPXpBLGvvGQnkOZdZAVqLPMAldAu = list.ToArray();
				hduUspHviDUBuOOrZDjpiODZaJYRA = bPXpBLGvvGQnkOZdZAVqLPMAldAu[0];
				bhLgTNfXfjiUrpOfMJDldQfHBQTSA = true;
			}

			private void zhAHjxersOsSDbxiiSvEyuqAocpj(UpdateLoopType P_0, vXlvtpgwbYXdIiFwJYmfVQDFFroL P_1)
			{
				bPXpBLGvvGQnkOZdZAVqLPMAldAu[xteFFlzAQpidnZrDpNkFVPsTbqtEA[(int)P_0]] = P_1;
			}

			public virtual void tHWUBQPxgtVgesSIHRaudMBBdKzfA(UpdateLoopType P_0)
			{
				if (vnxODGidKjiuJmdHVQxVluBJDCGV != (int)P_0)
				{
					uBlOEezirCUOhZeDngwUnFcLtYJm = P_0;
				}
			}

			public void LXWdxkAmKYSKJBIKIRsWJILPRznUA()
			{
				for (int i = 0; i < GFbZYVlHSCHYvzIhBrqpLNIUWVdt; i++)
				{
					bPXpBLGvvGQnkOZdZAVqLPMAldAu[i].LLNfRfqcelDriFSbeWoHtPBxWxdP();
				}
			}
		}

		internal abstract class vXlvtpgwbYXdIiFwJYmfVQDFFroL
		{
			public readonly UpdateLoopType PWjsRxkZcHAnQeZebVtiJzKMFjkK;

			public vXlvtpgwbYXdIiFwJYmfVQDFFroL(UpdateLoopType P_0)
			{
				PWjsRxkZcHAnQeZebVtiJzKMFjkK = P_0;
			}

			public abstract void LLNfRfqcelDriFSbeWoHtPBxWxdP();
		}

		internal FwfVunHdepBCPjnxolyzjMjQIqwcb dataSet;

		public HIDControllerElementWithDataSet(FwfVunHdepBCPjnxolyzjMjQIqwcb P_0, byte P_1, HIDInfo P_2)
			: base(P_1, P_2)
		{
			dataSet = P_0;
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet != null)
			{
				dataSet.tHWUBQPxgtVgesSIHRaudMBBdKzfA(updateLoop);
			}
		}
	}
}
