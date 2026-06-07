using System.Linq;
using DV.Customization;
using DV.Customization.Gadgets;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class PlaceGadgetStep : AQuickTutorialStep
	{
		public delegate GameObject GadgetProvider();

		public delegate(Transform, Vector3) AttentionPointProvider();

		private readonly AttentionPointProvider attentionProvider;

		private readonly GadgetProvider gadgetProvider;

		private GadgetItem[] gadgetItems;

		public GadgetBase PlacedGadget { get; private set; }

		public PlaceGadgetStep(GameObject[] gadgets, AQuickTutorialMessage message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			gadgetItems = gadgets.Select((GameObject g) => g.GetComponent<GadgetItem>()).ToArray();
		}

		public PlaceGadgetStep(GameObject[] gadgets, AQuickTutorialMessage message, AttentionPointProvider attentionProvider = null, bool shouldRecheck = true)
			: base(message, null, Vector3.zero, shouldRecheck)
		{
			gadgetItems = gadgets.Select((GameObject g) => g.GetComponent<GadgetItem>()).ToArray();
			this.attentionProvider = attentionProvider;
		}

		public PlaceGadgetStep(GadgetProvider gadgetProvider, AQuickTutorialMessage message, AttentionPointProvider attentionProvider = null, bool shouldRecheck = true)
			: base(message, null, Vector3.zero, shouldRecheck)
		{
			this.gadgetProvider = gadgetProvider;
			this.attentionProvider = attentionProvider;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			if (gadgetProvider != null)
			{
				gadgetItems = new GadgetItem[1] { gadgetProvider().GetComponent<GadgetItem>() };
			}
			if (attentionProvider != null)
			{
				(AttentionPoint, AttentionOffset) = attentionProvider();
			}
			PlacedGadget = null;
			GadgetItem[] array = gadgetItems;
			foreach (GadgetItem gadgetItem in array)
			{
				gadgetItem.Gadget.AfterLinked += OnLinked;
				if (gadgetItem.Gadget.IsLinked && PlacedGadget == null)
				{
					PlacedGadget = gadgetItem.Gadget;
				}
			}
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			GadgetItem[] array = gadgetItems;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Gadget.AfterLinked -= OnLinked;
			}
		}

		private void OnLinked(DV.Customization.Customization.CustomizerBase customizer, DV.Customization.Customization customization)
		{
			PlacedGadget = customizer as GadgetBase;
		}

		protected override bool InternalCheck()
		{
			if (PlacedGadget != null)
			{
				return PlacedGadget.IsLinked;
			}
			return false;
		}
	}
}
