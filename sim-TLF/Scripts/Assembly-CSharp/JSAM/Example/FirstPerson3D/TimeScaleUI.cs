using UnityEngine;
using UnityEngine.UI;

namespace JSAM.Example.FirstPerson3D
{
	public class TimeScaleUI : MonoBehaviour
	{
		[SerializeField]
		private float timeIncrement = 0.25f;

		[SerializeField]
		private Slider uiSlider;

		[SerializeField]
		private Text uiText;

		private void Start()
		{
			UpdateUI();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				Time.timeScale = Mathf.Clamp(Time.timeScale + timeIncrement, 0f, 2f);
				UpdateUI();
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				Time.timeScale = Mathf.Clamp(Time.timeScale - timeIncrement, 0f, 2f);
				UpdateUI();
			}
		}

		private void UpdateUI()
		{
			uiSlider.value = Mathf.InverseLerp(0f, 2f, Time.timeScale);
			uiText.text = "TimeScale: " + Time.timeScale;
		}
	}
}
