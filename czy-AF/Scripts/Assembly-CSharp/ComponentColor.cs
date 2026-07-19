using UnityEngine;

public class ComponentColor : MonoBehaviour
{
	public Colorpicker colorpicker;

	public void ValueChange(Color color)
	{
		GetComponent<ComponentBase>().Callback(base.name + "Update", color, base.transform);
	}

	public void ValueSet(Color color)
	{
		GetComponent<ComponentBase>().Callback(base.name + "Set", color, base.transform);
	}

	public void SetValue(Color color)
	{
		colorpicker.SetColor(color);
	}
}
