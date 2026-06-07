using UnityEngine;

public class SliderBG : MonoBehaviour
{
	public Slider slider;

	private void OnMouseDrag()
	{
		Vector3 mousePos = Slider.GetMousePos();
		float maxSlide = slider.maxSlide;
		float num = mousePos.x - base.transform.position.x;
		if (slider.vertical)
		{
			num = mousePos.y - base.transform.position.y;
		}
		float value = (num + maxSlide) / (2f * maxSlide);
		value = Mathf.Clamp01(value);
		slider.transform.localPosition = new Vector3(0f - maxSlide + value * 2f * maxSlide, 0f);
		slider.Set();
	}

	private void OnMouseEnter()
	{
		slider.owner.dungeon.hoveredModule = slider.owner;
		slider.owner.dungeon.tooltip.Set(slider.owner);
	}

	private void OnMouseExit()
	{
		slider.owner.dungeon.hoveredModule = null;
		slider.owner.dungeon.tooltip.Hide();
	}

	private void OnMouseOver()
	{
		if (Input.mouseScrollDelta.y > 0f || Module.GetInputUp() || Module.GetInputRight())
		{
			slider.ScrollUp();
		}
		if (Input.mouseScrollDelta.y < 0f || Module.GetInputDown() || Module.GetInputLeft())
		{
			slider.ScrollDown();
		}
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			slider.ResetSlider();
		}
	}
}
