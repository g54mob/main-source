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
			Debug.LogFormat("{0} = {1}", "layerNumber0", layerNumber0);
			Debug.LogFormat("{0} = {1}", "layerName0", layerName0);
			Debug.LogFormat("LayerToName({0}) = {1}", layerNumber0, LayerMask.LayerToName(layerNumber0));
			Debug.LogFormat("NameToLayer({0}) = {1}", layerName0, LayerMask.NameToLayer(layerName0));
		}
	}
}
