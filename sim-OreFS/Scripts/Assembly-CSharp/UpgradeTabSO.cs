using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgradeTab", menuName = "Game/UpgradeTabSO")]
public class UpgradeTabSO : ScriptableObject
{
	public string tabName;

	public UpgradeCategory category;

	public List<UpgradeGroupSO> groups = new List<UpgradeGroupSO>();
}
