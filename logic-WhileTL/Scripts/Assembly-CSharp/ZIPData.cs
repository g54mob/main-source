using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class ZIPData : BaseBlock
{
	[SceneBind("Socket")]
	public Socket socket;

	private List<Element> queue = new List<Element>();

	private ConstructionQuest cq;

	protected override bool TryActive()
	{
		if (queue.Count > 0)
		{
			return !socket.isFull();
		}
		return false;
	}

	protected override void Active()
	{
		if (queue.Count != 0)
		{
			socket.SetElement(queue[0]);
			queue.RemoveAt(0);
			if (queue.Count == 0)
			{
				GenerateData(cq);
			}
		}
	}

	public void SetDelay(float delayTimer)
	{
		base.delayTimer = delayTimer;
	}

	public void GenerateData(ConstructionQuest cq)
	{
		List<App.Data.Data> listDatas = Logic.GetListDatas(cq);
		for (int i = 0; i < listDatas.Count; i++)
		{
			if (listDatas[i] == null)
			{
				continue;
			}
			List<List<int>> couMatrixInData = Logic.GetCouMatrixInData(listDatas[i], cq);
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					for (int l = 0; l < couMatrixInData[j][k]; l++)
					{
						queue.Add(new Element(j, k, test: false));
						SpriteHolder zIPSpriteByKeyName = Logic.GetZIPSpriteByKeyName(cq.KeyName + "_" + k + j);
						string spriteName = Logic.GetZIPSpriteByKeyName("DEFAULT_ZIP").spriteName;
						if (zIPSpriteByKeyName != null)
						{
							spriteName = zIPSpriteByKeyName.spriteName;
						}
						Element element = queue.LastItem();
						element.SetZIPSprite(spriteName);
						element.inputNum = i;
						if (listDatas[i].truePredict != "")
						{
							element.word = new List<char>();
							for (int m = 0; m < cq.RNNCapacity; m++)
							{
								element.word.Add((char)(65 + Random.Range(0, 26)));
							}
						}
					}
				}
			}
		}
		queue.Shuffle();
	}

	public void Init(ConstructionQuest cq)
	{
		socket.Clear();
		lastActiveTime = Time.time;
		this.cq = cq;
		GenerateData(cq);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
	}

	protected override void FixedUpdate()
	{
		if (Mathf.Abs(Time.time - lastActiveTime - delayTimer) <= 0.01f || Time.time - lastActiveTime >= delayTimer)
		{
			Active();
			lastActiveTime = Time.time;
		}
	}
}
