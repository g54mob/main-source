using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderScroll : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Slider MainSlider;

	private bool _activeSlide;

	private float _countDown;

	private void Update()
	{
		if (!_activeSlide)
		{
			return;
		}
		float num = (Input.GetKey(KeyCode.LeftArrow) ? (-1f) : (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f));
		float num2 = (Input.GetKeyDown(KeyCode.LeftArrow) ? (-1f) : (Input.GetKeyDown(KeyCode.RightArrow) ? 1f : 0f));
		if (num != 0f)
		{
			_countDown -= Time.deltaTime;
			if (_countDown <= 0f)
			{
				_countDown = 0.1f;
				num2 = num;
			}
		}
		else
		{
			_countDown = 1f;
		}
		if (num2 != 0f)
		{
			float num3 = MainSlider.maxValue - MainSlider.minValue;
			if (!MainSlider.wholeNumbers && num3 < 3f)
			{
				num2 = ((!(num3 < 1f)) ? (num2 * 0.01f) : (num2 * (num3 / 100f)));
			}
			MainSlider.value = Mathf.Clamp(MainSlider.value + num2, MainSlider.minValue, MainSlider.maxValue);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_countDown = 1f;
		_activeSlide = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_activeSlide = false;
	}
}
