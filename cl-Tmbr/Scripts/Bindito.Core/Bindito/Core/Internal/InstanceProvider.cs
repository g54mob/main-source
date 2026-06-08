using System;

namespace Bindito.Core.Internal
{
	public class InstanceProvider
	{
		private readonly Func<object> _func;

		public bool Exported { get; }

		public InstanceProvider(Func<object> func, bool exported)
		{
			_func = func;
			Exported = exported;
		}

		public object GetInstance()
		{
			return _func();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((InstanceProvider)obj);
		}

		public override int GetHashCode()
		{
			return (((_func != null) ? _func.GetHashCode() : 0) * 397) ^ Exported.GetHashCode();
		}

		private bool Equals(InstanceProvider other)
		{
			if (object.Equals(_func, other._func))
			{
				return Exported == other.Exported;
			}
			return false;
		}
	}
}
