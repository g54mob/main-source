using OUSystems.Cheats.Commands;
using UnityEngine;

public class DevConsoleActionMode : PlayerActionMode
{
	public override bool PlayerCanMove => false;

	[field: SerializeField]
	public DeveloperConsoleManager DeveloperConsole { get; private set; }

	public override void OnInitiate()
	{
	}

	private void OnDestroy()
	{
	}

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}
}
