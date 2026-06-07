using System.Collections.Generic;
using Aux;
using UnityEngine;
using UnityEngine.UI;

public class AchivementView : ActiveComponent
{
	private Button closeButton;

	private ScrollRect scrollRect;

	private AchivementBlockInstancer achivementBlockPrefab;

	[SceneBind("Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("View")]
	public RectTransform View;

	private Rect viewRect = Rect.zero;

	[SceneBind("Scroll View/Viewport/Content")]
	public RectTransform Content;

	private List<GameObject> achievements = new List<GameObject>();

	private ContentSizeFitter sizeFilter;

	private GridLayoutGroup layoutGroup;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		closeButton = base.gameObject.GetComponentInChildren<Button>();
		scrollRect = base.gameObject.GetComponentInChildren<ScrollRect>();
		achivementBlockPrefab = Resources.Load<AchivementBlockInstancer>("Prefabs/BigAchivementBlock");
		closeButton.onClick.AddListener(OnExit);
		viewRect = Helper.GetWorldRect(View);
		scrollRect.onValueChanged.AddListener(delegate
		{
			UpdateVisibilityOnScreen();
		});
		sizeFilter = Content.GetComponent<ContentSizeFitter>();
		layoutGroup = Content.GetComponent<GridLayoutGroup>();
	}

	public override void Init()
	{
		base.Init();
		ClearContent();
		FillContent();
		base.gameObject.SetActive(value: true);
	}

	private void ClearContent()
	{
		AchivementBlockInstancer[] componentsInChildren = scrollRect.content.GetComponentsInChildren<AchivementBlockInstancer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Object.Destroy(componentsInChildren[i].gameObject);
		}
		achievements.Clear();
	}

	private void SpawnAchivement(string name)
	{
		if (ActiveComponent._staticData.AchivementDatas.FindIndex((AchivementData i) => i.KeyName == name) >= 0)
		{
			AchivementBlockInstancer achivementBlockInstancer = Object.Instantiate(achivementBlockPrefab, scrollRect.content);
			achivementBlockInstancer.Init(Logic.GetAchivementDataByKeyName(name));
			achievements.Add(achivementBlockInstancer.gameObject);
		}
	}

	private void FillContent()
	{
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		foreach (string gainedAchivement in ActiveComponent.Model.globalSaves.gainedAchivements)
		{
			AchivementData achivementDataByKeyName = Logic.GetAchivementDataByKeyName(gainedAchivement);
			if (achivementDataByKeyName != null && !achivementDataByKeyName.Locked && !achivementDataByKeyName.Hidden && !achivementDataByKeyName.KeyName.Contains("PS"))
			{
				SpawnAchivement(gainedAchivement);
			}
		}
		foreach (string gainedAchivement2 in ActiveComponent.Model.globalSaves.gainedAchivements)
		{
			AchivementData achivementDataByKeyName2 = Logic.GetAchivementDataByKeyName(gainedAchivement2);
			if (achivementDataByKeyName2 != null && !achivementDataByKeyName2.Locked && achivementDataByKeyName2.Hidden && !achivementDataByKeyName2.KeyName.Contains("PS"))
			{
				SpawnAchivement(gainedAchivement2);
			}
		}
		foreach (AchivementData achivementData in ActiveComponent._staticData.AchivementDatas)
		{
			if (!achivementData.Locked && !achivementData.Hidden && !ActiveComponent.Model.globalSaves.gainedAchivements.Contains(achivementData.KeyName) && !achivementData.KeyName.Contains("PS"))
			{
				SpawnAchivement(achivementData.KeyName);
			}
		}
		foreach (AchivementData achivementData2 in ActiveComponent._staticData.AchivementDatas)
		{
			if (!achivementData2.Locked && achivementData2.Hidden && !ActiveComponent.Model.globalSaves.gainedAchivements.Contains(achivementData2.KeyName) && !achivementData2.KeyName.Contains("PS"))
			{
				SpawnAchivement(achivementData2.KeyName);
			}
		}
		Vector3 localPosition = scrollRect.content.localPosition;
		localPosition.y = 0f;
		scrollRect.content.localPosition = localPosition;
	}

	private void OnExit()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Program.cursor.SetPosition(ActiveComponent.Program.mainMenu.AchivementsButton.transform.position);
		base.gameObject.SetActive(value: false);
	}

	private void UpdateVisibilityOnScreen()
	{
		sizeFilter.enabled = false;
		layoutGroup.enabled = false;
		foreach (GameObject achievement in achievements)
		{
			bool flag = viewRect.Contains(achievement.transform.position);
			if (flag != achievement.gameObject.activeSelf)
			{
				achievement.gameObject.SetActive(flag);
			}
		}
	}

	private void Update()
	{
		if (base.IsInited && ActiveComponent.Program.joyInput.areaMove)
		{
			Vector3 areaMoveDelta = ActiveComponent.Program.joyInput.areaMoveDelta;
			areaMoveDelta.x = 0f;
			ScrollRect.content.transform.position += Logic.ModifySliderMoveDelta(areaMoveDelta);
			UpdateVisibilityOnScreen();
		}
	}
}
