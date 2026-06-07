using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class KnobManagement : MonoBehaviour
{
	public Text KnobValue;

	public InputField SetKnobValue;

	public UI_Knob Knob;

	public void UpdateKnobValue()
	{
		Knob.SetKnobValue(float.Parse(SetKnobValue.text));
	}

	private void Update()
	{
		KnobValue.text = Knob.KnobValue.ToString();
	}
}
