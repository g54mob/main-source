using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class ModelLoader : MonoBehaviour
{
	public List<TailModelMap> tailModelInfo = new List<TailModelMap>();

	public Dictionary<TailType, GameObject> tailTypeDict = new Dictionary<TailType, GameObject>();

	public List<EarModelMap> earModelInfo = new List<EarModelMap>();

	public Dictionary<EarType, GameObject> earTypeDict = new Dictionary<EarType, GameObject>();

	public List<NoseModelMap> noseModelInfo = new List<NoseModelMap>();

	public Dictionary<NoseType, GameObject> noseTypeDict = new Dictionary<NoseType, GameObject>();

	public List<HornModelMap> hornModelInfo = new List<HornModelMap>();

	public Dictionary<HornType, GameObject> hornTypeDict = new Dictionary<HornType, GameObject>();

	public List<WingModelMap> wingModelInfo = new List<WingModelMap>();

	public Dictionary<WingType, GameObject> wingTypeDict = new Dictionary<WingType, GameObject>();

	private void Awake()
	{
		FillTailTypeDict();
		FillEarTypeDict();
		FillNoseTypeDict();
		FillHornTypeDict();
		FillWingTypeDict();
	}

	public GameObject GetTailForType(TailType type)
	{
		return tailTypeDict[type];
	}

	public LocalizedString GetTailNameForType(TailType type)
	{
		for (int i = 0; i < tailModelInfo.Count; i++)
		{
			if (tailModelInfo[i].tailType == type)
			{
				return tailModelInfo[i].localizedName;
			}
		}
		return tailModelInfo[0].localizedName;
	}

	public GameObject GetEarForType(EarType type)
	{
		return earTypeDict[type];
	}

	public LocalizedString GetEarNameForType(EarType type)
	{
		for (int i = 0; i < earModelInfo.Count; i++)
		{
			if (earModelInfo[i].earType == type)
			{
				return earModelInfo[i].localizedName;
			}
		}
		return earModelInfo[0].localizedName;
	}

	public GameObject GetNoseForType(NoseType type)
	{
		return noseTypeDict[type];
	}

	public LocalizedString GetNoseNameForType(NoseType type)
	{
		for (int i = 0; i < noseModelInfo.Count; i++)
		{
			if (noseModelInfo[i].noseType == type)
			{
				return noseModelInfo[i].localizedName;
			}
		}
		return noseModelInfo[0].localizedName;
	}

	public GameObject GetHornForType(HornType type)
	{
		return hornTypeDict[type];
	}

	public LocalizedString GetHornNameForType(HornType type)
	{
		for (int i = 0; i < hornModelInfo.Count; i++)
		{
			if (hornModelInfo[i].hornType == type)
			{
				return hornModelInfo[i].localizedName;
			}
		}
		return hornModelInfo[0].localizedName;
	}

	public GameObject GetWingForType(WingType type)
	{
		return wingTypeDict[type];
	}

	public LocalizedString GetWingNameForType(WingType type)
	{
		for (int i = 0; i < wingModelInfo.Count; i++)
		{
			if (wingModelInfo[i].wingType == type)
			{
				return wingModelInfo[i].localizedName;
			}
		}
		return wingModelInfo[0].localizedName;
	}

	private void FillTailTypeDict()
	{
		for (int i = 0; i < tailModelInfo.Count; i++)
		{
			tailTypeDict[tailModelInfo[i].tailType] = tailModelInfo[i].tailModel;
		}
	}

	private void FillEarTypeDict()
	{
		for (int i = 0; i < earModelInfo.Count; i++)
		{
			earTypeDict[earModelInfo[i].earType] = earModelInfo[i].earModel;
		}
	}

	private void FillNoseTypeDict()
	{
		for (int i = 0; i < noseModelInfo.Count; i++)
		{
			noseTypeDict[noseModelInfo[i].noseType] = noseModelInfo[i].noseModel;
		}
	}

	private void FillHornTypeDict()
	{
		for (int i = 0; i < hornModelInfo.Count; i++)
		{
			hornTypeDict[hornModelInfo[i].hornType] = hornModelInfo[i].hornModel;
		}
	}

	private void FillWingTypeDict()
	{
		for (int i = 0; i < wingModelInfo.Count; i++)
		{
			wingTypeDict[wingModelInfo[i].wingType] = wingModelInfo[i].wingModel;
		}
	}
}
