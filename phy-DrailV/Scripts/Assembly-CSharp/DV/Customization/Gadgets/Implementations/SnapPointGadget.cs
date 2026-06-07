using DV.CabControls;
using DV.Interaction;
using DV.Items.Snapping;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	[RequireComponent(typeof(ItemUseTarget))]
	public class SnapPointGadget : ItemSnapPointBase
	{
		public GadgetBase gadgetBase;

		public Dangler danglerToAffect;

		public float effectStrength = 0.1f;

		public AudioClip soundItemSnapped;

		public AudioClip soundItemRemoved;

		protected override bool DisallowInteractionOnSnap => false;

		protected override void Awake()
		{
			base.Awake();
			base.ItemSnappedChanged += OnItemSnappedChanged;
		}

		private void OnItemSnappedChanged(ItemSnapPointBase snapPoint, ItemBase item, bool snapped, bool forced)
		{
			AudioClip audioClip = (snapped ? soundItemSnapped : soundItemRemoved);
			if (audioClip != null)
			{
				audioClip.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			if (!(danglerToAffect == null))
			{
				danglerToAffect.angularVelocity = Random.insideUnitSphere * effectStrength;
				danglerToAffect.angularVelocity.y = 0f;
			}
		}
	}
}
