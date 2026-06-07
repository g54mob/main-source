using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class DesicionTree : BaseBlock
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
		if (ActiveComponent._staticData.LogicsColor[top.value].KeyName == "ANY")
		{
			flag = true;
		}
		if (ActiveComponent._staticData.LogicsColor[bot.value].KeyName == "ANY")
		{
			flag2 = true;
		}
		if (top.value == element.ColorId)
		{
			flag = true;
		}
		if (bot.value == element.ColorId)
		{
			flag2 = true;
		}
		if (flag == flag2 || !element.revealed)
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
		if (ActiveComponent._staticData.LogicsColor[top.value].KeyName == "ANY")
		{
			flag = true;
		}
		if (ActiveComponent._staticData.LogicsColor[bot.value].KeyName == "ANY")
		{
			flag2 = true;
		}
		if (top.value == element.ColorId)
		{
			flag = true;
		}
		if (bot.value == element.ColorId)
		{
			flag2 = true;
		}
		if (flag == flag2 || !element.revealed)
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
			keyName = "DSTREE";
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
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		optionsBot.Clear();
		optionsTop.Clear();
		for (int i = 0; i < ActiveComponent._staticData.LogicsColor.Count; i++)
		{
			optionsTop.Add(new Dropdown.OptionData(TextResources.GetString(ActiveComponent._staticData.LogicsColor[i].Name)));
			optionsBot.Add(new Dropdown.OptionData(TextResources.GetString(ActiveComponent._staticData.LogicsColor[i].Name)));
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
			top.value = sh.outConditionsColor[1];
			bot.value = sh.outConditionsColor[3];
		}
		AddRecordToEvent(top.onValueChanged);
		AddRecordToEvent(bot.onValueChanged);
		ListenCloseDropdown(top, normalTop);
		ListenCloseDropdown(bot, normalBot);
		top.onValueChanged.AddListener(delegate
		{
			ChangeColors();
		});
		bot.onValueChanged.AddListener(delegate
		{
			ChangeColors();
		});
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
		ChangeColors();
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
		top.captionText.color = Logic.GetColor(top.value);
		bot.captionText.color = Logic.GetColor(bot.value);
		Transform[] componentsInChildren3 = top.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren3)
		{
			if (transform.gameObject.GetComponent<Image>() != null && transform.gameObject.tag == "Checkmark")
			{
				transform.gameObject.GetComponent<Image>().color = Logic.GetColor(top.value);
			}
		}
		componentsInChildren3 = bot.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform2 in componentsInChildren3)
		{
			if (transform2.gameObject.GetComponent<Image>() != null && transform2.gameObject.tag == "Checkmark")
			{
				transform2.gameObject.GetComponent<Image>().color = Logic.GetColor(bot.value);
			}
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!ActiveComponent.Model.construction.testMode)
		{
			if (top.transform.childCount != normalTop || bot.transform.childCount != normalBot)
			{
				ChangeColors();
			}
			if (Logic.UpdateCursorCanvasStatus(ref topOpen, ref topClosing, top, normalTop) || Logic.UpdateCursorCanvasStatus(ref botOpen, ref botClosing, bot, normalBot))
			{
				ChangeColors();
			}
		}
	}
}
