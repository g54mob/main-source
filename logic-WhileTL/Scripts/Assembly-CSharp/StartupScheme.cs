using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class StartupScheme
{
	public int patch;

	public float timeInStartup;

	public int testRunsInStartup;

	public Cathub Cathub;

	public int released;

	public List<int> usersRetention = new List<int>();

	public Server serverType;

	public Startup baseStartup;

	public int startDay;

	public User audience;

	public SchemeBlock scheme;

	public List<int> lastUsers = new List<int>();

	public List<int> lastMoney = new List<int>();

	public List<float> lastFailed = new List<float>();

	public List<float> lastAccuracy = new List<float>();

	public List<int> lastServers = new List<int>();

	public int ServersCost;

	public int totalUsers;

	public int totalMoney;

	public int curUsers;

	public int type;

	public int firstDay;

	private List<List<int>> couMatrix = new List<List<int>>();

	private List<Element> elemQueue = new List<Element>();

	private List<bool> usersTaskComplete = new List<bool>();

	private int maxSockets = 5;

	private List<string> datasNames = new List<string>();

	private List<App.Data.Result> results = new List<App.Data.Result>();

	private ConstructionQuest cq;

	private int generatedUsers;

	private int generateBatch = 100;

	private List<int> packagedUserRetention;

	public StartupScheme()
	{
	}

	public int GetHypeValue()
	{
		if (Logic.GetModel().P == null)
		{
			return 0;
		}
		return (int)Logic.ParseMath(baseStartup.UsersInfluence, Logic.GetDay() - startDay);
	}

	public int GetUsersIncomeValue()
	{
		return lastUsers.LastItem() - lastUsers[lastUsers.Count - 2];
	}

	public Cathub GetCathub()
	{
		return Cathub;
	}

	public bool IsReleased()
	{
		return released == 1;
	}

	public StartupScheme(Startup startup)
	{
		baseStartup = startup;
		audience = new User(Logic.GetAudienceByKeyName(startup.AudienceType));
		Cathub = new Cathub();
	}

	public void SetReleased(int released)
	{
		if (this.released == 0 && released == 1)
		{
			StartStartup();
		}
		this.released = released;
		if (released == 0)
		{
			firstDay = 0;
		}
	}

	public void Init(Construction Construction)
	{
		SchemeBlock schemeBlock = new SchemeBlock();
		schemeBlock.Init(Construction);
		CathubScheme cathubScheme = new CathubScheme(schemeBlock, Construction.algoBlock.transform.position, Construction.algoBlock.transform.localScale, Construction.algoBlock.GetComponent<RectTransform>().pivot);
		Cathub.SetScheme(Cathub.GetCurrentScheme(), cathubScheme);
	}

	public void StartStartup()
	{
		DefaultInit();
		curUsers = (int)((float)audience.StartAudience * baseStartup.StartAudienceCoef);
		totalUsers = curUsers;
		usersRetention.Clear();
		for (int i = 0; i < curUsers; i++)
		{
			usersRetention.Add(Random.Range(audience.InterestMin, audience.InterestMax));
		}
		packagedUserRetention = new List<int>();
		foreach (int item in usersRetention)
		{
			while (packagedUserRetention.Count <= item)
			{
				packagedUserRetention.Add(0);
			}
			packagedUserRetention[item]++;
		}
		usersRetention.Clear();
		startDay = Logic.GetDay();
		serverType = Logic.GetServerByKeyName("DEBUG");
		Random.InitState(1234);
	}

	public int GetWeekIncome()
	{
		int num = 0;
		for (int i = 0; i < lastMoney.Count; i++)
		{
			num += lastMoney[i];
		}
		return num;
	}

	public int GetWeekServersCost()
	{
		int num = 0;
		for (int i = 0; i < lastMoney.Count; i++)
		{
			num += lastServers[i];
		}
		return num;
	}

	public void DefaultInit()
	{
		firstDay = 1;
		for (int i = 0; i < 7; i++)
		{
			lastUsers.Add(0);
			lastFailed.Add(0f);
			lastMoney.Add(0);
			lastAccuracy.Add(0f);
			lastServers.Add(0);
		}
	}

	public void ClearToSave()
	{
		scheme = null;
		couMatrix.Clear();
		elemQueue.Clear();
		usersTaskComplete.Clear();
		usersRetention.Clear();
	}

	private void GenerateData(int size)
	{
		while (elemQueue.Count < size)
		{
			for (int i = 0; i < datasNames.Count; i++)
			{
				App.Data.Data dataByKeyName = Logic.GetDataByKeyName(datasNames[i]);
				if (dataByKeyName == null)
				{
					continue;
				}
				couMatrix.Clear();
				couMatrix = Logic.GetCouMatrixInData(dataByKeyName, cq);
				if (dataByKeyName.words == "")
				{
					for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 3; k++)
						{
							if (couMatrix.Count <= j)
							{
								break;
							}
							if (couMatrix[j].Count <= k)
							{
								break;
							}
							for (int l = 0; l < couMatrix[j][k]; l++)
							{
								elemQueue.Add(new Element(j, k, test: false, cq, null, null, 0, i));
								if (elemQueue.Count >= curUsers)
								{
									break;
								}
							}
							if (elemQueue.Count >= curUsers)
							{
								break;
							}
						}
						if (elemQueue.Count >= curUsers)
						{
							break;
						}
					}
				}
				else
				{
					List<char> list = new List<char>();
					string truePredict = dataByKeyName.truePredict;
					foreach (char item in truePredict)
					{
						list.Add(item);
					}
					for (int n = 0; n < dataByKeyName.words.Length - cq.RNNBatch + 1; n++)
					{
						List<char> list2 = new List<char>();
						list2.Add(dataByKeyName.words[n]);
						for (int num = 1; num < cq.RNNBatch; num++)
						{
							list2.Add(dataByKeyName.words[n + num]);
						}
						Element element = new Element(0, 1, test: false, cq, list2, list, n, i);
						element.batchSize = cq.RNNBatch;
						if (dataByKeyName.colorsQueue != "")
						{
							element.colorsQueue = dataByKeyName.colorsQueue;
						}
						elemQueue.Add(element);
						if (elemQueue.Count >= curUsers)
						{
							break;
						}
					}
				}
				if (dataByKeyName.words == "")
				{
					for (int num2 = 0; num2 < elemQueue.Count; num2++)
					{
						Element value = elemQueue[num2];
						int index = Random.Range(0, elemQueue.Count);
						elemQueue[num2] = elemQueue[index];
						elemQueue[index] = value;
					}
				}
			}
		}
	}

	public void DayStep()
	{
		if (released == 0)
		{
			startDay = Logic.GetDay();
			return;
		}
		scheme = Cathub.GetCustomScheme();
		audience = new User(Logic.GetAudienceByKeyName(baseStartup.AudienceType));
		lastUsers.RemoveAt(0);
		lastUsers.Add(Mathf.Max(0, curUsers));
		cq = Logic.GetTaskByKeyName(baseStartup.TaskKeyName);
		results.Clear();
		results.Add(Logic.GetResultByKeyName(cq.Res0));
		results.Add(Logic.GetResultByKeyName(cq.Res1));
		results.Add(Logic.GetResultByKeyName(cq.Res2));
		results.Add(Logic.GetResultByKeyName(cq.Res3));
		results.Add(Logic.GetResultByKeyName(cq.Res4));
		datasNames.Clear();
		datasNames.Add(cq.Data0);
		datasNames.Add(cq.Data1);
		datasNames.Add(cq.Data2);
		datasNames.Add(cq.Data3);
		datasNames.Add(cq.Data4);
		elemQueue.Clear();
		scheme.ReInit();
		scheme.InitOnLoad(scheme);
		scheme.Clear();
		bool flag = scheme.onlyLegalBlocks(Logic.GetTaskByKeyName(baseStartup.TaskKeyName).UnlockedBlocks, "") && Logic.CheckConditions((QuestCondition)QuestLine.GetQuest(baseStartup.TaskKeyName).GetCondition(2), scheme);
		generatedUsers = 0;
		generateBatch = baseStartup.GenerateBatch;
		if (generateBatch == 0)
		{
			generateBatch = curUsers;
		}
		int size = Mathf.Min(curUsers - generatedUsers, generateBatch);
		GenerateData(size);
		foreach (Element item in elemQueue)
		{
			item.startup = true;
			item.error = 0f;
		}
		int num = 0;
		int num2 = 0;
		scheme.Clear();
		float num3 = 0.01f;
		for (int i = 0; i < 5; i++)
		{
			num3 = Mathf.Max(num3, scheme.GetInputSpeed(i));
		}
		num3 *= serverType.OverloadBonus + 1f;
		float num4 = 0f;
		float num5 = 0f - num3;
		int schemeUsersDayCapacity = Logic.GetSchemeUsersDayCapacity(scheme);
		List<Element> list = new List<Element>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		for (int j = 0; j < 5; j++)
		{
			list2.Add(0);
			list3.Add(0);
		}
		if (packagedUserRetention == null)
		{
			packagedUserRetention = new List<int>();
			foreach (int item2 in usersRetention)
			{
				while (packagedUserRetention.Count <= item2)
				{
					packagedUserRetention.Add(0);
				}
				packagedUserRetention[item2]++;
			}
		}
		else
		{
			usersRetention.Clear();
			foreach (int item3 in packagedUserRetention)
			{
				for (int k = 0; k < item3; k++)
				{
					usersRetention.Add(item3);
				}
			}
		}
		float num6 = 1f;
		scheme.Marking();
		int serversCou = scheme.GetServersCou(startup: true, 1);
		num6 = 1f + (float)(Mathf.Max(1, serversCou) - 1) * 0.08f;
		if (serversCou == scheme.GetBlocksCou(startup: true, 1))
		{
			num6 = 1f;
		}
		if (flag)
		{
			while (num4 < baseStartup.DayTime * num6)
			{
				if (elemQueue.Count == 0)
				{
					GenerateData(Mathf.Min(curUsers - generatedUsers, generateBatch));
					generatedUsers += elemQueue.Count;
				}
				if (list.Count == 0 && elemQueue.Count == 0)
				{
					break;
				}
				float num7 = 1E+14f;
				int num8 = -1;
				for (int l = 0; l < list.Count; l++)
				{
					if (list[l].exitTime < num7)
					{
						num7 = list[l].exitTime;
						num8 = l;
					}
				}
				if (num8 != -1)
				{
					if (list[num8].stopped)
					{
						num4 = list[num8].exitTime;
						list.RemoveAt(num8);
					}
					else
					{
						list[num8].recursionDepth = 0;
						bool flag2 = ResultCheckElement(cq, results[list[num8].socketOut], list[num8]);
						if (list[num8].colorsQueue != null)
						{
							flag2 = flag2 && list[num8].revealed;
						}
						if (flag2)
						{
							list2[list[num8].socketOut]++;
						}
						list3[list[num8].socketOut]++;
						if (flag2)
						{
							num++;
						}
						else
						{
							num2++;
						}
						num4 = list[num8].exitTime;
						list.RemoveAt(num8);
					}
				}
				while (num5 < num4)
				{
					num5 += num3;
					if (list.Count == schemeUsersDayCapacity)
					{
						continue;
					}
					if (elemQueue.Count == 0)
					{
						break;
					}
					Element element = elemQueue[0];
					float a = 0.01f;
					elemQueue.RemoveAt(0);
					element.Try = false;
					element.startup = true;
					element.recursionDepth = 0;
					if (scheme.inSockets[element.socketIn] == null)
					{
						break;
					}
					scheme.ClearBeforeRun();
					scheme.inSockets[element.socketIn].SetElement(element);
					scheme.PushInBlock();
					bool flag3 = false;
					for (int m = 0; m < maxSockets; m++)
					{
						if (scheme.outSockets[m] != null)
						{
							Element element2 = scheme.outSockets[m].GetElement();
							if (element2 != null)
							{
								element2.Try = false;
								element2.socketOut = m;
								element2.customOutSocket = -1;
								a = Mathf.Max(a, element2.timeInBlock);
								element2.exitTime = num5 + a;
								element2.stopped = false;
								element = element2;
								flag3 = true;
								break;
							}
						}
					}
					if (!flag3)
					{
						element.stopped = true;
						element.exitTime = num4 + element.timeInBlock;
					}
					list.Add(element);
				}
				if (num5 >= num4)
				{
					num4 = num5 + num3;
				}
			}
		}
		lastFailed.Add(Mathf.Max(0, curUsers - num - num2));
		num2 += elemQueue.Count + (curUsers - generatedUsers);
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		int num12 = 0;
		for (int n = 0; n < num; n++)
		{
			num11++;
			if ((float)Random.Range(audience.CallMin, audience.CallMax) * baseStartup.CallUserCoef >= (float)baseStartup.CallBorder)
			{
				for (int num13 = 0; num13 < audience.Callusers; num13++)
				{
					num9++;
					usersRetention.Add(Random.Range(audience.InterestMin, audience.InterestMax));
				}
			}
			if ((float)Random.Range(audience.RewardChanceMin, audience.RewardChanceMax) * baseStartup.RewardChanceCoef >= (float)baseStartup.RewardChanceBorder)
			{
				num10 += Random.Range(audience.RewardMin, audience.RewardMax);
			}
		}
		for (int num14 = 0; num14 < num2; num14++)
		{
			num12++;
			if ((float)Random.Range(audience.LeaveMin, audience.LeaveMax) * baseStartup.LeaveCoef >= (float)baseStartup.LeaveBorder)
			{
				for (int num15 = 0; num15 < Random.Range(audience.DeleteUsersLeaveMin, audience.DeleteUsersLeaveMax); num15++)
				{
					usersRetention[Random.Range(0, usersRetention.Count)] = 0;
				}
				usersRetention[num14] = 0;
			}
		}
		for (int num16 = 0; num16 < usersRetention.Count; num16++)
		{
			usersRetention[num16]--;
		}
		num10 = (int)(baseStartup.RewardCoef * (float)num10);
		for (int num17 = 0; num17 < usersRetention.Count; num17++)
		{
			if (usersRetention[num17] == 0)
			{
				usersRetention.RemoveAt(num17);
				num9--;
				num17--;
			}
		}
		int num18 = scheme.GetServersCost();
		if (num18 == 0)
		{
			num18 = 1;
		}
		float num19 = 0f;
		int num20 = 0;
		for (int num21 = 0; num21 < 5; num21++)
		{
			if (list3[num21] != 0 && scheme.outSockets[num21] != null)
			{
				num19 += Mathf.Min(1f, (float)list2[num21] / (float)list3[num21] + 0.01f * (float)(100 - results[num21].Accuracy));
				num20++;
			}
		}
		num19 /= (float)num20;
		if (num20 == 0)
		{
			num19 = 1f;
		}
		if (baseStartup.TutorialStartup)
		{
			num10 = (int)((float)num10 * Random.Range(0.9f, 1.1f) * num19);
			num9 = (int)((float)num9 * Random.Range(0.9f, 1.1f));
		}
		else
		{
			num10 = (int)((float)num10 * num19);
		}
		float num22 = Mathf.Max(0f, baseStartup.DayTime - num4) * serverType.ServerIdleCost;
		int num23 = 0;
		num23 = ((!baseStartup.TutorialStartup) ? ((int)((float)num18 * (num4 * serverType.ServerWorkCost + num22))) : ((int)((float)num18 * (num4 * serverType.ServerWorkCost + num22) * Random.Range(0.9f, 1.1f))));
		num23 = Mathf.Max(num23, 1);
		num9 += (int)Logic.ParseMath(baseStartup.UsersInfluence, Logic.GetDay() - startDay, lastUsers[lastUsers.Count - 1]);
		curUsers += num9;
		curUsers = Mathf.Max(0, curUsers);
		while (curUsers > usersRetention.Count)
		{
			usersRetention.Add(Random.Range(audience.InterestMin, audience.InterestMax));
		}
		while (curUsers < usersRetention.Count)
		{
			usersRetention.RemoveAt(0);
		}
		packagedUserRetention.Clear();
		foreach (int item4 in usersRetention)
		{
			while (packagedUserRetention.Count <= item4)
			{
				packagedUserRetention.Add(0);
			}
			packagedUserRetention[item4]++;
		}
		usersRetention.Clear();
		num10 += (int)Logic.ParseMath(baseStartup.MoneyInfluence, Logic.GetDay() - startDay, lastMoney[lastMoney.Count - 1]);
		curUsers = Mathf.Max(curUsers, 0);
		lastServers.Add(num23);
		lastMoney.Add(num10);
		lastMoney.RemoveAt(0);
		lastFailed.RemoveAt(0);
		lastServers.RemoveAt(0);
		elemQueue.Clear();
		scheme.Clear();
		couMatrix.Clear();
	}

	private bool ResultCheckElement(ConstructionQuest cq, App.Data.Result d, Element elem)
	{
		List<List<int>> list = new List<List<int>>();
		for (int i = 0; i < 3; i++)
		{
			list.Add(new List<int>());
			for (int j = 0; j < 3; j++)
			{
				list[i].Add(0);
			}
		}
		if (cq.OnlyColor == 1)
		{
			list[0][1] = d.RC + d.RS + d.RT;
			list[1][1] = d.GC + d.GS + d.GT;
			list[2][1] = d.BC + d.BS + d.BT;
		}
		else
		{
			list[0][0] = d.RC;
			list[1][0] = d.GC;
			list[2][0] = d.BC;
			list[0][1] = d.RS;
			list[1][1] = d.GS;
			list[2][1] = d.BS;
			list[0][2] = d.RT;
			list[1][2] = d.GT;
			list[2][2] = d.BT;
		}
		if (list[elem.ColorId][elem.ShapeId] > 0)
		{
			return true;
		}
		if (Random.Range(0f, 100f) > (float)d.Accuracy)
		{
			return true;
		}
		return false;
	}
}
