using System;
using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class SchemeBlock
{
	public string Image = "";

	public float constrWidthSaved = 928.05f;

	public float constrHeightSaved = 543.5f;

	private int maxSockets = 5;

	public int useGlobalPosition = 1;

	public Vector3 position;

	public Quaternion rotation;

	public List<SchemeSocket> inSockets = new List<SchemeSocket>();

	public string KeyName = string.Empty;

	public int KeyHash;

	public string ShowName = string.Empty;

	public int ShowNameHash;

	public int idInList;

	public List<SchemeSocket> outSockets = new List<SchemeSocket>();

	public List<int> outConditionsColor = new List<int>();

	public List<int> outConditionsShape = new List<int>();

	public List<int> changeColorSocket = new List<int>();

	public List<SchemeBlock> blocks = new List<SchemeBlock>();

	private int curExit;

	public int outputRNNColor;

	public int couProcessed;

	private bool custom;

	private float value;

	public float error;

	public bool hide;

	public float showError;

	private System.Random BlockRandom;

	public SchemeBlock main;

	private bool marked;

	private List<int> currentOutSockets;

	private List<int> currentInSockets;

	private Element memory;

	private Element elementHolder;

	private MultiDictionary<int, SchemeSocket> sortedRandomDict;

	private List<int> sortedRandomList;

	private List<SchemeSocket> socketsBuf;

	private float timer;

	public bool activated;

	private float baseWorkTime = -1f;

	public void SetKeyName(string keyname)
	{
		KeyName = keyname;
		KeyHash = keyname.GetHashCode();
	}

	public string GetKeyName()
	{
		return KeyName;
	}

	public void SetShowName(string name)
	{
		ShowName = name;
		ShowNameHash = name.GetHashCode();
	}

	public string GetShowName()
	{
		return ShowName;
	}

	private void Init()
	{
		KeyHash = KeyName.GetHashCode();
		for (int i = 0; i < maxSockets; i++)
		{
			inSockets.Add(null);
			outSockets.Add(null);
			outConditionsColor.Add(-1);
			outConditionsShape.Add(-1);
			changeColorSocket.Add(-1);
		}
	}

	public void UpdateAfterLoad()
	{
		useGlobalPosition = 0;
	}

	public void ReInit()
	{
		ClearToSave();
		SchemeBlock shbl = Logic.Clone<SchemeBlock>(this);
		BaseInit(shbl);
		shbl = null;
	}

	public void Clear(bool clearArrays = false)
	{
		foreach (SchemeSocket inSocket in inSockets)
		{
			inSocket?.Clear();
		}
		foreach (SchemeSocket outSocket in outSockets)
		{
			outSocket?.Clear();
		}
		foreach (SchemeBlock block in blocks)
		{
			block.Clear();
		}
		if (clearArrays)
		{
			inSockets.Clear();
			outSockets.Clear();
			blocks.Clear();
		}
		marked = false;
	}

	public void ClearToSave()
	{
		main = null;
		memory = null;
		elementHolder = null;
		foreach (SchemeSocket inSocket in inSockets)
		{
			inSocket?.Clear();
		}
		foreach (SchemeSocket outSocket in outSockets)
		{
			outSocket?.Clear();
		}
		if (sortedRandomDict != null)
		{
			sortedRandomDict.Clear();
			sortedRandomDict = null;
			sortedRandomList.Clear();
			sortedRandomList = null;
		}
		foreach (SchemeBlock block in blocks)
		{
			block.ClearToSave();
		}
	}

	public void ClearBeforeRun()
	{
		couProcessed = 0;
		foreach (SchemeBlock block in blocks)
		{
			block.ClearBeforeRun();
		}
	}

	public bool IsSocketConnected(int socket)
	{
		bool result = false;
		if (inSockets[socket] != null && inSockets[socket].nextBlock >= 0)
		{
			result = true;
		}
		return result;
	}

	public float GetInputSpeed(int socket)
	{
		float num = 2.1474836E+09f;
		bool flag = false;
		if (inSockets[socket] != null && inSockets[socket].nextBlock >= 0)
		{
			num = Mathf.Min(num, Logic.GetWorkTimeByKeyName(blocks[inSockets[socket].nextBlock].KeyName, socket));
			flag = true;
		}
		if (!flag)
		{
			num = 0.01f;
		}
		return num;
	}

	public void Init(Construction constr, bool savingFirstDepth = false)
	{
		constr.SetAllParentsToDefault();
		if (savingFirstDepth)
		{
			useGlobalPosition = 0;
		}
		constrHeightSaved = constr.constrBlock.sizeDelta.y;
		constrWidthSaved = constr.constrBlock.sizeDelta.x;
		custom = true;
		main = this;
		useGlobalPosition = 0;
		blocks = new List<SchemeBlock>();
		if (constr.constrState != ConstructionState.SandBox)
		{
			SetKeyName(QuestLine.GetCurrentQuestName());
		}
		else
		{
			SetKeyName(constr.schemeStack.Top().keyName);
		}
		SetShowName(constr.SchemeName.text);
		outConditionsColor = new List<int>();
		outConditionsShape = new List<int>();
		changeColorSocket = new List<int>();
		for (int i = 0; i < constr.blocksInScheme.Count; i++)
		{
			Construction.BlockInScheme blockInScheme = constr.blocksInScheme[i];
			SchemeBlock schemeBlock = new SchemeBlock();
			schemeBlock.Init(blockInScheme.go, blockInScheme.keyname, constr, this);
			schemeBlock.idInList = i;
			blocks.Add(schemeBlock);
		}
		for (int j = 0; j < constr.datas.Count; j++)
		{
			outConditionsColor.Add(-1);
			outConditionsShape.Add(-1);
			changeColorSocket.Add(-1);
			if (constr.datas[j].IsActive())
			{
				inSockets.Add(new SchemeSocket(inSocket: true));
				int nextGameObject = constr.datas[j].socketsOut[2].GetNextGameObject();
				inSockets[inSockets.Count - 1].nextBlock = nextGameObject;
				inSockets[inSockets.Count - 1].nextSocketNum = constr.datas[j].socketsOut[2].GetIdSocketInNextBlock();
				inSockets[inSockets.Count - 1].nextResultNum = -1;
				inSockets[inSockets.Count - 1].catcherSocket = constr.datas[j].socketsOut[2].GetNextCatcherSocket();
				inSockets[inSockets.Count - 1].type = constr.datas[j].socketsOut[2].GetNextTypeSocket();
			}
			else
			{
				inSockets.Add(null);
			}
		}
		for (int k = 0; k < constr.results.Count; k++)
		{
			if (constr.results[k].IsActive())
			{
				outSockets.Add(new SchemeSocket());
			}
			else
			{
				outSockets.Add(null);
			}
		}
	}

	public float GetMeanElementsInSockets()
	{
		int num = 0;
		int num2 = 0;
		foreach (SchemeSocket inSocket in inSockets)
		{
			if (inSocket != null)
			{
				if (inSocket.activated)
				{
					num2++;
				}
				num += inSocket.queue.Count;
			}
		}
		foreach (SchemeSocket outSocket in outSockets)
		{
			if (outSocket != null)
			{
				num2++;
				num += outSocket.queue.Count;
			}
		}
		return (float)num / (float)num2;
	}

	public void Init(GameObject go, string kn, Construction constr, SchemeBlock sh)
	{
		hide = true;
		Init();
		main = sh;
		useGlobalPosition = 0;
		position = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, go.transform.localPosition.z);
		constrWidthSaved = constr.constrBlock.sizeDelta.x;
		constrHeightSaved = constr.constrBlock.sizeDelta.y;
		rotation = go.transform.rotation;
		SetKeyName(kn);
		custom = !Logic.IsBaseBlock(kn);
		curExit = 0;
		InitBaseBlock(go.GetComponent<BaseBlock>());
		switch (KeyName)
		{
		case "CHCOLORBLOCK":
			InitChangeColor(go.GetComponent<ChangeColorBlock>());
			break;
		case "DSTREE":
			InitDsTree(go.GetComponent<DesicionTree>());
			break;
		case "IFCOLOR":
			InitIfColor(go.GetComponent<IfColor>());
			break;
		case "IFSHAPE":
			InitIfShape(go.GetComponent<IfShape>());
			break;
		case "DSSHAPE":
			InitDsShape(go.GetComponent<DsShape>());
			break;
		case "BRBLOCK":
			InitBrutforse(go.GetComponent<BrutforseBlock>());
			break;
		case "PERCEPTRONCOLOR":
			InitPercColor(go.GetComponent<PerceptronColor>());
			break;
		case "GENCOPYBLOCKCOLOR":
			InitGeneticColor(go.GetComponent<GeneticCopyBlockColor>());
			break;
		case "PERCEPTRONSHAPE":
			InitPercShape(go.GetComponent<PerceptronShape>());
			break;
		case "ROSENBLATT":
			InitRosenblatt(go.GetComponent<Rosenblat>());
			break;
		case "RNNCELL":
			InitRNN(go.GetComponent<RNNCELL>());
			break;
		case "ARMA":
			InitARMA(go.GetComponent<ARMA>());
			break;
		case "RANDOMFOREST":
			InitRandomForest(go.GetComponent<RandomForest>());
			break;
		case "ISOFOREST":
			InitIsoForest(go.GetComponent<IsolationForest>());
			break;
		default:
			InitCustom(go.GetComponent<CustomBlock>());
			break;
		case "DOUBLE":
		case "GENETIC":
		case "PARALLEL":
		case "REMOVE":
		case "GRADIENT":
		case "SGRADIENT":
		case "MULTIPLY":
		case "ISOBJECT":
		case "ISCAR":
			break;
		}
		value = Logic.GetValueByKeyName(KeyName);
	}

	private void InitRNN(RNNCELL block)
	{
		error = block.error;
	}

	private void InitARMA(ARMA block)
	{
		error = block.error;
	}

	private void InitPercColor(PerceptronColor block)
	{
		error = block.error;
	}

	private void InitGeneticColor(GeneticCopyBlockColor block)
	{
		hide = block.hide;
		error = block.error;
		showError = block.showError;
	}

	private void InitPercShape(PerceptronShape block)
	{
		error = block.error;
	}

	private void InitRosenblatt(Rosenblat block)
	{
		error = block.error;
	}

	private void InitBaseBlock(BaseBlock block)
	{
		for (int i = 0; i < maxSockets; i++)
		{
			if (block.socketsIn[i] != null)
			{
				inSockets[i] = new SchemeSocket(inSocket: true);
				inSockets[i].catcherSocket = block.socketsIn[i].catcherSocket;
			}
			if (block.socketsOut[i] != null)
			{
				outSockets[i] = new SchemeSocket();
				outSockets[i].nextBlock = block.socketsOut[i].GetNextGameObject();
				outSockets[i].nextSocketNum = block.socketsOut[i].GetIdSocketInNextBlock();
				outSockets[i].nextResultNum = block.socketsOut[i].GetNextResult();
			}
		}
	}

	private void InitChangeColor(ChangeColorBlock block)
	{
		outConditionsColor[2] = block.colorIn.value;
		changeColorSocket[2] = block.colorOut.value;
	}

	private void InitDsTree(DesicionTree block)
	{
		outConditionsColor[1] = block.top.value;
		outConditionsColor[3] = block.bot.value;
	}

	private void InitIsoForest(IsolationForest block)
	{
		outConditionsColor[0] = block.top.value;
		outConditionsColor[1] = block.mid.value;
	}

	private void InitRandomForest(RandomForest block)
	{
		outConditionsColor[1] = block.top.value;
		outConditionsColor[3] = block.bot.value;
		outConditionsColor[2] = block.mid.value;
	}

	private void InitIfColor(IfColor block)
	{
		outConditionsColor[1] = block.top.value;
	}

	private void InitDsShape(DsShape block)
	{
		outConditionsShape[1] = block.top.value;
		outConditionsShape[3] = block.bot.value;
	}

	private void InitIfShape(IfShape block)
	{
		outConditionsShape[1] = block.top.value;
		outConditionsShape[3] = -1;
	}

	private void InitBrutforse(BrutforseBlock block)
	{
		inSockets[2].catcherSocket = true;
	}

	private void InitCustom(CustomBlock block)
	{
		BaseInit(Logic.GetCustomSchemeByKeyName(KeyName));
		for (int i = 0; i < maxSockets; i++)
		{
			if (block.socketsOut[i] != null)
			{
				outSockets[i] = new SchemeSocket();
				outSockets[i].nextBlock = block.socketsOut[i].GetNextGameObject();
				outSockets[i].nextSocketNum = block.socketsOut[i].GetIdSocketInNextBlock();
				outSockets[i].nextResultNum = block.socketsOut[i].GetNextResult();
				outSockets[i].Init(this);
			}
		}
		position = block.gameObject.transform.localPosition;
		rotation = Quaternion.identity;
		custom = true;
	}

	public int GetNextSchemeBlock(int socketNum)
	{
		return outSockets[socketNum].nextBlock;
	}

	public int GetNextResult(int socketNum)
	{
		return outSockets[socketNum].nextResultNum;
	}

	public int GetNextSocketId(int socketNum)
	{
		return outSockets[socketNum].nextSocketNum;
	}

	public int GetMaxElementsInside()
	{
		int num = 0;
		foreach (SchemeBlock block in blocks)
		{
			num += block.GetMaxElementsInside();
		}
		custom = !Logic.IsBaseBlock(KeyName);
		if (!custom)
		{
			num++;
		}
		return num;
	}

	public void BaseInit(SchemeBlock shbl, bool savingFirstDepth = false)
	{
		if (main == null)
		{
			main = this;
		}
		currentInSockets = null;
		currentOutSockets = null;
		BlockRandom = new System.Random(1234);
		SetKeyName(shbl.KeyName);
		UnityEngine.Random.InitState(1234);
		_ = shbl.position;
		position = new Vector3(shbl.position.x, shbl.position.y, shbl.position.z);
		constrHeightSaved = shbl.constrHeightSaved;
		constrWidthSaved = shbl.constrWidthSaved;
		outConditionsColor = new List<int>();
		outConditionsShape = new List<int>();
		changeColorSocket = new List<int>();
		inSockets = new List<SchemeSocket>();
		outSockets = new List<SchemeSocket>();
		blocks = new List<SchemeBlock>();
		useGlobalPosition = shbl.useGlobalPosition;
		SetKeyName(shbl.KeyName);
		custom = Logic.IsBaseBlock(shbl.KeyName);
		value = Logic.GetValueByKeyName(KeyName);
		if (savingFirstDepth)
		{
			useGlobalPosition = 0;
		}
		for (int i = 0; i < shbl.blocks.Count; i++)
		{
			blocks.Add(new SchemeBlock());
			blocks[i].main = this;
			if (Logic.IsBaseBlock(shbl.blocks[i].KeyName))
			{
				blocks[i].BaseInit(shbl.blocks[i]);
				blocks[i].error = shbl.blocks[i].error;
				blocks[i].showError = shbl.blocks[i].showError;
				blocks[i].hide = shbl.blocks[i].hide;
				blocks[i].outputRNNColor = shbl.blocks[i].outputRNNColor;
				continue;
			}
			blocks[i].BaseInit(Logic.GetCustomSchemeByKeyName(shbl.blocks[i].KeyName));
			blocks[i].custom = true;
			_ = shbl.blocks[i].position;
			blocks[i].position = new Vector3(shbl.blocks[i].position.x, shbl.blocks[i].position.y, shbl.blocks[i].position.z);
			blocks[i].constrHeightSaved = shbl.blocks[i].constrHeightSaved;
			blocks[i].constrWidthSaved = shbl.blocks[i].constrWidthSaved;
			for (int j = 0; j < 5; j++)
			{
				if (shbl.blocks[i].inSockets[j] != null)
				{
					blocks[i].inSockets[j] = new SchemeSocket(inSocket: true);
					blocks[i].inSockets[j].Init(shbl.blocks[i].inSockets[j], blocks[i]);
				}
				if (shbl.blocks[i].outSockets[j] != null)
				{
					blocks[i].outSockets[j] = new SchemeSocket();
					blocks[i].outSockets[j].Init(shbl.blocks[i].outSockets[j], blocks[i]);
				}
				blocks[i].outConditionsColor[j] = shbl.blocks[i].outConditionsColor[j];
				blocks[i].outConditionsShape[j] = shbl.blocks[i].outConditionsShape[j];
				blocks[i].changeColorSocket[j] = shbl.blocks[i].changeColorSocket[j];
			}
			blocks[i].error = shbl.blocks[i].error;
			blocks[i].showError = shbl.blocks[i].showError;
			blocks[i].hide = shbl.blocks[i].hide;
			blocks[i].outputRNNColor = shbl.blocks[i].outputRNNColor;
		}
		for (int k = 0; k < maxSockets; k++)
		{
			if (k < shbl.inSockets.Count)
			{
				if (shbl.inSockets[k] != null)
				{
					inSockets.Add(new SchemeSocket(inSocket: true));
					inSockets[k].Init(shbl.inSockets[k], this);
				}
				else
				{
					inSockets.Add(null);
				}
				if (shbl.outSockets[k] != null)
				{
					outSockets.Add(new SchemeSocket());
					outSockets[k].Init(shbl.outSockets[k], this);
				}
				else
				{
					outSockets.Add(null);
				}
				outConditionsColor.Add(shbl.outConditionsColor[k]);
				outConditionsShape.Add(shbl.outConditionsShape[k]);
				changeColorSocket.Add(shbl.changeColorSocket[k]);
				error = shbl.error;
				showError = shbl.showError;
				hide = shbl.hide;
				outputRNNColor = shbl.outputRNNColor;
			}
		}
	}

	public int GetServersCost()
	{
		int num = 0;
		if (Logic.IsBaseBlock(KeyName))
		{
			return Logic.GetServersCouInBlock(KeyName);
		}
		foreach (SchemeBlock block in blocks)
		{
			num += block.GetServersCost();
		}
		return num;
	}

	public void MarkExit(int outId, bool marked)
	{
		if (outSockets[outId].nextResultNum == -1)
		{
			outSockets[outId].SetMarked(marked);
			if (outSockets[outId].nextBlock != -1 && outSockets[outId].nextSocketNum != -1 && main.blocks.Count > outSockets[outId].nextBlock)
			{
				main.blocks[outSockets[outId].nextBlock].Marking();
			}
		}
		else
		{
			main.MarkExit(outSockets[outId].nextResultNum, marked);
		}
	}

	public void Marking()
	{
		if (marked)
		{
			return;
		}
		marked = main.KeyHash != KeyHash;
		for (int i = 0; i < inSockets.Count; i++)
		{
			if (inSockets[i] != null)
			{
				inSockets[i].SetMarked(marked);
				if (inSockets[i].nextResultNum == -1 && inSockets[i].nextBlock != -1 && inSockets[i].nextSocketNum != -1 && blocks.Count > inSockets[i].nextBlock)
				{
					blocks[inSockets[i].nextBlock].Marking();
				}
			}
		}
		if (Logic.IsBaseBlock(KeyName))
		{
			for (int j = 0; j < outSockets.Count; j++)
			{
				if (outSockets[j] != null)
				{
					outSockets[j].SetMarked(marked);
					MarkExit(j, marked);
				}
			}
			return;
		}
		for (int k = 0; k < outSockets.Count; k++)
		{
			if (outSockets[k] != null)
			{
				outSockets[k].SetMarked(state: false);
			}
		}
	}

	public int GetServersCou(bool startup, int depth)
	{
		if (KeyName == "PARALLEL")
		{
			return 1;
		}
		int num = 0;
		Marking();
		foreach (SchemeBlock block in blocks)
		{
			if (block.marked)
			{
				num += block.GetServersCou(startup, depth++);
			}
		}
		return num;
	}

	public int GetBlocksCou(bool startup, int depth)
	{
		if (Logic.IsBaseBlock(KeyName))
		{
			return 1;
		}
		int num = 0;
		Marking();
		foreach (SchemeBlock block in blocks)
		{
			if (block.marked)
			{
				num += block.GetBlocksCou(startup, depth++);
			}
		}
		return num;
	}

	public void Push()
	{
		if (KeyHash == main.KeyHash)
		{
			return;
		}
		if (currentOutSockets == null)
		{
			currentOutSockets = new List<int>();
			for (int i = 0; i < outSockets.Count; i++)
			{
				if (outSockets[i] != null)
				{
					currentOutSockets.Add(i);
				}
			}
		}
		for (int j = 0; j < currentOutSockets.Count; j++)
		{
			int index = currentOutSockets[j];
			if (outSockets[index].nextResultNum == -1)
			{
				if (outSockets[index].nextBlock != -1 && outSockets[index].nextSocketNum != -1)
				{
					main.blocks[outSockets[index].nextBlock].inSockets[outSockets[index].nextSocketNum].SetElement(outSockets[index].GetElement());
					main.blocks[outSockets[index].nextBlock].Active(outSockets[index].nextSocketNum);
				}
				continue;
			}
			Element element = outSockets[index].GetElement();
			if (element != null)
			{
				element.curDepth--;
			}
			main.outSockets[outSockets[index].nextResultNum].SetElement(element);
		}
	}

	public void PushInBlock()
	{
		if (currentInSockets == null)
		{
			currentInSockets = new List<int>();
			for (int i = 0; i < inSockets.Count; i++)
			{
				if (inSockets[i] != null && inSockets[i].nextResultNum == -1 && inSockets[i].nextBlock != -1 && inSockets[i].nextSocketNum != -1)
				{
					currentInSockets.Add(i);
				}
			}
		}
		bool flag = false;
		for (int j = 0; j < currentInSockets.Count; j++)
		{
			int index = currentInSockets[j];
			Element element = inSockets[index].GetElement();
			if (element != null)
			{
				element.curDepth++;
				flag = true;
				blocks[inSockets[index].nextBlock].inSockets[inSockets[index].nextSocketNum].SetElement(element);
				blocks[inSockets[index].nextBlock].Active(inSockets[index].nextSocketNum);
			}
		}
		if (flag)
		{
			Push();
		}
	}

	private int GetCouSocketsInBaseBlock()
	{
		if (!marked)
		{
			return 0;
		}
		int num = 0;
		foreach (SchemeSocket inSocket in inSockets)
		{
			if (inSocket != null && inSocket.IsValid())
			{
				num++;
			}
		}
		int num2 = 0;
		foreach (SchemeSocket outSocket in outSockets)
		{
			num2++;
			if (outSocket != null && outSocket.IsValid())
			{
				num++;
			}
		}
		return num;
	}

	public int GetSocketsCou()
	{
		if (Logic.IsBaseBlock(KeyName))
		{
			return GetCouSocketsInBaseBlock();
		}
		int num = 0;
		foreach (SchemeBlock block in blocks)
		{
			num += block.GetSocketsCou();
		}
		return num;
	}

	public int GetRemoveCou()
	{
		if (KeyName == "REMOVE")
		{
			return 1;
		}
		if (Logic.IsBaseBlock(KeyName))
		{
			return 0;
		}
		int num = 0;
		foreach (SchemeBlock block in blocks)
		{
			num += block.GetRemoveCou();
		}
		return num;
	}

	public int GetFullBlocksCou()
	{
		if (KeyName == "REMOVE")
		{
			return 0;
		}
		if (Logic.IsBaseBlock(KeyName))
		{
			return 1;
		}
		int num = 0;
		foreach (SchemeBlock block in blocks)
		{
			num += block.GetFullBlocksCou();
		}
		return num;
	}

	public int GetWorkTimeFromNextBlockFromOutput(SchemeSocket outS)
	{
		if (outS.nextBlock != -1 && outS.nextResultNum == -1 && main.blocks.Count > outS.nextBlock)
		{
			return (int)Mathf.Min(Logic.GetMaxElementsOnLine(), Logic.GetChainTime() / Logic.GetWorkTimeByKeyName(main.blocks[outS.nextBlock].KeyName));
		}
		if (outS.nextBlock != -1 && outS.nextResultNum != -1 && main.blocks.Count > outS.nextBlock)
		{
			return Logic.GetMaxElementsOnLine();
		}
		if (outS.nextResultNum != -1)
		{
			if (KeyHash != main.KeyHash)
			{
				return main.GetWorkTimeFromNextBlockFromOutput(main.outSockets[outS.nextResultNum]);
			}
			return Logic.GetMaxElementsOnLine();
		}
		return 0;
	}

	public int GetMaxElementsOnLines()
	{
		int num = 0;
		if (Logic.IsBaseBlock(KeyName))
		{
			foreach (SchemeSocket outSocket in outSockets)
			{
				if (outSocket != null && outSocket.IsValid())
				{
					num += GetWorkTimeFromNextBlockFromOutput(outSocket);
				}
			}
		}
		else
		{
			foreach (SchemeBlock block in blocks)
			{
				num += block.GetMaxElementsOnLines();
			}
		}
		return num;
	}

	public int GetCustomBlocksCou()
	{
		int num = 0;
		if (!Logic.IsBaseBlock(KeyName))
		{
			num++;
			{
				foreach (SchemeBlock block in blocks)
				{
					num += block.GetCustomBlocksCou();
				}
				return num;
			}
		}
		return num;
	}

	public void InitOnLoad(SchemeBlock sheme)
	{
		main = sheme;
		for (int i = 0; i < blocks.Count; i++)
		{
			blocks[i].InitOnLoad(this);
		}
	}

	public void Active(int id)
	{
		if (inSockets[id] == null)
		{
			return;
		}
		if (!Logic.IsBaseBlock(KeyName))
		{
			PushInBlock();
			return;
		}
		Element element = inSockets[id].GetElement();
		if (element == null)
		{
			return;
		}
		couProcessed++;
		if (couProcessed > 15)
		{
			element.stopped = true;
			return;
		}
		element.recursionDepth++;
		if (element.recursionDepth > 100)
		{
			element.stopped = true;
			return;
		}
		element.timeInBlock += Logic.GetTimeInBlock(KeyName);
		if (element.curDepth == 1 && element.startup)
		{
			element.timeInBlock += Logic.GetChainTime();
		}
		switch (KeyName)
		{
		case "DSTREE":
		{
			if (id != 2)
			{
				break;
			}
			bool flag3 = false;
			bool flag4 = false;
			if (outConditionsColor[1] == 3)
			{
				flag3 = true;
			}
			if (outConditionsColor[3] == 3)
			{
				flag4 = true;
			}
			if (outConditionsColor[1] == element.ColorId)
			{
				flag3 = true;
			}
			if (outConditionsColor[3] == element.ColorId)
			{
				flag4 = true;
			}
			if (flag4 == flag3)
			{
				if (sortedRandomDict == null)
				{
					sortedRandomDict = new MultiDictionary<int, SchemeSocket>();
					sortedRandomDict.Add(outConditionsColor[1], outSockets[1]);
					sortedRandomDict.Add(outConditionsColor[3], outSockets[3]);
					sortedRandomList = new List<int>();
					sortedRandomList.Add(outConditionsColor[1]);
					sortedRandomList.Add(outConditionsColor[3]);
					sortedRandomList.Sort();
				}
				HashSet<SchemeSocket> hashSet = sortedRandomDict[sortedRandomList[(int)(BlockRandom.NextDouble() * 2.0)]];
				List<SchemeSocket> list = new List<SchemeSocket>();
				foreach (SchemeSocket item in hashSet)
				{
					list.Add(item);
				}
				list[(int)(BlockRandom.NextDouble() * (double)list.Count)].SetElement(element);
				Push();
			}
			else if (flag4)
			{
				outSockets[3].SetElement(element);
				Push();
			}
			else if (flag3)
			{
				outSockets[1].SetElement(element);
				Push();
			}
			break;
		}
		case "IFCOLOR":
			if (id == 2)
			{
				if (outConditionsColor[1] == element.ColorId)
				{
					outSockets[1].SetElement(element);
					Push();
				}
				else
				{
					outSockets[3].SetElement(element);
					Push();
				}
			}
			break;
		case "IFSHAPE":
			if (id == 2)
			{
				if (outConditionsShape[1] == element.ShapeId)
				{
					outSockets[1].SetElement(element);
					Push();
				}
				else
				{
					outSockets[3].SetElement(element);
					Push();
				}
			}
			break;
		case "DSSHAPE":
		{
			if (id != 2)
			{
				break;
			}
			bool flag6 = false;
			bool flag7 = false;
			if (outConditionsShape[1] == 3)
			{
				flag6 = true;
			}
			if (outConditionsShape[3] == 3)
			{
				flag7 = true;
			}
			if (outConditionsShape[1] == element.ShapeId)
			{
				flag6 = true;
			}
			if (outConditionsShape[3] == element.ShapeId)
			{
				flag7 = true;
			}
			if (flag7 == flag6)
			{
				if (sortedRandomDict == null)
				{
					sortedRandomDict = new MultiDictionary<int, SchemeSocket>();
					sortedRandomDict.Add(outConditionsShape[1], outSockets[1]);
					sortedRandomDict.Add(outConditionsShape[3], outSockets[3]);
					sortedRandomList = new List<int>();
					sortedRandomList.Add(outConditionsShape[1]);
					sortedRandomList.Add(outConditionsShape[3]);
					sortedRandomList.Sort();
				}
				HashSet<SchemeSocket> hashSet2 = sortedRandomDict[sortedRandomList[(int)(BlockRandom.NextDouble() * 2.0)]];
				List<SchemeSocket> list5 = new List<SchemeSocket>();
				foreach (SchemeSocket item2 in hashSet2)
				{
					list5.Add(item2);
				}
				list5[(int)(BlockRandom.NextDouble() * (double)list5.Count)].SetElement(element);
				Push();
			}
			else if (flag7)
			{
				outSockets[3].SetElement(element);
				Push();
			}
			else if (flag6)
			{
				outSockets[1].SetElement(element);
				Push();
			}
			break;
		}
		case "PARALLEL":
			if (id == 2)
			{
				if (curExit == 0)
				{
					outSockets[1].SetElement(element);
				}
				else
				{
					outSockets[3].SetElement(element);
				}
				if (!element.Try)
				{
					curExit = 1 - curExit;
				}
				Push();
			}
			break;
		case "REMOVE":
			element.stopped = true;
			break;
		case "PERCEPTRONCOLOR":
		case "GENCOPYBLOCKCOLOR":
			if (!element.revealed)
			{
				outSockets[1 + (int)BlockRandom.NextDouble()].SetElement(element);
				Push();
				break;
			}
			if (BlockRandom.NextDouble() > (double)error)
			{
				switch (element.ColorId)
				{
				case 0:
					outSockets[1].SetElement(element);
					break;
				case 1:
					outSockets[2].SetElement(element);
					break;
				case 2:
					outSockets[3].SetElement(element);
					break;
				}
			}
			else
			{
				List<int> list4 = new List<int>();
				switch (element.ColorId)
				{
				case 0:
					list4.Add(2);
					list4.Add(3);
					break;
				case 1:
					list4.Add(1);
					list4.Add(3);
					break;
				case 2:
					list4.Add(2);
					list4.Add(1);
					break;
				}
				int index = list4[(int)(BlockRandom.NextDouble() * 2.0)];
				element.error /= 2f;
				outSockets[index].SetElement(element);
			}
			Push();
			break;
		case "PERCEPTRONSHAPE":
		case "ROSENBLATT":
			if (BlockRandom.NextDouble() > (double)error)
			{
				switch (element.ShapeId)
				{
				case 0:
					outSockets[1].SetElement(element);
					break;
				case 1:
					outSockets[2].SetElement(element);
					break;
				case 2:
					outSockets[3].SetElement(element);
					break;
				}
				element.error /= 2f;
			}
			else
			{
				List<int> list3 = new List<int>();
				switch (element.ShapeId)
				{
				case 0:
					list3.Add(2);
					list3.Add(3);
					break;
				case 1:
					list3.Add(1);
					list3.Add(3);
					break;
				case 2:
					list3.Add(2);
					list3.Add(1);
					break;
				}
				element.error /= 2f;
				outSockets[list3[(int)(BlockRandom.NextDouble() * 2.0)]].SetElement(element);
			}
			Push();
			break;
		case "GRADIENT":
			element.error += value;
			outSockets[2].SetElement(element);
			Push();
			break;
		case "SGRADIENT":
			element.error *= value;
			outSockets[2].SetElement(element);
			Push();
			break;
		case "RNNCELL":
		case "ARMA":
			if (id != 1)
			{
				break;
			}
			if (!element.Try)
			{
				int num = 1;
				if (elementHolder == null)
				{
					elementHolder = new Element(element);
				}
				else
				{
					elementHolder.AddToRNNHolder(element);
				}
				List<char> list2 = new List<char>();
				int batchSize = elementHolder.batchSize;
				bool flag5 = false;
				for (int i = 0; i < num; i++)
				{
					if ((float)BlockRandom.NextDouble() > error && memory != null)
					{
						list2.Add(elementHolder.truePredict[(elementHolder.iterWord + i + batchSize) % elementHolder.truePredict.Count]);
						elementHolder.error /= 2f;
						flag5 = true;
						continue;
					}
					if (elementHolder.colorsQueue != null)
					{
						list2.Add((char)(48 + (int)(BlockRandom.NextDouble() * 10.0)));
					}
					else
					{
						list2.Add((char)(65 + (int)(BlockRandom.NextDouble() * 26.0)));
					}
					if (memory != null)
					{
						elementHolder.error /= 2f;
					}
				}
				int num2 = int.MaxValue;
				if (elementHolder.colorsQueue != null)
				{
					num2 = elementHolder.colorsQueue.Length;
				}
				Element element2 = new Element(0, 1, test: false, null, list2, elementHolder.truePredict, (elementHolder.iterWord + elementHolder.batchSize) % num2);
				element2.error = elementHolder.error;
				element2.startTime = elementHolder.startTime;
				element2.revealScore = elementHolder.revealScore;
				element2.colorsQueue = elementHolder.colorsQueue;
				element2.batchSize = elementHolder.batchSize;
				element2.spawnInDataTime = elementHolder.spawnInDataTime;
				if (flag5)
				{
					element2.ApplyRevealScore(100 - (int)(BlockRandom.NextDouble() * (double)error * 100.0));
				}
				element2.CheckRevealColor();
				Element element3 = new Element(element2);
				memory = element3;
				outSockets[1].SetElement(element2);
				elementHolder.MoveToNextBatch(batchSize);
			}
			else
			{
				outSockets[1].SetElement(element);
			}
			Push();
			break;
		case "RANDOMFOREST":
		{
			if (id != 2)
			{
				break;
			}
			bool flag8 = false;
			bool flag9 = false;
			bool flag10 = false;
			if (outConditionsColor[1] < 3)
			{
				if (outConditionsColor[1] == element.ColorId)
				{
					flag8 = true;
				}
			}
			else if (outConditionsColor[1] % 3 == element.ShapeId)
			{
				flag8 = true;
			}
			if (outConditionsColor[2] < 3)
			{
				if (outConditionsColor[2] == element.ColorId)
				{
					flag10 = true;
				}
			}
			else if (outConditionsColor[2] % 3 == element.ShapeId)
			{
				flag10 = true;
			}
			if (outConditionsColor[3] < 3)
			{
				if (outConditionsColor[3] == element.ColorId)
				{
					flag9 = true;
				}
			}
			else if (outConditionsColor[3] % 3 == element.ShapeId)
			{
				flag9 = true;
			}
			List<SchemeSocket> list6 = new List<SchemeSocket>();
			if (flag8)
			{
				list6.Add(outSockets[1]);
			}
			if (flag10)
			{
				list6.Add(outSockets[2]);
			}
			if (flag9)
			{
				list6.Add(outSockets[3]);
			}
			if (list6.Count > 0)
			{
				list6[(int)(BlockRandom.NextDouble() * (double)list6.Count)].SetElement(element);
			}
			else
			{
				list6 = new List<SchemeSocket>();
				list6.Add(outSockets[1]);
				list6.Add(outSockets[2]);
				list6.Add(outSockets[3]);
				list6[(int)(BlockRandom.NextDouble() * 3.0)].SetElement(element);
			}
			Push();
			break;
		}
		case "ISOFOREST":
			if (id == 2)
			{
				bool flag = false;
				bool flag2 = false;
				if (outConditionsColor[0] == element.ColorId && outConditionsColor[1] == element.ShapeId)
				{
					flag = true;
				}
				else
				{
					flag2 = true;
				}
				if (flag)
				{
					outSockets[1].SetElement(element);
				}
				if (flag2)
				{
					outSockets[3].SetElement(element);
				}
				Push();
			}
			break;
		case "ISOBJECT":
			IsSMTHTeamplate(element, id, "unknown", "object", "empty");
			Push();
			break;
		case "ISCAR":
			IsSMTHTeamplate(element, id, "object", "car", "wall");
			Push();
			break;
		}
	}

	public float TryActive(float addTimer)
	{
		if (!activated && KeyName != "REMOVE")
		{
			return 1000f;
		}
		float num = 1000f;
		timer += addTimer;
		foreach (SchemeSocket outSocket in outSockets)
		{
			if (outSocket != null)
			{
				num = Mathf.Min(num, outSocket.TryActive(addTimer));
			}
		}
		if (!custom)
		{
			if (baseWorkTime < 0f)
			{
				baseWorkTime = Logic.GetWorkTimeByKeyName(KeyName);
			}
			float num2 = baseWorkTime;
			if (timer > num2)
			{
				for (int i = 0; i < inSockets.Count; i++)
				{
					if (inSockets[i] != null && inSockets[i].queue.Count > 0 && ActiveWithTime(i))
					{
						if (KeyName == "PARALLEL")
						{
							num2 += 0.01f / (1f + 1.0155f * Logic.GetModel().P.upgradeStats.BlocksSpeedBonus);
						}
						timer -= num2;
						num = Mathf.Min(num, num2);
						inSockets[i].queue.RemoveAt(0);
						break;
					}
				}
			}
			foreach (SchemeSocket inSocket in inSockets)
			{
				if (inSocket != null)
				{
					num = Mathf.Min(num, inSocket.TryActive(addTimer));
				}
			}
		}
		else
		{
			foreach (SchemeBlock block in blocks)
			{
				num = Mathf.Min(num, block.TryActive(addTimer));
			}
			foreach (SchemeSocket inSocket2 in inSockets)
			{
				if (inSocket2 != null && inSocket2.nextBlock > -1 && inSocket2.nextSocketNum > -1 && !blocks[inSocket2.nextBlock].inSockets[inSocket2.nextSocketNum].isFull())
				{
					Element element = inSocket2.GetElement();
					if (element != null)
					{
						blocks[inSocket2.nextBlock].inSockets[inSocket2.nextSocketNum].SetElement(element);
					}
				}
			}
		}
		return num;
	}

	public bool ActiveWithTime(int id)
	{
		if (inSockets[id] == null)
		{
			return false;
		}
		Element element = inSockets[id].queue[0];
		if (element == null)
		{
			return false;
		}
		switch (KeyName)
		{
		case "DSTREE":
			if (id == 2)
			{
				bool flag3 = false;
				bool flag4 = false;
				if (outConditionsColor[1] == 3)
				{
					flag3 = true;
				}
				if (outConditionsColor[3] == 3)
				{
					flag4 = true;
				}
				if (outConditionsColor[1] == element.ColorId)
				{
					flag3 = true;
				}
				if (outConditionsColor[3] == element.ColorId)
				{
					flag4 = true;
				}
				if (flag4 == flag3)
				{
					if (outSockets[1].isFull() || outSockets[3].isFull())
					{
						return false;
					}
					if (sortedRandomDict == null)
					{
						sortedRandomDict = new MultiDictionary<int, SchemeSocket>();
						sortedRandomDict.Add(outConditionsColor[1], outSockets[1]);
						sortedRandomDict.Add(outConditionsColor[3], outSockets[3]);
						sortedRandomList = new List<int>();
						sortedRandomList.Add(outConditionsColor[1]);
						sortedRandomList.Add(outConditionsColor[3]);
						sortedRandomList.Sort();
					}
					HashSet<SchemeSocket> hashSet = sortedRandomDict[sortedRandomList[(int)(BlockRandom.NextDouble() * 2.0)]];
					List<SchemeSocket> list = new List<SchemeSocket>();
					foreach (SchemeSocket item in hashSet)
					{
						list.Add(item);
					}
					list[(int)(BlockRandom.NextDouble() * (double)list.Count)].SetElement(element);
					return true;
				}
				if (flag4)
				{
					if (outSockets[3].isFull())
					{
						return false;
					}
					outSockets[3].SetElement(element);
					return true;
				}
				if (flag3)
				{
					if (outSockets[1].isFull())
					{
						return false;
					}
					outSockets[1].SetElement(element);
					return true;
				}
			}
			return true;
		case "IFCOLOR":
			if (id == 2)
			{
				if (outConditionsColor[1] == element.ColorId)
				{
					outSockets[1].SetElement(element);
					if (outSockets[1].isFull())
					{
						return false;
					}
					return true;
				}
				if (outSockets[3].isFull())
				{
					return false;
				}
				outSockets[3].SetElement(element);
				return true;
			}
			return true;
		case "IFSHAPE":
			if (id == 2)
			{
				if (outConditionsShape[1] == element.ShapeId)
				{
					outSockets[1].SetElement(element);
					if (outSockets[1].isFull())
					{
						return false;
					}
					return true;
				}
				if (outSockets[3].isFull())
				{
					return false;
				}
				outSockets[3].SetElement(element);
				return true;
			}
			return true;
		case "DSSHAPE":
			if (id == 2)
			{
				bool flag8 = false;
				bool flag9 = false;
				if (outConditionsShape[1] == 3)
				{
					flag8 = true;
				}
				if (outConditionsShape[3] == 3)
				{
					flag9 = true;
				}
				if (outConditionsShape[1] == element.ShapeId)
				{
					flag8 = true;
				}
				if (outConditionsShape[3] == element.ShapeId)
				{
					flag9 = true;
				}
				if (flag9 == flag8)
				{
					if (outSockets[1].isFull() || outSockets[3].isFull())
					{
						return false;
					}
					if (sortedRandomDict == null)
					{
						sortedRandomDict = new MultiDictionary<int, SchemeSocket>();
						sortedRandomDict.Add(outConditionsShape[1], outSockets[1]);
						sortedRandomDict.Add(outConditionsShape[3], outSockets[3]);
						sortedRandomList = new List<int>();
						sortedRandomList.Add(outConditionsShape[1]);
						sortedRandomList.Add(outConditionsShape[3]);
						sortedRandomList.Sort();
					}
					HashSet<SchemeSocket> hashSet3 = sortedRandomDict[sortedRandomList[BlockRandom.Next(2)]];
					List<SchemeSocket> list4 = new List<SchemeSocket>();
					foreach (SchemeSocket item2 in hashSet3)
					{
						list4.Add(item2);
					}
					list4[BlockRandom.Next(list4.Count)].SetElement(element);
					return true;
				}
				if (flag9)
				{
					if (outSockets[3].isFull())
					{
						return false;
					}
					outSockets[3].SetElement(element);
					return true;
				}
				if (flag8)
				{
					if (outSockets[1].isFull())
					{
						return false;
					}
					outSockets[1].SetElement(element);
					return true;
				}
			}
			return true;
		case "PARALLEL":
			if (id != 2)
			{
				break;
			}
			if (outSockets[1].isFull() && outSockets[3].isFull())
			{
				return false;
			}
			if (curExit == 0)
			{
				if (outSockets[1].isFull())
				{
					outSockets[3].SetElement(element);
					return true;
				}
				outSockets[1].SetElement(element);
			}
			else
			{
				if (outSockets[3].isFull())
				{
					outSockets[1].SetElement(element);
					return true;
				}
				outSockets[3].SetElement(element);
			}
			curExit = 1 - curExit;
			return true;
		case "REMOVE":
			return true;
		case "PERCEPTRONCOLOR":
		case "GENCOPYBLOCKCOLOR":
			if (!element.revealed)
			{
				outSockets[1 + BlockRandom.Next() % 3].SetElement(element);
				return true;
			}
			if (BlockRandom.NextDouble() > (double)error)
			{
				switch (element.ColorId)
				{
				case 0:
					if (outSockets[1].isFull())
					{
						return false;
					}
					outSockets[1].SetElement(element);
					break;
				case 1:
					if (outSockets[2].isFull())
					{
						return false;
					}
					outSockets[2].SetElement(element);
					break;
				case 2:
					if (outSockets[3].isFull())
					{
						return false;
					}
					outSockets[3].SetElement(element);
					break;
				}
			}
			else
			{
				List<int> list2 = new List<int>();
				switch (element.ColorId)
				{
				case 0:
					list2.Add(2);
					list2.Add(3);
					break;
				case 1:
					list2.Add(1);
					list2.Add(3);
					break;
				case 2:
					list2.Add(2);
					list2.Add(1);
					break;
				}
				foreach (int item3 in list2)
				{
					if (outSockets[item3].isFull())
					{
						return false;
					}
				}
				int index = list2[BlockRandom.Next() % 2];
				element.error /= 2f;
				outSockets[index].SetElement(element);
			}
			return true;
		case "PERCEPTRONSHAPE":
		case "ROSENBLATT":
			if (!element.revealed)
			{
				outSockets[1 + BlockRandom.Next() % 3].SetElement(element);
				return true;
			}
			if (BlockRandom.NextDouble() > (double)error)
			{
				switch (element.ShapeId)
				{
				case 0:
					if (outSockets[1].isFull())
					{
						return false;
					}
					outSockets[1].SetElement(element);
					break;
				case 1:
					if (outSockets[2].isFull())
					{
						return false;
					}
					outSockets[2].SetElement(element);
					break;
				case 2:
					if (outSockets[3].isFull())
					{
						return false;
					}
					outSockets[3].SetElement(element);
					break;
				}
				element.error /= 2f;
			}
			else
			{
				List<int> list5 = new List<int>();
				switch (element.ShapeId)
				{
				case 0:
					list5.Add(2);
					list5.Add(3);
					break;
				case 1:
					list5.Add(1);
					list5.Add(3);
					break;
				case 2:
					list5.Add(2);
					list5.Add(1);
					break;
				}
				foreach (int item4 in list5)
				{
					if (outSockets[item4].isFull())
					{
						return false;
					}
				}
				element.error /= 2f;
				outSockets[list5[BlockRandom.Next() % 2]].SetElement(element);
			}
			return true;
		case "GRADIENT":
			if (outSockets[2].isFull())
			{
				return false;
			}
			element.error += value;
			outSockets[2].SetElement(element);
			return true;
		case "SGRADIENT":
			if (outSockets[2].isFull())
			{
				return false;
			}
			element.error *= value;
			outSockets[2].SetElement(element);
			return true;
		case "RNNCELL":
		case "ARMA":
			if (id != 1)
			{
				return false;
			}
			if (!element.Try)
			{
				if (outSockets[1].isFull())
				{
					return false;
				}
				int num = 1;
				if (elementHolder == null)
				{
					elementHolder = new Element(element);
				}
				else
				{
					elementHolder.AddToRNNHolder(element);
				}
				List<char> list6 = new List<char>();
				int batchSize = elementHolder.batchSize;
				bool flag10 = false;
				for (int i = 0; i < num; i++)
				{
					if ((float)BlockRandom.NextDouble() > error && memory != null)
					{
						list6.Add(elementHolder.truePredict[(elementHolder.iterWord + i + batchSize) % elementHolder.truePredict.Count]);
						elementHolder.error /= 2f;
						flag10 = true;
						continue;
					}
					if (elementHolder.colorsQueue != null)
					{
						list6.Add((char)(48 + BlockRandom.Next(10)));
					}
					else
					{
						list6.Add((char)(65 + BlockRandom.Next(26)));
					}
					if (memory != null)
					{
						elementHolder.error /= 2f;
					}
				}
				int num2 = int.MaxValue;
				if (elementHolder.colorsQueue != null)
				{
					num2 = elementHolder.colorsQueue.Length;
				}
				Element element2 = new Element(0, 1, test: false, null, list6, elementHolder.truePredict, (elementHolder.iterWord + elementHolder.batchSize) % num2);
				element2.error = elementHolder.error;
				element2.startTime = elementHolder.startTime;
				element2.revealScore = elementHolder.revealScore;
				element2.colorsQueue = elementHolder.colorsQueue;
				element2.batchSize = elementHolder.batchSize;
				element2.spawnInDataTime = elementHolder.spawnInDataTime;
				if (flag10)
				{
					element2.ApplyRevealScore(100 - BlockRandom.Next((int)(error * 100f)));
				}
				element2.CheckRevealColor();
				Element element3 = new Element(element2);
				memory = element3;
				outSockets[1].SetElement(element2);
				elementHolder.MoveToNextBatch(batchSize);
			}
			else
			{
				if (outSockets[1].isFull())
				{
					return false;
				}
				outSockets[1].SetElement(element);
			}
			return true;
		case "RANDOMFOREST":
		{
			if (id != 2)
			{
				break;
			}
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			if (outConditionsColor[1] < 3)
			{
				if (outConditionsColor[1] == element.ColorId)
				{
					if (outSockets[1].isFull())
					{
						return false;
					}
					flag5 = true;
				}
			}
			else if (outConditionsColor[1] % 3 == element.ShapeId)
			{
				if (outSockets[1].isFull())
				{
					return false;
				}
				flag5 = true;
			}
			if (outConditionsColor[2] < 3)
			{
				if (outConditionsColor[2] == element.ColorId)
				{
					if (outSockets[2].isFull())
					{
						return false;
					}
					flag7 = true;
				}
			}
			else if (outConditionsColor[2] % 3 == element.ShapeId)
			{
				if (outSockets[2].isFull())
				{
					return false;
				}
				flag7 = true;
			}
			if (outConditionsColor[3] < 3)
			{
				if (outConditionsColor[3] == element.ColorId)
				{
					if (outSockets[3].isFull())
					{
						return false;
					}
					flag6 = true;
				}
			}
			else if (outConditionsColor[3] % 3 == element.ShapeId)
			{
				if (outSockets[3].isFull())
				{
					return false;
				}
				flag6 = true;
			}
			if (sortedRandomDict == null)
			{
				sortedRandomDict = new MultiDictionary<int, SchemeSocket>();
				sortedRandomList = new List<int>();
			}
			sortedRandomList.Clear();
			sortedRandomDict.Clear();
			if (flag5)
			{
				sortedRandomDict.Add(outConditionsColor[1], outSockets[1]);
				sortedRandomList.Add(outConditionsColor[1]);
			}
			if (flag7)
			{
				sortedRandomDict.Add(outConditionsColor[2], outSockets[2]);
				sortedRandomList.Add(outConditionsColor[2]);
			}
			if (flag6)
			{
				sortedRandomDict.Add(outConditionsColor[3], outSockets[3]);
				sortedRandomList.Add(outConditionsColor[3]);
			}
			if (sortedRandomList.Count > 0 && element.revealed)
			{
				sortedRandomList.Sort();
				HashSet<SchemeSocket> hashSet2 = sortedRandomDict[sortedRandomList[BlockRandom.Next(sortedRandomList.Count)]];
				List<SchemeSocket> list3 = new List<SchemeSocket>();
				foreach (SchemeSocket item5 in hashSet2)
				{
					list3.Add(item5);
				}
				list3[BlockRandom.Next(list3.Count)].SetElement(element);
			}
			else
			{
				if (socketsBuf == null)
				{
					socketsBuf = new List<SchemeSocket>();
				}
				socketsBuf.Add(outSockets[1]);
				socketsBuf.Add(outSockets[2]);
				socketsBuf.Add(outSockets[3]);
				socketsBuf[BlockRandom.Next(3)].SetElement(element);
			}
			return true;
		}
		case "ISOFOREST":
		{
			if (id != 2)
			{
				break;
			}
			bool flag = false;
			bool flag2 = false;
			if (outConditionsColor[0] == element.ColorId && outConditionsColor[1] == element.ShapeId)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			if (flag)
			{
				if (outSockets[1].isFull())
				{
					return false;
				}
				outSockets[1].SetElement(element);
			}
			if (flag2)
			{
				if (outSockets[3].isFull())
				{
					return false;
				}
				outSockets[3].SetElement(element);
			}
			return true;
		}
		case "ISOBJECT":
			return IsSMTHTeamplate(element, id, "unknown", "object", "empty");
		case "ISCAR":
			return IsSMTHTeamplate(element, id, "object", "car", "wall");
		}
		return false;
	}

	public bool IsSMTHTeamplate(Element elem, int id, string key, string keyTop, string keyBot)
	{
		if (id == 2)
		{
			if (elem.predictedObject != key)
			{
				elem.predictedObject = "unknown";
			}
			else
			{
				elem.predictedObject = CarObjectTree.Step(elem.predictedObject, elem.trueCellObject);
			}
			if (elem.predictedObject == "unknown")
			{
				int[] array = new int[2] { 2, 3 };
				outSockets[array[BlockRandom.Next(2)]].SetElement(elem);
			}
			else
			{
				if (elem.predictedObject == keyTop)
				{
					if (outSockets[2].isFull())
					{
						return false;
					}
					outSockets[2].SetElement(elem);
				}
				if (elem.predictedObject == keyBot)
				{
					if (outSockets[3].isFull())
					{
						return false;
					}
					outSockets[3].SetElement(elem);
				}
			}
			return true;
		}
		return false;
	}

	public int GetIdBySchemeBlock(SchemeBlock shbl)
	{
		for (int i = 0; i < blocks.Count; i++)
		{
			if (shbl == blocks[i])
			{
				return i;
			}
		}
		return -1;
	}

	public bool onlyLegalBlocks(string legal, string block)
	{
		string[] array = block.Split(',');
		int hashCode = KeyName.GetHashCode();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i].GetHashCode() == hashCode)
			{
				return false;
			}
		}
		if (Logic.IsBaseBlock(KeyName))
		{
			return legal.Contains(KeyName);
		}
		for (int j = 0; j < blocks.Count; j++)
		{
			if (!blocks[j].onlyLegalBlocks(legal, block))
			{
				return false;
			}
		}
		return true;
	}

	public bool containsBlock(string block)
	{
		KeyName.GetHashCode();
		if (Logic.IsBaseBlock(KeyName))
		{
			return block == KeyName;
		}
		for (int i = 0; i < blocks.Count; i++)
		{
			if (blocks[i].containsBlock(block))
			{
				return true;
			}
		}
		return false;
	}

	public bool hasRecursion(string customs)
	{
		if (Logic.IsBaseBlock(KeyName))
		{
			return false;
		}
		string[] array = customs.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == KeyName)
			{
				return true;
			}
		}
		int hashCode = KeyName.GetHashCode();
		foreach (SchemeBlock block in blocks)
		{
			if (!Logic.IsBaseBlock(block.KeyName))
			{
				if (block.GetHashCode() == hashCode)
				{
					return true;
				}
				if (block.hasRecursion(customs + "," + KeyName))
				{
					return true;
				}
			}
		}
		return false;
	}
}
