using System.Collections.Generic;
using App.Data;
using Aux;
using UnityEngine;
using UnityEngine.UI;

public class CustomBlock : BaseBlock
{
	[SceneBind("Inside")]
	private Text insideText;

	[SceneBind("Name")]
	public Text nameText;

	[SceneBind("GoInside")]
	public Button goInside;

	[SceneBind("GraphHolder/Content")]
	public RectTransform content;

	private Dictionary<SchemeBlock, Image> graphBlocks = new Dictionary<SchemeBlock, Image>();

	private Dictionary<List<SchemeChain>, Image> chainsBetweenBlocks = new Dictionary<List<SchemeChain>, Image>();

	private Dictionary<Socket, Image> inSocketsChains = new Dictionary<Socket, Image>();

	private Dictionary<List<SchemeChain>, Image> outSocketsChains = new Dictionary<List<SchemeChain>, Image>();

	[SceneBind("ServersCost")]
	private Text sCost;

	public List<Element> inside = new List<Element>();

	public SchemeBlock scheme;

	private int skipRedraws = 4;

	private int curTick;

	private bool redraw = true;

	private List<List<int>> showInSocketLinesTicks = new List<List<int>>();

	private List<List<int>> showOutSocketLinesTicks = new List<List<int>>();

	private Dictionary<SchemeBlock, List<float>> graphNodesColors = new Dictionary<SchemeBlock, List<float>>();

	private int curShowTick;

	private int maxShowTick = 5;

	public int maxElementsInside;

	public float sumElementsInSocket;

	private Color inactiveBlockColor = Color.black;

	private Color inactiveColor = Color.black;

	private Color goodColor = Color.green;

	private Color badColor = Color.red;

	private int maxSocketCapacity;

	private int maxChainCapacity;

	private float startTimer;

	public bool inGame;

	public override void Redraw()
	{
		nameText.text = Logic.GetShowNameById(scheme.GetKeyName());
		sCost.text = Logic.ColorTransform("SERVERS", scheme.GetServersCost().ToString());
	}

	protected override void Active()
	{
	}

