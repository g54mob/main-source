using CTS.BBT;
using CTS.Core.Utilities;
using CTS.Furnitures;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class FurnitureSlot : MonoBehaviour
	{
		[SerializeField]
		[Foldout("Technical parameters")]
		private BoxCollider _collider;

		[SerializeField]
		[Foldout("Technical parameters")]
		private LayerMask _possibleOverlapsLayerMask;

		[SerializeField]
		private GameObject _gridFurniturePlacementVFX;

		[field: SerializeField]
		[field: UniqueFlag(true)]
		public EFurnitureTags CompatibleTags { get; private set; }

		[field: SerializeField]
		[field: ReadOnly]
		public bool IsActiveAndFree { get; private set; } = true;

		internal FurnitureController FurnitureController { get; private set; }

		internal RoomBuilding CurrentRoom => FurnitureController.Furniture.RoomObject.CurrentRoom;

		internal FurnitureController SlotedFurniture { get; private set; }

		private void Awake()
		{
			FurnitureController = GetComponentInParent<FurnitureController>();
			_gridFurniturePlacementVFX.SetActive(value: false);
		}

		private void Start()
		{
			CheckSlotOverlap();
		}

		private void OnEnable()
		{
			FurnitureController.StaticFurniturePlaced += OnPlacingFurniture;
			FurnitureController.FurniturePickedUp += OnAnyFurniturePickedUp;
			FurniturePlacer.FurniturePickedUp += OnFurniturePlacementCancelled;
		}

		private void OnDisable()
		{
			FurnitureController.StaticFurniturePlaced -= OnPlacingFurniture;
			FurnitureController.FurniturePickedUp -= OnAnyFurniturePickedUp;
			FurniturePlacer.FurniturePickedUp -= OnFurniturePlacementCancelled;
		}

		private bool IsCloseEnoughTo(Vector3 position)
		{
			if ((position - base.transform.position).sqrMagnitude > 25f)
			{
				return false;
			}
			return true;
		}

		private void OnAnyFurniturePickedUp(FurnitureController furniture)
		{
			if (IsCloseEnoughTo(furniture.PreviousPlacedPosition))
			{
				CheckSlotOverlap();
			}
			if ((bool)furniture && furniture.Furniture.Parameters.Tags.HasFlagNonAlloc(CompatibleTags))
			{
				_gridFurniturePlacementVFX.SetActive(IsActiveAndFree);
			}
			else
			{
				_gridFurniturePlacementVFX.SetActive(value: false);
			}
		}

		private void OnFurniturePlacementCancelled(Furniture obj)
		{
			if ((object)obj == null)
			{
				_gridFurniturePlacementVFX.SetActive(value: false);
			}
		}

		private void OnPlacingFurniture(FurnitureController furniture)
		{
			if (IsCloseEnoughTo(furniture.transform.position))
			{
				CheckSlotOverlap();
			}
			_gridFurniturePlacementVFX.SetActive(value: false);
		}

		public void CheckSlotOverlap()
		{
			Collider[] array = PhysicsAllocation.Get(10);
			int num = _collider.OverlapNonAlloc(array, _possibleOverlapsLayerMask, QueryTriggerInteraction.Collide);
			if ((bool)SlotedFurniture && SlotedFurniture.IsPlaced)
			{
				IsActiveAndFree = false;
				return;
			}
			IsActiveAndFree = true;
			if (num <= 0)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Collider collider = array[i];
				FurnitureController component = collider.GetComponent<FurnitureController>();
				if (!component)
				{
					component = collider.transform.parent.GetComponent<FurnitureController>();
				}
				if ((bool)component)
				{
					if (component.IsPlaced && !component.Furniture.Parameters.Tags.HasFlagNonAlloc(EFurnitureTags.Rug) && component != FurnitureController)
					{
						IsActiveAndFree = false;
						break;
					}
					continue;
				}
				IsActiveAndFree = false;
				break;
			}
		}

		internal void SetSlotedFurniture(FurnitureController p_slotedFurniture)
		{
			SlotedFurniture = p_slotedFurniture;
			IsActiveAndFree = !SlotedFurniture;
		}
	}
}
