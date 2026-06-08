using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Core.SequenceChecking
{
	public class SequenceFormatter
	{
		private class CallData
		{
			private readonly int _instanceNumber;

			private readonly ICall? _call;

			private readonly CallSpecAndTarget? _specAndTarget;

			private MethodInfo MethodInfo
			{
				get
				{
					if (_call == null)
					{
						return _specAndTarget.CallSpecification.GetMethodInfo();
					}
					return _call.GetMethodInfo();
				}
			}

			public object Target
			{
				get
				{
					if (_call == null)
					{
						return _specAndTarget.Target;
					}
					return _call.Target();
				}
			}

			public Type DeclaringType => MethodInfo.DeclaringType;

			public CallData(int instanceNumber, CallSpecAndTarget specAndTarget)
			{
				_instanceNumber = instanceNumber;
				_specAndTarget = specAndTarget;
			}

			public CallData(int instanceNumber, ICall call)
			{
				_instanceNumber = instanceNumber;
				_call = call;
			}

			public string Format(bool multipleInstances, bool includeInstanceNumber)
			{
				string text = ((_call != null) ? Format(_call) : Format(_specAndTarget));
				if (!multipleInstances)
				{
					return text;
				}
				object obj;
				if (!includeInstanceNumber)
				{
					obj = "";
				}
				else
				{
					int instanceNumber = _instanceNumber;
					obj = instanceNumber + "@";
				}
				string arg = (string)obj;
				string nonMangledTypeName = MethodInfo.DeclaringType.GetNonMangledTypeName();
				return string.Format("{1}{0}.{2}", nonMangledTypeName, arg, text);
			}

			private string Format(CallSpecAndTarget x)
			{
				return x.CallSpecification.ToString() ?? string.Empty;
			}

			private string Format(ICall call)
			{
				MethodInfo methodInfo = call.GetMethodInfo();
				ArgAndParamInfo[] arguments = methodInfo.GetParameters().Zip(call.GetOriginalArguments(), (ParameterInfo p, object a) => new ArgAndParamInfo(p, a)).ToArray();
				return CallFormatter.Default.Format(methodInfo, FormatArgs(arguments));
			}

			private IEnumerable<string> FormatArgs(ArgAndParamInfo[] arguments)
			{
				return (from x in arguments.SelectMany((ArgAndParamInfo a) => (!a.ParamInfo.IsParams()) ? ToEnumerable(a.Argument) : ((IEnumerable)a.Argument).Cast<object>())
					select ArgumentFormatter.Default.Format(x, highlight: false)).ToArray();
			}

			private IEnumerable<T> ToEnumerable<T>(T value)
			{
				yield return value;
			}
		}

		private class ArgAndParamInfo
		{
			public ParameterInfo ParamInfo { get; }

			public object? Argument { get; }

			public ArgAndParamInfo(ParameterInfo paramInfo, object? argument)
			{
				ParamInfo = paramInfo;
				Argument = argument;
			}
		}

		private readonly string _delimiter;

		private readonly CallData[] _query;

		private readonly CallData[] _actualCalls;

		private readonly bool _requiresInstanceNumbers;

		private readonly bool _hasMultipleInstances;

		public SequenceFormatter(string delimiter, CallSpecAndTarget[] querySpec, ICall[] matchingCallsInOrder)
		{
			_delimiter = delimiter;
			InstanceTracker instances = new InstanceTracker();
			_query = querySpec.Select((CallSpecAndTarget x) => new CallData(instances.InstanceNumber(x.Target), x)).ToArray();
			_actualCalls = matchingCallsInOrder.Select((ICall x) => new CallData(instances.InstanceNumber(x.Target()), x)).ToArray();
			_hasMultipleInstances = instances.NumberOfInstances() > 1;
			_requiresInstanceNumbers = HasMultipleCallsOnSameType();
		}

		public string FormatQuery()
		{
			return Format(_query);
		}

		public string FormatActualCalls()
		{
			return Format(_actualCalls);
		}

		private string Format(CallData[] calls)
		{
			return calls.Select((CallData x) => x.Format(_hasMultipleInstances, _requiresInstanceNumbers)).Join(_delimiter);
		}

		private bool HasMultipleCallsOnSameType()
		{
			Dictionary<Type, object> dictionary = new Dictionary<Type, object>();
			CallData[] query = _query;
			foreach (CallData callData in query)
			{
				if (dictionary.TryGetValue(callData.DeclaringType, out var value))
				{
					if (callData.Target != value)
					{
						return true;
					}
				}
				else
				{
					dictionary.Add(callData.DeclaringType, callData.Target);
				}
			}
			return false;
		}
	}
}
