using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ImageFillAnimation : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		private float animationSpeed = 0.5f;

		private void Update()
		{
			if (base.gameObject.activeInHierarchy)
			{
				float num = Mathf.Abs(Mathf.Sin(Time.time * animationSpeed));
				image.fillClockwise = num > image.fillAmount;
				image.fillAmount = num;
			}
		}
	}
}
