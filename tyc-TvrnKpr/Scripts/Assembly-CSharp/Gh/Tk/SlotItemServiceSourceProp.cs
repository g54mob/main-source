using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Replaceable))]
	[RequireComponent(typeof(ItemServiceSource))]
	public abstract class SlotItemServiceSourceProp : Prop, IAcceptedSlotItemKeyProvider
	{
		protected ItemServiceSource _service;

		protected Replaceable _replaceable;

		[Header("Item Source & Replaceable")]
		public string[] allowedTypes;

		public bool onlyAllowSingleItems;

		private bool _isInstalled;

		private readonly List<ContextMenuItem> _contextMenuItemsCache;

		public ItemServiceSource ServiceSource => null;

		public GameItemTemplate ItemTemplateSelected => null;

		public ShopItemTemplate ItemTemplateOnDisplay => null;

		public static event EventHandler ItemTemplateBeingServedChanged
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

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		protected override void OnInventoryChanged()
		{
		}

		private void UpdateVisualEvent(object sender, EventArgs e)
		{
		}

		public float GetRating(GameItemTemplate template, int amount, bool includePlaceholderItems = false)
		{
			return 0f;
		}

		protected abstract string GetNoItemConfiguredWarningText();

		private void UpdateVisual()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public override void PostBuiltInit()
		{
		}

		public override bool IsAllowedToAdvanceInQueue(Actor actor)
		{
			return false;
		}

		public void SetItemTemplateBeingServed(GameItemTemplate template)
		{
		}

		protected override void Dying()
		{
		}

		public override void OnDemolish()
		{
		}

		private GameItemTemplate[] GetPossibleItemTemplatesToSelect()
		{
			return null;
		}

		public IEnumerable<ContextMenuItem> GetSelectItemForServiceContextMenuItems(Action onItemExecutedCallback)
		{
			return null;
		}

		public override IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		public string GetAcceptedItemKey(int index)
		{
			return null;
		}

		public int GetSlotCount()
		{
			return 0;
		}
	}
}
