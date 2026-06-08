using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class Ripple : MonoBehaviour
	{
		public float speed;

		public float maxSize;

		public Color startColor;

		public Color transitionColor;

		private void Start()
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
			GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, startColor.a);
		}

		private void Update()
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(maxSize, maxSize, maxSize), Time.deltaTime * speed);
			GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, new Color(transitionColor.r, transitionColor.g, transitionColor.b, transitionColor.a), Time.deltaTime * speed);
			if ((double)base.transform.localScale.x >= (double)maxSize * 0.998)
			{
				if (base.transform.parent.childCount == 1)
				{
					base.transform.parent.gameObject.SetActive(value: false);
				}
				Object.Destroy(base.gameObject);
			}
		}
	}
}
