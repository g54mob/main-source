using UnityEngine;

[CreateAssetMenu(fileName = "User Key Data", menuName = "TrainSurvival/Key Data")]
public class KeyData : ScriptableObject
{
	public KeyCode InteractKey = KeyCode.E;

	public KeyCode AddFuelKey = KeyCode.F;

	public KeyCode InventoryKey = KeyCode.Tab;

	public KeyCode BuildKey = KeyCode.B;

	public KeyCode SimpleCraftKey = KeyCode.E;

	public KeyCode ExitKey = KeyCode.Escape;

	public KeyCode RadialSelectMenuKey = KeyCode.Q;

	public KeyCode DropKey = KeyCode.G;

	public KeyCode RotateKey = KeyCode.R;

	public KeyCode StoryPanelKey = KeyCode.U;

	public KeyCode PushToTalkKey = KeyCode.V;
}
