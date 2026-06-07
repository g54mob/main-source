using System;
using Assets.Packages.DevConsole;
using Assets.Scripts.State;
using ModApi.CelestialData;
using ModApi.Common.Events;
using ModApi.PlanetStudio;
using ModApi.State;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetStudioScript : PlanetStudioBase
	{
		[SerializeField]
		private CelestialBodyDesignerScript _celestialBodyDesigner;

		[SerializeField]
		private AudioListener _celestialBodyDesignerAudioListener;

		[SerializeField]
		private Camera _initialCamera;

		[SerializeField]
		private PlanetarySystemDesignerScript _planetarySystemDesigner;

		[SerializeField]
		private PlanetStudioUIScript _planetStudioUI;

		public static CelestialFile AutoLoadedCelestialBody { get; internal set; }

		public static CelestialFile AutoLoadedPlanetarySystem { get; internal set; }

		public new static PlanetStudioScript Instance { get; private set; }

		public override ICelestialBodyDesigner CelestialBodyDesigner => _celestialBodyDesigner;

		public CelestialBodyDesignerScript CelestialBodyDesignerScript => _celestialBodyDesigner;

		public override IPlanetarySystemDesigner PlanetarySystemDesigner => _planetarySystemDesigner;

		public PlanetarySystemDesignerScript PlanetarySystemDesignerScript => _planetarySystemDesigner;

		public override IPlanetStudioUI PlanetStudioUI => _planetStudioUI;

		public static bool LoadAndViewCelestialBody(CelestialFile file, string createName = null)
		{
			ICelestialBodyDesigner celestialBodyDesigner = Instance.CelestialBodyDesigner;
			OperationResult operationResult = celestialBodyDesigner.LoadCelestialBody(file);
			if (!operationResult.IsSuccess)
			{
				operationResult.Log();
				Game.Instance.UserInterface.CreateErrorDialog($"Unable to load celestial body with ID '{file.Id}': {operationResult.ErrorMessage}", ErrorDialogOptions.LongError);
				return false;
			}
			if (!string.IsNullOrEmpty(operationResult.WarningMessage))
			{
				operationResult.Log();
				Game.Instance.UserInterface.CreateErrorDialog("The celestial body was loaded with warnings: " + operationResult.WarningMessage, ErrorDialogOptions.LongError);
			}
			Instance.PlanetStudioUI.EditMode = PlanetStudioEditMode.CelestialBody;
			operationResult = celestialBodyDesigner.ViewCelestialBody(cleanGeneratedData: true, true);
			if (!string.IsNullOrWhiteSpace(createName))
			{
				celestialBodyDesigner.CurrentCelestialBody.Name = createName;
			}
			if (!operationResult.IsSuccess)
			{
				operationResult.Log();
				Game.Instance.UserInterface.CreateErrorDialog($"Unable to view celestial body with ID '{file.Id}': {operationResult.ErrorMessage}", ErrorDialogOptions.LongError);
				return false;
			}
			Instance.PlanetStudioUI.CreateUndoStep(null, "Loaded celestial body");
			return true;
		}

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
			RegisterDevConsoleCommands();
			GameState gameState = Game.Instance.GameState;
			if (gameState.Type != GameStateType.PlanetStudio)
			{
				string id = gameState.Id;
				string gameStateTag = "PlanetStudio.Active";
				Game.Instance.GameStateManager.CreateDefaultSandboxTag(id, gameStateTag, GameStateType.PlanetStudio);
				Game.Instance.LoadGameStateOrDefault(id, gameStateTag);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Instance = null;
			UnregisterDevConsoleCommands();
		}

		protected virtual void Start()
		{
			CelestialFile autoLoadedCelestialBody = AutoLoadedCelestialBody;
			CelestialFile autoLoadPlanetarySystem = AutoLoadedPlanetarySystem;
			PlanetStudioUI.EditModeChanged += OnEditModeChanged;
			if (autoLoadedCelestialBody != null)
			{
				PlanetStudioUI.EditMode = PlanetStudioEditMode.CelestialBody;
				_celestialBodyDesigner.StartViewCelestialBodyInteractive(autoLoadedCelestialBody, cleanGeneratedData: true, true);
			}
			else
			{
				if (autoLoadPlanetarySystem == null)
				{
					return;
				}
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					OperationResult operationResult = _planetarySystemDesigner.LoadPlanetarySystem(autoLoadPlanetarySystem);
					operationResult.Log();
					if (operationResult.IsSuccess)
					{
						PlanetStudioUI.EditMode = PlanetStudioEditMode.PlanetarySystem;
						_planetarySystemDesigner.ViewPlanetarySystem(cleanGeneratedData: false, true).Log();
					}
				});
			}
		}

		private void OnEditModeChanged(object sender, EventArgs e)
		{
			_initialCamera.gameObject.SetActive(PlanetStudioUI.EditMode == PlanetStudioEditMode.None);
			_celestialBodyDesignerAudioListener.gameObject.SetActive(PlanetStudioUI.EditMode == PlanetStudioEditMode.CelestialBody);
		}

		private void RegisterDevConsoleCommands()
		{
			DevConsoleApi.RegisterCommand("PlanetStudio_ToggleTerrainGenerationAdvancedSettings", delegate
			{
				bool flag = !Game.Instance.Settings.UserPrefs.GetBool("PlanetStudio.TerrainGeneration.AdvancedSettings");
				Game.Instance.Settings.UserPrefs.SetBool("PlanetStudio.TerrainGeneration.AdvancedSettings", flag);
				Debug.Log("Terrain Generation Advanced Settings " + (flag ? "ON" : "OFF"));
				Game.Instance.Settings.Save();
			});
		}

		private void UnregisterDevConsoleCommands()
		{
			DevConsoleApi.UnregisterCommand("PlanetStudio_ToggleTerrainGenerationAdvancedSettings");
		}
	}
}
