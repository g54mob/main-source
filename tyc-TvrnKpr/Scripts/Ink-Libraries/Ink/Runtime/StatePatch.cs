using System.Collections.Generic;

namespace Ink.Runtime
{
	public class StatePatch
	{
		private Dictionary<string, Object> _globals;

		private HashSet<string> _changedVariables;

		private Dictionary<Container, int> _visitCounts;

		private Dictionary<Container, int> _turnIndices;

		public Dictionary<string, Object> globals => null;

		public HashSet<string> changedVariables => null;

		public Dictionary<Container, int> visitCounts => null;

		public Dictionary<Container, int> turnIndices => null;

		public StatePatch(StatePatch toCopy)
		{
		}

		public bool TryGetGlobal(string name, out Object value)
		{
			value = null;
			return false;
		}

		public void SetGlobal(string name, Object value)
		{
		}

		public void AddChangedVariable(string name)
		{
		}

		public bool TryGetVisitCount(Container container, out int count)
		{
			count = default(int);
			return false;
		}

		public void SetVisitCount(Container container, int count)
		{
		}

		public void SetTurnIndex(Container container, int index)
		{
		}

		public bool TryGetTurnIndex(Container container, out int index)
		{
			index = default(int);
			return false;
		}
	}
}
