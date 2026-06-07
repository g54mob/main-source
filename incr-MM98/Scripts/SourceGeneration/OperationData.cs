using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Operation", fileName = "Operation")]
public class OperationData : ScriptableData<Operation>
{
	public double cost;

	public float costScale = 1f;

	public float duration = 1f;

	public bool allowMultipleUses = true;

	public List<UpgradeModifier> modifiers = new List<UpgradeModifier>();

	public List<Reward> rewards = new List<Reward>();

	protected override string LocalizationPrefix => "operations";

	protected override LocTable LocalizationTable => LocTable.Operations;

	public static implicit operator Operation(OperationData data)
	{
		return data.ID;
	}

	public static implicit operator OperationData(Operation node)
	{
		return node.Data();
	}
}
