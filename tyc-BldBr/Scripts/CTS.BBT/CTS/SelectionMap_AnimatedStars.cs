using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class SelectionMap_AnimatedStars : MonoBehaviour
	{
		private float _valueToFill;

		[field: SerializeField]
		public Animator Animator { get; private set; }

		[field: SerializeField]
		public Image FillImage { get; private set; }

		public void Value(float value)
		{
			_valueToFill = value;
		}

		public void EmptyTheImage()
		{
			FillImage.fillAmount = 0f;
		}

		public void FillTheSlide()
		{
			FillImage.fillAmount = _valueToFill;
		}
	}
}
