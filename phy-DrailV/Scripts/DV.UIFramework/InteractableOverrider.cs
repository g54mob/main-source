using DV.Utils;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
[ExecutionOrder(-1)]
public class InteractableOverrider : MonoBehaviour
{
	public enum OutOfGameAction
	{
		None = 0,
		URL = 1,
		File = 2
	}

	[Tooltip("Whether this button will take the player out of the game, and if so, how does it take them out of the game.")]
	public OutOfGameAction outOfGameAction;

	private void Awake()
	{
		if (!CanInteract() && TryGetComponent<Selectable>(out var component))
		{
			component.interactable = false;
		}
	}

	public bool CanInteract()
	{
		OutOfGameAction outOfGameAction = this.outOfGameAction;
		if ((uint)outOfGameAction > 1u && outOfGameAction == OutOfGameAction.File)
		{
			return !SingletonBehaviour<APlatformProvider>.Instance.MustStayInGame;
		}
		return true;
	}
}
