using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class GeneticCopyBlockColor : BaseBlock
{
	private Socket socketIn;

	private Socket socketBlue;

	private Socket socketRed;

	private Socket socketGreen;

	[SceneBind("Error")]
	private Text Error;

	[SceneBind("EvolveBtn")]
	private Button Evolve;

	[SceneBind("EvolveBtn/Hide")]
	private Image Hide;

	[SceneBind("DropdownGlow")]
	private Image DropdownGlow;

	public bool hide;

	public float showError;

	private int checkedElems;

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
		return Mathf.Abs(minError - showError) < 0.005f;
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
			switch (element.ColorId)
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
		}
		else
		{
			List<int> list = new List<int>();
			switch (element.ColorId)
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
			socketsOut[list[(int)(BlockRandom.NextDouble() * 2.0)]].SetElement(element);
		}
		if (!element.Test)
		{
			showError = (showError + error) / 2f;
		}
		hide = false;
		Redraw();
	}

	public override void Redraw()
	{
		Hide.gameObject.SetActive(Mathf.Abs(showError - error) > 0.01f);
		Evolve.gameObject.GetComponent<ZoomOnMouse>().enabled = Mathf.Abs(showError - error) <= 0.01f;
		Evolve.enabled = Mathf.Abs(showError - error) <= 0.01f;
		string text = "LOWERROR";
		DropdownGlow.gameObject.SetActive(ActiveComponent.Model.construction.constrState == ConstructionState.Forum && !Hide.gameObject.activeSelf);
		if (100f * showError > (float)(100 - acc) || hide)
		{
			text = "BIGERROR";
		}
		if (IsTrained())
		{
			text = "LOWERROR";
		}
		if (IsTrained())
		{
			DropdownGlow.gameObject.SetActive(value: false);
		}
		if (hide && !Evolve.enabled)
		{
			Error.text = Logic.ColorTransform(text, "???%");
		}
		else
		{
			Error.text = Logic.ColorTransform(text, (int)(100f * showError) + "%");
		}
	}

	private void EvolveClick()
	{
		GameObject go = ActiveComponent.Model.construction.AttachNewBlockToMouse(base.gameObject).go;
		go.transform.position = Evolve.gameObject.transform.position;
		go.GetComponent<GeneticCopyBlockColor>().Init();
		GeneticCopyBlockColor component = go.GetComponent<GeneticCopyBlockColor>();
		List<Socket> list = component.socketsOut;
		list = component.socketsIn;
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			if (list[i] != null)
			{
				for (int j = 0; j < socketsIn[2].inChains.Count; j++)
				{
					ActiveComponent.Model.construction.CreateChainWithTransform(base.transform).SetSockets(socketsIn[2].inChains[j].socketIn, list[i]);
				}
			}
		}
		float f = Random.Range(-0.3f, -0.1f);
		while (Mathf.Abs(f) < 0.02f)
		{
			f = Random.Range(-0.3f, -0.1f);
		}
		component.error = Mathf.Clamp(error + Random.Range(-0.3f, -0.1f), 0.09f, 1f);
		component.showError = Mathf.Clamp(showError, 0.09f, 1f);
		component.hide = true;
		component.Redraw();
		DropdownGlow.gameObject.SetActive(value: false);
		Record();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Block_Install");
	}

	public override void Init()
	{
		if (!base.IsInited)
		{
			base.Init();
			minError = 0.09f;
			Evolve.onClick.RemoveAllListeners();
			Evolve.onClick.AddListener(EvolveClick);
			socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
			socketRed = base.transform.Find("SocketRed").GetComponent<Socket>();
			socketBlue = base.transform.Find("SocketBlue").GetComponent<Socket>();
			socketGreen = base.transform.Find("SocketGreen").GetComponent<Socket>();
		}
		hide = true;
		Evolve.onClick.RemoveAllListeners();
		Evolve.onClick.AddListener(EvolveClick);
		keyName = "GENCOPYBLOCKCOLOR";
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
		error = Random.Range(0.6f, 0.8f);
		showError = Random.Range(0.85f, 1f);
		Error.text = "ERROR ???%";
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			hide = sh.hide;
			error = sh.error;
			showError = sh.showError;
		}
		if (!ActiveComponent.Model.construction.IsInNormalTaskRunMode())
		{
			error = minError;
			showError = minError;
		}
		DropdownGlow.gameObject.SetActive(value: false);
		Redraw();
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
