using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

namespace Gh.Tk
{
	[DisplayStringFormat("{Button}+{Button}+{Vector2}")]
	public class Vector2WithTwoModifiers : InputBindingComposite<Vector2>
	{
		[InputControl(layout = "Button")]
		public int button1;

		[InputControl(layout = "Button")]
		public int button2;

		[InputControl(layout = "Vector2")]
		public int vector2;

		public override Vector2 ReadValue(ref InputBindingCompositeContext context)
		{
			return default(Vector2);
		}

		public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
		{
			return 0f;
		}

		static Vector2WithTwoModifiers()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
		}
	}
}
