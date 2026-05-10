using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using __Project__.Scripts.Cameras;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.UI.ColorPickerUI;

namespace __Project__.Scripts.UI
{
	public class ChangeNameOverlay : NoktaSingleton<ChangeNameOverlay>
	{
		[SerializeField]
		private TMP_InputField m_NameInput;

		[SerializeField]
		private TextMeshProUGUI m_MoneyText;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedCostText;

		[SerializeField]
		private Button m_ChangeNameButton;

		[SerializeField]
		private Button m_CancelButton;

		[SerializeField]
		private GameObject m_InteractableParent;

		[SerializeField]
		private float m_Price;

		[SerializeField]
		private NameFontSizer m_FontSizerX;

		[SerializeField]
		private NameFontSizer m_FontSizerY;

		[SerializeField]
		private ColorPreview m_NameColorPreview;

		[SerializeField]
		private ColorPreview m_BackgroundColorPreview;

		[SerializeField]
		private GameObject m_EnterNameText;

		[SerializeField]
		private TMP_Text m_ApprovedCanvas;

		[SerializeField]
		private GameObject m_TextColorPickerParent;

		[SerializeField]
		private GameObject m_BackgroundColorPickerParent;

		[SerializeField]
		private ColorPicker m_TextColorPicker;

		[SerializeField]
		private ColorPicker m_BackgroundColorPicker;

		[SerializeField]
		private GamePadUIPanel m_gamepadPanel;

		[SerializeField]
		private BackgroundColorPickerButton backgroundColorPickerButton;

		private string m_CachedName;

		private Color m_CachedColor;

		private Color m_CachedBackgroundColor;

		private float m_CachedSizeX;

		private float m_CachedSizeY;

		private bool m_CachedDefaultBGState;

		private DoorSwitchCamera m_SwitchCamera;

		[HideInInspector]
		public Color selectedColor;

		[HideInInspector]
		public float selectedSizeX;

		[HideInInspector]
		public float selectedSizeY;

		[HideInInspector]
		public Color selectedBackGroundColor;

		public bool IsAnythingChanged => false;

		public void Initialize(float price, DoorSwitchCamera switchCamera)
		{
		}

		private void SetStoreName(string storeName)
		{
		}

		public void ApproveStoreName()
		{
		}

		public void ApproveStoreName_Order(string shopName, Color shopTextColor, Color shopTextBgColor, float xSize, float ySize, bool isSignboardDefault)
		{
		}

		public void Cancel()
		{
		}

		public void SwitchColorPickers(bool isBackgroundOpened)
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnGamepadConnected(bool isConnected)
		{
		}
	}
}
