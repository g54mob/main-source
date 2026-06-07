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
		private class zbfXeEyGPPUmrxPXlKqDDsTiuaBM
		{
			public readonly UpdateLoopType MmewooifFhteKJeABYnJXhjTHYki;

			public T jsEZFjLXzCLbHSuiDMyOzpSPaNAl;

			public zbfXeEyGPPUmrxPXlKqDDsTiuaBM(UpdateLoopType P_0)
			{
				MmewooifFhteKJeABYnJXhjTHYki = P_0;
			}
		}

		private const int SEIMAnMeNDODmSvwOfYvXFAZXKCj = 0;

		private zbfXeEyGPPUmrxPXlKqDDsTiuaBM gznNaUIxlfSJWHtylreAVjpJaOpB;

		private int urYJGTKAOKlBYytmQBppNyEYOaRF;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] zeCpOSVCXkWKkuXzvzQRxmSpVbXI;

		private readonly zbfXeEyGPPUmrxPXlKqDDsTiuaBM[] iPIdOnJGoQwneNCGSMbzaPOqwYVN;

		private UpdateLoopType OcVEkbEGOddWvXpTAohxnyriHxfh = (UpdateLoopType)(-1);

		public T Current => gznNaUIxlfSJWHtylreAVjpJaOpB.jsEZFjLXzCLbHSuiDMyOzpSPaNAl;

		public int Count => urYJGTKAOKlBYytmQBppNyEYOaRF;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= urYJGTKAOKlBYytmQBppNyEYOaRF)
				{
					throw new IndexOutOfRangeException();
				}
				return iPIdOnJGoQwneNCGSMbzaPOqwYVN[index].jsEZFjLXzCLbHSuiDMyOzpSPaNAl;
			}
			set
			{
				if (index < 0 || index >= urYJGTKAOKlBYytmQBppNyEYOaRF)
				{
					throw new IndexOutOfRangeException();
				}
				iPIdOnJGoQwneNCGSMbzaPOqwYVN[index].jsEZFjLXzCLbHSuiDMyOzpSPaNAl = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			zeCpOSVCXkWKkuXzvzQRxmSpVbXI = new int[3];
			ArrayTools.Fill(zeCpOSVCXkWKkuXzvzQRxmSpVbXI, -1);
			List<zbfXeEyGPPUmrxPXlKqDDsTiuaBM> list = new List<zbfXeEyGPPUmrxPXlKqDDsTiuaBM>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					zbfXeEyGPPUmrxPXlKqDDsTiuaBM zbfXeEyGPPUmrxPXlKqDDsTiuaBM2 = new zbfXeEyGPPUmrxPXlKqDDsTiuaBM(list2[i]);
					if (P_1 != null)
					{
						T jsEZFjLXzCLbHSuiDMyOzpSPaNAl = P_1();
						zbfXeEyGPPUmrxPXlKqDDsTiuaBM2.jsEZFjLXzCLbHSuiDMyOzpSPaNAl = jsEZFjLXzCLbHSuiDMyOzpSPaNAl;
					}
					list.Add(zbfXeEyGPPUmrxPXlKqDDsTiuaBM2);
					zeCpOSVCXkWKkuXzvzQRxmSpVbXI[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			iPIdOnJGoQwneNCGSMbzaPOqwYVN = list.ToArray();
			urYJGTKAOKlBYytmQBppNyEYOaRF = iPIdOnJGoQwneNCGSMbzaPOqwYVN.Length;
			SetUpdateLoop(iPIdOnJGoQwneNCGSMbzaPOqwYVN[0].MmewooifFhteKJeABYnJXhjTHYki);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (OcVEkbEGOddWvXpTAohxnyriHxfh != updateLoop)
			{
				OcVEkbEGOddWvXpTAohxnyriHxfh = updateLoop;
				gznNaUIxlfSJWHtylreAVjpJaOpB = iPIdOnJGoQwneNCGSMbzaPOqwYVN[zeCpOSVCXkWKkuXzvzQRxmSpVbXI[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= urYJGTKAOKlBYytmQBppNyEYOaRF)
			{
				throw new IndexOutOfRangeException();
			}
			return iPIdOnJGoQwneNCGSMbzaPOqwYVN[index].jsEZFjLXzCLbHSuiDMyOzpSPaNAl;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return iPIdOnJGoQwneNCGSMbzaPOqwYVN[zeCpOSVCXkWKkuXzvzQRxmSpVbXI[(int)updateLoop]].jsEZFjLXzCLbHSuiDMyOzpSPaNAl;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= urYJGTKAOKlBYytmQBppNyEYOaRF)
			{
				throw new IndexOutOfRangeException();
			}
			iPIdOnJGoQwneNCGSMbzaPOqwYVN[index].jsEZFjLXzCLbHSuiDMyOzpSPaNAl = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= urYJGTKAOKlBYytmQBppNyEYOaRF)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return iPIdOnJGoQwneNCGSMbzaPOqwYVN[index].MmewooifFhteKJeABYnJXhjTHYki;
		}
	}
}
