using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using NSubstitute.Core.Arguments;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class Call : ICall, CallCollection.IReceivedCallEntry
	{
		private readonly MethodInfo _methodInfo;

		private readonly object?[] _arguments;

		private object?[] _originalArguments;

		private readonly object _target;

		private readonly IList<IArgumentSpecification> _argumentSpecifications;

		private IParameterInfo[]? _parameterInfosCached;

		private long? _sequenceNumber;

		private readonly Func<object>? _baseMethod;

		private int _callEntryState;

		public bool CanCallBase => _baseMethod != null;

		ICall CallCollection.IReceivedCallEntry.Call => this;

		bool CallCollection.IReceivedCallEntry.IsSkipped => _callEntryState == -1;

		[Obsolete("This constructor is deprecated and will be removed in future version of product.")]
		public Call(MethodInfo methodInfo, object?[] arguments, object target, IList<IArgumentSpecification> argumentSpecifications, IParameterInfo[] parameterInfos, Func<object> baseMethod)
			: this(methodInfo, arguments, target, argumentSpecifications, baseMethod)
		{
			_parameterInfosCached = parameterInfos ?? throw new ArgumentNullException("parameterInfos");
		}

		public Call(MethodInfo methodInfo, object?[] arguments, object target, IList<IArgumentSpecification> argumentSpecifications, Func<object>? baseMethod)
		{
			_methodInfo = methodInfo;
			_arguments = arguments;
			_target = target;
			_argumentSpecifications = argumentSpecifications;
			_baseMethod = baseMethod;
			_originalArguments = _arguments;
		}

		public IParameterInfo[] GetParameterInfos()
		{
			return _parameterInfosCached ?? (_parameterInfosCached = GetParameterInfoFromMethod(_methodInfo));
		}

		public IList<IArgumentSpecification> GetArgumentSpecifications()
		{
			return _argumentSpecifications;
		}

		public void AssignSequenceNumber(long number)
		{
			_sequenceNumber = number;
		}

		public long GetSequenceNumber()
		{
			return _sequenceNumber ?? throw new MissingSequenceNumberException();
		}

		public Maybe<object?> TryCallBase()
		{
			if (_baseMethod != null)
			{
				return Maybe.Just(_baseMethod());
			}
			return Maybe.Nothing<object>();
		}

		public Type GetReturnType()
		{
			return _methodInfo.ReturnType;
		}

		public MethodInfo GetMethodInfo()
		{
			return _methodInfo;
		}

		public object?[] GetArguments()
		{
			object[] originalArguments = _originalArguments;
			if (originalArguments == _arguments && originalArguments.Length != 0)
			{
				object[] value = originalArguments.ToArray();
				Interlocked.CompareExchange(ref _originalArguments, value, originalArguments);
			}
			return _arguments;
		}

		public object?[] GetOriginalArguments()
		{
			return _originalArguments;
		}

		public object Target()
		{
			return _target;
		}

		private static IParameterInfo[] GetParameterInfoFromMethod(MethodInfo methodInfo)
		{
			ParameterInfo[] parameters = methodInfo.GetParameters();
			IParameterInfo[] array = new IParameterInfo[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = new ParameterInfoWrapper(parameters[i]);
			}
			return array;
		}

		void CallCollection.IReceivedCallEntry.Skip()
		{
			_callEntryState = -1;
		}

		bool CallCollection.IReceivedCallEntry.TryTakeEntryOwnership()
		{
			return Interlocked.CompareExchange(ref _callEntryState, 1, 0) == 0;
		}
	}
}
