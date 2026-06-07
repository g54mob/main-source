using System.Collections.Generic;
using App.Data;
using DeepTraffic;
using Localization;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.UI;

public class Result : ActiveComponent
{
	[SceneBind("Header/Text")]
	private Text header;

	private Socket socketIn;

	public List<Socket> socketsIn = new List<Socket>();

	private List<List<int>> couMatrix = new List<List<int>>();

	private List<List<GameObject>> matrix = new List<List<GameObject>>();

	private bool[] carObjectIndicators = new bool[DeepTrafficStatic.cellObjectSize];

	private Dictionary<string, int>[] trueObjCount = new Dictionary<string, int>[5];

	private Dictionary<string, int>[] totalObjCount = new Dictionary<string, int>[5];

	[SceneBind("Result")]
	private Text resText;

	[SceneBind("OccBar/OccImg")]
	private Image occImg;

	[SceneBind("OccBar/TimeImg")]
	private Image timeImg;

	[SceneBind("Accuracy")]
	private Text accText;

	[SceneBind("AnswerShow")]
	private Text AnswerShow;

	[SceneBind("Occupancy")]
	private Text occText;

	[SceneBind("ReqImg")]
	private Image reqImg;

	[SceneBind("CurImg")]
	private Image curImg;

	[SceneBind("Circle")]
	private Image circleImg;

	[SceneBind("Square")]
	private Image squareImg;

	[SceneBind("Triangle")]
	private Image triangleImg;

	[SceneBind("OccBar")]
	private CustomProgressBar OccBar;

	[SceneBind("OccBar/TimeImg")]
	private Image occBarTimeImg;

	[SceneBind("AccBar")]
	private CustomProgressBar AccBar;

	[SceneBind("AccOnly")]
	private Image accOnly;

	[SceneBind("Proc")]
	private Image Proc;

	[SceneBind("AccBasic")]
	private Image accBasic;

	[SceneBind("HiddenSandbox")]
	private Button ShowResult;

	[SceneBind("Shadow")]
	private Image shadowImage;

	[SceneBind("LeftFrontBorderImage")]
	private Image leftFrontBorderImage;

	[SceneBind("FrontResultBorderImage")]
	private Image frontResultBorderImage;

	[SceneBind("ResultBehindBorderImage")]
	private Image resultBehindBorderImage;

	[SceneBind("BehindRightBorderImage")]
	private Image behindRightBorderImage;

	[SceneBind("RightBorderImage")]
	private Image rightBorderImage;

	[SceneBind("LeftStatisticTable")]
	private StatisticTableController leftStatisticController;

	[SceneBind("FrontStatisticTable")]
	private StatisticTableController frontStatisticController;

	[SceneBind("BehindStatisticTable")]
	private StatisticTableController behindStatisticController;

	[SceneBind("RightStatisticTable")]
	private StatisticTableController rightSatisticController;

	[SceneBind("SocketOpacity")]
	private RectTransform socketGlowObj;

	[SceneBind("Header/HeaderImg")]
	private Image headerImg;

	public int resultNum;

	private StatisticTableController[] statisticControllers = new StatisticTableController[5];

	private float timer;

	private float delayTimer = 1E-07f;

	private float lastActiveTime;

	private List<int> NeedColors;

	private List<int> CurColors;

	private List<float> inTimers = new List<float>();

	public int accuracy;

	private bool play;

	private bool isOccDisabled;

	private int cur = -1;

	public float need;

	public float avarageGoTime;

	private bool deploy;

	private bool wasInit;

	public App.Data.Result result;

	private string ansText = "";

	private ConstructionState state;

	private ConstructionQuest cq;

	private SandboxResult sbr;

	private bool disableSocketGlow = true;

	public int curElems;

	private int falseElems;

	private bool start;

	public GameObject[] ClassifierStatistics
	{
		get
		{
			GameObject[] array = new GameObject[5];
			for (int i = 0; i < 5; i++)
			{
				array[i] = ((statisticControllers[i] == null || !statisticControllers[i].gameObject.activeSelf) ? null : statisticControllers[i].gameObject);
			}
			return array;
		}
	}

