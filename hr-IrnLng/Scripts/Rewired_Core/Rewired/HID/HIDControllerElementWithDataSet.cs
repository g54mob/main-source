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
		internal abstract class tHlQeLJqCEWKUMOmVnJppXPuLSy
		{
			private int mkilpbOzLbvfOkGEyycpxcIzHRj;

			private int[] XerEfwYGynpiGSfHXXeWxTOBLoO;

			protected VGnAJRIkyhjNBoXBsmJfCojhFgas[] KKxvXzhbFzmenMQwioAojqUOeaj;

			public VGnAJRIkyhjNBoXBsmJfCojhFgas TrWUdtjebjTxiTudwuGvXSlDJgg;

			private int jZIrWyBTDMYPCOWflxuDUQgsNSP;

			private int xzsHlpfVkUipOIFvAGjOgLamtlLt = -1;

			private bool iTMWkJzAQHobYymwbflfUznXqqe;

			protected int dataCount => mkilpbOzLbvfOkGEyycpxcIzHRj;

			protected int[] updateLoopIndex => XerEfwYGynpiGSfHXXeWxTOBLoO;

			public UpdateLoopType updateLoop
			{
				set
				{
					if (xzsHlpfVkUipOIFvAGjOgLamtlLt != (int)value)
					{
						xzsHlpfVkUipOIFvAGjOgLamtlLt = (int)value;
						jZIrWyBTDMYPCOWflxuDUQgsNSP = XerEfwYGynpiGSfHXXeWxTOBLoO[(int)value];
						TrWUdtjebjTxiTudwuGvXSlDJgg = KKxvXzhbFzmenMQwioAojqUOeaj[jZIrWyBTDMYPCOWflxuDUQgsNSP];
					}
				}
			}

			public tHlQeLJqCEWKUMOmVnJppXPuLSy()
			{
			}

			public void arYCwNeHnjJnYWBURQvFgVcxTDp(UpdateLoopSetting P_0, Func<UpdateLoopType, VGnAJRIkyhjNBoXBsmJfCojhFgas> P_1)
			{
				if (iTMWkJzAQHobYymwbflfUznXqqe)
				{
					Logger.LogError("Already initialized!");
					return;
				}
				XerEfwYGynpiGSfHXXeWxTOBLoO = new int[3];
				mkilpbOzLbvfOkGEyycpxcIzHRj = 0;
				List<VGnAJRIkyhjNBoXBsmJfCojhFgas> list = new List<VGnAJRIkyhjNBoXBsmJfCojhFgas>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list2 = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0, list2);
					for (int i = 0; i < list2.Count; i++)
					{
						XerEfwYGynpiGSfHXXeWxTOBLoO[(int)list2[i]] = mkilpbOzLbvfOkGEyycpxcIzHRj;
						mkilpbOzLbvfOkGEyycpxcIzHRj++;
						list.Add(P_1(list2[i]));
					}
				}
				KKxvXzhbFzmenMQwioAojqUOeaj = list.ToArray();
				TrWUdtjebjTxiTudwuGvXSlDJgg = KKxvXzhbFzmenMQwioAojqUOeaj[0];
				iTMWkJzAQHobYymwbflfUznXqqe = true;
			}

			private void JSoAwuHeTKqsvApBlevpCJIIMnnk(UpdateLoopType P_0, VGnAJRIkyhjNBoXBsmJfCojhFgas P_1)
			{
				KKxvXzhbFzmenMQwioAojqUOeaj[XerEfwYGynpiGSfHXXeWxTOBLoO[(int)P_0]] = P_1;
			}

			public virtual void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
			{
				if (xzsHlpfVkUipOIFvAGjOgLamtlLt != (int)P_0)
				{
					updateLoop = P_0;
				}
			}

			public void agvWMBoHtblzmgSmVloJbsDkfGk()
			{
				for (int i = 0; i < mkilpbOzLbvfOkGEyycpxcIzHRj; i++)
				{
					KKxvXzhbFzmenMQwioAojqUOeaj[i].agvWMBoHtblzmgSmVloJbsDkfGk();
				}
			}
		}

		internal abstract class VGnAJRIkyhjNBoXBsmJfCojhFgas
		{
			public readonly UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

			public VGnAJRIkyhjNBoXBsmJfCojhFgas(UpdateLoopType updateLoop)
			{
				ENXLJBnoaLplSRNpPerVNetoNsG = updateLoop;
			}

			public abstract void agvWMBoHtblzmgSmVloJbsDkfGk();
		}

		internal tHlQeLJqCEWKUMOmVnJppXPuLSy dataSet;

		public HIDControllerElementWithDataSet(tHlQeLJqCEWKUMOmVnJppXPuLSy dataSet, byte reportId, HIDInfo hidInfo)
			: base(reportId, hidInfo)
		{
			this.dataSet = dataSet;
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet != null)
			{
				dataSet.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(updateLoop);
			}
		}
	}
}
