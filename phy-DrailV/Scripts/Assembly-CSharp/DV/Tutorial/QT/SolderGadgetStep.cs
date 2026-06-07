using DV.Customization.Gadgets;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class SolderGadgetStep : AQuickTutorialStep
	{
		private readonly GadgetBase gadget;

		public SolderGadgetStep(GadgetBase gadget, AQuickTutorialMessage message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, gadget.transform, attentionOffset, shouldRecheck)
		{
			this.gadget = gadget;
		}

		protected override bool InternalCheck()
		{
			return gadget.IsSoldered;
		}
	}
}
