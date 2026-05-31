using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Rewired;
using Rewired.Libraries.SharpDX.RawInput;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;

internal class EkVkWMYCVwtPsFXxHOsvvAxKeBxA
{
	private const uint muPjPBMWdNCHKOiFfAMVccCLqPwO = 8192u;

	private const uint GtQGcuDWVXlCOKicUibvXyzFkUN = 100u;

	private const uint FenINcMCMCfYFKbiLfxlZPWWeuS = 8192u;

	private static readonly EugmBWQTjvJBXorkcWtQvGwQgTc RMSZKhseDFvyHtVlFJaDCeiQZVT;

	private static IntPtr aMBSIMXrmyxJHcQpxajwhOoYqVm;

	private static bool VhEYEKjlanmYvOwGeegKSicGruY;

	private static IntPtr kKyBdUXGvytnvotnBEHqHJGPJsq;

	private static bool MGOzYaWJAYYyRwHyWiOADrKmZso;

	private static readonly int cehcYjlJhIRRJfTJgoDhVyMwuHm;

	private static readonly int DTjJxJKThrtEeVbegHHEuvraUsM;

	private static readonly NativeBuffer TNqSegkBeBQLZrHVtEkmPhsCawN;

	private static readonly bool bdbwOGjyuuNQfLHwdxiolEGQnVM;

	private static readonly byte[] pTqzKuXJyVpYKrqOOXJwwmnGwhi;

	private static readonly uint[] gNTsbGpllNOboFRQfToPKyhnLWp;

	private static readonly uint[] NYZbmKttcIgKGKEbALeILPfqFpu;

	private static readonly bool XDnwToJJDnnFhUaadTnjCNbHKGQ;

	private static ForwardRawInputEventsToUnityDelegate TkXfmPnMoXpMsQnuvMcheKINzvi;

	private static Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> CKbaVvAzpstjZSAovreLoyNJjVjF;

	private static Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> PpRMwYpbOrNVlRhQJbQlitubCIV;

	private static Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> dqxZCtZKFepYbNxRzUGjBpCpjgSj;

	private static Action<IntPtr> rBOlgmAeHAFVEslBdaLAGSNuRdHr;

	private static Action usUFnpgdYIUkAhWbGwAaFRwliKy;

	public static ForwardRawInputEventsToUnityDelegate forwardRawInputEventsDelegate
	{
		get
		{
			return TkXfmPnMoXpMsQnuvMcheKINzvi;
		}
		set
		{
			TkXfmPnMoXpMsQnuvMcheKINzvi = value;
		}
	}

