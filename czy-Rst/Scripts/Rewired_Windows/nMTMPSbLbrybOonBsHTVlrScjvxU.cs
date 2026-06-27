using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class nMTMPSbLbrybOonBsHTVlrScjvxU
{
	[CompilerGenerated]
	private DateTime GdLDzKBfWlpFHUJAfpSidbOGUWMdc;

	[CompilerGenerated]
	private WeakReference zJhPletrFlQKyjHLgSLVwcayvnMl;

	[CompilerGenerated]
	private string oCCofZBdnFoVBMMykZUsXoyDSnXc;

	public DateTime iIBFoMFKWkJluvvlYglJzepfFvue
	{
		[CompilerGenerated]
		get
		{
			return GdLDzKBfWlpFHUJAfpSidbOGUWMdc;
		}
		[CompilerGenerated]
		private set
		{
			GdLDzKBfWlpFHUJAfpSidbOGUWMdc = gdLDzKBfWlpFHUJAfpSidbOGUWMdc;
		}
	}

	public WeakReference hOEUNknQNHQbmfyaZuLymDMGhPqT
	{
		[CompilerGenerated]
		get
		{
			return zJhPletrFlQKyjHLgSLVwcayvnMl;
		}
		[CompilerGenerated]
		private set
		{
			zJhPletrFlQKyjHLgSLVwcayvnMl = weakReference;
		}
	}

	public string zaMDDsKJhfYBqPVCfAXRrHFmfhKNA
	{
		[CompilerGenerated]
		get
		{
			return oCCofZBdnFoVBMMykZUsXoyDSnXc;
		}
		[CompilerGenerated]
		private set
		{
			oCCofZBdnFoVBMMykZUsXoyDSnXc = text;
		}
	}

	public bool wracHqcBSjmPKayrapovTNBRUlQyA => hOEUNknQNHQbmfyaZuLymDMGhPqT.IsAlive;

	public nMTMPSbLbrybOonBsHTVlrScjvxU(DateTime P_0, MVODoHWtmlXSEWwatoJRHSNlznOK P_1, string P_2)
	{
		iIBFoMFKWkJluvvlYglJzepfFvue = P_0;
		hOEUNknQNHQbmfyaZuLymDMGhPqT = new WeakReference(P_1, trackResurrection: true);
		zaMDDsKJhfYBqPVCfAXRrHFmfhKNA = P_2;
	}

	public virtual string SPiRdMfmSICUUZQvbkFFxdKgenkV()
	{
		if (!(hOEUNknQNHQbmfyaZuLymDMGhPqT.Target is MVODoHWtmlXSEWwatoJRHSNlznOK mVODoHWtmlXSEWwatoJRHSNlznOK))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", mVODoHWtmlXSEWwatoJRHSNlznOK.wkJiNziQVZeKUDzpAUZiJMbAGjgE.ToInt64(), mVODoHWtmlXSEWwatoJRHSNlznOK.GetType().FullName, iIBFoMFKWkJluvvlYglJzepfFvue, zaMDDsKJhfYBqPVCfAXRrHFmfhKNA).AppendLine();
		return stringBuilder.ToString();
	}
}
