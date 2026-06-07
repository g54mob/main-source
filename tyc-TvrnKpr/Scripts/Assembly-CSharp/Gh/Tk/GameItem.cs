using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class GameItem : IPersistable
	{
		public sealed class AmountChangedEventArgs : EventArgs
		{
			public int OldAmount { get; private set; }

			public int NewAmount { get; private set; }

			public int Difference => 0;

			public AmountChangedEventArgs(int old, int @new)
			{
			}
		}

		[JsonIgnore]
		private GameItemTrait[] _tmpTraits;

		private List<string> _traits;

		private List<string> _removedTraits;

		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		[PersistenceAllowBrokenReferenceOnLoad]
		public Actor PickUpInProgressBy;

		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		[PersistenceAllowBrokenReferenceOnLoad]
		public Actor SetDownInProgressBy;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool CreationInProgress;

		public const float GROUND_SPOIL_MODIFIER = 2f;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected bool IsTemplate;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isInCraftingProcess;

		public static Dictionary<int, GameObject> _gameItemVisuals;

		[JsonIgnore]
		private GameObjectX _targetGox;

		private static Dictionary<Type, MethodInfo> _jsonHelperToMethodCache;

		[JsonIgnore]
		private int _amount;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float? _weight;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int? _currentPrice;

		private bool _isItemStack;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Inventory _parentInventory;

		[JsonIgnore]
		public virtual string VisualKey => null;

		[JsonIgnore]
		public string VisualKeyBase => null;

		[JsonIgnore]
		public virtual int Stars => 0;

		[JsonIgnore]
		public IEnumerable<string> Traits => null;

		[JsonIgnore]
		public string FullName => null;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameItemTemplate Template { get; protected set; }

		[JsonIgnore]
		public bool IsInCraftingProcess
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public virtual bool IgnoreInLarder => false;

		public int Id { get; private set; }

		[JsonIgnore]
		public GameObjectX TargetGox => null;

		[JsonIgnore]
		public GameObject Visual
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[JsonIgnore]
		public string Description => null;

		public int Amount
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		[JsonIgnore]
		public int MaxAmount => 0;

		[JsonIgnore]
		public float Weight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int CurrentPrice
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsSealed { get; set; }

		public bool IsItemStack
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsContainer { get; set; }

		[JsonIgnore]
		public virtual int AveragePrice => 0;

		[JsonIgnore]
		public string Type => null;

		[JsonIgnore]
		public string Name => null;

		[JsonIgnore]
		public string FullNameKey => null;

		[JsonIgnore]
		public Flammability Flammability => default(Flammability);

		[JsonIgnore]
		public Inventory ParentInventory
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event EventHandler<AmountChangedEventArgs> AmountChanged
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

		public static event EventHandler<EventArgs<(GameItemTemplate template, int amount)>> GameItemPurchased
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

		public bool HasTrait<T>() where T : GameItemTrait
		{
			return false;
		}

		public void AddTrait(string trait)
		{
		}

		public void RemoveTrait(string trait)
		{
		}

		public IEnumerable<GameItemTrait> GetTraits()
		{
			return null;
		}

		public void RemoveTrait(GameItemTrait trait)
		{
		}

		public void AddTrait<T>() where T : GameItemTrait
		{
		}

		public int GetTemperatureSpoilModifierPercentage(float temperature, StringBuilder details = null)
		{
			return 0;
		}

		protected string GetTraitsTooltipPart()
		{
			return null;
		}

		protected void AppendStoredInTooltipData(out StringBuilderPool.DisposableStringBuilder sb)
		{
			sb = null;
		}

		protected virtual void AppendUsedInTooltipData(out StringBuilderPool.DisposableStringBuilder sb)
		{
			sb = null;
		}

		public bool IsSpoilingEnabled(StringBuilder details = null)
		{
			return false;
		}

		public static bool IsSpoilingEnabledGlobal(StringBuilder details = null)
		{
			return false;
		}

		public GameItem()
		{
		}

		public GameItem(bool representsTemplate = false)
		{
		}

		public GameItem(GameItemTemplate template, bool representsTemplate = false)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		internal void ApplyBlueprintMaterial(Material newMaterial)
		{
		}

		internal string GetAnimationKeyOverride()
		{
			return null;
		}

		public static string GeneralizeVisualKey(string visualKey)
		{
			return null;
		}

		public void SetVisual(GameObject visual, GameObjectX gox)
		{
		}

		public void RemoveVisual()
		{
		}

		public void AddVisual(Transform where)
		{
		}

		private MethodInfo GetJsonHelperToObjectMethod()
		{
			return null;
		}

		public virtual GameItem CreateCopy()
		{
			return null;
		}

		public virtual void PlaceAtLocation(Vector3 position, Quaternion rotation, bool singleAccessPoint = false)
		{
		}

		public virtual TooltipData GetTooltipData(TooltipAlignment alignment = TooltipAlignment.Default)
		{
			return null;
		}

		public float GetFillLevel()
		{
			return 0f;
		}

		private void OnAmountChanged(AmountChangedEventArgs e)
		{
		}

		public static GameItem Merge(GameItem item1, GameItem item2)
		{
			return null;
		}

		public static GameItem CreateItemStack(GameItemTemplate template, bool representsTemplate = false)
		{
			return null;
		}

		internal void OnSpawn()
		{
		}

		public static void RaiseGameItemPurchasedEvent(object sender, GameItemTemplate template, int amount)
		{
		}

		public void SetFinalModel()
		{
		}
	}
}
