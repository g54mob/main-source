using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class UpJYtIyHkhXTxTerpbIGIMQMINV
{
	private class DREwzODmbSpHhLbGsXZygXSrCTB
	{
		private readonly AList<IControllerTemplate> WGbffMyxRwMRJaYYpbgRACDXbfV;

		private IList mBfOwYEJaDykMAoydsUYkLjpSCF;

		private IList BovbjJkDYztVzmQgcuySHOAvLsRL;

		public readonly Type NKrRavQzBncjnBNomJbbjeXhgCD;

		public DREwzODmbSpHhLbGsXZygXSrCTB(Type type)
		{
			NKrRavQzBncjnBNomJbbjeXhgCD = type;
			WGbffMyxRwMRJaYYpbgRACDXbfV = new AList<IControllerTemplate>();
		}

		public IList<T> PoxNLyEKfLBqvaizvkvHcJnPXMDH<T>() where T : IControllerTemplate
		{
			if (mBfOwYEJaDykMAoydsUYkLjpSCF == null)
			{
				UOTAuMGhcJJqkoPfebtkZZFALlcK<T>();
			}
			return BovbjJkDYztVzmQgcuySHOAvLsRL as IList<T>;
		}

		public void kXumKtfSBwewksMrxulEXBnmjdWG(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				WGbffMyxRwMRJaYYpbgRACDXbfV.Add(P_0);
				if (mBfOwYEJaDykMAoydsUYkLjpSCF != null)
				{
					mBfOwYEJaDykMAoydsUYkLjpSCF.Add(P_0);
				}
			}
		}

		public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				WGbffMyxRwMRJaYYpbgRACDXbfV.Remove(P_0);
				if (mBfOwYEJaDykMAoydsUYkLjpSCF != null)
				{
					mBfOwYEJaDykMAoydsUYkLjpSCF.Remove(P_0);
				}
			}
		}

		private void UOTAuMGhcJJqkoPfebtkZZFALlcK<T>() where T : IControllerTemplate
		{
			mBfOwYEJaDykMAoydsUYkLjpSCF = new AList<T>();
			BovbjJkDYztVzmQgcuySHOAvLsRL = new ReadOnlyCollection<T>((AList<T>)mBfOwYEJaDykMAoydsUYkLjpSCF);
			for (int i = 0; i < WGbffMyxRwMRJaYYpbgRACDXbfV._count; i++)
			{
				mBfOwYEJaDykMAoydsUYkLjpSCF.Add(WGbffMyxRwMRJaYYpbgRACDXbfV._items[i]);
			}
		}
	}

	private readonly AList<DREwzODmbSpHhLbGsXZygXSrCTB> BAqklEmwFGieyQHubUJHhGgOFNc;

	private readonly Type[] kjTZEpHXjhbkquUOMWbVRGBwLpq;

	private readonly Type[] SoocTOSUbeWNPEKncAvNgtTptQj;

	private readonly int uWdeyToitefDbghphqewmurdcDhn;

	public UpJYtIyHkhXTxTerpbIGIMQMINV(Type[] templateTypes, Type[] interfaceTypes)
	{
		if (templateTypes.Length != interfaceTypes.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		kjTZEpHXjhbkquUOMWbVRGBwLpq = templateTypes;
		SoocTOSUbeWNPEKncAvNgtTptQj = interfaceTypes;
		uWdeyToitefDbghphqewmurdcDhn = kjTZEpHXjhbkquUOMWbVRGBwLpq.Length;
		BAqklEmwFGieyQHubUJHhGgOFNc = new AList<DREwzODmbSpHhLbGsXZygXSrCTB>();
		for (int i = 0; i < uWdeyToitefDbghphqewmurdcDhn; i++)
		{
			BAqklEmwFGieyQHubUJHhGgOFNc.Add(new DREwzODmbSpHhLbGsXZygXSrCTB(SoocTOSUbeWNPEKncAvNgtTptQj[i]));
		}
	}

	public void HWIjIWHDiHmuObinjAMvEfORTYeM(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = twdoRWaTzpWflTdaQrLfyUpbRLG(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				MSJNnqKJLFrUDxbFOBkuKkMefvI(type)?.kXumKtfSBwewksMrxulEXBnmjdWG(controllerTemplate);
			}
		}
	}

	public void ugTjZrvDSxPdNxpwLjCweZdZmiz(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = twdoRWaTzpWflTdaQrLfyUpbRLG(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				MSJNnqKJLFrUDxbFOBkuKkMefvI(type)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(controllerTemplate);
			}
		}
	}

	public IList<T> PoxNLyEKfLBqvaizvkvHcJnPXMDH<T>() where T : IControllerTemplate
	{
		Type typeFromHandle = typeof(T);
		for (int i = 0; i < BAqklEmwFGieyQHubUJHhGgOFNc._count; i++)
		{
			DREwzODmbSpHhLbGsXZygXSrCTB dREwzODmbSpHhLbGsXZygXSrCTB = BAqklEmwFGieyQHubUJHhGgOFNc._items[i];
			if (object.ReferenceEquals(dREwzODmbSpHhLbGsXZygXSrCTB.NKrRavQzBncjnBNomJbbjeXhgCD, typeFromHandle))
			{
				return dREwzODmbSpHhLbGsXZygXSrCTB.PoxNLyEKfLBqvaizvkvHcJnPXMDH<T>();
			}
		}
		string text = "";
		for (int j = 0; j < SoocTOSUbeWNPEKncAvNgtTptQj.Length; j++)
		{
			text += SoocTOSUbeWNPEKncAvNgtTptQj[j].Name;
			if (j != SoocTOSUbeWNPEKncAvNgtTptQj.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<T>.EmptyReadOnlyIListT;
	}

	private DREwzODmbSpHhLbGsXZygXSrCTB MSJNnqKJLFrUDxbFOBkuKkMefvI(Type P_0)
	{
		for (int i = 0; i < BAqklEmwFGieyQHubUJHhGgOFNc._count; i++)
		{
			if (object.ReferenceEquals(P_0, BAqklEmwFGieyQHubUJHhGgOFNc._items[i].NKrRavQzBncjnBNomJbbjeXhgCD))
			{
				return BAqklEmwFGieyQHubUJHhGgOFNc._items[i];
			}
		}
		return null;
	}

	private Type twdoRWaTzpWflTdaQrLfyUpbRLG(Type P_0)
	{
		for (int i = 0; i < uWdeyToitefDbghphqewmurdcDhn; i++)
		{
			if (object.ReferenceEquals(kjTZEpHXjhbkquUOMWbVRGBwLpq[i], P_0))
			{
				return SoocTOSUbeWNPEKncAvNgtTptQj[i];
			}
		}
		return null;
	}
}
