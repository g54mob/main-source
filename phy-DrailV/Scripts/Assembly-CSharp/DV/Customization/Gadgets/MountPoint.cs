using DV.Highlighting;
using DV.Interaction;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK.GrabAttachMechanics;

namespace DV.Customization.Gadgets
{
	public class MountPoint : MonoBehaviour
	{
		public enum States : byte
		{
			None = 0,
			Mounted = 1,
			Taped = 2
		}

		[SerializeField]
		private States state;

		[SerializeField]
		private GameObject onBolted;

		[SerializeField]
		private GameObject onTaped;

		[SerializeField]
		private GameObject onJustHole;

		[SerializeField]
		private Renderer highlightRenderer;

		private bool isHighlighted;

		private VRTK_InteractableObject_DV grab;

		private SphereCollider sc;

		public bool IsHighlighted
		{
			get
			{
				return isHighlighted;
			}
			set
			{
				if (isHighlighted != value)
				{
					isHighlighted = value;
					SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(value, highlightRenderer, AGeneralHighlighter.HighlightType.Generic, useObstructedMaterial: false);
				}
			}
		}

		public States State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
				if (onBolted != null)
				{
					onBolted.SetActive(state == States.Mounted);
				}
				if (onTaped != null)
				{
					onTaped.SetActive(state == States.Taped);
				}
				if (onJustHole != null)
				{
					onJustHole.SetActive(state == States.None);
				}
				if (VRManager.IsVREnabled())
				{
					RefreshGrabbable();
				}
			}
		}

		public bool IsOnGlass { get; internal set; }

		public Drillable Drillable { get; internal set; }

		public int Index { get; internal set; }

		private void Start()
		{
			if (Drillable == null)
			{
				Object.Destroy(this);
			}
			else if (VRManager.IsVREnabled())
			{
				sc = base.gameObject.AddComponent<SphereCollider>();
				sc.isTrigger = true;
				sc.radius = 0.025f / base.transform.localScale.x;
				Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
				grab = base.gameObject.AddComponent<VRTK_InteractableObject_DV>();
				rigidbody.isKinematic = true;
				grab.interactionHandPoses = new InteractionHandPoses
				{
					grabPose = HandPose.Grab,
					nearTouchPose = HandPose.PreGrab,
					touchPose = HandPose.PreGrab
				};
				MountHoleAttachMethod grabAttachMechanicScript = base.gameObject.AddComponent<MountHoleAttachMethod>();
				grab.grabAttachMechanicScript = grabAttachMechanicScript;
				RefreshGrabbable();
			}
		}

		private void RefreshGrabbable()
		{
			if ((bool)grab)
			{
				grab.isGrabbable = state == States.Taped;
				sc.enabled = grab.isGrabbable;
			}
		}
	}
}
