using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls.Spec
{
	[DisallowMultipleComponent]
	public abstract class ControlSpec : MonoBehaviour, IInteractableTag
	{
		[Header("Common")]
		public bool disallowShortTriggerLockHold;

		public GameObject[] colliderGameObjects;

		public InteractionHandPoses handPosesOverride;

		public abstract InteractableTag InteractableTag { get; }

		public void Awake()
		{
			SingletonBehaviour<ControlsInstantiatorBase>.Instance.Spawn(this);
		}
	}
}
