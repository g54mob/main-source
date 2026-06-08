using System;
using System.Reflection;

namespace NSubstitute.Core
{
	internal class ParameterInfoWrapper : IParameterInfo
	{
		private readonly ParameterInfo _parameterInfo;

		public Type ParameterType => _parameterInfo.ParameterType;

		public bool IsParams => _parameterInfo.IsParams();

		public bool IsOptional => _parameterInfo.IsOptional;

		public bool IsOut => _parameterInfo.IsOut;

		public ParameterInfoWrapper(ParameterInfo parameterInfo)
		{
			_parameterInfo = parameterInfo;
		}
	}
}
