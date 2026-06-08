using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

internal static class VpaEvRBtdsqRFIXgptXqzCAXuwN
{
	private static Dictionary<IntPtr, List<CmJrJrItMoTbvbevKsCGaiZxZUH>> NqMeSMGHiOifPBeHSAqQSmrlSNeh;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<CmJrJrItMoTbvbevKsCGaiZxZUH>> uADgOqUNZFTLrwIUiSPHyBOeRCO;

	private static EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> WnnhcrFAdYQmURPsaEoCLgdllgR;

	private static EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> HAYxyxUVNTdigtgABOafjtjXCgt;

	private static Dictionary<IntPtr, List<CmJrJrItMoTbvbevKsCGaiZxZUH>> ObjectReferences
	{
		get
		{
			if (DBqWdhHkzzKerymufWpquDqNZdX.ZthKFLHHYWEbSUYGbriZHEgWYwr)
			{
				if (uADgOqUNZFTLrwIUiSPHyBOeRCO == null)
				{
					uADgOqUNZFTLrwIUiSPHyBOeRCO = new Dictionary<IntPtr, List<CmJrJrItMoTbvbevKsCGaiZxZUH>>(gzEPiyMlhiwikloOqmmyBoKrtIf.NPVYiMLFReocSqajMIQVeYrCvwr);
				}
				return uADgOqUNZFTLrwIUiSPHyBOeRCO;
			}
			if (NqMeSMGHiOifPBeHSAqQSmrlSNeh == null)
			{
				NqMeSMGHiOifPBeHSAqQSmrlSNeh = new Dictionary<IntPtr, List<CmJrJrItMoTbvbevKsCGaiZxZUH>>(gzEPiyMlhiwikloOqmmyBoKrtIf.NPVYiMLFReocSqajMIQVeYrCvwr);
			}
			return NqMeSMGHiOifPBeHSAqQSmrlSNeh;
		}
	}

