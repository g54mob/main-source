using UnityEngine;

namespace GPUInstancerPro
{
	[DefaultExecutionOrder(-310)]
	[DisallowMultipleComponent]
	public class GPUIOptionalRenderer : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		public GPUIPrefabBase prefabBase;

		[SerializeField]
		[HideInInspector]
		public int optionalRendererNo;

		private void OnEnable()
		{
			prefabBase?.SetOptionalRendererEnabled(this, enabled: true);
		}

		private void OnDisable()
		{
			prefabBase?.SetOptionalRendererEnabled(this, enabled: false);
		}
	}
}
