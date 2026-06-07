using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flotsam/DPad/DPad Decoration Button Properties")]
public class DPadDecorationButtonProperties : DPadButtonProperties
{
	public override void Enable(Image image)
	{
		base.Enable(image);
		GameEventDispatcher.RemoveListener(GameEventType.UnlockableUnlocked, base.UpdateInteractable);
		if (!base.Interactable)
		{
			GameEventDispatcher.AddListener(GameEventType.UnlockableUnlocked, base.UpdateInteractable);
		}
	}

	public override void Disable()
	{
		base.Disable();
		GameEventDispatcher.RemoveListener(GameEventType.UnlockableUnlocked, base.UpdateInteractable);
	}

	protected override bool IsInteractable()
	{
		return GameManager.Settings.BuildableSettings.Decorations.Find((DecorationProperties decoration) => decoration != null && decoration.IsUnlocked()) != null;
	}
}
