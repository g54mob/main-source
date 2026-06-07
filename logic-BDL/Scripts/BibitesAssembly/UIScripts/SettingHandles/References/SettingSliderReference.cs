using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.SettingHandles.References
{
	public class SettingSliderReference : MonoBehaviour
	{
		[SerializeField]
		public Slider slider;

		[SerializeField]
		public Button resetButton;

		[SerializeField]
		public Button editButton;

		[SerializeField]
		public TMP_InputField editField;

		[SerializeField]
		public FloatValueTextHandle sliderValue;

		[SerializeField]
		public TextMeshProUGUI settingName;

		[SerializeField]
		public GameObject defaultPointer;

		[SerializeField]
		public GameObject normalSection;

		[SerializeField]
		public GameObject editSection;

		public SliderDragHandler sliderDragHandler;

		public UnityEvent OnSizeChange = new UnityEvent();

		private void OnRectTransformDimensionsChange()
		{
			OnSizeChange.Invoke();
		}
	}
}
