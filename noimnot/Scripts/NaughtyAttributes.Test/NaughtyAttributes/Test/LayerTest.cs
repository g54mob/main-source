using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class LayerTest : MonoBehaviour
	{
		[Layer]
		public int layerNumber0;

		[Layer]
		public string layerName0;

		public LayerNest1 nest1;

		[Button(null, EButtonEnableMode.Always)]
		public void DebugLog()
		{
		}
	}
}
