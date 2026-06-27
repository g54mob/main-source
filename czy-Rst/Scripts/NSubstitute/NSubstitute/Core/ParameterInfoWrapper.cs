using System;
using System.Reflection;

namespace NSubstitute.Core
{
	internal class ParameterInfoWrapper : IParameterInfo
	{
		public Type ParameterType => _003CparameterInfo_003EP.ParameterType;

		public bool IsParams => _003CparameterInfo_003EP.IsParams();

		public bool IsOptional => _003CparameterInfo_003EP.IsOptional;

		public bool IsOut => _003CparameterInfo_003EP.IsOut;

		public ParameterInfoWrapper(ParameterInfo parameterInfo)
		{
			_003CparameterInfo_003EP = parameterInfo;
			base._002Ector();
		}
	}
}
