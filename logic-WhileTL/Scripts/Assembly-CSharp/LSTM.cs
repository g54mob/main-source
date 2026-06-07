using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class LSTM : BaseBlock
{
	private Element elementHolder;

	[SceneBind("ShowPredict")]
	private Text ShowPredict;

	[SceneBind("MemoryText")]
	private Text MemoryText;

	[SceneBind("Error")]
	private Text Error;

	private string result = "";

	public new float error;

	private int memsize = 1;

	private Element memory;

	private bool init;

	protected override bool TryActive()
	{
		result = "_";
		if (socketsIn[1].queue.Count == 0)
		{
			return false;
		}
		if (socketsOut[1].isFull())
		{
			return false;
		}
		if (elementHolder == null || elementHolder.word.Count < Logic.GetCurrentTableQuest().RNNBatch)
		{
			Element element = socketsIn[1].GetElement();
			if (elementHolder == null)
			{
				elementHolder = element;
			}
			else
			{
				elementHolder.AddToRNNHolder(element);
			}
		}
		if (elementHolder.word.Count < Logic.GetCurrentTableQuest().RNNBatch)
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
		socketsOut[4].SetElement(memory);
		memory = socketsIn[4].GetElement();
		Element element = socketsIn[3].GetElement();
		List<char> list = new List<char>();
		int rNNBatch = Logic.GetCurrentTableQuest().RNNBatch;
		for (int i = 0; i < memsize; i++)
		{
			if (Random.Range(0f, 1f) > error && element != null)
			{
				if (elementHolder.iterWord + i + rNNBatch < elementHolder.truePredict.Count)
				{
					list.Add(elementHolder.truePredict[elementHolder.iterWord + i + rNNBatch]);
					error = Mathf.Max(0.1f, Mathf.Min(1f, error + elementHolder.error));
					elementHolder.error /= 2f;
				}
			}
			else
			{
				list.Add((char)(65 + Random.Range(0, 26)));
				if (element != null)
				{
					error = Mathf.Max(0.11f, Mathf.Min(1f, error + elementHolder.error));
					elementHolder.error /= 2f;
				}
			}
		}
		Element element2 = new Element(0, 0, test: false, null, list, elementHolder.truePredict, elementHolder.iterWord + rNNBatch);
		element2.error = elementHolder.error;
		Element elem = new Element(element2);
		socketsOut[3].SetElement(elem);
		socketsOut[1].SetElement(element2);
		Redraw(elementHolder, memory, element2);
		elementHolder.MoveToNextBatch(rNNBatch);
	}

	public override void Init()
	{
		if (base.IsInited)
		{
			return;
		}
		Random.InitState(1234);
		result = "";
		SceneBindContainer.BindObjects(this, base.transform);
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName("LSTM") + " " + TextResources.GetString("SEC"));
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			Transform transform = base.transform.Find("SocketIn" + i);
			if (transform != null)
			{
				socketsIn.Add(transform.GetComponent<Socket>());
			}
			else
			{
				socketsIn.Add(null);
			}
			transform = base.transform.Find("SocketOut" + i);
			if (transform != null)
			{
				socketsOut.Add(transform.GetComponent<Socket>());
			}
			else
			{
				socketsOut.Add(null);
			}
		}
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
		error = 0.75f;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			error = sh.error;
			init = true;
		}
		delayTimer = Logic.GetWorkTimeByKeyName("LSTM");
		ShowPredict.text = "";
		MemoryText.text = "";
		string text = "BIGERROR";
		Error.text = Logic.ColorTransform(text, (int)(100f * error) + "%");
	}

	private void Redraw(Element a, Element m, Element b)
	{
		Redraw();
		string text = "";
		text = Logic.WordToString(a.word) + " + [";
		if (m != null)
		{
			MemoryText.text = Logic.WordToString(m.word).ToUpper();
			text += Logic.WordToString(m.word);
		}
		else
		{
			MemoryText.text = "";
			text += " ";
		}
		text = text + "] = " + Logic.WordToString(b.word);
		ShowPredict.text = text.ToUpper();
	}

	public new void Redraw()
	{
		string text = "LOWERROR";
		if (100f * error > (float)(100 - Logic.GetCurrentTableQuest().Acсuracy))
		{
			text = "BIGERROR";
		}
		Error.text = Logic.ColorTransform(text, (int)(100f * error) + "%");
	}

	private void Awake()
	{
		Init();
	}

	protected override void FixedUpdate()
	{
		if (socketsIn[1].queue.Count == 0)
		{
			lastActiveTime = timer;
		}
		timer += Time.deltaTime * ActiveComponent.Model.curSpeed;
		if (timer - lastActiveTime >= delayTimer)
		{
			Active();
			lastActiveTime = timer;
		}
	}
}
