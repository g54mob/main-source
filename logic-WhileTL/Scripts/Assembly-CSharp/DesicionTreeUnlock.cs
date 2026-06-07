using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesicionTreeUnlock : ActiveComponent
{
	private Button _createProjectButton;

	[SceneBind("ExitButton")]
	private Button exitButton;

	private int score;

	[SceneBind("Left")]
	private Button leftButton;

	[SceneBind("Right")]
	private Button rightButton;

	private GameObject playPrefab;

	private List<GameObject> blocks = new List<GameObject>();

	private GameObject playObject;

	private int curId;

	private int findValue;

	private void OnExitClick()
	{
		ActiveComponent._controller.RedrawUnlockTable();
		base.gameObject.SetActive(value: false);
	}

	private void ClickLeft()
	{
		curId *= 2;
		SetPos();
	}

	private void ClickRight()
	{
		curId *= 2;
		curId++;
		SetPos();
	}

	protected override void OnInit()
	{
		base.OnInit();
		playPrefab = Resources.Load("Prefabs/PlayPrefab") as GameObject;
		SceneBindContainer.BindObjects(this, base.transform);
		exitButton.onClick.AddListener(OnExitClick);
		for (int i = 1; i < 16; i++)
		{
			blocks.Add(base.transform.Find("Block" + i).gameObject);
		}
		leftButton.onClick.AddListener(ClickLeft);
		rightButton.onClick.AddListener(ClickRight);
		IniGame();
	}

	private void IniGame()
	{
		playObject = Object.Instantiate(playPrefab, base.transform.position, base.transform.rotation);
		playObject.transform.parent = base.gameObject.transform;
		findValue = Random.Range(8, 16);
		playObject.GetComponentInChildren<Text>().text = findValue.ToString();
		curId = 1;
		SetPos();
	}

	private void SetPos()
	{
		playObject.transform.position = blocks[curId - 1].transform.position;
		CheckEnd();
	}

	private void CheckEnd()
	{
		if (curId > 7)
		{
			Debug.Log(curId + " " + findValue);
			if (curId == findValue)
			{
				base.gameObject.SetActive(value: false);
			}
			Object.Destroy(playObject);
			IniGame();
		}
	}

	private void Update()
	{
	}
}
