using JSAM;
using UnityEngine;

namespace Vehicles.FunctionalObjects
{
	public class Starter : AbstractFunctionalObject
	{
		[SerializeField]
		private int _starterPower = 100;

		[SerializeField]
		private EngineComponent _engineComponent;

		[SerializeField]
		private float _startTime = 2f;

		[SerializeField]
		private EngineSocket _socket;

		private float _currentTime;

		private bool _canCount;

		public int StarterPower => _starterPower;

		private void OnEnable()
		{
			_socket.OnSystemsRefreshRequired += UpdateStatus;
		}

		private void OnDisable()
		{
			_socket.OnSystemsRefreshRequired -= UpdateStatus;
		}

		public void UpdateStatus()
		{
			if (_socket.CheckSystem(PartFunction.Starter))
			{
				TryEnable();
			}
			else
			{
				TryDisable();
			}
		}

		public void StarterOn()
		{
			if (base.Enabled)
			{
				AudioManager.PlaySound(PlaneLibrarySounds.StarterLoop);
				_currentTime = 0f;
				_canCount = true;
			}
		}

		public void StarterOff()
		{
			AudioManager.StopSoundIfPlaying(PlaneLibrarySounds.StarterLoop);
			_currentTime = 0f;
			_canCount = false;
		}

		public override void TryDisable()
		{
			base.TryDisable();
			StarterOff();
		}

		private void Update()
		{
			if (!_canCount)
			{
				return;
			}
			if (!base.Enabled)
			{
				_canCount = false;
				return;
			}
			_currentTime += Time.deltaTime;
			if (_currentTime >= _startTime)
			{
				_canCount = false;
				_engineComponent.StartEngine();
			}
		}
	}
}
