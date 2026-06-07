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
		internal abstract class xmZuwrAGVqILrhjYoPclRrBmGJaQ
		{
			private int coGfDXEBIDrurtHUBYvfiHEznXrwA;

			private int[] RsTJDGRaBRixhxMPkHrGBMADHsES;

			protected VrVvhtnBXDKMgsvVTUrvWTjnyaqi[] OhZfPLeiCZorKUdCTHxwoDcQlqvkA;

			public VrVvhtnBXDKMgsvVTUrvWTjnyaqi FzeFBTyCrPwRSotVRRvPtdRXkqzA;

			private int hXbwTkGIglELkIvAOJmgZwYkqPGIA;

			private int rxSDcDkNBigQzfrdvekKpcuczXDh = -1;

			private bool qumTafanxrjKbDduWdypwIzXqmiP;

			protected int yfViQNEGbvoVyRxINlWZIgKQXsZV => coGfDXEBIDrurtHUBYvfiHEznXrwA;

			protected int[] sxdBpaYjPuliXdEyQIUVniaagjdw => RsTJDGRaBRixhxMPkHrGBMADHsES;

			public UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB
			{
				set
				{
					if (rxSDcDkNBigQzfrdvekKpcuczXDh != (int)updateLoopType)
					{
						rxSDcDkNBigQzfrdvekKpcuczXDh = (int)updateLoopType;
						hXbwTkGIglELkIvAOJmgZwYkqPGIA = RsTJDGRaBRixhxMPkHrGBMADHsES[(int)updateLoopType];
						FzeFBTyCrPwRSotVRRvPtdRXkqzA = OhZfPLeiCZorKUdCTHxwoDcQlqvkA[hXbwTkGIglELkIvAOJmgZwYkqPGIA];
					}
				}
			}

			public xmZuwrAGVqILrhjYoPclRrBmGJaQ()
			{
			}

			public void yWuIeddROHFQtkpYivZHHCufAJtzA(UpdateLoopSetting P_0, Func<UpdateLoopType, VrVvhtnBXDKMgsvVTUrvWTjnyaqi> P_1)
			{
				if (qumTafanxrjKbDduWdypwIzXqmiP)
				{
					Logger.LogError("Already initialized!");
					return;
				}
				RsTJDGRaBRixhxMPkHrGBMADHsES = new int[3];
				coGfDXEBIDrurtHUBYvfiHEznXrwA = 0;
				List<VrVvhtnBXDKMgsvVTUrvWTjnyaqi> list = new List<VrVvhtnBXDKMgsvVTUrvWTjnyaqi>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list2 = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0, list2);
					for (int i = 0; i < list2.Count; i++)
					{
						RsTJDGRaBRixhxMPkHrGBMADHsES[(int)list2[i]] = coGfDXEBIDrurtHUBYvfiHEznXrwA;
						coGfDXEBIDrurtHUBYvfiHEznXrwA++;
						list.Add(P_1(list2[i]));
					}
				}
				OhZfPLeiCZorKUdCTHxwoDcQlqvkA = list.ToArray();
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = OhZfPLeiCZorKUdCTHxwoDcQlqvkA[0];
				qumTafanxrjKbDduWdypwIzXqmiP = true;
			}

			private void TWAOJIzfeanOCEpVUqTdrEsEvCtG(UpdateLoopType P_0, VrVvhtnBXDKMgsvVTUrvWTjnyaqi P_1)
			{
				OhZfPLeiCZorKUdCTHxwoDcQlqvkA[RsTJDGRaBRixhxMPkHrGBMADHsES[(int)P_0]] = P_1;
			}

			public virtual void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
			{
				if (rxSDcDkNBigQzfrdvekKpcuczXDh != (int)P_0)
				{
					KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_0;
				}
			}

			public void ooNidbhWzBcZZJydutNALDEuSswc()
			{
				for (int i = 0; i < coGfDXEBIDrurtHUBYvfiHEznXrwA; i++)
				{
					OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i].ooNidbhWzBcZZJydutNALDEuSswc();
				}
			}
		}

		internal abstract class VrVvhtnBXDKMgsvVTUrvWTjnyaqi
		{
			public readonly UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

			public VrVvhtnBXDKMgsvVTUrvWTjnyaqi(UpdateLoopType P_0)
			{
				KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_0;
			}

			public abstract void ooNidbhWzBcZZJydutNALDEuSswc();
		}

		internal xmZuwrAGVqILrhjYoPclRrBmGJaQ dataSet;

		public HIDControllerElementWithDataSet(xmZuwrAGVqILrhjYoPclRrBmGJaQ P_0, byte P_1, HIDInfo P_2)
			: base(P_1, P_2)
		{
			dataSet = P_0;
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet != null)
			{
				dataSet.sOLNzBCCbZmFXkMugfndpShqgrUP(updateLoop);
			}
		}
	}
}
