using System;
using System.Diagnostics.CodeAnalysis;
using Coherence.Log;

namespace Coherence.Common
{
	public abstract class CoherenceError<TId> : CoherenceError, IEquatable<CoherenceError<TId>> where TId : struct
	{
		private readonly TId type;

		public TId Type => default(TId);

		private protected CoherenceError(TId type, Error error = Error.UnobservedError, bool hasBeenObserved = false)
			: base(default(Error))
		{
		}

		private protected CoherenceError(TId type, string message, Error error = Error.UnobservedError, bool hasBeenObserved = false)
			: base(default(Error))
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static bool operator ==(CoherenceError<TId> left, TId right)
		{
			return false;
		}

		public static bool operator !=(CoherenceError<TId> left, TId right)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(CoherenceError<TId> other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(TId id)
		{
			return false;
		}
	}
	public abstract class CoherenceError
	{
		private readonly string message;

		private readonly Error error;

		private bool hasBeenObserved;

		protected DateTime timestamp;

		public string Message => null;

		private protected CoherenceError(Error error = Error.UnobservedError, bool hasBeenObserved = false)
		{
		}

		private protected CoherenceError(string message, Error error = Error.UnobservedError, bool hasBeenObserved = false)
		{
		}

		public void Ignore()
		{
		}

		[DoesNotReturn]
		public void Throw()
		{
		}

		public void Log()
		{
		}

		private void Log(string message)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator Exception(CoherenceError error)
		{
			return null;
		}

		private protected virtual Exception ToException()
		{
			return null;
		}

		private void OnObserved()
		{
		}

		~CoherenceError()
		{
		}
	}
}
