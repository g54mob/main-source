using UnityEngine;

namespace NekoLib.ReactiveProps
{
	public abstract class ScriptableProp<T> : ScriptableObject, IReadOnlyProp<T>
	{
		[SerializeField]
		protected T _value;

		public virtual T Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}
	}
}
