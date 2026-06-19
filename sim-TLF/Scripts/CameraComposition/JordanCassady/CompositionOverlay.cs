using UnityEngine;
using UnityEngine.UI;

namespace JordanCassady
{
	[RequireComponent(typeof(Image))]
	public class CompositionOverlay : MonoBehaviour
	{
		public bool IsActive => GetComponent<Image>().enabled;

		public float Opacity => GetComponent<Image>().color.a;

		public void Activate(bool activate)
		{
			GetComponent<Image>().enabled = activate;
		}

		public bool InvertLineColor(bool invert)
		{
			if (invert)
			{
				GetComponent<Image>().color = Color.black;
			}
			else
			{
				GetComponent<Image>().color = Color.white;
			}
			return invert;
		}

		public void UpdateOpacity(float alpha)
		{
			Image component = GetComponent<Image>();
			GetComponent<Image>().color = new Color(component.color.r, component.color.g, component.color.b, alpha);
		}

		public void Position(string orientation)
		{
			switch (orientation)
			{
			case "Bottom Right":
				GetComponent<Image>().transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				break;
			case "Bottom Left":
				GetComponent<Image>().transform.rotation = Quaternion.Euler(-180f, 0f, -180f);
				break;
			case "Top Right":
				GetComponent<Image>().transform.rotation = Quaternion.Euler(-180f, 0f, 0f);
				break;
			case "Top Left":
				GetComponent<Image>().transform.rotation = Quaternion.Euler(0f, 0f, -180f);
				break;
			}
		}
	}
}
