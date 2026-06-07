using Brewery.Map;
using Brewery.NPC.Data;
using UnityEngine;

namespace Property
{
	public class House : MonoBehaviour
	{
		[Header("Configuration")]
		[Tooltip("The role of this house determines how it's used")]
		[SerializeField]
		private HouseRole role;

		[Tooltip("Unique identifier for this house (auto-generated from GO name if empty)")]
		[SerializeField]
		private string houseId;

		[Header("For Clerk/Local Houses")]
		[Tooltip("The NPC that lives here. Only set for Clerk and Local houses.")]
		[SerializeField]
		private NPCProfile assignedNPC;

		[Header("For ForSale Houses")]
		[Tooltip("House data for purchase/sale. Only set for ForSale houses.")]
		[SerializeField]
		private HouseData houseData;

		[Header("References")]
		[Tooltip("Where NPCs spawn. Auto-detected from child named 'SpawnPoint' if not assigned.")]
		[SerializeField]
		private Transform spawnPoint;

		[Tooltip("Where NPCs idle at home. Optional.")]
		[SerializeField]
		private Transform idleAnchor;

		[Tooltip("The for-sale sign. Auto-detected from children if not assigned.")]
		[SerializeField]
		private PlotForSaleSignInteractable forSaleSign;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NPCProfile runtimeOccupant;

		private HouseHoverProvider hoverProvider;

		private static House[] cachedHouses;

		public HouseRole Role => default(HouseRole);

		public string HouseId => null;

		public NPCProfile AssignedNPC => null;

		public HouseData HouseData => null;

		public Transform SpawnPoint => null;

		public Transform IdleAnchor => null;

		public PlotForSaleSignInteractable ForSaleSign => null;

		public bool HasOccupant => false;

		public bool IsOccupiedByVisitor => false;

		private void Awake()
		{
		}

		private void OnValidate()
		{
		}

		private void ValidateConfiguration()
		{
		}

		public void AssignVisitorAsOccupant(NPCProfile visitorProfile)
		{
		}

		public void ClearOccupant()
		{
		}

		public Vector3 GetSpawnPosition()
		{
			return default(Vector3);
		}

		public Quaternion GetSpawnRotation()
		{
			return default(Quaternion);
		}

		public static House[] GetAllHouses()
		{
			return null;
		}

		public static House FindByHouseId(string id)
		{
			return null;
		}

		public static House FindByHouseDataId(string houseDataId)
		{
			return null;
		}

		public static House FindByAssignedNpcId(string npcId)
		{
			return null;
		}

		public static House[] GetHousesByRole(HouseRole role)
		{
			return null;
		}

		public static void ClearCache()
		{
		}
	}
}
