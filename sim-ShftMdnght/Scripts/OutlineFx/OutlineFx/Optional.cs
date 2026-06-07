using System;
using UnityEngine;

namespace OutlineFx
{
	[Serializable]
	public sealed class Optional<T>
	{
		[SerializeField]
		internal bool enabled;

		[SerializeField]
		internal T value;

		public bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				enabled = value;
			}
		}

		public T Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}

		public Optional(bool enabled)
		{
			this.enabled = enabled;
		}

		public Optional(T value, bool enabled)
		{
			this.enabled = enabled;
			this.value = value;
		}

		public T GetValue(T disabledValue)
		{
			if (!enabled)
			{
				return disabledValue;
			}
			return value;
		}

		public T GetValueOrDefault()
		{
			if (!enabled)
			{
				return default(T);
			}
			return value;
		}

		public static implicit operator bool(Optional<T> opt)
		{
			return opt.enabled;
		}

		public static implicit operator T(Optional<T> opt)
		{
			return opt.value;
		}
	}
}
