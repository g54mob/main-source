using System;
using Noesis;
using UnityEngine;

public class NoesisSettings : ScriptableObject
{
	public enum TextureSize
	{
		_256x256 = 0,
		_512x512 = 1,
		_1024x1024 = 2,
		_2048x2048 = 3,
		_4096x4096 = 4
	}

	public enum OffscreenSampleCount
	{
		_SameAsUnity = 0,
		_1x = 1,
		_2x = 2,
		_4x = 3,
		_8x = 4
	}

	public enum LinearRendering
	{
		_SamesAsUnity = 0,
		_Enabled = 1,
		_Disabled = 2
	}

	public enum LogLevel
	{
		Off = 0,
		Error = 1,
		Warning = 2,
		Information = 3,
		Debug = 4
	}

	[Serializable]
	public struct Cursor
	{
		public Texture2D Texture;

		public Vector2 HotSpot;
	}

	private static NoesisSettings _settings;

	[Tooltip("Fill with the Name value your were given when purchasing your Noesis license")]
	[Header("License")]
	public string licenseName;

	[Tooltip("Fill with the Key value your were given when purchasing your Noesis license")]
	public string licenseKey;

	[Tooltip("Sets a collection of application-scope resources, such as styles and brushes. Provides a simple way to support a consistent theme across your application")]
	[Header("XAML")]
	public NoesisXaml applicationResources;

	public Hash128 applicationResourcesHash;

	[Tooltip("Default value for FontFamily when it is not specified in a control or text element.")]
	public NoesisFont defaultFont;

	[Tooltip("Loads platform specific font fallbacks to be able to render a wide range of unicode characters like chinese, korean, japanese or emojis")]
	public bool loadPlatformFonts;

	[Tooltip("Default value for FontSize when it is not specified in a control or text element")]
	public float defaultFontSize;

	[Tooltip("Default value for FontWeight when it is not specified in a control or text element")]
	public FontWeight defaultFontWeight;

	[Tooltip("Default value for FontStretch when it is not specified in a control or text element")]
	public FontStretch defaultFontStretch;

	[Tooltip("Default value for FontStyle when it is not specified in a control or text element")]
	public FontStyle defaultFontStyle;

	[Header("Rendering (*)")]
	[Tooltip("Dimensions of texture used to cache glyphs")]
	public TextureSize glyphTextureSize;

	[Tooltip("Multisampling of offscreen textures")]
	public OffscreenSampleCount offscreenSampleCount;

	[Tooltip("Number of offscreen textures created at startup")]
	public uint offscreenInitSurfaces;

	[Tooltip("Max number of offscreen textures (0 = unlimited)")]
	public uint offscreenMaxSurfaces;

	[Tooltip("Enables linear color space")]
	public LinearRendering linearRendering;

	[Header("Editor Settings")]
	[Tooltip("Enables generation of thumbnails and previews")]
	public bool previewEnabled;

	[Tooltip("Sets the logging level for general messages")]
	public LogLevel generalLogLevel;

	[Tooltip("Sets the logging level for data binding")]
	public LogLevel bindingLogLevel;

	[Tooltip("The cursor that appears when an application is starting")]
	public Cursor AppStarting;

	[Tooltip("The Arrow cursor")]
	public Cursor Arrow;

	[Tooltip("The arrow with a compact disk cursor")]
	public Cursor ArrowCD;

	[Tooltip("The crosshair cursor")]
	public Cursor Cross;

	[Tooltip("A hand cursor")]
	public Cursor Hand;

	[Tooltip("A help cursor which is a combination of an arrow and a question mark")]
	public Cursor Help;

	[Tooltip("An I-beam cursor, which is used to show where the text cursor appears when the mouse is clicked")]
	public Cursor IBeam;

	[Tooltip("A cursor with which indicates that a particular region is invalid for a given operation")]
	public Cursor No;

	[Tooltip("A special cursor that is invisible")]
	public Cursor None;

	[Tooltip("A pen cursor")]
	public Cursor Pen;

	[Tooltip("The scroll all cursor")]
	public Cursor ScrollAll;

	[Tooltip("The scroll east cursor")]
	public Cursor ScrollE;

	[Tooltip("The scroll north cursor")]
	public Cursor ScrollN;

	[Tooltip("The scroll northeast cursor")]
	public Cursor ScrollNE;

	[Tooltip("The scroll north/south cursor")]
	public Cursor ScrollNS;

	[Tooltip("A scroll northwest cursor")]
	public Cursor ScrollNW;

	[Tooltip("The scroll south cursor")]
	public Cursor ScrollS;

	[Tooltip("A south/east scrolling cursor")]
	public Cursor ScrollSE;

	[Tooltip("The scroll southwest cursor")]
	public Cursor ScrollSW;

	[Tooltip("The scroll west cursor")]
	public Cursor ScrollW;

	[Tooltip("A west/east scrolling cursor")]
	public Cursor ScrollWE;

	[Tooltip("A four-headed sizing cursor, which consists of four joined arrows that point north, south, east, and west")]
	public Cursor SizeAll;

	[Tooltip("A two-headed northeast/southwest sizing cursor")]
	public Cursor SizeNESW;

	[Tooltip("A two-headed north/south sizing cursor")]
	public Cursor SizeNS;

	[Tooltip("A two-headed northwest/southeast sizing cursor")]
	public Cursor SizeNWSE;

	[Tooltip("A two-headed west/east sizing cursor")]
	public Cursor SizeWE;

	[Tooltip("An up arrow cursor, which is typically used to identify an insertion point")]
	public Cursor UpArrow;

	[Tooltip("Specifies a wait (or hourglass) cursor")]
	public Cursor Wait;

	[SerializeField]
	private string version;

	public string Version
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static NoesisSettings Get()
	{
		return null;
	}
}