	protected override bool TryActive()
	{
		redraw = true;
		if (ActiveComponent.Model.globalSaves.video == 1)
		{
			redraw = curTick % skipRedraws == 0;
			if (redraw)
			{
				curTick = 1;
			}
			else
			{
				curTick++;
			}
		}
		foreach (KeyValuePair<Socket, Image> inSocketsChain in inSocketsChains)
		{
			if (inSocketsChain.Key.inGame)
			{
				showInSocketLinesTicks[inSocketsChain.Key.num][curShowTick] = socketsIn[inSocketsChain.Key.num].queue.Count + scheme.inSockets[inSocketsChain.Key.num].queue.Count;
				int num = 0;
				foreach (int item in showInSocketLinesTicks[inSocketsChain.Key.num])
				{
					num += item;
				}
				float perc = (float)(num / 2 / maxShowTick) / (float)maxSocketCapacity;
				if (num == 0)
				{
					inSocketsChain.Value.color = inactiveColor;
				}
				else
				{
					inSocketsChain.Value.color = Logic.GetPercColor(perc);
				}
			}
			else
			{
				inSocketsChain.Value.color = inactiveColor;
			}
		}
		scheme.TryActive(Time.fixedDeltaTime);
		foreach (SchemeBlock key in graphBlocks.Keys)
		{
			if (key.activated)
			{
				if (key.KeyName == "REMOVE")
				{
					graphBlocks[key].color = Logic.GetPercColor(0f);
					continue;
				}
				float num2 = 0f;
				foreach (float item2 in graphNodesColors[key])
				{
					num2 += item2;
				}
				float num3 = num2 / (float)maxShowTick;
				graphNodesColors[key][curShowTick] = key.GetMeanElementsInSockets() / (float)maxSocketCapacity;
				if (num3 == 0f)
				{
					graphBlocks[key].color = inactiveBlockColor;
				}
				else
				{
					graphBlocks[key].color = Logic.GetPercColor(num3);
				}
			}
			else
			{
				graphBlocks[key].color = inactiveBlockColor;
			}
		}
		if (redraw)
		{
			foreach (KeyValuePair<List<SchemeChain>, Image> chainsBetweenBlock in chainsBetweenBlocks)
			{
				foreach (SchemeChain item3 in chainsBetweenBlock.Key)
				{
					if (item3.activated)
					{
						if (!item3.move)
						{
							chainsBetweenBlock.Value.color = badColor;
							continue;
						}
						float perc2 = item3.queue.Count / maxChainCapacity;
						if (item3.queue.Count == 0)
						{
							chainsBetweenBlock.Value.color = inactiveColor;
						}
						else
						{
							chainsBetweenBlock.Value.color = Logic.GetPercColor(perc2);
						}
					}
					else
					{
						chainsBetweenBlock.Value.color = inactiveColor;
					}
				}
			}
		}
		foreach (KeyValuePair<List<SchemeChain>, Image> outSocketsChain in outSocketsChains)
		{
			foreach (SchemeChain item4 in outSocketsChain.Key)
			{
				if (item4.activated)
				{
					int num4 = 0;
					foreach (int item5 in showOutSocketLinesTicks[item4.nextResultId])
					{
						num4 += item5;
					}
					float perc3 = (float)(num4 / 2 / maxShowTick) / (float)maxSocketCapacity;
					showOutSocketLinesTicks[item4.nextResultId][curShowTick] = socketsOut[item4.nextResultId].queue.Count + scheme.outSockets[item4.nextResultId].queue.Count;
					if (num4 == 0)
					{
						outSocketsChain.Value.color = inactiveColor;
					}
					else
					{
						outSocketsChain.Value.color = Logic.GetPercColor(perc3);
					}
				}
				else
				{
					outSocketsChain.Value.color = inactiveColor;
				}
			}
		}
		curShowTick = (curShowTick + 1) % maxShowTick;
		return true;
	}

	private void GoInside()
	{
		if (!enteredToScheme)
		{
			Logic.SaveCurCathub();
			ActiveComponent.Model.SandboxOpen = base.gameObject.name;
			enteredToScheme = true;
			ActiveComponent.Model.construction.AutoSave(Construction.Info.ShowNothing);
			ActiveComponent.Model.construction.OpenWindowInit(QuestLine.GetQuest(ActiveComponent.Model.SandboxOpen), replay: false, customBlockOpened: true, ActiveComponent.Model.SandboxOpen);
		}
	}

	public override void Init()
	{
		base.Init();
		socketsIn.Clear();
		socketsOut.Clear();
		for (int i = 0; i < 5; i++)
		{
			socketsIn.Add(base.transform.Find("SocketIn" + i).GetComponent<Socket>());
			socketsOut.Add(base.transform.Find("SocketOut" + i).GetComponent<Socket>());
		}
		for (int j = 0; j < 5; j++)
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
		goInside.onClick.RemoveAllListeners();
		goInside.onClick.AddListener(GoInside);
	}

	public override void Clear()
	{
		base.Clear();
		inside.Clear();
		inGame = false;
		sumElementsInSocket = 0f;
	}

	private void Awake()
	{
		Init();
	}

