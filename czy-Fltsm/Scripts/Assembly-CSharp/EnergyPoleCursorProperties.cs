using PajamaLlama.Utilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Energy Pole")]
public class EnergyPoleCursorProperties : BuildableCursorProperties
{
	[SerializeField]
	[Tooltip("The buildable version of energy poles should not be able to be built anymore, so we need to redirect this cursor properties to the decoration one instead")]
	private DecorationProperties _decorationVersionCursorProperties;

	public override void Activate()
	{
		FinalUpdate.RegisterEndOfFrameOneShot(ActivateDecorationCursorInstead);
	}

	public override void DeactivateImmediately()
	{
	}

	public override void UpdateCursor(CursorManager cursor)
	{
	}

	private void ActivateDecorationCursorInstead()
	{
		_decorationVersionCursorProperties.ActivateCursor(null);
	}
}
