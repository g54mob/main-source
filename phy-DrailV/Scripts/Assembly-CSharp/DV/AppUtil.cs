using System;
using System.Collections;
using DV.DopplerEffects;
using DV.UI;
using DV.Utils;
using Unity.Entities;
using UnityEngine;
using VRTK;

namespace DV
{
	public class AppUtil : SingletonBehaviour<AppUtil>
	{
		public float unpausedTimeScale = 1f;

		public float pauseDelay = 0.08f;

		private Coroutine pauseCoro;

		private Vector3 originalGravity = Physics.gravity;

		private RequestSystem requestSystem = new RequestSystem();

		private Entity dopplerDisableUpdateEntity;

		public bool IsPauseMenuOpen
		{
			get
			{
				if ((bool)SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
				{
					return SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.PauseMenu);
				}
				return false;
			}
		}

		public bool IsTimePaused { get; private set; }

		public bool IsTimePausedSafer
		{
			get
			{
				if (!IsTimePaused && TimeUtil.IsFlowing)
				{
					return SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess;
				}
				return true;
			}
		}

		public event Action GamePauseRequested;

		public event Action GamePaused;

		public event Action EndOfFrameGamePaused;

		public event Action GameUnpaused;

		public event Action AfterGameUnpaused;

		public event Action<bool> FocusChanged;

		protected override void Awake()
		{
			base.Awake();
			requestSystem.ValueChanged += RequestSystemOnValueChanged;
		}

		private void OnApplicationFocus(bool focus)
		{
			this.FocusChanged?.Invoke(focus);
		}

		private void RequestSystemOnValueChanged(float value)
		{
			bool flag = value > 0.5f;
			if (pauseCoro == null && IsTimePaused != flag)
			{
				IsTimePaused = flag;
				SetDopplerEnabled(!IsTimePaused);
				if (flag)
				{
					AudioListener.pause = true;
					pauseCoro = StartCoroutine(PauseTimeCoro());
					return;
				}
				AudioListener.pause = false;
				this.GameUnpaused?.Invoke();
				Time.timeScale = unpausedTimeScale;
				Physics.gravity = originalGravity;
				this.AfterGameUnpaused?.Invoke();
			}
		}

		private void SetDopplerEnabled(bool on)
		{
			EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
			if (on)
			{
				if (entityManager.Exists(dopplerDisableUpdateEntity))
				{
					entityManager.DestroyEntity(dopplerDisableUpdateEntity);
					dopplerDisableUpdateEntity = default(Entity);
				}
			}
			else
			{
				dopplerDisableUpdateEntity = entityManager.CreateEntity();
				entityManager.AddComponent<Doppler.DopplerPauseUpdate>(dopplerDisableUpdateEntity);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
			}
			if (!UnloadWatcher.isQuitting)
			{
				SetDopplerEnabled(on: true);
				Physics.gravity = originalGravity;
				Time.timeScale = 1f;
				requestSystem.ValueChanged -= RequestSystemOnValueChanged;
				AudioListener.pause = false;
			}
		}

		public new static string AllowAutoCreate()
		{
			return "[AppUtil]";
		}

		public void PauseGame()
		{
			if ((bool)SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: true);
			}
		}

		public void UnpauseGame()
		{
			if ((bool)SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: false);
			}
		}

		private IEnumerator PauseTimeCoro()
		{
			this.GamePauseRequested?.Invoke();
			yield return WaitFor.SecondsRealtime(pauseDelay);
			this.GamePaused?.Invoke();
			yield return WaitFor.FixedUpdate;
			yield return WaitFor.EndOfFrame;
			this.EndOfFrameGamePaused?.Invoke();
			unpausedTimeScale = Time.timeScale;
			Time.timeScale = 0f;
			VRTK_SDK_Bridge.HeadsetFade(Color.clear, 0f);
			Physics.gravity = Vector3.zero;
			pauseCoro = null;
			RequestSystemOnValueChanged(requestSystem.Value);
		}

		public void RequestPause(object caller, bool paused, int priority = 0)
		{
			requestSystem.RequestValue(caller, paused ? 1 : 0, priority);
		}

		public void RemovePauseRequest(object caller)
		{
			requestSystem.RemoveValue(caller);
		}
	}
}
