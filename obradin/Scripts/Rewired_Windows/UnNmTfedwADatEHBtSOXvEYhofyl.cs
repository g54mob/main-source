using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class UnNmTfedwADatEHBtSOXvEYhofyl : global::kmHpGQwmXoEcVBHxRtFhghtsGww<vfSjaXTPQduEZCQIOoFegIyLKpJ, XHWCvzBuKhOsSAQnFMrcvZXaUvMo>
{
	private static readonly List<Key> ENbGkWfLVQfLzzvxQqnilyaNlMFH;

	[CompilerGenerated]
	private List<Key> szKmMNdlCPpywtxpcSvWfCVMHKQ;

	public List<Key> AllKeys
	{
		get
		{
			return ENbGkWfLVQfLzzvxQqnilyaNlMFH;
		}
	}

	public List<Key> PressedKeys
	{
		[CompilerGenerated]
		get
		{
			return szKmMNdlCPpywtxpcSvWfCVMHKQ;
		}
		[CompilerGenerated]
		private set
		{
			szKmMNdlCPpywtxpcSvWfCVMHKQ = value;
		}
	}

	static UnNmTfedwADatEHBtSOXvEYhofyl()
	{
		ENbGkWfLVQfLzzvxQqnilyaNlMFH = new List<Key>(256);
		foreach (object value in Enum.GetValues(typeof(Key)))
		{
			ENbGkWfLVQfLzzvxQqnilyaNlMFH.Add((Key)value);
		}
	}

	public UnNmTfedwADatEHBtSOXvEYhofyl()
	{
		PressedKeys = new List<Key>(16);
	}

	public bool KiloPpiIogLgjvhjnScneWBuQxv(Key P_0)
	{
		return PressedKeys.Contains(P_0);
	}

	public void Update(XHWCvzBuKhOsSAQnFMrcvZXaUvMo P_0)
	{
		if (P_0.Key != Key.Unknown)
		{
			bool flag = KiloPpiIogLgjvhjnScneWBuQxv(P_0.Key);
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

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		PressedKeys.Clear();
		vfSjaXTPQduEZCQIOoFegIyLKpJ* ptr = (vfSjaXTPQduEZCQIOoFegIyLKpJ*)(void*)P_0;
		XHWCvzBuKhOsSAQnFMrcvZXaUvMo xHWCvzBuKhOsSAQnFMrcvZXaUvMo = default(XHWCvzBuKhOsSAQnFMrcvZXaUvMo);
		byte* ptr2 = &ptr->EBQUvGeydRCUGFmivfptrdFvadHJ.KIwRoHtxWtlKYdQvYaAHRJybxco;
		for (int i = 0; i < 256; i++)
		{
			xHWCvzBuKhOsSAQnFMrcvZXaUvMo.xeneszFMgwgsUEUWpBCICXAZtcHB = i;
			xHWCvzBuKhOsSAQnFMrcvZXaUvMo.JdvAUuiZIjqpmuBMKovdOmacUFXr = ptr2[i];
			if (xHWCvzBuKhOsSAQnFMrcvZXaUvMo.IsPressed)
			{
				PressedKeys.Add(xHWCvzBuKhOsSAQnFMrcvZXaUvMo.Key);
			}
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", WISJwItoxlmpVJIyUeIxBJGahMp.TkivIiwenPObKhVpNcJOpmJrSiH(",", PressedKeys));
	}
}
