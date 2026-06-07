using UnityEngine;

public class CursorController : MonoBehaviour
{
	public enum ECursor
	{
		Default = 0,
		Axe = 1,
		Pickaxe = 2,
		Error = 3,
		Config = 4,
		Highlight = 5,
		Sell = 6,
		StraightModifier = 7
	}

	[SerializeField]
	private bool forceSoftware;

	[Header("Cursor")]
	[SerializeField]
	private Texture2D cursorDefault;

	[SerializeField]
	private Texture2D cursorHighlight;

	[SerializeField]
	private Texture2D cursorAxe;

	[SerializeField]
	private Texture2D cursorPickaxe;

	[SerializeField]
	private Texture2D cursorError;

	[SerializeField]
	private Texture2D cursorConfig;

	[SerializeField]
	private Texture2D cursorSell;

	[SerializeField]
	private Texture2D cursorStraightModifier;

	public void SetCursor(ECursor cursor)
	{
		Texture2D texture = null;
		switch (cursor)
		{
		case ECursor.Default:
			texture = cursorDefault;
			break;
		case ECursor.Highlight:
			texture = cursorHighlight;
			break;
		case ECursor.Axe:
			texture = cursorAxe;
			break;
		case ECursor.Pickaxe:
			texture = cursorPickaxe;
			break;
		case ECursor.Error:
			texture = cursorError;
			break;
		case ECursor.Config:
			texture = cursorConfig;
			break;
		case ECursor.Sell:
			texture = cursorSell;
			break;
		case ECursor.StraightModifier:
			texture = cursorStraightModifier;
			break;
		}
		Cursor.SetCursor(texture, Vector2.zero, forceSoftware ? CursorMode.ForceSoftware : CursorMode.Auto);
	}
}
