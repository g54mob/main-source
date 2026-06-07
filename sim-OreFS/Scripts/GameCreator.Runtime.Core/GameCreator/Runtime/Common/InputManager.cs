using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class InputManager : Singleton<InputManager>
	{
		protected override bool SurviveSceneLoads => true;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void OnSubsystemsInit()
		{
			Singleton<InputManager>.Instance.WakeUp();
		}

		protected override void OnCreate()
		{
			base.OnCreate();
		}

		public void RequireEnhancedTouchInput()
		{
			if (!EnhancedTouchSupport.enabled)
			{
				EnhancedTouchSupport.Enable();
			}
		}
	}
}
