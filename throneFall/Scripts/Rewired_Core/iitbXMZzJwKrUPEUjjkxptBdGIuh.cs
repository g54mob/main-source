using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class iitbXMZzJwKrUPEUjjkxptBdGIuh
{
	[Flags]
	public enum OIGellesqerDaQoiUJKUMZUmGhbUA
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class eoqQYnNfKdJdBaQNpEcfAhgqqziab
	{
		public bool yclenfvUigiHYbcOZjFcmoTgPlRoA;

		public bool DAzGXJGgHKnOzQThEQhSSTYleolFb;

		public bool tKqelLgRdEcWwVVDtzTfXHsRnIDb;
	}

	private Dictionary<int, eoqQYnNfKdJdBaQNpEcfAhgqqziab> uOcMLKaoQEFfXebsKrahFcasfGIP;

	public OIGellesqerDaQoiUJKUMZUmGhbUA cawSbCrptxrvYYqpGSKzAuIazVxA;

	private bool pRnOVouWJrYQoxyxecAdsjmFBjUe => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public iitbXMZzJwKrUPEUjjkxptBdGIuh()
		: this(OIGellesqerDaQoiUJKUMZUmGhbUA.Self | OIGellesqerDaQoiUJKUMZUmGhbUA.Children)
	{
	}

	public iitbXMZzJwKrUPEUjjkxptBdGIuh(OIGellesqerDaQoiUJKUMZUmGhbUA P_0)
	{
		cawSbCrptxrvYYqpGSKzAuIazVxA = P_0;
		uOcMLKaoQEFfXebsKrahFcasfGIP = new Dictionary<int, eoqQYnNfKdJdBaQNpEcfAhgqqziab>();
	}

	public void HJrgjgTtFYwslhcOyEAAanOTMAqxA(Transform P_0, bool P_1)
	{
		if (!pRnOVouWJrYQoxyxecAdsjmFBjUe)
		{
			return;
		}
		if ((cawSbCrptxrvYYqpGSKzAuIazVxA & OIGellesqerDaQoiUJKUMZUmGhbUA.Self) != OIGellesqerDaQoiUJKUMZUmGhbUA.None)
		{
			if ((cawSbCrptxrvYYqpGSKzAuIazVxA & OIGellesqerDaQoiUJKUMZUmGhbUA.Children) != OIGellesqerDaQoiUJKUMZUmGhbUA.None)
			{
				zGyrhZuDdNbjUUhhENnzMjXFlrin(P_0, P_1, uOcMLKaoQEFfXebsKrahFcasfGIP);
			}
			else
			{
				ROYhnLxffsCQxWolTREdDRZKtEkS(P_0, P_1, uOcMLKaoQEFfXebsKrahFcasfGIP);
			}
		}
		else if ((cawSbCrptxrvYYqpGSKzAuIazVxA & OIGellesqerDaQoiUJKUMZUmGhbUA.Children) != OIGellesqerDaQoiUJKUMZUmGhbUA.None)
		{
			TjhwfxALHqMPkmokiamvlgwStFvx(P_0, P_1, uOcMLKaoQEFfXebsKrahFcasfGIP);
		}
	}

	public void ijrRyVGjiyWDYVJtTsAirrYJaGuy()
	{
		if (pRnOVouWJrYQoxyxecAdsjmFBjUe)
		{
			uOcMLKaoQEFfXebsKrahFcasfGIP.Clear();
		}
	}

	private static void zGyrhZuDdNbjUUhhENnzMjXFlrin(Transform P_0, bool P_1, Dictionary<int, eoqQYnNfKdJdBaQNpEcfAhgqqziab> P_2)
	{
		if (!(P_0 == null))
		{
			ROYhnLxffsCQxWolTREdDRZKtEkS(P_0, P_1, P_2);
			TjhwfxALHqMPkmokiamvlgwStFvx(P_0, P_1, P_2);
		}
	}

	private static void TjhwfxALHqMPkmokiamvlgwStFvx(Transform P_0, bool P_1, Dictionary<int, eoqQYnNfKdJdBaQNpEcfAhgqqziab> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				zGyrhZuDdNbjUUhhENnzMjXFlrin(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void ROYhnLxffsCQxWolTREdDRZKtEkS(Transform P_0, bool P_1, Dictionary<int, eoqQYnNfKdJdBaQNpEcfAhgqqziab> P_2)
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
			value = new eoqQYnNfKdJdBaQNpEcfAhgqqziab();
			value.yclenfvUigiHYbcOZjFcmoTgPlRoA = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.DAzGXJGgHKnOzQThEQhSSTYleolFb && flag == value.yclenfvUigiHYbcOZjFcmoTgPlRoA) || (!value.DAzGXJGgHKnOzQThEQhSSTYleolFb && flag != value.yclenfvUigiHYbcOZjFcmoTgPlRoA))
		{
			value.DAzGXJGgHKnOzQThEQhSSTYleolFb = false;
			value.tKqelLgRdEcWwVVDtzTfXHsRnIDb = false;
			value.yclenfvUigiHYbcOZjFcmoTgPlRoA = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.yclenfvUigiHYbcOZjFcmoTgPlRoA)
		{
			if (value.yclenfvUigiHYbcOZjFcmoTgPlRoA == P_1)
			{
				value.DAzGXJGgHKnOzQThEQhSSTYleolFb = false;
				value.tKqelLgRdEcWwVVDtzTfXHsRnIDb = false;
			}
			else
			{
				value.DAzGXJGgHKnOzQThEQhSSTYleolFb = true;
				value.tKqelLgRdEcWwVVDtzTfXHsRnIDb = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
