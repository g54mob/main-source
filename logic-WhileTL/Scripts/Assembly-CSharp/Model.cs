using System.Collections.Generic;
using App.Data;
using Unity.Components.Events;
using UnityEngine;
using UnityEngine.UI;

public class Model
{
	public bool ReadyToPlay;

	public KeyboardController Keyboard;

	public int KeyBoardTicks;

	public bool LoadingSave;

	public bool CurInputDeviceIsController;

	public string CurInputDevice = "PC";

	public WeakEvent<string> InputDeviceChanged = new WeakEvent<string>();

	public static bool steamDeckRunning = false;

	public static float sizeMultCoef = 1f;

	public static Dictionary<string, TextInGame> _texts;

	public bool firstLoad = true;

	public static int startups_tutorial_comics_68_percentile = 0;

	public float sessionTime;

	public float spriteRenderScale = 1f;

	private int activeElementsNum;

	private List<ElementControl> elementsPool = new List<ElementControl>();

	private Dictionary<int, List<BaseBlock>> blocksPool = new Dictionary<int, List<BaseBlock>>();

	private Dictionary<int, int> activeBlocksNum = new Dictionary<int, int>();

	private int activeChainsNum;

	private List<Chain> chainsPool = new List<Chain>();

	private Dictionary<int, List<GameObject>> objPool = new Dictionary<int, List<GameObject>>();

	private Dictionary<int, int> gameObjectNum = new Dictionary<int, int>();

	public bool lastCatPromoActivated;

	public string RunTaskWhenTreeOpens = string.Empty;

	public bool recordHistory;

	public GameObject linesContainer;

	public GameObject chainPrefab;

	public HashSet<string> activatedCheats = new HashSet<string>();

	public bool showSteamWindow;

	public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

	public int drawnMoney;

	public float drawedMoneySpeed = 1f;

	public Startup curStartup;

	public StartupScheme curStartupInWork;

	public string SandboxOpen = "";

	public SchemeBlock Scheme;

	public GlobalSaves globalSaves;

	public PreviewData curPreview;

	public Startup ShowFastStartup;

	public PersistentData P;

	public bool CanUsePSN = true;

	public float curSpeed;

	public QuestLine.Quest OpenTaskInbox;

	public QuestLine.Quest OpenTaskTree;

	public int OpenStartupInbox;

	public ConstructionState constructionState;

	public bool trainTest;

	public bool wasGlowOnThisTask;

	public List<string> PredefinedGoodEventTitles = new List<string>();

	public List<string> PredefinedBadEventTitles = new List<string>();

	public List<string> PredefinedTitles = new List<string>();

	public List<string> Titles = new List<string>();

	public List<string> Genres = new List<string>();

	public List<string> Authors = new List<string>();

	public List<string> MailTemplates = new List<string>();

	public List<int> BlockInList = new List<int>();

	public WeakEvent LevelUpdated = new WeakEvent();

	public Level Level;

	public float curAccurcyCoef;

	public float curRewardCoef;

	public int lastProjectServers;

	public AlgoProject CurrentProject;

	public bool lastBlock;

	public bool lastCrit;

	public int lastProjectNum;

	public GameObject currentChain;

	public Construction construction;

	private GameObject SpawnElement(GameObject prefab, Vector3 pos, Quaternion rotation, Transform parent)
	{
		return Object.Instantiate(prefab, pos, rotation, parent);
	}

	public void SetSpawnSettings(MonoBehaviour obj, Vector3 pos, Quaternion rotation, Transform parent)
	{
		obj.enabled = true;
		obj.gameObject.transform.SetParent(parent);
		obj.gameObject.transform.SetAsLastSibling();
		obj.gameObject.transform.rotation = rotation;
		obj.gameObject.transform.position = pos;
	}