	public void Init(SchemeBlock sh, bool flag)
	{
		Init();
		inactiveColor = Logic.GetColor("GREY");
		inactiveBlockColor = Logic.GetColor("GREY");
		goodColor = Logic.GetColor("GREEN");
		badColor = Logic.GetColor("RED");
		maxSocketCapacity = Logic.GetCurSocketDepth();
		maxChainCapacity = Logic.GetMaxChainCapacityForGraph();
		maxShowTick = 10;
		content.transform.parent.localScale = Vector3.one;
		scheme = new SchemeBlock();
		scheme.BaseInit(sh);
		scheme.InitOnLoad(scheme);
		for (int i = 0; i < 5; i++)
		{
			if (sh.inSockets[i] == null)
			{
				socketsIn[i].DisableSocket();
				socketsIn[i] = null;
			}
			if (sh.outSockets[i] == null)
			{
				socketsOut[i].DisableSocket();
				socketsOut[i] = null;
			}
		}
		showInSocketLinesTicks = new List<List<int>>();
		showOutSocketLinesTicks = new List<List<int>>();
		graphNodesColors = new Dictionary<SchemeBlock, List<float>>();
		for (int j = 0; j < BaseBlock.maxSockets; j++)
		{
			List<int> list = new List<int>();
			for (int k = 0; k < maxShowTick; k++)
			{
				list.Add(0);
			}
			showInSocketLinesTicks.Add(list);
		}
		for (int l = 0; l < BaseBlock.maxSockets; l++)
		{
			List<int> list2 = new List<int>();
			for (int m = 0; m < maxShowTick; m++)
			{
				list2.Add(0);
			}
			showOutSocketLinesTicks.Add(list2);
		}
		base.enabled = flag;
		maxElementsInside = scheme.GetMaxElementsInside();
		Redraw();
		startTimer = Time.fixedTime;
		GameObject original = Logic.LoadPrefab("GraphBlock", block: false);
		GameObject original2 = Logic.LoadPrefab("GraphChain", block: false);
		foreach (KeyValuePair<SchemeBlock, Image> graphBlock in graphBlocks)
		{
			Object.Destroy(graphBlock.Value);
		}
		foreach (KeyValuePair<List<SchemeChain>, Image> chainsBetweenBlock in chainsBetweenBlocks)
		{
			Object.Destroy(chainsBetweenBlock.Value);
		}
		foreach (KeyValuePair<Socket, Image> inSocketsChain in inSocketsChains)
		{
			Object.Destroy(inSocketsChain.Value);
		}
		foreach (KeyValuePair<List<SchemeChain>, Image> outSocketsChain in outSocketsChains)
		{
			Object.Destroy(outSocketsChain.Value);
		}
		graphBlocks = new Dictionary<SchemeBlock, Image>();
		inSocketsChains = new Dictionary<Socket, Image>();
		outSocketsChains = new Dictionary<List<SchemeChain>, Image>();
		chainsBetweenBlocks = new Dictionary<List<SchemeChain>, Image>();
		foreach (SchemeBlock block in scheme.blocks)
		{
			GameObject obj = Object.Instantiate(original, Vector3.zero, Quaternion.identity, content);
			block.position.z = 0f;
			obj.transform.localPosition = block.position;
			Image component = obj.GetComponent<Image>();
			Sprite sprite = Logic.LoadSprite("GRAPH_" + block.KeyName);
			if (sprite != null)
			{
				component.sprite = sprite;
			}
			graphBlocks.Add(block, component);
			obj.GetComponent<Image>().color = inactiveColor;
			List<float> list3 = new List<float>();
			for (int n = 0; n < maxShowTick; n++)
			{
				list3.Add(0f);
			}
			graphNodesColors[block] = list3;
		}
		content.transform.localScale = Vector3.one * content.GetComponent<RectTransform>().rect.size.y / 988.1818f;
		float num = float.MaxValue;
		float num2 = float.MinValue;
		float num3 = float.MaxValue;
		float num4 = float.MinValue;
		foreach (SchemeBlock block2 in scheme.blocks)
		{
			GameObject gameObject = graphBlocks[block2].gameObject;
			num = Mathf.Min(num, gameObject.transform.localPosition.x);
			num2 = Mathf.Max(num2, gameObject.transform.localPosition.x);
			num3 = Mathf.Min(num3, gameObject.transform.localPosition.y);
			num4 = Mathf.Max(num4, gameObject.transform.localPosition.y);
		}
		Vector3 vector = new Vector3((num2 + num) / 2f, (num4 + num3) / 2f, 0f);
		foreach (SchemeBlock block3 in scheme.blocks)
		{
			graphBlocks[block3].gameObject.transform.localPosition -= vector;
		}
		num = float.MaxValue;
		num2 = float.MinValue;
		num3 = float.MaxValue;
		num4 = float.MinValue;
		foreach (SchemeBlock block4 in scheme.blocks)
		{
			GameObject gameObject2 = graphBlocks[block4].gameObject;
			num = Mathf.Min(num, gameObject2.transform.position.x);
			num2 = Mathf.Max(num2, gameObject2.transform.position.x);
			num3 = Mathf.Min(num3, gameObject2.transform.position.y);
			num4 = Mathf.Max(num4, gameObject2.transform.position.y);
		}
		Rect worldRect = Helper.GetWorldRect(content.transform.parent.GetComponent<RectTransform>());
		if (scheme.blocks.Count == 1)
		{
			content.transform.parent.localScale = Vector3.one;
		}
		else
		{
			content.transform.parent.localScale *= Mathf.Max(1f, Mathf.Min(worldRect.height / Mathf.Abs(num4 - num3), worldRect.width / Mathf.Abs(num2 - num)));
		}
		foreach (SchemeBlock block5 in scheme.blocks)
		{
			List<SchemeChain> list4 = new List<SchemeChain>();
			foreach (SchemeSocket outSocket in block5.outSockets)
			{
				if (outSocket == null || outSocket.chain == null || outSocket.chain.nextBlockId == -1 || list4.Contains(outSocket.chain))
				{
					continue;
				}
				List<SchemeChain> list5 = new List<SchemeChain>();
				list4.Add(outSocket.chain);
				list5.Add(outSocket.chain);
				foreach (SchemeSocket outSocket2 in block5.outSockets)
				{
					if (outSocket2 != null && outSocket2 != outSocket && outSocket2.chain != null && !list4.Contains(outSocket2.chain) && outSocket.chain.nextBlockId == outSocket2.chain.nextBlockId)
					{
						list5.Add(outSocket2.chain);
						list4.Add(outSocket2.chain);
					}
				}
				if (list5.Count > 0)
				{
					GameObject gameObject3 = Object.Instantiate(original2, Vector3.zero, Quaternion.identity, content);
					gameObject3.transform.localScale = Vector3.one;
					gameObject3.GetComponent<CustomGraphChain>().Init();
					gameObject3.GetComponent<CustomGraphChain>().SetEnds(graphBlocks[block5].gameObject, graphBlocks[scheme.blocks[list5[0].nextBlockId]].gameObject);
					gameObject3.GetComponent<Image>().color = inactiveColor;
					chainsBetweenBlocks.Add(list5, gameObject3.GetComponent<Image>());
				}
			}
		}
		for (int num5 = 0; num5 < socketsIn.Count; num5++)
		{
			if (socketsIn[num5] != null)
			{
				socketsIn[num5].transform.SetParent(content);
				GameObject gameObject4 = Object.Instantiate(original2, Vector3.zero, Quaternion.identity, content);
				gameObject4.transform.localScale = Vector3.one;
				gameObject4.GetComponent<CustomGraphChain>().Init();
				gameObject4.GetComponent<CustomGraphChain>().SetEnds(socketsIn[num5].gameObject, graphBlocks[scheme.blocks[scheme.inSockets[num5].nextBlock]].gameObject);
				inSocketsChains.Add(socketsIn[num5], gameObject4.GetComponent<Image>());
				gameObject4.GetComponent<Image>().color = inactiveColor;
				socketsIn[num5].transform.SetParent(base.transform);
				socketsIn[num5].gameObject.SetActive(value: true);
				socketsIn[num5].enabled = true;
			}
		}
		foreach (SchemeBlock block6 in scheme.blocks)
		{
			List<SchemeChain> list6 = new List<SchemeChain>();
			foreach (SchemeSocket outSocket3 in block6.outSockets)
			{
				if (outSocket3 == null || outSocket3.chain == null || outSocket3.chain.nextResultId == -1 || list6.Contains(outSocket3.chain))
				{
					continue;
				}
				List<SchemeChain> list7 = new List<SchemeChain>();
				list6.Add(outSocket3.chain);
				list7.Add(outSocket3.chain);
				foreach (SchemeSocket outSocket4 in block6.outSockets)
				{
					if (outSocket4 != null && outSocket4 != outSocket3 && outSocket4.chain != null && !list6.Contains(outSocket4.chain) && outSocket3.chain.nextResultId == outSocket4.chain.nextResultId)
					{
						list7.Add(outSocket4.chain);
						list6.Add(outSocket4.chain);
					}
				}
				if (list7.Count > 0)
				{
					GameObject gameObject5 = Object.Instantiate(original2, Vector3.zero, Quaternion.identity, content);
					gameObject5.transform.localScale = Vector3.one;
					gameObject5.GetComponent<CustomGraphChain>().Init();
					socketsOut[list7[0].nextResultId].transform.SetParent(content);
					gameObject5.GetComponent<CustomGraphChain>().SetEnds(graphBlocks[block6].gameObject, socketsOut[list7[0].nextResultId].gameObject);
					socketsOut[list7[0].nextResultId].transform.SetParent(base.transform);
					socketsOut[list7[0].nextResultId].gameObject.SetActive(value: true);
					socketsOut[list7[0].nextResultId].enabled = true;
					gameObject5.GetComponent<Image>().color = inactiveColor;
					outSocketsChains.Add(list7, gameObject5.GetComponent<Image>());
				}
			}
		}
		foreach (Image value in chainsBetweenBlocks.Values)
		{
			SetChainDefaultScale(value);
		}
		foreach (Image value2 in inSocketsChains.Values)
		{
			SetChainDefaultScale(value2);
		}
		foreach (Image value3 in outSocketsChains.Values)
		{
			SetChainDefaultScale(value3);
		}
		foreach (SchemeBlock block7 in scheme.blocks)
		{
			graphBlocks[block7].transform.SetParent(base.transform);
			graphBlocks[block7].transform.localScale = Vector3.one;
			if (!Logic.IsBaseBlock(block7.KeyName))
			{
				graphBlocks[block7].transform.localScale = new Vector3(1.8f, 1.2f, 1f);
			}
			if (block7.KeyName == "REMOVE")
			{
				graphBlocks[block7].transform.localScale = Vector3.one * 1f;
			}
			graphBlocks[block7].transform.SetParent(content);
		}
	}

