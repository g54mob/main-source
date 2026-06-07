using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	[PersistenceOptIn]
	public abstract class AiComponent : IPersistable, IReferenceableObject
	{
		private static AiComponent[] _prototypes;

		private static List<AiComponent> _unlockablePrototypes;

		public static float deltaTime;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isHidden;

		[PersistenceOptIn]
		private string _displayNameKeyOverride;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _descriptionKeyOverride;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _firstInitCalled;

		public static Type[] AllComponentTypes { get; private set; }

		public virtual bool ShouldUpdateTooltipPeriodically { get; protected set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int ExecutionOrder { get; protected set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int DisplayOrder { get; set; }

		public virtual bool IsHidden
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public int Id { get; protected set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameObjectX Owner { get; protected set; }

		[PersistenceOptIn]
		public string Name { get; protected set; }

		[PersistenceOptIn]
		public string DisplayName { get; protected set; }

		public string DisplayNameKey
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string Description { get; protected set; }

		public string DescriptionKey
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public event EventHandler TooltipChanged
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

		public event EventHandler<EventArgs<bool>> IsHiddenChanged
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

		public static AiComponent InstantiateFromType(Type type, GameObjectX owner)
		{
			return null;
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected virtual string GetTooltipTextKey()
		{
			return null;
		}

		protected void RaiseTooltipChangedEvent()
		{
		}

		public virtual TooltipData GetTooltipData()
		{
			return null;
		}

		public static void AddDefaultComponents(GameObjectX gox)
		{
		}

		protected AiComponent()
		{
		}

		protected AiComponent(GameObjectX owner, bool canOwnerBeNull = false, bool expectCodexTooltip = true)
		{
		}

		protected void RefreshDescription()
		{
		}

		protected void CheckCodexTooltip(bool expectCodexTooltip, string codexIdOverride = null)
		{
		}

		protected void ParseDescription(string description)
		{
		}

		protected AiComponent(GameObjectX owner, string name, string displayNameKey, string descriptionKey)
		{
		}

		protected virtual int GetDefaultExecutionOrder()
		{
			return 0;
		}

		public virtual void Init()
		{
		}

		private void OnOwnerDisplayNameChanged(object sender, EventArgs e)
		{
		}

		public virtual void FirstInit()
		{
		}

		public virtual void Update()
		{
		}

		public void RemoveComponent()
		{
		}

		public virtual void OnRemoving()
		{
		}

		public virtual bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public virtual string GetTraitBadgeIconPrefabName()
		{
			return null;
		}
	}
}
