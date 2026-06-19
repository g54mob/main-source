using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal abstract class CodeChecker<T> where T : MemberReference
	{
		public abstract void SecurityCheckCode(CodeSecurityContext context, T definition);

		protected void SecurityCheckAndReportTypeReferenceAndNamespace(CodeSecurityContext context, TypeReference reference, ICodeUsageProvider usageProvider)
		{
			if (CheckForIllegalNamespaceReference(context, reference))
			{
				ReportIllegalNamespaceReferenceOccurence(context, reference.Namespace, reference, usageProvider.GetIllegalUsage());
			}
			if (CheckForIllegalTypeReference(context, reference))
			{
				ReportIllegalTypeReferenceOccurence(context, reference, usageProvider.GetIllegalUsage());
			}
		}

		protected void SecurityCheckAndReportMemberReference(CodeSecurityContext context, MemberReference reference, ICodeUsageProvider usageProvider)
		{
			if (CheckForIllegalMemberReference(context, reference))
			{
				bool indirect = CheckForIllegalTypeReference(context, reference.DeclaringType);
				ReportIllegalMemberReferenceOccurence(context, reference, usageProvider.GetIllegalUsage(), indirect);
			}
		}

		protected bool CheckForIllegalNamespaceReference(CodeSecurityContext context, TypeReference potentialIllegalNamespace)
		{
			return !context.IsNamespaceReferenceAllowedCached(potentialIllegalNamespace);
		}

		protected bool CheckForIllegalTypeReference(CodeSecurityContext context, TypeReference potentialIllegalType)
		{
			return !context.IsTypeReferenceAllowedCached(potentialIllegalType);
		}

		protected bool CheckForIllegalMemberReference(CodeSecurityContext context, MemberReference potentialIllegalMember)
		{
			return !context.IsMemberReferenceAllowedCached(potentialIllegalMember);
		}

		protected void ReportIllegalNamespaceReferenceOccurence(CodeSecurityContext context, string illegalNamespace, TypeReference indirectIllegalTypeReference, IllegalReferenceUsage illegalReferenceUsage)
		{
			context.Report.AddIllegalNamespaceReferenceOccurence(illegalNamespace, indirectIllegalTypeReference, illegalReferenceUsage);
		}

		protected void ReportIllegalTypeReferenceOccurence(CodeSecurityContext context, TypeReference illegalType, IllegalReferenceUsage illegalReferenceUsage)
		{
			context.Report.AddIllegalTypeReferenceOccurence(illegalType, illegalReferenceUsage);
		}

		protected void ReportIllegalMemberReferenceOccurence(CodeSecurityContext context, MemberReference illegalMember, IllegalReferenceUsage illegalReferenceUsage, bool indirect)
		{
			context.Report.AddIllegalMemberReferenceOccurence(illegalMember, illegalReferenceUsage, indirect);
		}
	}
}
