using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public abstract class FlowBase : Object, INamedContent
	{
		public class Argument
		{
			public string name;

			public bool isByReference;

			public bool isDivertTarget;
		}

		public struct VariableResolveResult
		{
			public bool found;

			public bool isGlobal;

			public bool isArgument;

			public bool isTemporary;

			public FlowBase ownerFlow;
		}

		public Dictionary<string, VariableAssignment> variableDeclarations;

		private Weave _rootWeave;

		private Dictionary<string, FlowBase> _subFlowsByName;

		private Ink.Runtime.Divert _startingSubFlowDivert;

		private Ink.Runtime.Object _startingSubFlowRuntime;

		private FlowBase _firstChildFlow;

		public string name { get; set; }

		public List<Argument> arguments { get; protected set; }

		public bool hasParameters => false;

		public abstract FlowLevel flowLevel { get; }

		public bool isFunction { get; protected set; }

		protected Dictionary<string, FlowBase> subFlowsByName => null;

		public override string typeName => null;

		public FlowBase(string name = null, List<Object> topLevelObjects = null, List<Argument> arguments = null, bool isFunction = false, bool isIncludedStory = false)
		{
		}

		private List<Object> SplitWeaveAndSubFlowContent(List<Object> contentObjs, bool isRootStory)
		{
			return null;
		}

		protected virtual void PreProcessTopLevelObjects(List<Object> topLevelObjects)
		{
		}

		public VariableResolveResult ResolveVariableWithName(string varName, Object fromNode)
		{
			return default(VariableResolveResult);
		}

		public void TryAddNewVariableDeclaration(VariableAssignment varDecl)
		{
		}

		public void ResolveWeavePointNaming()
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		private void GenerateArgumentVariableAssignments(Container container)
		{
		}

		public Object ContentWithNameAtLevel(string name, FlowLevel? level = null, bool deepSearch = false)
		{
			return null;
		}

		private Object DeepSearchForAnyLevelContent(string name)
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}

		private void CheckForDisallowedFunctionFlowControl()
		{
		}

		private void WarningInTermination(Object terminatingObject)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
