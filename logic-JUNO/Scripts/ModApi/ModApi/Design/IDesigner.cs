using System;
using System.Collections.ObjectModel;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design.Events;
using ModApi.GameLoop.Interfaces;
using ModApi.Ui;
using UnityEngine;

namespace ModApi.Design
{
	public interface IDesigner
	{
		ICraftConfiguration ActiveCraftConfiguration { get; }

		bool AdvancedMode { get; set; }

		bool AllowPartMovement { get; set; }

		bool AllowPartSelection { get; set; }

		bool CameraIsMoving { get; }

		bool CanPinch { get; set; }

		DesignerTool CapturedTool { get; }

		ICraftScript CraftScript { get; }

		IDesignerCamera DesignerCamera { get; }

		IDesignerUi DesignerUi { get; }

		bool DisableCameraMovement { get; set; }

		bool DisableCameraZoom { get; }

		IDesignerGameLoop GameLoop { get; }

		GameObject GameObject { get; }

		Camera GizmoCamera { get; }

		IPartScript HighlightedPart { get; set; }

		Light[] Lights { get; }

		DesignerTool MovePartTool { get; }

		IPerformanceAnalysis PerformanceAnalysis { get; }

		IPartScript SelectedPart { get; }

		ISelectPartTool SelectPartTool { get; }

		ISymmetry Symmetry { get; }

		ReadOnlyCollection<DesignerTool> Tools { get; }

		IUserInterface UserInterface { get; }

		event SimpleNotificationDelegate CraftLoaded;

		event SimpleNotificationDelegate CraftStructureChanged;

		event EventHandler<DesignerPartAddedEventArgs> PartAdded;

		event SelectedPartChangedDelegate SelectedPartChanged;

		event EventHandler<DesignerTutorialStartedEventArgs> TutorialStarted;

		event EventHandler<DesignerTutorialStepLoadedEventArgs> TutorialStepLoaded;

		void AddTool<T>(T newTool) where T : DesignerTool;

		void BeginFlight();

		void CreateCraftBodyDatas();

		void CreateNewCraft(CrafConfigurationType type, Action<ICraftScript> successCallback = null);

		void CreateSubassembly(string name, Assembly subassembly);

		void CreateUndoStep(string ignoreKey = null);

		void DeselectPart();

		void DeselectTool(DesignerTool tool);

		void Exit(string exitToScene = "Menu");

		PartRaycastResult GetPartAtScreenPosition(Vector2 position);

		T GetTool<T>() where T : DesignerTool;

		void HandleSelectedPartClicked(RaycastHit hit);

		bool IsToolActive<T>() where T : DesignerTool;

		bool IsToolActive(DesignerTool toolToCheck);

		AudioSource PlaySound(AudioFile audioFile);

		void SaveCraft(string craftId = null, string name = null, bool showMessage = false);

		void SelectPart(IPartScript partScript, RaycastHit? hit, bool justAdded);

		void SelectTool(DesignerTool tool);

		void ShowMessage(string message, float time = 7f);
	}
}
