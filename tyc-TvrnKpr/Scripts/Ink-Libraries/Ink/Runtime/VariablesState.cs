using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ink.Runtime
{
	public class VariablesState : IEnumerable<string>, IEnumerable
	{
		public delegate void VariableChanged(string variableName, Object newValue);

		public StatePatch patch;

		private bool _batchObservingVariableChanges;

		public static bool dontSaveDefaultValues;

		private Dictionary<string, Object> _globalVariables;

		private Dictionary<string, Object> _defaultGlobalVariables;

		private CallStack _callStack;

		private HashSet<string> _changedVariablesForBatchObs;

		private ListDefinitionsOrigin _listDefsOrigin;

		public bool batchObservingVariableChanges
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CallStack callStack
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object this[string variableName]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event VariableChanged variableChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public IEnumerator<string> GetEnumerator()
		{
			return null;
		}

		public VariablesState(CallStack callStack, ListDefinitionsOrigin listDefsOrigin)
		{
		}

		public void ApplyPatch()
		{
		}

		public void SetJsonToken(Dictionary<string, object> jToken)
		{
		}

		public void WriteJson(SimpleJson.Writer writer)
		{
		}

		public bool RuntimeObjectsEqual(Object obj1, Object obj2)
		{
			return false;
		}

		public Object GetVariableWithName(string name)
		{
			return null;
		}

		public Object TryGetDefaultVariableValue(string name)
		{
			return null;
		}

		public bool GlobalVariableExistsWithName(string name)
		{
			return false;
		}

		private Object GetVariableWithName(string name, int contextIndex)
		{
			return null;
		}

		private Object GetRawVariableWithName(string name, int contextIndex)
		{
			return null;
		}

		public Object ValueAtVariablePointer(VariablePointerValue pointer)
		{
			return null;
		}

		public void Assign(VariableAssignment varAss, Object value)
		{
		}

		public void SnapshotDefaultGlobals()
		{
		}

		private void RetainListOriginsForAssignment(Object oldValue, Object newValue)
		{
		}

		public void SetGlobal(string variableName, Object value)
		{
		}

		private VariablePointerValue ResolveVariablePointer(VariablePointerValue varPointer)
		{
			return null;
		}

		private int GetContextIndexOfVariableNamed(string varName)
		{
			return 0;
		}
	}
}
