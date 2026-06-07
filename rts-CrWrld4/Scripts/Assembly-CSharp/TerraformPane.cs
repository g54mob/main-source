using UnityEngine;
using UnityEngine.UI;

public class TerraformPane : MonoBehaviour
{
	public Slider brushSizeSlider;

	public Slider terrainHeightSlider;

	public Text terrainHeightVal;

	public Toggle floodToggle;

	public Toggle onlyContaminantToggle;

	public Toggle terpVoidToggle;

	public void OnContaminantChange(bool val)
	{
	}

	public void OnEnable()
	{
	}

	private void RefreshDeconToggle()
	{
	}

	public void LateUpdate()
	{
	}
}
