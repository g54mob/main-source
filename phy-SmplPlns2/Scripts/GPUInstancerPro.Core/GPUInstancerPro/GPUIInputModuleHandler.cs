using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace GPUInstancerPro
{
	[RequireComponent(typeof(EventSystem))]
	public class GPUIInputModuleHandler : MonoBehaviour
	{
		private void Start()
		{
			if (TryGetComponent<StandaloneInputModule>(out var component))
			{
				Object.Destroy(component);
			}
			base.gameObject.AddOrGetComponent<InputSystemUIInputModule>();
		}
	}
}
