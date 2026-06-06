using Cysharp.Threading.Tasks;
using Febucci.TextAnimatorForUnity;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class MailPopup : Popup
{
	[SerializeField]
	private Button decline;

	[SerializeField]
	private Button accept;

	[SerializeField]
	private TMP_Text dateText;

	[SerializeField]
	private GameObject ending;

	[SerializeField]
	private GameObject textBox;

	[SerializeField]
	private LocalizedString localizedText;

	[SerializeField]
	private TypewriterComponent typewriter;

	[SerializeField]
	private Button continueButton;

	[SerializeField]
	private float fadeDuration = 0.5f;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(decline).AddListener(ChooseEndingA).Context(accept)
			.AddListener(ChooseEndingB)
			.Context(continueButton)
			.AddListener(ApplicationController.LoadMainMenu)
			.Context(ending)
			.SetInactive();
	}

	public override void ShowContent()
	{
		base.ShowContent();
		dateText.text = Database.State.Studio.EndingAchieved.ToShortDateString();
	}

	private void ChooseEndingA()
	{
		Database.State.Studio.Ending.Value = EndingState.EndingASelected;
		Database.Save();
		Database.Commands.Achievements.Unlock(Achievement.EndingA);
		HideContent();
	}

	private void ChooseEndingB()
	{
		Database.State.Studio.Ending.Value = EndingState.EndingBSelected;
		Database.Save();
		HideContent();
		ApplicationController.LoadingScreen.ShowLoadingScreen(fadeDuration, SetupEndingBCutscene);
	}

	private void SetupEndingBCutscene()
	{
		ending.SetActive(value: true);
		textBox.SetActive(value: false);
		continueButton.gameObject.SetActive(value: false);
		MonoSingleton<Audio>.Instance.SetAmbient(Audio.Ambient.Beach);
		UniTaskUtility.Delayed(fadeDuration, delegate
		{
			ApplicationController.LoadingScreen.HideLoadingScreen(fadeDuration, AnimateEndingBCutscene);
		}, this.GetCancellationTokenOnDestroy()).Forget();
	}

	private void AnimateEndingBCutscene()
	{
		textBox.SetActive(value: true);
		typewriter.ShowText(localizedText.GetLocalizedString());
		typewriter.onTextShowed.AddListener(delegate
		{
			Database.Commands.Achievements.Unlock(Achievement.EndingB);
			Database.SaveGlobal();
			continueButton.gameObject.SetActive(value: true);
		});
	}
}
