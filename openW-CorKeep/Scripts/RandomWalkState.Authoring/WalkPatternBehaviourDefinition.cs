using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkPatternBehaviourDefinition", menuName = "WalkState/WalkPatternBehaviourDefinition")]
public class WalkPatternBehaviourDefinition : ScriptableObject
{
	[Serializable]
	public class WalkPatternGroupInSet
	{
		public float weight = 1f;

		public WalkPatternGroupDefinition walkPatternGroup;
	}

	public WalkStateSelectionType groupSelectionType;

	public List<WalkPatternGroupInSet> walkPatternGroups;
}
