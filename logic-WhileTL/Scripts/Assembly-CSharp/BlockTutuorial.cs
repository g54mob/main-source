using System.Collections;
using System.Collections.Generic;
using App.Data;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.UI;

public class BlockTutuorial : ActiveComponent
{
	[SceneBind("Ok")]
	private Button Ok;

	[SceneBind("Layer")]
	private Button Layer;

	[SceneBind("Place")]
	private RectTransform Place;

	[SceneBind("LinesContainer")]
	private RectTransform LinesContainer;

	private List<GameObject> blocks = new List<GameObject>();

	private Dictionary<int, GameObject> prefabs = new Dictionary<int, GameObject>();

	private List<Socket> socketsIn = new List<Socket>();

	private List<Socket> socketsOut = new List<Socket>();

	private GameObject obj;

	private List<Chain> chains = new List<Chain>();

	private BaseBlock baseBlock;

	private float blockSpeed;

	private string curKeyName = "";

	private bool wait = true;

	private List<Element> queue = new List<Element>();

	public App.Data.Data data;

	private float lastSendTime;

	private List<List<int>> couMatrix = new List<List<int>>();

	private float time;

	public void OkClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		wait = false;
		foreach (Chain chain in chains)
		{
			chain.ClearBeforeDelete();
			ActiveComponent.Model.DisableChainObj(chain);
		}
		chains.Clear();
		foreach (Socket item in socketsIn)
		{
			item.Clear();
			item.DeleteChains(invoke: false);
		}
		foreach (Socket item2 in socketsOut)
		{
			item2.Clear();
			item2.DeleteChains(invoke: false);
		}
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Ok.onClick.AddListener(OkClick);
		Layer.onClick.AddListener(OkClick);
		blocks.Clear();
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform != null && transform.gameObject != null)
			{
				if (transform.tag == "Newspaper")
				{
					GameObject gameObject = transform.gameObject;
					blocks.Add(gameObject);
					prefabs.Add(gameObject.name.GetHashCode(), Logic.LoadPrefab(gameObject.name));
				}
				if (transform.GetComponent<UrlButton>() != null)
				{
					transform.GetComponent<UrlButton>().Init();
				}
			}
		}
		socketsIn.Clear();
		socketsOut.Clear();
		for (int j = 0; j < 5; j++)
		{
			socketsIn.Add(base.transform.Find("SocketIn" + j).GetComponent<Socket>());
			socketsOut.Add(base.transform.Find("SocketOut" + j).GetComponent<Socket>());
		}
	}

	public void Redraw(string KeyName)
	{
		wait = true;
		Redraw(KeyName, prefabs[KeyName.GetHashCode()]);
		ActiveComponent.Program.cursor.SetPosition(Ok.gameObject.transform.position);
	}

	public Chain CreateChain()
	{
		Chain chainObjectFromPool = ActiveComponent.Model.GetChainObjectFromPool(ActiveComponent.Model.chainPrefab, Vector3.zero, Quaternion.identity, LinesContainer);
		chainObjectFromPool.transform.localScale = Vector3.one;
		chainObjectFromPool.tutorial = true;
		return chainObjectFromPool;
	}

	public void Redraw(string KeyName, GameObject pref)
	{
		wait = true;
		curKeyName = KeyName;
		foreach (GameObject block in blocks)
		{
			block.SetActive(value: false);
		}
		foreach (GameObject block2 in blocks)
		{
			if (!(block2.name == KeyName))
			{
				continue;
			}
			if (this.obj != null)
			{
				ActiveComponent.Model.DisableBaseBlockObj(this.obj.GetComponent<BaseBlock>());
			}
			couMatrix.Clear();
			for (int i = 0; i < 3; i++)
			{
				couMatrix.Add(new List<int>());
				for (int j = 0; j < 3; j++)
				{
					couMatrix[i].Add(0);
				}
			}
			data = Logic.GetDataByKeyName(KeyName + "_TUTORIAL");
			blockSpeed = Logic.GetWorkTimeByKeyName(KeyName);
			if (data != null)
			{
				if (data.words == "")
				{
					couMatrix[0][0] = data.RC;
					couMatrix[1][0] = data.GC;
					couMatrix[2][0] = data.BC;
					couMatrix[0][1] = data.RS;
					couMatrix[1][1] = data.GS;
					couMatrix[2][1] = data.BS;
					couMatrix[0][2] = data.RT;
					couMatrix[1][2] = data.GT;
					couMatrix[2][2] = data.BT;
				}
				time = data.Time;
			}
			else
			{
				time = 1f;
			}
			foreach (Socket item in socketsIn)
			{
				item.Clear();
			}
			queue.Clear();
			lastSendTime = Time.unscaledTime;
			GameObject gameObject = ActiveComponent.Model.GetBaseBlockObjectFromPool(pref, Place.gameObject.transform.position, Quaternion.identity, Place.transform).gameObject;
			gameObject.transform.parent = Place.transform;
			BlockData component = gameObject.GetComponent<BlockData>();
			BaseBlock baseBlock = (this.baseBlock = gameObject.GetComponent<BaseBlock>());
			component.DeActive();
			baseBlock.enabled = true;
			baseBlock.tutorial = true;
			if (gameObject != null)
			{
				Socket[] componentsInChildren = gameObject.GetComponentsInChildren<Socket>();
				foreach (Socket obj in componentsInChildren)
				{
					obj.Redraw();
					obj.InitDraw();
				}
			}
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			this.obj = gameObject;
			block2.SetActive(value: true);
			List<Socket> list = component.socketsIn;
			List<Socket> list2 = component.socketsOut;
			if (!baseBlock.IsTrained())
			{
				baseBlock.error = baseBlock.minError;
				baseBlock.Redraw();
			}
			if (KeyName == "RNNCELL" || KeyName == "ARMA")
			{
				Chain chain = CreateChain();
				chain.SetInSocket(list2[3]);
				chain.SetOutSocket(list[4]);
				chain.transform.SetParent(LinesContainer);
				chains.Add(chain);
				chain = CreateChain();
				chain.SetInSocket(list2[4]);
				chain.SetOutSocket(list[3]);
				chain.transform.SetParent(LinesContainer);
				chains.Add(chain);
			}
			foreach (Socket item2 in list)
			{
				if (item2 != null && item2.inChains.Count == 0 && !item2.type.Contains("MEMORY"))
				{
					Chain chain2 = CreateChain();
					Vector3 position = socketsIn[item2.num].transform.position;
					position.y = item2.transform.position.y;
					socketsIn[item2.num].transform.position = position;
					chain2.SetInSocket(socketsIn[item2.num]);
					chain2.SetOutSocket(item2);
					chain2.transform.SetParent(LinesContainer);
					chains.Add(chain2);
				}
			}
			{
				foreach (Socket item3 in list2)
				{
					if (item3 != null && item3.chain == null && !item3.type.Contains("MEMORY"))
					{
						Chain chain3 = CreateChain();
						Vector3 position2 = socketsOut[item3.num].transform.position;
						position2.y = item3.transform.position.y;
						socketsOut[item3.num].transform.position = position2;
						chain3.SetInSocket(item3);
						chain3.SetOutSocket(socketsOut[item3.num]);
						chain3.transform.SetParent(LinesContainer);
						chains.Add(chain3);
					}
				}
				return;
			}
		}
		base.gameObject.SetActive(value: false);
	}

	public IEnumerator WaitForUserAction()
	{
		while (wait)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			OkClick();
		}
		if (!(Time.unscaledTime - lastSendTime > time))
		{
			return;
		}
		if (queue.Count == 0)
		{
			if (data != null)
			{
				if (data.words == "")
				{
					for (int i = 0; i < 3; i++)
					{
						for (int j = 0; j < 3; j++)
						{
							for (int k = 0; k < couMatrix[i][j]; k++)
							{
								Element item = new Element(i, j, test: false);
								queue.Add(item);
							}
						}
					}
				}
				else
				{
					List<char> list = new List<char>();
					string truePredict = data.truePredict;
					foreach (char item2 in truePredict)
					{
						list.Add(item2);
					}
					for (int m = 0; m < data.words.Length - 1 + 1; m++)
					{
						List<char> list2 = new List<char>();
						list2.Add(data.words[m]);
						for (int n = 1; n < 1; n++)
						{
							list2.Add(data.words[m + n]);
						}
						Element element = new Element(0, 1, test: false, null, list2, list, m);
						element.revealed = false;
						element.revealScore = 93;
						element.batchSize = 1;
						if (data.colorsQueue != "")
						{
							element.colorsQueue = data.colorsQueue;
						}
						queue.Add(element);
					}
					baseBlock.Clear();
					foreach (Chain chain in chains)
					{
						chain.ElemsClear();
					}
					baseBlock.ClearSockets();
					foreach (Socket item3 in socketsIn)
					{
						item3.Clear();
					}
				}
			}
			else if (curKeyName == "ISOBJECT")
			{
				queue.Add(new Element(CellObjects.car));
				queue.Add(new Element(CellObjects.empty, "unknown", false, true, 0));
				queue.Add(new Element(CellObjects.wall));
			}
			else
			{
				Element element2 = new Element(CellObjects.car);
				element2.predictedObject = "object";
				queue.Add(element2);
				element2 = new Element(CellObjects.wall);
				element2.predictedObject = "object";
				queue.Add(element2);
			}
		}
		lastSendTime = Time.unscaledTime;
		foreach (Socket item4 in socketsIn)
		{
			if (item4.chain != null)
			{
				item4.SetElement(queue[0]);
			}
		}
		queue.RemoveAt(0);
		foreach (Socket item5 in socketsOut)
		{
			item5.Clear();
		}
	}
}
