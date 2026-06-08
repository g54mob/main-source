using System;

namespace Jobberwocky.MIConvexHull
{
	public class ConvexHullGenerationException : Exception
	{
		private readonly string _003CErrorMessage_003Ek__BackingField;

		private readonly ConvexHullCreationResultOutcome _003CError_003Ek__BackingField;

		public string ErrorMessage => _003CErrorMessage_003Ek__BackingField;

		public ConvexHullCreationResultOutcome Error => _003CError_003Ek__BackingField;

		public ConvexHullGenerationException(ConvexHullCreationResultOutcome error, string errorMessage)
		{
			_003CErrorMessage_003Ek__BackingField = errorMessage;
			_003CError_003Ek__BackingField = error;
		}
	}
}
