using UnityEngine;

namespace DV.Interaction.Inputs
{
	public class RewiredFocusManager : MonoBehaviour
	{
		private void Start()
		{
			OnApplicationFocus(Application.isFocused);
		}

		private void OnDestroy()
		{
			OnApplicationFocus(hasFocus: true);
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			InputManager.SetKeyboardAndMouseEnabled(this, hasFocus);
		}
	}
}
