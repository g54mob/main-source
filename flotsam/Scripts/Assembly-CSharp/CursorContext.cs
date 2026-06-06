using I2.Loc;
using UnityEngine;

public abstract class CursorContext : ScriptableObject
{
	[SerializeField]
	private LocalizedString _title;

	[SerializeField]
	private LocalizedString _description;

	public LocalizedString Title => _title;

	public LocalizedString Description => _description;

	public virtual bool Interactable => FlotsamInputManager.HasActiveInput(InputFlags.Joystick);

	public abstract Sprite CrosshairIcon { get; }

	public abstract SelectionLink SelectionLink { get; }

	public abstract ActionBase[] Actions { get; }

	public abstract bool TryActivate(CursorManager cursorManager);

	public abstract void Deactivate();

	public abstract void EnableRadialMenu();
}
