using System;
using System.Collections.Generic;
using App.Data;
using DeepTraffic;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.UI;

public class CarEnvironment : ActiveComponent
{
	[SceneBind("SocketIn")]
	private Socket socketIn;

	[SceneBind("REMOVE")]
	private Socket socketOut;

	[SceneBind("LineHolder")]
	private RectTransform LineHolder;

	private List<Element> elems = new List<Element>();

	private List<Element> elemBuff = new List<Element>();

	private Chain ch;

	private int enviromentLengh = -1;

	private int envIter;

	private int magicConstant = 3;

	private bool state;

	private float timer;

	private DeepTrafficEnvironment curEnv;

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		ch = ActiveComponent.Model.GetChainObjectFromPool(ActiveComponent.Model.chainPrefab, base.gameObject.transform.position, base.gameObject.transform.rotation, LineHolder.transform);
		ch.GetComponent<Image>().enabled = false;
		ch.GetComponent<Chain>().SetInSocket(socketIn);
		ch.GetComponent<Chain>().SetOutSocket(socketOut);
		socketOut.gameObject.GetComponent<RemoveSocket>().Init();
	}

	public void SetState(bool state, DeepTrafficEnvironment env = null)
	{
		this.state = state;
		if (state)
		{
			timer = -1f;
			curEnv = env;
			return;
		}
		socketIn.Clear();
		socketOut.Clear();
		elems.Clear();
		ch.DropValues();
		ch.SetMove(state: true);
	}

	private void AddPredictedElem(int lidarId, CellObjects cell, System.Random random)
	{
		int code = ActiveComponent.Model.construction.PredictCode(lidarId, cell, new System.Random());
		elemBuff.Add(new Element(cell, CarObjectTree.GetNameByCode(code)));
	}

	private void Active()
	{
		if (elems.Count <= 0)
		{
			elems.Clear();
			elemBuff.Clear();
			System.Random random = new System.Random();
			CellObjects[] array = curEnv.State;
			DeepTrafficEnvPresets carEnv = QuestLine.GetCurrentCarQuest().CarEnv;
			int num = DeepTrafficStatic.BehindLidarBound(carEnv);
			int num2 = DeepTrafficStatic.FrontLidarBound(carEnv);
			for (int i = 0; i < num; i++)
			{
				if (carEnv.enabledLidarCells[i])
				{
					AddPredictedElem(2, array[i], random);
				}
			}
			for (int j = num; j < num2; j++)
			{
				if (carEnv.enabledLidarCells[j])
				{
					if (DeepTrafficStatic.IsLeft(j, carEnv))
					{
						AddPredictedElem(0, array[j], random);
					}
					else
					{
						AddPredictedElem(2 + ((num > 0) ? 1 : 0), array[j], random);
					}
				}
			}
			for (int k = num2; k < array.Length; k++)
			{
				if (carEnv.enabledLidarCells[k])
				{
					if (DeepTrafficStatic.IsLeft(k, carEnv))
					{
						AddPredictedElem(0, array[k], random);
					}
					else if (DeepTrafficStatic.IsFront(k, carEnv))
					{
						AddPredictedElem((num2 > 0) ? 1 : 0, array[k], random);
					}
					else
					{
						AddPredictedElem(2 + ((num > 0) ? 1 : 0), array[k], random);
					}
				}
			}
			if (elemBuff.Count != enviromentLengh)
			{
				enviromentLengh = elemBuff.Count;
				envIter = 0;
			}
			for (int l = envIter; l < Mathf.Min(enviromentLengh, envIter + magicConstant); l++)
			{
				elems.Add(elemBuff[l]);
			}
			envIter += magicConstant;
			if (enviromentLengh != 0)
			{
				envIter %= enviromentLengh;
			}
		}
		if (enviromentLengh != 0)
		{
			socketIn.SetElement(elems[0]);
			elems.RemoveAt(0);
		}
	}

	private void FixedUpdate()
	{
		if (state && (double)Time.time - 0.2 > (double)timer)
		{
			timer = Time.time;
			Active();
		}
	}
}
