using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI;

public class MenuCreditsPage : BaseUIPage
{
	private TextMeshProUGUI _CreditsText;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		string creditsText = Credits.GetCreditsText();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	private void SetCredits()
	{
		string creditsText = Credits.GetCreditsText();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}
}
