using System.Collections.Immutable;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.TemplateSystem;

namespace Timberborn.UnderstructureSystem
{
	internal class UnderstructureConstraintValidator : IBlockObjectValidator
	{
		private readonly UnderstructureFinder _understructureFinder;

		public UnderstructureConstraintValidator(UnderstructureFinder understructureFinder)
		{
			_understructureFinder = understructureFinder;
		}

		public bool IsValid(BlockObject blockObject, out string errorMessage)
		{
			if (!IsValid(blockObject, out UnderstructureConstraint understructureConstraint))
			{
				errorMessage = understructureConstraint.ErrorMessage;
				return false;
			}
			errorMessage = null;
			return true;
		}

		private bool IsValid(BlockObject blockObject, out UnderstructureConstraint understructureConstraint)
		{
			understructureConstraint = blockObject.GetComponent<UnderstructureConstraint>();
			if (understructureConstraint != null)
			{
				return IsValidAgainstSpec(blockObject, understructureConstraint);
			}
			return true;
		}

		private bool IsValidAgainstSpec(BlockObject validatedBlockObject, UnderstructureConstraint understructureConstraint)
		{
			ImmutableArray<string> understructureTemplateNames = understructureConstraint.UnderstructureTemplateNames;
			BlockObject blockObject = _understructureFinder.FindStrict(validatedBlockObject);
			if ((bool)blockObject)
			{
				TemplateSpec templateBelow = blockObject.GetComponent<TemplateSpec>();
				if ((object)templateBelow != null)
				{
					return understructureTemplateNames.FastAny((string expected) => templateBelow.IsNamed(expected));
				}
			}
			return false;
		}
	}
}
