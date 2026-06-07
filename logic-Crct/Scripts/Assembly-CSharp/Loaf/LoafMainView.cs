using System;
using System.Runtime.InteropServices;
using Noesis;

namespace Loaf
{
	public class LoafMainView : UserControl
	{
		public static LoafMainView inst;

		public static bool Dragging;

		public static UserControl DraggingControl;

		public static double Last7SegFV;

		public static double Last7SegMaxI;

		public static int Last7SegType;

		public static int LastBuzzerType;

		public static double LastLEDFV;

		public static double LastLEDCurrent;

		public static int LastLEDColor;

		public static int LastMOSFET;

		public static double LastBeta;

		public static int LastTransistorType;

		public static double LastDiodeFV;

		public static double LastDiodeLeakage;

		public static double LastDiodeZv;

		public static double LastPotOhms;

		public static double LastHenry;

		public static double LastFarads;

		public static int LastCapType;

		public static float LastResistance;

		public static float LastMaxPower;

		private ComponentToolWindow activeComponentTool;

		private HexEditorWindow activeHexEditor;

		public static string LastHexSaveName;

		public static string LastHexSaveLocation;

		private CodeEditorWindow activeCodeEditor;

		public static string LastCodeSaveLocation;

		public static string LastCodeName;

		private SerialMonitorWindow activeMonitor;

		private ScopeWindow activeScope;

		public static bool LockUpdate;

		public Button CloseButton;

		public Button MinimizeButton;

		public Button WindowButton;

		public Noesis.Label Title;

		public Button NewDesignButton;

		public Button OpenDesign;

		public Button SaveAsButton;

		public Image SaveImg;

		public Image UndoImg;

		public Image RedoImg;

		public Image StatusImage;

		public Button PassiveButton;

		public Button SaveButton;

		public Button UndoButton;

		public Button RedoButton;

		public Button ActiveButton;

		public Button OutputButton;

		public Button ICButton;

		public Button SettingsButton;

		public Border PassiveDropDown;

		public Border ActiveDropDown;

		public Border OutputDropDown;

		public Border ICDropDown;

		public Button ContextClickCaptureButton;

		public Rectangle ViewportRectangle;

		public TextBlock SimStatus;

		public Button HomeViewButton;

		public Button ViewSettingsButton;

		public Border ViewportSettingsPanel;

		public static CheckBox AOCheck;

		public static CheckBox BloomCheck;

		public static CheckBox AACheck;

		public static CheckBox ShadowHighCheck;

		public static CheckBox ShadowLowCheck;

		public static CheckBox ShadowOffCheck;

		public static CheckBox PerspectiveCheck;

		public static CheckBox OrthoCheck;

		public static Button SelectionToolButton;

		public static Button InteractionToolButton;

		public static Button ScopeToolButton;

		public static Border VoltageDisplay;

		public static Border CurrentDisplay;

		public static Noesis.Label MaxVoltageLabel;

		public static Noesis.Label MinVoltageLabel;

		public static Noesis.Label MaxCurrentLabel;

		public static Noesis.Label MinCurrentLabel;

		public static CheckBox StandardViewCheck;

		public static CheckBox VoltageViewCheck;

		public static CheckBox CurrentViewCheck;

		public static CheckBox ShowPinsCheck;

		public static CheckBox LogicCheck;

		public static CheckBox LightingCheck;

		public Button BreadboardButton;

		public Button PowerRailButton;

		public Button JumperWireButton;

		public Button ResistorButton;

		public Button CapacitorButton;

		public Button InductorButton;

		public Button TactSwitchButton;

		public Button SlideSwitchButton;

		public Button DIPSwitch4Button;

		public Button DIPSwitch8Button;

		public Button PotentiometerButton;

		public Button DiodeButton;

		public Button ZenerButton;

		public Button TransistorButton;

		public Button MOSFETButton;

		public Button SCRButton;

		public Button LEDButton;

		public Button BuzzerButton;

		public Button SevenSegButton;

		public Button HD44780Button;

		public Button ST7735Button;

		public Button NanoButton;

		public Button LabelButton;

		public Button MonitorButton;

		public Button DC12Button;

		public Button SignalGenButton;

		public Button LM555Button;

		public Button LM741Button;

		public Button _74HC00Button;

		public Button _74HC02Button;

		public Button _74HC04Button;