	public ElementControl GetElementObjectFromPool(GameObject prefab, Vector3 pos, Quaternion rotation, Transform parent)
	{
		ElementControl elementControl = null;
		if (activeElementsNum == elementsPool.Count)
		{
			elementControl = SpawnElement(prefab, pos, rotation, parent).GetComponent<ElementControl>();
			elementControl.Init();
			elementsPool.Add(elementControl);
		}
		else
		{
			elementControl = elementsPool[activeElementsNum];
			if (elementControl == null)
			{
				elementControl = SpawnElement(prefab, pos, rotation, parent).GetComponent<ElementControl>();
				elementControl.Init();
			}
			else
			{
				elementControl.gameObject.SetActive(value: true);
			}
			SetSpawnSettings(elementControl, pos, rotation, parent);
		}
		activeElementsNum++;
		return elementControl;
	}

	public Chain GetChainObjectFromPool(GameObject prefab, Vector3 pos, Quaternion rotation, Transform parent)
	{
		Chain chain = null;
		if (activeChainsNum == chainsPool.Count)
		{
			chain = SpawnElement(prefab, pos, rotation, parent).GetComponent<Chain>();
			chain.Init();
			chainsPool.Add(chain);
		}
		else
		{
			chain = chainsPool[activeChainsNum];
			if (chain == null)
			{
				chain = SpawnElement(prefab, pos, rotation, parent).GetComponent<Chain>();
				chain.Init();
			}
			SetSpawnSettings(chain, pos, rotation, parent);
		}
		chain.gameObject.GetComponent<Button>().enabled = true;
		chain.hoverChain = false;
		chain.Clear();
		chain.tutorial = false;
		chain.SetMove(state: false);
		activeChainsNum++;
		chain.SetDummy(state: false);
		chain.InitDraw();
		return chain;
	}

	public BaseBlock GetBaseBlockObjectFromPool(GameObject prefab, Vector3 pos, Quaternion rotation, Transform parent)
	{
		BaseBlock baseBlock = null;
		int hashCode = prefab.name.GetHashCode();
		if (!blocksPool.ContainsKey(hashCode))
		{
			blocksPool.Add(hashCode, new List<BaseBlock>());
			activeBlocksNum.Add(hashCode, 0);
		}
		if (activeBlocksNum[hashCode] == blocksPool[hashCode].Count)
		{
			baseBlock = SpawnElement(prefab, pos, rotation, parent).GetComponent<BaseBlock>();
			baseBlock.Init();
			blocksPool[hashCode].Add(baseBlock);
		}
		else
		{
			baseBlock = blocksPool[hashCode][activeBlocksNum[hashCode]];
			if (baseBlock == null)
			{
				baseBlock = SpawnElement(prefab, pos, rotation, parent).GetComponent<BaseBlock>();
				baseBlock.Init();
			}
			SetSpawnSettings(baseBlock, pos, rotation, parent);
		}
		baseBlock.Clear();
		BlockData component = baseBlock.GetComponent<BlockData>();
		component.dummy = false;
		component.InitSockets();
		component.ResetCornerScales();
		List<Socket>[] array = new List<Socket>[2] { component.socketsIn, component.socketsOut };
		for (int i = 0; i < array.Length; i++)
		{
			foreach (Socket item in array[i])
			{
				if (item != null)
				{
					item.Redraw();
					item.InitDraw();
					item.gameObject.SetActive(value: true);
					item.gameObject.GetComponent<Button>().enabled = true;
					item.gameObject.GetComponent<Socket>().enabled = true;
					item.gameObject.GetComponent<ZoomOnMouse>().enabled = true;
				}
			}
		}
		baseBlock.ResetRandom();
		baseBlock.enteredToScheme = false;
		baseBlock.gameObject.name = prefab.name;
		baseBlock.gameObject.SetActive(value: true);
		activeBlocksNum[hashCode]++;
		return baseBlock;
	}

