using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI.Components
{
	public class UiRippleCreator : MonoBehaviour
	{
		[SerializeField]
		private GameObject rippleParent;

		[SerializeField]
		public Sprite rippleShape;

		[SerializeField]
		private float speed = 2.4f;

		[SerializeField]
		private float maxSize = 4f;

		[SerializeField]
		private Color startColor = new Color(1f, 1f, 1f, 0.4f);

		[SerializeField]
		private Color transitionColor = new Color(1f, 1f, 1f, 0f);

		[SerializeField]
		private bool shouldRenderOnTop;

		[SerializeField]
		private bool shouldSpawnCentered;

		internal void CreateRipple(Vector2 pos)
		{
			if (rippleParent != null)
			{
				GameObject gameObject = new GameObject();
				gameObject.AddComponent<Ripple>();
				gameObject.AddComponent<Image>();
				gameObject.GetComponent<Image>().sprite = rippleShape;
				gameObject.name = "Ripple";
				rippleParent.gameObject.SetActive(value: true);
				gameObject.transform.SetParent(rippleParent.transform);
				if (shouldRenderOnTop)
				{
					rippleParent.transform.SetAsLastSibling();
				}
				if (shouldSpawnCentered)
				{
					gameObject.transform.localPosition = new Vector2(0f, 0f);
				}
				else
				{
					gameObject.transform.position = pos;
				}
				gameObject.GetComponent<Ripple>().speed = speed;
				gameObject.GetComponent<Ripple>().maxSize = maxSize;
				gameObject.GetComponent<Ripple>().startColor = startColor;
				gameObject.GetComponent<Ripple>().transitionColor = transitionColor;
			}
		}
	}
}
