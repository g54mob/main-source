using System;
using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class SaveClass_Furnitures : ISaveClass
	{
		[Serializable]
		public class FurnitureState
		{
			public int gameID;

			public int modelUID;

			public Vector2 position;

			public Vector3 actualPosition;

			public EFurnitureOrientation orientation;

			public FurnitureState(Furniture furniture)
			{
				gameID = furniture.GameID;
				modelUID = furniture.UID;
				actualPosition = furniture.Position;
				orientation = furniture.Orientation;
			}

			public FurnitureState(FurnitureState furnitureState)
			{
				gameID = furnitureState.gameID;
				modelUID = furnitureState.modelUID;
				position = furnitureState.position;
				actualPosition = furnitureState.actualPosition;
				orientation = furnitureState.orientation;
			}

			public Vector3 GetPosition()
			{
				if (actualPosition == Vector3.zero)
				{
					return new Vector3(position.x, 0f, position.y);
				}
				return actualPosition;
			}
		}

		[Serializable]
		public class ShelfState : FurnitureState
		{
			[Serializable]
			public struct ShelfStackState
			{
				public int productUID;

				public int quantity;

				public EShelfLabelState labelState;
			}

			public List<ShelfStackState> shelfStacks;

			public ShelfState(Shelf shelf)
				: base(shelf)
			{
				shelfStacks = new List<ShelfStackState>();
				foreach (ShelfInteractable allShelfInteractable in shelf.GetAllShelfInteractables())
				{
					int actualCount = allShelfInteractable.Stack.ActualCount;
					if (actualCount > 0)
					{
						shelfStacks.Add(new ShelfStackState
						{
							productUID = allShelfInteractable.CurrentProduct.UID,
							quantity = actualCount,
							labelState = allShelfInteractable.Label.State
						});
					}
					else
					{
						shelfStacks.Add(new ShelfStackState
						{
							productUID = 0,
							quantity = 0,
							labelState = allShelfInteractable.Label.State
						});
					}
				}
			}
		}

		[Serializable]
		public class ReserveShelfState : FurnitureState
		{
			[Serializable]
			public struct ReserveShelfInteractableState
			{
				public StackableBoxSaveState boxState;
			}

			public List<ReserveShelfInteractableState> shelfInteractables;

			public ReserveShelfState(ReserveShelf shelf)
				: base(shelf)
			{
				shelfInteractables = new List<ReserveShelfInteractableState>();
				foreach (ReserveShelfInteractable allShelfInteractable in shelf.GetAllShelfInteractables())
				{
					if (allShelfInteractable.Box != null)
					{
						shelfInteractables.Add(new ReserveShelfInteractableState
						{
							boxState = (allShelfInteractable.Box.GetSaveState() as StackableBoxSaveState)
						});
					}
					else
					{
						shelfInteractables.Add(new ReserveShelfInteractableState
						{
							boxState = null
						});
					}
				}
			}
		}

		[Serializable]
		public class CashRegisterState : FurnitureState
		{
			public List<BoughtProductInfo> productsToCheckout;

			public EPaymentMethod paymentMethod;

			public CashRegisterState(CashRegister cashRegister)
				: base(cashRegister)
			{
				productsToCheckout = new List<BoughtProductInfo>();
				foreach (BoughtProductInfo checkoutProduct in cashRegister.Workshop.GetCheckoutProducts())
				{
					productsToCheckout.Add(checkoutProduct);
				}
				paymentMethod = cashRegister.Workshop.PaymentMethod;
			}
		}

		public List<FurnitureState> baseFurnitures;

		public List<ShelfState> shelves;

		public List<ReserveShelfState> reserveShelves;

		public List<CashRegisterState> cashRegisters;

		public SaveClass_Furnitures()
		{
			baseFurnitures = new List<FurnitureState>();
			foreach (FurnitureState defaultFurniture in FurnitureSettings.DefaultFurnitures)
			{
				baseFurnitures.Add(new FurnitureState(defaultFurniture));
			}
			shelves = new List<ShelfState>();
			reserveShelves = new List<ReserveShelfState>();
			cashRegisters = new List<CashRegisterState>();
		}

		public void StartSaveProcess()
		{
			baseFurnitures = new List<FurnitureState>();
			shelves = new List<ShelfState>();
			reserveShelves = new List<ReserveShelfState>();
			cashRegisters = new List<CashRegisterState>();
		}

		public void SaveFurniture(FurnitureState state)
		{
			baseFurnitures.Add(state);
		}

		public void SaveFurniture(ShelfState state)
		{
			shelves.Add(state);
		}

		public void SaveFurniture(ReserveShelfState state)
		{
			reserveShelves.Add(state);
		}

		public void SaveFurniture(CashRegisterState state)
		{
			cashRegisters.Add(state);
		}

		public IEnumerable<FurnitureState> GetSavedFurnitures()
		{
			if (baseFurnitures.IsValid())
			{
				foreach (FurnitureState baseFurniture in baseFurnitures)
				{
					yield return baseFurniture;
				}
			}
			if (shelves.IsValid())
			{
				foreach (ShelfState shelf in shelves)
				{
					yield return shelf;
				}
			}
			if (reserveShelves.IsValid())
			{
				foreach (ReserveShelfState reserveShelf in reserveShelves)
				{
					yield return reserveShelf;
				}
			}
			if (!cashRegisters.IsValid())
			{
				yield break;
			}
			foreach (CashRegisterState cashRegister in cashRegisters)
			{
				yield return cashRegister;
			}
		}
	}
}
