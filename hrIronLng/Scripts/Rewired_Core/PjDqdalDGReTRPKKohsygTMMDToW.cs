using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class PjDqdalDGReTRPKKohsygTMMDToW
{
	private class cnrAdFBacRiwzgdKshmaBASNIggq
	{
		private class xUrmiFEhQqfOLCJudPSQPigvEGB
		{
			private int YeoWTxCQgRnimGZWwTJsKNURUbe;

			private NUumTgTsbLCIscZWZsoKKcQsieu[] aJtpRSRHtDeqCDIJtCvHanoFDlsc;

			private wDbWSCPawDTbvWeelIsfjiZPWma[] jvtuzgHGpVYYUcKiWEJhKXATgvN;

			public xUrmiFEhQqfOLCJudPSQPigvEGB(int index)
			{
				YeoWTxCQgRnimGZWwTJsKNURUbe = index;
				aJtpRSRHtDeqCDIJtCvHanoFDlsc = new NUumTgTsbLCIscZWZsoKKcQsieu[20];
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					aJtpRSRHtDeqCDIJtCvHanoFDlsc[i] = new NUumTgTsbLCIscZWZsoKKcQsieu();
				}
				jvtuzgHGpVYYUcKiWEJhKXATgvN = new wDbWSCPawDTbvWeelIsfjiZPWma[29];
				for (int j = 0; j < jvtuzgHGpVYYUcKiWEJhKXATgvN.Length; j++)
				{
					jvtuzgHGpVYYUcKiWEJhKXATgvN[j] = new wDbWSCPawDTbvWeelIsfjiZPWma(j);
				}
			}

			public void haigBPYnEYOHMRhDBFILgYsuyYdT()
			{
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(YeoWTxCQgRnimGZWwTJsKNURUbe, i);
					aJtpRSRHtDeqCDIJtCvHanoFDlsc[i].haigBPYnEYOHMRhDBFILgYsuyYdT(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < jvtuzgHGpVYYUcKiWEJhKXATgvN.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(YeoWTxCQgRnimGZWwTJsKNURUbe, j);
					jvtuzgHGpVYYUcKiWEJhKXATgvN[j].haigBPYnEYOHMRhDBFILgYsuyYdT(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					aJtpRSRHtDeqCDIJtCvHanoFDlsc[i].value = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(YeoWTxCQgRnimGZWwTJsKNURUbe, i);
				}
				for (int j = 0; j < jvtuzgHGpVYYUcKiWEJhKXATgvN.Length; j++)
				{
					jvtuzgHGpVYYUcKiWEJhKXATgvN[j].value = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(YeoWTxCQgRnimGZWwTJsKNURUbe, j);
				}
			}

			public bool JFLhhsViRZmASHFRAirmzVNMOhf(int P_0)
			{
				if (P_0 < 0 || P_0 >= aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length)
				{
					return false;
				}
				return aJtpRSRHtDeqCDIJtCvHanoFDlsc[P_0].value;
			}

			public bool CmwiIVrqfDqUrfdgDhwXnRxwqAE(int P_0)
			{
				if (P_0 < 0 || P_0 >= aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length)
				{
					return false;
				}
				return aJtpRSRHtDeqCDIJtCvHanoFDlsc[P_0].justPressed;
			}

			public bool cpecOFaBXVFHwWEOrZWGPOEkoSMP(int P_0)
			{
				if (P_0 < 0 || P_0 >= aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length)
				{
					return false;
				}
				return aJtpRSRHtDeqCDIJtCvHanoFDlsc[P_0].justReleased;
			}

			public float MUPgTaacHnwLRmoJOGqdcZFUrOL(int P_0)
			{
				if (P_0 < 0 || P_0 >= jvtuzgHGpVYYUcKiWEJhKXATgvN.Length)
				{
					return 0f;
				}
				return jvtuzgHGpVYYUcKiWEJhKXATgvN[P_0].value;
			}

			public bool pEONpayIfhrGohgneBlLmAmHdLv(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= jvtuzgHGpVYYUcKiWEJhKXATgvN.Length)
				{
					return false;
				}
				return jvtuzgHGpVYYUcKiWEJhKXATgvN[P_0].efPFnJtobodubpQYOBTayBiBGwP(P_1);
			}

			public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					aJtpRSRHtDeqCDIJtCvHanoFDlsc[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
				for (int j = 0; j < jvtuzgHGpVYYUcKiWEJhKXATgvN.Length; j++)
				{
					jvtuzgHGpVYYUcKiWEJhKXATgvN[j].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
			}
		}

		private class axeEVbvELWfEVKVsvqvjoLIbrSC
		{
			private NUumTgTsbLCIscZWZsoKKcQsieu[] aJtpRSRHtDeqCDIJtCvHanoFDlsc;

			public axeEVbvELWfEVKVsvqvjoLIbrSC()
			{
				aJtpRSRHtDeqCDIJtCvHanoFDlsc = new NUumTgTsbLCIscZWZsoKKcQsieu[7];
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					aJtpRSRHtDeqCDIJtCvHanoFDlsc[i] = new NUumTgTsbLCIscZWZsoKKcQsieu();
				}
			}

			public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					aJtpRSRHtDeqCDIJtCvHanoFDlsc[i].value = Input.GetButton("MouseButton" + i);
				}
			}

			public bool JFLhhsViRZmASHFRAirmzVNMOhf(int P_0)
			{
				if (P_0 < 0 || P_0 >= aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length)
				{
					return false;
				}
				return aJtpRSRHtDeqCDIJtCvHanoFDlsc[P_0].value;
			}

			public bool CmwiIVrqfDqUrfdgDhwXnRxwqAE(int P_0)
			{
				if (P_0 < 0 || P_0 >= aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length)
				{
					return false;
				}
				return aJtpRSRHtDeqCDIJtCvHanoFDlsc[P_0].justPressed;
			}

			public bool cpecOFaBXVFHwWEOrZWGPOEkoSMP(int P_0)
			{
				if (P_0 < 0 || P_0 >= aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length)
				{
					return false;
				}
				return aJtpRSRHtDeqCDIJtCvHanoFDlsc[P_0].justReleased;
			}

			public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				for (int i = 0; i < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; i++)
				{
					aJtpRSRHtDeqCDIJtCvHanoFDlsc[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
			}
		}

		private class NUumTgTsbLCIscZWZsoKKcQsieu
		{
			private bool rDXFGACXzNvmEuFurHYAqqwyQzh;

			private bool IhKLhrqiNQPKgnnQtlzfGRMHigN;

			public bool value
			{
				get
				{
					return rDXFGACXzNvmEuFurHYAqqwyQzh;
				}
				set
				{
					IhKLhrqiNQPKgnnQtlzfGRMHigN = rDXFGACXzNvmEuFurHYAqqwyQzh;
					rDXFGACXzNvmEuFurHYAqqwyQzh = value;
				}
			}

			public bool justPressed
			{
				get
				{
					if (rDXFGACXzNvmEuFurHYAqqwyQzh)
					{
						return !IhKLhrqiNQPKgnnQtlzfGRMHigN;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (IhKLhrqiNQPKgnnQtlzfGRMHigN)
					{
						return !rDXFGACXzNvmEuFurHYAqqwyQzh;
					}
					return false;
				}
			}

			public void haigBPYnEYOHMRhDBFILgYsuyYdT(bool P_0)
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh = P_0;
				IhKLhrqiNQPKgnnQtlzfGRMHigN = P_0;
			}

			public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh = false;
				IhKLhrqiNQPKgnnQtlzfGRMHigN = false;
			}
		}

		private class wDbWSCPawDTbvWeelIsfjiZPWma
		{
			private int pMHWUoAdVGSRCEdinnGPuzGxtnW;

			private float rDXFGACXzNvmEuFurHYAqqwyQzh;

			private float UdDEJXdJFRskFrBsxMdGryzLEMgm;

			public float value
			{
				get
				{
					return rDXFGACXzNvmEuFurHYAqqwyQzh;
				}
				set
				{
					rDXFGACXzNvmEuFurHYAqqwyQzh = value;
				}
			}

			public wDbWSCPawDTbvWeelIsfjiZPWma(int axisIndex)
			{
				pMHWUoAdVGSRCEdinnGPuzGxtnW = axisIndex;
			}

			public void haigBPYnEYOHMRhDBFILgYsuyYdT(float P_0)
			{
				UdDEJXdJFRskFrBsxMdGryzLEMgm = P_0;
				rDXFGACXzNvmEuFurHYAqqwyQzh = P_0;
			}

			public bool efPFnJtobodubpQYOBTayBiBGwP(bool P_0)
			{
				float num = rDXFGACXzNvmEuFurHYAqqwyQzh - UdDEJXdJFRskFrBsxMdGryzLEMgm;
				if (P_0 && num < 0f)
				{
					return false;
				}
				if (MathTools.Abs(num) > 0.7f)
				{
					return true;
				}
				return false;
			}

			public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh = 0f;
				UdDEJXdJFRskFrBsxMdGryzLEMgm = 0f;
			}
		}

		private xUrmiFEhQqfOLCJudPSQPigvEGB[] kjwFdZmRbOPrZUBwYofYzTFLQnc;

		private axeEVbvELWfEVKVsvqvjoLIbrSC asfRDzSekmvCpHiAVkQLFwtshxJ;

		public cnrAdFBacRiwzgdKshmaBASNIggq()
		{
			kjwFdZmRbOPrZUBwYofYzTFLQnc = new xUrmiFEhQqfOLCJudPSQPigvEGB[16];
			for (int i = 0; i < kjwFdZmRbOPrZUBwYofYzTFLQnc.Length; i++)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i] = new xUrmiFEhQqfOLCJudPSQPigvEGB(i);
			}
			asfRDzSekmvCpHiAVkQLFwtshxJ = new axeEVbvELWfEVKVsvqvjoLIbrSC();
		}

		public void haigBPYnEYOHMRhDBFILgYsuyYdT()
		{
			for (int i = 0; i < kjwFdZmRbOPrZUBwYofYzTFLQnc.Length; i++)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].haigBPYnEYOHMRhDBFILgYsuyYdT();
			}
		}

		public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
		{
			for (int i = 0; i < kjwFdZmRbOPrZUBwYofYzTFLQnc.Length; i++)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
			}
			asfRDzSekmvCpHiAVkQLFwtshxJ.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
		}

		public bool HGuZGXYoxHPfzmrtySRpetLzXPE(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= kjwFdZmRbOPrZUBwYofYzTFLQnc.Length)
			{
				return false;
			}
			return kjwFdZmRbOPrZUBwYofYzTFLQnc[P_0].JFLhhsViRZmASHFRAirmzVNMOhf(P_1);
		}

		public bool ibpwVFivgGFEGRkTwYpHtsrUEAK(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= kjwFdZmRbOPrZUBwYofYzTFLQnc.Length)
			{
				return false;
			}
			return kjwFdZmRbOPrZUBwYofYzTFLQnc[P_0].CmwiIVrqfDqUrfdgDhwXnRxwqAE(P_1);
		}

		public bool ZuhSdEBrQtSJVmmiwzYPfLWeWOI(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= kjwFdZmRbOPrZUBwYofYzTFLQnc.Length)
			{
				return false;
			}
			return kjwFdZmRbOPrZUBwYofYzTFLQnc[P_0].cpecOFaBXVFHwWEOrZWGPOEkoSMP(P_1);
		}

		public bool EjHXQfThgAaacaDTMKLFRbbIClzK(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= kjwFdZmRbOPrZUBwYofYzTFLQnc.Length)
			{
				return false;
			}
			return kjwFdZmRbOPrZUBwYofYzTFLQnc[P_0].pEONpayIfhrGohgneBlLmAmHdLv(P_1, P_2);
		}

		public bool CTIxIVzfEiWQbIHkhttLtWQkvDI(int P_0)
		{
			return asfRDzSekmvCpHiAVkQLFwtshxJ.JFLhhsViRZmASHFRAirmzVNMOhf(P_0);
		}

		public bool ViSSxHQMAtjbqEDCuszVZVfzOyR(int P_0)
		{
			return asfRDzSekmvCpHiAVkQLFwtshxJ.CmwiIVrqfDqUrfdgDhwXnRxwqAE(P_0);
		}

		public bool GzLIoZRowTcdslVvjgUcwisvmFG(int P_0)
		{
			return asfRDzSekmvCpHiAVkQLFwtshxJ.cpecOFaBXVFHwWEOrZWGPOEkoSMP(P_0);
		}

		public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			for (int i = 0; i < kjwFdZmRbOPrZUBwYofYzTFLQnc.Length; i++)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
			asfRDzSekmvCpHiAVkQLFwtshxJ.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}
	}

	private UpdateLoopType TShjztsSqTidVVARtigrVGyvDKuC;

	private cnrAdFBacRiwzgdKshmaBASNIggq AcYTOiDjHgaCbkuLjDYOczoUuTJ;

	private IndexedDictionary<int, cnrAdFBacRiwzgdKshmaBASNIggq> ALzKzwEPPCnkjtevfNykduPJedu;

	public PjDqdalDGReTRPKKohsygTMMDToW(UpdateLoopSetting updateLoopSetting)
	{
		ALzKzwEPPCnkjtevfNykduPJedu = new IndexedDictionary<int, cnrAdFBacRiwzgdKshmaBASNIggq>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				ALzKzwEPPCnkjtevfNykduPJedu.Add((int)list[i], new cnrAdFBacRiwzgdKshmaBASNIggq());
			}
		}
		TShjztsSqTidVVARtigrVGyvDKuC = UpdateLoopType.Update;
		AcYTOiDjHgaCbkuLjDYOczoUuTJ = ALzKzwEPPCnkjtevfNykduPJedu.GetValue(0);
	}

	public void haigBPYnEYOHMRhDBFILgYsuyYdT()
	{
		TrrNLWIBBtbmazesCbGbiSzlKqG(ReInput.currentUpdateLoop);
		AcYTOiDjHgaCbkuLjDYOczoUuTJ.haigBPYnEYOHMRhDBFILgYsuyYdT();
	}

	public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
	{
		TrrNLWIBBtbmazesCbGbiSzlKqG(P_0);
		AcYTOiDjHgaCbkuLjDYOczoUuTJ.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
	}

	public bool HGuZGXYoxHPfzmrtySRpetLzXPE(int P_0, int P_1)
	{
		return AcYTOiDjHgaCbkuLjDYOczoUuTJ.HGuZGXYoxHPfzmrtySRpetLzXPE(P_0, P_1);
	}

	public bool ibpwVFivgGFEGRkTwYpHtsrUEAK(int P_0, int P_1)
	{
		return AcYTOiDjHgaCbkuLjDYOczoUuTJ.ibpwVFivgGFEGRkTwYpHtsrUEAK(P_0, P_1);
	}

	public bool ZuhSdEBrQtSJVmmiwzYPfLWeWOI(int P_0, int P_1)
	{
		return AcYTOiDjHgaCbkuLjDYOczoUuTJ.ZuhSdEBrQtSJVmmiwzYPfLWeWOI(P_0, P_1);
	}

	public bool EjHXQfThgAaacaDTMKLFRbbIClzK(int P_0, int P_1, bool P_2)
	{
		return AcYTOiDjHgaCbkuLjDYOczoUuTJ.EjHXQfThgAaacaDTMKLFRbbIClzK(P_0, P_1, P_2);
	}

	public bool CTIxIVzfEiWQbIHkhttLtWQkvDI(int P_0)
	{
		return AcYTOiDjHgaCbkuLjDYOczoUuTJ.CTIxIVzfEiWQbIHkhttLtWQkvDI(P_0);
	}

	public bool ViSSxHQMAtjbqEDCuszVZVfzOyR(int P_0)
	{
		return AcYTOiDjHgaCbkuLjDYOczoUuTJ.ViSSxHQMAtjbqEDCuszVZVfzOyR(P_0);
	}

	public bool GzLIoZRowTcdslVvjgUcwisvmFG(int P_0)
	{
		return AcYTOiDjHgaCbkuLjDYOczoUuTJ.GzLIoZRowTcdslVvjgUcwisvmFG(P_0);
	}

	public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
	{
		for (int i = 0; i < ALzKzwEPPCnkjtevfNykduPJedu.Count; i++)
		{
			ALzKzwEPPCnkjtevfNykduPJedu[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}
	}

	private void TrrNLWIBBtbmazesCbGbiSzlKqG(UpdateLoopType P_0)
	{
		if (TShjztsSqTidVVARtigrVGyvDKuC != P_0)
		{
			TShjztsSqTidVVARtigrVGyvDKuC = P_0;
			AcYTOiDjHgaCbkuLjDYOczoUuTJ = ALzKzwEPPCnkjtevfNykduPJedu.GetValue((int)P_0);
		}
	}
}
