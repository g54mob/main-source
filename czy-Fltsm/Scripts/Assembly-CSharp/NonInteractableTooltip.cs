using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class NonInteractableTooltip : NonInteractableTooltipBase
{
	[SerializeField]
	private Selectable _selectable;

	protected override bool Interactable
	{
		get
		{
			if ((bool)_selectable)
			{
				return _selectable.interactable;
			}
			return false;
		}
	}
}
