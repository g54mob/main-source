using System;
using System.Collections.Generic;
using Coherence.Toolkit.Bindings;
using UnityEngine;

namespace Coherence.Toolkit.Archetypes
{
	[Serializable]
	public sealed class ArchetypeComponent : IEquatable<ArchetypeComponent>
	{
		[NonSerialized]
		private List<Binding> bindings;

		[SerializeField]
		private Component component;

		[SerializeField]
		private int lodStepsActive;

		private int maxLods;

		private string displayName;

		private string componentFullname;

		public string DisplayName => null;

		public string ComponentFullName => null;

		internal bool ExpandedInEditor { get; set; }

		public Component Component => null;

		public int LodStepsActive => 0;

		public int MaxLods => 0;

		public List<Binding> Bindings => null;

		private ArchetypeComponent()
		{
		}

		public ArchetypeComponent(Component component, int maxLods)
		{
		}

		public void AddLODStep(int step, bool fromEditor = false)
		{
		}

		public void RemoveLODStep(int step)
		{
		}

		internal void ClearBindings(CoherenceSync sync)
		{
		}

		internal bool HasSyncedBindings()
		{
			return false;
		}

		internal bool ShouldBeIncludedInArchetype()
		{
			return false;
		}

		public int GetTotalBitsOfLOD(int lodStep)
		{
			return 0;
		}

		public int GetTotalActiveBindings()
		{
			return 0;
		}

		public int GetTotalActiveMethodBindings()
		{
			return 0;
		}

		public int GetTotalActiveValueBindings()
		{
			return 0;
		}

		internal void UpdateLODCountToArchetype(int archetypeLODs)
		{
		}

		public bool AddBinding(Binding binding, SchemaType type)
		{
			return false;
		}

		public void RemoveBinding(Binding binding)
		{
		}

		internal void SetLodActive(bool isActive, int lodStep)
		{
		}

		private string GetComponentFullName()
		{
			return null;
		}

		private string GetComponentDisplayName()
		{
			return null;
		}

		internal List<Binding> GetAllBindingsOnSync(CoherenceSync sync)
		{
			return null;
		}

		public static bool operator ==(ArchetypeComponent x, ArchetypeComponent y)
		{
			return false;
		}

		public static bool operator !=(ArchetypeComponent x, ArchetypeComponent y)
		{
			return false;
		}

		public bool Equals(ArchetypeComponent other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