	public static event Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> KeyboardInput
	{
		add
		{
			Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> action = CKbaVvAzpstjZSAovreLoyNJjVjF;
			Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> action2;
			do
			{
				action2 = action;
				Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> value2 = (Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref CKbaVvAzpstjZSAovreLoyNJjVjF, value2, action2);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> action = CKbaVvAzpstjZSAovreLoyNJjVjF;
			Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> action2;
			do
			{
				action2 = action;
				Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double> value2 = (Action<cBjdMczDgoEYQlFSGytXSwLhLdF, double>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref CKbaVvAzpstjZSAovreLoyNJjVjF, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> MouseInput
	{
		add
		{
			Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> action = PpRMwYpbOrNVlRhQJbQlitubCIV;
			Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> action2;
			do
			{
				action2 = action;
				Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> value2 = (Action<FxXuFsDGohnklEbYOAktGXFvpsa, double>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref PpRMwYpbOrNVlRhQJbQlitubCIV, value2, action2);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> action = PpRMwYpbOrNVlRhQJbQlitubCIV;
			Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> action2;
			do
			{
				action2 = action;
				Action<FxXuFsDGohnklEbYOAktGXFvpsa, double> value2 = (Action<FxXuFsDGohnklEbYOAktGXFvpsa, double>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref PpRMwYpbOrNVlRhQJbQlitubCIV, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> RawInput
	{
		add
		{
			Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> action = dqxZCtZKFepYbNxRzUGjBpCpjgSj;
			Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> action2;
			do
			{
				action2 = action;
				Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> value2 = (Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref dqxZCtZKFepYbNxRzUGjBpCpjgSj, value2, action2);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> action = dqxZCtZKFepYbNxRzUGjBpCpjgSj;
			Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> action2;
			do
			{
				action2 = action;
				Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double> value2 = (Action<xVpqVseTQjmLMIZnQEZASnpdzDu, double>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref dqxZCtZKFepYbNxRzUGjBpCpjgSj, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<IntPtr> DeviceConnectedEvent
	{
		add
		{
			Action<IntPtr> action = rBOlgmAeHAFVEslBdaLAGSNuRdHr;
			Action<IntPtr> action2;
			do
			{
				action2 = action;
				Action<IntPtr> value2 = (Action<IntPtr>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref rBOlgmAeHAFVEslBdaLAGSNuRdHr, value2, action2);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<IntPtr> action = rBOlgmAeHAFVEslBdaLAGSNuRdHr;
			Action<IntPtr> action2;
			do
			{
				action2 = action;
				Action<IntPtr> value2 = (Action<IntPtr>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref rBOlgmAeHAFVEslBdaLAGSNuRdHr, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action DeviceDisconnectedEvent
	{
		add
		{
			Action action = usUFnpgdYIUkAhWbGwAaFRwliKy;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref usUFnpgdYIUkAhWbGwAaFRwliKy, value2, action2);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = usUFnpgdYIUkAhWbGwAaFRwliKy;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref usUFnpgdYIUkAhWbGwAaFRwliKy, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	static EkVkWMYCVwtPsFXxHOsvvAxKeBxA()
	{
		RMSZKhseDFvyHtVlFJaDCeiQZVT = SKRvzQSHgIEBgwIYQAoOmdXStap;
		cehcYjlJhIRRJfTJgoDhVyMwuHm = JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<oJqDOpLSpzXpieFwwDGOPDuUBLb>();
		DTjJxJKThrtEeVbegHHEuvraUsM = JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<iOOQIEtdZDQeMABXgchzEZokWcv>();
		bdbwOGjyuuNQfLHwdxiolEGQnVM = UnityTools.windowsStandalone_supportsRawInputForwarding;
		if (bdbwOGjyuuNQfLHwdxiolEGQnVM)
		{
			try
			{
				TNqSegkBeBQLZrHVtEkmPhsCawN = new NativeBuffer(8192);
				pTqzKuXJyVpYKrqOOXJwwmnGwhi = new byte[8192];
				gNTsbGpllNOboFRQfToPKyhnLWp = new uint[100];
				NYZbmKttcIgKGKEbALeILPfqFpu = new uint[100];
			}
			catch
			{
				bdbwOGjyuuNQfLHwdxiolEGQnVM = false;
				Logger.LogError("Could not allocate memory for Raw Input buffer.", requiredThreadSafety: true);
			}
		}
		XDnwToJJDnnFhUaadTnjCNbHKGQ = !SystemInfo.is64Bit && AewjMoBLyBolnnNMhBXWHRooNZC.fMLbqtKOCPvcPfZfxjnLngbxRCxh();
	}

	public static void LFIgfiHYNUQmKRHYAoaxATLEvNvL(IntPtr P_0, bool P_1)
	{
		VhEYEKjlanmYvOwGeegKSicGruY = P_1;
		if (!(P_0 == IntPtr.Zero) && !(P_0 == aMBSIMXrmyxJHcQpxajwhOoYqVm))
		{
			aMBSIMXrmyxJHcQpxajwhOoYqVm = P_0;
			MGOzYaWJAYYyRwHyWiOADrKmZso = true;
		}
	}

	public static void pBkWucpvPeUIQSMdobwZGjnHrV(bool P_0)
	{
		VhEYEKjlanmYvOwGeegKSicGruY = P_0;
	}

	public static EugmBWQTjvJBXorkcWtQvGwQgTc shBkdkpsRRvZpzjDrUquQNAjPao()
	{
		return RMSZKhseDFvyHtVlFJaDCeiQZVT;
	}

	public unsafe static List<iyIwThXmVTAIckoxFwEfUfmQUsL> yDqiGSkMQYxYBcosfJNCvDgVcTXc(bool P_0)
	{
		int num = 0;
		pKZMnjMMImQdiKyeumoKPkbgwQI.WPimmLUNirHddOMGogIEehnEPAPc(null, ref num, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<AZmbvcVIunYbHEntMIOGHkdhIws>());
		if (num == 0)
		{
			return null;
		}
		AZmbvcVIunYbHEntMIOGHkdhIws[] array = new AZmbvcVIunYbHEntMIOGHkdhIws[num];
		pKZMnjMMImQdiKyeumoKPkbgwQI.WPimmLUNirHddOMGogIEehnEPAPc(array, ref num, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<AZmbvcVIunYbHEntMIOGHkdhIws>());
		string[] array2 = new string[num];
		int num2 = 0;
		int num3 = 0;
		List<iyIwThXmVTAIckoxFwEfUfmQUsL> list = new List<iyIwThXmVTAIckoxFwEfUfmQUsL>();
		for (int i = 0; i < num; i++)
		{
			bool flag = false;
			IntPtr iwQsZkJYbdNBBYrWJIGRHvvDEft = array[i].IwQsZkJYbdNBBYrWJIGRHvvDEft;
			int num4 = 0;
			pKZMnjMMImQdiKyeumoKPkbgwQI.uXdQxHDpZlhDnraSJLluJrIrfUF(iwQsZkJYbdNBBYrWJIGRHvvDEft, yDzOYwhrGcjGweXvPzNXXJeRUPD.grGKADVFdGGSLUntXjqDNCkqUpU, IntPtr.Zero, ref num4);
			if (num4 == 0)
			{
				flag = true;
			}
			char* ptr = stackalloc char[num4];
			pKZMnjMMImQdiKyeumoKPkbgwQI.uXdQxHDpZlhDnraSJLluJrIrfUF(iwQsZkJYbdNBBYrWJIGRHvvDEft, yDzOYwhrGcjGweXvPzNXXJeRUPD.grGKADVFdGGSLUntXjqDNCkqUpU, (IntPtr)ptr, ref num4);
			int length = ((num4 > 0) ? (num4 - 1) : 0);
			string text = new string(ptr, 0, length);
			if (text.Length == 0)
			{
				text = string.Empty;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			int num5 = 0;
			for (int j = 0; j < bytes.Length; j++)
			{
				if (bytes[j] != 0)
				{
					num5++;
				}
			}
			if (num5 != bytes.Length)
			{
				if (num5 == 0)
				{
					text = string.Empty;
				}
				else
				{
					byte[] array3 = new byte[num5];
					int num6 = 0;
					for (int k = 0; k < bytes.Length; k++)
					{
						if (bytes[k] != 0)
						{
							array3[num6] = bytes[k];
							num6++;
						}
					}
					text = Encoding.UTF8.GetString(array3);
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (!string.IsNullOrEmpty(array2[l]) && string.Equals(array2[l], text, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
			}
			array2[i] = text;
			int num7 = 0;
			int num8 = pKZMnjMMImQdiKyeumoKPkbgwQI.uXdQxHDpZlhDnraSJLluJrIrfUF(iwQsZkJYbdNBBYrWJIGRHvvDEft, yDzOYwhrGcjGweXvPzNXXJeRUPD.KYGPUtgqYxzzHXPzLmAfndkgbKA, IntPtr.Zero, ref num7);
			if (num7 == 0)
			{
				if (flag)
				{
					num3++;
				}
				continue;
			}
			byte* ptr2 = stackalloc byte[(int)(uint)num7];
			*(int*)ptr2 = num7;
			num8 = pKZMnjMMImQdiKyeumoKPkbgwQI.uXdQxHDpZlhDnraSJLluJrIrfUF(iwQsZkJYbdNBBYrWJIGRHvvDEft, yDzOYwhrGcjGweXvPzNXXJeRUPD.KYGPUtgqYxzzHXPzLmAfndkgbKA, (IntPtr)ptr2, ref num7);
			if (num8 >= 0)
			{
				try
				{
					ghJPqjSBgqEidmvfDuvMlyNpuRu ghJPqjSBgqEidmvfDuvMlyNpuRu2 = *(ghJPqjSBgqEidmvfDuvMlyNpuRu*)ptr2;
					iyIwThXmVTAIckoxFwEfUfmQUsL item = iyIwThXmVTAIckoxFwEfUfmQUsL.RwYRYRusefnxswccZKlgeBuliwQ(ref ghJPqjSBgqEidmvfDuvMlyNpuRu2, text, iwQsZkJYbdNBBYrWJIGRHvvDEft);
					list.Add(item);
				}
				catch (Exception)
				{
					throw;
				}
				num2++;
			}
		}
		if (P_0 && num2 == 0 && num3 > 0)
		{
			Exception ex2 = new Exception("Possible sandbox detected.");
			ex2.Data.Add(1, "sandbox");
			throw ex2;
		}
		return list;
	}

	public static void JXvLmUdzSkDuqEitjeAVpcnLGqm(cqrrYzQQNtwerOenPmEAhYSfbvo P_0, VABRdqYQwczyEykxLDdEfwgXtM P_1, udeFPeagJNADrdnQrjwMerhHHxJM P_2, IntPtr P_3)
	{
		CtNYpbJCDqfBuwgobuGKPnMOhUT[] array = new CtNYpbJCDqfBuwgobuGKPnMOhUT[1];
		array[0].NmQhBtQCcgcHDaWeaCjxXfWGcIGd = (short)P_0;
		array[0].ZYGeQPjXCaJVJLnAiYGNJFbZgfk = (short)P_1;
		array[0].wbmxfUinNZtnthzDdPSUImGyMjT = (int)P_2;
		array[0].PJlJGGkbAhuATkazDDtetKaRWR = P_3;
		pKZMnjMMImQdiKyeumoKPkbgwQI.tnkrQmbACuXnOzOegYrmbelFiJ(array, 1, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<CtNYpbJCDqfBuwgobuGKPnMOhUT>());
	}

	public static void eOHWtWJjUGQSvtUiHnEKkDIcqJr(cqrrYzQQNtwerOenPmEAhYSfbvo P_0, VABRdqYQwczyEykxLDdEfwgXtM P_1)
	{
		CtNYpbJCDqfBuwgobuGKPnMOhUT[] array = new CtNYpbJCDqfBuwgobuGKPnMOhUT[1];
		array[0].NmQhBtQCcgcHDaWeaCjxXfWGcIGd = (short)P_0;
		array[0].ZYGeQPjXCaJVJLnAiYGNJFbZgfk = (short)P_1;
		array[0].wbmxfUinNZtnthzDdPSUImGyMjT = 1;
		array[0].PJlJGGkbAhuATkazDDtetKaRWR = IntPtr.Zero;
		pKZMnjMMImQdiKyeumoKPkbgwQI.tnkrQmbACuXnOzOegYrmbelFiJ(array, 1, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<CtNYpbJCDqfBuwgobuGKPnMOhUT>());
	}

	internal static void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		CKbaVvAzpstjZSAovreLoyNJjVjF = null;
		PpRMwYpbOrNVlRhQJbQlitubCIV = null;
		dqxZCtZKFepYbNxRzUGjBpCpjgSj = null;
		aMBSIMXrmyxJHcQpxajwhOoYqVm = IntPtr.Zero;
		VhEYEKjlanmYvOwGeegKSicGruY = false;
		kKyBdUXGvytnvotnBEHqHJGPJsq = IntPtr.Zero;
		MGOzYaWJAYYyRwHyWiOADrKmZso = false;
	}

	public unsafe static void zAeRLwCciujaBHXdkummCczJnQlC(IntPtr P_0, double P_1)
	{
		if (bdbwOGjyuuNQfLHwdxiolEGQnVM)
		{
			uint num = 0u;
			uint num2 = 0u;
			uint num3 = 8192u;
			int num4 = 0;
			if (pKZMnjMMImQdiKyeumoKPkbgwQI.tYywPmEMznZgYESvREorQiNjYWS(P_0, vJEfxIGFfCJqylTBjQxgDpIzhTAl.bLNYQxUzEEsneBGkDOGPKOeskCQ, IntPtr.Zero, ref num4, DTjJxJKThrtEeVbegHHEuvraUsM) < 0 || num4 == 0)
			{
				return;
			}
			num4 = (int)num3;
			if (pKZMnjMMImQdiKyeumoKPkbgwQI.tYywPmEMznZgYESvREorQiNjYWS(P_0, vJEfxIGFfCJqylTBjQxgDpIzhTAl.bLNYQxUzEEsneBGkDOGPKOeskCQ, TNqSegkBeBQLZrHVtEkmPhsCawN.Pointer, ref num4, DTjJxJKThrtEeVbegHHEuvraUsM) < 0)
			{
				return;
			}
			oJqDOpLSpzXpieFwwDGOPDuUBLb* ptr = (oJqDOpLSpzXpieFwwDGOPDuUBLb*)(void*)TNqSegkBeBQLZrHVtEkmPhsCawN.Pointer;
			RmhmWLqMrgtOVnKqjBBtDxiYDDpP(ptr, P_1);
			yUovqGGwwnIujnAEaiPhznWlTNR(ptr, pTqzKuXJyVpYKrqOOXJwwmnGwhi, gNTsbGpllNOboFRQfToPKyhnLWp, NYZbmKttcIgKGKEbALeILPfqFpu, ref num2, ref num);
			if (XDnwToJJDnnFhUaadTnjCNbHKGQ)
			{
				int num5;
				while ((num5 = AewjMoBLyBolnnNMhBXWHRooNZC.WgZDhIiQBPfslnwjTubhPxUhEtU(TNqSegkBeBQLZrHVtEkmPhsCawN.Pointer, ref num3, (uint)DTjJxJKThrtEeVbegHHEuvraUsM)) > 0)
				{
					byte* ptr2 = (byte*)(void*)TNqSegkBeBQLZrHVtEkmPhsCawN.Pointer;
					for (int i = 0; i < num5; i++)
					{
						int lFmyulvhyawdMpwOAdWQXdZXmuB = ((iOOQIEtdZDQeMABXgchzEZokWcv*)ptr2)->LFmyulvhyawdMpwOAdWQXdZXmuB;
						byte* ptr3 = stackalloc byte[(int)(uint)(DTjJxJKThrtEeVbegHHEuvraUsM + lFmyulvhyawdMpwOAdWQXdZXmuB)];
						jrpbiUWSBQEMcGMhBQbhkaeULUlm.YMlWNtHvqNKpeZSRXxCWKEFddZG(ptr2, ptr3, 0, 0, DTjJxJKThrtEeVbegHHEuvraUsM);
						jrpbiUWSBQEMcGMhBQbhkaeULUlm.YMlWNtHvqNKpeZSRXxCWKEFddZG(ptr2, ptr3, DTjJxJKThrtEeVbegHHEuvraUsM + 8, DTjJxJKThrtEeVbegHHEuvraUsM, lFmyulvhyawdMpwOAdWQXdZXmuB);
						ptr = (oJqDOpLSpzXpieFwwDGOPDuUBLb*)ptr3;
						RmhmWLqMrgtOVnKqjBBtDxiYDDpP(ptr, P_1);
						yUovqGGwwnIujnAEaiPhznWlTNR(ptr, pTqzKuXJyVpYKrqOOXJwwmnGwhi, gNTsbGpllNOboFRQfToPKyhnLWp, NYZbmKttcIgKGKEbALeILPfqFpu, ref num2, ref num);
						ptr2 = (byte*)RETOrZtFGMNYJdskCxWJKMJmcIj.eiHYCwRJuGpCsfBpxNiymPAWFbX((oJqDOpLSpzXpieFwwDGOPDuUBLb*)ptr2);
					}
				}
			}
			else
			{
				int num5;
				while ((num5 = AewjMoBLyBolnnNMhBXWHRooNZC.WgZDhIiQBPfslnwjTubhPxUhEtU(TNqSegkBeBQLZrHVtEkmPhsCawN.Pointer, ref num3, (uint)DTjJxJKThrtEeVbegHHEuvraUsM)) > 0)
				{
					ptr = (oJqDOpLSpzXpieFwwDGOPDuUBLb*)(void*)TNqSegkBeBQLZrHVtEkmPhsCawN.Pointer;
					for (int j = 0; j < num5; j++)
					{
						RmhmWLqMrgtOVnKqjBBtDxiYDDpP(ptr, P_1);
						yUovqGGwwnIujnAEaiPhznWlTNR(ptr, pTqzKuXJyVpYKrqOOXJwwmnGwhi, gNTsbGpllNOboFRQfToPKyhnLWp, NYZbmKttcIgKGKEbALeILPfqFpu, ref num2, ref num);
						ptr = RETOrZtFGMNYJdskCxWJKMJmcIj.eiHYCwRJuGpCsfBpxNiymPAWFbX(ptr);
					}
				}
			}
			jTNycMEMXwFQgDClNBbXBCdULdcM(pTqzKuXJyVpYKrqOOXJwwmnGwhi, gNTsbGpllNOboFRQfToPKyhnLWp, NYZbmKttcIgKGKEbALeILPfqFpu, ref num2, ref num);
		}
		else
		{
			int num6 = 0;
			pKZMnjMMImQdiKyeumoKPkbgwQI.tYywPmEMznZgYESvREorQiNjYWS(P_0, vJEfxIGFfCJqylTBjQxgDpIzhTAl.bLNYQxUzEEsneBGkDOGPKOeskCQ, IntPtr.Zero, ref num6, DTjJxJKThrtEeVbegHHEuvraUsM);
			if (num6 != 0)
			{
				byte* ptr4 = stackalloc byte[(int)(uint)num6];
				pKZMnjMMImQdiKyeumoKPkbgwQI.tYywPmEMznZgYESvREorQiNjYWS(P_0, vJEfxIGFfCJqylTBjQxgDpIzhTAl.bLNYQxUzEEsneBGkDOGPKOeskCQ, (IntPtr)ptr4, ref num6, DTjJxJKThrtEeVbegHHEuvraUsM);
				RmhmWLqMrgtOVnKqjBBtDxiYDDpP((oJqDOpLSpzXpieFwwDGOPDuUBLb*)ptr4, P_1);
			}
		}
	}

	private unsafe static void yUovqGGwwnIujnAEaiPhznWlTNR(oJqDOpLSpzXpieFwwDGOPDuUBLb* P_0, byte[] P_1, uint[] P_2, uint[] P_3, ref uint P_4, ref uint P_5)
	{
		if (!IDitextfxVkZUscVtUryZjTeSit(P_0, P_1, P_2, P_3, ref P_4, ref P_5))
		{
			jTNycMEMXwFQgDClNBbXBCdULdcM(P_1, P_2, P_3, ref P_4, ref P_5);
			IDitextfxVkZUscVtUryZjTeSit(P_0, P_1, P_2, P_3, ref P_4, ref P_5);
		}
	}

	private unsafe static bool IDitextfxVkZUscVtUryZjTeSit(oJqDOpLSpzXpieFwwDGOPDuUBLb* P_0, byte[] P_1, uint[] P_2, uint[] P_3, ref uint P_4, ref uint P_5)
	{
		iOOQIEtdZDQeMABXgchzEZokWcv* ptr = &P_0->byDGMqNQwQgcEKGrKIjIwBvRyWv;
		uint num = (uint)(DTjJxJKThrtEeVbegHHEuvraUsM + ptr->LFmyulvhyawdMpwOAdWQXdZXmuB);
		if (P_4 + num > P_1.Length)
		{
			return false;
		}
		if (P_5 == P_2.Length)
		{
			return false;
		}
		Marshal.Copy((IntPtr)P_0, P_1, (int)P_4, DTjJxJKThrtEeVbegHHEuvraUsM + ptr->LFmyulvhyawdMpwOAdWQXdZXmuB);
		P_2[P_5] = P_4;
		P_3[P_5] = (uint)(P_4 + DTjJxJKThrtEeVbegHHEuvraUsM);
		P_5++;
		P_4 += num;
		return true;
	}

	private unsafe static void jTNycMEMXwFQgDClNBbXBCdULdcM(byte[] P_0, uint[] P_1, uint[] P_2, ref uint P_3, ref uint P_4)
	{
		if (TkXfmPnMoXpMsQnuvMcheKINzvi == null || P_4 == 0 || P_3 == 0)
		{
			P_3 = 0u;
			P_4 = 0u;
			return;
		}
		try
		{
			fixed (byte* ptr = P_0)
			{
				fixed (uint* ptr2 = P_1)
				{
					fixed (uint* ptr3 = P_2)
					{
						TkXfmPnMoXpMsQnuvMcheKINzvi((IntPtr)ptr2, (IntPtr)ptr3, P_4, (IntPtr)ptr, P_3);
					}
				}
			}
		}
		catch (Exception msg)
		{
			Logger.LogError(msg, requiredThreadSafety: true);
		}
		P_3 = 0u;
		P_4 = 0u;
	}

	private unsafe static void RmhmWLqMrgtOVnKqjBBtDxiYDDpP(oJqDOpLSpzXpieFwwDGOPDuUBLb* P_0, double P_1)
	{
		switch (P_0->byDGMqNQwQgcEKGrKIjIwBvRyWv.UANajORgEjGJZDtTWdmqYjUulHF)
		{
		case MAPTyOhgNVdBQSioUpquSdYiRkd.FwhTFJcoxdOAZsdJarteiktzdNZ:
			if (dqxZCtZKFepYbNxRzUGjBpCpjgSj != null)
			{
				xVpqVseTQjmLMIZnQEZASnpdzDu arg = new xVpqVseTQjmLMIZnQEZASnpdzDu(ref *P_0, NLAafvtpIMpkQDvRyQpTkAkoxUf.lwBeTwCdWwgYTDGlpqpgjcqyRcS);
				if (arg.IsValid)
				{
					dqxZCtZKFepYbNxRzUGjBpCpjgSj(arg, P_1);
				}
			}
			break;
		case MAPTyOhgNVdBQSioUpquSdYiRkd.cXiIaGSjeBKnSzIJGvtEtwBDTsm:
			if (CKbaVvAzpstjZSAovreLoyNJjVjF != null)
			{
				CKbaVvAzpstjZSAovreLoyNJjVjF(new cBjdMczDgoEYQlFSGytXSwLhLdF(ref *P_0), P_1);
			}
			break;
		case MAPTyOhgNVdBQSioUpquSdYiRkd.NcOiPCmfYWmxxojUswKfONTIHos:
			if (PpRMwYpbOrNVlRhQJbQlitubCIV != null)
			{
				PpRMwYpbOrNVlRhQJbQlitubCIV(new FxXuFsDGohnklEbYOAktGXFvpsa(ref *P_0), P_1);
			}
			break;
		}
	}

	private static void dMboDKLVwTDuXWlFZfjegWdVSRDg(IntPtr P_0, IntPtr P_1)
	{
		switch (P_0.ToInt32())
		{
		case 1:
			if (rBOlgmAeHAFVEslBdaLAGSNuRdHr != null)
			{
				rBOlgmAeHAFVEslBdaLAGSNuRdHr(P_1);
			}
			break;
		case 2:
			if (usUFnpgdYIUkAhWbGwAaFRwliKy != null)
			{
				usUFnpgdYIUkAhWbGwAaFRwliKy();
			}
			break;
		}
	}

	[MonoPInvokeCallback(typeof(EugmBWQTjvJBXorkcWtQvGwQgTc))]
	private static IntPtr SKRvzQSHgIEBgwIYQAoOmdXStap(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		switch (P_1)
		{
		case 255u:
			zAeRLwCciujaBHXdkummCczJnQlC(P_3, ReInput.realTime);
			if (VhEYEKjlanmYvOwGeegKSicGruY && !bdbwOGjyuuNQfLHwdxiolEGQnVM)
			{
				GICGgsoGEasetIFkYeeIupygiCY(P_0, P_1, P_2, P_3);
			}
			break;
		case 254u:
			dMboDKLVwTDuXWlFZfjegWdVSRDg(P_2, P_3);
			break;
		}
		return IntPtr.Zero;
	}

	private static void GICGgsoGEasetIFkYeeIupygiCY(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (wPobypBrGqJFMzpPsHcbxMDAdOQb.tnpXovapZeMTkjrIXoysdQnNfdq(aMBSIMXrmyxJHcQpxajwhOoYqVm))
		{
			if (MGOzYaWJAYYyRwHyWiOADrKmZso)
			{
				kKyBdUXGvytnvotnBEHqHJGPJsq = wPobypBrGqJFMzpPsHcbxMDAdOQb.mIcfmROfUnqGxOdljRQshbYfeZD(aMBSIMXrmyxJHcQpxajwhOoYqVm, wPobypBrGqJFMzpPsHcbxMDAdOQb.zPOCPaHmHblMOcOAMgXFBQqlwUS.SKRvzQSHgIEBgwIYQAoOmdXStap);
				MGOzYaWJAYYyRwHyWiOADrKmZso = false;
			}
			if (kKyBdUXGvytnvotnBEHqHJGPJsq != IntPtr.Zero)
			{
				wPobypBrGqJFMzpPsHcbxMDAdOQb.lmIFqBFHfPjoSGqaevsdloGxHlNe(kKyBdUXGvytnvotnBEHqHJGPJsq, aMBSIMXrmyxJHcQpxajwhOoYqVm, (int)P_1, P_2, P_3);
			}
		}
	}
}
