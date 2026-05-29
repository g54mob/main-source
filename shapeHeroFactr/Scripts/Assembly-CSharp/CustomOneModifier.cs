using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

[DisplayName("Custom One Modifier")]
[DisplayStringFormat("{firstPart}+{secondPart}")]
public class CustomOneModifier : InputBindingComposite<float>
{
	[InputControl(layout = "Button")]
	public int firstPart;

	[InputControl(layout = "Button")]
	public int secondPart;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Initialize()
	{
	}

	public override float ReadValue(ref InputBindingCompositeContext context)
	{
		return 0f;
	}

	public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
	{
		return 0f;
	}
}
