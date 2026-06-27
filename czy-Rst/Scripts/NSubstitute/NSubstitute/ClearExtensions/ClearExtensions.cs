using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.ClearExtensions
{
	public static class ClearExtensions
	{
		public static void ClearSubstitute<T>(this T substitute, ClearOptions options = ClearOptions.All) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			SubstitutionContext.Current.GetCallRouterFor(substitute).Clear(options);
		}
	}
}
