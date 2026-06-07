using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class WbtTwlDPwwjUlDmYIZawuYHsCcBA
{
	private class ObYUUFDIRnVhTSDaYUuHRVvcauKK
	{
		private readonly AList<IControllerTemplate> bUjTLxlHXQuJZTulwUEuPtTtxelI;

		private IList pDxcWOhQIByMQXCLlXnhTlqCHjAV;

		private IList bfZRJWUwoQIelBXyaazncvsXZSAd;

		public readonly Type HhqozgPpVXBWxQfWIEBjMmkHSniE;

		public ObYUUFDIRnVhTSDaYUuHRVvcauKK(Type P_0)
		{
			HhqozgPpVXBWxQfWIEBjMmkHSniE = P_0;
			bUjTLxlHXQuJZTulwUEuPtTtxelI = new AList<IControllerTemplate>();
		}

		public IList<_0001> CRxsHqlehpCbcSKRBCFIZAuLYTnC<_0001>() where _0001 : IControllerTemplate
		{
			if (pDxcWOhQIByMQXCLlXnhTlqCHjAV == null)
			{
				vZRoOfrcuYuUPNFIvgVAhykiXoJH<_0001>();
			}
			return bfZRJWUwoQIelBXyaazncvsXZSAd as IList<_0001>;
		}

		public void ihMjaylyugPRZXtgjbevQuJirvIG(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				bUjTLxlHXQuJZTulwUEuPtTtxelI.Add(P_0);
				if (pDxcWOhQIByMQXCLlXnhTlqCHjAV != null)
				{
					pDxcWOhQIByMQXCLlXnhTlqCHjAV.Add(P_0);
				}
			}
		}

		public void OkOFqLbwaZXnEckcyHONPBsDrsMh(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				bUjTLxlHXQuJZTulwUEuPtTtxelI.Remove(P_0);
				if (pDxcWOhQIByMQXCLlXnhTlqCHjAV != null)
				{
					pDxcWOhQIByMQXCLlXnhTlqCHjAV.Remove(P_0);
				}
			}
		}

		private void vZRoOfrcuYuUPNFIvgVAhykiXoJH<_0001>() where _0001 : IControllerTemplate
		{
			pDxcWOhQIByMQXCLlXnhTlqCHjAV = new AList<_0001>();
			bfZRJWUwoQIelBXyaazncvsXZSAd = new ReadOnlyCollection<_0001>((AList<_0001>)pDxcWOhQIByMQXCLlXnhTlqCHjAV);
			for (int i = 0; i < bUjTLxlHXQuJZTulwUEuPtTtxelI._count; i++)
			{
				pDxcWOhQIByMQXCLlXnhTlqCHjAV.Add(bUjTLxlHXQuJZTulwUEuPtTtxelI._items[i]);
			}
		}
	}

	private readonly AList<ObYUUFDIRnVhTSDaYUuHRVvcauKK> ZCZhUOyjHirSlWacLVDiIuHXQTiF;

	private readonly Type[] hnAAlzOETYOxgCxHetAxlVVWEpYT;

	private readonly Type[] iLsaqRNQdHeqwVweNNuZLdhpITujA;

	private readonly int cUWkhjagshSgeSCfRavleFrvhVIMA;

	public WbtTwlDPwwjUlDmYIZawuYHsCcBA(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		hnAAlzOETYOxgCxHetAxlVVWEpYT = P_0;
		iLsaqRNQdHeqwVweNNuZLdhpITujA = P_1;
		cUWkhjagshSgeSCfRavleFrvhVIMA = hnAAlzOETYOxgCxHetAxlVVWEpYT.Length;
		ZCZhUOyjHirSlWacLVDiIuHXQTiF = new AList<ObYUUFDIRnVhTSDaYUuHRVvcauKK>();
		for (int i = 0; i < cUWkhjagshSgeSCfRavleFrvhVIMA; i++)
		{
			ZCZhUOyjHirSlWacLVDiIuHXQTiF.Add(new ObYUUFDIRnVhTSDaYUuHRVvcauKK(iLsaqRNQdHeqwVweNNuZLdhpITujA[i]));
		}
	}

	public void sepIsMCbMHhyQkEJtNDWjuEZmYMBA(Controller P_0)
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
			Type type = dWdmPxqFUWIIpFejbRiCvcXfjsXV(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				AryXsMmtMagXUDflLjPbPLVkELbDA(type)?.ihMjaylyugPRZXtgjbevQuJirvIG(controllerTemplate);
			}
		}
	}

	public void XwKsqBusctndNwTHULgAVhQaVOrh(Controller P_0)
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
			Type type = dWdmPxqFUWIIpFejbRiCvcXfjsXV(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				AryXsMmtMagXUDflLjPbPLVkELbDA(type)?.OkOFqLbwaZXnEckcyHONPBsDrsMh(controllerTemplate);
			}
		}
	}

	public IList<_0001> MHQnzUbHMBcCPeeKTudObjnLDeRbA<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < ZCZhUOyjHirSlWacLVDiIuHXQTiF._count; i++)
		{
			ObYUUFDIRnVhTSDaYUuHRVvcauKK obYUUFDIRnVhTSDaYUuHRVvcauKK = ZCZhUOyjHirSlWacLVDiIuHXQTiF._items[i];
			if ((object)obYUUFDIRnVhTSDaYUuHRVvcauKK.HhqozgPpVXBWxQfWIEBjMmkHSniE == typeFromHandle)
			{
				return obYUUFDIRnVhTSDaYUuHRVvcauKK.CRxsHqlehpCbcSKRBCFIZAuLYTnC<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < iLsaqRNQdHeqwVweNNuZLdhpITujA.Length; j++)
		{
			text += iLsaqRNQdHeqwVweNNuZLdhpITujA[j].Name;
			if (j != iLsaqRNQdHeqwVweNNuZLdhpITujA.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private ObYUUFDIRnVhTSDaYUuHRVvcauKK AryXsMmtMagXUDflLjPbPLVkELbDA(Type P_0)
	{
		for (int i = 0; i < ZCZhUOyjHirSlWacLVDiIuHXQTiF._count; i++)
		{
			if ((object)P_0 == ZCZhUOyjHirSlWacLVDiIuHXQTiF._items[i].HhqozgPpVXBWxQfWIEBjMmkHSniE)
			{
				return ZCZhUOyjHirSlWacLVDiIuHXQTiF._items[i];
			}
		}
		return null;
	}

	private Type dWdmPxqFUWIIpFejbRiCvcXfjsXV(Type P_0)
	{
		for (int i = 0; i < cUWkhjagshSgeSCfRavleFrvhVIMA; i++)
		{
			if ((object)hnAAlzOETYOxgCxHetAxlVVWEpYT[i] == P_0)
			{
				return iLsaqRNQdHeqwVweNNuZLdhpITujA[i];
			}
		}
		return null;
	}
}
