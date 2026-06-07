using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	public class DivideScreenSizeProcessor : InputProcessor<Vector2>
	{
		public override Vector2 Process(Vector2 value, InputControl control)
		{
			return Vector2.Scale(value, new Vector2(1f / (float)Screen.height, 1f / (float)Screen.height));
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			InputSystem.RegisterProcessor<DivideScreenSizeProcessor>();
		}
	}
}
