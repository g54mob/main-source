using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class RandomColorUGUI : MonoBehaviour
	{
		public delegate void OnColorChangedDelegate(Color color);

		public Image ColorImage;

		public UnityEvent<Color> OnColorChangedEvent;

		public OnColorChangedDelegate OnColorChanged;

		protected Color _color;

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				if (!(value == _color))
				{
					_color = value;
					updateColorImage(Color);
					OnColorChangedEvent?.Invoke(Color);
					OnColorChanged?.Invoke(Color);
				}
			}
		}

		public void Randomize()
		{
			Color = new Color(Random.value, Random.value, Random.value, 1f);
		}

		protected void updateColorImage(Color color)
		{
			ColorImage.color = color;
		}
	}
}
