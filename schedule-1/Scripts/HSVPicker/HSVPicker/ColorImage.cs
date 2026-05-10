using UnityEngine;
using UnityEngine.UI;

namespace HSVPicker
{
	[RequireComponent(typeof(Image))]
	public class ColorImage : MonoBehaviour
	{
		public ColorPicker picker;

		private Image image;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void ColorChanged(Color newColor)
		{
		}
	}
}
