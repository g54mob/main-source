using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Types
{
	public class AssemblyAssertions : ReferenceTypeAssertions<Assembly, AssemblyAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "assembly";

		public AssemblyAssertions(Assembly assembly, AssertionChain assertionChain)
			: base(assembly, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<AssemblyAssertions> NotReference(Assembly assembly, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(assembly, "assembly");
			string name = assembly.GetName().Name;
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected assembly not to reference assembly {0}{reason}, but {context:assembly} is <null>.", name);
			if (assertionChain.Succeeded)
			{
				string name2 = base.Subject.GetName().Name;
				IEnumerable<string> source = from x in base.Subject.GetReferencedAssemblies()
					select x.Name;
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!source.Contains(name)).FailWith("Expected assembly {0} not to reference assembly {1}{reason}.", name2, name);
			}
			return new AndConstraint<AssemblyAssertions>(this);
		}

		public AndConstraint<AssemblyAssertions> Reference(Assembly assembly, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(assembly, "assembly");
			string name = assembly.GetName().Name;
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected assembly to reference assembly {0}{reason}, but {context:assembly} is <null>.", name);
			if (assertionChain.Succeeded)
			{
				string name2 = base.Subject.GetName().Name;
				IEnumerable<string> source = from x in base.Subject.GetReferencedAssemblies()
					select x.Name;
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(source.Contains(name)).FailWith("Expected assembly {0} to reference assembly {1}{reason}, but it does not.", name2, name);
			}
			return new AndConstraint<AssemblyAssertions>(this);
		}

		public AndWhichConstraint<AssemblyAssertions, Type> DefineType(string @namespace, string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected assembly to define type {0}.{1}{reason}, but {context:assembly} is <null>.", @namespace, name);
			Type type = null;
			if (assertionChain.Succeeded)
			{
				type = base.Subject.GetTypes().SingleOrDefault((Type t) => t.Namespace == @namespace && t.Name == name);
				assertionChain.ForCondition((object)type != null).BecauseOf(because, becauseArgs).FailWith("Expected assembly {0} to define type {1}.{2}{reason}, but it does not.", base.Subject.FullName, @namespace, name);
			}
			return new AndWhichConstraint<AssemblyAssertions, Type>(this, type);
		}

		public AndConstraint<AssemblyAssertions> BeUnsigned([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition((object)base.Subject != null).FailWith("Can't check for assembly signing if {context:assembly} reference is <null>.");
			if (assertionChain.Succeeded)
			{
				AssertionChain obj = assertionChain.BecauseOf(because, becauseArgs);
				byte[] publicKey = base.Subject.GetName().GetPublicKey();
				obj.ForCondition(publicKey == null || publicKey.Length <= 0).FailWith("Did not expect the assembly {0} to be signed{reason}, but it is.", base.Subject.FullName);
			}
			return new AndConstraint<AssemblyAssertions>(this);
		}

		public AndConstraint<AssemblyAssertions> BeSignedWithPublicKey(string publicKey, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(publicKey, "publicKey");
			assertionChain.ForCondition((object)base.Subject != null).FailWith("Can't check for assembly signing if {context:assembly} reference is <null>.");
			if (assertionChain.Succeeded)
			{
				byte[] bytes = base.Subject.GetName().GetPublicKey() ?? Array.Empty<byte>();
				string assemblyKey = ToHexString(bytes);
				assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected assembly {0} to have public key {1} ", base.Subject.FullName, publicKey, delegate(AssertionChain chain)
				{
					chain.ForCondition(bytes.Length != 0).FailWith("{reason}, but it is unsigned.").Then.ForCondition(string.Equals(assemblyKey, publicKey, StringComparison.OrdinalIgnoreCase)).FailWith("{reason}, but it has {0} instead.", assemblyKey);
				});
			}
			return new AndConstraint<AssemblyAssertions>(this);
		}

		private static string ToHexString(byte[] bytes)
		{
			return SystemExtensions.Replace(BitConverter.ToString(bytes), "-", string.Empty, StringComparison.Ordinal);
		}
	}
}
