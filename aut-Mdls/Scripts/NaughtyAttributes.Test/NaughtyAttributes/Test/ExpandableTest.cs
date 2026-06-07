using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ExpandableTest : MonoBehaviour
	{
		public int precedingField = 5;

		[Expandable]
		public ScriptableObject obj0;

		public ExpandableScriptableObjectNest1 nest1;
	}
}
