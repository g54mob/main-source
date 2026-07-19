using UnityEngine;
using UnityEngine.UI;

public class ComponentRocker : MonoBehaviour
{
	private float step;

	private float index;

	private float minimumValue;

	private float initialValue;

	private float maximumValue;

	private string modifier;

	public Text value;

	private void Start()
	{
		ComponentBase component = GetComponent<ComponentBase>();
		step = (float)component.GetData("step", 1f);
		modifier = (string)component.GetData("modifier", "");
		minimumValue = (float)component.GetData("minimum", 0f);
		initialValue = (float)component.GetData("initial", 0f);
		maximumValue = (float)component.GetData("maximum", 100f);
		Reset();
	}

	public void Plus()
	{
		index += step;
		UpdateValue();
	}

	public void Minus()
	{
		index -= step;
		UpdateValue();
	}

	public void Reset()
	{
		index = initialValue;
		UpdateValue();
	}

	public void UpdateValue()
	{
		index = Mathf.Clamp(index, minimumValue, maximumValue);
		string text = index.ToString("F1");
		if (index == (float)Mathf.RoundToInt(index))
		{
			text = index.ToString("F0");
		}
		value.text = text + modifier;
		GetComponent<ComponentBase>().Callback(base.name + "Change", index, base.transform);
	}

	public void SetValue(float i)
	{
		index = i;
		UpdateValue();
	}
}
