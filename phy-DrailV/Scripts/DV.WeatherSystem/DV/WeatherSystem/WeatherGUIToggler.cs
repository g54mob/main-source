using UnityEngine;

namespace DV.WeatherSystem
{
	public class WeatherGUIToggler : MonoBehaviour
	{
		public WeatherEditorGUI guiScript;

		public KeyCode toggleKey = KeyCode.CapsLock;

		private void Start()
		{
			SetState(enabled: false);
		}

		protected virtual void SetState(bool enabled)
		{
			guiScript.enabled = enabled;
		}

		private void Update()
		{
			if (Input.GetKeyDown(toggleKey))
			{
				SetState(!guiScript.enabled);
			}
		}
	}
}
