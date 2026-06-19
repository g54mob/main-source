using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkPatternGroupDefinition", menuName = "WalkState/WalkPatternGroupDefinition")]
public class WalkPatternGroupDefinition : ScriptableObject
{
	[Serializable]
	public class WalkPatterInGroup
	{
		public float weight = 1f;

		public WalkPatternDefinition walkPattern;
	}

	public WalkStateSelectionType groupSelectionType;

	public List<WalkPatterInGroup> walkPatterns;
}
