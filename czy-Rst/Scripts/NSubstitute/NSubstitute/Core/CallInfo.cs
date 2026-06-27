using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class CallInfo
	{
		public object this[int index]
		{
			get
			{
				return _003CcallArguments_003EP[index].Value;
			}
			set
			{
				Argument argument = _003CcallArguments_003EP[index];
				EnsureArgIsSettable(argument, index, value);
				argument.Value = value;
			}
		}

		public CallInfo(Argument[] callArguments)
		{
			_003CcallArguments_003EP = callArguments;
			base._002Ector();
		}

		private void EnsureArgIsSettable(Argument argument, int index, object value)
		{
			if (!argument.IsByRef)
			{
				throw new ArgumentIsNotOutOrRefException(index, argument.DeclaredType);
			}
			if (value != null && !argument.CanSetValueWithInstanceOf(value.GetType()))
			{
				throw new ArgumentSetWithIncompatibleValueException(index, argument.DeclaredType, value.GetType());
			}
		}

		public object[] Args()
		{
			return _003CcallArguments_003EP.Select((Argument x) => x.Value).ToArray();
		}

		public Type[] ArgTypes()
		{
			return _003CcallArguments_003EP.Select((Argument x) => x.DeclaredType).ToArray();
		}

		public T Arg<T>()
		{
			if (TryGetArg<T>((Argument x) => x.IsDeclaredTypeEqualToOrByRefVersionOf(typeof(T)), out var value))
			{
				return value;
			}
			if (TryGetArg<T>((Argument x) => x.IsValueAssignableTo(typeof(T)), out value))
			{
				return value;
			}
			throw new ArgumentNotFoundException("Can not find an argument of type " + typeof(T).FullName + " to this call.");
		}

		private bool TryGetArg<T>(Func<Argument, bool> condition, [MaybeNullWhen(false)] out T value)
		{
			value = default(T);
			IEnumerable<Argument> enumerable = _003CcallArguments_003EP.Where(condition);
			if (!enumerable.Any())
			{
				return false;
			}
			ThrowIfMoreThanOne<T>(enumerable);
			value = (T)enumerable.First().Value;
			return true;
		}

		private void ThrowIfMoreThanOne<T>(IEnumerable<Argument> arguments)
		{
			if (arguments.Skip(1).Any())
			{
				throw new AmbiguousArgumentsException("There is more than one argument of type " + typeof(T).FullName + " to this call.\nThe call signature is (" + DisplayTypes(ArgTypes()) + ")\n  and was called with (" + DisplayTypes(_003CcallArguments_003EP.Select((Argument x) => x.ActualType)) + ")");
			}
		}

		public T ArgAt<T>(int position)
		{
			if (position >= _003CcallArguments_003EP.Length)
			{
				throw new ArgumentOutOfRangeException("position", $"There is no argument at position {position}");
			}
			try
			{
				return (T)_003CcallArguments_003EP[position].Value;
			}
			catch (InvalidCastException)
			{
				throw new InvalidCastException($"Couldn't convert parameter at position {position} to type {typeof(T).FullName}");
			}
		}

		private static string DisplayTypes(IEnumerable<Type> types)
		{
			return string.Join(", ", types.Select((Type x) => x.Name).ToArray());
		}
	}
}
