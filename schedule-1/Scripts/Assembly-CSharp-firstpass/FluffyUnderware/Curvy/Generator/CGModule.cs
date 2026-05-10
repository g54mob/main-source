using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[ExecuteAlways]
	public abstract class CGModule : DTVersionedMonoBehaviour
	{
		private class DirtinessManager
		{
			[NotNull]
			private readonly CGModule module;

			private bool isDirty;

			private bool isStateChangeDirty;

			private bool lastIsConfiguredState;

			private static readonly Action<CGModule> SetDirtyAction;

			private static readonly Action<CGModule> SetTreeDirtyStateChangeAction;

			public bool IsDirty
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public DirtinessManager([NotNull] CGModule module)
			{
			}

			public void UnsetDirtyFlag()
			{
			}

			public void Reset()
			{
			}

			public void CheckOnStateChanged()
			{
			}

			public void OnDestroy()
			{
			}

			private void SetTreeDirtyStateChange()
			{
			}

			private void ForEachValidOutputModule(Action<CGModule> action)
			{
			}
		}

		private class Identifier
		{
			[NotNull]
			private readonly CGModule module;

			[CanBeNull]
			private string cachedStringID;

			public int ID
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			[NotNull]
			public string StringID => null;

			public Identifier([NotNull] CGModule module)
			{
			}

			public void Reset()
			{
			}
		}

		private class InformationProvider
		{
			[NotNull]
			private readonly CGModule module;

			private ModuleInfoAttribute moduleInformation;

			[CanBeNull]
			public ModuleInfoAttribute Information => null;

			public InformationProvider([NotNull] CGModule module)
			{
			}

			[CanBeNull]
			private ModuleInfoAttribute GetInformation()
			{
				return null;
			}
		}

		private class ResourceNamer
		{
			private readonly CGModule cgModule;

			private readonly Dictionary<string, Dictionary<int, string>> resourcesNameCache;

			public ResourceNamer(CGModule cgModule)
			{
			}

			public void ClearCache()
			{
			}

			[NotNull]
			private string GetResourceName([NotNull] string resourceName, int index)
			{
				return null;
			}

			public void Rename([NotNull] string resourceName, [NotNull] Component resource, int index)
			{
			}
		}

		private class Slots
		{
			[NotNull]
			private readonly CGModule module;

			[NotNull]
			public Dictionary<string, CGModuleInputSlot> InputSlotsByName { get; }

			[NotNull]
			public Dictionary<string, CGModuleOutputSlot> OutputSlotsByName { get; }

			[NotNull]
			public List<CGModuleInputSlot> InputSlots { get; }

			[NotNull]
			public List<CGModuleOutputSlot> OutputSlots { get; }

			public bool IsConfigured => false;

			public Slots([NotNull] CGModule module)
			{
			}

			private void Setup()
			{
			}

			[CanBeNull]
			private CGModuleSlot GetSlot([NotNull] FieldInfo fieldInfo)
			{
				return null;
			}

			private void Store([NotNull] CGModuleSlot slot)
			{
			}

			public void ReinitializeLinkedModulesLinkedSlots()
			{
			}

			private static void ReinitializeLinkedModulesLinkedSlots([NotNull] CGModuleSlot slot)
			{
			}

			public void ReInitializeLinkedSlots()
			{
			}

			[System.Diagnostics.Conditional("UNITY_EDITOR")]
			public void ResetInputSlotsLastDataCount()
			{
			}

			public void ResetLasRequestedParameters()
			{
			}

			public void ClearOutputData()
			{
			}

			public CGModuleInputSlot GetInputSlot(string name)
			{
				return null;
			}

			public CGModuleOutputSlot GetOutputSlot(string name)
			{
				return null;
			}

			public void CheckInputModulesNotDirty()
			{
			}
		}

		[Group("Events", Expanded = false, Sort = 1000)]
		[SerializeField]
		protected CurvyCGEvent m_OnBeforeRefresh;

		[Group("Events")]
		[SerializeField]
		protected CurvyCGEvent m_OnRefresh;

		[SerializeField]
		[HideInInspector]
		private string m_ModuleName;

		[SerializeField]
		[HideInInspector]
		private bool m_Active;

		[Group("Seed Options", Expanded = false, Sort = 1001)]
		[GroupCondition("UsesRandom")]
		[FieldAction("CBSeedOptions", ActionAttribute.ActionEnum.Callback, ShowBelowProperty = true)]
		[SerializeField]
		private bool m_RandomizeSeed;

		[HideInInspector]
		[SerializeField]
		private int m_Seed;

		[SerializeField]
		[HideInInspector]
		private int m_UniqueID;

		private CurvyGenerator generator;

		private bool isInitialized;

		[NotNull]
		private readonly ResourceNamer resourceNamer;

		[NotNull]
		private readonly InformationProvider informationProvider;

		[NotNull]
		private readonly DirtinessManager dirtinessManager;

		[NotNull]
		private readonly Slots slots;

		[NotNull]
		private readonly Identifier identifier;

		[NotNull]
		private readonly List<(Component ResourceManager, string ResourceName)> resourceManagers;

		[NonSerialized]
		public List<string> UIMessages;

		[HideInInspector]
		public CGModuleProperties Properties;

		[HideInInspector]
		public List<CGModuleLink> InputLinks;

		[HideInInspector]
		public List<CGModuleLink> OutputLinks;

		[Obsolete]
		[UsedImplicitly]
		internal int SortAncestors;

		public CurvyCGEvent OnBeforeRefresh
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvyCGEvent OnRefresh
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ModuleName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Active
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int Seed
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool RandomizeSeed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Dirty
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsConfigured => false;

		public virtual bool IsInitialized => false;

		public CurvyGenerator Generator => null;

		public int UniqueID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Obsolete("Use Generator.HasCircularReference instead")]
		[UsedImplicitly]
		public bool CircularReferenceError
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[NotNull]
		public Dictionary<string, CGModuleInputSlot> InputByName => null;

		[NotNull]
		public Dictionary<string, CGModuleOutputSlot> OutputByName => null;

		[NotNull]
		public List<CGModuleInputSlot> Input => null;

		[NotNull]
		public List<CGModuleOutputSlot> Output => null;

		[CanBeNull]
		[Obsolete]
		[UsedImplicitly]
		public ModuleInfoAttribute Info => null;

		protected CurvyCGEventArgs OnBeforeRefreshEvent(CurvyCGEventArgs e)
		{
			return null;
		}

		protected CurvyCGEventArgs OnRefreshEvent(CurvyCGEventArgs e)
		{
			return null;
		}

		protected virtual void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected override void OnValidate()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		public new virtual void Reset()
		{
		}

		public virtual void Refresh()
		{
		}

		public virtual bool DeleteAllOutputManagedResources()
		{
			return false;
		}

		public virtual void OnStateChange()
		{
		}

		public virtual void OnTemplateCreated()
		{
		}

		protected static T GetRequestParameter<T>(ref CGDataRequestParameter[] requests) where T : CGDataRequestParameter
		{
			return null;
		}

		protected static void RemoveRequestParameter(ref CGDataRequestParameter[] requests, CGDataRequestParameter request)
		{
		}

		public CGModule()
		{
		}

		public void Initialize()
		{
		}

		[CanBeNull]
		public CGModuleLink GetOutputLink(CGModuleOutputSlot outputSlot, CGModuleInputSlot inputSlot)
		{
			return null;
		}

		[NotNull]
		public List<CGModuleLink> GetOutputLinks(CGModuleOutputSlot outputSlot)
		{
			return null;
		}

		[CanBeNull]
		public CGModuleLink GetInputLink(CGModuleInputSlot inputSlot, CGModuleOutputSlot outputSlot)
		{
			return null;
		}

		[NotNull]
		public List<CGModuleLink> GetInputLinks(CGModuleInputSlot inputSlot)
		{
			return null;
		}

		[UsedImplicitly]
		[Obsolete("Use ComponentExt.DuplicateGameObject and CurvyGenerator.AddModule to duplicate the module then add it to the generator ")]
		public CGModule CopyTo(CurvyGenerator targetGenerator)
		{
			return null;
		}

		public Component AddManagedResource([NotNull] string resourceName, string context = "", int index = -1)
		{
			return null;
		}

		public void DeleteManagedResource(string resourceName, Component res, [NotNull] string context = "", bool dontUsePool = false)
		{
		}

		public bool IsManagedResource(Component res)
		{
			return false;
		}

		public List<IPool> GetAllPrefabPools()
		{
			return null;
		}

		public void DeleteAllPrefabPools()
		{
		}

		public void Delete()
		{
		}

		public CGModuleInputSlot GetInputSlot(string name)
		{
			return null;
		}

		public CGModuleOutputSlot GetOutputSlot(string name)
		{
			return null;
		}

		public bool GetManagedResources(out List<Component> components, out List<string> resourceNames)
		{
			components = null;
			resourceNames = null;
			return false;
		}

		private void SetModuleName()
		{
		}

		protected void RenameResource([NotNull] string resourceName, Component resource, int index = -1)
		{
		}

		[CanBeNull]
		private static CGModuleLink GetLink(List<CGModuleLink> lst, CGModuleSlot source, CGModuleSlot target)
		{
			return null;
		}

		[NotNull]
		private static List<CGModuleLink> GetLinks(List<CGModuleLink> lst, CGModuleSlot source)
		{
			return null;
		}

		protected PrefabPool GetPrefabPool(GameObject prefab)
		{
			return null;
		}

		protected bool TryDeleteChildrenFromAssociatedPrefab()
		{
			return false;
		}

		internal void doRefresh()
		{
		}

		public void checkOnStateChangedINTERNAL()
		{
		}

		[NotNull]
		[Obsolete("This does not return all resource managers. Read todo inside and fix it first")]
		[UsedImplicitly]
		private List<(Component, string)> GetResourceManagers()
		{
			return null;
		}

		protected override void ResetOnEnable()
		{
		}

		private bool UsesRandom()
		{
			return false;
		}

		[UsedImplicitly]
		[Obsolete]
		internal void initializeSort()
		{
		}

		[Obsolete]
		[UsedImplicitly]
		internal List<CGModule> decrementChilds()
		{
			return null;
		}

		[UsedImplicitly]
		[Obsolete]
		public int SetUniqueIdINTERNAL()
		{
			return 0;
		}

		[UsedImplicitly]
		[Obsolete]
		internal ModuleInfoAttribute getInfo()
		{
			return null;
		}

		[Obsolete]
		[UsedImplicitly]
		public void renameManagedResourcesINTERNAL()
		{
		}

		[Obsolete]
		[UsedImplicitly]
		public void ReInitializeLinkedSlots()
		{
		}

		[Obsolete("Will be removed. Copy the method's implementation if needed")]
		[UsedImplicitly]
		public List<CGModuleInputSlot> GetInputSlots(Type filterType = null)
		{
			return null;
		}

		[Obsolete("Will be removed. Copy the method's implementation if needed")]
		[UsedImplicitly]
		public List<CGModuleOutputSlot> GetOutputSlots(Type filterType = null)
		{
			return null;
		}
	}
}
