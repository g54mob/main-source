using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace RainbowArt.CleanFlatUI
{
	public class InputModuleSwitch : MonoBehaviour
	{
		private void Awake()
		{
			StandaloneInputModule component = base.gameObject.GetComponent<StandaloneInputModule>();
			if ((bool)component)
			{
				Object.Destroy(component);
			}
			if (base.gameObject.GetComponent<InputSystemUIInputModule>() == null)
			{
				base.gameObject.AddComponent<InputSystemUIInputModule>();
			}
		}
	}
}