	private void UpdateStats(int id, CellObjects trueObj, string predictedObj)
	{
		using IEnumerator<string> enumerator = CarObjectTree.MoveToRoot(trueObj);
		do
		{
			string text = enumerator.Current;
			if (text == null)
			{
				text = CarObjectTree.GetNameByCellObject(trueObj);
			}
			if (!totalObjCount[id].ContainsKey(text))
			{
				totalObjCount[id][text] = 1;
			}
			else
			{
				Dictionary<string, int> obj = totalObjCount[id];
				string key = text;
				int value = obj[key] + 1;
				obj[key] = value;
			}
			if (text == predictedObj)
			{
				if (text != "unknown")
				{
					if (!trueObjCount[id].ContainsKey(text))
					{
						trueObjCount[id][text] = 1;
					}
					else
					{
						Dictionary<string, int> obj2 = trueObjCount[id];
						string key = text;
						int value = obj2[key] + 1;
						obj2[key] = value;
					}
					statisticControllers[id].SetPrecision(text, (float)trueObjCount[id][text] / (float)totalObjCount[id][text]);
				}
				break;
			}
			if (!trueObjCount[id].ContainsKey(text))
			{
				trueObjCount[id][text] = 0;
			}
			statisticControllers[id].SetPrecision(text, (float)trueObjCount[id][text] / (float)totalObjCount[id][text]);
		}
		while (enumerator.MoveNext());
	}

	private void SetOccText(string text, Color color)
	{
		occText.text = text;
		if (!isOccDisabled)
		{
			occText.color = color;
		}
	}

	public bool End()
	{
		if (state == ConstructionState.CarTask)
		{
			return curElems >= (int)need;
		}
		if (state == ConstructionState.SandBox)
		{
			return false;
		}
		if (state == ConstructionState.Startup)
		{
			return false;
		}
		if (accuracy < result.Accuracy)
		{
			return false;
		}
		if (cq.OnlyAcc == 0)
		{
			if ((float)curElems < need)
			{
				return false;
			}
		}
		else
		{
			if (!deploy && ActiveComponent.Model.trainTest)
			{
				return false;
			}
			if ((double)need > 0.01)
			{
				return false;
			}
		}
		return true;
	}

	public void ClearLines()
	{
		socketIn.DropInChains();
	}

	public void Clear()
	{
		CurColors.Clear();
		for (int i = 0; i < ActiveComponent._staticData.Colors.Count; i++)
		{
			CurColors.Add(0);
		}
		AccBar.Clear();
		OccBar.Clear();
		accuracy = 0;
		curElems = 0;
		falseElems = 0;
		if (state != ConstructionState.SandBox)
		{
			if (state == ConstructionState.CarTask)
			{
				CarRedraw();
			}
			else
			{
				Redraw(RedrawEnum.Full);
			}
		}
		else
		{
			RedrawSandbox();
		}
		inTimers.Clear();
	}

	public void Sleep()
	{
		start = false;
	}

