using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class EventChecker : CodeChecker<EventDefinition>, ICodeUsageProvider
	{
		private EventDefinition currentEvent;

		private TypeReferenceChecker typeReferenceChecker;

		private MethodChecker accessorChecker = new MethodChecker();

		public EventChecker()
		{
			typeReferenceChecker = new TypeReferenceChecker(this);
		}

		public override void SecurityCheckCode(CodeSecurityContext context, EventDefinition eventDefinition)
		{
			currentEvent = eventDefinition;
			typeReferenceChecker.SecurityCheckCode(context, eventDefinition.EventType);
			SecurityCheckAndReportMemberReference(context, eventDefinition, this);
			if (eventDefinition.AddMethod != null)
			{
				accessorChecker.SecurityCheckCode(context, eventDefinition.AddMethod);
			}
			if (eventDefinition.RemoveMethod != null)
			{
				accessorChecker.SecurityCheckCode(context, eventDefinition.RemoveMethod);
			}
		}

		public IllegalReferenceUsage GetIllegalUsage()
		{
			return new IllegalReferenceUsage(currentEvent);
		}
	}
}
