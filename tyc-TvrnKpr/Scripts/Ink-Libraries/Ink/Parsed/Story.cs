using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class Story : FlowBase
	{
		public enum SymbolType : uint
		{
			Knot = 0u,
			List = 1u,
			ListItem = 2u,
			Var = 3u,
			SubFlowAndWeave = 4u,
			Arg = 5u,
			Temp = 6u
		}

		public Dictionary<string, Expression> constants;

		public Dictionary<string, ExternalDeclaration> externals;

		public bool countAllVisits;

		private ErrorHandler _errorHandler;

		private bool _hadError;

		private bool _hadWarning;

		private HashSet<Container> _dontFlattenContainers;

		private Dictionary<string, ListDefinition> _listDefs;

		public override FlowLevel flowLevel => default(FlowLevel);

		internal bool hadError => false;

		internal bool hadWarning => false;

		public Story(List<Object> toplevelObjects, bool isInclude = false)
		{
		}

		protected override void PreProcessTopLevelObjects(List<Object> topLevelContent)
		{
		}

		public Ink.Runtime.Story ExportRuntime(ErrorHandler errorHandler = null)
		{
			return null;
		}

		public ListDefinition ResolveList(string listName)
		{
			return null;
		}

		public ListElementDefinition ResolveListItem(string listName, string itemName, Object source = null)
		{
			return null;
		}

		private void FlattenContainersIn(Container container)
		{
		}

		private void TryFlattenContainer(Container container)
		{
		}

		public override void Error(string message, Object source, bool isWarning)
		{
		}

		public void ResetError()
		{
		}

		public bool IsExternal(string namedFuncTarget)
		{
			return false;
		}

		public void AddExternal(ExternalDeclaration decl)
		{
		}

		public void DontFlattenContainer(Container container)
		{
		}

		private void NameConflictError(Object obj, string name, Object existingObj, string typeNameToPrint)
		{
		}

		public static bool IsReservedKeyword(string name)
		{
			return false;
		}

		public void CheckForNamingCollisions(Object obj, string name, SymbolType symbolType, string typeNameOverride = null)
		{
		}
	}
}
