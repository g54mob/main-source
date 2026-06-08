using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Item", menuName = "Kitchen/Item")]
	public class Item : GameDataObject, IHasPrefab
	{
		[Serializable]
		public struct ItemProcess
		{
			public Process Process;

			public Item Result;

			public float Duration;

			public bool IsBad;

			public bool RequiresWrapper;
		}

		public GameObject Prefab;

		[SerializeField]
		private List<ItemProcess> Processes;

		[NonSerialized]
		public List<ItemProcess> DerivedProcesses;

		public ItemProcess AutomaticItemProcess;

		public List<IItemProperty> Properties;

		public bool RequiresCleaning;

		public float ExtraTimeGranted;

		public Factor EatingTime;

		public ItemValue ItemValue = ItemValue.Small;

		[HideInInspector]
		public int Reward = 1;

		public Item DirtiesTo;

		public bool IsConsumedByCustomer;

		public List<Item> MayRequestExtraItems;

		public int MaxOrderSharers;

		public int AlwaysOrderAdditionalItem;

		public bool AutoSatisfied;

		public int RepeatOrderMin;

		public int RepeatOrderMax;

		public bool CanBeOrderedPiecemeal;

		public List<Item> SatisfiedBy;

		public List<Item> NeedsIngredients;

		public Item SplitSubItem;

		public int SplitCount;

		public float SplitSpeed = 1f;

		public List<Item> SplitDepletedItems;

		public bool AllowSplitMerging;

		public bool PreventExplicitSplit;

		public bool SplitByComponents;

		public Item SplitByComponentsHolder;

		public Item SplitByComponentsWrapper;

		public bool SplitByCopying;

		public Item RefuseSplitWith;

		public bool HasImplicitlyModifiedComponents;

		public Item DisposesTo;

		public bool IsIndisposable;

		public bool IsSinkDisposable;

		public ItemCategory ItemCategory;

		public ItemStorage ItemStorageFlags;

		public Appliance DedicatedProvider;

		public ToolAttachPoint HoldPose;

		public bool IsMergeableSide;

		public Dish CreditSourceDish;

		public Item ExtendedDirtItem;

		private static HashSet<string> SeenProcesses = new HashSet<string>();

		GameObject IHasPrefab.Prefab => Prefab;

		public bool IsSplittable
		{
			get
			{
				if (!(SplitSubItem != null))
				{
					return SplitByComponents;
				}
				return true;
			}
		}

		protected override void InitialiseDefaults()
		{
			DerivedProcesses = new List<ItemProcess>();
			Properties = new List<IItemProperty>();
			SplitDepletedItems = new List<Item>();
		}

		public override void SetupForGame()
		{
			if (Processes == null)
			{
				Processes = new List<ItemProcess>();
			}
			if (Properties == null)
			{
				Properties = new List<IItemProperty>();
			}
			if (SplitDepletedItems == null)
			{
				SplitDepletedItems = new List<Item>();
			}
			DerivedProcesses = new List<ItemProcess>(Processes);
			Reward = ItemValue switch
			{
				ItemValue.None => 0, 
				ItemValue.Small => 3, 
				ItemValue.Medium => 5, 
				ItemValue.MediumLarge => 6, 
				ItemValue.Large => 8, 
				ItemValue.ExtraLarge => 10, 
				ItemValue.SideSmall => 1, 
				ItemValue.SideMedium => 2, 
				ItemValue.SideLarge => 3, 
				_ => 1, 
			};
		}

		protected virtual bool ShowItemSpecifics()
		{
			return true;
		}

		public static string GetIconSet(Item item)
		{
			List<ItemProcess> derivedProcesses = item.DerivedProcesses;
			StringBuilder stringBuilder = new StringBuilder(derivedProcesses.Count);
			SeenProcesses.Clear();
			if (item.SplitSubItem != null)
			{
				stringBuilder.Append("<sprite name=\"split\">");
				SeenProcesses.Add("<sprite name=\"split\">");
			}
			foreach (ItemProcess item2 in derivedProcesses)
			{
				if (!item2.RequiresWrapper && !item2.IsBad && !SeenProcesses.Contains(item2.Process.Icon))
				{
					SeenProcesses.Add(item2.Process.Icon);
					stringBuilder.Append(item2.Process.Icon);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
