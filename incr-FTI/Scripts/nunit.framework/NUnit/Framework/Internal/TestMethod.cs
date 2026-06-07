using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal
{
	public class TestMethod : Test
	{
		public TestCaseParameters parms;

		internal bool HasExpectedResult => parms != null && parms.HasExpectedResult;

		internal object ExpectedResult => (parms != null) ? parms.ExpectedResult : null;

		internal object[] Arguments => (parms != null) ? parms.Arguments : null;

		public override bool HasChildren => false;

		public override IList<ITest> Tests => new ITest[0];

		public override string XmlElementName => "test-case";

		public override string MethodName => base.Method.Name;

		public TestMethod(IMethodInfo method)
			: base(method)
		{
		}

		public TestMethod(IMethodInfo method, Test parentSuite)
			: base(method)
		{
			if (parentSuite != null)
			{
				base.FullName = parentSuite.FullName + "." + base.Name;
			}
		}

		public override TestResult MakeTestResult()
		{
			return new TestCaseResult(this);
		}

		public override TNode AddToXml(TNode parentNode, bool recursive)
		{
			TNode tNode = parentNode.AddElement(XmlElementName);
			PopulateTestNode(tNode, recursive);
			tNode.AddAttribute("seed", base.Seed.ToString());
			return tNode;
		}
	}
}
