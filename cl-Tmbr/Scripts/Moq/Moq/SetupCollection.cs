using System;
using System.Collections;
using System.Collections.Generic;

namespace Moq
{
	internal sealed class SetupCollection : ISetupList, IReadOnlyList<ISetup>, IEnumerable<ISetup>, IEnumerable, IReadOnlyCollection<ISetup>
	{
		private List<Setup> setups;

		private HashSet<Expectation> activeSetups;

		public int Count
		{
			get
			{
				lock (setups)
				{
					return setups.Count;
				}
			}
		}

		public ISetup this[int index]
		{
			get
			{
				lock (setups)
				{
					return setups[index];
				}
			}
		}

		public SetupCollection()
		{
			setups = new List<Setup>();
			activeSetups = new HashSet<Expectation>();
		}

		public void Add(Setup setup)
		{
			lock (setups)
			{
				setups.Add(setup);
				if (!activeSetups.Add(setup.Expectation))
				{
					MarkOverriddenSetups();
				}
			}
		}

		private void MarkOverriddenSetups()
		{
			HashSet<Expectation> hashSet = new HashSet<Expectation>();
			for (int num = setups.Count - 1; num >= 0; num--)
			{
				Setup setup = setups[num];
				if (!setup.IsOverridden && !setup.IsConditional && !hashSet.Add(setup.Expectation))
				{
					setup.MarkAsOverridden();
				}
			}
		}

		public void Clear()
		{
			lock (setups)
			{
				setups.Clear();
				activeSetups.Clear();
			}
		}

		public List<Setup> FindAll(Func<Setup, bool> predicate)
		{
			List<Setup> list = new List<Setup>();
			lock (setups)
			{
				for (int i = 0; i < setups.Count; i++)
				{
					Setup setup = setups[i];
					if (!setup.IsOverridden && predicate(setup))
					{
						list.Add(setup);
					}
				}
				return list;
			}
		}

		public Setup FindLast(Func<Setup, bool> predicate)
		{
			if (setups.Count == 0)
			{
				return null;
			}
			lock (setups)
			{
				for (int num = setups.Count - 1; num >= 0; num--)
				{
					Setup setup = setups[num];
					if (!setup.IsOverridden && predicate(setup))
					{
						return setup;
					}
				}
			}
			return null;
		}

		public void Reset()
		{
			lock (setups)
			{
				foreach (Setup setup in setups)
				{
					setup.Reset();
				}
			}
		}

		public IEnumerator<ISetup> GetEnumerator()
		{
			lock (setups)
			{
				IEnumerable<Setup> enumerable = setups.ToArray();
				return enumerable.GetEnumerator();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
