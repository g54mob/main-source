using UnityEngine;

public class PausedPlayerActions : PlayerActionMode
{
	[SerializeField]
	private PauseMenu _pauseMenu;

	public override bool PlayerCanMove => false;

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}
}
