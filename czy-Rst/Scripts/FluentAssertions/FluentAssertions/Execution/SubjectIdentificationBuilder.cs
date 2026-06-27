using System;
using FluentAssertions.Common;

namespace FluentAssertions.Execution
{
	internal class SubjectIdentificationBuilder
	{
		private readonly Func<string> getScopeName;

		private readonly Lazy<string[]> identifiersExtractedFromTheCode;

		private int identifierIndex;

		private Func<string> getSubject;

		public bool HasOverriddenIdentifier { get; private set; }

		public SubjectIdentificationBuilder(Func<string[]> getCallerIdentifiers, Func<string> getScopeName)
		{
			SubjectIdentificationBuilder subjectIdentificationBuilder = this;
			this.getScopeName = getScopeName;
			identifiersExtractedFromTheCode = new Lazy<string[]>(() => getCallerIdentifiers());
			getSubject = () => subjectIdentificationBuilder.GetIdentifier(0);
		}

		public void AdvanceToNextSubject()
		{
			identifierIndex++;
			int localIndex = identifierIndex;
			getSubject = () => GetIdentifier(localIndex);
		}

		public void OverrideSubjectIdentifier(Func<string> getSubject)
		{
			HasOverriddenIdentifier = true;
			this.getSubject = getSubject;
		}

		public void UsePostfix(string postfix)
		{
			int localIndex = identifierIndex;
			getSubject = () => (GetIdentifier(localIndex) + postfix).Combine(GetIdentifier(localIndex + 1));
			HasOverriddenIdentifier = true;
		}

		public string Build()
		{
			string text = getScopeName();
			string text2 = getSubject();
			if (text == null)
			{
				return text2 ?? "";
			}
			if (text2 == null)
			{
				return text;
			}
			return text + "/" + text2;
		}

		private string GetIdentifier(int index)
		{
			if (identifiersExtractedFromTheCode.Value.Length <= index)
			{
				return null;
			}
			return identifiersExtractedFromTheCode.Value[index];
		}
	}
}
