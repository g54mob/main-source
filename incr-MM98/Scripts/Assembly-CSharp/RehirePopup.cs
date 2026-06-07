using UnityEngine;
using UnityEngine.UI;

public class RehirePopup : Popup
{
	[SerializeField]
	private Button accept;

	[SerializeField]
	private Button decline;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(accept).AddListener(OnSubmit).Context(decline)
			.AddListener(OnCancel);
	}

	protected override void OnSubmit()
	{
		base.OnSubmit();
		Database.State.Studio.Ending.Value = EndingState.EndingBRehired;
		EventHub.Scene.Publish<RehiredContinue>();
		Database.Commands.IRC.Print(IRCSystem.Rehired);
	}

	protected override void OnCancel()
	{
		base.OnCancel();
		ApplicationController.LoadMainMenu();
	}
}
