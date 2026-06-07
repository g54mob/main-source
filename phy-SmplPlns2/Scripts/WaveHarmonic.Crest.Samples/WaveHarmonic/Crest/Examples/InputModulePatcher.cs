using UnityEngine;
using UnityEngine.EventSystems;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	internal sealed class InputModulePatcher : MonoBehaviour
	{
		private void OnEnable()
		{
			GetComponent<StandaloneInputModule>().enabled = false;
		}
	}
}
