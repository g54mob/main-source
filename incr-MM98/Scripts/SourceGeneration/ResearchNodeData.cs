using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Research", fileName = "ResearchNode")]
public class ResearchNodeData : ScriptableData<ResearchNode>
{
	public Sprite sprite;

	public double cost;

	public bool demo;

	public ResearchNodeDirectory directory;

	public Operation operation;

	public List<Modifier> modifiers = new List<Modifier>();

	protected override string LocalizationPrefix => "research";

	protected override LocTable LocalizationTable => LocTable.Research;

	public static implicit operator ResearchNode(ResearchNodeData data)
	{
		return data.ID;
	}

	public static implicit operator ResearchNodeData(ResearchNode node)
	{
		return node.Data();
	}
}