	public void InitAsProcessor(bool start, int need, string[] statLists)
	{
		if (Proc != null)
		{
			Proc.gameObject.SetActive(value: true);
		}
		headerImg.gameObject.SetActive(value: false);
		socketGlowObj.gameObject.SetActive(value: false);
		header.text = TextResources.GetString("CAR_PROCESSOR");
		state = ConstructionState.CarTask;
		lastActiveTime = 0f;
		SceneBindContainer.BindObjects(this, base.transform);
		ansText = "";
		timer = Time.time;
		avarageGoTime = 0f;
		this.need = need;
		timeImg.gameObject.SetActive(value: false);
		curElems = 0;
		for (int i = 0; i < 5; i++)
		{
			trueObjCount[i] = new Dictionary<string, int>();
			totalObjCount[i] = new Dictionary<string, int>();
		}
		for (int j = 0; j < 3; j++)
		{
			for (int k = 0; k < 3; k++)
			{
				matrix[j][k].GetComponent<Button>().onClick.RemoveAllListeners();
				matrix[j][k].SetActive(value: false);
			}
		}
		OccBar.gameObject.SetActive(value: true);
		OccBar.Clear();
		occText.gameObject.SetActive(value: true);
		SetOccText(need.ToString(), Logic.GetColor("ACCURACY"));
		AccBar.gameObject.SetActive(value: false);
		accText.gameObject.SetActive(value: false);
		for (int l = 0; l < carObjectIndicators.Length; l++)
		{
			carObjectIndicators[l] = true;
		}
		wasInit = true;
		this.start = start;
		statisticControllers[0] = leftStatisticController;
		statisticControllers[1] = frontStatisticController;
		statisticControllers[2] = null;
		statisticControllers[3] = behindStatisticController;
		statisticControllers[4] = rightSatisticController;
		List<Data> datas = ActiveComponent.Model.construction.datas;
		for (int m = 0; m < 5; m++)
		{
			if (statisticControllers[m] != null)
			{
				if (datas[m].GetShow())
				{
					statisticControllers[m].gameObject.SetActive(value: true);
					statisticControllers[m].Init(statLists[m]);
				}
				else
				{
					statisticControllers[m].gameObject.SetActive(value: false);
				}
			}
		}
		shadowImage.gameObject.SetActive(value: false);
		leftStatisticController.gameObject.SetActive(value: false);
		frontStatisticController.gameObject.SetActive(value: false);
		behindStatisticController.gameObject.SetActive(value: false);
		rightSatisticController.gameObject.SetActive(value: false);
		ShowResult.gameObject.SetActive(value: false);
		CarRedraw();
	}

	public void InitQuest(SandboxResult result, bool testMode)
	{
		socketGlowObj.gameObject.SetActive(value: false);
		AccBar.gameObject.SetActive(value: true);
		accText.gameObject.SetActive(value: true);
		headerImg.gameObject.SetActive(value: false);
		header.text = TextResources.GetString("OUTPUT") + " " + resultNum;
		statisticControllers[0] = leftStatisticController;
		statisticControllers[1] = frontStatisticController;
		statisticControllers[2] = null;
		statisticControllers[3] = behindStatisticController;
		statisticControllers[4] = rightSatisticController;
		for (int i = 0; i < 5; i++)
		{
			if (statisticControllers[i] != null)
			{
				statisticControllers[i].gameObject.SetActive(value: false);
			}
		}
		if (Proc != null)
		{
			Proc.gameObject.SetActive(value: false);
		}
		sbr = result;
		state = ConstructionState.SandBox;
		cq = null;
		timer = 0f;
		lastActiveTime = 0f;
		SceneBindContainer.BindObjects(this, base.transform);
		this.result = result.GetResultClone();
		ansText = "";
		start = testMode;
		wasInit = true;
		timer = Time.time;
		avarageGoTime = 0f;
		need = 0f;
		couMatrix.Clear();
		for (int j = 0; j < 3; j++)
		{
			couMatrix.Add(new List<int>());
			for (int k = 0; k < 3; k++)
			{
				couMatrix[j].Add(0);
				int newI = j;
				int newJ = k;
				matrix[j][k].GetComponent<Button>().onClick.RemoveAllListeners();
				matrix[j][k].GetComponent<Button>().onClick.AddListener(delegate
				{
					ChangeElemCou(newI, newJ);
				});
			}
		}
		for (int num = 0; num < 3; num++)
		{
			for (int num2 = 0; num2 < 3; num2++)
			{
				matrix[num][num2].GetComponentsInChildren<Image>()[1].sprite = Logic.GetSpriteByKeyName("SHAPE" + num2);
			}
		}
		UpdateSprites(activeElement: true);
		couMatrix[0][0] = this.result.RC;
		couMatrix[1][0] = this.result.GC;
		couMatrix[2][0] = this.result.BC;
		couMatrix[0][1] = this.result.RS;
		couMatrix[1][1] = this.result.GS;
		couMatrix[2][1] = this.result.BS;
		couMatrix[0][2] = this.result.RT;
		couMatrix[1][2] = this.result.GT;
		couMatrix[2][2] = this.result.BT;
		RedrawSandbox();
		SetShow(result.IsActive(), sandbox: true);
		shadowImage.gameObject.SetActive(value: true);
		if (leftFrontBorderImage != null)
		{
			leftFrontBorderImage.gameObject.SetActive(value: false);
			frontResultBorderImage.gameObject.SetActive(value: false);
			resultBehindBorderImage.gameObject.SetActive(value: false);
			behindRightBorderImage.gameObject.SetActive(value: false);
			rightBorderImage.gameObject.SetActive(value: false);
		}
	}

