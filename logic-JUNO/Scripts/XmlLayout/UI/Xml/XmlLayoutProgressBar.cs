using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	public class XmlLayoutProgressBar : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 100f)]
		private float m_percentage;

		public bool showPercentageText = true;

		public string percentageTextFormat = "0.00";

		[Header("References")]
		public Image ref_backgroundImage;

		public Image ref_fillImage;

		public Text ref_text;

		public float percentage
		{
			get
			{
				return m_percentage;
			}
			set
			{
				SetProperty(ref m_percentage, Mathf.Max(0f, Mathf.Min(100f, value)));
			}
		}

		private void SetDirty()
		{
			ref_text.gameObject.SetActive(showPercentageText);
			ref_text.text = string.Format("{0:" + percentageTextFormat + "}%", percentage);
			ref_fillImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ref_backgroundImage.rectTransform.rect.width * (percentage / 100f));
		}

		private void SetProperty<T>(ref T o, T value)
		{
			o = value;
			SetDirty();
		}

		private void OnRectTransformDimensionsChange()
		{
			SetDirty();
		}
	}
}
