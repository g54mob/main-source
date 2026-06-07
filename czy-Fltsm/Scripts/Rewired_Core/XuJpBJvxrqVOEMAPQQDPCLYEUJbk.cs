using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class XuJpBJvxrqVOEMAPQQDPCLYEUJbk : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class vbTcNQxMfTgkqooJRHUymurRHbwd
	{
		public static readonly vbTcNQxMfTgkqooJRHUymurRHbwd _003C_003E9 = new vbTcNQxMfTgkqooJRHUymurRHbwd();

		public static Func<XuJpBJvxrqVOEMAPQQDPCLYEUJbk> _003C_003E9__30_0;

		internal XuJpBJvxrqVOEMAPQQDPCLYEUJbk zjFfTdaWKsTPmvdElhgPkRdxAkuH()
		{
			return LMxcmGJjdPVYSyQoCbYjlrUbIUQQ();
		}
	}

	private static ObjectPool<XuJpBJvxrqVOEMAPQQDPCLYEUJbk> MeLrgYDhrsexbcXYSVopBkmyXSYsA;

	private Controller sGABbzRbdedWKShxWrOcOJgDVaRS;

	private int hrMWSENCDfRmSLDIXDqFThgcMcny;

	private AxisRange BGdQQrlmVYmxuHrytdhnrkhldcdy;

	private IObjectPool KLNSjuQjOsHHAKTYmeusykYMdJLtA;

	private bool fJpznQRVGqvBskBLlOOElveAQsay;

	int IControllerElementTarget.elementIdentifierId => hrMWSENCDfRmSLDIXDqFThgcMcny;

	AxisRange IControllerElementTarget.axisRange => BGdQQrlmVYmxuHrytdhnrkhldcdy;

	bool IControllerElementTarget.hasTarget => ((IControllerElementTarget)this).element != null;

	ControllerElementType IControllerElementTarget.elementType
	{
		get
		{
			if (((IControllerElementTarget)this).element == null)
			{
				return ControllerElementType.Axis;
			}
			return ((IControllerElementTarget)this).element.type;
		}
	}

	string IControllerElementTarget.descriptiveName
	{
		get
		{
			if (sGABbzRbdedWKShxWrOcOJgDVaRS == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = sGABbzRbdedWKShxWrOcOJgDVaRS.GetElementIdentifierById(hrMWSENCDfRmSLDIXDqFThgcMcny);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = sGABbzRbdedWKShxWrOcOJgDVaRS.GetElementById(hrMWSENCDfRmSLDIXDqFThgcMcny);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, BGdQQrlmVYmxuHrytdhnrkhldcdy);
		}
	}

	Controller IControllerElementTarget.controller => sGABbzRbdedWKShxWrOcOJgDVaRS;

	Controller.Element IControllerElementTarget.element
	{
		get
		{
			if (sGABbzRbdedWKShxWrOcOJgDVaRS == null)
			{
				return null;
			}
			if (sGABbzRbdedWKShxWrOcOJgDVaRS.GetElementIdentifierById(hrMWSENCDfRmSLDIXDqFThgcMcny) == null)
			{
				return null;
			}
			return sGABbzRbdedWKShxWrOcOJgDVaRS.GetElementById(hrMWSENCDfRmSLDIXDqFThgcMcny);
		}
	}

	public ControllerElementIdentifier ZinxqwIhqTYHIwipcqSweIAyBzin
	{
		get
		{
			if (sGABbzRbdedWKShxWrOcOJgDVaRS == null)
			{
				return null;
			}
			return sGABbzRbdedWKShxWrOcOJgDVaRS.GetElementIdentifierById(hrMWSENCDfRmSLDIXDqFThgcMcny);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return KLNSjuQjOsHHAKTYmeusykYMdJLtA;
		}
		set
		{
			KLNSjuQjOsHHAKTYmeusykYMdJLtA = value;
		}
	}

	internal XuJpBJvxrqVOEMAPQQDPCLYEUJbk(Controller P_0, int P_1, AxisRange P_2)
	{
		sGABbzRbdedWKShxWrOcOJgDVaRS = P_0;
		hrMWSENCDfRmSLDIXDqFThgcMcny = P_1;
		BGdQQrlmVYmxuHrytdhnrkhldcdy = P_2;
	}

	internal void FsUaYNMFohDzaFAdCORmvcSKpUpbA(ControllerElementTarget P_0)
	{
		sGABbzRbdedWKShxWrOcOJgDVaRS = P_0.controller;
		hrMWSENCDfRmSLDIXDqFThgcMcny = P_0.elementIdentifierId;
		BGdQQrlmVYmxuHrytdhnrkhldcdy = P_0.axisRange;
	}

	internal void NGdGdLdRKSyqVTPFMNkMMWmrfaEL(IControllerElementTarget P_0)
	{
		sGABbzRbdedWKShxWrOcOJgDVaRS = P_0.controller;
		hrMWSENCDfRmSLDIXDqFThgcMcny = P_0.elementIdentifierId;
		BGdQQrlmVYmxuHrytdhnrkhldcdy = P_0.axisRange;
	}

	internal void bcCMPUuSxwQvwllUjRZAvqDtfzy(XuJpBJvxrqVOEMAPQQDPCLYEUJbk P_0)
	{
		NGdGdLdRKSyqVTPFMNkMMWmrfaEL(P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		sGABbzRbdedWKShxWrOcOJgDVaRS = null;
		hrMWSENCDfRmSLDIXDqFThgcMcny = -1;
		BGdQQrlmVYmxuHrytdhnrkhldcdy = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (KLNSjuQjOsHHAKTYmeusykYMdJLtA != null)
		{
			KLNSjuQjOsHHAKTYmeusykYMdJLtA.Return(this);
		}
	}

	internal static XuJpBJvxrqVOEMAPQQDPCLYEUJbk YNYkkzbZfLBfoXSDZEFyFDZXGiNg()
	{
		if (MeLrgYDhrsexbcXYSVopBkmyXSYsA == null)
		{
			MeLrgYDhrsexbcXYSVopBkmyXSYsA = new ObjectPool<XuJpBJvxrqVOEMAPQQDPCLYEUJbk>(vbTcNQxMfTgkqooJRHUymurRHbwd._003C_003E9.zjFfTdaWKsTPmvdElhgPkRdxAkuH);
		}
		return MeLrgYDhrsexbcXYSVopBkmyXSYsA.Get();
	}

	internal static XuJpBJvxrqVOEMAPQQDPCLYEUJbk vZNASuCGODMiXWePrYVtzaOvfwfs(ControllerElementTarget P_0)
	{
		XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = YNYkkzbZfLBfoXSDZEFyFDZXGiNg();
		xuJpBJvxrqVOEMAPQQDPCLYEUJbk.FsUaYNMFohDzaFAdCORmvcSKpUpbA(P_0);
		return xuJpBJvxrqVOEMAPQQDPCLYEUJbk;
	}

	internal static void gBYtRmxJUHEApkMkUIYRtLusajDpA(XuJpBJvxrqVOEMAPQQDPCLYEUJbk P_0)
	{
		if (P_0 != null && MeLrgYDhrsexbcXYSVopBkmyXSYsA != null)
		{
			MeLrgYDhrsexbcXYSVopBkmyXSYsA.Return(P_0);
		}
	}

	internal static XuJpBJvxrqVOEMAPQQDPCLYEUJbk LMxcmGJjdPVYSyQoCbYjlrUbIUQQ()
	{
		return new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		fzjjttuCvocjGWvYSHiRybiPcEoGA(true);
		GC.SuppressFinalize(this);
	}

	protected void XAEhDUsGYPjMnWokMHoxaZiKmEbHA()
	{
		try
		{
			fzjjttuCvocjGWvYSHiRybiPcEoGA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void fzjjttuCvocjGWvYSHiRybiPcEoGA(bool P_0)
	{
		if (!fJpznQRVGqvBskBLlOOElveAQsay)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			fJpznQRVGqvBskBLlOOElveAQsay = true;
		}
	}
}
