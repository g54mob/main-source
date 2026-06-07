using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class UnZIP : ActiveComponent
{
	[SceneBind("ZIPData")]
	private ZIPData Content;

	[SceneBind("ConverterZIP")]
	private ConverterZIP ConverterZIP;

	[SceneBind("ZIPData")]
	private ZIPData ZIPData;

	[SceneBind("LinesContainer")]
	private RectTransform LinesContainer;

	[SceneBind("ControlsLayer")]
	private RectTransform ControlsLayer;

	[SceneBind("ControlsLayer/Exit")]
	private Button Exit;

	[SceneBind("ControlsLayer/Hide")]
	private Toggle Hide;

	private List<Data> datas = new List<Data>();

	public float chainTime = 0.2f;

	public float dataDelay = 0.2f;

	private List<Chain> chains = new List<Chain>();

	private void ChangeValue(bool value)
	{
		ActiveComponent.Model.P.hideZIP = value;
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ConverterZIP.Init();
		ZIPData.Init();
		ZIPData.SetDelay(dataDelay);
		Exit.onClick.AddListener(CloseZIP);
		for (int i = 0; i < 5; i++)
		{
			datas.Add(base.transform.Find("DATA" + i).GetComponent<Data>());
			datas[i].SetBackPlay(state: true, dataDelay);
			datas[i].HideText();
			Socket[] componentsInChildren = datas[i].GetComponentsInChildren<Socket>();
			Socket[] array = componentsInChildren;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].dataNum = i;
			}
			Chain chain = Logic.CreateChain(LinesContainer.transform);
			chain.SetSockets(ConverterZIP.GetSocketId(incoming: false, i), componentsInChildren[0]);
			chain.DropValues();
			chain.SetMove(state: true);
			chain.SetSendTimer(chainTime);
			chains.Add(chain);
		}
		Chain chain2 = Logic.CreateChain(LinesContainer.transform);
		chain2.SetSockets(ZIPData.socket, ConverterZIP.GetSocketId(incoming: true, 2));
		chain2.DropValues();
		chain2.SetMove(state: true);
		chain2.SetSendTimer(chainTime);
		Hide.onValueChanged.AddListener(ChangeValue);
	}

	private void CloseZIP()
	{
		if (ActiveComponent.Model.construction.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			ActiveComponent.Model.construction.RunAllTutorials();
		}
	}

	public void InitZIP(ConstructionQuest cq)
	{
		Hide.isOn = ActiveComponent.Model.P.hideZIP;
		ActiveComponent.Model.curSpeed = 1f;
		ConverterZIP.ClearSockets();
		List<App.Data.Data> listDatas = Logic.GetListDatas(cq);
		foreach (Data data in datas)
		{
			data.InitQuest(cq, listDatas[data.dataNum], deploy: false, ConstructionState.Task);
			ConverterZIP.SetSocketState(data.dataNum, listDatas[data.dataNum] != null);
			if (listDatas[data.dataNum] != null)
			{
				data.HideText(listDatas[data.dataNum].truePredict != "");
			}
		}
		chains.ForEach(delegate(Chain ch)
		{
			ch.Clear();
		});
		ZIPData.Init(cq);
		if (ActiveComponent.Model.P.hideZIP)
		{
			CloseZIP();
		}
	}
}
