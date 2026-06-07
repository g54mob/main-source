using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class RNNCELL : BaseBlock
{
	private Element elementHolder;

	[SceneBind("ShowPredict")]
	private Text ShowPredict;

	[SceneBind("MemoryText")]
	private Text MemoryText;

	[SceneBind("Error")]
	private Text Error;

	private string result = "";

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
		if (elementHolder == null || elementHolder.word.Count < elementHolder.batchSize)
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
		if (elementHolder.word.Count < elementHolder.batchSize)
		{
			return false;
		}
		return true;
	}

	public override void Clear()
	{
		base.Clear();
		elementHolder = null;
		memory = null;
		MemoryText.text = "";
		ShowPredict.text = "";
	}

	public override bool IsTrained()
	{
		return Mathf.Abs(error - minError) < 0.005f;
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
		for (int i = 0; i < memsize; i++)
		{
			if ((float)BlockRandom.NextDouble() > error && element != null)
			{
				if (elementHolder.iterWord + i + elementHolder.batchSize < elementHolder.truePredict.Count)
				{
					list.Add(elementHolder.truePredict[elementHolder.iterWord + i + elementHolder.batchSize]);
					if (!IsTrained())
					{
						error = Mathf.Max(0.1f, Mathf.Min(1f, error + elementHolder.error));
					}
					else
					{
						error = 0.1f;
					}
					elementHolder.error /= 2f;
					if (!ActiveComponent.Model.construction.testMode)
					{
						elementHolder.ApplyRevealScore(100 - (int)(BlockRandom.NextDouble() * (double)error * 100.0));
					}
				}
				continue;
			}
			list.Add((char)(65 + Random.Range(0, 26)));
			if (element != null)
			{
				if (!IsTrained())
				{
					error = Mathf.Max(0.1f, Mathf.Min(1f, error + elementHolder.error));
				}
				else
				{
					error = 0.1f;
				}
				elementHolder.error /= 2f;
			}
		}
		Element element2 = new Element(0, 1, test: false, null, list, elementHolder.truePredict, elementHolder.iterWord + elementHolder.batchSize);
		element2.error = elementHolder.error;
		element2.revealed = elementHolder.revealed;
		element2.colorsQueue = elementHolder.colorsQueue;
		element2.batchSize = elementHolder.batchSize;
		element2.CheckRevealColor();
		Element elem = new Element(element2);
		socketsOut[3].SetElement(elem);
		socketsOut[1].SetElement(element2);
		Redraw(elementHolder, memory, element2);
		elementHolder.MoveToNextBatch(elementHolder.batchSize);
	}

	public override void Init()
	{
		if (!base.IsInited)
		{
			base.Init();
			minError = 0.1f;
			result = "";
			socketsIn.Clear();
			socketsOut.Clear();
			SceneBindContainer.BindObjects(this, base.transform);
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
		}
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName("RNNCELL") + " " + TextResources.GetString("SEC"));
		error = 0.75f;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			error = sh.error;
			init = true;
		}
		delayTimer = Logic.GetWorkTimeByKeyName("RNNCELL");
		ShowPredict.text = "";
		MemoryText.text = "";
		string text = "LOWERROR";
		if (100f * error > (float)(100 - Logic.GetCurrentTableQuest().Acсuracy))
		{
			text = "BIGERROR";
		}
		if (!ActiveComponent.Model.construction.IsInNormalTaskRunMode())
		{
			error = minError;
		}
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
		if (!tutorial)
		{
			ShowPredict.text = text.ToUpper();
		}
	}

	public override void Redraw()
	{
		string text = "LOWERROR";
		if (100f * error > (float)(100 - Logic.GetCurrentTableQuest().Acсuracy))
		{
			text = "BIGERROR";
		}
		Error.text = Logic.ColorTransform(text, (int)(100f * error) + "%");
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
