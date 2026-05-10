using System.Collections.Generic;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class _TestScriptableObjectA : ScriptableObject
	{
		[Expandable]
		public List<_TestScriptableObjectB> listB;
	}
}
