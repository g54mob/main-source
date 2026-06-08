using UnityEngine;
using UnityEngine.InputSystem;

namespace Dorfromantik
{
	public class DynamicScale : InputProcessor<Vector2>
	{
		public float minMultiplier;

		public float maxMultiplier;

		public override Vector2 Process(Vector2 value, InputControl control)
		{
			return Vector2.Scale(b: new Vector2(Mathf.Lerp(minMultiplier, maxMultiplier, Mathf.Abs(value.x)), Mathf.Lerp(minMultiplier, maxMultiplier, Mathf.Abs(value.y))), a: value);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			InputSystem.RegisterProcessor<DynamicScale>();
		}
	}
}
