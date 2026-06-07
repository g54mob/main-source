using System;
using System.Collections.Generic;
using App.Data;
using DeepTraffic;
using Localization;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.UI;

public class Data : ActiveComponent
{
	[SceneBind("Header/Text")]
	private Text headerText;

	[SceneBind("Header")]
	private Image header;

	[SceneBind("Stats")]
	private Text statsText;

	[SceneBind("Value0")]
	private Text value0;

	[SceneBind("TextLine")]
	private Text textLine;

	[SceneBind("Value1")]
	private Text value1;

	[SceneBind("Value2")]
	private Text value2;

	[SceneBind("TrainCou")]
	private InputField trainCou;

	[SceneBind("TestCou")]
	private InputField testCou;

	[SceneBind("Train0")]
	private InputField train0;

	[SceneBind("Train1")]
	private InputField train1;

	[SceneBind("Train2")]
	private InputField train2;

	private List<InputField> trainList = new List<InputField>();

	[SceneBind("Train")]
	private Text trainText;

	[SceneBind("TestText")]
	private Text testText;

	[SceneBind("TrainText0")]
	private Text text1;

	[SceneBind("TrainText1")]
	private Text text2;

	[SceneBind("TrainText2")]
	private Text text3;

	[SceneBind(":")]
	private Text helpText;

	[SceneBind("HiddenSandbox")]
	private Button ShowData;

	[SceneBind("SocketOpacity")]
	private RectTransform socketGlowObj;

	[SceneBind("Header/HeaderImg")]
	private Image headerImg;

	private List<GameObject> circleImg;

	private List<GameObject> squareImg;

	private List<GameObject> triangleImg;

	private List<List<GameObject>> imageMatrix = new List<List<GameObject>>();

	private List<List<int>> couMatrix = new List<List<int>>();

	private List<List<GameObject>> matrix = new List<List<GameObject>>();

	private List<List<Button>> inputMatrix = new List<List<Button>>();

	private List<Text> textValueList = new List<Text>();

	private List<int> trainColorsCou = new List<int>();

	private List<int> addColorsCou = new List<int>();

	private Socket socket;

	public List<Socket> socketsOut = new List<Socket>();

	private float timer;

	public float delayTimer = 0.01f;

	private float lastActiveTime;

	private int train;

	private int test;

	public int dataNum;

	private CarDatas carDatas;

	private bool play;

	private bool checkElems;

	private float startTime;

	private List<int> dataCounter;

	private List<int> trainData;

	private int full;

	private int trainValue;

	public App.Data.Data data;

	private List<Element> elemQueue = new List<Element>();

	private ConstructionState state;

	private ConstructionQuest cq;

	private SandboxData sbd;

	private CarDatas carDatasBackup;

	private bool disableSocketGlow = true;

	private bool isShow;

	private List<int> colorElements = new List<int>();

	private int[] values = new int[5] { 0, 10, 50, 100, 300 };

	private float delay;

	public void StartupChangePlay()
	{
		play = !play;
		checkElems = play;
		if (play && socket.chain != null)
		{
			delayTimer = Mathf.Max(0f, Logic.GetWorkTimeByKeyName(socket.chain.socketOut.gameObject.transform.parent.gameObject.name, socket.chain.socketOut.num), ActiveComponent._staticData.Settings.ChainTime);
		}
		startTime = Time.unscaledTime;
	}

	public void ChangePlay()
	{
		play = !play;
		checkElems = play;
		if (play && socket.chain != null)
		{
			delayTimer = Mathf.Max(0f, Logic.GetWorkTimeByKeyName(socket.chain.socketOut.gameObject.transform.parent.gameObject.name, socket.chain.socketOut.num), ActiveComponent._staticData.Settings.ChainTime);
		}
		startTime = Time.unscaledTime;
	}

	public void SetBackPlay(bool state, float delayTimer)
	{
		play = state;
		checkElems = play;
		startTime = Time.unscaledTime;
		this.delayTimer = delayTimer;
	}

	private Text GetTextField(CellObjects obj)
	{
		return obj switch
		{
			CellObjects.car => matrix[0][1].GetComponent<Text>(), 
			CellObjects.empty => matrix[1][1].GetComponent<Text>(), 
			CellObjects.wall => matrix[2][1].GetComponent<Text>(), 
			_ => throw new ArgumentException("Got wrong CellObject"), 
		};
	}

