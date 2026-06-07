using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class InspectBehaviour : ActorBehaviour
	{
		[PersistenceOptIn]
		private int _targetStars;

		[PersistenceOptIn]
		private List<string> _zonesToCheck;

		[PersistenceOptIn]
		private List<string> _zonesMissing;

		[PersistenceOptIn]
		private Dictionary<string, List<string>> _zonesAndPropsFound;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private List<Room> _roomsInspected;

		[PersistenceOptIn]
		private string _currentZoneInspecting;

		[PersistenceOptIn]
		private bool _hasWaitedTooLong;

		[PersistenceOptIn]
		private bool _hadDrink;

		[PersistenceOptIn]
		private bool _hadMeal;

		[PersistenceOptIn]
		public List<Tuple<float, string>> inspectionFeedback;

		[PersistenceOptIn]
		private int _maxGoldCost;

		[PersistenceOptIn]
		private int _minGoldCost;

		[PersistenceOptIn]
		private int _processingFeeBoundry;

		[PersistenceOptIn]
		private bool _isInspectionFinalized;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Actor_ConsumeItem(object sender, Actor.ActorEventArgs<Ingredient> e)
		{
		}

		protected InspectBehaviour()
		{
		}

		public InspectBehaviour(Actor owner)
		{
		}

		public override void Init()
		{
		}

		public bool HasRoomBeenInspected(Room room)
		{
			return false;
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override bool IsTreshholdReached()
		{
			return false;
		}

		public IEnumerable<Room> GetRoomsLeftToInspect(string zone)
		{
			return null;
		}

		public void RoomInspectionFinished(Room room)
		{
		}

		public bool HasZoneMetRequirements(string zone)
		{
			return false;
		}

		public void PropFound(string zone, string prefabTypeIdentifier)
		{
		}

		public void RateDirt()
		{
		}

		public void WaitedTooLong()
		{
		}

		protected void OnConsumeItem(Ingredient item)
		{
		}

		public void AddGoldFine(float goldFine, string feedbackKey)
		{
		}

		public bool IsCostBribe(int goldCost)
		{
			return false;
		}

		public int GetFinalGoldCost()
		{
			return 0;
		}

		public string GetAllFeedback()
		{
			return null;
		}

		public void FinalizeInspection()
		{
		}

		public bool HasTavernPassedInspection()
		{
			return false;
		}
	}
}
