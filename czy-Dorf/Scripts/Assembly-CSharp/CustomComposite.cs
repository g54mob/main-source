using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

[DisplayStringFormat("{multiplier}*{stick}")]
public class CustomComposite : InputBindingComposite<Vector2>
{
	[InputControl(layout = "Axis")]
	public int multiplier;

	[InputControl(layout = "Vector2")]
	public int stick;

	public float scaleFactor = 1f;

	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		InputSystem.RegisterBindingComposite<CustomComposite>();
	}

	public override Vector2 ReadValue(ref InputBindingCompositeContext context)
	{
		Vector2 vector = context.ReadValue<Vector2, Vector2MagnitudeComparer>(stick);
		float num = context.ReadValue<float>(multiplier);
		return vector * (num * scaleFactor);
	}
}
