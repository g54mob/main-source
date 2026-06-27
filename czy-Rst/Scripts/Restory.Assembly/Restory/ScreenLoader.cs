using Restory.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory
{
	public class ScreenLoader : MonoBehaviour, IInitializable, IFixedTickable
	{
		[SerializeField]
		private Slider progressBar;

		[SerializeField]
		private float progressBarSpeed = 10f;

		[SerializeField]
		[Range(0.5f, 1f)]
		private float progressBarClampSpeedFactor = 0.95f;

		private Coroutine updateProgressBarCoroutine;

		private GlobalStateMachine globalStateMachine;

		[Inject]
		private void Construct(GlobalStateMachine globalStateMachine)
		{
			this.globalStateMachine = globalStateMachine;
		}

		public void Initialize()
		{
			progressBar.value = 0f;
		}

		public void FixedTick()
		{
			float num = globalStateMachine.InitializationProgress - progressBar.value;
			if (num > 0f)
			{
				float num2 = Mathf.Clamp(num * progressBarSpeed, 0f, progressBarClampSpeedFactor);
				progressBar.value += num2 * Time.fixedDeltaTime;
			}
		}
	}
}
