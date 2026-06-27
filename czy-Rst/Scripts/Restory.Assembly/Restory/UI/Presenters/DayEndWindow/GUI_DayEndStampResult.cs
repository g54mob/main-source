using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters.DayEndWindow
{
	public class GUI_DayEndStampResult : MonoBehaviour
	{
		[SerializeField]
		private RawImage image;

		public void SetUp(Texture2D stampIcon, float iconRotationAngle)
		{
			image.texture = stampIcon;
			image.SetNativeSize();
			Vector3 eulerAngles = image.rectTransform.rotation.eulerAngles;
			image.rectTransform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, iconRotationAngle);
		}
	}
}
