using Localization;
using UnityEngine.UI;

public class MiniGames : ActiveComponent
{
	[SceneBind("FullAlgosList", true)]
	public UnlockTable UnlockTable;

	private void OpenUnlockGame()
	{
		if (!UnlockTable.gameObject.active)
		{
			UnlockTable.gameObject.SetActive(value: true);
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		UnlockTable.Init();
		UnlockTable.gameObject.SetActive(value: false);
		base.gameObject.GetComponent<Button>().onClick.AddListener(OpenUnlockGame);
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
		base.gameObject.GetComponentsInChildren<Text>()[0].text = TextResources.GetString("learnbtn");
	}

	private void Update()
	{
	}
}
