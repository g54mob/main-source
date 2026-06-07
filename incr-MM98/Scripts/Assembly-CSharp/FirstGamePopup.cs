using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstGamePopup : Popup
{
	[SerializeField]
	private TMP_InputField gameField;

	[SerializeField]
	private Button confirm;

	[SerializeField]
	private Button randomizeName;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(confirm).AddListener(OnSubmit).Context(randomizeName)
			.AddListener(RandomizeGameName, invoke: true)
			.Context(gameField)
			.OnEndEdit(GameNameChanged);
	}

	protected override void OnSubmit()
	{
		if (!string.IsNullOrEmpty(gameField.text))
		{
			base.OnSubmit();
			Database.State.Game.Name.Value = gameField.text;
			Database.State.Game.BoxArt.Value = EnumUtility.GetRandomSkipNone<BoxArt>();
			Database.State.Game.World.Value = EnumUtility.GetRandom<WorldType>();
			EventHub.Scene.Publish<FirstGameReleased>();
			Database.Commands.IRC.Print(IRCSystem.GameReleased);
		}
	}

	private void RandomizeGameName()
	{
		string localizedString;
		do
		{
			localizedString = LocalizationUtility.Random(LocTable.Titles).GetLocalizedString();
		}
		while (gameField.text == localizedString);
		gameField.text = localizedString;
	}

	private void GameNameChanged(string game)
	{
		confirm.interactable = !string.IsNullOrEmpty(game);
	}
}
