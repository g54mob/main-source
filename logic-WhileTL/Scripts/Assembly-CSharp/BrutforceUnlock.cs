using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrutforceUnlock : ActiveComponent
{
	private Button _createProjectButton;

	[SceneBind("ExitButton")]
	private Button exitButton;

	[SceneBind("NextGen")]
	private Button nextGen;

	[SceneBind("NumFind")]
	private Text numFind;

	[SceneBind("CurRes")]
	private Text result;

	private int score;

	private List<GameObject> blocks = new List<GameObject>();

	private int findValue;

	private int maxScore;

	private void OnExitClick()
	{
		ActiveComponent._controller.RedrawUnlockTable();
		base.gameObject.SetActive(value: false);
	}

	private void Generate()
	{
		foreach (GameObject block in blocks)
		{
			block.GetComponentInChildren<Text>().text = Random.Range(0, 10).ToString();
		}
		result.text = score + "/" + maxScore;
	}

	private void OnClickNum(GameObject go)
	{
		if (go.GetComponentInChildren<Text>().text == findValue.ToString())
		{
			score++;
			CheckEnd();
		}
		Generate();
	}

	public void Redraw()
	{
		IniGame();
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		exitButton.onClick.AddListener(OnExitClick);
		nextGen.onClick.AddListener(Generate);
		for (int i = 1; i < 4; i++)
		{
			blocks.Add(base.transform.Find("Block" + i).gameObject);
			GameObject newInst = blocks[blocks.Count - 1];
			blocks[blocks.Count - 1].GetComponent<Button>().onClick.AddListener(delegate
			{
				OnClickNum(newInst);
			});
		}
		IniGame();
	}

	private void IniGame()
	{
		findValue = Random.Range(0, 10);
		score = 0;
		maxScore = 5;
		numFind.text = findValue.ToString();
		Generate();
	}

	private void CheckEnd()
	{
		if (score == maxScore)
		{
			IniGame();
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
	}
}