	public static event EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> Tracked
	{
		add
		{
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler = WnnhcrFAdYQmURPsaEoCLgdllgR;
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> value2 = (EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref WnnhcrFAdYQmURPsaEoCLgdllgR, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler = WnnhcrFAdYQmURPsaEoCLgdllgR;
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> value2 = (EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref WnnhcrFAdYQmURPsaEoCLgdllgR, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> UnTracked
	{
		add
		{
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler = HAYxyxUVNTdigtgABOafjtjXCgt;
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> value2 = (EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref HAYxyxUVNTdigtgABOafjtjXCgt, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler = HAYxyxUVNTdigtgABOafjtjXCgt;
			EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW> value2 = (EventHandler<wNBHQwBUuFCVlxowxkGLTXqKezW>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref HAYxyxUVNTdigtgABOafjtjXCgt, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static VpaEvRBtdsqRFIXgptXqzCAXuwN()
	{
		AppDomain.CurrentDomain.DomainUnload += fHnnisIXcOeWJyywpFESVQFyjyD;
		AppDomain.CurrentDomain.ProcessExit += fHnnisIXcOeWJyywpFESVQFyjyD;
	}

	private static void fHnnisIXcOeWJyywpFESVQFyjyD(object P_0, EventArgs P_1)
	{
		if (DBqWdhHkzzKerymufWpquDqNZdX.RNgEkrOhIYihxGuwVCGqkwQnsFK)
		{
			string value = XVrBqOdeGBNolezEYaxLUwaFuNKi();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void ZgoWBDAHbCRwBZLqOUZYBBhEaAnF(thUdjkhtsoEtlHZFTxVMIBAaDZoG P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				value = new List<CmJrJrItMoTbvbevKsCGaiZxZUH>();
				ObjectReferences.Add(P_0.NativePointer, value);
			}
			StringBuilder stringBuilder = new StringBuilder();
			StackTrace stackTrace = new StackTrace(3, fNeedFileInfo: true);
			StackFrame[] frames = stackTrace.GetFrames();
			foreach (StackFrame stackFrame in frames)
			{
				if (stackFrame.GetFileLineNumber() != 0)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\t{0}({1},{2}) : {3}", stackFrame.GetFileName(), stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(), stackFrame.GetMethod()).AppendLine();
				}
			}
			value.Add(new CmJrJrItMoTbvbevKsCGaiZxZUH(DateTime.Now, P_0, stringBuilder.ToString()));
			KvYlVVXvFpQEZtFtCrXGrFJKXic(P_0);
		}
	}

	public static List<CmJrJrItMoTbvbevKsCGaiZxZUH> TRyLtPfiiFpGPNucOuzDDNMGpwr(IntPtr P_0)
	{
		lock (ObjectReferences)
		{
			if (ObjectReferences.TryGetValue(P_0, out var value))
			{
				return new List<CmJrJrItMoTbvbevKsCGaiZxZUH>(value);
			}
		}
		return new List<CmJrJrItMoTbvbevKsCGaiZxZUH>();
	}

	public static CmJrJrItMoTbvbevKsCGaiZxZUH TRyLtPfiiFpGPNucOuzDDNMGpwr(thUdjkhtsoEtlHZFTxVMIBAaDZoG P_0)
	{
		lock (ObjectReferences)
		{
			if (ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				foreach (CmJrJrItMoTbvbevKsCGaiZxZUH item in value)
				{
					if (object.ReferenceEquals(item.Object.Target, P_0))
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void ULAoDGPLwVWkhZaoJajHImgySBPo(thUdjkhtsoEtlHZFTxVMIBAaDZoG P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				CmJrJrItMoTbvbevKsCGaiZxZUH cmJrJrItMoTbvbevKsCGaiZxZUH = value[num];
				if (object.ReferenceEquals(cmJrJrItMoTbvbevKsCGaiZxZUH.Object.Target, P_0))
				{
					value.RemoveAt(num);
				}
				else if (!cmJrJrItMoTbvbevKsCGaiZxZUH.IsAlive)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				ObjectReferences.Remove(P_0.NativePointer);
			}
			KxbCyRENjRudwtrMeXfJHckSAgy(P_0);
		}
	}

	public static List<CmJrJrItMoTbvbevKsCGaiZxZUH> QqfDgRiuekGNXUvpDXLBKWleUcGp()
	{
		List<CmJrJrItMoTbvbevKsCGaiZxZUH> list = new List<CmJrJrItMoTbvbevKsCGaiZxZUH>();
		lock (ObjectReferences)
		{
			foreach (List<CmJrJrItMoTbvbevKsCGaiZxZUH> value in ObjectReferences.Values)
			{
				foreach (CmJrJrItMoTbvbevKsCGaiZxZUH item in value)
				{
					if (item.IsAlive)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string XVrBqOdeGBNolezEYaxLUwaFuNKi()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (CmJrJrItMoTbvbevKsCGaiZxZUH item in QqfDgRiuekGNXUvpDXLBKWleUcGp())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.Object.Target;
				if (target != null)
				{
					string name = target.GetType().Name;
					if (!dictionary.TryGetValue(name, out var value))
					{
						dictionary[name] = 0;
					}
					dictionary[name] = value + 1;
				}
			}
			num++;
		}
		List<string> list = new List<string>(dictionary.Keys);
		list.Sort();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Count per Type:");
		foreach (string item2 in list)
		{
			stringBuilder.AppendFormat("{0} : {1}", item2, dictionary[item2]);
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private static void KvYlVVXvFpQEZtFtCrXGrFJKXic(thUdjkhtsoEtlHZFTxVMIBAaDZoG P_0)
	{
		WnnhcrFAdYQmURPsaEoCLgdllgR?.Invoke(null, new wNBHQwBUuFCVlxowxkGLTXqKezW(P_0));
	}

	private static void KxbCyRENjRudwtrMeXfJHckSAgy(thUdjkhtsoEtlHZFTxVMIBAaDZoG P_0)
	{
		HAYxyxUVNTdigtgABOafjtjXCgt?.Invoke(null, new wNBHQwBUuFCVlxowxkGLTXqKezW(P_0));
	}
}
