using UnityEngine;

public class Phantom : MonoBehaviour
{
	public enum Method
	{
		AfterMomentVisited = 0,
		AfterMomentUnlocked = 1,
		External = 2
	}

	public Method method;

	[MomentId]
	public string momentId;

	[MomentId]
	public string orMomentId;

	public string externalStatId;

	public bool keepInStaticMoment;

	private bool importingCorpse;

	private void Init()
	{
		bool flag = false;
		if (method == Method.AfterMomentVisited)
		{
			flag = SaveData.it.momentRo[momentId].visited;
			if (orMomentId.HasValue())
			{
				flag |= SaveData.it.momentRo[orMomentId].visited;
			}
		}
		else if (method == Method.AfterMomentUnlocked)
		{
			flag = SaveData.it.momentRo[momentId].unlocked;
			if (orMomentId.HasValue())
			{
				flag |= SaveData.it.momentRo[orMomentId].unlocked;
			}
		}
		else if (externalStatId.HasValue())
		{
			flag = SaveData.it.GetStat(externalStatId) > 0;
		}
		Force(flag);
	}

	private void Start()
	{
		Init();
	}

	public void Force(bool wantAfter)
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			GameObject gameObject = base.transform.GetChild(i).gameObject;
			if (gameObject.name.StartsWith("before") || gameObject.name.StartsWith("closed"))
			{
				gameObject.SetActive(!wantAfter);
			}
			else if (gameObject.name.StartsWith("after") || gameObject.name.StartsWith("open"))
			{
				gameObject.SetActive(wantAfter);
			}
		}
		if (externalStatId.HasValue())
		{
			SaveData.it.SetStat(externalStatId, wantAfter ? 1 : 0);
		}
	}
}
