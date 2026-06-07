using System.Collections.Generic;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class StartupView : ActiveComponent
{
	[SceneBind("CreateStartupButton")]
	private Button _createStartupButton;

	public CreateProject createProject;

	public const int LIMIT = 4;

	private Vector3 defaultPosition;

	private List<GameObject> startupsButtons = new List<GameObject>();

	private GameObject buttonPrefab;

	private List<StartupItemView> _items = new List<StartupItemView>();

	private void OnCreateClicked()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		buttonPrefab = Resources.Load("Prefabs/BTNStartup") as GameObject;
		defaultPosition = base.gameObject.transform.GetComponent<RectTransform>().position;
		_createStartupButton.onClick.AddListener(OnCreateClicked);
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
	}

	private void RefreshItemObjects()
	{
	}

	private void DeleteStartup(int id)
	{
		Logic.DeleteStartup(id);
		MoveItems();
	}

	public void MoveItems()
	{
	}

	public void Redraw()
	{
		MoveItems();
	}
}
