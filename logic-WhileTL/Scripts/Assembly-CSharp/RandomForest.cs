using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class RandomForest : BaseBlock
{
	private Socket socketIn;

	private Socket socketTop;

	private Socket socketMid;

	private Socket socketBot;

	[SceneBind("ParamTop")]
	public Dropdown top;

	[SceneBind("ParamBot")]
	public Dropdown bot;

	[SceneBind("ParamMid")]
	public Dropdown mid;

	private List<Dropdown.OptionData> optionsTop = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsBot = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsMid = new List<Dropdown.OptionData>();

	private MultiDictionary<int, Socket> sortedRandomDict = new MultiDictionary<int, Socket>();

	private List<int> sortedRandomList = new List<int>();

	private List<Socket> socketsBuf;

	public Sprite CircleImage;

	public Sprite SquareImage;

	public Sprite TriangleImage;

	private bool topOpen;

	private bool botOpen;

	private bool midOpen;

	private bool topClosing;

	private bool botClosing;

	private bool midClosing;

	private int normalTop;

	private int normalBot;

	private int normalMid;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		Element element = socketIn.queue[0];
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (top.value < 3)
		{
			if (top.value == element.ColorId)
			{
				flag = true;
			}
		}
		else if (top.value % 3 == element.ShapeId)
		{
			flag = true;
		}
		if (mid.value < 3)
		{
			if (mid.value == element.ColorId)
			{
				flag3 = true;
			}
		}
		else if (mid.value % 3 == element.ShapeId)
		{
			flag3 = true;
		}
		if (bot.value < 3)
		{
			if (bot.value == element.ColorId)
			{
				flag2 = true;
			}
		}
		else if (bot.value % 3 == element.ShapeId)
		{
			flag2 = true;
		}
		if (flag && socketTop.isFull())
		{
			return false;
		}
		if (flag2 && socketBot.isFull())
		{
			return false;
		}
		if (flag3 && socketMid.isFull())
		{
			return false;
		}
		if (((!flag3 && !flag2 && !flag) || !element.revealed) && (socketTop.isFull() || socketMid.isFull() || socketBot.isFull()))
		{
			return false;
		}
		return true;
	}

	protected override void Active()
	{
		if (!TryActive())
		{
			return;
		}
		Element element = socketIn.GetElement();
		if (element == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (top.value < 3)
		{
			if (top.value == element.ColorId)
			{
				flag = true;
			}
		}
		else if (top.value % 3 == element.ShapeId)
		{
			flag = true;
		}
		if (mid.value < 3)
		{
			if (mid.value == element.ColorId)
			{
				flag3 = true;
			}
		}
		else if (mid.value % 3 == element.ShapeId)
		{
			flag3 = true;
		}
		if (bot.value < 3)
		{
			if (bot.value == element.ColorId)
			{
				flag2 = true;
			}
		}
		else if (bot.value % 3 == element.ShapeId)
		{
			flag2 = true;
		}
		sortedRandomList.Clear();
		sortedRandomDict.Clear();
		if (flag)
		{
			sortedRandomDict.Add(top.value, socketTop);
			sortedRandomList.Add(top.value);
		}
		if (flag3)
		{
			sortedRandomDict.Add(mid.value, socketMid);
			sortedRandomList.Add(mid.value);
		}
		if (flag2)
		{
			sortedRandomDict.Add(bot.value, socketBot);
			sortedRandomList.Add(bot.value);
		}
		if (sortedRandomList.Count > 0 && element.revealed)
		{
			sortedRandomList.Sort();
			HashSet<Socket> hashSet = sortedRandomDict[sortedRandomList[BlockRandom.Next(sortedRandomList.Count)]];
			List<Socket> list = new List<Socket>();
			foreach (Socket item in hashSet)
			{
				list.Add(item);
			}
			list[BlockRandom.Next(list.Count)].SetElement(element);
		}
		else
		{
			if (socketsBuf == null)
			{
				socketsBuf = new List<Socket>();
				socketsBuf.Add(socketTop);
				socketsBuf.Add(socketMid);
				socketsBuf.Add(socketBot);
			}
			socketsBuf[BlockRandom.Next(3)].SetElement(element);
		}
	}

	public override void Init()
	{
		if (!base.IsInited)
		{
			base.Init();
			socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
			socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
			socketBot = base.transform.Find("SocketBot").GetComponent<Socket>();
			socketMid = base.transform.Find("SocketMid").GetComponent<Socket>();
			keyName = "RANDOMFOREST";
			normalTop = top.transform.childCount;
			normalBot = bot.transform.childCount;
			normalMid = mid.transform.childCount;
		}
		if (top.transform.childCount != normalTop)
		{
			Object.Destroy(top.transform.GetChild(top.transform.childCount - 1).gameObject);
		}
		if (bot.transform.childCount != normalBot)
		{
			Object.Destroy(bot.transform.GetChild(bot.transform.childCount - 1).gameObject);
		}
		if (mid.transform.childCount != normalMid)
		{
			Object.Destroy(mid.transform.GetChild(mid.transform.childCount - 1).gameObject);
		}
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		optionsBot.Clear();
		optionsMid.Clear();
		optionsTop.Clear();
		for (int i = 0; i < ActiveComponent._staticData.LogicsColor.Count - 1; i++)
		{
			optionsTop.Add(new Dropdown.OptionData(TextResources.GetString(ActiveComponent._staticData.LogicsColor[i].Name)));
			optionsBot.Add(new Dropdown.OptionData(TextResources.GetString(ActiveComponent._staticData.LogicsColor[i].Name)));
			optionsMid.Add(new Dropdown.OptionData(TextResources.GetString(ActiveComponent._staticData.LogicsColor[i].Name)));
		}
		for (int j = 0; j < ActiveComponent._staticData.LogicsShape.Count - 1; j++)
		{
			optionsTop.Add(new Dropdown.OptionData(""));
			optionsBot.Add(new Dropdown.OptionData(""));
			optionsMid.Add(new Dropdown.OptionData(""));
		}
		top.onValueChanged.RemoveAllListeners();
		bot.onValueChanged.RemoveAllListeners();
		mid.onValueChanged.RemoveAllListeners();
		top.ClearOptions();
		bot.ClearOptions();
		mid.ClearOptions();
		top.AddOptions(optionsTop);
		bot.AddOptions(optionsBot);
		mid.AddOptions(optionsMid);
		hasDropdown = true;
		socketsIn[2] = socketIn;
		socketsOut[1] = socketTop;
		socketsOut[3] = socketBot;
		socketsOut[2] = socketMid;
		for (int k = 0; k < BaseBlock.maxSockets; k++)
		{
			if (socketsIn[k] != null)
			{
				socketsIn[k].num = k;
			}
			if (socketsOut[k] != null)
			{
				socketsOut[k].num = k;
			}
		}
		top.enabled = true;
		bot.enabled = true;
		mid.enabled = true;
		top.value = 0;
		mid.value = 2;
		bot.value = 5;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			top.value = sh.outConditionsColor[1];
			bot.value = sh.outConditionsColor[3];
			mid.value = sh.outConditionsColor[2];
		}
		AddRecordToEvent(top.onValueChanged);
		AddRecordToEvent(mid.onValueChanged);
		AddRecordToEvent(bot.onValueChanged);
		ListenCloseDropdown(top, normalTop);
		ListenCloseDropdown(bot, normalBot);
		ListenCloseDropdown(mid, normalMid);
		top.onValueChanged.AddListener(delegate
		{
			ChangeColors();
			ChangeSprites();
		});
		bot.onValueChanged.AddListener(delegate
		{
			ChangeColors();
			ChangeSprites();
		});
		mid.onValueChanged.AddListener(delegate
		{
			ChangeColors();
			ChangeSprites();
		});
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
		ChangeColors();
		ChangeSprites();
	}

	public void ChangeColors()
	{
		Text[] componentsInChildren = top.GetComponentsInChildren<Text>();
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].color = Logic.GetColor(i - 1);
		}
		Text[] componentsInChildren2 = bot.GetComponentsInChildren<Text>();
		for (int j = 1; j < componentsInChildren2.Length; j++)
		{
			componentsInChildren2[j].color = Logic.GetColor(j - 1);
		}
		Text[] componentsInChildren3 = mid.GetComponentsInChildren<Text>();
		for (int k = 1; k < componentsInChildren3.Length; k++)
		{
			componentsInChildren3[k].color = Logic.GetColor(k - 1);
		}
		top.captionText.color = Logic.GetColor(top.value);
		bot.captionText.color = Logic.GetColor(bot.value);
		mid.captionText.color = Logic.GetColor(mid.value);
		Transform[] componentsInChildren4 = top.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren4)
		{
			if (transform.gameObject.GetComponent<Image>() != null && transform.gameObject.tag == "Checkmark")
			{
				transform.gameObject.GetComponent<Image>().color = Logic.GetColor(Mathf.Min(top.value, 3));
			}
		}
		componentsInChildren4 = bot.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform2 in componentsInChildren4)
		{
			if (transform2.gameObject.GetComponent<Image>() != null && transform2.gameObject.tag == "Checkmark")
			{
				transform2.gameObject.GetComponent<Image>().color = Logic.GetColor(Mathf.Min(bot.value, 3));
			}
		}
		componentsInChildren4 = mid.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform3 in componentsInChildren4)
		{
			if (transform3.gameObject.GetComponent<Image>() != null && transform3.gameObject.tag == "Checkmark")
			{
				transform3.gameObject.GetComponent<Image>().color = Logic.GetColor(Mathf.Min(mid.value, 3));
			}
		}
	}

	public void ChangeSprites()
	{
		Toggle[] componentsInChildren = base.gameObject.GetComponentsInChildren<Toggle>();
		if (componentsInChildren.Length != 0)
		{
			Transform[] componentsInChildren2 = componentsInChildren[3].gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren2)
			{
				if (transform.tag == "Second")
				{
					transform.gameObject.GetComponent<Image>().sprite = CircleImage;
				}
				else if (transform.tag == "First" || transform.tag == "Third")
				{
					transform.gameObject.SetActive(value: false);
				}
			}
			componentsInChildren2 = componentsInChildren[4].gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform2 in componentsInChildren2)
			{
				if (transform2.tag == "Second")
				{
					transform2.gameObject.GetComponent<Image>().sprite = SquareImage;
				}
				else if (transform2.tag == "First" || transform2.tag == "Third")
				{
					transform2.gameObject.SetActive(value: false);
				}
			}
			componentsInChildren2 = componentsInChildren[5].gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform3 in componentsInChildren2)
			{
				if (transform3.tag == "Second")
				{
					transform3.gameObject.GetComponent<Image>().sprite = TriangleImage;
				}
				else if (transform3.tag == "First" || transform3.tag == "Third")
				{
					transform3.gameObject.SetActive(value: false);
				}
			}
			for (int j = 0; j < 3; j++)
			{
				componentsInChildren2 = componentsInChildren[j].gameObject.GetComponentsInChildren<Transform>();
				foreach (Transform transform4 in componentsInChildren2)
				{
					if (transform4.tag == "Second")
					{
						transform4.gameObject.SetActive(value: false);
					}
					else if (transform4.tag == "First" || transform4.tag == "Third")
					{
						transform4.gameObject.SetActive(value: false);
					}
				}
			}
		}
		GameObject gameObject = bot.gameObject.transform.Find("First").gameObject;
		GameObject gameObject2 = bot.gameObject.transform.Find("Second").gameObject;
		GameObject gameObject3 = bot.gameObject.transform.Find("Third").gameObject;
		if (bot.value >= 3)
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			gameObject2.gameObject.SetActive(value: true);
			switch (bot.value % 3)
			{
			case 0:
				gameObject2.GetComponent<Image>().sprite = CircleImage;
				break;
			case 1:
				gameObject2.GetComponent<Image>().sprite = SquareImage;
				break;
			case 2:
				gameObject2.GetComponent<Image>().sprite = TriangleImage;
				break;
			}
		}
		else
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			gameObject2.gameObject.SetActive(value: false);
		}
		gameObject = top.gameObject.transform.Find("First").gameObject;
		gameObject2 = top.gameObject.transform.Find("Second").gameObject;
		gameObject3 = top.gameObject.transform.Find("Third").gameObject;
		if (top.value >= 3)
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			gameObject2.gameObject.SetActive(value: true);
			switch (top.value % 3)
			{
			case 0:
				gameObject2.GetComponent<Image>().sprite = CircleImage;
				break;
			case 1:
				gameObject2.GetComponent<Image>().sprite = SquareImage;
				break;
			case 2:
				gameObject2.GetComponent<Image>().sprite = TriangleImage;
				break;
			}
		}
		else
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			gameObject2.gameObject.SetActive(value: false);
		}
		gameObject = mid.gameObject.transform.Find("First").gameObject;
		gameObject2 = mid.gameObject.transform.Find("Second").gameObject;
		gameObject3 = mid.gameObject.transform.Find("Third").gameObject;
		if (mid.value >= 3)
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			gameObject2.gameObject.SetActive(value: true);
			switch (mid.value % 3)
			{
			case 0:
				gameObject2.GetComponent<Image>().sprite = CircleImage;
				break;
			case 1:
				gameObject2.GetComponent<Image>().sprite = SquareImage;
				break;
			case 2:
				gameObject2.GetComponent<Image>().sprite = TriangleImage;
				break;
			}
		}
		else
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			gameObject2.gameObject.SetActive(value: false);
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!ActiveComponent.Model.construction.testMode)
		{
			if (top.transform.childCount != normalTop || bot.transform.childCount != normalBot || mid.transform.childCount != normalMid)
			{
				ChangeColors();
				ChangeSprites();
			}
			if (Logic.UpdateCursorCanvasStatus(ref topOpen, ref topClosing, top, normalTop) || Logic.UpdateCursorCanvasStatus(ref botOpen, ref botClosing, bot, normalBot) || Logic.UpdateCursorCanvasStatus(ref midOpen, ref midClosing, mid, normalMid))
			{
				ChangeColors();
				ChangeSprites();
			}
		}
	}
}
