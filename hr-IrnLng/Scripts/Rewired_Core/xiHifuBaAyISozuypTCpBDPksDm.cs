using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class xiHifuBaAyISozuypTCpBDPksDm
{
	[Flags]
	public enum qbYJyJMQFMRGgcqtDeeVPZdnpzV
	{
		xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
		ZMYAZXfiENPsSzRTvLkQyXchoDP = 1,
		zwEKtzVRLPfgUvGJKidDuMqeCXxA = 2
	}

	private class PEkJWhCgryMFYunSccIMKbsposZm
	{
		public bool CkrbPyuDqpIvYYOxbClPEfWpSmUp;

		public bool NosALOCJZWSRRlLkYnXjziASvDO;

		public bool PpwlgrBZcJaCPxTAtKpQqFKAPHP;
	}

	private Dictionary<int, PEkJWhCgryMFYunSccIMKbsposZm> AeqMGuTpqWVYmoqAGFYfYEomAbb;

	public qbYJyJMQFMRGgcqtDeeVPZdnpzV pkqJbEtJTdzGtDfmwshOQEOycUSC;

	private bool isValid => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public xiHifuBaAyISozuypTCpBDPksDm()
		: this(qbYJyJMQFMRGgcqtDeeVPZdnpzV.ZMYAZXfiENPsSzRTvLkQyXchoDP | qbYJyJMQFMRGgcqtDeeVPZdnpzV.zwEKtzVRLPfgUvGJKidDuMqeCXxA)
	{
	}

	public xiHifuBaAyISozuypTCpBDPksDm(qbYJyJMQFMRGgcqtDeeVPZdnpzV targets)
	{
		pkqJbEtJTdzGtDfmwshOQEOycUSC = targets;
		AeqMGuTpqWVYmoqAGFYfYEomAbb = new Dictionary<int, PEkJWhCgryMFYunSccIMKbsposZm>();
	}

	public void pdWNtSuAtgJQpXSAYCtoqPXrdLT(Transform P_0, bool P_1)
	{
		if (!isValid)
		{
			return;
		}
		if ((pkqJbEtJTdzGtDfmwshOQEOycUSC & qbYJyJMQFMRGgcqtDeeVPZdnpzV.ZMYAZXfiENPsSzRTvLkQyXchoDP) != qbYJyJMQFMRGgcqtDeeVPZdnpzV.xHdBaRgdNDZThJOvnpmpFtvdLIun)
		{
			if ((pkqJbEtJTdzGtDfmwshOQEOycUSC & qbYJyJMQFMRGgcqtDeeVPZdnpzV.zwEKtzVRLPfgUvGJKidDuMqeCXxA) != qbYJyJMQFMRGgcqtDeeVPZdnpzV.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				XvyRpMzbwNNzAeMCMwxstnvJesq(P_0, P_1, AeqMGuTpqWVYmoqAGFYfYEomAbb);
			}
			else
			{
				pdWNtSuAtgJQpXSAYCtoqPXrdLT(P_0, P_1, AeqMGuTpqWVYmoqAGFYfYEomAbb);
			}
		}
		else if ((pkqJbEtJTdzGtDfmwshOQEOycUSC & qbYJyJMQFMRGgcqtDeeVPZdnpzV.zwEKtzVRLPfgUvGJKidDuMqeCXxA) != qbYJyJMQFMRGgcqtDeeVPZdnpzV.xHdBaRgdNDZThJOvnpmpFtvdLIun)
		{
			HJQnXemvsiqKAFswgfPaYcdLShQ(P_0, P_1, AeqMGuTpqWVYmoqAGFYfYEomAbb);
		}
	}

	public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
	{
		if (isValid)
		{
			AeqMGuTpqWVYmoqAGFYfYEomAbb.Clear();
		}
	}

	private static void XvyRpMzbwNNzAeMCMwxstnvJesq(Transform P_0, bool P_1, Dictionary<int, PEkJWhCgryMFYunSccIMKbsposZm> P_2)
	{
		if (!(P_0 == null))
		{
			pdWNtSuAtgJQpXSAYCtoqPXrdLT(P_0, P_1, P_2);
			HJQnXemvsiqKAFswgfPaYcdLShQ(P_0, P_1, P_2);
		}
	}

	private static void HJQnXemvsiqKAFswgfPaYcdLShQ(Transform P_0, bool P_1, Dictionary<int, PEkJWhCgryMFYunSccIMKbsposZm> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				XvyRpMzbwNNzAeMCMwxstnvJesq(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void pdWNtSuAtgJQpXSAYCtoqPXrdLT(Transform P_0, bool P_1, Dictionary<int, PEkJWhCgryMFYunSccIMKbsposZm> P_2)
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
			value = new PEkJWhCgryMFYunSccIMKbsposZm();
			value.CkrbPyuDqpIvYYOxbClPEfWpSmUp = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.NosALOCJZWSRRlLkYnXjziASvDO && flag == value.CkrbPyuDqpIvYYOxbClPEfWpSmUp) || (!value.NosALOCJZWSRRlLkYnXjziASvDO && flag != value.CkrbPyuDqpIvYYOxbClPEfWpSmUp))
		{
			value.NosALOCJZWSRRlLkYnXjziASvDO = false;
			value.PpwlgrBZcJaCPxTAtKpQqFKAPHP = false;
			value.CkrbPyuDqpIvYYOxbClPEfWpSmUp = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.CkrbPyuDqpIvYYOxbClPEfWpSmUp)
		{
			if (value.CkrbPyuDqpIvYYOxbClPEfWpSmUp == P_1)
			{
				value.NosALOCJZWSRRlLkYnXjziASvDO = false;
				value.PpwlgrBZcJaCPxTAtKpQqFKAPHP = false;
			}
			else
			{
				value.NosALOCJZWSRRlLkYnXjziASvDO = true;
				value.PpwlgrBZcJaCPxTAtKpQqFKAPHP = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
