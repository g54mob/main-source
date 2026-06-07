using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flotsam/DPad/DPad Button Properties")]
public class DPadButtonProperties : ScriptableObject
{
	[SerializeField]
	private DPadMenuId _menuId;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private Sprite _iconNonInteractable;

	public DPadMenuId MenuId => _menuId;

	public bool Interactable { get; protected set; }

	protected Image Image { get; private set; }

	public virtual void Enable(Image image)
	{
		Image = image;
		UpdateInteractable();
	}

	public virtual void Disable()
	{
		Image.overrideSprite = null;
		Image = null;
	}

	protected void UpdateInteractable(GameEvent gameEvent = null)
	{
		Interactable = (bool)Image && IsInteractable();
		Image.overrideSprite = (Interactable ? _icon : _iconNonInteractable);
	}

	protected virtual bool IsInteractable()
	{
		return true;
	}
}
