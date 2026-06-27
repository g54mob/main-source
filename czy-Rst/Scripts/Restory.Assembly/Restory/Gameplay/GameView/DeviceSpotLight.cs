using UnityEngine;

namespace Restory.Gameplay.GameView
{
	public class DeviceSpotLight : MonoBehaviour
	{
		[SerializeField]
		private Light spotLight;

		public Light Light => spotLight;
	}
}