	private void SetChainDefaultScale(Image scaleImg)
	{
		scaleImg.gameObject.transform.SetParent(base.transform);
		Vector3 localScale = scaleImg.gameObject.transform.localScale;
		localScale.x = 1f;
		localScale.z = 1f;
		scaleImg.gameObject.transform.localScale = localScale;
		scaleImg.gameObject.transform.SetParent(content);
	}

	private void GetFromSockets()
	{
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			if (!(socketsIn[i] != null) || socketsIn[i].isEmpty() || scheme.inSockets[i].isFull())
			{
				continue;
			}
			Element element = socketsIn[i].GetElement();
			if (element != null)
			{
				element.inputNum = i;
				if (element != null)
				{
					scheme.inSockets[element.inputNum].SetElement(new Element(element));
					scheme.activated = true;
				}
				inGame = true;
			}
		}
		if (inGame)
		{
			TryActive();
		}
	}

	protected override void FixedUpdate()
	{
		if (bd.dummy || !base.gameObject.activeInHierarchy || !ActiveComponent.Model.construction.testMode)
		{
			return;
		}
		if (inGame)
		{
			for (int i = 0; i < scheme.outSockets.Count; i++)
			{
				if (scheme.outSockets[i] != null && !socketsOut[i].isFull())
				{
					Element element = scheme.outSockets[i].GetElement();
					if (element != null)
					{
						socketsOut[i].SetElement(element);
					}
				}
			}
		}
		GetFromSockets();
	}
}
