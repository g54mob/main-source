using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	public class MultiplyDeltaTimeProcessor : InputProcessor<Vector2>
	{
		public override Vector2 Process(Vector2 value, InputControl control)
		{
			return value * Time.unscaledDeltaTime;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			InputSystem.RegisterProcessor<MultiplyDeltaTimeProcessor>();
		}
	}
}