	public void InitAsProcessor(CarDatas carDatas)
	{
		headerImg.gameObject.SetActive(value: false);
		textLine.text = "";
		socketGlowObj.gameObject.SetActive(value: false);
		header.gameObject.SetActive(value: true);
		header.color = Logic.GetColor("LIDAR_" + dataNum);
		headerText.text = TextResources.GetString("LIDAR_" + dataNum);
		carDatasBackup = carDatas;
		state = ConstructionState.CarTask;
		this.carDatas = (CarDatas)carDatas.Clone();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				matrix[i][j].SetActive(value: false);
			}
		}
		timer = 0f;
		lastActiveTime = 0f;
		timer = Time.time;
		GenerateCarData();
		for (int k = 0; k < 3; k++)
		{
			circleImg[k].gameObject.SetActive(value: false);
			squareImg[k].gameObject.SetActive(value: true);
			triangleImg[k].gameObject.SetActive(value: false);
		}
		squareImg[0].GetComponent<Image>().sprite = Logic.GetSpriteByKeyName(Logic.GetCarObjectTreeHierarchyByKeyName("car").smallSpriteName);
		squareImg[1].GetComponent<Image>().sprite = Logic.GetSpriteByKeyName(Logic.GetCarObjectTreeHierarchyByKeyName("empty").smallSpriteName);
		squareImg[2].GetComponent<Image>().sprite = Logic.GetSpriteByKeyName(Logic.GetCarObjectTreeHierarchyByKeyName("wall").smallSpriteName);
		CarRedraw();
	}

	public void InitQuest(SandboxData data)
	{
		headerImg.gameObject.SetActive(value: false);
		header.color = Logic.GetColor("DEFAULT_DATA");
		headerText.text = TextResources.GetString("INPUT") + " " + dataNum;
		carDatas = null;
		cq = null;
		sbd = data;
		disableSocketGlow = true;
		socketGlowObj.gameObject.SetActive(value: false);
		state = ConstructionState.SandBox;
		App.Data.Data data2 = (this.data = data.GetDataClone());
		couMatrix.Clear();
		timer = Time.time;
		for (int i = 0; i < 3; i++)
		{
			couMatrix.Add(new List<int>());
			for (int j = 0; j < 3; j++)
			{
				couMatrix[i].Add(0);
				matrix[i][j].SetActive(value: true);
				matrix[i][j].GetComponent<Text>().enabled = true;
			}
		}
		couMatrix[0][0] = data2.RC;
		couMatrix[1][0] = data2.GC;
		couMatrix[2][0] = data2.BC;
		couMatrix[0][1] = data2.RS;
		couMatrix[1][1] = data2.GS;
		couMatrix[2][1] = data2.BS;
		couMatrix[0][2] = data2.RT;
		couMatrix[1][2] = data2.GT;
		couMatrix[2][2] = data2.BT;
		for (int k = 0; k < 3; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				imageMatrix[k][l].GetComponent<Image>().sprite = Logic.GetSpriteByKeyName("SHAPE_H" + l);
			}
		}
		GenerateData(deploy: false);
		RedrawSandbox();
		SetShow(data.IsActive(), sandbox: true);
	}

	public void InitQuest(ConstructionQuest cqt, App.Data.Data d, bool deploy, ConstructionState state)
	{
		if (d == null)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		headerImg.gameObject.SetActive(d.Sprite != "");
		disableSocketGlow = cqt.KeyName != "R/B DIVIDE";
		if (disableSocketGlow)
		{
			socketGlowObj.gameObject.SetActive(value: false);
		}
		socket.Clear();
		ShowData.gameObject.SetActive(value: false);
		header.color = Logic.GetColor("DEFAULT_DATA");
		headerText.text = TextResources.GetString("INPUT") + " " + dataNum;
		if (TextResources.IsKeyExists(cqt.KeyName + "_DATA_" + dataNum))
		{
			headerText.text = TextResources.GetString(cqt.KeyName + "_DATA_" + dataNum);
		}
		carDatas = null;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				matrix[i][j].SetActive(value: true);
			}
		}
		cq = cqt;
		timer = 0f;
		lastActiveTime = 0f;
		this.state = state;
		data = Logic.Clone<App.Data.Data>(d);
		couMatrix.Clear();
		timer = Time.time;
		couMatrix = Logic.GetCouMatrixInData(data, cqt);
		for (int k = 0; k < 3; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				imageMatrix[k][l].GetComponent<Image>().sprite = Logic.GetSpriteByKeyName("SHAPE_H" + l);
			}
		}
		GenerateData(deploy);
		Redraw();
	}

	private void GenerateCarData()
	{
		elemQueue.Clear();
		for (int i = 0; i < carDatas.dummyCar; i++)
		{
			elemQueue.Add(new Element(CellObjects.car));
		}
		for (int j = 0; j < carDatas.emptySpace; j++)
		{
			elemQueue.Add(new Element(CellObjects.empty, "unknown", false, true, 0));
		}
		for (int k = 0; k < carDatas.wall; k++)
		{
			elemQueue.Add(new Element(CellObjects.wall));
		}
		int inputNum = base.gameObject.name[base.gameObject.name.Length - 1] - 48;
		foreach (Element item in elemQueue)
		{
			item.inputNum = inputNum;
		}
		UnityEngine.Random.InitState(carDatas.seed);
		elemQueue.Shuffle();
	}

	private void GenerateData(bool deploy)
	{
		if (data.words != "")
		{
			for (int i = 0; i < 3; i++)
			{
				squareImg[i].SetActive(value: false);
				triangleImg[i].SetActive(value: false);
				circleImg[i].SetActive(value: false);
				for (int j = 0; j < 3; j++)
				{
					matrix[i][j].SetActive(value: false);
				}
			}
		}
		elemQueue.Clear();
		if (data.words == "")
		{
			for (int k = 0; k < 3; k++)
			{
				for (int l = 0; l < 3; l++)
				{
					for (int m = 0; m < couMatrix[k][l]; m++)
					{
						Element item = new Element(k, l, test: false, cq);
						elemQueue.Add(item);
					}
				}
			}
			UnityEngine.Random.InitState(data.RandomSeed);
			for (int n = 0; n < elemQueue.Count; n++)
			{
				Element value = elemQueue[n];
				int index = UnityEngine.Random.Range(0, elemQueue.Count);
				elemQueue[n] = elemQueue[index];
				elemQueue[index] = value;
			}
		}
		else
		{
			GetSumElems();
			List<char> list = new List<char>();
			string truePredict = data.truePredict;
			foreach (char item2 in truePredict)
			{
				list.Add(item2);
			}
			for (int num2 = 0; num2 < data.words.Length - cq.RNNBatch + 1; num2++)
			{
				List<char> list2 = new List<char>();
				list2.Add(data.words[num2]);
				for (int num3 = 1; num3 < cq.RNNBatch; num3++)
				{
					list2.Add(data.words[num2 + num3]);
				}
				Element element = new Element(0, 1, test: false, cq, list2, list, num2);
				element.batchSize = cq.RNNBatch;
				if (data.colorsQueue != "")
				{
					element.colorsQueue = data.colorsQueue;
				}
				elemQueue.Add(element);
			}
		}
		if (state == ConstructionState.SandBox)
		{
			foreach (Element item3 in elemQueue)
			{
				item3.error = UnityEngine.Random.Range(-0.04f, 0.01f);
			}
		}
		else if (cq.OnlyShape == 1)
		{
			elemQueue.ForEach(delegate(Element element2)
			{
				element2.hideColor = true;
			});
		}
		if (deploy || !ActiveComponent.Model.trainTest)
		{
			foreach (Element item4 in elemQueue)
			{
				item4.error = 0f;
			}
		}
		foreach (Element item5 in elemQueue)
		{
			item5.Test = !ActiveComponent.Model.trainTest;
		}
		test = 0;
		train = 0;
		for (int num4 = 0; num4 < trainColorsCou.Count; num4++)
		{
			trainColorsCou[num4] = 0;
			addColorsCou[num4] = 0;
			textValueList[num4].gameObject.SetActive(value: false);
			trainList[num4].gameObject.SetActive(value: false);
		}
		RecalcTrainValue();
	}

	private void RecalcTrainValue()
	{
		trainValue = 0;
		for (int i = 0; i < trainColorsCou.Count; i++)
		{
			trainValue += trainColorsCou[i] + addColorsCou[i];
		}
	}

	public bool IsActive()
	{
		if (state == ConstructionState.SandBox)
		{
			if (!ShowData.gameObject.activeSelf)
			{
				return socket.chain != null;
			}
			return false;
		}
		if (base.gameObject.activeSelf)
		{
			return socket.chain != null;
		}
		return false;
	}

	public void Recalc()
	{
		full = 0;
		foreach (int item in dataCounter)
		{
			full += item;
		}
	}

	public void HideText(bool showBagOfWords = true)
	{
		foreach (List<GameObject> item in matrix)
		{
			foreach (GameObject item2 in item)
			{
				item2.GetComponent<Text>().text = "";
			}
		}
		foreach (List<Button> item3 in inputMatrix)
		{
			foreach (Button item4 in item3)
			{
				item4.gameObject.SetActive(value: false);
			}
		}
		if (showBagOfWords)
		{
			textLine.text = TextResources.GetString("BAG_OF_WORDS");
		}
		else
		{
			textLine.text = "";
		}
	}

	private void HideSelf(bool sandbox = false)
	{
		base.gameObject.SetActive(value: false);
		ShowData.gameObject.SetActive(value: false);
		if (sandbox)
		{
			base.gameObject.SetActive(value: true);
		}
	}

	public bool GetShow()
	{
		return isShow;
	}

	public void SetShow(bool active, bool sandbox = false)
	{
		if (!base.IsInited)
		{
			Init();
		}
		isShow = active;
		if (active)
		{
			base.gameObject.SetActive(value: true);
			ShowData.gameObject.SetActive(value: false);
			return;
		}
		HideSelf(sandbox);
		if (!(socket.chain == null) && !base.gameObject.activeSelf)
		{
			ActiveComponent.Model.DisableChainObj(socket.chain);
		}
	}

	private void Active()
	{
		if (socket.inSocket)
		{
			while (!socket.isEmpty())
			{
				socket.GetElement();
			}
		}
		else if (socket.chain != null)
		{
			if (elemQueue.Count <= 0)
			{
				if (state == ConstructionState.Task && ActiveComponent.Model.trainTest)
				{
					InitQuest(cq, data, deploy: false, state);
				}
				if (state == ConstructionState.Forum && ActiveComponent.Model.trainTest)
				{
					InitQuest(cq, data, deploy: false, state);
				}
				if (state == ConstructionState.Startup)
				{
					InitQuest(cq, data, deploy: false, state);
				}
				if (state == ConstructionState.SandBox)
				{
					InitQuest(sbd);
				}
				if (state == ConstructionState.CarTask)
				{
					InitAsProcessor(carDatasBackup);
				}
			}
			if (socket.chain.isMoving() || socket.isFull())
			{
				return;
			}
			if (elemQueue.Count == 0)
			{
				checkElems = false;
				return;
			}
			if (state != ConstructionState.Startup)
			{
				if (state != ConstructionState.CarTask)
				{
					couMatrix[elemQueue[0].ColorId][elemQueue[0].ShapeId]--;
				}
				else
				{
					switch (elemQueue[0].trueCellObject)
					{
					case CellObjects.car:
						carDatas.dummyCar--;
						break;
					case CellObjects.empty:
						carDatas.emptySpace--;
						break;
					case CellObjects.wall:
						carDatas.wall--;
						break;
					}
				}
			}
			else
			{
				couMatrix[elemQueue[0].ColorId][elemQueue[0].ShapeId]--;
			}
			elemQueue[0].spawnInDataTime = timer;
			socket.SetElement(elemQueue[0], calcStats: false);
			elemQueue.RemoveAt(0);
			if (state == ConstructionState.SandBox)
			{
				RedrawSandbox();
			}
			else if (state == ConstructionState.CarTask)
			{
				CarRedraw();
			}
			else
			{
				Redraw();
			}
		}
		else
		{
			checkElems = false;
		}
	}

	private void ChangeTrain(string str)
	{
		if (int.TryParse(str, out var result))
		{
			train = result;
			return;
		}
		train = 1;
		trainCou.Select();
		trainCou.text = "1";
	}

	private void ChangeTest(string str)
	{
		if (int.TryParse(str, out var result))
		{
			test = result;
			return;
		}
		test = 1;
		testCou.Select();
		testCou.text = "1";
	}

	private void ChangeColorCou(int i)
	{
		if (int.TryParse(trainList[i].text, out var result))
		{
			trainColorsCou[i] = result;
			return;
		}
		trainColorsCou[i] = 1;
		trainList[i].Select();
		trainList[i].text = "1";
	}

	private void ResetData()
	{
		data.RC = couMatrix[0][0];
		data.GC = couMatrix[1][0];
		data.BC = couMatrix[2][0];
		data.RS = couMatrix[0][1];
		data.GS = couMatrix[1][1];
		data.BS = couMatrix[2][1];
		data.RT = couMatrix[0][2];
		data.GT = couMatrix[1][2];
		data.BT = couMatrix[2][2];
	}

	private void ChangeElemCou(int i, int j)
	{
		if (play)
		{
			return;
		}
		_ = inputMatrix[i][j].GetComponentInChildren<Text>().text;
		if (int.TryParse(inputMatrix[i][j].GetComponentInChildren<Text>().text, out var result))
		{
			int num = 0;
			num = 0;
			while (j < values.Length && values[num] != result)
			{
				num++;
			}
			num = (num + 1) % values.Length;
			result = values[num];
			couMatrix[i][j] = Mathf.Min(999, result);
			inputMatrix[i][j].GetComponentInChildren<Text>().text = couMatrix[i][j].ToString();
			ResetData();
			RefreshColors();
		}
		else
		{
			result = values[1];
			couMatrix[i][j] = Mathf.Min(999, result);
			inputMatrix[i][j].GetComponentInChildren<Text>().text = couMatrix[i][j].ToString();
			ResetData();
			RefreshColors();
		}
	}

	private void SandboxActive()
	{
		SetShow(active: true, sandbox: true);
	}

	private void SandboxHide()
	{
		if (state == ConstructionState.SandBox)
		{
			SetShow(active: false, sandbox: true);
		}
	}

	public void InitData()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		ShowData.onClick.AddListener(SandboxActive);
		base.gameObject.GetComponent<Button>().onClick.AddListener(SandboxHide);
		play = false;
		checkElems = false;
		dataCounter = new List<int>();
		imageMatrix.Clear();
		imageMatrix.Add(new List<GameObject>());
		imageMatrix.Add(new List<GameObject>());
		imageMatrix.Add(new List<GameObject>());
		circleImg = new List<GameObject>();
		squareImg = new List<GameObject>();
		triangleImg = new List<GameObject>();
		for (int i = 0; i < 3; i++)
		{
			circleImg.Add(base.gameObject.transform.Find("Circle" + i).gameObject);
			squareImg.Add(base.gameObject.transform.Find("Square" + i).gameObject);
			triangleImg.Add(base.gameObject.transform.Find("Triangle" + i).gameObject);
			imageMatrix[i].Add(circleImg[i]);
			imageMatrix[i].Add(squareImg[i]);
			imageMatrix[i].Add(triangleImg[i]);
			matrix.Add(new List<GameObject>());
			inputMatrix.Add(new List<Button>());
			for (int j = 0; j < 3; j++)
			{
				matrix[i].Add(base.gameObject.transform.Find(i.ToString() + j).gameObject);
				inputMatrix[i].Add(matrix[i][j].GetComponentInChildren<Button>());
				int newI = i;
				int newJ = j;
				inputMatrix[i][j].GetComponent<Button>().onClick.AddListener(delegate
				{
					ChangeElemCou(newI, newJ);
				});
			}
		}
		socket = base.transform.Find("Socket").GetComponent<Socket>();
		for (int num = 0; num < 5; num++)
		{
			socketsOut.Add(null);
		}
		socketsOut[2] = socket;
		RecalcTrainValue();
	}

	private void RedrawSandbox()
	{
		textLine.text = "";
		for (int i = 0; i < 3; i++)
		{
			circleImg[i].gameObject.SetActive(value: true);
			circleImg[i].GetComponent<Image>().color = Logic.GetColor(i);
			squareImg[i].gameObject.SetActive(value: true);
			squareImg[i].GetComponent<Image>().color = Logic.GetColor(i);
			triangleImg[i].gameObject.SetActive(value: true);
			triangleImg[i].GetComponent<Image>().color = Logic.GetColor(i);
		}
		for (int j = 0; j < 3; j++)
		{
			circleImg[j].gameObject.SetActive(value: true);
			squareImg[j].gameObject.SetActive(value: true);
			triangleImg[j].gameObject.SetActive(value: true);
			squareImg[j].GetComponent<Image>().color = Logic.GetColor(j);
		}
		for (int k = 0; k < 3; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				matrix[k][l].gameObject.GetComponent<SelectHighlighter>().enabled = true;
				inputMatrix[k][l].gameObject.SetActive(value: true);
				if (state != ConstructionState.CarTask)
				{
					inputMatrix[k][l].gameObject.GetComponentInChildren<Text>().text = couMatrix[k][l].ToString();
				}
				else
				{
					inputMatrix[k][l].gameObject.GetComponentInChildren<Text>().text = "";
				}
			}
		}
		RefreshColors();
	}

	private void RefreshColors()
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (couMatrix[i][j] == 0)
				{
					imageMatrix[i][j].GetComponent<Image>().color = Logic.GetColor("GRAYUNDERBLOCK");
					inputMatrix[i][j].GetComponentInChildren<Text>().text = "";
					matrix[i][j].GetComponent<Text>().text = "";
				}
				else
				{
					matrix[i][j].GetComponent<Text>().text = couMatrix[i][j].ToString();
					imageMatrix[i][j].GetComponent<Image>().color = Logic.GetColor(i);
				}
				if (state == ConstructionState.CarTask)
				{
					inputMatrix[i][j].GetComponentInChildren<Text>().text = "";
					matrix[i][j].GetComponent<Text>().text = "";
				}
			}
		}
		if (state == ConstructionState.SandBox || cq.OnlyShape != 1)
		{
			return;
		}
		for (int k = 0; k < 3; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				if (couMatrix[k][l] == 0)
				{
					imageMatrix[k][l].GetComponent<Image>().color = Logic.GetColor("GRAYUNDERBLOCK");
				}
				else
				{
					imageMatrix[k][l].GetComponent<Image>().color = Logic.GetColor("WHITE");
				}
			}
		}
	}

	private int GetSumElems()
	{
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				num += couMatrix[i][j];
			}
		}
		return Mathf.Min(num, data.words.Length);
	}

	private void CarRedraw()
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				matrix[i][j].gameObject.GetComponent<SelectHighlighter>().enabled = false;
			}
		}
		Text textField = GetTextField(CellObjects.car);
		textField.gameObject.SetActive(value: true);
		textField.text = "";
		squareImg[0].GetComponent<Image>().color = ((carDatas.dummyCar == 0) ? Logic.GetColor("GRAYUNDERBLOCK") : new Color(1f, 1f, 1f));
		Text textField2 = GetTextField(CellObjects.empty);
		textField2.gameObject.SetActive(value: true);
		textField2.text = "";
		squareImg[1].GetComponent<Image>().color = ((carDatas.emptySpace == 0) ? Logic.GetColor("GRAYUNDERBLOCK") : new Color(1f, 1f, 1f));
		Text textField3 = GetTextField(CellObjects.wall);
		textField3.gameObject.SetActive(value: true);
		textField3.text = "";
		squareImg[2].GetComponent<Image>().color = ((carDatas.wall == 0) ? Logic.GetColor("GRAYUNDERBLOCK") : new Color(1f, 1f, 1f));
	}

	private void Redraw()
	{
		textLine.text = "";
		for (int i = 0; i < 3; i++)
		{
			circleImg[i].gameObject.SetActive(value: true);
			circleImg[i].GetComponent<Image>().color = Logic.GetColor(i);
			squareImg[i].gameObject.SetActive(value: true);
			squareImg[i].GetComponent<Image>().color = Logic.GetColor(i);
			triangleImg[i].gameObject.SetActive(value: true);
			triangleImg[i].GetComponent<Image>().color = Logic.GetColor(i);
		}
		if (cq.OnlyColor == 1)
		{
			for (int j = 0; j < 3; j++)
			{
				circleImg[j].gameObject.SetActive(value: false);
				triangleImg[j].gameObject.SetActive(value: false);
				squareImg[j].GetComponent<Image>().color = Logic.GetColor(j);
			}
		}
		if (cq.OnlyColor == 0 && cq.OnlyShape == 0)
		{
			for (int k = 0; k < 3; k++)
			{
				circleImg[k].gameObject.SetActive(value: true);
				squareImg[k].gameObject.SetActive(value: true);
				triangleImg[k].gameObject.SetActive(value: true);
				squareImg[k].GetComponent<Image>().color = Logic.GetColor(k);
			}
		}
		if (cq.OnlyShape == 1)
		{
			for (int l = 0; l < 3; l++)
			{
				circleImg[l].gameObject.SetActive(value: false);
				squareImg[l].gameObject.SetActive(value: false);
				triangleImg[l].gameObject.SetActive(value: false);
				circleImg[l].GetComponent<Image>().color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
				squareImg[l].GetComponent<Image>().color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
				triangleImg[l].GetComponent<Image>().color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
			}
			circleImg[1].gameObject.SetActive(value: true);
			squareImg[1].gameObject.SetActive(value: true);
			triangleImg[1].gameObject.SetActive(value: true);
		}
		if (data.words != "")
		{
			for (int m = 0; m < 3; m++)
			{
				circleImg[m].gameObject.SetActive(value: false);
				squareImg[m].gameObject.SetActive(value: false);
				triangleImg[m].gameObject.SetActive(value: false);
			}
			if (elemQueue.Count > 0)
			{
				int sumElems = GetSumElems();
				string text = "<color=#00ffffff>" + Logic.WordToString(elemQueue[0].word) + "</color>";
				for (int n = elemQueue[0].iterWord + cq.RNNBatch; n < Mathf.Min(sumElems, elemQueue[0].iterWord + cq.RNNBatch + 2); n++)
				{
					text += data.words[n];
				}
				int num = elemQueue[0].iterWord - 2;
				string text2 = "";
				for (int num2 = Mathf.Max(0, num); num2 < Mathf.Min(num + 2, elemQueue[0].iterWord); num2++)
				{
					text2 += data.words[num2];
				}
				text = text2 + text;
				textLine.text = text.ToUpper();
			}
		}
		for (int num3 = 0; num3 < 3; num3++)
		{
			for (int num4 = 0; num4 < 3; num4++)
			{
				inputMatrix[num3][num4].gameObject.SetActive(value: false);
				matrix[num3][num4].gameObject.GetComponent<SelectHighlighter>().enabled = false;
				if ((cq.OnlyColor == 1 && num4 != 1) || state == ConstructionState.CarTask)
				{
					matrix[num3][num4].GetComponent<Text>().text = "";
				}
				else
				{
					matrix[num3][num4].GetComponent<Text>().text = couMatrix[num3][num4].ToString();
				}
			}
		}
		if (cq.OnlyShape == 1)
		{
			matrix[0][0].GetComponent<Text>().text = "";
			matrix[0][1].GetComponent<Text>().text = "";
			matrix[0][2].GetComponent<Text>().text = "";
			matrix[2][0].GetComponent<Text>().text = "";
			matrix[2][1].GetComponent<Text>().text = "";
			matrix[2][2].GetComponent<Text>().text = "";
		}
		RefreshColors();
	}

	private void FixedUpdate()
	{
		if (!disableSocketGlow)
		{
			socketGlowObj.gameObject.SetActive(socket.chain == null && ActiveComponent.Model.construction.blocksInScheme.Count > 0);
		}
		if (ActiveComponent.Model != null)
		{
			timer += Time.deltaTime * ActiveComponent.Model.curSpeed;
		}
		if (play && checkElems)
		{
			delay = timer - lastActiveTime;
			if (Mathf.Abs(delay - delayTimer) < 0.01f || delay >= delayTimer)
			{
				Active();
				lastActiveTime = timer;
			}
		}
	}
}
