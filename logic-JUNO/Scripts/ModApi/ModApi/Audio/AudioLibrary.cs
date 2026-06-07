namespace ModApi.Audio
{
	public static class AudioLibrary
	{
		public static class Career
		{
			public static readonly AudioFile CompleteLandmark = CreateUiSound("CareerLandmark");

			public static readonly AudioFile CompleteMilestone = CreateUiSound("CareerMilestone");

			public static readonly AudioFile ContractAccept = CreateUiSound("ContractAccept");

			public static readonly AudioFile ContractCancel = CreateUiSound("ContractCancel");

			public static readonly AudioFile ContractComplete = CreateUiSound("ContractComplete");

			public static readonly AudioFile ContractFail = CreateUiSound("ContractFail");
		}

		public static class Design
		{
			public static readonly AudioFile AddPart = CreateUiSound("DesignerAddPart");

			public static readonly AudioFile ConnectPart = CreateUiSound("DesignerConnectPart");

			public static readonly AudioFile DeletePart = CreateUiSound("DesignerDeletePart");

			public static readonly AudioFile DisconnectPart = CreateUiSound("DesignerDisconnectPart");

			public static readonly AudioFile DropPart = CreateUiSound("DesignerDropPart");

			public static readonly AudioFile GizmoFlyout = CreateUiSound("DesignerGizmoFlyout", 0.35f);

			public static readonly AudioFile ResizeSampleLooped = CreateUiSound("DesignerResizeSampleLooped", 0.35f);

			public static readonly AudioFile SelectPart = CreateUiSound("DesignerSelectPart");

			public static readonly AudioFile SprayPaint = CreateUiSound("DesignerSprayPaint");

			public static readonly AudioFile StagingDragPart = CreateUiSound("DesignerStagingDragPart");

			public static readonly AudioFile StagingDragStage = CreateUiSound("DesignerStagingDragStage");

			public static readonly AudioFile StagingDropPart = CreateUiSound("DesignerStagingDropPart");

			public static readonly AudioFile StagingDropStage = CreateUiSound("DesignerStagingDropStage");

			public static readonly AudioFile SuggestConnection = CreateUiSound("DesignerSuggestConnection");

			public static readonly AudioFile TutorialStep = CreateUiSound("DesignerTutorialStep");
		}

		public static class Flight
		{
			public static readonly AudioFile DisconnectPart = CreateSound("FlightDisconnectPart");

			public static readonly AudioFile DockConnect = CreateSound("DockConnect");

			public static readonly AudioFile DockDisconnect = CreateSound("DockDisconnect");

			public static readonly AudioFile EvaCollision = CreateSound("GRUNT_Male_B_Hurt_Short_08_mono", 1f, 2f, 50f);

			public static readonly AudioFile EvaJetpack = CreateSound("RCSNozzle", 0.02f, 2f, 50f);

			public static readonly AudioFile FairingSeparation = CreateSound("FairingSeparation");

			public static readonly AudioFile Interstage = CreateSound("Detacher");

			public static readonly AudioFile LandingGearLocked = CreateSound("LandingGearLocked", 1f, 10f, 500f);

			public static readonly AudioFile MetalCollisionConcrete = CreateSound("MetalCollisionConcrete");

			public static readonly AudioFile NavSphereMoved = CreateSound("NavSphereMoved");

			public static readonly AudioFile NavSpherePressed = CreateSound("NavSpherePressed");

			public static readonly AudioFile NavSphereReleased = CreateSound("NavSphereReleased");

			public static readonly AudioFile ParachuteDeployed = CreateSound("Parachute");

			public static readonly AudioFile PartCollisionGround = CreateSound("FlightPartCollisionGround");

			public static readonly AudioFile Swimming = CreateSound("WaterSwim", 1f, 2f, 50f);

			public static readonly AudioFile ThrottleDecreaseClick = CreateSound("ThrottleDecreaseClick");

			public static readonly AudioFile ThrottleIncreaseClick = CreateSound("ThrottleIncreaseClick");
		}

		public static class Purchase
		{
			public static readonly AudioFile SelectBundle = CreateSound("PurchaseSelectBundle");

			public static readonly AudioFile OpenBundle = CreateSound("PurchaseOpenBundle");
		}

		public static class Vizzy
		{
			public static readonly AudioFile Beep = CreateSound("VizzyBeep");

			public static readonly AudioFile ConnectNode = CreateUiSound("VizzyConnect");

			public static readonly AudioFile DeleteNode = CreateUiSound("VizzyDelete");

			public static readonly AudioFile DisconnectNode = CreateUiSound("VizzyDisconnect");

			public static readonly AudioFile DropNode = CreateUiSound("VizzyDrop");

			public static readonly AudioFile SuggestConnection = CreateUiSound("VizzySuggest");
		}

		public static readonly AudioFile ButtonClicked = CreateUiSound("ButtonClicked");

		public static readonly AudioFile LevelFail = CreateUiSound("LevelFail");

		public static readonly AudioFile LevelSuccess = CreateUiSound("LevelSuccess");

		private static AudioFile CreateSound(string sound, float defaultVolume = 1f, float minDistance = 250f, float maxDistance = 1500f)
		{
			return new AudioFile("Audio/Sounds/" + sound)
			{
				DefaultVolume = defaultVolume,
				MinDistance = minDistance,
				MaxDistance = maxDistance
			};
		}

		private static AudioFile CreateUiSound(string sound, float defaultVolume = 0f)
		{
			return new AudioFile("Audio/Sounds/" + sound)
			{
				DefaultVolume = 1f
			};
		}
	}
}
