using System;
using UnityEngine.Events;

[Serializable]
public class CoffeeMixerComponent
{
	public Item requiredItem;

	public ItemSocket socket;

	public bool ready;

	public bool isDependingOnOtherReady;

	public int[] dependencyComponentIndex;

	public bool isDependingOnCup;

	public bool canLock;

	public bool lockState;

	public bool isDependingOnInteractionItem;

	public Item interactionItem;

	public UnityEvent OnReady = new UnityEvent();
}
