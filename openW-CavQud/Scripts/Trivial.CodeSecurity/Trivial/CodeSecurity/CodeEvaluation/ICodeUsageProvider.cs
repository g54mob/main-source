namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal interface ICodeUsageProvider
	{
		IllegalReferenceUsage GetIllegalUsage();
	}
}
