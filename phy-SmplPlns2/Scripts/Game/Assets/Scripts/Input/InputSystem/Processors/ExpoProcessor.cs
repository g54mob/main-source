using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input.InputSystem.Processors
{
	public class ExpoProcessor : InputProcessor<float>
	{
		[Tooltip("Adds \"exponential\" to the value (values above 1 give more precision for smaller values).")]
		public float Expo = 1f;

		public override float Process(float value, InputControl control)
		{
			return Mathf.Sign(value) * Mathf.Pow(Mathf.Abs(value), Expo);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			UnityEngine.InputSystem.InputSystem.RegisterProcessor<ExpoProcessor>();
		}
	}
}