	public GameObject GetGameObjectFromPool(GameObject prefab, Vector3 pos, Quaternion rotation, Transform parent)
	{
		GameObject gameObject = null;
		int hashCode = prefab.name.GetHashCode();
		if (!objPool.ContainsKey(hashCode))
		{
			objPool.Add(hashCode, new List<GameObject>());
			gameObjectNum.Add(hashCode, 0);
		}
		if (gameObjectNum[hashCode] == objPool[hashCode].Count)
		{
			gameObject = SpawnElement(prefab, pos, rotation, parent);
			objPool[hashCode].Add(gameObject);
		}
		else
		{
			gameObject = objPool[hashCode][gameObjectNum[hashCode]];
			if (gameObject == null)
			{
				gameObject = SpawnElement(prefab, pos, rotation, parent);
			}
			gameObject.transform.SetParent(parent);
			gameObject.transform.SetAsLastSibling();
			gameObject.transform.rotation = rotation;
			gameObject.transform.position = pos;
		}
		gameObject.gameObject.name = prefab.name;
		gameObject.gameObject.SetActive(value: true);
		gameObjectNum[hashCode]++;
		return gameObject;
	}

	public void DisableGameObj(GameObject obj)
	{
		int hashCode = obj.gameObject.name.GetHashCode();
		int index = objPool[hashCode].FindIndex((GameObject i) => i == obj);
		if (objPool[hashCode][index].gameObject.activeInHierarchy)
		{
			gameObjectNum[hashCode]--;
			obj.transform.SetParent(construction.FactoryHolder);
			obj.gameObject.SetActive(value: false);
			GameObject value = objPool[hashCode][gameObjectNum[hashCode]];
			objPool[hashCode][gameObjectNum[hashCode]] = obj;
			objPool[hashCode][index] = value;
		}
	}

	public void DisableElemObj(ElementControl obj)
	{
		obj.enabled = true;
		int num = elementsPool.FindIndex((ElementControl i) => i == obj);
		if (num >= -1 && elementsPool[num].gameObject.activeInHierarchy)
		{
			activeElementsNum--;
			obj.gameObject.SetActive(value: false);
			ElementControl value = elementsPool[activeElementsNum];
			elementsPool[activeElementsNum] = obj;
			elementsPool[num] = value;
		}
	}

	public void DisableBaseBlockObj(BaseBlock obj)
	{
		int hashCode = obj.gameObject.name.GetHashCode();
		obj.enabled = true;
		int index = blocksPool[hashCode].FindIndex((BaseBlock i) => i == obj);
		if (blocksPool[hashCode][index].gameObject.activeInHierarchy)
		{
			activeBlocksNum[hashCode]--;
			obj.transform.SetParent(construction.FactoryHolder);
			obj.gameObject.SetActive(value: false);
			obj.gameObject.GetComponent<BlockData>().SetSelected(state: false, ignoreConditions: true);
			BaseBlock value = blocksPool[hashCode][activeBlocksNum[hashCode]];
			blocksPool[hashCode][activeBlocksNum[hashCode]] = obj;
			blocksPool[hashCode][index] = value;
		}
	}

	public void ClearBaseBlocksPool()
	{
		foreach (List<BaseBlock> value in blocksPool.Values)
		{
			foreach (BaseBlock item in value)
			{
				Object.Destroy(item.gameObject);
			}
		}
		blocksPool.Clear();
		activeBlocksNum.Clear();
	}

	public void DisableChainObj(Chain obj)
	{
		obj.enabled = true;
		int num = chainsPool.FindIndex((Chain i) => i == obj);
		if (num >= 0 && !chainsPool[num].dummy)
		{
			if (currentChain != null && obj == currentChain.GetComponent<Chain>())
			{
				currentChain = null;
			}
			obj.ImgState(state: false);
			obj.gameObject.SetActive(value: false);
			obj.ClearBeforeDelete();
			activeChainsNum--;
			obj.tutorial = false;
			obj.SetDummy(state: true);
			obj.DropValues();
			Chain value = chainsPool[activeChainsNum];
			chainsPool[activeChainsNum] = obj;
			chainsPool[num] = value;
		}
	}

	public Model()
	{
		chainPrefab = Resources.Load("Prefabs/Chain") as GameObject;
	}

	public bool IsQuestDone(string name)
	{
		return curPreview.IsQuestDone(name);
	}

	public bool IsQuestAvailable(string name)
	{
		return curPreview.IsQuestAvailable(name);
	}
}
