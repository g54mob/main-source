namespace Restory.Constants
{
	public static class ZenjectConstants
	{
		public static class ContractNames
		{
			public const string MainScene = "MainScene";

			public const string LoadingScreen = "LoadingScreen";
		}

		public static class GUI
		{
			public static class ConfirmationDialogue
			{
				public const string QuitExpeditionGameMode = "QuitExpeditionGameModeDialogueWindow";

				public const string CommonId = "CommonDialogueWindow";

				public const string CoreGameplayId = "CoreGameplayDialogueWindow";

				public const string PauseMenu = "PauseMenuDialogueWindow";

				public const string MainMenuId = "MainMenuWindow";
			}

			public static class FadeScreen
			{
				public const string BlackFadeScreenId = "BlackFadeScreen";
			}
		}

		public static class UI
		{
			public static class Toolkit
			{
				public static class Notepad
				{
					public const string ElementTemplate = "NotepadElementTemplate";
				}

				public const string GameplayOverlayDocument = "GameplayOverlayUIDocument";
			}
		}

		public static class TextureMask
		{
			public const string TextureMaskComputeShader = "TextureMaskComputeShader";

			public const string MeshUVRasterizerShader = "MeshUVRasterizerShader";

			public const string DefaultMaskPreset = "DefaultMaskPreset";
		}

		public static class Character
		{
			public const string Inventory = "Inventory";
		}

		public static class Npc
		{
			public const string Librarian = "Librarian";

			public const string Policeman = "Policeman";
		}

		public static class BindPriority
		{
			public const int StaticGameObjectsRegistry = -1;
		}

		public static class GameObjects
		{
			public const string UserReportId = "UserReportGameObject";
		}

		public static class InitializationOrder
		{
			public const int ObjectPoolPrewarmStarter = -100;

			public const int ArticyEntitiesWrapper = 10;

			public const int GUI_LibraryPanel = 50;

			public const int GUI_DialogueNpcCanvas = 100;

			public const int GUI_DialoguePlayerCanvas = 101;
		}

		public const string MainCanvasTransformId = "GameplayOverlayCanvas";

		public const string PauseCanvasTransformId = "PauseOverlayCanvas";

		public const string DialoguePanelsCanvasTransformId = "DialoguePanelsCanvas";

		public const string CommonMarkersCanvasTransformId = "MarkersCanvas";

		public const string MinionMarkersCanvasTransformId = "MinionMarkersCanvas";

		public const string BuildingPopoversCanvasTransformId = "BuildingPopoversCanvas";

		public const string PlayerPopoversCanvasTransformId = "PlayerPopoversCanvas";

		public const string TooltipsCanvasTransformId = "TooltipsCanvas";

		public const string ErrorsCanvasTransformId = "ErrorsCanvas";

		public const string GameWorldTutorialIconsCanvasTransformId = "GameWorldTutorialIconsCanvas";

		public const string PlayerTransformId = "playerTransform";

		public const string FreeCamera = "FreeCamera";

		public const string MainCamera = "MainCamera";

		public const string GameCamera = "GameCamera";

		public const string ElementsShop = "ElementsShop";

		public const string DeviceShop = "DeviceShop";

		public const string DecorsShop = "DecorsShop";

		public const string LoadingSceneId = "LoadingSceneId";

		public const string BlackLoadingSceneId = "BlackLoadingSceneId";

		public const string BicycleLoadingSceneId = "BicycleLoadingSceneId";

		public const string PlayerInputId = "PlayerInputId";

		public const string OperatorInputId = "OperatorInputId";

		public const string DeviceSpotLightTimeView = "DeviceSpotLightTimeView";

		public const string AmbientLightTimeView = "AmbientLightTimeView";

		public const string TableLampLightTimeView = "TableLampLightTimeView";
	}
}
