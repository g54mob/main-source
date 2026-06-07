using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ExpandableScriptableObjectNest1
	{
		[Expandable]
		public ScriptableObject obj1;

		public ExpandableScriptableObjectNest2 nest2;
	}
}
