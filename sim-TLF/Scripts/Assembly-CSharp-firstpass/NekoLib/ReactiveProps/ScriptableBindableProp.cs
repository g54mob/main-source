using System;

namespace NekoLib.ReactiveProps
{
	public class ScriptableBindableProp<T> : ScriptableProp<T>, IBindableProp<T>, IReadOnlyProp<T> where T : struct
	{
		public override T Value
		{
			set
			{
				if (!_value.Equals(value))
				{
					_value = value;
					OnValueChange();
				}
			}
		}

		public event Action<T> ValueChanged;

		protected virtual void OnValueChange()
		{
			this.ValueChanged?.Invoke(Value);
		}

		private void OnValidate()
		{
			Value = _value;
			OnValueChange();
		}
	}
}
