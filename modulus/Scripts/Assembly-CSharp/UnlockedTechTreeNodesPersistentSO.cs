using System;
using System.Collections.Generic;
using Data.SaveData;
using Data.Variables;
using UnityEngine;

[CreateAssetMenu(menuName = "PersistentSOs/TechTree", fileName = "UnlockedTechTreeNodesPersistentSO", order = 0)]
public class UnlockedTechTreeNodesPersistentSO : AbstractPersistentSO
{
	[SerializeField]
	private TechTreeSO _techTreeSO;

	[SerializeField]
	private IntVariableSO _lastUnlockedNodeID;

	public TechTreeSO TechTreeSo
	{
		get
		{
			return _techTreeSO;
		}
		set
		{
			_techTreeSO = value;
		}
	}

	public event Action<TechTreeSaveData> OnApplyLoadedSaveData = delegate
	{
	};

	public event Action OnResetToDefaults = delegate
	{
	};

	protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
	{
		TechTreeSaveData techTreeSaveData = saveData as TechTreeSaveData;
		_lastUnlockedNodeID.SetValue(techTreeSaveData.FocusedNodeID);
		this.OnApplyLoadedSaveData(techTreeSaveData);
	}

	public override void ResetToDefaults()
	{
		this.OnResetToDefaults();
	}

	public override AbstractSaveData GetSaveData()
	{
		List<TechTreeSaveDataNode> list = new List<TechTreeSaveDataNode>();
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			if (node.IsUnlocked)
			{
				list.Add(new TechTreeSaveDataNode(node.ID, node.UnlockedIndex, node.Cost));
			}
		}
		return new TechTreeSaveData(_techTreeSO.VersionGuid, list, _lastUnlockedNodeID.Value);
	}

	public override bool TryLoadSaveData(string fullPath)
	{
		return TryLoadSaveDataInternal<TechTreeSaveData>(fullPath);
	}
}
