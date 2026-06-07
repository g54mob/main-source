using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class DsShape : BaseBlock
{
	private Socket socketIn;

	private Socket socketTop;

	private Socket socketBot;

	[SceneBind("ParamTop")]
	public Dropdown top;

	[SceneBind("ParamBot")]
	public Dropdown bot;

	private List<Dropdown.OptionData> optionsTop = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsBot = new List<Dropdown.OptionData>();

	public Sprite CircleImage;

	public Sprite SquareImage;

	public Sprite TriangleImage;

	private MultiDictionary<int, Socket> sortedRandomDict;

	private List<int> sortedRandomList;

	private bool topOpen;

	private bool botOpen;

	private bool topClosing;

	private bool botClosing;

	private int normalTop;

	private int normalBot;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		Element element = socketIn.queue[0];
		bool flag = false;
		bool flag2 = false;
		if (ActiveComponent._staticData.LogicsShape[top.value].KeyName == "ANY")
		{
			flag = true;
		}
		if (ActiveComponent._staticData.LogicsShape[bot.value].KeyName == "ANY")
		{
			flag2 = true;
		}
		if (top.value == element.ShapeId)
		{
			flag = true;
		}
		if (bot.value == element.ShapeId)
		{
			flag2 = true;
		}
		if (flag == flag2)
		{
			if (!socketBot.isFull())
			{
				return !socketTop.isFull();
			}
			return false;
		}
		if (flag)
		{
			return !socketTop.isFull();
		}
		if (flag2)
		{
			return !socketBot.isFull();
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
		if (ActiveComponent._staticData.LogicsShape[top.value].KeyName == "ANY")
		{
			flag = true;
		}
		if (ActiveComponent._staticData.LogicsShape[bot.value].KeyName == "ANY")
		{
			flag2 = true;
		}
		if (top.value == element.ShapeId)
		{
			flag = true;
		}
		if (bot.value == element.ShapeId)
		{
			flag2 = true;
		}
		if (flag == flag2)
		{
			if (sortedRandomDict == null)
			{
				sortedRandomDict = new MultiDictionary<int, Socket>();
				sortedRandomDict.Add(top.value, socketTop);
				sortedRandomDict.Add(bot.value, socketBot);
				sortedRandomList = new List<int>();
				sortedRandomList.Add(top.value);
				sortedRandomList.Add(bot.value);
				sortedRandomList.Sort();
			}
			HashSet<Socket> hashSet = sortedRandomDict[sortedRandomList[BlockRandom.Next(2)]];
			List<Socket> list = new List<Socket>();
			foreach (Socket item in hashSet)
			{
				list.Add(item);
			}
			list[BlockRandom.Next(list.Count)].SetElement(element);
		}
		else if (flag)
		{
			socketTop.SetElement(element);
		}
		else if (flag2)
		{
			socketBot.SetElement(element);
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
			keyName = "DSSHAPE";
			normalTop = top.transform.childCount;
			normalBot = bot.transform.childCount;
		}
		if (top.transform.childCount != normalTop)
		{
			Object.Destroy(top.transform.GetChild(top.transform.childCount - 1).gameObject);
		}
		if (bot.transform.childCount != normalBot)
		{
			Object.Destroy(bot.transform.GetChild(bot.transform.childCount - 1).gameObject);
		}
		optionsBot.Clear();
		optionsTop.Clear();
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		for (int i = 0; i < ActiveComponent._staticData.LogicsShape.Count; i++)
		{
			optionsTop.Add(new Dropdown.OptionData(""));
			optionsBot.Add(new Dropdown.OptionData(""));
		}
		top.onValueChanged.RemoveAllListeners();
		bot.onValueChanged.RemoveAllListeners();
		top.ClearOptions();
		bot.ClearOptions();
		top.AddOptions(optionsTop);
		bot.AddOptions(optionsBot);
		top.enabled = true;
		bot.enabled = true;
		hasDropdown = true;
		top.value = 0;
		bot.value = 2;
		socketsIn[2] = socketIn;
		socketsOut[1] = socketTop;
		socketsOut[3] = socketBot;
		for (int j = 0; j < BaseBlock.maxSockets; j++)
		{
			if (socketsIn[j] != null)
			{
				socketsIn[j].num = j;
			}
			if (socketsOut[j] != null)
			{
				socketsOut[j].num = j;
			}
		}
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			top.value = sh.outConditionsShape[1];
			bot.value = sh.outConditionsShape[3];
		}
		AddRecordToEvent(top.onValueChanged);
		AddRecordToEvent(bot.onValueChanged);
		ListenCloseDropdown(top, normalTop);
		ListenCloseDropdown(bot, normalBot);
		top.onValueChanged.AddListener(delegate
		{
			ChangeSprites();
		});
		bot.onValueChanged.AddListener(delegate
		{
			ChangeSprites();
		});
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
		ChangeSprites();
	}

	public void ChangeSprites()
	{
		Toggle[] componentsInChildren = base.gameObject.GetComponentsInChildren<Toggle>();
		if (componentsInChildren.Length != 0)
		{
			Transform[] componentsInChildren2 = componentsInChildren[0].gameObject.GetComponentsInChildren<Transform>();
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
			componentsInChildren2 = componentsInChildren[1].gameObject.GetComponentsInChildren<Transform>();
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
			componentsInChildren2 = componentsInChildren[2].gameObject.GetComponentsInChildren<Transform>();
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
		}
		GameObject gameObject = bot.gameObject.transform.Find("First").gameObject;
		GameObject gameObject2 = bot.gameObject.transform.Find("Second").gameObject;
		GameObject gameObject3 = bot.gameObject.transform.Find("Third").gameObject;
		if (bot.value != 3)
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			switch (bot.value)
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
			gameObject.gameObject.SetActive(value: true);
			gameObject3.gameObject.SetActive(value: true);
			gameObject2.GetComponent<Image>().sprite = SquareImage;
		}
		gameObject = top.gameObject.transform.Find("First").gameObject;
		gameObject2 = top.gameObject.transform.Find("Second").gameObject;
		gameObject3 = top.gameObject.transform.Find("Third").gameObject;
		if (top.value != 3)
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			switch (top.value)
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
			gameObject.gameObject.SetActive(value: true);
			gameObject3.gameObject.SetActive(value: true);
			gameObject2.GetComponent<Image>().sprite = SquareImage;
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!ActiveComponent.Model.construction.testMode)
		{
			if (top.transform.childCount != normalTop || bot.transform.childCount != normalBot)
			{
				ChangeSprites();
			}
			if (Logic.UpdateCursorCanvasStatus(ref topOpen, ref topClosing, top, normalTop) || Logic.UpdateCursorCanvasStatus(ref botOpen, ref botClosing, bot, normalBot))
			{
				ChangeSprites();
			}
		}
	}
}
