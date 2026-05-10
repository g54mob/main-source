using System;
using System.Linq;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.DevConsole.Variables;
using CTS.Furnitures;
using UnityEngine;

namespace CTS.BBT
{
	[Constructor("Construct")]
	public class Furniture : CTSBehaviour
	{
		[SerializeField]
		private SelectionModes _selectionCallbacksModes;

		private int _tmpValue;

		private static CVarFloatRangeReference CVarSellRatio;

		[field: SerializeField]
		[field: Inject(false)]
		public FurnitureController Controller { get; private set; }

		[field: SerializeField]
		[field: Inject(false)]
		public FurnitureBounds Bounds { get; private set; }

		[field: SerializeField]
		[field: Inject(false)]
		internal FurnitureInteractor Interactor { get; private set; }

		[field: SerializeField]
		[field: Tooltip("Should be auto-assigned when creating the ScriptableObject via right click Create > BBT > Create FurnitureSO From Prefab")]
		public FurnitureSO Parameters { get; private set; }

		[field: SerializeField]
		public FurnitureSlot[] Slots { get; private set; }

		public int SlotsUsedAmount
		{
			get
			{
				int num = 0;
				FurnitureSlot[] slots = Slots;
				for (int i = 0; i < slots.Length; i++)
				{
					if ((bool)slots[i].SlotedFurniture)
					{
						num++;
					}
				}
				return num;
			}
		}

		[field: SerializeField]
		public bool Purchased { get; private set; }

		[field: Inject(false)]
		public SelectableObject SelectableObject { get; set; }

		[field: Inject(false)]
		public OutlineRendererCollection OutlineRenderers { get; set; }

		[field: Inject(false)]
		public BarVisualObject BarVisualObject { get; private set; }

		[field: SerializeField]
		public RoomObject RoomObject { get; private set; }

		private static float PreviousFrameTotalFurnitureValueInBar { get; set; }

		public event Action Moved;

		public event Action OnFurnitureSold;

		public event Action OnFurnitureDestroyed;

		public static event Func<Currencies, int, int> BuyingFurniture;

		public static event Action<Furniture> FurnitureAdded;

		public static event Action<Furniture> FurniturePlaced;

		public static event Action<Furniture> FurnitureRemoved;

		public static event Action<Furniture> FurnitureBought;

		public static event Action<Furniture> FurnitureSold;

		public static event Action<Furniture> FurnitureDestroyed;

		public static event Action<float> FurnituresValueInBarChanged;

		public void SetFurnitureSO(FurnitureSO p_furnitureSO)
		{
			Parameters = p_furnitureSO;
			Controller.SetupSelectableObject();
		}

		private void Construct([InjectScope(EGetScope.Children)] FurnitureSlot[] slots)
		{
			Slots = slots;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			if ((object)CVarSellRatio == null)
			{
				CVarSellRatio = ConsoleVar.GetVariable<CVarFloatRangeReference>("FurnitureSellRatio");
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Controller.FurniturePlaced += OnFurniturePlaced;
			FurnitureBought += AddFurniture;
			RoomObject.CurrentRoomUpdated += OnCurrentRoomUpdated;
			RoomObject.CurrentRoomChanged += OnCurrentRoomChanged;
			RoomObject.RoomLost += OnRoomLost;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Controller.FurniturePlaced -= OnFurniturePlaced;
			FurnitureBought -= AddFurniture;
			RoomObject.CurrentRoomUpdated -= OnCurrentRoomUpdated;
			RoomObject.CurrentRoomChanged -= OnCurrentRoomChanged;
			RoomObject.RoomLost -= OnRoomLost;
			RemoveFurniture(this);
		}

		private void OnDestroy()
		{
			this.OnFurnitureDestroyed?.Invoke();
			Furniture.FurnitureDestroyed?.Invoke(this);
		}

		private void OnFurniturePlaced(bool buyIt)
		{
			RoomObject.TryFindCurrentRoom();
			Furniture.FurniturePlaced?.Invoke(this);
			if (buyIt)
			{
				BuyFurniture();
			}
			else
			{
				MarkAsBought();
			}
		}

		public void BuyFurniture()
		{
			if (!Purchased)
			{
				_tmpValue = Parameters.PurchasePrice;
				Furniture.BuyingFurniture?.Invoke(Currencies.Dollars, -_tmpValue);
				MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Expense, _tmpValue, TransactionTag.Furniture);
				Purchased = true;
				Furniture.FurnitureBought?.Invoke(this);
			}
		}

		public void MarkAsBought()
		{
			if (!Purchased)
			{
				Purchased = true;
				Controller.SetupFurnitureInPlace();
				Furniture.FurnitureBought?.Invoke(this);
			}
		}

