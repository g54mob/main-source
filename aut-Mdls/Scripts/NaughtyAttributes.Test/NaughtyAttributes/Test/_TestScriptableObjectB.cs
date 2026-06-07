using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class _TestScriptableObjectB : ScriptableObject
	{
		[MinMaxSlider(0f, 10f)]
		public Vector2Int slider;
	}
}
