using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class bizhSGSkbYKHLUAwUjJldBHmyZwq
{
	[Flags]
	public enum ZcAMrOtAeESDjrKvrejMZGGnknjd
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class zlurXpCtqPwMQpFnYBAbdokxTuqN
	{
		public bool OLHrHCpGRFlifzldYRcPNRSbFaCP;

		public bool PbUHosKJkgEJooUDbfinUHsUtzGhA;

		public bool LCQeQHWJZlTPqUZWYiaYSLAEjLFt;
	}

	private Dictionary<int, zlurXpCtqPwMQpFnYBAbdokxTuqN> QRGCiWMcNwXLPJwChSTbafiexzvQ;

	public ZcAMrOtAeESDjrKvrejMZGGnknjd bkAZFmkmgBFNWubkZAaSekGmMASM;

	private bool MnJpMQFiroAQrejONWrLIhRQIMXzA => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public bizhSGSkbYKHLUAwUjJldBHmyZwq()
		: this(ZcAMrOtAeESDjrKvrejMZGGnknjd.Self | ZcAMrOtAeESDjrKvrejMZGGnknjd.Children)
	{
	}

	public bizhSGSkbYKHLUAwUjJldBHmyZwq(ZcAMrOtAeESDjrKvrejMZGGnknjd P_0)
	{
		bkAZFmkmgBFNWubkZAaSekGmMASM = P_0;
		QRGCiWMcNwXLPJwChSTbafiexzvQ = new Dictionary<int, zlurXpCtqPwMQpFnYBAbdokxTuqN>();
	}

	public void nmwDzgxVACcOAJkYbADwUYDbZzFK(Transform P_0, bool P_1)
	{
		if (!MnJpMQFiroAQrejONWrLIhRQIMXzA)
		{
			return;
		}
		if ((bkAZFmkmgBFNWubkZAaSekGmMASM & ZcAMrOtAeESDjrKvrejMZGGnknjd.Self) != ZcAMrOtAeESDjrKvrejMZGGnknjd.None)
		{
			if ((bkAZFmkmgBFNWubkZAaSekGmMASM & ZcAMrOtAeESDjrKvrejMZGGnknjd.Children) != ZcAMrOtAeESDjrKvrejMZGGnknjd.None)
			{
				FuWLnyyFLlgmlNvAbcoaDVfDnceu(P_0, P_1, QRGCiWMcNwXLPJwChSTbafiexzvQ);
			}
			else
			{
				nmwDzgxVACcOAJkYbADwUYDbZzFK(P_0, P_1, QRGCiWMcNwXLPJwChSTbafiexzvQ);
			}
		}
		else if ((bkAZFmkmgBFNWubkZAaSekGmMASM & ZcAMrOtAeESDjrKvrejMZGGnknjd.Children) != ZcAMrOtAeESDjrKvrejMZGGnknjd.None)
		{
			LmeCbSxnJMbXzqGaPoCguOjZYxCV(P_0, P_1, QRGCiWMcNwXLPJwChSTbafiexzvQ);
		}
	}

	public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
	{
		if (MnJpMQFiroAQrejONWrLIhRQIMXzA)
		{
			QRGCiWMcNwXLPJwChSTbafiexzvQ.Clear();
		}
	}

	private static void FuWLnyyFLlgmlNvAbcoaDVfDnceu(Transform P_0, bool P_1, Dictionary<int, zlurXpCtqPwMQpFnYBAbdokxTuqN> P_2)
	{
		if (!(P_0 == null))
		{
			nmwDzgxVACcOAJkYbADwUYDbZzFK(P_0, P_1, P_2);
			LmeCbSxnJMbXzqGaPoCguOjZYxCV(P_0, P_1, P_2);
		}
	}

	private static void LmeCbSxnJMbXzqGaPoCguOjZYxCV(Transform P_0, bool P_1, Dictionary<int, zlurXpCtqPwMQpFnYBAbdokxTuqN> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				FuWLnyyFLlgmlNvAbcoaDVfDnceu(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void nmwDzgxVACcOAJkYbADwUYDbZzFK(Transform P_0, bool P_1, Dictionary<int, zlurXpCtqPwMQpFnYBAbdokxTuqN> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		Graphic component = P_0.GetComponent<Graphic>();
		if (component == null)
		{
			return;
		}
		bool flag = UnityTools.externalTools.UnityUI_Graphic_GetRaycastTarget(component);
		int instanceID = component.GetInstanceID();
		if (!P_2.TryGetValue(instanceID, out var value))
		{
			if (!flag)
			{
				return;
			}
			value = new zlurXpCtqPwMQpFnYBAbdokxTuqN();
			value.OLHrHCpGRFlifzldYRcPNRSbFaCP = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.PbUHosKJkgEJooUDbfinUHsUtzGhA && flag == value.OLHrHCpGRFlifzldYRcPNRSbFaCP) || (!value.PbUHosKJkgEJooUDbfinUHsUtzGhA && flag != value.OLHrHCpGRFlifzldYRcPNRSbFaCP))
		{
			value.PbUHosKJkgEJooUDbfinUHsUtzGhA = false;
			value.LCQeQHWJZlTPqUZWYiaYSLAEjLFt = false;
			value.OLHrHCpGRFlifzldYRcPNRSbFaCP = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.OLHrHCpGRFlifzldYRcPNRSbFaCP)
		{
			if (value.OLHrHCpGRFlifzldYRcPNRSbFaCP == P_1)
			{
				value.PbUHosKJkgEJooUDbfinUHsUtzGhA = false;
				value.LCQeQHWJZlTPqUZWYiaYSLAEjLFt = false;
			}
			else
			{
				value.PbUHosKJkgEJooUDbfinUHsUtzGhA = true;
				value.LCQeQHWJZlTPqUZWYiaYSLAEjLFt = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
