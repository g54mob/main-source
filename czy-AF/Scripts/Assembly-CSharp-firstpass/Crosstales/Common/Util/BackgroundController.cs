using UnityEngine;

namespace Crosstales.Common.Util
{
	public class BackgroundController : MonoBehaviour
	{
		[Tooltip("Selected objects to disable in the background for the controller.")]
		public GameObject[] Objects;

		private bool isFocused;
	}
}
