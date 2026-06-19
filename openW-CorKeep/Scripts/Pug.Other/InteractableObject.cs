using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
	public float weightMultiplier = 1f;

	public bool useDiscreteOutlineColor;

	public FactionID requiredFactionToInteract;

	public GameObject optionalIcon;

	public OutlineController optionalOutlineController;

	public List<OutlineController> additionalOutlineControllers;

	public List<SpriteObject> spriteObjects;

	private int currentUseAction;

	private bool _updateOutline;

	public List<UnityEvent> onUseActions;

	public List<UnityEvent> onTriggerExitActions;

	public float radius = 0.7f;

	public List<Transform> interactingPoints;

	public bool allowToUseOnlyWhenClaimed;

	public bool ignorePlayerDirection;

	private Color transparent = new Color(0f, 0f, 0f, 0f);

	private void Start()
	{
		if (optionalIcon != null)
		{
			optionalIcon.SetActive(value: false);
		}
		for (int num = interactingPoints.Count - 1; num >= 0; num--)
		{
			if (interactingPoints[num] == null)
			{
				interactingPoints.RemoveAt(num);
			}
		}
		if (interactingPoints.Count == 0)
		{
			interactingPoints.Add(base.transform);
		}
	}

	private void OnDisable()
	{
		if (optionalOutlineController != null)
		{
			optionalOutlineController.showOutline = false;
		}
		foreach (OutlineController additionalOutlineController in additionalOutlineControllers)
		{
			additionalOutlineController.showOutline = false;
		}
		if (spriteObjects == null)
		{
			return;
		}
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			spriteObject.outlineColor = transparent;
		}
	}

	public void UpdateVisuals(bool playerIsAllowedToInteract, bool isSelectedByPlayer)
	{
		bool flag = isSelectedByPlayer && playerIsAllowedToInteract;
		if (optionalIcon != null)
		{
			optionalIcon.SetActive(flag && !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap);
		}
	}

	public void Use()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (currentUseAction < onUseActions.Count)
		{
			onUseActions[currentUseAction]?.Invoke();
			currentUseAction++;
		}
		else
		{
			foreach (UnityEvent onUseAction in onUseActions)
			{
				onUseAction?.Invoke();
			}
			currentUseAction = onUseActions.Count;
		}
		if (currentUseAction >= onUseActions.Count)
		{
			currentUseAction %= onUseActions.Count;
		}
	}

	private void OnValidate()
	{
		if (additionalOutlineControllers != null)
		{
			GameObject gameObject = base.gameObject;
			while (gameObject.transform.parent != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
			}
			foreach (OutlineController additionalOutlineController in additionalOutlineControllers)
			{
				if (additionalOutlineController == null)
				{
					Debug.LogError("Null outlineController", gameObject);
				}
			}
		}
		if (spriteObjects == null)
		{
			return;
		}
		GameObject gameObject2 = base.gameObject;
		while (gameObject2.transform.parent != null)
		{
			gameObject2 = gameObject2.transform.parent.gameObject;
		}
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			if (spriteObject == null)
			{
				Debug.LogError($"Null spriteobject in Interactable on {gameObject2}", gameObject2);
			}
		}
	}
}
