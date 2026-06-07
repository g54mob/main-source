using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RuleBookScreenData", menuName = "RuleBookScreens")]
public class RuleBookScreenData : ScriptableObject
{
	public List<RuleBookPage> ruleBookPages = new List<RuleBookPage>();

	public bool isTableOfContents;
}
