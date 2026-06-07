using UnityEngine;
using UnityEngine.UI;

namespace VRTK.Examples
{
	public abstract class VRTKExample_OptionTile : MonoBehaviour
	{
		public Image backgroundImage;

		public Color highlightColor = Color.yellow;

		protected Color originalColor = Color.clear;

		public abstract void Activate();

		public virtual void Highlight()
		{
			if (backgroundImage != null)
			{
				originalColor = backgroundImage.color;
				backgroundImage.color = highlightColor;
			}
		}

		public virtual void Unhighlight()
		{
			if (backgroundImage != null)
			{
				backgroundImage.color = originalColor;
			}
		}
	}
}
