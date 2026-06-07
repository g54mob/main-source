using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class KFxALCKJXDMoaDpabVBRHjBbQelXc
{
	private class SdQYvvLFyKmWxeydByKmEqpfKePD
	{
		private readonly AList<IControllerTemplate> fElzVVtLLnadnlYnxFMRWiUomRgP;

		private IList zdCGolHAuHXmtnFsIzOQSfTiVPs;

		private IList dZZeHsUquxXHLnpovssMxLaGOvBr;

		public readonly Type JDiOmETEtiDAJdsbLaGGYLzAByrSA;

		public SdQYvvLFyKmWxeydByKmEqpfKePD(Type P_0)
		{
			JDiOmETEtiDAJdsbLaGGYLzAByrSA = P_0;
			fElzVVtLLnadnlYnxFMRWiUomRgP = new AList<IControllerTemplate>();
		}

		public IList<_0001> ODtGyxtsgSDDOfsMYpQtjWDYfkqRA<_0001>() where _0001 : IControllerTemplate
		{
			if (zdCGolHAuHXmtnFsIzOQSfTiVPs == null)
			{
				lhHDyPvlgpuzxrnCyJonmTjrkfIV<_0001>();
			}
			return dZZeHsUquxXHLnpovssMxLaGOvBr as IList<_0001>;
		}

		public void wCAtrUxncLLUnhZiiFhQPJEvrNHx(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				fElzVVtLLnadnlYnxFMRWiUomRgP.Add(P_0);
				if (zdCGolHAuHXmtnFsIzOQSfTiVPs != null)
				{
					zdCGolHAuHXmtnFsIzOQSfTiVPs.Add(P_0);
				}
			}
		}

		public void YSALJxjgeweKaUwqtgZuaWxKLJRgA(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				fElzVVtLLnadnlYnxFMRWiUomRgP.Remove(P_0);
				if (zdCGolHAuHXmtnFsIzOQSfTiVPs != null)
				{
					zdCGolHAuHXmtnFsIzOQSfTiVPs.Remove(P_0);
				}
			}
		}

		private void lhHDyPvlgpuzxrnCyJonmTjrkfIV<_0001>() where _0001 : IControllerTemplate
		{
			zdCGolHAuHXmtnFsIzOQSfTiVPs = new AList<_0001>();
			dZZeHsUquxXHLnpovssMxLaGOvBr = new ReadOnlyCollection<_0001>((AList<_0001>)zdCGolHAuHXmtnFsIzOQSfTiVPs);
			for (int i = 0; i < fElzVVtLLnadnlYnxFMRWiUomRgP._count; i++)
			{
				zdCGolHAuHXmtnFsIzOQSfTiVPs.Add(fElzVVtLLnadnlYnxFMRWiUomRgP._items[i]);
			}
		}
	}

	private readonly AList<SdQYvvLFyKmWxeydByKmEqpfKePD> LzTntamwTTekRuboOWBDVmQELcrN;

	private readonly Type[] rTYDtRSHDnvgUcFZfoGMkUMTkXLt;

	private readonly Type[] qSwesnVKjkIhUdziCpeyiQwwlxrgb;

	private readonly int cZYfsDiyiAfDCorpErmAWsuyvdTi;

	public KFxALCKJXDMoaDpabVBRHjBbQelXc(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		rTYDtRSHDnvgUcFZfoGMkUMTkXLt = P_0;
		qSwesnVKjkIhUdziCpeyiQwwlxrgb = P_1;
		cZYfsDiyiAfDCorpErmAWsuyvdTi = rTYDtRSHDnvgUcFZfoGMkUMTkXLt.Length;
		LzTntamwTTekRuboOWBDVmQELcrN = new AList<SdQYvvLFyKmWxeydByKmEqpfKePD>();
		for (int i = 0; i < cZYfsDiyiAfDCorpErmAWsuyvdTi; i++)
		{
			LzTntamwTTekRuboOWBDVmQELcrN.Add(new SdQYvvLFyKmWxeydByKmEqpfKePD(qSwesnVKjkIhUdziCpeyiQwwlxrgb[i]));
		}
	}

	public void qFpuCelGxwvwkiFIaRKpdJlSeoVD(Controller P_0)
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
			Type type = bonVNPaVMrXOXzOfaievupAwSHWH(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				MtwaEoqaCHhCslBrWJvOOAMvGfiR(type)?.wCAtrUxncLLUnhZiiFhQPJEvrNHx(controllerTemplate);
			}
		}
	}

	public void PvAFaKDgcCoszaENHXDfaERHrlarc(Controller P_0)
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
			Type type = bonVNPaVMrXOXzOfaievupAwSHWH(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				MtwaEoqaCHhCslBrWJvOOAMvGfiR(type)?.YSALJxjgeweKaUwqtgZuaWxKLJRgA(controllerTemplate);
			}
		}
	}

	public IList<_0001> SzWhVgbJYcDgvObEAFprenmWjSAdA<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < LzTntamwTTekRuboOWBDVmQELcrN._count; i++)
		{
			SdQYvvLFyKmWxeydByKmEqpfKePD sdQYvvLFyKmWxeydByKmEqpfKePD = LzTntamwTTekRuboOWBDVmQELcrN._items[i];
			if ((object)sdQYvvLFyKmWxeydByKmEqpfKePD.JDiOmETEtiDAJdsbLaGGYLzAByrSA == typeFromHandle)
			{
				return sdQYvvLFyKmWxeydByKmEqpfKePD.ODtGyxtsgSDDOfsMYpQtjWDYfkqRA<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < qSwesnVKjkIhUdziCpeyiQwwlxrgb.Length; j++)
		{
			text += qSwesnVKjkIhUdziCpeyiQwwlxrgb[j].Name;
			if (j != qSwesnVKjkIhUdziCpeyiQwwlxrgb.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private SdQYvvLFyKmWxeydByKmEqpfKePD MtwaEoqaCHhCslBrWJvOOAMvGfiR(Type P_0)
	{
		for (int i = 0; i < LzTntamwTTekRuboOWBDVmQELcrN._count; i++)
		{
			if ((object)P_0 == LzTntamwTTekRuboOWBDVmQELcrN._items[i].JDiOmETEtiDAJdsbLaGGYLzAByrSA)
			{
				return LzTntamwTTekRuboOWBDVmQELcrN._items[i];
			}
		}
		return null;
	}

	private Type bonVNPaVMrXOXzOfaievupAwSHWH(Type P_0)
	{
		for (int i = 0; i < cZYfsDiyiAfDCorpErmAWsuyvdTi; i++)
		{
			if ((object)rTYDtRSHDnvgUcFZfoGMkUMTkXLt[i] == P_0)
			{
				return qSwesnVKjkIhUdziCpeyiQwwlxrgb[i];
			}
		}
		return null;
	}
}
