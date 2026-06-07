using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class rRNhjRpfbeHXdDjgkCEeGsrflVcU : IDisposable, IControllerElementTarget, IPoolableObject, IPoolableObject_Internal
{
	private static ObjectPool<rRNhjRpfbeHXdDjgkCEeGsrflVcU> COEGZBPxGhpIFgDHuOolzfcmejM;

	private Controller frSJxBhFNALntnzeNKOcTHuHKsS;

	private int MAfbKattduhdBJEmosLzsDAtqCjp;

	private AxisRange iKpdeCcvrahntrCdBHCMvDYKvQZ;

	private IObjectPool ElaSinXhnhGuzFjTAavbzvFadoF;

	private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

	[CompilerGenerated]
	private static Func<rRNhjRpfbeHXdDjgkCEeGsrflVcU> rZGVFRgQMmptVpKQzBtcADhlKAsu;

	public int elementIdentifierId => MAfbKattduhdBJEmosLzsDAtqCjp;

	public AxisRange axisRange => iKpdeCcvrahntrCdBHCMvDYKvQZ;

	public bool hasTarget => element != null;

	public ControllerElementType elementType
	{
		get
		{
			if (element == null)
			{
				return ControllerElementType.Axis;
			}
			return element.type;
		}
	}

	public string descriptiveName
	{
		get
		{
			if (frSJxBhFNALntnzeNKOcTHuHKsS == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = frSJxBhFNALntnzeNKOcTHuHKsS.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = frSJxBhFNALntnzeNKOcTHuHKsS.GetElementById(MAfbKattduhdBJEmosLzsDAtqCjp);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, iKpdeCcvrahntrCdBHCMvDYKvQZ);
		}
	}

	public Controller controller => frSJxBhFNALntnzeNKOcTHuHKsS;

	public Controller.Element element
	{
		get
		{
			if (frSJxBhFNALntnzeNKOcTHuHKsS == null)
			{
				return null;
			}
			ControllerElementIdentifier elementIdentifierById = frSJxBhFNALntnzeNKOcTHuHKsS.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
			if (elementIdentifierById == null)
			{
				return null;
			}
			return frSJxBhFNALntnzeNKOcTHuHKsS.GetElementById(MAfbKattduhdBJEmosLzsDAtqCjp);
		}
	}

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (frSJxBhFNALntnzeNKOcTHuHKsS == null)
			{
				return null;
			}
			return frSJxBhFNALntnzeNKOcTHuHKsS.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return ElaSinXhnhGuzFjTAavbzvFadoF;
		}
		set
		{
			ElaSinXhnhGuzFjTAavbzvFadoF = value;
		}
	}

	internal rRNhjRpfbeHXdDjgkCEeGsrflVcU(Controller controller, int elementIdentifierId, AxisRange axisRange)
	{
		frSJxBhFNALntnzeNKOcTHuHKsS = controller;
		MAfbKattduhdBJEmosLzsDAtqCjp = elementIdentifierId;
		iKpdeCcvrahntrCdBHCMvDYKvQZ = axisRange;
	}

	internal void tlMbXbDwaaKJTudkJIuTPdZmwuo(ControllerElementTarget P_0)
	{
		frSJxBhFNALntnzeNKOcTHuHKsS = P_0.controller;
		MAfbKattduhdBJEmosLzsDAtqCjp = P_0.elementIdentifierId;
		iKpdeCcvrahntrCdBHCMvDYKvQZ = P_0.axisRange;
	}

	internal void tlMbXbDwaaKJTudkJIuTPdZmwuo(IControllerElementTarget P_0)
	{
		frSJxBhFNALntnzeNKOcTHuHKsS = P_0.controller;
		MAfbKattduhdBJEmosLzsDAtqCjp = P_0.elementIdentifierId;
		iKpdeCcvrahntrCdBHCMvDYKvQZ = P_0.axisRange;
	}

	internal void tlMbXbDwaaKJTudkJIuTPdZmwuo(rRNhjRpfbeHXdDjgkCEeGsrflVcU P_0)
	{
		tlMbXbDwaaKJTudkJIuTPdZmwuo((IControllerElementTarget)P_0);
	}

	private void iFyiWAxAjHkmeYvAgGLurMCWihg()
	{
		frSJxBhFNALntnzeNKOcTHuHKsS = null;
		MAfbKattduhdBJEmosLzsDAtqCjp = -1;
		iKpdeCcvrahntrCdBHCMvDYKvQZ = AxisRange.Full;
	}

	void IPoolableObject_Internal.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in iFyiWAxAjHkmeYvAgGLurMCWihg
		this.iFyiWAxAjHkmeYvAgGLurMCWihg();
	}

	private void JbLaJDFMNXqXVdQvPBRtskUIwLsq()
	{
		if (ElaSinXhnhGuzFjTAavbzvFadoF != null)
		{
			ElaSinXhnhGuzFjTAavbzvFadoF.Return(this);
		}
	}

	void IPoolableObject.Return()
	{
		//ILSpy generated this explicit interface implementation from .override directive in JbLaJDFMNXqXVdQvPBRtskUIwLsq
		this.JbLaJDFMNXqXVdQvPBRtskUIwLsq();
	}

	internal static rRNhjRpfbeHXdDjgkCEeGsrflVcU MyFdjCFHrgeFWbyjPuCXTirWPhx()
	{
		if (COEGZBPxGhpIFgDHuOolzfcmejM == null)
		{
			COEGZBPxGhpIFgDHuOolzfcmejM = new ObjectPool<rRNhjRpfbeHXdDjgkCEeGsrflVcU>(() => wDPkgttzlRAAdnlXproyhCFJCGW());
		}
		return COEGZBPxGhpIFgDHuOolzfcmejM.Get();
	}

	internal static rRNhjRpfbeHXdDjgkCEeGsrflVcU MyFdjCFHrgeFWbyjPuCXTirWPhx(ControllerElementTarget P_0)
	{
		rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = MyFdjCFHrgeFWbyjPuCXTirWPhx();
		rRNhjRpfbeHXdDjgkCEeGsrflVcU2.tlMbXbDwaaKJTudkJIuTPdZmwuo(P_0);
		return rRNhjRpfbeHXdDjgkCEeGsrflVcU2;
	}

	internal static void PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU P_0)
	{
		if (P_0 != null && COEGZBPxGhpIFgDHuOolzfcmejM != null)
		{
			COEGZBPxGhpIFgDHuOolzfcmejM.Return(P_0);
		}
	}

	internal static rRNhjRpfbeHXdDjgkCEeGsrflVcU wDPkgttzlRAAdnlXproyhCFJCGW()
	{
		return new rRNhjRpfbeHXdDjgkCEeGsrflVcU(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		hPYtPMXxgzKzMhWWBZyeOBKCxhk(true);
		GC.SuppressFinalize(this);
	}

	~rRNhjRpfbeHXdDjgkCEeGsrflVcU()
	{
		hPYtPMXxgzKzMhWWBZyeOBKCxhk(false);
	}

	private void hPYtPMXxgzKzMhWWBZyeOBKCxhk(bool P_0)
	{
		if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
		}
	}

	[CompilerGenerated]
	private static rRNhjRpfbeHXdDjgkCEeGsrflVcU CzWxTrhLsjFiUbacwKXxioagxMV()
	{
		return wDPkgttzlRAAdnlXproyhCFJCGW();
	}
}
