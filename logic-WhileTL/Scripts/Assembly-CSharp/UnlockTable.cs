using System.Collections.Generic;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class UnlockTable : ActiveComponent
{
	[SceneBind("DesicionTreeUnlock", true)]
	private DesicionTreeUnlock desicionUnlock;

	[SceneBind("BrutforceUnlock", true)]
	private BrutforceUnlock brutforceUnlock;

	[SceneBind("GeneticUnlock", true)]
	private GeneticUnlock geneticUnlock;

	[SceneBind("LinearUnlock", true)]
	private LinearRegUnlock linearUnlock;

	[SceneBind("Boxes")]
	private Image boxes;

	private List<GameObject> textList = new List<GameObject>();

	private List<GameObject> unlockList = new List<GameObject>();

	[SceneBind("ExitButton", true)]
	private Button exit;

	[SceneBind("LearningStatus", true)]
	private Text LearningStatus;

	private GameObject namePref;

	private GameObject unlockBtn;

	private GameObject okPref;

	public List<GameObject> underEpoch = new List<GameObject>();

	private GameObject underLayer;

	private void OpenUnlockGame(int i)
	{
		HideAll();
		switch (i)
		{
		case 0:
			desicionUnlock.gameObject.SetActive(value: true);
			break;
		case 2:
			geneticUnlock.gameObject.SetActive(value: true);
			geneticUnlock.IniGame();
			break;
		case 4:
			brutforceUnlock.gameObject.SetActive(value: true);
			brutforceUnlock.Redraw();
			break;
		case 5:
			linearUnlock.gameObject.SetActive(value: true);
			linearUnlock.IniGame();
			break;
		}
	}

	private void ExitClick()
	{
		base.gameObject.SetActive(value: false);
	}

	public void HideAll()
	{
		boxes.gameObject.SetActive(value: false);
		foreach (GameObject text in textList)
		{
			Object.Destroy(text.gameObject);
		}
		foreach (GameObject unlock in unlockList)
		{
			Object.Destroy(unlock.gameObject);
		}
		unlockList = new List<GameObject>();
		textList = new List<GameObject>();
		exit.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		namePref = Resources.Load("Prefabs/AlgoName") as GameObject;
		unlockBtn = Resources.Load("Prefabs/UnlockBTN") as GameObject;
		underLayer = Resources.Load("Prefabs/UnderLayerEpoch") as GameObject;
		okPref = Resources.Load("Prefabs/Ok") as GameObject;
		desicionUnlock.Init();
		brutforceUnlock.Init();
		geneticUnlock.Init();
		linearUnlock.Init();
		desicionUnlock.gameObject.SetActive(value: false);
		brutforceUnlock.gameObject.SetActive(value: false);
		geneticUnlock.gameObject.SetActive(value: false);
		linearUnlock.gameObject.SetActive(value: false);
		exit.onClick.AddListener(ExitClick);
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
		exit.GetComponentInChildren<Text>().text = TextResources.GetString("exit");
	}
}
