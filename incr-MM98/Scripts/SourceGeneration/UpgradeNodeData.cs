using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Upgrade", fileName = "UpgradeNode")]
public class UpgradeNodeData : ScriptableData<UpgradeNode>
{
	public Sprite sprite;

	public ResearchNode research;

	public double cost;

	public Operation operation;

	public List<Modifier> modifiers = new List<Modifier>();

	public UpgradeNode prerequisite;

	public Vector2Int gridPosition;

	protected override string LocalizationPrefix => "upgrade";

	protected override LocTable LocalizationTable => LocTable.Upgrades;

	public Vector2 GetPosition(Vector2 gridSize)
	{
		return new Vector2((float)gridPosition.x * gridSize.x, (float)(-gridPosition.y) * gridSize.y);
	}

	public static implicit operator UpgradeNode(UpgradeNodeData data)
	{
		return data.ID;
	}

	public static implicit operator UpgradeNodeData(UpgradeNode node)
	{
		return node.Data();
	}
}
