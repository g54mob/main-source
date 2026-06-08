using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Exceptions
{
	public class RedundantArgumentMatcherException : SubstituteException
	{
		public RedundantArgumentMatcherException(IEnumerable<IArgumentSpecification> remainingSpecifications, IEnumerable<IArgumentSpecification> allSpecifications)
			: this(FormatErrorMessage(remainingSpecifications, allSpecifications))
		{
		}

		public RedundantArgumentMatcherException(string message)
			: base(message)
		{
		}

		private static string FormatErrorMessage(IEnumerable<IArgumentSpecification> remainingSpecifications, IEnumerable<IArgumentSpecification> allSpecifications)
		{
			return "Some argument specifications (e.g. Arg.Is, Arg.Any) were left over after the last call." + Environment.NewLine + Environment.NewLine + "This is often caused by using an argument spec with a call to a member NSubstitute does not handle (such as a non-virtual member or a call to an instance which is not a substitute), or for a purpose other than specifying a call (such as using an arg spec as a return value). For example:" + Environment.NewLine + Environment.NewLine + "    var sub = Substitute.For<SomeClass>();" + Environment.NewLine + "    var realType = new MyRealType(sub);" + Environment.NewLine + "    // INCORRECT, arg spec used on realType, not a substitute:" + Environment.NewLine + "    realType.SomeMethod(Arg.Any<int>()).Returns(2);" + Environment.NewLine + "    // INCORRECT, arg spec used as a return value, not to specify a call:" + Environment.NewLine + "    sub.VirtualMethod(2).Returns(Arg.Any<int>());" + Environment.NewLine + "    // INCORRECT, arg spec used with a non-virtual method:" + Environment.NewLine + "    sub.NonVirtualMethod(Arg.Any<int>()).Returns(2);" + Environment.NewLine + "    // CORRECT, arg spec used to specify virtual call on a substitute:" + Environment.NewLine + "    sub.VirtualMethod(Arg.Any<int>()).Returns(2);" + Environment.NewLine + Environment.NewLine + "To fix this make sure you only use argument specifications with calls to substitutes. If your substitute is a class, make sure the member is virtual." + Environment.NewLine + Environment.NewLine + "Another possible cause is that the argument spec type does not match the actual argument type, but code compiles due to an implicit cast. For example, Arg.Any<int>() was used, but Arg.Any<double>() was required." + Environment.NewLine + Environment.NewLine + "NOTE: the cause of this exception can be in a previously executed test. Use the diagnostics below to see the types of any redundant arg specs, then work out where they are being created." + Environment.NewLine + Environment.NewLine + "Diagnostic information:" + Environment.NewLine + Environment.NewLine + "Remaining (non-bound) argument specifications:" + Environment.NewLine + FormatSpecifications(remainingSpecifications) + Environment.NewLine + Environment.NewLine + "All argument specifications:" + Environment.NewLine + FormatSpecifications(allSpecifications) + Environment.NewLine;
		}

		private static string FormatSpecifications(IEnumerable<IArgumentSpecification> specifications)
		{
			return string.Join(Environment.NewLine, specifications.Select((IArgumentSpecification spec) => "    " + spec.ToString()));
		}
	}
}
