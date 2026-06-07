using System;
using System.Collections.Generic;
using Coherence.Log;
using Coherence.Toolkit.Bindings;
using UnityEngine;

namespace Coherence.Toolkit.Archetypes
{
	[Serializable]
	internal class ToolkitArchetype
	{
		private sealed class ByReferenceEqualityComparer : IEqualityComparer<Component>
		{
			public bool Equals(Component x, Component y)
			{
				return false;
			}

			public int GetHashCode(Component obj)
			{
				return 0;
			}
		}

		public Action<int> OnLODChanged;

		[SerializeField]
		private List<ArchetypeLODStep> lodLevels;

		private List<Component> cachedComponents;

		[SerializeField]
		private List<ArchetypeComponent> boundComponents;

		private readonly Dictionary<Component, ArchetypeComponent> indexedBoundComponents;

		private int lastObservedLodLevel;

		private static Coherence.Log.Logger logger;

		[SerializeField]
		internal bool GeneratesArchetypeDefinition;

		public CoherenceSync CoherenceSync { get; private set; }

		public List<Component> CachedComponents => null;

		[Obsolete("Use CoherenceSync.ArchetypeName")]
		[Deprecated("4/3/2023", 1, 2, 0)]
		public string ArchetypeName => null;

		internal List<ArchetypeLODStep> LODLevels => null;

		public List<ArchetypeComponent> BoundComponents => null;

		public int LastObservedLodLevel => 0;

		internal void Setup(CoherenceSync coherenceSync)
		{
		}

		internal bool Validate()
		{
			return false;
		}

		internal bool RefreshGeneratesArchetypeDefinitionFlag()
		{
			return false;
		}

		public void AddLODLevel(bool fromEditor = false)
		{
		}

		public void SetLodLevelDistance(float newDistance, int lodStep)
		{
		}

		public void RemoveLodLevel(int index)
		{
		}

		internal bool UpdateBoundVariables(CoherenceSync coherenceSync)
		{
			return false;
		}

		internal bool UpdateBindableComponents()
		{
			return false;
		}

		private void IndexBoundComponents()
		{
		}

		private bool IsBindValid(Binding binding, Component component)
		{
			return false;
		}

		private bool IsComponentSameAndBindable(Component component, Component bindingComponent)
		{
			return false;
		}

		private bool UpdateBinding(Binding binding, ArchetypeComponent boundComponent)
		{
			return false;
		}

		internal void SetBindingActive(Binding binding, ArchetypeComponent boundComponent, bool active)
		{
		}

		public int GetTotalActiveBitsOfLOD(int lodStep)
		{
			return 0;
		}

		public int GetLargestLOD()
		{
			return 0;
		}

		public ArchetypeComponent GetBoundComponentByComponent(Component component)
		{
			return null;
		}

		internal int GetTotalBindings(bool methods)
		{
			return 0;
		}

		public void SetObservedLodLevel(int newObservedLodLevel)
		{
		}
	}
}
