using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class FlexibleColorPicker : MonoBehaviour
{
	[Serializable]
	private struct Picker
	{
		public Image image;

		public Sprite dynamicSprite;

		public Sprite staticSpriteHor;

		public Sprite staticSpriteVer;

		public Material dynamicMaterial;
	}

	private enum PickerType
	{
		Main = 0,
		R = 1,
		G = 2,
		B = 3,
		H = 4,
		S = 5,
		V = 6,
		A = 7,
		Preview = 8,
		PreviewAlpha = 9
	}

	public enum MainPickingMode
	{
		HS = 0,
		HV = 1,
		SH = 2,
		SV = 3,
		VH = 4,
		VS = 5
	}

	[Serializable]
	public class ColorUpdateEvent : UnityEvent<Color>
	{
	}

	[Serializable]
	public class AdvancedSettings
	{
		[Serializable]
		public class PSettings
		{
			[Tooltip("Value can be used to restrict slider range")]
			public Vector2 range;

			[Tooltip("Make the picker associated with this value act static, even in a dynamic color picker setup")]
			public bool overrideStatic;
		}

		public bool mainStatic;

		public PSettings r;

		public PSettings g;

		public PSettings b;

		public PSettings h;

		public PSettings s;

		public PSettings v;

		public PSettings a;

		public PSettings Get(int i)
		{
			return null;
		}
	}

	[Serializable]
	private class BufferedColor
	{
		public Color color;

		private float bufferedHue;

		private float bufferedSaturation;

		public float r => 0f;

		public float g => 0f;

		public float b => 0f;

		public float a => 0f;

		public float h => 0f;

		public float s => 0f;

		public float v => 0f;

		public BufferedColor()
		{
		}

		public BufferedColor(Color color)
		{
		}

		public BufferedColor(Color color, float hue, float sat)
		{
		}

		public BufferedColor(Color color, BufferedColor source)
		{
		}

		public void Set(Color color)
		{
		}

		public void Set(Color color, float bufferedHue, float bufferedSaturation)
		{
		}

		public BufferedColor PickR(float value)
		{
			return null;
		}

		public BufferedColor PickG(float value)
		{
			return null;
		}

		public BufferedColor PickB(float value)
		{
			return null;
		}

		public BufferedColor PickA(float value)
		{
			return null;
		}

		public BufferedColor PickH(float value)
		{
			return null;
		}

		public BufferedColor PickS(float value)
		{
			return null;
		}

		public BufferedColor PickV(float value)
		{
			return null;
		}
	}

	[SerializeField]
	private Slider hSlider;

	[SerializeField]
	private Slider sSlider;

	[SerializeField]
	private Slider vSlider;

	[Tooltip("Connections to the FCP's picker images, this should not be adjusted unless in advanced use cases.")]
	[SerializeField]
	private Picker[] pickers;

	[Tooltip("Connection to the FCP's hexadecimal input field.")]
	[SerializeField]
	private InputField hexInput;

	[Tooltip("Connection to the FCP's mode dropdown menu.")]
	[SerializeField]
	private Dropdown modeDropdown;

	private Canvas canvas;

	[Tooltip("The (starting) 2D picking mode, i.e. the 2 color values that can be picked with the large square picker.")]
	[SerializeField]
	private MainPickingMode mode;

	[Tooltip("Sprites to be used in static mode on the main picker, one for each 2D mode.")]
	[SerializeField]
	private Sprite[] staticSpriteMain;

	private BufferedColor bufferedColor;

	private Picker focusedPicker;

	private PickerType focusedPickerType;

	private MainPickingMode lastUpdatedMode;

	private bool typeUpdate;

	private bool triggeredStaticMode;

	private bool materialsSeperated;

	[Tooltip("Color set to the color picker on Start(). If you wish to set a starting color via script please used the standard color parameter of the FCP in stead.")]
	[SerializeField]
	private Color startingColor;

	[Tooltip("Use static mode: picker images are replaced by static images in stead of adaptive Unity shaders.")]
	public bool staticMode;

	[Tooltip("Make sure FCP seperates its picker materials so that the dynamic mode works consistently, even when multiple FPCs are active at the same time. Turning this off yields a slight performance boost.")]
	public bool multiInstance;

	public ColorUpdateEvent onColorChange;

	private const float HUE_LOOP = 5.9999f;

	private const string SHADER_MODE = "_Mode";

	private const string SHADER_C1 = "_Color1";

	private const string SHADER_C2 = "_Color2";

	private const string SHADER_DOUBLE_MODE = "_DoubleMode";

	private const string SHADER_HSV = "_HSV";

	private const string SHADER_HSV_MIN = "_HSV_MIN";

	private const string SHADER_HSV_MAX = "_HSV_MAX";

	[Tooltip("More specific settings for color picker. Changes are not applied immediately, but require an FCP update to trigger.")]
	public AdvancedSettings advancedSettings;

	private AdvancedSettings avs => null;

	public Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public Color GetColor()
	{
		return default(Color);
	}

	public void SetColor(Color color)
	{
	}

	public Color GetColorFullAlpha()
	{
		return default(Color);
	}

	public void SetColorNoAlpha(Color color)
	{
	}

	private void Awake()
	{
	}

	private void SliderUpdate(PickerType type, float value)
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void SetPointerFocus(int i)
	{
	}

	public void PointerUpdate(BaseEventData e)
	{
	}

	public void TypeHex(string input)
	{
	}

	public void FinishTypeHex(string input)
	{
	}

	public void ChangeMode(int newMode)
	{
	}

	public void ChangeMode(MainPickingMode mode)
	{
	}

	private void SeperateMaterials()
	{
	}

	public void ShiftColor(int type, float delta)
	{
	}

	public void ShiftHue(float delta)
	{
	}

	private BufferedColor PickColor(BufferedColor color, PickerType type, Vector2 v)
	{
		return null;
	}

	private BufferedColor PickColorMain(BufferedColor color, Vector2 v)
	{
		return null;
	}

	private BufferedColor PickColor1D(BufferedColor color, PickerType type, Vector2 v)
	{
		return null;
	}

	private BufferedColor PickColorMain(BufferedColor color, MainPickingMode mode, Vector2 v)
	{
		return null;
	}

	private BufferedColor PickColor2D(BufferedColor color, PickerType type1, float value1, PickerType type2, float value2)
	{
		return null;
	}

	private BufferedColor PickColor1D(BufferedColor color, PickerType type, float value)
	{
		return null;
	}

	private void UpdateMarkers()
	{
	}

	private void UpdateMarker(Picker picker, PickerType type, Vector2 v)
	{
	}

	private void SetMarker(Image picker, Vector2 v, bool setX, bool setY)
	{
	}

	private RectTransform GetMarker(Image picker, string search)
	{
		return null;
	}

	private Vector2 GetValue(PickerType type)
	{
		return default(Vector2);
	}

	private float GetValue1D(PickerType type)
	{
		return 0f;
	}

	private Vector2 GetValue(MainPickingMode mode)
	{
		return default(Vector2);
	}

	private void UpdateTextures()
	{
	}

	private void UpdateStatic(PickerType type)
	{
	}

	private void UpdateDynamic(PickerType type)
	{
	}

	private int GetGradientMode(PickerType type)
	{
		return 0;
	}

	private bool IsPickerAvailable(PickerType type)
	{
		return false;
	}

	private bool IsPickerAvailable(int index)
	{
		return false;
	}

	private void UpdateHex()
	{
	}

	private void TypeHex(string input, bool finish)
	{
	}

	private void MakeModeOptions()
	{
	}

	private void UpdateMode(MainPickingMode mode)
	{
	}

	private static bool IsPreviewType(PickerType type)
	{
		return false;
	}

	private static bool IsAlphaType(PickerType type)
	{
		return false;
	}

	private static bool IsHorizontal(Picker p)
	{
		return false;
	}

	public static string GetSanitizedHex(string input, bool full)
	{
		return null;
	}

	private static bool IsValidHexChar(char c)
	{
		return false;
	}

	public static Color ParseHex(string input)
	{
		return default(Color);
	}

	public static Color ParseHex(string input, Color defaultColor)
	{
		return default(Color);
	}

	private static Vector2 GetNormalizedPointerPosition(Canvas canvas, RectTransform rect, BaseEventData e)
	{
		return default(Vector2);
	}

	private static Vector2 GetNormScreenSpace(RectTransform rect, BaseEventData e)
	{
		return default(Vector2);
	}

	private static Vector2 GetNormWorldSpace(Canvas canvas, RectTransform rect, BaseEventData e)
	{
		return default(Vector2);
	}

	public static Color HSVToRGB(Vector3 hsv)
	{
		return default(Color);
	}

	public static Color HSVToRGB(float h, float s, float v)
	{
		return default(Color);
	}

	public static Vector3 RGBToHSV(Color color)
	{
		return default(Vector3);
	}

	public static Vector3 RGBToHSV(float r, float g, float b)
	{
		return default(Vector3);
	}
}
