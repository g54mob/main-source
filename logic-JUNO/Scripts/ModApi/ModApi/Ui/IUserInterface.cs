using System;
using ModApi.Ui.Events;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Ui
{
	public interface IUserInterface
	{
		IDialog ActiveDialog { get; }

		bool AnyDialogsOpen { get; }

		Camera Camera { get; }

		bool IgnoreKeyboardInputs { get; }

		bool InspectorPanelsVisible { get; set; }

		bool IsTextInputFocused { get; }

		IUIResourceDatabase ResourceDatabase { get; }

		Transform Transform { get; }

		event AnyDialogsOpenChangedHandler AnyDialogsOpenChanged;

		event EventHandler<InspectorPanelLoadedEventArgs> InspectorPanelLoaded;

		event EventHandler<InspectorPanelLoadingEventArgs> InspectorPanelLoading;

		event EventHandler<UserInterfaceLoadedEventArgs> UserInterfaceLoaded;

		event EventHandler<UserInterfaceLoadingEventArgs> UserInterfaceLoading;

		void AddBuildInspectorPanelAction(BuildInspectorPanelDelegate buildAction);

		void AddBuildInspectorPanelAction(string inspectorId, BuildInspectorPanelDelegate buildAction);

		void AddBuildUserInterfaceXmlAction(BuildUserInterfaceXmlDelegate buildAction);

		void AddBuildUserInterfaceXmlAction(string userInterfaceId, BuildUserInterfaceXmlDelegate buildAction);

		void BuildUserInterfaceFromRequest(BuildUserInterfaceXmlRequest request, IXmlLayout xmlLayout);

		void BuildUserInterfaceFromRequest(BuildUserInterfaceXmlRequest request, GameObject obj, object eventTarget, Action<IXmlLayoutController> layoutRebuiltAction);

		void BuildUserInterfaceFromResource(string xmlPath, IXmlLayout xmlLayout);

		void BuildUserInterfaceFromResource(string xmlPath, MonoBehaviour script, Action<IXmlLayoutController> layoutRebuiltAction);

		T BuildUserInterfaceFromResource<T>(string xmlPath, Action<T, IXmlLayoutController> layoutRebuiltAction = null, Transform parentTransform = null) where T : MonoBehaviour;

		T BuildUserInterfaceFromXml<T>(string xml, string userInterfaceId, Action<T, IXmlLayoutController> layoutRebuiltAction = null, Transform parentTransform = null) where T : MonoBehaviour;

		void BuildUserInterfaceFromXml(string xml, string userInterfaceId, IXmlLayout xmlLayout);

		void BuildUserInterfaceFromXml(string xml, string userInterfaceId, MonoBehaviour script, Action<IXmlLayoutController> layoutRebuiltAction);

		void CreateColorPicker(bool allowTransparency, Color initialColor, Action<Color> onComplete, Action<Color> onPreviewColorChanged = null, bool allowHDR = false);

		void CreateCurveEditor(AnimationCurve curve, Action<AnimationCurve> saveBack);

		T CreateDialog<T>(Transform parent, bool registerWithUserInterface = true, bool fadeIn = true) where T : DialogScript;

		T CreateDialog<T>(string xmlResourcePath, Transform parent, Action<T, IXmlLayoutController> layoutRebuiltAction, Action<T> initializeAction = null, bool fadeIn = true) where T : DialogScript;

		MessageDialogScript CreateErrorDialog(string errorMessage, Action action = null, Transform parent = null);

		MessageDialogScript CreateErrorDialog(string errorMessage, ErrorDialogOptions options);

		void CreateGradientEditor(Gradient gradient, Action<Gradient> saveBack, bool hasAlpha, bool allowHDR);

		InputDialogScript CreateInputDialog(Transform parent = null);

		IInspectorPanel CreateInspectorPanel(InspectorModel model, InspectorPanelCreationInfo creationInfo = null);

		IListView CreateListView(IListViewModel viewModel, IListViewObjectViewer objectViewer = null);

		MessageDialogScript CreateMessageDialog(string message, Action action = null, Transform parent = null, bool fadeIn = true);

		MessageDialogScript CreateMessageDialog(MessageDialogType type = MessageDialogType.Okay, Transform parent = null, bool fadeIn = true);

		void RegisterDialog(IDialog dialog);

		void RemoveBuildInspectorPanelAction(BuildInspectorPanelDelegate buildAction);

		void RemoveBuildInspectorPanelAction(string inspectorId, BuildInspectorPanelDelegate buildAction);

		void RemoveBuildUserInterfaceXmlAction(BuildUserInterfaceXmlDelegate buildAction);

		void RemoveBuildUserInterfaceXmlAction(string userInterfaceId, BuildUserInterfaceXmlDelegate buildAction);

		void ToggleFps();

		void UnregisterDialog(IDialog dialog);
	}
}
