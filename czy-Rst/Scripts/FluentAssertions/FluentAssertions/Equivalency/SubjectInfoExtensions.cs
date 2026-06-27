using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	public static class SubjectInfoExtensions
	{
		public static bool WhichSetterHas(this IMemberInfo memberInfo, CSharpAccessModifier accessModifier)
		{
			return memberInfo.SetterAccessibility == accessModifier;
		}

		public static bool WhichSetterDoesNotHave(this IMemberInfo memberInfo, CSharpAccessModifier accessModifier)
		{
			return memberInfo.SetterAccessibility != accessModifier;
		}

		public static bool WhichGetterHas(this IMemberInfo memberInfo, CSharpAccessModifier accessModifier)
		{
			return memberInfo.GetterAccessibility == accessModifier;
		}

		public static bool WhichGetterDoesNotHave(this IMemberInfo memberInfo, CSharpAccessModifier accessModifier)
		{
			return memberInfo.GetterAccessibility != accessModifier;
		}
	}
}
