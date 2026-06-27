using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace Moq.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("Moq.Properties.Resources", typeof(Resources).Assembly);
					resourceMan = resourceManager;
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static string AlreadyInitialized => ResourceManager.GetString("AlreadyInitialized", resourceCulture);

		internal static string ArgumentCannotBeEmpty => ResourceManager.GetString("ArgumentCannotBeEmpty", resourceCulture);

		internal static string ArgumentMatcherWillNeverMatch => ResourceManager.GetString("ArgumentMatcherWillNeverMatch", resourceCulture);

		internal static string AsMustBeInterface => ResourceManager.GetString("AsMustBeInterface", resourceCulture);

		internal static string CallBaseCannotBeUsedWithDelegateMocks => ResourceManager.GetString("CallBaseCannotBeUsedWithDelegateMocks", resourceCulture);

		internal static string CantSetReturnValueForVoid => ResourceManager.GetString("CantSetReturnValueForVoid", resourceCulture);

		internal static string ConstructorArgsForDelegate => ResourceManager.GetString("ConstructorArgsForDelegate", resourceCulture);

		internal static string ConstructorArgsForInterface => ResourceManager.GetString("ConstructorArgsForInterface", resourceCulture);

		internal static string ConstructorNotFound => ResourceManager.GetString("ConstructorNotFound", resourceCulture);

		internal static string DelaysMustBeGreaterThanZero => ResourceManager.GetString("DelaysMustBeGreaterThanZero", resourceCulture);

		internal static string FieldsNotSupported => ResourceManager.GetString("FieldsNotSupported", resourceCulture);

		internal static string InvalidCallbackNotADelegateWithReturnTypeVoid => ResourceManager.GetString("InvalidCallbackNotADelegateWithReturnTypeVoid", resourceCulture);

		internal static string InvalidCallbackParameterCountMismatch => ResourceManager.GetString("InvalidCallbackParameterCountMismatch", resourceCulture);

		internal static string InvalidCallbackParameterMismatch => ResourceManager.GetString("InvalidCallbackParameterMismatch", resourceCulture);

		internal static string InvalidCallbackReturnTypeMismatch => ResourceManager.GetString("InvalidCallbackReturnTypeMismatch", resourceCulture);

		internal static string InvalidMockGetType => ResourceManager.GetString("InvalidMockGetType", resourceCulture);

		internal static string InvalidReturnsCallbackNotADelegateWithReturnType => ResourceManager.GetString("InvalidReturnsCallbackNotADelegateWithReturnType", resourceCulture);

		internal static string LastMemberHasNonInterceptableReturnType => ResourceManager.GetString("LastMemberHasNonInterceptableReturnType", resourceCulture);

		internal static string LinqBinaryOperatorNotSupported => ResourceManager.GetString("LinqBinaryOperatorNotSupported", resourceCulture);

		internal static string LinqMethodNotSupported => ResourceManager.GetString("LinqMethodNotSupported", resourceCulture);

		internal static string LinqMethodNotVirtual => ResourceManager.GetString("LinqMethodNotVirtual", resourceCulture);

		internal static string MatcherAssignmentFailedDuringExpressionReconstruction => ResourceManager.GetString("MatcherAssignmentFailedDuringExpressionReconstruction", resourceCulture);

		internal static string MemberMissing => ResourceManager.GetString("MemberMissing", resourceCulture);

		internal static string MethodIsPublic => ResourceManager.GetString("MethodIsPublic", resourceCulture);

		internal static string MethodMissing => ResourceManager.GetString("MethodMissing", resourceCulture);

		internal static string MethodNotVisibleToProxyFactory => ResourceManager.GetString("MethodNotVisibleToProxyFactory", resourceCulture);

		internal static string MinDelayMustBeLessThanMaxDelay => ResourceManager.GetString("MinDelayMustBeLessThanMaxDelay", resourceCulture);

		internal static string MockExceptionMessage => ResourceManager.GetString("MockExceptionMessage", resourceCulture);

		internal static string NextMemberNonInterceptable => ResourceManager.GetString("NextMemberNonInterceptable", resourceCulture);

		internal static string NoConstructorCallFound => ResourceManager.GetString("NoConstructorCallFound", resourceCulture);

		internal static string NoInvocationsPerformed => ResourceManager.GetString("NoInvocationsPerformed", resourceCulture);

		internal static string NoMatchingCallsAtLeast => ResourceManager.GetString("NoMatchingCallsAtLeast", resourceCulture);

		internal static string NoMatchingCallsAtLeastOnce => ResourceManager.GetString("NoMatchingCallsAtLeastOnce", resourceCulture);

		internal static string NoMatchingCallsAtMost => ResourceManager.GetString("NoMatchingCallsAtMost", resourceCulture);

		internal static string NoMatchingCallsAtMostOnce => ResourceManager.GetString("NoMatchingCallsAtMostOnce", resourceCulture);

		internal static string NoMatchingCallsBetweenExclusive => ResourceManager.GetString("NoMatchingCallsBetweenExclusive", resourceCulture);

		internal static string NoMatchingCallsBetweenInclusive => ResourceManager.GetString("NoMatchingCallsBetweenInclusive", resourceCulture);

		internal static string NoMatchingCallsExactly => ResourceManager.GetString("NoMatchingCallsExactly", resourceCulture);

		internal static string NoMatchingCallsNever => ResourceManager.GetString("NoMatchingCallsNever", resourceCulture);

		internal static string NoMatchingCallsOnce => ResourceManager.GetString("NoMatchingCallsOnce", resourceCulture);

		internal static string NoSetup => ResourceManager.GetString("NoSetup", resourceCulture);

		internal static string ObjectInstanceNotMock => ResourceManager.GetString("ObjectInstanceNotMock", resourceCulture);

		internal static string OutExpressionMustBeConstantValue => ResourceManager.GetString("OutExpressionMustBeConstantValue", resourceCulture);

		internal static string PerformedInvocations => ResourceManager.GetString("PerformedInvocations", resourceCulture);

		internal static string PropertyGetNotFound => ResourceManager.GetString("PropertyGetNotFound", resourceCulture);

		internal static string PropertySetNotFound => ResourceManager.GetString("PropertySetNotFound", resourceCulture);

		internal static string ProtectedMemberNotFound => ResourceManager.GetString("ProtectedMemberNotFound", resourceCulture);

		internal static string RefExpressionMustBeConstantValue => ResourceManager.GetString("RefExpressionMustBeConstantValue", resourceCulture);

		internal static string ReturnValueRequired => ResourceManager.GetString("ReturnValueRequired", resourceCulture);

		internal static string SetupNotEventAdd => ResourceManager.GetString("SetupNotEventAdd", resourceCulture);

		internal static string SetupNotEventRemove => ResourceManager.GetString("SetupNotEventRemove", resourceCulture);

		internal static string SetupNotProperty => ResourceManager.GetString("SetupNotProperty", resourceCulture);

		internal static string SetupNotSetter => ResourceManager.GetString("SetupNotSetter", resourceCulture);

		internal static string TypeHasNoDefaultConstructor => ResourceManager.GetString("TypeHasNoDefaultConstructor", resourceCulture);

		internal static string TypeMatchersMayNotBeUsedWithCallbacks => ResourceManager.GetString("TypeMatchersMayNotBeUsedWithCallbacks", resourceCulture);

		internal static string TypeNotImplementInterface => ResourceManager.GetString("TypeNotImplementInterface", resourceCulture);

		internal static string TypeNotMockable => ResourceManager.GetString("TypeNotMockable", resourceCulture);

		internal static string UnexpectedPublicProperty => ResourceManager.GetString("UnexpectedPublicProperty", resourceCulture);

		internal static string UnexpectedTranslationOfMemberAccess => ResourceManager.GetString("UnexpectedTranslationOfMemberAccess", resourceCulture);

		internal static string UnhandledBindingType => ResourceManager.GetString("UnhandledBindingType", resourceCulture);

		internal static string UnhandledExpressionType => ResourceManager.GetString("UnhandledExpressionType", resourceCulture);

		internal static string UnmatchedSetup => ResourceManager.GetString("UnmatchedSetup", resourceCulture);

		internal static string UnsupportedExpression => ResourceManager.GetString("UnsupportedExpression", resourceCulture);

		internal static string UnsupportedExpressionWithHint => ResourceManager.GetString("UnsupportedExpressionWithHint", resourceCulture);

		internal static string UnsupportedExtensionMethod => ResourceManager.GetString("UnsupportedExtensionMethod", resourceCulture);

		internal static string UnsupportedMember => ResourceManager.GetString("UnsupportedMember", resourceCulture);

		internal static string UnsupportedNonOverridableMember => ResourceManager.GetString("UnsupportedNonOverridableMember", resourceCulture);

		internal static string UnsupportedStaticMember => ResourceManager.GetString("UnsupportedStaticMember", resourceCulture);

		internal static string UnverifiedInvocations => ResourceManager.GetString("UnverifiedInvocations", resourceCulture);

		internal static string UseItExprIsNullRatherThanNullArgumentValue => ResourceManager.GetString("UseItExprIsNullRatherThanNullArgumentValue", resourceCulture);

		internal static string UseItIsOtherOverload => ResourceManager.GetString("UseItIsOtherOverload", resourceCulture);

		internal static string VerificationErrorsOfInnerMock => ResourceManager.GetString("VerificationErrorsOfInnerMock", resourceCulture);

		internal static string VerificationErrorsOfMock => ResourceManager.GetString("VerificationErrorsOfMock", resourceCulture);

		internal static string VerificationErrorsOfMockRepository => ResourceManager.GetString("VerificationErrorsOfMockRepository", resourceCulture);

		internal Resources()
		{
		}
	}
}
