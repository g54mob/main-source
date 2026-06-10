using UnityEngine;

public class LockpickProgressController : MonoBehaviour
{
	public float amount;

	public float barMax;

	public float progress;

	public RectTransform rect;

	public RectTransform bar;

	public JuiceController juice;

	public Color depletedColor;

	private bool completed;

	public void SetBarMax(float val)
	{
	}

	public void SetAmount(float val)
	{
	}

	public void UpdateBar()
	{
	}
}
