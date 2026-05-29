using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.Frame
{
	public class UITutorialArrow : MonoBehaviour
	{
		[SerializeField]
		private Image _img;

		private float _progress;

		private void Update()
		{
			_progress += Time.deltaTime;
			_img.color = new Color(1f, 1f, 1f, Mathf.Abs(Mathf.Sin(_progress)));
			((RectTransform)base.transform).anchoredPosition = new Vector2(0f, 80f + 40f * Mathf.Abs(Mathf.Cos(_progress)));
		}
	}
}
