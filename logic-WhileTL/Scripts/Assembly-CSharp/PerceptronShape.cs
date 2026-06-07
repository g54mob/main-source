using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class PerceptronShape : BaseBlock
{
	private Socket socketIn;

	private Socket socketBlue;

	private Socket socketRed;

	private Socket socketGreen;

	[SceneBind("Error")]
	private Text Error;

	private int acc;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		_ = socketIn.queue[0];
		bool result = true;
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			if (socketsOut[i] != null && socketsOut[i].isFull())
			{
				result = false;
			}
		}
		return result;
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
		Element element = socketIn.GetElement();
		if (element == null)
		{
			return;
		}
		if (BlockRandom.NextDouble() > (double)error)
		{
			switch (element.ShapeId)
			{
			case 0:
				socketsOut[1].SetElement(element);
				break;
			case 1:
				socketsOut[2].SetElement(element);
				break;
			case 2:
				socketsOut[3].SetElement(element);
				break;
			}
			if (!IsTrained())
			{
				error = Mathf.Max(0.09f, Mathf.Min(1f, error + element.error));
			}
			else
			{
				error = 0.09f;
			}
			element.error /= 2f;
		}
		else
		{
			List<int> list = new List<int>();
			switch (element.ShapeId)
			{
			case 0:
				list.Add(2);
				list.Add(3);
				break;
			case 1:
				list.Add(1);
				list.Add(3);
				break;
			case 2:
				list.Add(2);
				list.Add(1);
				break;
			}
			if (!IsTrained())
			{
				error = Mathf.Max(0.09f, Mathf.Min(1f, error + element.error));
			}
			else
			{
				error = 0.09f;
			}
			element.error /= 2f;
			socketsOut[list[BlockRandom.Next() % 2]].SetElement(element);
		}
		Redraw();
	}

	public override void Redraw()
	{
		string text = "LOWERROR";
		if (100f * error > (float)(100 - acc))
		{
			text = "BIGERROR";
		}
		Error.text = Logic.ColorTransform(text, (int)(100f * error) + "%");
	}

	public override void Init()
	{
		if (!base.IsInited)
		{
			base.Init();
			minError = 0.09f;
			socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
			socketRed = base.transform.Find("SocketRed").GetComponent<Socket>();
			socketBlue = base.transform.Find("SocketBlue").GetComponent<Socket>();
			socketGreen = base.transform.Find("SocketGreen").GetComponent<Socket>();
			keyName = "PERCEPTRONSHAPE";
		}
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		if (ActiveComponent.Model.constructionState == ConstructionState.Startup)
		{
			acc = Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName).Acсuracy;
		}
		if (ActiveComponent.Model.constructionState == ConstructionState.SandBox)
		{
			acc = 75;
		}
		if (ActiveComponent.Model.constructionState == ConstructionState.Task || ActiveComponent.Model.constructionState == ConstructionState.Forum)
		{
			acc = Logic.GetCurrentTableQuest().Acсuracy;
		}
		socketsIn[2] = socketIn;
		socketsOut[1] = socketRed;
		socketsOut[2] = socketGreen;
		socketsOut[3] = socketBlue;
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			if (socketsIn[i] != null)
			{
				socketsIn[i].num = i;
			}
			if (socketsOut[i] != null)
			{
				socketsOut[i].num = i;
			}
		}
		error = 0.75f;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			error = sh.error;
		}
		if (!ActiveComponent.Model.construction.IsInNormalTaskRunMode())
		{
			error = minError;
		}
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
		Redraw();
	}
}
