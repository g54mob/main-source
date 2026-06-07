using System.Collections.Generic;
using UnityEngine;

public class RelicManager : Singleton<RelicManager>
{
	[SerializeField]
	private List<eItemType> list_LoadedRelicTypes;

	[SerializeField]
	private Dictionary<eItemType, ARelicBase> dict_LoadedRelics;

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRelicChanged(List<eItemType> list_Relics)
	{
	}

	public ARelicBase GetLoadedRelicByType(eItemType type)
	{
		return null;
	}

	public void AddRelic(eItemType type)
	{
	}

	private ARelicBase AddComponentByRelicType(eItemType itemType)
	{
		return null;
	}
}
