using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ExpandableScriptableObjectNest2
	{
		[Expandable]
		public ScriptableObject obj2;
	}
}