		public Button _74HC08Button;

		public Button _74HC32Button;

		public Button _74HC86Button;

		public Button _74HC107Button;

		public Button _74HC138Button;

		public Button _74HC139Button;

		public Button _74HC157Button;

		public Button _74HC161Button;

		public Button _74HC173Button;

		public Button _74F189Button;

		public Button _74HC245Button;

		public Button _74HC273Button;

		public Button _74HC283Button;

		public Button _28C16Button;

		public Button _74HC595Button;

		public static Grid ViewportGrid;

		public static StackPanel EditButtonStackPanel;

		public static Button DeleteButton;

		public static Button CancelButton;

		public static Button ConfirmButton;

		public static Noesis.Label ConfirmText;

		public static StackPanel WarningPanel;

		public static Noesis.Label WarningLabel;

		public static ComponentToolWindow ActiveComponentTool => null;

		public static HexEditorWindow ActiveHexEditor => null;

		public static CodeEditorWindow ActiveCodeEditor => null;

		public static HexEditorWindow ActiveMonitor => null;

		public static ScopeWindow ActiveScope => null;

		public static bool CanSaveButton => false;

		public static bool CanUndoButton => false;

		public static bool CanRedoButton => false;

		[PreserveSig]
		private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

		[PreserveSig]
		private static extern IntPtr GetActiveWindow();

		private void MinimizeButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void WindowButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void CloseButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void SignalGenButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void DC12Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void MonitorButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void LabelButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void NanoButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC595Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _28C16Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC283Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC273Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC245Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74F189Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC173Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC161Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC157Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC139Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC138Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC107Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC86Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC32Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC08Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC04Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC02Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void _74HC00Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void LM741Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void LM555Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void ST7735Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void HD44780Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void SevenSegButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void BuzzerButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void LEDButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void SCRButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void MOSFETButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void TransistorButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void DiodeButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void ZenerButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void PotentiometerButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void DIPSwitch8Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void DIPSwitch4Button_Click(object sender, RoutedEventArgs args)
		{
		}

		private void SlideSwitchButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void TactSwitchButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void InductorButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void CapacitorButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void ResistorButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void JumperWireButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void BreadboardButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void PowerRailButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public static void Update()
		{
		}

		public static void CloseComponentTool()
		{
		}

		public static void OpenComponentTool(UserControl componentControl = null, string componentName = "", bool editor = false)
		{
		}

		public static void OpenHexEditor(byte[] data = null)
		{
		}

		public static void CloseHexEditor()
		{
		}

		public static void OpenCodeEditor(MicroController mc)
		{
		}

		public static void CloseCodeEditor()
		{
		}

		public static void OpenMonitor()
		{
		}

		public static void CloseMonitor()
		{
		}

		public static void OpenScope(BaseComponent comp)
		{
		}

		public static void CloseScope()
		{
		}

		public static void LogicCheckHotkey()
		{
		}

		public static void LogicCheck_Click(object sender, RoutedEventArgs args)
		{
		}

		public static void ShowPinsHotkey()
		{
		}

		public static void ShowPinsCheck_Click(object sender, RoutedEventArgs args)
		{
		}

		private void ViewSettingsButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public void SettingsButton_Click(object sender, RoutedEventArgs e)
		{
		}

		public void MouseEnteredViewport(object s, RoutedEventArgs e)
		{
		}

		public void MouseLeftViewport(object s, RoutedEventArgs e)
		{
		}

		public static void SaveButtonDisabled()
		{
		}

		public static void SaveButtonEnabled()
		{
		}

		public static void UndoButtonDisabled()
		{
		}

		public static void UndoButtonEnabled()
		{
		}

		public static void RedoButtonDisabled()
		{
		}

		public static void RedoButtonEnabled()
		{
		}

		public void ShowPassiveDropDown(object s, RoutedEventArgs e)
		{
		}

		public void ShowActiveDropDown(object s, RoutedEventArgs e)
		{
		}

		public void ShowOutputDropDown(object s, RoutedEventArgs e)
		{
		}

		public void ShowICDropDown(object s, RoutedEventArgs e)
		{
		}

		public void HideAllContexts(object s, RoutedEventArgs e)
		{
		}

		public static void UpdateSimStatus(CircuitSimulation.Status status)
		{
		}

		public static void UpdateSimStatusMessage(string message)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