		public void SellFurniture()
		{
			if (!Purchased)
			{
				return;
			}
			Purchased = false;
			_tmpValue = GetResellPrice();
			FurnitureSlot[] slots = Slots;
			for (int i = 0; i < slots.Length; i++)
			{
				FurnitureController slotedFurniture = slots[i].SlotedFurniture;
				if ((bool)slotedFurniture)
				{
					slotedFurniture.LeaveSlot();
					slotedFurniture.Furniture.SellFurniture();
				}
			}
			Furniture.BuyingFurniture?.Invoke(Currencies.Dollars, _tmpValue);
			if (MonoSingleton<TransactionsHandlers>.TryGetInstance(out var outInstance))
			{
				outInstance.AddNewData(TransactionType.Income, _tmpValue, TransactionTag.OtherSale);
			}
			Furniture.FurnitureSold?.Invoke(this);
			RemoveFurniture(this);
			this.OnFurnitureSold?.Invoke();
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public int GetResellPrice()
		{
			return Mathf.RoundToInt((float)Parameters.PurchasePrice * (float)CVarSellRatio);
		}

		public int GetResellPriceWithSlots()
		{
			int num = 0;
			FurnitureSlot[] slots = Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot && (bool)furnitureSlot.SlotedFurniture)
				{
					num += furnitureSlot.SlotedFurniture.Furniture.GetResellPriceWithSlots();
				}
			}
			return num + GetResellPrice();
		}

		public FurnitureSlot GetClosestFreeSlot(Vector3 position)
		{
			FurnitureSlot furnitureSlot = (from x in Slots
				where x.IsActiveAndFree
				orderby Vector3.Distance(position, x.transform.position)
				select x).ToList().FirstOrDefault();
			if (!furnitureSlot && (bool)Controller.CurrentSlot)
			{
				furnitureSlot = Controller.CurrentSlot.FurnitureController.Furniture.GetClosestFreeSlot(position);
			}
			return furnitureSlot;
		}

		public FurnitureSlot GetClosestAvailableSlot(Vector3 position, Furniture furniture)
		{
			foreach (FurnitureSlot item in from x in Slots
				where x.IsActiveAndFree
				orderby Vector3.Distance(position, x.transform.position)
				select x)
			{
				if (furniture.Bounds.CouldBePlaced(item))
				{
					return item;
				}
			}
			if ((bool)Controller.CurrentSlot)
			{
				return Controller.CurrentSlot.FurnitureController.Furniture.GetClosestAvailableSlot(position, furniture);
			}
			return null;
		}

		public void Move(Vector3 newPosition)
		{
			base.transform.position = newPosition;
			Bounds.CheckIntersections();
			RoomObject.TryFindCurrentRoom();
			this.Moved?.Invoke();
		}

		private void OnCurrentRoomUpdated()
		{
			if (Controller.IsPlaced && !HasValidRoomPlacement(onlyCheckWalls: true))
			{
				SellFurniture();
			}
		}

		private void OnCurrentRoomChanged()
		{
			if (Controller.IsPlaced && !HasValidRoomPlacement(onlyCheckWalls: false))
			{
				SellFurniture();
			}
		}

		public bool HasValidRoomPlacement(bool onlyCheckWalls)
		{
			int num;
			if (onlyCheckWalls)
			{
				num = -1;
				num &= ~(1 << LayerMask.NameToLayer("Wall"));
			}
			else
			{
				num = 1 << LayerMask.NameToLayer("Item");
			}
			if (Bounds.IncorectPlacement(num))
			{
				return false;
			}
			if (!FurniturePlacer.CanBePlaceOnCurrentRoom(this))
			{
				return false;
			}
			return true;
		}

		private void OnRoomLost()
		{
			if (base.gameObject.scene.isLoaded)
			{
				SellFurniture();
			}
		}

		private static void AddFurniture(Furniture p_furniture)
		{
			CTSSingleton<LevelParameters>.Instance.Furnitures.AddFurniture(p_furniture);
			if (!StaticObjectSet<Furniture>.Contains(p_furniture))
			{
				StaticObjectSet<Furniture>.Add(p_furniture);
				Furniture.FurnitureAdded?.Invoke(p_furniture);
				if (p_furniture.Parameters.PurchasePrice > 0)
				{
					Furniture.FurnituresValueInBarChanged?.Invoke(p_furniture.Parameters.PrestigeValue);
				}
			}
		}

		private static void RemoveFurniture(Furniture p_furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists())
			{
				CTSSingleton<LevelParameters>.Instance.Furnitures.RemoveFurniture(p_furniture);
			}
			if (StaticObjectSet<Furniture>.Contains(p_furniture))
			{
				StaticObjectSet<Furniture>.Remove(p_furniture);
				Furniture.FurnitureRemoved?.Invoke(p_furniture);
				if (p_furniture.Parameters.PurchasePrice > 0)
				{
					Furniture.FurnituresValueInBarChanged?.Invoke(0f - p_furniture.Parameters.PrestigeValue);
				}
			}
		}
	}
}
