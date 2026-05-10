using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class SortingLayerTest : MonoBehaviour
	{
		[SortingLayer]
		public int layerNumber0;

		[SortingLayer]
		public string layerName0;

		public SortingLayerNest1 nest1;

		[Button(null, EButtonEnableMode.Always)]
		public void DebugLog()
		{
		}
	}
}
