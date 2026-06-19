using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class VIPTourRouteConfig
	{
		[InspectorHeader("Tour")]
		[InspectorTooltip("Mininum Rooms in the tour schedule.  Number of rooms in the tour will be a random number between Min and Max. The tour will end once all rooms are viewed. If we can't find enough rooms, we will repeat. -1 means ignore")]
		public int MinRoomsInTour;

		[InspectorTooltip("Maximum Rooms in the tour schedule.  Number of rooms in the tour will be a random number between Min and Max. The tour will end once all rooms are viewed.  -1 means ignore")]
		public int MaxRoomsInTour;

		[InspectorTooltip("The visit will not return to the room that has previously been appraise")]
		public bool VisitRoomOnlyOnce;

		[InspectorTooltip("Tag used for appraisal interactions in the room")]
		public string AppraisalInteractionString;

		[InspectorTooltip("List of rooms types that are preferred.")]
		public List<RoomDefinition.Type> PreferredRoomList;

		[InspectorTooltip("List of rooms types that will not be entered.")]
		public List<RoomDefinition.Type> ExcludedRoomList;

		[InspectorTooltip("The VIP will only visit preferred rooms during the tour")]
		public bool OnlyVisitPreferredRooms;

		[InspectorTooltip("The probability of selecting a preferred room for the tour route [0 - 1].  NB: it will never select an excluded room type.")]
		public float ProbabiltiyPreferredRoom;
	}
}
