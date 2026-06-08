using System;

namespace Moq
{
	internal interface IMatcher
	{
		bool Matches(object argument, Type parameterType);

		void SetupEvaluatedSuccessfully(object argument, Type parameterType);
	}
}
