using System;

namespace FluentAssertions.Equivalency
{
	public interface INode
	{
		GetSubjectId GetSubjectId { get; }

		Type Type { get; }

		Type ParentType { get; }

		Pathway Subject { get; internal set; }

		Pathway Expectation { get; }

		int Depth { get; }

		bool IsRoot { get; }

		bool RootIsCollection { get; }

		void AdjustForRemappedSubject(IMember subjectMember);
	}
}
