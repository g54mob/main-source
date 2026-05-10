using System.Collections;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public abstract class Cutscene : MonoRoutine
	{
		private LockToggle _selectionToggler;

		private Transform _cameraTarget;

		private void Start()
		{
			_selectionToggler = new LockToggle(CTSSingleton<WorldSelector>.Instance);
		}

		protected abstract bool CutsceneElementsAreReady();

		protected sealed override IEnumerator Routine()
		{
			if (CutsceneElementsAreReady())
			{
				UICinematic.Toggle(value: true);
				MonoSingleton<MainCamera>.Instance.CVarLockType.SetCurrentValue(CameraFollowing.LockType.Tutorial);
				_selectionToggler.Lock();
				WorldSelector.DeselectAll();
				yield return CutsceneRoutine();
				_selectionToggler.Unlock();
				MonoSingleton<MainCamera>.Instance.CVarLockType.SetCurrentValue(CameraFollowing.LockType.Soft);
				MonoSingleton<CameraFollowing>.Instance.Lock(null);
				UICinematic.Toggle(value: false);
			}
		}

		protected abstract IEnumerator CutsceneRoutine();

		protected void LockCamera(Vector3 pos)
		{
			if (!_cameraTarget)
			{
				_cameraTarget = new GameObject("CameraTarget").transform;
				_cameraTarget.SetParent(base.transform);
			}
			_cameraTarget.position = pos;
			MonoSingleton<CameraFollowing>.Instance.Lock(_cameraTarget);
		}

		protected void LockCamera(Transform parent)
		{
			MonoSingleton<CameraFollowing>.Instance.Lock(parent);
		}

		private void OnDisable()
		{
			Stop();
		}

		protected sealed override void OnStop()
		{
			if (MonoSingleton<MainCamera>.InstanceExists())
			{
				MonoSingleton<MainCamera>.Instance.CVarLockType.SetCurrentValue(CameraFollowing.LockType.Soft);
			}
			if (MonoSingleton<CameraFollowing>.InstanceExists())
			{
				MonoSingleton<CameraFollowing>.Instance.Lock(null);
			}
			_selectionToggler.Unlock();
			UICinematic.Toggle(value: false);
		}

		protected virtual void OnCutsceneCancel()
		{
		}
	}
}
