using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	public class MultiplyScreenSizeProcessor : InputProcessor<Vector2>
	{
		public override Vector2 Process(Vector2 value, InputControl control)
		{
			return Vector2.Scale(value, new Vector2(Screen.height, Screen.height));
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			InputSystem.RegisterProcessor<MultiplyScreenSizeProcessor>();
		}
	}
}
