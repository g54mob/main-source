using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TechTree", menuName = "Tech Tree/Tech Tree")]
public class TechTreeSO : ScriptableObject
{
	public List<TechTreeNodeSO> Nodes = new List<TechTreeNodeSO>();

	public string VersionGuid;
}