	private void SetOccColor(Color color)
	{
		occText.color = color;
		occBarTimeImg.color = color;
		OccBar.GetComponent<Image>().color = color;
	}

	public void RedrawSandbox()
	{
		if (curElems == 0)
		{
			accuracy = 0;
		}
		else
		{
			accuracy = (int)(100f * (float)(curElems - falseElems) / (float)curElems);
		}
		accText.text = Logic.ColorTransform("ACCURACY", result.Accuracy.ToString());
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				matrix[i][j].GetComponentsInChildren<Image>()[1].color = Logic.GetColor(i);
				matrix[i][j].GetComponentsInChildren<Image>()[1].enabled = couMatrix[i][j] > 0;
				matrix[i][j].SetActive(value: true);
			}
		}
		accText.transform.SetParent(accOnly.transform);
		accText.transform.localPosition = new Vector3(0f, accText.transform.localPosition.y, 0f);
		AccBar.transform.SetParent(accOnly.transform);
		AccBar.transform.localPosition = new Vector3(0f, AccBar.transform.localPosition.y, 0f);
		OccBar.gameObject.SetActive(value: false);
		occText.gameObject.SetActive(value: false);
		if (curElems == 0)
		{
			accuracy = 0;
		}
		else
		{
			accuracy = (int)(100f * (float)(curElems - falseElems) / (float)curElems);
		}
		accText.text = Logic.ColorTransform("ACCURACY", accuracy.ToString());
		AccBar.SetPercantage((float)accuracy / 100f);
		AccBar.HideBorder();
		AnswerShow.text = "";
	}

	public void InitQuest(ConstructionQuest cqt, App.Data.Result res, bool dep, ConstructionState state, bool testMode)
	{
		header.text = TextResources.GetString("OUTPUT") + " " + resultNum;
		AccBar.gameObject.SetActive(value: true);
		accText.gameObject.SetActive(value: true);
		headerImg.gameObject.SetActive(res.Sprite != "");
		if (TextResources.IsKeyExists(cqt.KeyName + "_RESULT_" + resultNum))
		{
			header.text = TextResources.GetString(cqt.KeyName + "_RESULT_" + resultNum);
		}
		disableSocketGlow = cqt.KeyName != "R/B DIVIDE";
		if (disableSocketGlow)
		{
			socketGlowObj.gameObject.SetActive(value: false);
		}
		statisticControllers[0] = leftStatisticController;
		statisticControllers[1] = frontStatisticController;
		statisticControllers[2] = null;
		statisticControllers[3] = behindStatisticController;
		statisticControllers[4] = rightSatisticController;
		for (int i = 0; i < 5; i++)
		{
			if (statisticControllers[i] != null)
			{
				statisticControllers[i].gameObject.SetActive(value: false);
			}
		}
		if (Proc != null)
		{
			Proc.gameObject.SetActive(value: false);
		}
		occImg.gameObject.SetActive(cqt.OnlyAcc == 0);
		timeImg.gameObject.SetActive(cqt.OnlyAcc == 1);
		cq = cqt;
		this.state = state;
		timer = 0f;
		lastActiveTime = 0f;
		SceneBindContainer.BindObjects(this, base.transform);
		result = res;
		ansText = "";
		start = testMode;
		wasInit = true;
		timer = Time.time;
		avarageGoTime = 0f;
		need = 0f;
		deploy = dep;
		couMatrix.Clear();
		for (int j = 0; j < 3; j++)
		{
			couMatrix.Add(new List<int>());
			for (int k = 0; k < 3; k++)
			{
				couMatrix[j].Add(0);
			}
		}
		if (cq.OnlyColor == 1)
		{
			couMatrix[0][1] = res.RC + res.RS + res.RT;
			couMatrix[1][1] = res.GC + res.GS + res.GT;
			couMatrix[2][1] = res.BC + res.BS + res.BT;
		}
		else
		{
			couMatrix[0][0] = res.RC;
			couMatrix[1][0] = res.GC;
			couMatrix[2][0] = res.BC;
			couMatrix[0][1] = res.RS;
			couMatrix[1][1] = res.GS;
			couMatrix[2][1] = res.BS;
			couMatrix[0][2] = res.RT;
			couMatrix[1][2] = res.GT;
			couMatrix[2][2] = res.BT;
		}
		if (cq.OnlyShape == 1)
		{
			couMatrix.Clear();
			for (int l = 0; l < 3; l++)
			{
				couMatrix.Add(new List<int>());
				for (int m = 0; m < 3; m++)
				{
					couMatrix[l].Add(0);
				}
			}
			couMatrix[1][0] = res.RC + res.GC + res.BC;
			couMatrix[1][1] = res.RS + res.GS + res.BS;
			couMatrix[1][2] = res.RT + res.GT + res.BT;
		}
		for (int n = 0; n < 3; n++)
		{
			for (int num = 0; num < 3; num++)
			{
				need += couMatrix[n][num];
				matrix[n][num].GetComponent<Button>().onClick.RemoveAllListeners();
				if (cq.OnlyColor == 1)
				{
					matrix[n][num].SetActive(value: false);
				}
				else if (couMatrix[n][num] > 0)
				{
					matrix[n][num].GetComponentsInChildren<Image>()[1].enabled = true;
				}
				else
				{
					matrix[n][num].GetComponentsInChildren<Image>()[1].enabled = false;
				}
			}
		}
		OccBar.gameObject.SetActive(value: true);
		occText.gameObject.SetActive(value: true);
		occBarTimeImg.color = Color.white;
		OccBar.GetComponent<Image>().color = Logic.GetColor("STATBAR_COLOR");
		isOccDisabled = false;
		accText.gameObject.SetActive(value: true);
		AccBar.gameObject.SetActive(value: true);
		if (ActiveComponent.Model.trainTest)
		{
			SetOccColor(Logic.GetColor("NEWS"));
			isOccDisabled = true;
			if (state == ConstructionState.Startup)
			{
				OccBar.gameObject.SetActive(value: false);
				occText.gameObject.SetActive(value: false);
			}
		}
		else if (!deploy && state == ConstructionState.Startup)
		{
			accText.transform.SetParent(accOnly.transform);
			accText.transform.localPosition = new Vector3(0f, accText.transform.localPosition.y, 0f);
			AccBar.transform.SetParent(accOnly.transform);
			AccBar.transform.localPosition = new Vector3(0f, AccBar.transform.localPosition.y, 0f);
			accText.transform.SetParent(base.transform);
			AccBar.transform.SetParent(base.transform);
			OccBar.gameObject.SetActive(value: false);
			occText.gameObject.SetActive(value: false);
		}
		else
		{
			accText.transform.SetParent(accBasic.transform);
			accText.transform.localPosition = new Vector3(0f, accText.transform.localPosition.y, 0f);
			AccBar.transform.SetParent(accBasic.transform);
			AccBar.transform.localPosition = new Vector3(0f, AccBar.transform.localPosition.y, 0f);
			accText.transform.SetParent(base.transform);
			AccBar.transform.SetParent(base.transform);
		}
		if (cq.OnlyAcc == 1)
		{
			need = cq.TimeTrueAcc;
		}
		if (result.words != "")
		{
			need = result.words.Length;
		}
		inTimers.Clear();
		UpdateSprites();
		shadowImage.gameObject.SetActive(value: true);
		if (leftFrontBorderImage != null)
		{
			leftFrontBorderImage.gameObject.SetActive(value: false);
			frontResultBorderImage.gameObject.SetActive(value: false);
			resultBehindBorderImage.gameObject.SetActive(value: false);
			behindRightBorderImage.gameObject.SetActive(value: false);
			rightBorderImage.gameObject.SetActive(value: false);
		}
		Redraw(RedrawEnum.Full);
	}

	private void UpdateSprites(bool activeElement = false)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				Image[] componentsInChildren = matrix[i][j].GetComponentsInChildren<Image>();
				matrix[i][j].gameObject.GetComponent<SelectHighlighter>().enabled = activeElement;
				Image[] array = componentsInChildren;
				for (int k = 0; k < array.Length; k++)
				{
					array[k].sprite = Logic.GetSpriteByKeyName("SHAPE_H" + j);
				}
			}
		}
	}

	private void Active()
	{
		Element element = socketIn.GetElement();
		if (element == null)
		{
			return;
		}
		avarageGoTime = avarageGoTime * (float)curElems - element.spawnInDataTime + timer;
		curElems++;
		avarageGoTime /= curElems;
		if (element.word != null && result.words != "")
		{
			int num = 0;
			foreach (char item in element.word)
			{
				if (result.words[(curElems - 1) % result.words.Length] != item)
				{
					falseElems++;
					ansText += Logic.ColorTransform("GREY", item.ToString());
				}
				else
				{
					ansText += Logic.ColorTransform("GOOD", item.ToString());
				}
				num++;
			}
		}
		else if (element.isCarElem)
		{
			UpdateStats(element.inputNum, element.trueCellObject, element.predictedObject);
		}
		else if (couMatrix[element.ColorId][element.ShapeId] <= 0 || !element.revealed)
		{
			falseElems++;
		}
		if (ActiveComponent.Model.constructionState == ConstructionState.Startup)
		{
			inTimers.Add(timer);
		}
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
			Redraw(RedrawEnum.Full);
		}
	}

	public int GetStartupUsersInDay()
	{
		return inTimers.Count;
	}

	public bool IsActive()
	{
		if (state == ConstructionState.SandBox)
		{
			if (!ShowResult.gameObject.activeSelf)
			{
				return socketIn.HasChains();
			}
			return false;
		}
		if (base.gameObject.activeSelf)
		{
			return socketIn.HasChains();
		}
		return false;
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

	private void ResetResult()
	{
		result.RC = couMatrix[0][0];
		result.GC = couMatrix[1][0];
		result.BC = couMatrix[2][0];
		result.RS = couMatrix[0][1];
		result.GS = couMatrix[1][1];
		result.BS = couMatrix[2][1];
		result.RT = couMatrix[0][2];
		result.GT = couMatrix[1][2];
		result.BT = couMatrix[2][2];
	}

	private void ChangeElemCou(int id, int jd)
	{
		couMatrix[id][jd] = 1 - couMatrix[id][jd];
		ResetResult();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				matrix[i][j].GetComponentsInChildren<Image>()[1].enabled = couMatrix[i][j] > 0;
			}
		}
	}

	private void Awake()
	{
		start = false;
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		SceneBindContainer.BindObjects(this, base.transform);
		base.gameObject.GetComponent<Button>().onClick.AddListener(SandboxHide);
		ShowResult.onClick.AddListener(SandboxActive);
		for (int i = 0; i < 3; i++)
		{
			matrix.Add(new List<GameObject>());
			for (int j = 0; j < 3; j++)
			{
				matrix[i].Add(base.gameObject.transform.Find(i.ToString() + j).gameObject);
			}
		}
		NeedColors = new List<int>();
		CurColors = new List<int>();
		for (int k = 0; k < 5; k++)
		{
			socketsIn.Add(null);
		}
		socketsIn[2] = socketIn;
	}

	private void FixedUpdate()
	{
		if (!wasInit)
		{
			return;
		}
		if (start)
		{
			timer += Time.deltaTime * ActiveComponent.Model.curSpeed;
			if (ActiveComponent.Model.constructionState == ConstructionState.Startup && inTimers.Count > 0 && inTimers[0] < timer - ActiveComponent.Model.curStartup.DayTime)
			{
				inTimers.RemoveAt(0);
			}
			while (socketIn.queue.Count > 0)
			{
				Active();
			}
			if (state != ConstructionState.SandBox && state != ConstructionState.CarTask && cq.OnlyAcc == 1)
			{
				if (curElems > 0 && accuracy >= result.Accuracy)
				{
					need -= Time.deltaTime * ActiveComponent.Model.curSpeed;
					need = Mathf.Max(0f, need);
				}
				else
				{
					need = cq.TimeTrueAcc;
				}
			}
			Redraw();
		}
		if (!disableSocketGlow)
		{
			socketGlowObj.gameObject.SetActive(socketIn.inChains.Count == 0 && ActiveComponent.Model.construction.blocksInScheme.Count > 0);
		}
	}

	private void HideSelf(bool sandbox = false)
	{
		base.gameObject.SetActive(value: false);
		ShowResult.gameObject.SetActive(value: false);
		if (sandbox)
		{
			base.gameObject.SetActive(value: true);
		}
	}

	public void SetShow(bool active, bool sandbox = false)
	{
		if (active)
		{
			base.gameObject.SetActive(value: true);
			ShowResult.gameObject.SetActive(value: false);
			return;
		}
		HideSelf(sandbox);
		if (!(socketIn.chain == null))
		{
			ActiveComponent.Model.DisableChainObj(socketIn.chain);
		}
	}

	private void Redraw(RedrawEnum redrawState = RedrawEnum.States)
	{
		ShowResult.gameObject.SetActive(value: false);
		if (cq == null)
		{
			return;
		}
		if (cq.OnlyAcc == 0)
		{
			SetOccText(need.ToString(), Logic.GetColor("ACCURACY"));
		}
		else
		{
			SetOccText(need.ToString("N1"), Logic.GetColor("TIME"));
		}
		string text = "";
		for (int i = Mathf.Max(0, ansText.Length - 120); i < ansText.Length; i++)
		{
			text += ansText[i];
		}
		AnswerShow.text = text.ToUpper();
		if (curElems == 0)
		{
			accuracy = 0;
		}
		else
		{
			accuracy = (int)(100f * (float)(curElems - falseElems) / (float)curElems);
		}
		accText.text = Logic.ColorTransform("ACCURACY", result.Accuracy + "%");
		if (redrawState == RedrawEnum.Full)
		{
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					matrix[j][k].SetActive(value: true);
					matrix[j][k].GetComponentsInChildren<Image>()[1].color = Logic.GetColor(j);
					matrix[j][k].GetComponentsInChildren<Image>()[1].enabled = couMatrix[j][k] > 0;
					if (cq.OnlyColor == 1)
					{
						if (couMatrix[j][k] > 0)
						{
							matrix[j][k].SetActive(value: true);
							matrix[j][k].GetComponent<Text>().text = "";
							matrix[j][k].GetComponentsInChildren<Image>()[1].enabled = true;
						}
						else
						{
							matrix[j][k].SetActive(value: true);
							matrix[j][k].GetComponent<Text>().text = "";
							matrix[j][k].GetComponentsInChildren<Image>()[1].enabled = false;
						}
					}
					if (cq.OnlyColor == 1)
					{
						matrix[j][k].SetActive(k == 1);
					}
					else if (cq.OnlyShape == 0)
					{
						matrix[j][k].SetActive(value: true);
					}
					if (cq.OnlyShape == 1)
					{
						if (j != 1)
						{
							matrix[j][k].SetActive(value: false);
						}
						else
						{
							matrix[1][0].GetComponentsInChildren<Image>()[1].color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
							matrix[1][1].GetComponentsInChildren<Image>()[1].color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
							matrix[1][2].GetComponentsInChildren<Image>()[1].color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
						}
						if (couMatrix[j][k] > 0)
						{
							matrix[j][k].GetComponent<Text>().text = "";
							matrix[j][k].GetComponentsInChildren<Image>()[1].enabled = true;
						}
						else
						{
							matrix[j][k].GetComponent<Text>().text = "";
							matrix[j][k].GetComponentsInChildren<Image>()[1].enabled = false;
						}
					}
					if (result.words != "")
					{
						matrix[j][k].SetActive(value: false);
					}
				}
			}
		}
		AccBar.SetPercantage((float)accuracy / 100f);
		AccBar.SetBorder(result);
		if (isOccDisabled)
		{
			return;
		}
		if (cq.OnlyAcc == 0)
		{
			if (need != 0f)
			{
				OccBar.SetPercantage(Mathf.Min(1f, (float)curElems / need));
			}
		}
		else
		{
			OccBar.SetPercantage(Mathf.Max(0f, 1f - need / cq.TimeTrueAcc));
		}
	}

	private void CarRedraw()
	{
		if (!isOccDisabled)
		{
			OccBar.SetPercantage(Mathf.Min(1f, (float)curElems / need));
		}
	}
}
