using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NSubstitute.Core.SequenceChecking
{
	public class InstanceTracker
	{
		private class ReferenceEqualityComparer : IEqualityComparer<object>
		{
			public new bool Equals(object? x, object? y)
			{
				return x == y;
			}

			public int GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}
		}

		private readonly Dictionary<object, int> _instances = new Dictionary<object, int>(new ReferenceEqualityComparer());

		private int _counter;

		public int InstanceNumber(object o)
		{
			if (_instances.TryGetValue(o, out var value))
			{
				return value;
			}
			int num = ++_counter;
			_instances.Add(o, num);
			return num;
		}

		public int NumberOfInstances()
		{
			return _counter;
		}
	}
}
