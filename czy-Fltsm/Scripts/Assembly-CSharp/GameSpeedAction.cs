using UnityEngine;

[CreateAssetMenu(fileName = "Game Speed Action", menuName = "Flotsam/Actions/Game Speed")]
public class GameSpeedAction : SimpleAction
{
	[SerializeField]
	private GameSpeed _gameSpeed;

	public override bool IsInteractable => true;

	public override bool IsSelected => GameSpeedManager.GameSpeed == _gameSpeed;

	public GameSpeed GameSpeed => _gameSpeed;

	public override void Trigger()
	{
		if (_gameSpeed == GameSpeed.Zero)
		{
			GameSpeedManager.ToggleGameSpeedZero();
		}
		else
		{
			GameSpeedManager.SetGameSpeed(_gameSpeed);
		}
	}
}
