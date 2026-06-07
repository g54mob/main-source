using I2.Loc;
using UnityEngine;

public abstract class SimpleAction : ActionBase
{
	[SerializeField]
	private LocalizedString _label;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private Sprite _interactableSprite;

	[SerializeField]
	private Sprite _nonInteractableSprite;

	public override bool IsSelected => false;

	public override Sprite GetIcon()
	{
		if (IsInteractable)
		{
			return _interactableSprite;
		}
		return _nonInteractableSprite;
	}

	public override LocalizedString GetLabel()
	{
		return _label;
	}

	public override LocalizedString GetDescription()
	{
		return _description;
	}
}
