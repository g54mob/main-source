using System;
using System.Collections.Generic;
using UnityEngine;

public class SandboxScheme
{
	public bool active;

	public List<SandboxData> datas;

	public List<SandboxResult> results;

	public Cathub catHub;

	private static int MaxInputs = 5;

	private static int MaxOutputs = 5;

	public void InitEmpty()
	{
		active = false;
		catHub = new Cathub();
		datas = new List<SandboxData>();
		results = new List<SandboxResult>();
		for (int i = 0; i < MaxInputs; i++)
		{
			datas.Add(new SandboxData());
			datas[datas.Count - 1].InitEmpty();
		}
		for (int j = 0; j < MaxOutputs; j++)
		{
			results.Add(new SandboxResult());
			results[results.Count - 1].InitEmpty();
		}
	}

	public SchemeBlock GetUseAsCustomScheme()
	{
		return catHub.GetCustomScheme();
	}

	public bool IsActive()
	{
		return active;
	}

	public SandboxData GetData(int id)
	{
		return datas[id];
	}

	public SandboxResult GetResult(int id)
	{
		return results[id];
	}

	public SchemeBlock GetCurrentScheme()
	{
		return catHub.GetLastOpenScheme();
	}

	public CathubScheme GetCathubScheme(int i)
	{
		return catHub.GetScheme(i);
	}

	public void SetUseAsCustom(int id)
	{
		catHub.SetUseAsCustom(id);
	}

	public int GetUseAsCustomId()
	{
		return catHub.GetUseAsCustom();
	}

	public Cathub GetCatHub()
	{
		if (catHub == null)
		{
			catHub = new Cathub();
		}
		return catHub;
	}

	public void Init(Construction constr)
	{
		active = true;
		datas = new List<SandboxData>();
		results = new List<SandboxResult>();
		foreach (Data data in constr.datas)
		{
			datas.Add(new SandboxData(Convert.ToInt32(data.IsActive()), data.data));
		}
		foreach (Result result in constr.results)
		{
			results.Add(new SandboxResult(Convert.ToInt32(result.IsActive()), result.result));
		}
		SchemeBlock schemeBlock = new SchemeBlock();
		schemeBlock.Init(constr);
		int currentScheme = catHub.GetCurrentScheme();
		Transform transform = constr.algoBlock.transform;
		catHub.SetScheme(currentScheme, new CathubScheme(schemeBlock, transform.localPosition, transform.localScale, transform.GetComponent<RectTransform>().pivot));
	}
}
