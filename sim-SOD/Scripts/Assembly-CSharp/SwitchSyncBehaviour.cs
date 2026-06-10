using System.Collections.Generic;
using UnityEngine;

public class SwitchSyncBehaviour : MonoBehaviour
{
	public enum BasicBehaviour
	{
		none = 0,
		hideWhenOn = 1,
		hideWhenOff = 2
	}

	[Header("State")]
	public InteractablePreset.Switch syncWithState;

	public bool isOn;

	public bool inverted;

	[Header("Basic Behaviour")]
	public BasicBehaviour basicBehaviour;

	public List<GameObject> basicBehaviourObjects;

	[Tooltip("Sync this interactable")]
	public InteractableController syncInteractable;

	public bool onlySyncWhenParentIsOn;

	public virtual void SetOn(bool val)
	{
	}
}
