using UnityEngine;

namespace TH20
{
	public struct AnimalMagnetismCureAnim
	{
		public struct Config
		{
			public float FlyDuration;

			public float FallDuration;

			public float FlyDistance;

			public float FallDistance;

			public float FlyRotateSpeed;

			public float FallRotateSpeed;
		}

		public enum State
		{
			Null = 0,
			Fly = 1,
			Fall = 2,
			End = 3
		}

		private Config _config;

		private State _currentState;

		private float _currentTime;

		private Vector3 _initialFlyPosition;

		private Vector3 _initialFallPosition;

		private Transform _animal;

		private Transform _machine;

		public State CurrentState => _currentState;

		public AnimalMagnetismCureAnim(Transform animal, Transform machine, Config config)
		{
			_currentState = State.Fly;
			_currentTime = 0f;
			_animal = animal;
			_machine = machine;
			_config = config;
			_initialFallPosition = Vector3.zero;
			_initialFlyPosition = animal.position;
		}

		public void Update()
		{
			switch (_currentState)
			{
			case State.Fly:
				_currentTime += Time.deltaTime;
				_animal.transform.position = Vector3.Lerp(_initialFlyPosition, _initialFlyPosition - _machine.forward * _config.FlyDistance, _currentTime / _config.FlyDuration);
				_animal.transform.rotation = Quaternion.AngleAxis(_config.FlyRotateSpeed * Time.deltaTime, _machine.right) * _animal.transform.rotation;
				if (_currentTime > _config.FlyDuration)
				{
					_initialFallPosition = _animal.position;
					_currentTime = 0f;
					_currentState = State.Fall;
				}
				break;
			case State.Fall:
			{
				_currentTime += Time.deltaTime;
				float num = EasingsUtils.QuadraticEaseIn(_currentTime / _config.FallDuration);
				_animal.transform.position = Vector3.Lerp(_initialFallPosition, _initialFallPosition - _machine.up * _config.FallDistance, num);
				_animal.transform.rotation = Quaternion.AngleAxis(_config.FallRotateSpeed * Time.deltaTime * num, _machine.right) * _animal.transform.rotation;
				if (_currentTime > _config.FallDuration)
				{
					_currentTime = 0f;
					_currentState = State.End;
				}
				break;
			}
			}
		}
	}
}
