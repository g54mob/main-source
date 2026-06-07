using System.Collections;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class StartupBankrupt : ActiveComponent
{
	[SceneBind("Ok")]
	private Button ok;

	[SceneBind("Fail")]
	private Text Fail;

	private bool waitAction;

	public bool denied;

	private int rew;

	private int profit;

	private StartupScheme sch;

	private void OkClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		sch.baseStartup.BaseMoney += profit;
		ActiveComponent.Model.P.startupsStatsString[sch.baseStartup.KeyName].bankrupt = true;
		Logic.UpdateGameSaves();
		waitAction = true;
	}

	public IEnumerator WaitForUserAction()
	{
		while (!waitAction)
		{
			yield return new WaitForEndOfFrame();
		}
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok.onClick.AddListener(OkClick);
	}

	public void Redraw(StartupScheme scheme)
	{
		sch = scheme;
		waitAction = false;
		denied = false;
		Fail.text = Logic.ColorTransform("RED", TextResources.GetString("STARTUPBAKRUPT")).Replace("%KEYNAME", TextResources.GetString(scheme.baseStartup.Texts + "T"));
		Logic.UpdateGameSaves();
	}
}
