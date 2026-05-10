using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class SliderTransition : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[SerializeField]
		private Slider slider;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private bool hasText;

		[SerializeField]
		private Text text;

		private bool bDelayedUpdate;

		public bool HasText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void UpdateText()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void SliderValueChange(float value)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
