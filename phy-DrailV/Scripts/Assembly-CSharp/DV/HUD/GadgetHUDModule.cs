using System;
using DV.Customization.Gadgets;
using DV.UI.LocoHUD;
using UnityEngine;

namespace DV.HUD
{
	[RequireComponent(typeof(HUDPanel))]
	public abstract class GadgetHUDModule : MonoBehaviour
	{
		public HUDPanel panel;

		[NonSerialized]
		public GameObject originalPrefab;

		private void Start()
		{
			panel.OpenChanged += delegate(bool on)
			{
				base.enabled = on;
			};
			base.enabled = panel.open;
		}

		public abstract void SetGadget(GadgetBase gadget);

		public abstract string GetName();
	}
	public abstract class GadgetHUDModule<TGadget, TGadgetLOD> : GadgetHUDModule where TGadget : GadgetBase
	{
		protected TGadget gadget;

		protected TGadgetLOD gadgetLOD;

		public override void SetGadget(GadgetBase gadgetBase)
		{
			if (gadgetBase is TGadget val)
			{
				gadget = val;
				gadgetLOD = gadgetBase.GetComponentInChildren<TGadgetLOD>(includeInactive: true);
			}
		}

		public override string GetName()
		{
			return gadget.GadgetItem.Item.InventorySpecs.LocalizedName;
		}
	}
}
