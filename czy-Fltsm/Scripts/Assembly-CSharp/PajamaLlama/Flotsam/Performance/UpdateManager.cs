using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.Performance
{
	public class UpdateManager : MonoBehaviour
	{
		private List<IUpdateManagerFixedUpdateTarget> _fixedUpdateTargets;

		private int _fixedUpdateTargetCount;

		private List<IUpdateManagerUpdateTarget> _updateTargets;

		private int _updateTargetCount;

		private List<IUpdateManagerLateUpdateTarget> _lateUpdateTargets;

		private int _lateUpdateTargetCount;

		public void Initialize()
		{
			_fixedUpdateTargets = new List<IUpdateManagerFixedUpdateTarget>(1000);
			_updateTargets = new List<IUpdateManagerUpdateTarget>(1000);
			_lateUpdateTargets = new List<IUpdateManagerLateUpdateTarget>(1000);
		}

		private void FixedUpdate()
		{
			for (int i = 0; i < _fixedUpdateTargetCount; i++)
			{
				_fixedUpdateTargets[i].UpdateManager_FixedUpdate();
			}
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			int frameCount = Time.frameCount;
			for (int i = 0; i < _updateTargetCount; i++)
			{
				_updateTargets[i].UpdateManager_Update(deltaTime, frameCount);
			}
		}

		private void LateUpdate()
		{
			for (int i = 0; i < _lateUpdateTargetCount; i++)
			{
				_lateUpdateTargets[i].UpdateManager_LateUpdate();
			}
		}

		public void RegisterFixedUpdateTarget(IUpdateManagerFixedUpdateTarget target)
		{
			_fixedUpdateTargets.Add(target);
			_fixedUpdateTargetCount++;
		}

		public void UnregisterFixedUpdateTarget(IUpdateManagerFixedUpdateTarget target)
		{
			if (_fixedUpdateTargets.Remove(target))
			{
				_fixedUpdateTargetCount--;
			}
		}

		public void RegisterUpdateTarget(IUpdateManagerUpdateTarget target)
		{
			_updateTargets.Add(target);
			_updateTargetCount++;
		}

		public void UnregisterUpdateTarget(IUpdateManagerUpdateTarget target)
		{
			if (_updateTargets.Remove(target))
			{
				_updateTargetCount--;
			}
		}

		public void RegisterLateUpdateTarget(IUpdateManagerLateUpdateTarget target)
		{
			_lateUpdateTargets.Add(target);
			_lateUpdateTargetCount++;
		}

		public void UnregisterLateUpdateTarget(IUpdateManagerLateUpdateTarget target)
		{
			if (_lateUpdateTargets.Remove(target))
			{
				_lateUpdateTargetCount--;
			}
		}
	}
}
