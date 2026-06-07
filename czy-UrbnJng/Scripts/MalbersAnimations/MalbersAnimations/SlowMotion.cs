using System.Collections;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Managers/Slow Motion")]
	public class SlowMotion : MonoBehaviour
	{
		[Space]
		[Range(0.05f, 1f)]
		[SerializeField]
		private float slowMoTimeScale = 0.25f;

		[Range(0.1f, 2f)]
		[SerializeField]
		private float slowMoSpeed = 0.2f;

		private bool PauseGame;

		private float CurrentTime = 1f;

		private IEnumerator SlowTime_C;

		private float currentFixedTimeScale;

		private void Awake()
		{
			currentFixedTimeScale = Time.fixedDeltaTime;
		}

		public void Slow_Motion()
		{
			if (SlowTime_C == null && base.enabled)
			{
				if (Time.timeScale == 1f)
				{
					SlowTime_C = SlowTime();
					StartCoroutine(SlowTime_C);
				}
				else
				{
					SlowTime_C = RestartTime();
					StartCoroutine(SlowTime_C);
				}
			}
		}

		public void Slow_Motion(bool value)
		{
			if (value)
			{
				Slow_MotionOn();
			}
			else
			{
				Slow_MotionOFF();
			}
		}

		public void Slow_MotionOn()
		{
			SlowTime_C = SlowTime();
			StartCoroutine(SlowTime_C);
		}

		public void Slow_MotionOFF()
		{
			SlowTime_C = RestartTime();
			StartCoroutine(SlowTime_C);
		}

		public virtual void Freeze_Game()
		{
			PauseGame = !PauseGame;
			CurrentTime = ((Time.timeScale != 0f) ? Time.timeScale : CurrentTime);
			Time.timeScale = (PauseGame ? 0f : CurrentTime);
		}

		public void PauseEditor()
		{
			Debug.Break();
		}

		private IEnumerator SlowTime()
		{
			while (Time.timeScale > slowMoTimeScale)
			{
				Time.timeScale -= Time.timeScale * slowMoSpeed;
				Time.fixedDeltaTime = currentFixedTimeScale * Time.timeScale;
				yield return null;
			}
			Time.timeScale = slowMoTimeScale;
			Time.fixedDeltaTime = currentFixedTimeScale * Time.timeScale;
			SlowTime_C = null;
		}

		private IEnumerator RestartTime()
		{
			while (Time.timeScale < 1f)
			{
				Time.timeScale += Time.timeScale * slowMoSpeed;
				Time.fixedDeltaTime = currentFixedTimeScale * Time.timeScale;
				yield return null;
			}
			Time.timeScale = (CurrentTime = 1f);
			Time.fixedDeltaTime = currentFixedTimeScale;
			SlowTime_C = null;
		}

		private void Reset()
		{
			CreateInputs();
		}

		[ContextMenu("Create Inputs")]
		protected void CreateInputs()
		{
		}
	}
}
