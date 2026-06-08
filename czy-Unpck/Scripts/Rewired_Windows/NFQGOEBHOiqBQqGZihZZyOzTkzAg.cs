using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class NFQGOEBHOiqBQqGZihZZyOzTkzAg : global::hUKGPbfBxUOZywKzQaehXkEGSiKp<sgPSpsuggPFbqePUFOQoGiBGplvi, QXXqsQNLwFEZxCDlRmmahPwwxjwS>
{
	private static readonly List<Key> RoaplrkJxiCoEgmrVbysmrPdMEt;

	[CompilerGenerated]
	private List<Key> zbRjJeaAitGVDwuldOBARliwRPcc;

	public List<Key> AllKeys => RoaplrkJxiCoEgmrVbysmrPdMEt;

	public List<Key> PressedKeys
	{
		[CompilerGenerated]
		get
		{
			return zbRjJeaAitGVDwuldOBARliwRPcc;
		}
		[CompilerGenerated]
		private set
		{
			zbRjJeaAitGVDwuldOBARliwRPcc = value;
		}
	}

	static NFQGOEBHOiqBQqGZihZZyOzTkzAg()
	{
		RoaplrkJxiCoEgmrVbysmrPdMEt = new List<Key>(256);
		foreach (object value in Enum.GetValues(typeof(Key)))
		{
			RoaplrkJxiCoEgmrVbysmrPdMEt.Add((Key)value);
		}
	}

	public NFQGOEBHOiqBQqGZihZZyOzTkzAg()
	{
		PressedKeys = new List<Key>(16);
	}

	public bool DDgBxOPEoCrgYsPzwbDzwYxWYsX(Key P_0)
	{
		return PressedKeys.Contains(P_0);
	}

	public void FFYEDujhZPZIRSsDbLkeXQkxTZI(QXXqsQNLwFEZxCDlRmmahPwwxjwS P_0)
	{
		if (P_0.Key != Key.Unknown)
		{
			bool flag = DDgBxOPEoCrgYsPzwbDzwYxWYsX(P_0.Key);
			if (P_0.IsPressed && !flag)
			{
				PressedKeys.Add(P_0.Key);
			}
			else if (P_0.IsReleased && flag)
			{
				PressedKeys.Remove(P_0.Key);
			}
		}
	}

	void global::hUKGPbfBxUOZywKzQaehXkEGSiKp<sgPSpsuggPFbqePUFOQoGiBGplvi, QXXqsQNLwFEZxCDlRmmahPwwxjwS>.FFYEDujhZPZIRSsDbLkeXQkxTZI(QXXqsQNLwFEZxCDlRmmahPwwxjwS P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in FFYEDujhZPZIRSsDbLkeXQkxTZI
		this.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_0);
	}

	public unsafe void wybJdAhTpvWqyyOomZLOcLcMQJK(IntPtr P_0)
	{
		PressedKeys.Clear();
		sgPSpsuggPFbqePUFOQoGiBGplvi* ptr = (sgPSpsuggPFbqePUFOQoGiBGplvi*)(void*)P_0;
		QXXqsQNLwFEZxCDlRmmahPwwxjwS qXXqsQNLwFEZxCDlRmmahPwwxjwS = default(QXXqsQNLwFEZxCDlRmmahPwwxjwS);
		byte* ptr2 = &ptr->LDXLulRoRvytfOUyqaajrJaRejr.FYfADkQKeHUGheRMRjVNLXrRhdY;
		for (int i = 0; i < 256; i++)
		{
			qXXqsQNLwFEZxCDlRmmahPwwxjwS.iheXxAuZSEhTnXIAmmTABgdlXkj = i;
			qXXqsQNLwFEZxCDlRmmahPwwxjwS.CbigNTsukThQPOzMZKybwcHUxLr = ptr2[i];
			if (qXXqsQNLwFEZxCDlRmmahPwwxjwS.IsPressed)
			{
				PressedKeys.Add(qXXqsQNLwFEZxCDlRmmahPwwxjwS.Key);
			}
		}
	}

	void global::hUKGPbfBxUOZywKzQaehXkEGSiKp<sgPSpsuggPFbqePUFOQoGiBGplvi, QXXqsQNLwFEZxCDlRmmahPwwxjwS>.wybJdAhTpvWqyyOomZLOcLcMQJK(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in wybJdAhTpvWqyyOomZLOcLcMQJK
		this.wybJdAhTpvWqyyOomZLOcLcMQJK(P_0);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", new object[1] { XhNUbpKnHPBQaARiBNUpPFpGECJ.KPhjBJDiNhyYzqyhMKgYdCkZDgj(",", PressedKeys) });
	}
}
