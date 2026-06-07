using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Misc/Set Cursor Attributes On Awake")]
	public class SetCursorAttributesOnAwake : MonoBehaviour
	{
		public bool visible;

		public CursorLockMode lockState;

		private void Awake()
		{
		}

		public void SetCursorVisibility(bool _visible)
		{
		}
	}
}
