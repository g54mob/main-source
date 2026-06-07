namespace Assets.Scripts.Craft
{
	public class AircraftVariable
	{
		public bool _used = true;

		private bool _hasUpdatedThisFrame;

		private bool _isInWritablePhase;

		private int _lastUpdatePriority;

		private int _queuedPriority;

		private float? _queuedValue;

		public string Name { get; private set; }

		public float Value { get; private set; }

		public AircraftVariable(string name)
		{
			Name = name;
		}

		public void EndWritablePhase()
		{
			_isInWritablePhase = false;
		}

		public void SetValue(float value, int priority)
		{
			if (!_isInWritablePhase)
			{
				if (!_queuedValue.HasValue || priority >= _queuedPriority)
				{
					_queuedValue = value;
					_queuedPriority = priority;
				}
			}
			else if (!_hasUpdatedThisFrame || priority >= _lastUpdatePriority)
			{
				_hasUpdatedThisFrame = true;
				_lastUpdatePriority = priority;
				Value = value;
			}
		}

		public void StartFrame()
		{
			_hasUpdatedThisFrame = false;
			_isInWritablePhase = true;
			if (_queuedValue.HasValue)
			{
				SetValue(_queuedValue.Value, _queuedPriority);
			}
			_queuedValue = null;
			_queuedPriority = 0;
		}
	}
}
