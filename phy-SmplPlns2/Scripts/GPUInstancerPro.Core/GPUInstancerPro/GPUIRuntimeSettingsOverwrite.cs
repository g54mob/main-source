using UnityEngine;

namespace GPUInstancerPro
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(-1000)]
	public class GPUIRuntimeSettingsOverwrite : MonoBehaviour
	{
		public GPUIRuntimeSettings runtimeSettingsOverwrite;

		private void OnEnable()
		{
			GPUIRuntimeSettings.OverwriteSettings(runtimeSettingsOverwrite);
		}
	}
}
