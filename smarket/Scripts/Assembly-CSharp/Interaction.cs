using System;
using UnityEngine;

[Serializable]
public abstract class Interaction : MonoBehaviour
{
	public InteractactableType Type { get; protected set; }

	public abstract IInteractable Interactable { get; set; }

	public abstract bool Enable { get; set; }
}
