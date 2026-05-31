using System.Collections.Generic;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class _NaughtyScriptableObject : ScriptableObject
	{
		[Expandable]
		public List<_TestScriptableObjectA> listA;
	}
}
