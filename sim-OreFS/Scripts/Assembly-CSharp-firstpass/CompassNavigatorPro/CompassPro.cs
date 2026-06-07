using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CompassNavigatorPro
{
	[HelpURL("https://kronnect.com/guides-category/compass-navigator-pro-2/")]
	[ExecuteAlways]
	[DefaultExecutionOrder(100)]
	public class CompassPro : MonoBehaviour
	{
		private enum CompassPoint
		{
			CardinalEast = 0,
			OrdinalNorthEast = 1,
			CardinalNorth = 2,
			OrdinalNorthWest = 3,
			CardinalWest = 4,
			OrdinalSouthWest = 5,
			CardinalSouth = 6,
			OrdinalSouthEast = 7
		}

		private struct CompassPointPOI
		{
			public Vector3 position;

			public float cos;

			public float sin;

			public Text text;
		}

		private static class ShaderParams
		{
			public static int MainTex = Shader.PropertyToID("_MainTex");

			public static int MiniMapTex = Shader.PropertyToID("_MiniMapTex");

			public static int MaskTex = Shader.PropertyToID("_MaskTex");

			public static int BorderTex = Shader.PropertyToID("_BorderTex");

			public static int FoWTexture = Shader.PropertyToID("_FogOfWarTex");

			public static int FollowPos = Shader.PropertyToID("_FollowPos");

			public static int Rotation = Shader.PropertyToID("_Rotation");

			public static int ConeRotation = Shader.PropertyToID("_ConeRotation");

			public static int UVOffset = Shader.PropertyToID("_UVOffset");

			public static int UVFogOffset = Shader.PropertyToID("_UVFogOffset");

			public static int FoWTintColor = Shader.PropertyToID("_FogOfWarTintColor");

			public static int Effects = Shader.PropertyToID("_Effects");

			public static int LUTTexture = Shader.PropertyToID("_LUTTex");

			public static int VignetteColor = Shader.PropertyToID("_VignetteColor");

			public static int RingsData = Shader.PropertyToID("_RingsData");

			public static int RingsColor = Shader.PropertyToID("_RingsColor");

			public static int RingsPulseData = Shader.PropertyToID("_RingsPulse");

			public static int ViewConeColor = Shader.PropertyToID("_ViewConeColor");

			public static int ViewConeData = Shader.PropertyToID("_ViewConeData");

			public static int ViewConeOutlineColor = Shader.PropertyToID("_ViewConeOutlineColor");

			public static int Color = Shader.PropertyToID("_Color");

			public static int Angle = Shader.PropertyToID("_Angle");

			public static int TintColor = Shader.PropertyToID("_TintColor");

			public static int BackgroundColor = Shader.PropertyToID("_BackgroundColor");

			public static int BackgroundOpaque = Shader.PropertyToID("_BackgroundOpaque");

			public static int OffscreenIndicatorIconTexture = Shader.PropertyToID("_IconTex");

			public static int CompassData = Shader.PropertyToID("_CompassData");

			public static int CompassIP = Shader.PropertyToID("_CompassIP");

			public static int CompassAngle = Shader.PropertyToID("_CompassAngle");

			public static int TicksSize = Shader.PropertyToID("_TicksSize");

			public static int TicksColor = Shader.PropertyToID("_TicksColor");

			public static int FXData = Shader.PropertyToID("_FXData");

			public static int CircleStartRadius = Shader.PropertyToID("_StartRadius");

			public static int CircleInnerColor = Shader.PropertyToID("_InnerColor");

			public static int ScrollOffset = Shader.PropertyToID("_ScrollOffset");

			public const string SKW_COMPASS_LUT = "COMPASS_LUT";

			public const string SKW_COMPASS_FOG_OF_WAR = "COMPASS_FOG_OF_WAR";

			public const string SKW_COMPASS_ROTATED = "COMPASS_ROTATED";

			public const string SKW_COMPASS_INDICATOR_KEEPSIZE = "COMPASS_INDICATOR_KEEPSIZE";

			public const string SKW_COMPASS_RADAR = "COMPASS_RADAR";

			public const string SKW_COMPASS_VIEW_CONE = "COMPASS_VIEW_CONE";

			public const string SKW_COMPASS_VIEW_CONE_OUTLINE = "COMPASS_VIEW_CONE_OUTLINE";

			public const string SKW_TICKS = "TICKS";

			public const string SKW_TICKS_180 = "TICKS_180";

			public const string SKW_TICKS_360 = "TICKS_360";

			public const string SKW_SCROLLABLE = "SCROLLABLE";

			public const string SKW_SCROLLABLE_180 = "SCROLLABLE_180";

			public const string SKW_SCROLLABLE_360 = "SCROLLABLE_360";

			public const string SKW_COMPASS_ROTATE_BORDER = "COMPASS_ROTATE_BORDER";
		}

		[Tooltip("Camera used for computing the indicators and POI screen positions")]
		[SerializeField]
		private Camera _cameraMain;

		[Tooltip("The pivot used to compute distances. In a third person setup, the follow could be the root of the player game object which is different than the orbiting camera.")]
		[SerializeField]
		private Transform _follow;

		[Tooltip("Contents are always updated if camera moves or rotates. If not, this property specifies the interval between POI change checks")]
		[SerializeField]
		private UpdateMode _updateMode;

		[Tooltip("Frames between compass bar updates.")]
		[SerializeField]
		private int _updateIntervalFrameCount = 60;

		[Tooltip("Seconds between compass bar updates")]
		[SerializeField]
		private float _updateIntervalTime = 0.2f;

		[Tooltip("Hides UI if no camera is found")]
		[SerializeField]
		private bool _hideIfNoCamera;

		[Tooltip("Shows the compass bar")]
		[SerializeField]
		private bool _showCompassBar = true;

		[Tooltip("Compass bar style")]
		[SerializeField]
		private CompassStyle _style = CompassStyle.Celtic_White;

		[Tooltip("Custom sprite for the compass bar. Check the documentation for configuring a sprite.")]
		[SerializeField]
		private Sprite _compassBackSprite;

		[Tooltip("If the sprite can scroll horizontally")]
		[SerializeField]
		private bool _compassBackSpriteScrollable;

		[Tooltip("If the sprite can scroll horizontally")]
		[SerializeField]
		[Range(-1f, 1f)]
		private float _compassBackSpriteScrollOffset;

		[SerializeField]
		private Color _compassTintColor = Color.white;

		[Tooltip("The position of the North in degrees (0-360)")]
		[Range(-180f, 180f)]
		[SerializeField]
		private float _northDegrees;

		[Tooltip("POIs beyond visible distance (meters) will not be shown in the compass bar")]
		[SerializeField]
		private float _visibleMaxDistance = 500f;

		[Tooltip("POIs nearer than this distance (meters) will not be shown in the compass bar")]
		[SerializeField]
		private float _visibleMinDistance;

		[Tooltip("Minimum POI distance to display its title. Distance text won't be shown for objects within this distance")]
		[SerializeField]
		private float _titleMinPOIDistance = 10f;

		[Tooltip("Distance to a POI where the icon will start to grow as player approaches")]
		[SerializeField]
		private float _nearDistance = 75f;

		[Tooltip("Minimum distance to a POI to be considered as explored/visited")]
		[SerializeField]
		private float _visitedDistance = 25f;

		[Tooltip("Shows on-screen indicators in the scene during playmode for the POIs (can be enabled/disabled per POI)")]
		[SerializeField]
		private bool _showOnScreenIndicators = true;

		[SerializeField]
		private GameObject _compassIconPrefab;

		[Tooltip("Indicator prefab. Used for both on-screen and off-screen modes.")]
		[SerializeField]
		private GameObject _onScreenIndicatorPrefab;

		[Tooltip("Transparency level of on-screen indicators")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _onScreenIndicatorAlpha = 0.85f;

		[Tooltip("Scaling applied to indicators shown during playmode")]
		[SerializeField]
		private float _onScreenIndicatorScale = 1f;

		[Tooltip("Distance at which the indicator will not be visible")]
		[SerializeField]
		private float _onScreenIndicatorFarDistance = 10000f;

		[Tooltip("Distance at which the on-screen indicator will start to fade when it approaches camera")]
		[SerializeField]
		private float _onScreenIndicatorNearFadeDistance = 10f;

		[Tooltip("Minimum distance at which the on-screen indicator disappear")]
		[SerializeField]
		private float _onScreenIndicatorNearFadeMin = 1f;

		[Tooltip("Whether the distance in meters should be shown under the indicator")]
		[SerializeField]
		private bool _onScreenIndicatorShowDistance = true;

		[Tooltip("The string format for displaying the distance on the indicators. The syntax for this string format corresponds with the available options for ToString(format) method of C#")]
		[SerializeField]
		private string _onScreenIndicatorShowDistanceFormat = "0m";

		[Tooltip("Whether the title of the POI should also be displayed")]
		[SerializeField]
		private bool _onScreenIndicatorShowTitle;

		[Tooltip("Show indicators on the edges of screen during playmode for POIs not visible in the screen (can be enabled/disabled per POI)")]
		[SerializeField]
		private bool _showOffScreenIndicators = true;

		[Tooltip("Scaling applied to offscreen indicators shown during playmode.")]
		[SerializeField]
		private float _offScreenIndicatorScale = 1f;

		[Tooltip("Margin between the indicator and screen edge")]
		[Range(0f, 0.4f)]
		[SerializeField]
		private float _offScreenIndicatorMargin = 0.05f;

		[Tooltip("Screen rect where indicators are displayed")]
		[SerializeField]
		private Rect _offScreenIndicatorRect = new Rect(0f, 0f, 1f, 1f);

		[Tooltip("Enable to avoid off-screen icons to overlap.")]
		[SerializeField]
		private bool _offScreenIndicatorAvoidOverlap = true;

		[Tooltip("Overlap distance")]
		[Range(0f, 0.1f)]
		[SerializeField]
		private float _offScreenIndicatorOverlapDistance = 0.04f;

		[Tooltip("Transparency level of offscreen indicators")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _offScreenIndicatorAlpha = 0.85f;

		[Tooltip("Transparency of the compass bar")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _alpha = 1f;

		[Tooltip("Hides the compass bar if no POIs are below visible distance")]
		[SerializeField]
		private bool _autoHide;

		[Tooltip("Duration of alpha changes in seconds")]
		[Range(0f, 8f)]
		[SerializeField]
		private float _fadeDuration = 2f;

		[Tooltip("Makes the bar always visible (ignores alpha property) while in Edit Mode")]
		[SerializeField]
		private bool _alwaysVisibleInEditMode = true;

		[Tooltip("Distance from the bottom of the screen in %")]
		[Range(-0.2f, 1.2f)]
		[SerializeField]
		private float _verticalPosition = 0.97f;

		[Tooltip("Distance from the center of the screen in %")]
		[Range(-0.5f, 0.5f)]
		[SerializeField]
		private float _horizontalPosition;

		[Tooltip("Bending amount. Set this to zero to disable bending effect")]
		[Range(-1f, 1f)]
		[SerializeField]
		private float _bendAmount;

		[Tooltip("Width of the compass bar in % of the screen width")]
		[Range(0.05f, 1f)]
		[SerializeField]
		private float _width = 0.65f;

		[Tooltip("Vertical scale of the compass bar.")]
		[Range(0.05f, 5f)]
		[SerializeField]
		private float _height = 1f;

		[Tooltip("Enables edge fade out effect")]
		[SerializeField]
		private bool _edgeFadeOut;

		[Tooltip("If edge fade out affects title and text below compass bar")]
		[SerializeField]
		private bool _edgeFadeOutText = true;

		[Tooltip("Width of the edge fade out")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _edgeFadeOutWidth = 0.1f;

		[Tooltip("Start of the edge fade out.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _edgeFadeOutStart;

		[Tooltip("Width of the end caps of the compass bar. This setting limits the usable horizontal range of the bar in the screen to prevent icons being drawn over the art of the end caps of the bar")]
		[Range(0f, 100f)]
		[SerializeField]
		private float _endCapsWidth = 54f;

		[Tooltip("Whether N, W, S, E should be visible in the compass bar")]
		[SerializeField]
		private bool _showCardinalPoints = true;

		[Tooltip("Whether NW, NE, SW, SE should be visible in the compass bar")]
		[SerializeField]
		private bool _showOrdinalPoints = true;

		[Range(0.1f, 3f)]
		[SerializeField]
		private float _cardinalScale = 1f;

		[Range(0.1f, 3f)]
		[SerializeField]
		private float _ordinalScale = 1f;

		[Tooltip("Optional vertical displacement for both cardinal and ordinal points")]
		[SerializeField]
		private float _cardinalPointsVerticalOffset;

		[Tooltip("Enable vertical interval marks in the compass bar")]
		[SerializeField]
		private bool _showHalfWinds = true;

		[SerializeField]
		[Range(0.01f, 0.5f)]
		private float _halfWindsHeight = 0.125f;

		[SerializeField]
		[Range(0.01f, 2f)]
		private float _halfWindsWidth = 0.2f;

		[SerializeField]
		[Range(1f, 45f)]
		private float _halfWindsInterval = 5f;

		[SerializeField]
		private Color _halfWindsTintColor = new Color(1f, 1f, 1f, 0.5f);

		[Tooltip("The distance from the center of the compass bar where a POI's label is visible")]
		[Range(0.001f, 0.2f)]
		[SerializeField]
		private float _labelHotZone = 0.015f;

		[SerializeField]
		private float _maxIconSize = 1.15f;

		[SerializeField]
		private float _minIconSize = 0.5f;

		[Tooltip("Duration for the scale animation when the POI appears on the compass bar")]
		[Range(0f, 5f)]
		[SerializeField]
		private float _scaleInDuration = 0.3f;

		[SerializeField]
		private CompassProPOI _focusedPOI;

		[Tooltip("How POIs positions are mapped to the bar. 1) Limited To Bar Width = the bar width determines the view angle, 2) Camera Frustum = the entire camera frustum is mapped to the bar width, 3) Full 180 degrees = all POIs in front of the camera will appear in the compass bar. 4) Full 360 degrees = all POIs are visible in the compass bar")]
		[SerializeField]
		private WorldMappingMode _worldMappingMode = WorldMappingMode.CameraFrustum;

		[Tooltip("Vertical offset in pixels for the text with respect to the compass bar.")]
		[Range(-200f, 200f)]
		[SerializeField]
		private float _textVerticalPosition = -30f;

		[Tooltip("Scaling applied to the text")]
		[Range(0.02f, 3f)]
		[SerializeField]
		private float _textScale = 0.2f;

		[Tooltip("Controls the spacing between each letter in the reveal text.")]
		[Range(0.02f, 3f)]
		[SerializeField]
		private float _textLetterSpacing = 1f;

		[Tooltip("Show a revealing text effect when discovering POIs for the first time")]
		[SerializeField]
		private bool _textRevealEnabled = true;

		[Tooltip("Text reveal duration in seconds")]
		[Range(0f, 3f)]
		[SerializeField]
		private float _textRevealDuration = 0.5f;

		[Tooltip("Delay in appearance of each letter during a text reveal")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _textRevealLetterDelay = 0.05f;

		[Tooltip("Text duration in screen")]
		[Range(0f, 20f)]
		[SerializeField]
		private float _textDuration = 5f;

		[Tooltip("Duration of the text fade out.")]
		[Range(0f, 10f)]
		[SerializeField]
		private float _textFadeOutDuration = 2f;

		[Tooltip("Enable or disable text shadow")]
		[SerializeField]
		private bool _textShadowEnabled = true;

		[SerializeField]
		private Font _textFont;

		[Tooltip("Vertical offset in pixels for the title with respect to the compass bar")]
		[Range(-200f, 200f)]
		[SerializeField]
		private float _titleVerticalPosition = 18f;

		[Tooltip("Scaling applied to the title")]
		[Range(0.02f, 3f)]
		[SerializeField]
		private float _titleScale = 0.1f;

		[SerializeField]
		private Font _titleFont;

		[Tooltip("Font used for the title when bending is enabled")]
		[SerializeField]
		private bool _titleShadowEnabled = true;

		[Tooltip("Font used for the title when bending is disabled")]
		[SerializeField]
		private TMP_FontAsset _titleFontTMP;

		[Tooltip("Whether the distance in meters should be shown in the title")]
		[SerializeField]
		private bool _titleShowDistance;

		[Tooltip("The string format for displaying the distance in the title. The syntax for this string format corresponds with the available options for ToString(format) method of C#")]
		[SerializeField]
		private string _titleShowDistanceFormat = "0.0 m";

		[Tooltip("Whether 3D distance should be computed instead of planar X/Z distance")]
		[SerializeField]
		private bool _use3Ddistance;

		[Tooltip("Minimum difference in altitude from camera to show 'above' or 'below'")]
		[Range(1f, 50f)]
		[SerializeField]
		private float _sameAltitudeThreshold = 3f;

		[Tooltip("Whether the distance in meters should be shown in the POI indicator")]
		[SerializeField]
		private bool _showDistance = true;

		[Tooltip("The string format for displaying the distance under the icons on the compass bar. The syntax for this string format corresponds with the available options for ToString(format) method of C#")]
		[SerializeField]
		private string _showDistanceFormat = "0m";

		[Tooltip("Default audio clip to be played when a POI is visited for the first time. Note that you can specify a different audio clip in the POI script itself")]
		[SerializeField]
		private AudioClip _visitedDefaultAudioClip;

		[Tooltip("Default audio clip to be played when a POI beacon is shown. Note that you can specify a different audio clip in the POI script itself")]
		[SerializeField]
		private AudioClip _beaconDefaultAudioClip;

		[Tooltip("Default audio clip to play for the heartbeat effect. This effect is enabled on each POI and will play a custom sound with variable speed depending on distance")]
		[SerializeField]
		private AudioClip _heartbeatDefaultAudioClip;

		[Tooltip("Preserve compass bar between scene changes.")]
		[SerializeField]
		private bool _dontDestroyOnLoad;

		[NonSerialized]
		public CompassProPOI nearestPOI;

		public Action<CompassProPOI> OnPOIRegister;

		public Action<CompassProPOI> OnPOIUnregister;

		public Action<CompassProPOI> OnPOIVisited;

		public Action<CompassProPOI> OnPOIEnterCircle;

		public Action<CompassProPOI> OnPOIExitCircle;

		public Action<CompassProPOI> OnPOIVisible;

		public Action<CompassProPOI> OnPOIHide;

		public Action<CompassProPOI> OnPOIMiniMapIconMouseEnter;

		public Action<CompassProPOI> OnPOIMiniMapIconMouseExit;

		public Action<CompassProPOI, int> OnPOIMiniMapIconMouseDown;

		public Action<CompassProPOI, int> OnPOIMiniMapIconMouseUp;

		public Action<CompassProPOI, int> OnPOIMiniMapIconMouseClick;

		public Action<CompassProPOI> OnPOIVisibleInMiniMap;

		public Action<CompassProPOI> OnPOIHidesInMiniMap;

		public Action<bool> OnMiniMapChangeFullScreenState;

		public Action<Vector3, int> OnMiniMapMouseClick;

		public Action<Vector2> OnMiniMapMouseEnter;

		public Action<Vector2> OnMiniMapMouseExit;

		public Action OnMiniMapBeforeCapture;

		public Action OnMiniMapAfterCapture;

		public Action<CompassProPOI> OnPOIOnScreen;

		public Action<CompassProPOI> OnPOIOffScreen;

		[Tooltip("Enables fog of war system")]
		[SerializeField]
		private bool _fogOfWarEnabled;

		[Tooltip("Center of the fog of war layer (only X/Z coordinates are used)")]
		[SerializeField]
		private Vector3 _fogOfWarCenter;

		[Tooltip("Size of the fog of war layer (only X/Z coordinates are used)")]
		[SerializeField]
		private Vector3 _fogOfWarSize = new Vector3(1024f, 0f, 1024f);

		[Tooltip("Resolution for the fog of war texture effect")]
		[SerializeField]
		[Range(32f, 2048f)]
		private int _fogOfWarTextureSize = 256;

		[SerializeField]
		private Color _fogOfWarColor = new Color(0.18431373f, 0.18431373f, 0.18431373f);

		[Tooltip("Clears fog automatically as player crosses it")]
		[SerializeField]
		private bool _fogOfWarAutoClear;

		[SerializeField]
		private float _fogOfWarAutoClearRadius = 20f;

		[Tooltip("Default alpha value of fog of war in the scene")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _fogOfWarDefaultAlpha = 1f;

		[Tooltip("Shows the minimap")]
		[SerializeField]
		private bool _showMiniMap;

		[SerializeField]
		private MiniMapPositionAndScaleMode _miniMapPositionAndSize;

		[SerializeField]
		private MiniMapPosition _miniMapLocation = MiniMapPosition.BottomRight;

		[Tooltip("POIs beyond visible distance (meters) will not be shown in the compass bar")]
		[SerializeField]
		private float _miniMapVisibleMaxDistance = 10000f;

		[SerializeField]
		private Vector2 _miniMapScreenPositionOffset = new Vector2(-5f, 5f);

		[Tooltip("Keeps the mini-map oriented to North")]
		[SerializeField]
		private bool _miniMapKeepStraight;

		[Tooltip("Orientation of the mini-map")]
		[SerializeField]
		private MiniMapOrientation _miniMapOrientation;

		[Tooltip("Rotation of the mini-map camera")]
		[SerializeField]
		[Range(0f, 90f)]
		private float _miniMapCameraTilt;

		[Tooltip("Screen size of mini-map in % of screen height")]
		[SerializeField]
		private float _miniMapSize = 0.35f;

		private Vector3 _miniMapFollowOffset;

		[Tooltip("Mask for the border of the mini map")]
		[SerializeField]
		private Sprite _miniMapMaskSprite;

		[Tooltip("Texture for the border of the mini map")]
		[SerializeField]
		private Texture2D _miniMapBorderTexture;

		[Tooltip("Mini-map style")]
		[SerializeField]
		private MiniMapStyle _miniMapStyle;

		[SerializeField]
		private Color _miniMapBackgroundColor = Color.black;

		[SerializeField]
		private bool _miniMapBackgroundOpaque;

		[Tooltip("What to show when minimap is non full screen mode")]
		[SerializeField]
		private MiniMapContents _miniMapContents;

		[Tooltip("The texture to be used as background for the minimap in non full screen mode")]
		[SerializeField]
		private Texture _miniMapContentsTexture;

		[Tooltip("Allows rotation of the UI texture")]
		[SerializeField]
		private bool _miniMapContentsTextureAllowRotation;

		[Tooltip("Mask for the border of the mini map in full screen mode")]
		[SerializeField]
		private Sprite _miniMapMaskSpriteFullScreenMode;

		[Tooltip("Texture for the border of the mini map in full screen mode")]
		[SerializeField]
		private Texture2D _miniMapBorderTextureFullScreenMode;

		[Tooltip("Mini-map style in full screen mode")]
		[SerializeField]
		private MiniMapStyle _miniMapFullScreenStyle = MiniMapStyle.SolidBox;

		[Tooltip("Size of the mini-map render texture in non-full screen mode")]
		[SerializeField]
		private MiniMapResolution _miniMapResolution = MiniMapResolution._512;

		[Tooltip("Size of the render texture in full screen mode")]
		[SerializeField]
		private MiniMapResolution _miniMapFullScreenResolution = MiniMapResolution._1024;

		[Tooltip("The zoom level used for the mini-map in full screen mode")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _miniMapFullScreenZoomLevel = 1f;

		[Tooltip("Optional UI element which serves as placeholder for exact positioning of the mini-map in fullscreen mode")]
		[SerializeField]
		private RectTransform _miniMapFullScreenPlaceholder;

		[Tooltip("The distance of clamped icons to the edge of the mini-map in full screen mode")]
		[SerializeField]
		private float _miniMapFullScreenClampBorder = 0.02f;

		[Tooltip("Enable this option if the minimap uses a circular shape in full screen mode")]
		[SerializeField]
		private bool _miniMapFullScreenClampBorderCircular;

		[Tooltip("Percentage of screen size if full-screen mode. Image resolution will increase according to screen resolution")]
		[Range(0.5f, 1f)]
		[SerializeField]
		private float _miniMapFullScreenSize = 0.9f;

		[Tooltip("What to show when minimap is in full screen mode")]
		[SerializeField]
		private MiniMapContents _miniMapFullScreenContents;

		[Tooltip("The texture to be used as background for the minimap in full screen mode.")]
		[SerializeField]
		private Texture _miniMapFullScreenContentsTexture;

		[Tooltip("Keep aspect ration in full screen mode")]
		[SerializeField]
		private bool _miniMapKeepAspectRatio = true;

		[Tooltip("Allow user to drag the map around")]
		[SerializeField]
		private bool _miniMapAllowUserDrag;

		[Tooltip("Allow user to drag the map around in full screen mode")]
		[SerializeField]
		private bool _miniMapFullScreenAllowUserDrag;

		[Tooltip("Reset drag offset when user ends dragging")]
		[SerializeField]
		private bool _miniMapAutoResetDrag;

		[Tooltip("Reset drag offset when user ends dragging in full screen mode")]
		[SerializeField]
		private bool _miniMapFullScreenAutoResetDrag;

		[SerializeField]
		[Tooltip("Maximum allowed drag distance")]
		private float _miniMapDragMaxDistance = 1000f;

		[SerializeField]
		[Tooltip("Maximum allowed drag distance in full screen mode")]
		private float _miniMapFullScreenDragMaxDistance = 1000f;

		[Tooltip("Orthographic or perspective mode for the mini-map camera")]
		[SerializeField]
		private MiniMapCameraMode _miniMapCameraMode = MiniMapCameraMode.Orthographic;

		[Tooltip("Frequency of camera capture")]
		[SerializeField]
		private MiniMapCameraSnapshotFrequency _miniMapCameraSnapshotFrequency = MiniMapCameraSnapshotFrequency.DistanceTravelled;

		[Tooltip("The orthographic size of the mini-map camera")]
		[SerializeField]
		private float _miniMapCaptureSize = 256f;

		[SerializeField]
		private float _miniMapSnapshotInterval = 10f;

		[Tooltip("Distance in meters")]
		[SerializeField]
		private float _miniMapSnapshotDistance = 10f;

		[Tooltip("Contrast of the mini-map image")]
		[Range(0f, 2f)]
		[SerializeField]
		private float _miniMapContrast = 1.02f;

		[Tooltip("Brightness of the mini-map image")]
		[Range(0f, 2f)]
		[SerializeField]
		private float _miniMapBrightness = 1.05f;

		[Tooltip("Tint color for the mini-map. Alpha controls the intensity.")]
		[SerializeField]
		private Color _miniMapTintColor = new Color(1f, 1f, 1f, 0f);

		[Tooltip("Enable to render shadows in mini-map")]
		[SerializeField]
		private bool _miniMapEnableShadows;

		[SerializeField]
		[Range(0f, 1f)]
		private float _miniMapZoomMin = 0.01f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _miniMapZoomMax = 1f;

		[SerializeField]
		private GameObject _miniMapIconPrefab;

		[Tooltip("Optional displacement for the icons in the mini-map")]
		[SerializeField]
		private Vector2 _miniMapIconPositionShift;

		[Tooltip("The current zoom for the mini-map based on the minimum / maximum ranges")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _miniMapZoomLevel = 0.5f;

		[Tooltip("The minimum altitude of the mini-map camera respect with the follow target")]
		[SerializeField]
		private float _miniMapCameraMinAltitude = 10f;

		[Tooltip("The maximum altitude of the mini-map camera respect with the follow target")]
		[SerializeField]
		private float _miniMapCameraMaxAltitude = 100f;

		[Tooltip("The altitude of the mini-map camera relative to the main camera or followed gameobject")]
		[SerializeField]
		private float _miniMapCameraHeightVSFollow = 200f;

		[Tooltip("How far will capture the mini-map camera from the top-down position (this is the far clip plane of the mini-map camera).")]
		[SerializeField]
		private float _miniMapCameraDepth = 1000f;

		[Tooltip("Which objects will be visible in the mini-map")]
		[SerializeField]
		private LayerMask _miniMapLayerMask = -1;

		[Tooltip("The size for the icons on the mini-map")]
		[SerializeField]
		private float _miniMapIconSize = 0.5f;

		[Tooltip("Enables player/compass icon on the mini-map")]
		[SerializeField]
		private bool _miniMapShowPlayerIcon = true;

		[Tooltip("The size for the player icon on the mini-map")]
		[SerializeField]
		private float _miniMapPlayerIconSize = 1f;

		[Tooltip("The sprite for the player icon")]
		[SerializeField]
		private Sprite _miniMapPlayerIconSprite;

		[Tooltip("The color for the player icon")]
		[SerializeField]
		private Color _miniMapPlayerIconColor = Color.white;

		[Tooltip("Enables North icon on the mini-map")]
		[SerializeField]
		private bool _miniMapShowCardinals = true;

		[Tooltip("The size for the North icon on the mini-map")]
		[SerializeField]
		private float _miniMapCardinalsSize = 1f;

		[Tooltip("The sprite for the mini-map cardinals")]
		[SerializeField]
		private Sprite _miniMapCardinalsSprite;

		[Tooltip("The tint color for the mini-map cardinals")]
		[SerializeField]
		private Color _miniMapCardinalsColor = Color.white;

		[Tooltip("Enables view cone on the mini-map")]
		[SerializeField]
		private bool _miniMapShowViewCone = true;

		[Tooltip("Color of the view cone")]
		[SerializeField]
		private Color _miniMapViewConeColor = new Color(1f, 1f, 1f, 0.25f);

		[SerializeField]
		private MiniMapViewConeFovSource _miniMapViewConeFoVSource;

		[SerializeField]
		[Range(0f, 360f)]
		private float _miniMapViewConeFoV = 60f;

		[Tooltip("Distance of the view cone")]
		[SerializeField]
		private float _miniMapViewConeDistance = 150f;

		[Tooltip("Fall-off/gradient for the view cone effect")]
		[SerializeField]
		[Range(0.0001f, 1f)]
		private float _miniMapViewConeFallOff = 0.75f;

		[Tooltip("Enables view cone outline")]
		[SerializeField]
		private bool _miniMapShowViewConeOutline;

		[Tooltip("Color of the view cone outline")]
		[SerializeField]
		private Color _miniMapViewConeOutlineColor = new Color(1f, 1f, 1f, 0.5f);

		[Tooltip("The distance of clamped icons to the edge of the mini-map")]
		[SerializeField]
		private float _miniMapClampBorder = 0.02f;

		[Tooltip("Enable this option if the minimap uses a circular shape")]
		[SerializeField]
		private bool _miniMapClampBorderCircular;

		[Tooltip("Enable this option if the minimap uses a circular shape and want to darken the inner border.")]
		[SerializeField]
		private bool _miniMapVignette;

		[Tooltip("Transparency of the mini-map")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _miniMapAlpha = 1f;

		[Tooltip("Show the zoom in/out minimap button")]
		[SerializeField]
		private bool _miniMapShowZoomInOutButtons;

		[SerializeField]
		[Range(0.001f, 10f)]
		private float _miniMapIconCircleAnimationDuration = 1f;

		[Tooltip("Show the maximize minimap button.")]
		[SerializeField]
		private bool _miniMapShowMaximizeButton;

		[Range(0.01f, 2f)]
		[SerializeField]
		private float _miniMapButtonsScale = 1f;

		[Tooltip("Raise pointer click, down, up, enter and exit events on icons")]
		[SerializeField]
		private bool _miniMapIconEvents;

		[Tooltip("Displays the distance to each ring")]
		[SerializeField]
		private MiniMapRadarInfoType _miniMapRadarInfoDisplay = MiniMapRadarInfoType.RingIntervalDistance;

		[Tooltip("Method used to render radar graphics")]
		[SerializeField]
		private MiniMapRadarGraphicsMethod _miniMapRadarGraphicsMethod;

		[SerializeField]
		private Color _miniMapRadarRingsColor = Color.white;

		[SerializeField]
		private float _miniMapRadarRingsDistance = 10f;

		[Range(0.01f, 4f)]
		[SerializeField]
		private float _miniMapRadarRingsWidth = 1f;

		[SerializeField]
		private bool _miniMapRadarPulseEnabled = true;

		[SerializeField]
		private MiniMapPulsePreset _miniMapRadarPulseAnimationPreset;

		[Range(0f, 1f)]
		[SerializeField]
		private float _miniMapRadarPulseOpacity = 0.25f;

		[SerializeField]
		private float _miniMapRadarPulseFrequency = 0.1f;

		[SerializeField]
		private float _miniMapRadarPulseFallOff = 50f;

		[SerializeField]
		private float _miniMapRadarPulseSpeed = 50f;

		[SerializeField]
		private bool _miniMapRadarFadePOIs = true;

		[SerializeField]
		private bool _miniMapFullScreenState;

		[SerializeField]
		private Vector3 _miniMapFullScreenWorldCenter;

		[SerializeField]
		private Vector3 _miniMapFullScreenWorldSize = new Vector3(1000f, 0f, 1000f);

		[Tooltip("Forces center of the world map to be the same position of the followed object")]
		public bool miniMapFullScreenWorldCenterFollows = true;

		[Tooltip("Prevents user move or rotate camera while in maximized mode")]
		public bool miniMapFullScreenFreezeCamera = true;

		[Tooltip("Ensures the map doesn't scroll beyond world size in maximized mode")]
		public bool miniMapFullScreenClampToWorldEdges = true;

		[Tooltip("Ensures the map doesn't scroll beyond world size in non-maximized mode")]
		public bool miniMapClampToWorldEdges;

		[Tooltip("Center of the world map")]
		[SerializeField]
		private Vector3 _miniMapWorldCenter;

		[Tooltip("Size of the world map")]
		[SerializeField]
		private Vector3 _miniMapWorldSize = new Vector3(1000f, 0f, 1000f);

		[SerializeField]
		[Range(0f, 1f)]
		private float _miniMapLutIntensity = 1f;

		[SerializeField]
		private Texture2D _miniMapLutTexture;

		[SerializeField]
		private Color _miniMapVignetteColor = new Color(0f, 0f, 0f, 0.5f);

		private readonly int[] cardinals = new int[4] { 0, 2, 4, 6 };

		private readonly int[] ordinals = new int[4] { 1, 3, 5, 7 };

		private const string SAMPLE_TITLE_TEXT = "SAMPLE TITLE";

		private const int TEXT_POOL_SIZE = 256;

		private const string TEXT_POOL_OBJECT_NAME = "CompassProTextPool";

		[NonSerialized]
		public readonly List<CompassProPOI> pois = new List<CompassProPOI>();

		private static readonly List<CompassPro> compasses = new List<CompassPro>();

		private static CompassPro _instance;

		private float fadeStartTime;

		private float prevAlpha;

		private CanvasGroup canvasGroup;

		private RectTransform compassBackRT;

		private Image compassBackImage;

		private Text text;

		private Text textShadow;

		private Text title;

		private Text titleShadow;

		private TextMeshProUGUI titleTMP;

		private float endTimeOfCurrentTextReveal;

		private Vector3 lastCamPos;

		private Quaternion lastCamRot;

		private int lastUpdateFrameCount;

		private float lastUpdateTime;

		private readonly StringBuilder titleText = new StringBuilder();

		private RectTransform titleRT;

		private RectTransform titleShadowRT;

		private RectTransform titleTMPRT;

		private Vector3 titleRTDefaultPosition;

		private Vector3 titleShadowRTDefaultPosition;

		private AudioSource audioSource;

		private int poiVisibleCount;

		private bool autoHiding;

		private float thisAlpha;

		private bool needUpdateCompassBarIcons;

		private CompassPointPOI[] compassPoints;

		private float usedNorthDegrees;

		private LetterAnimator[] textPool;

		private Vector3 textPoolOriginalLocalPosition;

		private Vector3 textPoolOriginalShadowLocalPosition;

		private int poolIndex;

		private Transform canvasTextPool;

		private Canvas _canvas;

		private CompassProPOI lastNearestPOI;

		private string lastNearestPOIDistanceText;

		private float lastNearestPOIDistance;

		private float nearestPOIDistance;

		private float nearestPOIAlpha;

		private Vector3 currentCamPos;

		private Quaternion currentCamRot;

		private Matrix4x4 currentCamVP;

		private Vector3 followPos;

		private bool needsUpdateSettings;

		private Vector3 lastVisitedDistanceFollowPos;

		private Transform indicatorsRoot;

		private Material compassBarMat;

		private Material curvedMat;

		private Material defaultUICurvedMatForCardinals;

		private Material defaultUICurvedMatForText;

		[NonSerialized]
		public bool needFogOfWarUpdate;

		[NonSerialized]
		public bool needFogOfWarTextureUpdate;

		private const string FOG_OF_WAR_LAYER = "FogOfWarLayer";

		private Texture2D fogOfWarTexture;

		private Color32[] fogOfWarColorBuffer;

		private Material fogOfWarMaterial;

		private int fogOfWarAutoClearLastPosX = int.MaxValue;

		private int fogOfWarAutoClearLastPosZ;

		private const string INDICATORS_ROOT_NAME = "OnScreen Indicators Root";

		private const int MAX_STORED_VPOS = 100;

		private readonly Vector3[] lastVPos = new Vector3[100];

		private bool needUpdateIndicators;

		[NonSerialized]
		public Camera miniMapCamera;

		private bool needUpdateMiniMapIcons;

		private Transform miniMapMaskUI;

		private Transform miniMapButtonsPanel;

		private RectTransform miniMapUI;

		private RectTransform miniMapUIRootRT;

		private Transform playerIcon;

		private Transform miniMapCardinalsRT;

		private RectTransform playerIconRT;

		private Image playerIconImage;

		private Image miniMapCardinalsImage;

		private RenderTexture miniMapTex;

		private CanvasGroup miniMapCanvasGroup;

		private Material miniMapOverlayMat;

		private Vector2 miniMapAnchorMin;

		private Vector2 miniMapAnchorMax;

		private Vector2 miniMapPivot;

		private Vector2 miniMapSizeDelta;

		private float miniMapCameraAspect;

		private float miniMapLastSnapshotTime;

		private Vector3 miniMapLastSnapshotLocation;

		private int needMiniMapShot;

		private Image miniMapImage;

		private Image miniMapMaskImage;

		private Quaternion miniMapFullScreenFixedCameraRotation;

		private Vector3 miniMapFullScreenFixedCameraPosition;

		private bool needsSetupMiniMap;

		private bool needsIconSorting;

		private float miniMapRegularZoomLevel;

		private float lastViewConeCameraAspect;

		private float lastViewConeFoV;

		private Vector4 viewConeData;

		private TextMeshProUGUI ringsDistanceText;

		private float lastRadarInfoDistance;

		private Vector3 miniMapCenter;

		public Camera cameraMain
		{
			get
			{
				if (_cameraMain == null)
				{
					_cameraMain = FindSuitableCamera();
				}
				return _cameraMain;
			}
			set
			{
				if (_cameraMain != value)
				{
					_cameraMain = value;
					Refresh();
				}
			}
		}

		public Transform follow
		{
			get
			{
				return _follow;
			}
			set
			{
				if (_follow != value)
				{
					_follow = value;
					Refresh();
				}
			}
		}

		public UpdateMode updateMode
		{
			get
			{
				return _updateMode;
			}
			set
			{
				if (value != _updateMode)
				{
					_updateMode = value;
				}
			}
		}

		public int updateIntervalFrameCount
		{
			get
			{
				return _updateIntervalFrameCount;
			}
			set
			{
				if (value != _updateIntervalFrameCount)
				{
					_updateIntervalFrameCount = value;
				}
			}
		}

		public float updateIntervalTime
		{
			get
			{
				return _updateIntervalTime;
			}
			set
			{
				if (value != _updateIntervalTime)
				{
					_updateIntervalTime = value;
				}
			}
		}

		public bool hideIfNoCamera
		{
			get
			{
				return _hideIfNoCamera;
			}
			set
			{
				if (value != _showCompassBar)
				{
					_hideIfNoCamera = value;
				}
			}
		}

		public bool showCompassBar
		{
			get
			{
				return _showCompassBar;
			}
			set
			{
				if (value != _showCompassBar)
				{
					_showCompassBar = value;
					UpdateCompassBarAppearance();
					UpdateCompassBarAlpha();
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public CompassStyle style
		{
			get
			{
				return _style;
			}
			set
			{
				if (value != _style)
				{
					_style = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public Sprite compassBackSprite
		{
			get
			{
				return _compassBackSprite;
			}
			set
			{
				if (value != _compassBackSprite)
				{
					_compassBackSprite = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public bool compassBackSpriteScrollable
		{
			get
			{
				return _compassBackSpriteScrollable;
			}
			set
			{
				if (value != _compassBackSpriteScrollable)
				{
					_compassBackSpriteScrollable = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public float compassBackSpriteScrollOffset
		{
			get
			{
				return _compassBackSpriteScrollOffset;
			}
			set
			{
				if (value != _compassBackSpriteScrollOffset)
				{
					_compassBackSpriteScrollOffset = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public Color compassTintColor
		{
			get
			{
				return _compassTintColor;
			}
			set
			{
				if (value != _compassTintColor)
				{
					_compassTintColor = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public float northDegrees
		{
			get
			{
				return _northDegrees;
			}
			set
			{
				if (value != _northDegrees)
				{
					_northDegrees = value;
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public float visibleMaxDistance
		{
			get
			{
				return _visibleMaxDistance;
			}
			set
			{
				if (value != _visibleMaxDistance)
				{
					_visibleMaxDistance = value;
				}
			}
		}

		public float visibleMinDistance
		{
			get
			{
				return _visibleMinDistance;
			}
			set
			{
				if (value != _visibleMinDistance)
				{
					_visibleMinDistance = value;
				}
			}
		}

		public float titleMinPOIDistance
		{
			get
			{
				return _titleMinPOIDistance;
			}
			set
			{
				if (value != _titleMinPOIDistance)
				{
					_titleMinPOIDistance = value;
				}
			}
		}

		public float nearDistance
		{
			get
			{
				return _nearDistance;
			}
			set
			{
				if (value != _nearDistance)
				{
					_nearDistance = value;
				}
			}
		}

		public float visitedDistance
		{
			get
			{
				return _visitedDistance;
			}
			set
			{
				if (value != _visitedDistance)
				{
					_visitedDistance = value;
				}
			}
		}

		public bool showOnScreenIndicators
		{
			get
			{
				return _showOnScreenIndicators;
			}
			set
			{
				if (value != _showOnScreenIndicators)
				{
					_showOnScreenIndicators = value;
				}
			}
		}

		public GameObject compassIconPrefab
		{
			get
			{
				return _compassIconPrefab;
			}
			set
			{
				if (value != _compassIconPrefab)
				{
					_compassIconPrefab = value;
				}
			}
		}

		public GameObject onScreenIndicatorPrefab
		{
			get
			{
				return _onScreenIndicatorPrefab;
			}
			set
			{
				if (value != _onScreenIndicatorPrefab)
				{
					_onScreenIndicatorPrefab = value;
				}
			}
		}

		public float onScreenIndicatorAlpha
		{
			get
			{
				return onScreenIndicatorAlpha;
			}
			set
			{
				if (value != _onScreenIndicatorAlpha)
				{
					_onScreenIndicatorAlpha = value;
				}
			}
		}

		public float onScreenIndicatorScale
		{
			get
			{
				return _onScreenIndicatorScale;
			}
			set
			{
				if (value != _onScreenIndicatorScale)
				{
					_onScreenIndicatorScale = value;
				}
			}
		}

		public float onScreenIndicatorFarDistance
		{
			get
			{
				return _onScreenIndicatorFarDistance;
			}
			set
			{
				if (value != _onScreenIndicatorFarDistance)
				{
					_onScreenIndicatorFarDistance = value;
				}
			}
		}

		public float onScreenIndicatorNearFadeDistance
		{
			get
			{
				return _onScreenIndicatorNearFadeDistance;
			}
			set
			{
				if (value != _onScreenIndicatorNearFadeDistance)
				{
					_onScreenIndicatorNearFadeDistance = value;
				}
			}
		}

		public float onScreenIndicatorNearFadeMin
		{
			get
			{
				return _onScreenIndicatorNearFadeMin;
			}
			set
			{
				if (value != _onScreenIndicatorNearFadeMin)
				{
					_onScreenIndicatorNearFadeMin = value;
				}
			}
		}

		public bool onScreenIndicatorShowDistance
		{
			get
			{
				return _onScreenIndicatorShowDistance;
			}
			set
			{
				if (value != _onScreenIndicatorShowDistance)
				{
					_onScreenIndicatorShowDistance = value;
				}
			}
		}

		public string onScreenIndicatorShowDistanceFormat
		{
			get
			{
				return _onScreenIndicatorShowDistanceFormat;
			}
			set
			{
				if (value != _onScreenIndicatorShowDistanceFormat)
				{
					_onScreenIndicatorShowDistanceFormat = value;
				}
			}
		}

		public bool onScreenIndicatorShowTitle
		{
			get
			{
				return _onScreenIndicatorShowTitle;
			}
			set
			{
				if (value != _onScreenIndicatorShowTitle)
				{
					_onScreenIndicatorShowTitle = value;
				}
			}
		}

		public bool showOffScreenIndicators
		{
			get
			{
				return _showOffScreenIndicators;
			}
			set
			{
				if (value != _showOffScreenIndicators)
				{
					_showOffScreenIndicators = value;
				}
			}
		}

		public float offScreenIndicatorScale
		{
			get
			{
				return _offScreenIndicatorScale;
			}
			set
			{
				if (value != _offScreenIndicatorScale)
				{
					_offScreenIndicatorScale = value;
				}
			}
		}

		public float offScreenIndicatorMargin
		{
			get
			{
				return _offScreenIndicatorMargin;
			}
			set
			{
				if (value != _offScreenIndicatorMargin)
				{
					_offScreenIndicatorMargin = value;
				}
			}
		}

		public Rect offScreenIndicatorRect
		{
			get
			{
				return _offScreenIndicatorRect;
			}
			set
			{
				if (value != _offScreenIndicatorRect)
				{
					_offScreenIndicatorRect = value;
				}
			}
		}

		public bool offScreenIndicatorAvoidOverlap
		{
			get
			{
				return _offScreenIndicatorAvoidOverlap;
			}
			set
			{
				if (value != _offScreenIndicatorAvoidOverlap)
				{
					_offScreenIndicatorAvoidOverlap = value;
				}
			}
		}

		public float offScreenIndicatorOverlapDistance
		{
			get
			{
				return _offScreenIndicatorOverlapDistance;
			}
			set
			{
				if (value != _offScreenIndicatorOverlapDistance)
				{
					_offScreenIndicatorOverlapDistance = value;
				}
			}
		}

		public float offScreenIndicatorAlpha
		{
			get
			{
				return _offScreenIndicatorAlpha;
			}
			set
			{
				if (value != _offScreenIndicatorAlpha)
				{
					_offScreenIndicatorAlpha = value;
				}
			}
		}

		public float alpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				if (value != _alpha)
				{
					_alpha = value;
					UpdateCompassBarAlpha();
				}
			}
		}

		public bool autoHide
		{
			get
			{
				return _autoHide;
			}
			set
			{
				if (value != _autoHide)
				{
					_autoHide = value;
				}
			}
		}

		public float fadeDuration
		{
			get
			{
				return _fadeDuration;
			}
			set
			{
				if (value != _fadeDuration)
				{
					_fadeDuration = value;
				}
			}
		}

		public bool alwaysVisibleInEditMode
		{
			get
			{
				return _alwaysVisibleInEditMode;
			}
			set
			{
				if (value != _alwaysVisibleInEditMode)
				{
					_alwaysVisibleInEditMode = value;
					UpdateCompassBarAlpha();
				}
			}
		}

		public float verticalPosition
		{
			get
			{
				return _verticalPosition;
			}
			set
			{
				if (value != _verticalPosition)
				{
					_verticalPosition = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public float horizontalPosition
		{
			get
			{
				return _horizontalPosition;
			}
			set
			{
				if (value != _horizontalPosition)
				{
					_horizontalPosition = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public float bendAmount
		{
			get
			{
				return _bendAmount;
			}
			set
			{
				if (value != _bendAmount)
				{
					_bendAmount = value;
					if (_bendAmount == 0f)
					{
						_verticalPosition = 0.94f;
					}
					UpdateCompassBarAppearance();
					UpdateTitleAppearance();
				}
			}
		}

		public float width
		{
			get
			{
				return _width;
			}
			set
			{
				if (value != _width)
				{
					_width = value;
					UpdateCompassBarAppearance();
					UpdateHalfWindsAppearance();
				}
			}
		}

		public float height
		{
			get
			{
				return _height;
			}
			set
			{
				if (value != _height)
				{
					_height = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public bool edgeFadeOut
		{
			get
			{
				return _edgeFadeOut;
			}
			set
			{
				if (value != _edgeFadeOut)
				{
					_edgeFadeOut = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public bool edgeFadeOutText
		{
			get
			{
				return _edgeFadeOutText;
			}
			set
			{
				if (value != _edgeFadeOutText)
				{
					_edgeFadeOutText = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public float edgeFadeOutWidth
		{
			get
			{
				return _edgeFadeOutWidth;
			}
			set
			{
				if (value != _edgeFadeOutWidth)
				{
					_edgeFadeOutWidth = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public float edgeFadeOutStart
		{
			get
			{
				return _edgeFadeOutStart;
			}
			set
			{
				if (value != _edgeFadeOutStart)
				{
					_edgeFadeOutStart = value;
					UpdateCompassBarAppearance();
				}
			}
		}

		public float endCapsWidth
		{
			get
			{
				return _endCapsWidth;
			}
			set
			{
				if (value != _endCapsWidth)
				{
					_endCapsWidth = value;
					UpdateCompassBarAppearance();
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public bool showCardinalPoints
		{
			get
			{
				return _showCardinalPoints;
			}
			set
			{
				if (value != _showCardinalPoints)
				{
					_showCardinalPoints = value;
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public bool showOrdinalPoints
		{
			get
			{
				return _showOrdinalPoints;
			}
			set
			{
				if (value != _showOrdinalPoints)
				{
					_showOrdinalPoints = value;
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public float cardinalScale
		{
			get
			{
				return _cardinalScale;
			}
			set
			{
				if (value != _cardinalScale)
				{
					_cardinalScale = value;
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public float ordinalScale
		{
			get
			{
				return _ordinalScale;
			}
			set
			{
				if (value != _ordinalScale)
				{
					_ordinalScale = value;
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public float cardinalPointsVerticalOffset
		{
			get
			{
				return _cardinalPointsVerticalOffset;
			}
			set
			{
				if (value != _cardinalPointsVerticalOffset)
				{
					_cardinalPointsVerticalOffset = value;
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public bool showHalfWinds
		{
			get
			{
				return _showHalfWinds;
			}
			set
			{
				if (value != _showHalfWinds)
				{
					_showHalfWinds = value;
					UpdateHalfWindsAppearance();
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public float halfWindsHeight
		{
			get
			{
				return _halfWindsHeight;
			}
			set
			{
				if (value != _halfWindsHeight)
				{
					_halfWindsHeight = value;
					UpdateHalfWindsAppearance();
				}
			}
		}

		public float halfWindsWidth
		{
			get
			{
				return _halfWindsWidth;
			}
			set
			{
				if (value != _halfWindsWidth)
				{
					_halfWindsWidth = value;
					UpdateHalfWindsAppearance();
				}
			}
		}

		public float halfWindsInterval
		{
			get
			{
				return _halfWindsInterval;
			}
			set
			{
				if (value != _halfWindsInterval)
				{
					_halfWindsInterval = value;
					UpdateHalfWindsAppearance();
				}
			}
		}

		public Color halfWindsTintColor
		{
			get
			{
				return _halfWindsTintColor;
			}
			set
			{
				if (value != _halfWindsTintColor)
				{
					_halfWindsTintColor = value;
					UpdateHalfWindsAppearance();
				}
			}
		}

		public float labelHotZone
		{
			get
			{
				return _labelHotZone;
			}
			set
			{
				if (value != _labelHotZone)
				{
					_labelHotZone = value;
				}
			}
		}

		public float maxIconSize
		{
			get
			{
				return _maxIconSize;
			}
			set
			{
				if (value != _maxIconSize)
				{
					_maxIconSize = value;
				}
			}
		}

		public float minIconSize
		{
			get
			{
				return _minIconSize;
			}
			set
			{
				if (value != _minIconSize)
				{
					_minIconSize = value;
				}
			}
		}

		public float scaleInDuration
		{
			get
			{
				return _scaleInDuration;
			}
			set
			{
				if (value != _scaleInDuration)
				{
					_scaleInDuration = value;
				}
			}
		}

		public CompassProPOI focusedPOI
		{
			get
			{
				return _focusedPOI;
			}
			set
			{
				if (value != _focusedPOI)
				{
					_focusedPOI = value;
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public WorldMappingMode worldMappingMode
		{
			get
			{
				return _worldMappingMode;
			}
			set
			{
				if (value != _worldMappingMode)
				{
					_worldMappingMode = value;
					UpdateHalfWindsAppearance();
					UpdateCompassBarAppearance();
					needUpdateCompassBarIcons = true;
				}
			}
		}

		public float textVerticalPosition
		{
			get
			{
				return _textVerticalPosition;
			}
			set
			{
				if (value != _textVerticalPosition)
				{
					_textVerticalPosition = value;
					UpdateTextAppearanceEditMode();
				}
			}
		}

		public float textScale
		{
			get
			{
				return _textScale;
			}
			set
			{
				if (value != _textScale)
				{
					_textScale = value;
					UpdateTextAppearanceEditMode();
				}
			}
		}

		public float textLetterSpacing
		{
			get
			{
				return _textLetterSpacing;
			}
			set
			{
				if (value != _textLetterSpacing)
				{
					_textLetterSpacing = value;
				}
			}
		}

		public bool textRevealEnabled
		{
			get
			{
				return _textRevealEnabled;
			}
			set
			{
				if (value != _textRevealEnabled)
				{
					_textRevealEnabled = value;
				}
			}
		}

		public float textRevealDuration
		{
			get
			{
				return _textRevealDuration;
			}
			set
			{
				if (value != _textRevealDuration)
				{
					_textRevealDuration = value;
				}
			}
		}

		public float textRevealLetterDelay
		{
			get
			{
				return _textRevealLetterDelay;
			}
			set
			{
				if (value != _textRevealLetterDelay)
				{
					_textRevealLetterDelay = value;
				}
			}
		}

		public float textDuration
		{
			get
			{
				return _textDuration;
			}
			set
			{
				if (value != _textDuration)
				{
					_textDuration = value;
				}
			}
		}

		public float textFadeOutDuration
		{
			get
			{
				return _textFadeOutDuration;
			}
			set
			{
				if (value != _textFadeOutDuration)
				{
					_textFadeOutDuration = value;
				}
			}
		}

		public bool textShadowEnabled
		{
			get
			{
				return _textShadowEnabled;
			}
			set
			{
				if (value != _textShadowEnabled)
				{
					_textShadowEnabled = value;
					if (!Application.isPlaying)
					{
						UpdateTextAppearanceEditMode();
					}
				}
			}
		}

		public Font textFont
		{
			get
			{
				if (_textFont == null)
				{
					_textFont = Resources.Load<Font>("CNPro/Fonts/Vollkorn-Regular");
				}
				return _textFont;
			}
			set
			{
				if (value != _textFont)
				{
					_textFont = value;
					UpdateTextAppearanceEditMode();
				}
			}
		}

		public float titleVerticalPosition
		{
			get
			{
				return _titleVerticalPosition;
			}
			set
			{
				if (value != _titleVerticalPosition)
				{
					_titleVerticalPosition = value;
					UpdateTitleAppearanceEditMode();
				}
			}
		}

		public float titleScale
		{
			get
			{
				return _titleScale;
			}
			set
			{
				if (value != _titleScale)
				{
					_titleScale = value;
					UpdateTitleAppearanceEditMode();
				}
			}
		}

		public Font titleFont
		{
			get
			{
				return _titleFont;
			}
			set
			{
				if (value != _titleFont)
				{
					_titleFont = value;
					UpdateTitleAppearanceEditMode();
				}
			}
		}

		public bool titleShadowEnabled
		{
			get
			{
				return _titleShadowEnabled;
			}
			set
			{
				if (value != _titleShadowEnabled)
				{
					_titleShadowEnabled = value;
					if (!Application.isPlaying)
					{
						UpdateTitleAppearanceEditMode();
					}
				}
			}
		}

		public TMP_FontAsset titleFontTMP
		{
			get
			{
				return _titleFontTMP;
			}
			set
			{
				if (value != _titleFontTMP)
				{
					_titleFontTMP = value;
					UpdateTitleAppearanceEditMode();
				}
			}
		}

		public bool titleShowDistance
		{
			get
			{
				return _titleShowDistance;
			}
			set
			{
				if (value != _titleShowDistance)
				{
					_titleShowDistance = value;
				}
			}
		}

		public string titleShowDistanceFormat
		{
			get
			{
				return _titleShowDistanceFormat;
			}
			set
			{
				if (value != _titleShowDistanceFormat)
				{
					_titleShowDistanceFormat = value;
				}
			}
		}

		public bool use3Ddistance
		{
			get
			{
				return _use3Ddistance;
			}
			set
			{
				if (value != _use3Ddistance)
				{
					_use3Ddistance = value;
				}
			}
		}

		public float sameAltitudeThreshold
		{
			get
			{
				return _sameAltitudeThreshold;
			}
			set
			{
				if (value != _sameAltitudeThreshold)
				{
					_sameAltitudeThreshold = value;
				}
			}
		}

		public bool showDistance
		{
			get
			{
				return _showDistance;
			}
			set
			{
				if (value != _showDistance)
				{
					_showDistance = value;
				}
			}
		}

		public string showDistanceFormat
		{
			get
			{
				return _showDistanceFormat;
			}
			set
			{
				if (value != _showDistanceFormat)
				{
					_showDistanceFormat = value;
				}
			}
		}

		public AudioClip visitedDefaultAudioClip
		{
			get
			{
				return _visitedDefaultAudioClip;
			}
			set
			{
				if (value != _visitedDefaultAudioClip)
				{
					_visitedDefaultAudioClip = value;
				}
			}
		}

		public AudioClip beaconDefaultAudioClip
		{
			get
			{
				return _beaconDefaultAudioClip;
			}
			set
			{
				if (value != _beaconDefaultAudioClip)
				{
					_beaconDefaultAudioClip = value;
				}
			}
		}

		public AudioClip heartbeatDefaultAudioClip
		{
			get
			{
				return _heartbeatDefaultAudioClip;
			}
			set
			{
				if (value != _heartbeatDefaultAudioClip)
				{
					_heartbeatDefaultAudioClip = value;
				}
			}
		}

		public bool dontDestroyOnLoad
		{
			get
			{
				return _dontDestroyOnLoad;
			}
			set
			{
				if (value != _dontDestroyOnLoad)
				{
					_dontDestroyOnLoad = value;
				}
			}
		}

		public static CompassPro instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Misc.FindObjectOfType<CompassPro>();
				}
				return _instance;
			}
		}

		public Canvas canvas => _canvas;

		public float degrees => (_cameraMain.transform.eulerAngles.y + 360f - _northDegrees) % 360f;

		public bool fogOfWarEnabled
		{
			get
			{
				return _fogOfWarEnabled;
			}
			set
			{
				if (value != _fogOfWarEnabled)
				{
					_fogOfWarEnabled = value;
					SetupMiniMap();
					UpdateFogOfWar();
				}
			}
		}

		public Vector3 fogOfWarCenter
		{
			get
			{
				return _fogOfWarCenter;
			}
			set
			{
				if (value != _fogOfWarCenter)
				{
					_fogOfWarCenter = value;
					UpdateFogOfWar();
				}
			}
		}

		public Vector3 fogOfWarSize
		{
			get
			{
				return _fogOfWarSize;
			}
			set
			{
				if (value != _fogOfWarSize && value.x > 0f && value.z > 0f)
				{
					_fogOfWarSize = value;
					UpdateFogOfWar();
				}
			}
		}

		public int fogOfWarTextureSize
		{
			get
			{
				return _fogOfWarTextureSize;
			}
			set
			{
				if (value != _fogOfWarTextureSize && value > 16)
				{
					_fogOfWarTextureSize = value;
					UpdateFogOfWar();
				}
			}
		}

		public Color fogOfWarColor
		{
			get
			{
				return _fogOfWarColor;
			}
			set
			{
				if (value != _fogOfWarColor)
				{
					_fogOfWarColor = value;
					UpdateFogOfWar();
				}
			}
		}

		public bool fogOfWarAutoClear
		{
			get
			{
				return _fogOfWarAutoClear;
			}
			set
			{
				if (value != _fogOfWarAutoClear)
				{
					_fogOfWarAutoClear = value;
				}
			}
		}

		public float fogOfWarAutoClearRadius
		{
			get
			{
				return _fogOfWarAutoClearRadius;
			}
			set
			{
				if (value != _fogOfWarAutoClearRadius)
				{
					_fogOfWarAutoClearRadius = value;
				}
			}
		}

		public float fogOfWarDefaultAlpha
		{
			get
			{
				return _fogOfWarDefaultAlpha;
			}
			set
			{
				if (value != _fogOfWarDefaultAlpha)
				{
					_fogOfWarDefaultAlpha = value;
					UpdateFogOfWar();
				}
			}
		}

		public Color32[] fogOfWarTextureData
		{
			get
			{
				return fogOfWarColorBuffer;
			}
			set
			{
				fogOfWarEnabled = true;
				fogOfWarColorBuffer = value;
				if (value != null && !(fogOfWarTexture == null) && value.Length == fogOfWarTexture.width * fogOfWarTexture.height)
				{
					fogOfWarTexture.SetPixels32(fogOfWarColorBuffer);
					fogOfWarTexture.Apply();
				}
			}
		}

		public bool showMiniMap
		{
			get
			{
				return _showMiniMap;
			}
			set
			{
				if (value != _showMiniMap)
				{
					_showMiniMap = value;
					miniMapFullScreenState = false;
					SetupMiniMap();
					UpdateCompassBarAlpha();
				}
			}
		}

		public MiniMapPositionAndScaleMode miniMapPositionAndSize
		{
			get
			{
				return _miniMapPositionAndSize;
			}
			set
			{
				if (value != _miniMapPositionAndSize)
				{
					_miniMapPositionAndSize = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapPosition miniMapLocation
		{
			get
			{
				return _miniMapLocation;
			}
			set
			{
				if (value != _miniMapLocation)
				{
					_miniMapLocation = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapVisibleMaxDistance
		{
			get
			{
				return _miniMapVisibleMaxDistance;
			}
			set
			{
				if (value != _miniMapVisibleMaxDistance)
				{
					_miniMapVisibleMaxDistance = value;
				}
			}
		}

		public Vector2 miniMapLocationOffset
		{
			get
			{
				return _miniMapScreenPositionOffset;
			}
			set
			{
				if (value != _miniMapScreenPositionOffset)
				{
					_miniMapScreenPositionOffset = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapKeepStraight
		{
			get
			{
				return _miniMapKeepStraight;
			}
			set
			{
				if (value != _miniMapKeepStraight)
				{
					_miniMapKeepStraight = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapOrientation miniMapOrientation
		{
			get
			{
				return _miniMapOrientation;
			}
			set
			{
				if (value != _miniMapOrientation)
				{
					_miniMapOrientation = value;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapCameraTilt
		{
			get
			{
				return _miniMapCameraTilt;
			}
			set
			{
				if (value != _miniMapCameraTilt)
				{
					_miniMapCameraTilt = value;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapSize
		{
			get
			{
				return _miniMapSize;
			}
			set
			{
				if (value != _miniMapSize)
				{
					_miniMapSize = Mathf.Max(value, 0.001f);
					SetupMiniMap();
				}
			}
		}

		public Vector3 miniMapFollowOffset
		{
			get
			{
				return _miniMapFollowOffset;
			}
			set
			{
				if (_miniMapFollowOffset != value)
				{
					_miniMapFollowOffset = value;
					ClampDragOffset();
					needUpdateMiniMapIcons = true;
				}
			}
		}

		public Sprite miniMapMaskSprite
		{
			get
			{
				return _miniMapMaskSprite;
			}
			set
			{
				if (value != _miniMapMaskSprite)
				{
					_miniMapMaskSprite = value;
					SetupMiniMap();
				}
			}
		}

		public Texture2D miniMapBorderTexture
		{
			get
			{
				return _miniMapBorderTexture;
			}
			set
			{
				if (value != _miniMapBorderTexture)
				{
					_miniMapBorderTexture = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapStyle miniMapStyle
		{
			get
			{
				return _miniMapStyle;
			}
			set
			{
				if (value != _miniMapStyle)
				{
					_miniMapStyle = value;
					SetupMiniMap();
				}
			}
		}

		public Color miniMapBackgroundColor
		{
			get
			{
				return _miniMapBackgroundColor;
			}
			set
			{
				if (value != _miniMapBackgroundColor)
				{
					_miniMapBackgroundColor = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapBackgroundOpaque
		{
			get
			{
				return _miniMapBackgroundOpaque;
			}
			set
			{
				if (value != _miniMapBackgroundOpaque)
				{
					_miniMapBackgroundOpaque = value;
					UpdateMiniMap();
				}
			}
		}

		public MiniMapContents miniMapContents
		{
			get
			{
				return _miniMapContents;
			}
			set
			{
				if (value != _miniMapContents)
				{
					_miniMapContents = value;
					SetupMiniMap();
				}
			}
		}

		public Texture miniMapContentsTexture
		{
			get
			{
				return _miniMapContentsTexture;
			}
			set
			{
				if (value != _miniMapContentsTexture)
				{
					_miniMapContentsTexture = value;
					UpdateMiniMap();
				}
			}
		}

		public bool miniMapContentsTextureAllowRotation
		{
			get
			{
				return _miniMapContentsTextureAllowRotation;
			}
			set
			{
				if (value != _miniMapContentsTextureAllowRotation)
				{
					_miniMapContentsTextureAllowRotation = value;
					UpdateMiniMap();
				}
			}
		}

		public Sprite miniMapMaskSpriteFullScreenMode
		{
			get
			{
				return _miniMapMaskSpriteFullScreenMode;
			}
			set
			{
				if (value != _miniMapMaskSpriteFullScreenMode)
				{
					_miniMapMaskSpriteFullScreenMode = value;
					SetupMiniMap();
				}
			}
		}

		public Texture2D miniMapBorderTextureFullScreenMode
		{
			get
			{
				return _miniMapBorderTextureFullScreenMode;
			}
			set
			{
				if (value != _miniMapBorderTextureFullScreenMode)
				{
					_miniMapBorderTextureFullScreenMode = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapStyle miniMapFullScreenStyle
		{
			get
			{
				return _miniMapFullScreenStyle;
			}
			set
			{
				if (value != _miniMapFullScreenStyle)
				{
					_miniMapFullScreenStyle = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapResolution miniMapResolution
		{
			get
			{
				return _miniMapResolution;
			}
			set
			{
				if (value != _miniMapResolution)
				{
					_miniMapResolution = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapResolution miniMapFullScreenResolution
		{
			get
			{
				return _miniMapFullScreenResolution;
			}
			set
			{
				if (value != _miniMapFullScreenResolution)
				{
					_miniMapFullScreenResolution = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapFullScreenZoomLevel
		{
			get
			{
				return _miniMapFullScreenZoomLevel;
			}
			set
			{
				value = Mathf.Clamp(value, _miniMapZoomMin, _miniMapZoomMax);
				if (value != _miniMapFullScreenZoomLevel)
				{
					_miniMapFullScreenZoomLevel = value;
					lastViewConeCameraAspect = 0f;
					UpdateMiniMapContents();
				}
			}
		}

		public RectTransform miniMapFullScreenPlaceholder
		{
			get
			{
				return _miniMapFullScreenPlaceholder;
			}
			set
			{
				if (value != _miniMapFullScreenPlaceholder)
				{
					_miniMapFullScreenPlaceholder = value;
					if (_miniMapFullScreenState)
					{
						MiniMapZoomToggle(state: false);
					}
					else
					{
						SetupMiniMap();
					}
				}
			}
		}

		public float miniMapFullScreenClampBorder
		{
			get
			{
				return _miniMapFullScreenClampBorder;
			}
			set
			{
				if (value != _miniMapFullScreenClampBorder)
				{
					_miniMapFullScreenClampBorder = value;
					needUpdateMiniMapIcons = true;
				}
			}
		}

		public bool miniMapFullScreenClampBorderCircular
		{
			get
			{
				return _miniMapFullScreenClampBorderCircular;
			}
			set
			{
				if (value != _miniMapFullScreenClampBorderCircular)
				{
					_miniMapFullScreenClampBorderCircular = value;
					needUpdateMiniMapIcons = true;
				}
			}
		}

		public float miniMapFullScreenSize
		{
			get
			{
				return _miniMapFullScreenSize;
			}
			set
			{
				if (value != _miniMapFullScreenSize)
				{
					_miniMapFullScreenSize = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapContents miniMapFullScreenContents
		{
			get
			{
				return _miniMapFullScreenContents;
			}
			set
			{
				if (value != _miniMapFullScreenContents)
				{
					_miniMapFullScreenContents = value;
					SetupMiniMap();
				}
			}
		}

		public Texture miniMapFullScreenContentsTexture
		{
			get
			{
				return _miniMapFullScreenContentsTexture;
			}
			set
			{
				if (value != _miniMapFullScreenContentsTexture)
				{
					_miniMapFullScreenContentsTexture = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapKeepAspectRatio
		{
			get
			{
				return _miniMapKeepAspectRatio;
			}
			set
			{
				if (value != _miniMapKeepAspectRatio)
				{
					_miniMapKeepAspectRatio = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapAllowUserDrag
		{
			get
			{
				return _miniMapAllowUserDrag;
			}
			set
			{
				if (value != _miniMapAllowUserDrag)
				{
					_miniMapAllowUserDrag = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapFullScreenAllowUserDrag
		{
			get
			{
				return _miniMapFullScreenAllowUserDrag;
			}
			set
			{
				if (value != _miniMapFullScreenAllowUserDrag)
				{
					_miniMapFullScreenAllowUserDrag = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapAutoResetDrag
		{
			get
			{
				return _miniMapAutoResetDrag;
			}
			set
			{
				if (value != _miniMapAutoResetDrag)
				{
					_miniMapAutoResetDrag = value;
				}
			}
		}

		public bool miniMapFullScreenAutoResetDrag
		{
			get
			{
				return _miniMapFullScreenAutoResetDrag;
			}
			set
			{
				if (value != _miniMapFullScreenAutoResetDrag)
				{
					_miniMapFullScreenAutoResetDrag = value;
				}
			}
		}

		public float miniMapDragMaxDistance
		{
			get
			{
				return _miniMapDragMaxDistance;
			}
			set
			{
				if (value != _miniMapDragMaxDistance)
				{
					_miniMapDragMaxDistance = value;
					ClampDragOffset();
				}
			}
		}

		public float miniMapFullScreenDragMaxDistance
		{
			get
			{
				return _miniMapFullScreenDragMaxDistance;
			}
			set
			{
				if (value != _miniMapFullScreenDragMaxDistance)
				{
					_miniMapFullScreenDragMaxDistance = value;
					ClampDragOffset();
				}
			}
		}

		public MiniMapCameraMode miniMapCameraMode
		{
			get
			{
				return _miniMapCameraMode;
			}
			set
			{
				if (value != _miniMapCameraMode)
				{
					_miniMapCameraMode = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapCameraSnapshotFrequency miniMapCameraSnapshotFrequency
		{
			get
			{
				return _miniMapCameraSnapshotFrequency;
			}
			set
			{
				if (value != _miniMapCameraSnapshotFrequency)
				{
					_miniMapCameraSnapshotFrequency = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapCaptureSize
		{
			get
			{
				return _miniMapCaptureSize;
			}
			set
			{
				if (value != _miniMapCaptureSize)
				{
					_miniMapCaptureSize = value;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapSnapshotInterval
		{
			get
			{
				return _miniMapSnapshotInterval;
			}
			set
			{
				if (value != _miniMapSnapshotInterval)
				{
					_miniMapSnapshotInterval = value;
				}
			}
		}

		public float miniMapSnapshotDistance
		{
			get
			{
				return _miniMapSnapshotDistance;
			}
			set
			{
				if (value != _miniMapSnapshotDistance)
				{
					_miniMapSnapshotDistance = value;
				}
			}
		}

		public float miniMapContrast
		{
			get
			{
				return _miniMapContrast;
			}
			set
			{
				if (value != _miniMapContrast)
				{
					_miniMapContrast = value;
				}
			}
		}

		public float miniMapBrightness
		{
			get
			{
				return _miniMapBrightness;
			}
			set
			{
				if (value != _miniMapBrightness)
				{
					_miniMapBrightness = value;
				}
			}
		}

		public Color miniMapTintColor
		{
			get
			{
				return _miniMapTintColor;
			}
			set
			{
				if (value != _miniMapTintColor)
				{
					_miniMapTintColor = value;
				}
			}
		}

		public bool miniMapEnableShadows
		{
			get
			{
				return _miniMapEnableShadows;
			}
			set
			{
				if (value != _miniMapEnableShadows)
				{
					_miniMapEnableShadows = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapZoomMin
		{
			get
			{
				return _miniMapZoomMin;
			}
			set
			{
				if (value != _miniMapZoomMin)
				{
					_miniMapZoomMin = value;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapZoomMax
		{
			get
			{
				return _miniMapZoomMax;
			}
			set
			{
				if (value != _miniMapZoomMax)
				{
					_miniMapZoomMax = value;
					UpdateMiniMapContents();
				}
			}
		}

		public GameObject miniMapIconPrefab
		{
			get
			{
				return _miniMapIconPrefab;
			}
			set
			{
				if (value != _miniMapIconPrefab)
				{
					_miniMapIconPrefab = value;
				}
			}
		}

		public Vector2 miniMapIconPositionShift
		{
			get
			{
				return _miniMapIconPositionShift;
			}
			set
			{
				if (value != _miniMapIconPositionShift)
				{
					_miniMapIconPositionShift = value;
					_miniMapIconPositionShift.x = Mathf.Clamp(_miniMapIconPositionShift.x, -1f, 1f);
					_miniMapIconPositionShift.y = Mathf.Clamp(_miniMapIconPositionShift.y, -1f, 1f);
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapZoomLevel
		{
			get
			{
				return _miniMapZoomLevel;
			}
			set
			{
				float num = Mathf.Clamp(value, _miniMapZoomMin, _miniMapZoomMax);
				if (num != _miniMapZoomLevel)
				{
					_miniMapZoomLevel = num;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapCameraMinAltitude
		{
			get
			{
				return _miniMapCameraMinAltitude;
			}
			set
			{
				if (value != _miniMapCameraMinAltitude)
				{
					_miniMapCameraMinAltitude = value;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapCameraMaxAltitude
		{
			get
			{
				return _miniMapCameraMaxAltitude;
			}
			set
			{
				value = Mathf.Max(_miniMapCameraMinAltitude, value);
				if (value != _miniMapCameraMaxAltitude)
				{
					_miniMapCameraMaxAltitude = value;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapCameraHeightVSFollow
		{
			get
			{
				return _miniMapCameraHeightVSFollow;
			}
			set
			{
				if (value != _miniMapCameraHeightVSFollow)
				{
					_miniMapCameraHeightVSFollow = value;
					UpdateMiniMapContents();
				}
			}
		}

		public float miniMapCameraDepth
		{
			get
			{
				return _miniMapCameraDepth;
			}
			set
			{
				if (value != _miniMapCameraDepth)
				{
					_miniMapCameraDepth = value;
					SetupMiniMap();
				}
			}
		}

		public LayerMask miniMapLayerMask
		{
			get
			{
				return _miniMapLayerMask;
			}
			set
			{
				if ((int)value != (int)_miniMapLayerMask)
				{
					_miniMapLayerMask = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapIconSize
		{
			get
			{
				return _miniMapIconSize;
			}
			set
			{
				if (value != _miniMapIconSize)
				{
					_miniMapIconSize = value;
				}
			}
		}

		public bool miniMapShowPlayerIcon
		{
			get
			{
				return _miniMapShowPlayerIcon;
			}
			set
			{
				if (value != _miniMapShowPlayerIcon)
				{
					_miniMapShowPlayerIcon = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapPlayerIconSize
		{
			get
			{
				return _miniMapPlayerIconSize;
			}
			set
			{
				if (value != _miniMapPlayerIconSize)
				{
					_miniMapPlayerIconSize = value;
				}
			}
		}

		public Sprite miniMapPlayerIconSprite
		{
			get
			{
				return _miniMapPlayerIconSprite;
			}
			set
			{
				if (value != _miniMapPlayerIconSprite)
				{
					_miniMapPlayerIconSprite = value;
				}
			}
		}

		public Color miniMapPlayerIconColor
		{
			get
			{
				return _miniMapPlayerIconColor;
			}
			set
			{
				if (value != _miniMapPlayerIconColor)
				{
					_miniMapPlayerIconColor = value;
				}
			}
		}

		public bool miniMapShowNorth
		{
			get
			{
				return _miniMapShowCardinals;
			}
			set
			{
				if (value != _miniMapShowCardinals)
				{
					_miniMapShowCardinals = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapCardinalsSize
		{
			get
			{
				return _miniMapCardinalsSize;
			}
			set
			{
				if (value != _miniMapCardinalsSize)
				{
					_miniMapCardinalsSize = value;
					SetupMiniMap();
				}
			}
		}

		public Sprite miniMapCardinalsSprite
		{
			get
			{
				return _miniMapCardinalsSprite;
			}
			set
			{
				if (value != _miniMapCardinalsSprite)
				{
					_miniMapCardinalsSprite = value;
					SetupMiniMap();
				}
			}
		}

		public Color miniMapCardinalsColor
		{
			get
			{
				return _miniMapCardinalsColor;
			}
			set
			{
				if (value != _miniMapCardinalsColor)
				{
					_miniMapCardinalsColor = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapShowViewCone
		{
			get
			{
				return _miniMapShowViewCone;
			}
			set
			{
				if (value != _miniMapShowViewCone)
				{
					_miniMapShowViewCone = value;
					SetupMiniMap();
				}
			}
		}

		public Color miniMapViewConeColor
		{
			get
			{
				return _miniMapViewConeColor;
			}
			set
			{
				if (value != _miniMapViewConeColor)
				{
					_miniMapViewConeColor = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapViewConeFovSource miniMapViewConeFoVSource
		{
			get
			{
				return _miniMapViewConeFoVSource;
			}
			set
			{
				if (value != _miniMapViewConeFoVSource)
				{
					_miniMapViewConeFoVSource = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapViewConeFoV
		{
			get
			{
				return _miniMapViewConeFoV;
			}
			set
			{
				if (value != _miniMapViewConeFoV)
				{
					_miniMapViewConeFoV = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapViewConeDistance
		{
			get
			{
				return _miniMapViewConeDistance;
			}
			set
			{
				if (value != _miniMapViewConeDistance)
				{
					_miniMapViewConeDistance = value;
					UpdateMiniMap();
				}
			}
		}

		public float miniMapViewConeFallOff
		{
			get
			{
				return _miniMapViewConeFallOff;
			}
			set
			{
				if (value != _miniMapViewConeFallOff)
				{
					_miniMapViewConeFallOff = value;
					UpdateMiniMap();
				}
			}
		}

		public bool miniMapShowViewConeOutline
		{
			get
			{
				return _miniMapShowViewConeOutline;
			}
			set
			{
				if (value != _miniMapShowViewConeOutline)
				{
					_miniMapShowViewConeOutline = value;
					SetupMiniMap();
				}
			}
		}

		public Color miniMapViewConeOutlineColor
		{
			get
			{
				return _miniMapViewConeOutlineColor;
			}
			set
			{
				if (value != _miniMapViewConeOutlineColor)
				{
					_miniMapViewConeOutlineColor = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapClampBorder
		{
			get
			{
				return _miniMapClampBorder;
			}
			set
			{
				if (value != _miniMapClampBorder)
				{
					_miniMapClampBorder = value;
					needUpdateMiniMapIcons = true;
				}
			}
		}

		public bool miniMapClampBorderCircular
		{
			get
			{
				return _miniMapClampBorderCircular;
			}
			set
			{
				if (value != _miniMapClampBorderCircular)
				{
					_miniMapClampBorderCircular = value;
					needUpdateMiniMapIcons = true;
				}
			}
		}

		public bool miniMapVignette
		{
			get
			{
				return _miniMapVignette;
			}
			set
			{
				if (value != _miniMapVignette)
				{
					_miniMapVignette = value;
					needUpdateMiniMapIcons = true;
				}
			}
		}

		public float miniMapAlpha
		{
			get
			{
				return _miniMapAlpha;
			}
			set
			{
				if (value != _miniMapAlpha)
				{
					_miniMapAlpha = value;
				}
			}
		}

		public bool miniMapShowZoomInOutButtons
		{
			get
			{
				return _miniMapShowZoomInOutButtons;
			}
			set
			{
				if (value != _miniMapShowZoomInOutButtons)
				{
					_miniMapShowZoomInOutButtons = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapIconCircleAnimationDuration
		{
			get
			{
				return _miniMapIconCircleAnimationDuration;
			}
			set
			{
				if (value != _miniMapIconCircleAnimationDuration)
				{
					_miniMapIconCircleAnimationDuration = value;
				}
			}
		}

		public bool miniMapShowMaximizeButton
		{
			get
			{
				return _miniMapShowMaximizeButton;
			}
			set
			{
				if (value != _miniMapShowMaximizeButton)
				{
					_miniMapShowMaximizeButton = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapButtonsScale
		{
			get
			{
				return _miniMapButtonsScale;
			}
			set
			{
				if (value != _miniMapButtonsScale)
				{
					_miniMapButtonsScale = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapIconEvents
		{
			get
			{
				return _miniMapIconEvents;
			}
			set
			{
				if (_miniMapIconEvents != value)
				{
					_miniMapIconEvents = value;
				}
			}
		}

		public MiniMapRadarInfoType miniMapRadarInfoDisplay
		{
			get
			{
				return _miniMapRadarInfoDisplay;
			}
			set
			{
				if (_miniMapRadarInfoDisplay != value)
				{
					_miniMapRadarInfoDisplay = value;
				}
			}
		}

		public MiniMapRadarGraphicsMethod miniMapRadarGraphicsMethod
		{
			get
			{
				return _miniMapRadarGraphicsMethod;
			}
			set
			{
				if (_miniMapRadarGraphicsMethod != value)
				{
					_miniMapRadarGraphicsMethod = value;
					SetupMiniMap();
				}
			}
		}

		public Color miniMapRadarRingsColor
		{
			get
			{
				return _miniMapRadarRingsColor;
			}
			set
			{
				if (value != _miniMapRadarRingsColor)
				{
					_miniMapRadarRingsColor = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapRadarRingsDistance
		{
			get
			{
				return _miniMapRadarRingsDistance;
			}
			set
			{
				if (value != _miniMapRadarRingsDistance)
				{
					_miniMapRadarRingsDistance = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapRadarRingsWidth
		{
			get
			{
				return _miniMapRadarRingsWidth;
			}
			set
			{
				if (value != _miniMapRadarRingsWidth)
				{
					_miniMapRadarRingsWidth = value;
					SetupMiniMap();
				}
			}
		}

		public bool miniMapRadarPulseEnabled
		{
			get
			{
				return _miniMapRadarPulseEnabled;
			}
			set
			{
				if (value != _miniMapRadarPulseEnabled)
				{
					_miniMapRadarPulseEnabled = value;
					SetupMiniMap();
				}
			}
		}

		public MiniMapPulsePreset miniMapRadarPulseAnimationPreset
		{
			get
			{
				return _miniMapRadarPulseAnimationPreset;
			}
			set
			{
				if (value != _miniMapRadarPulseAnimationPreset)
				{
					_miniMapRadarPulseAnimationPreset = value;
					SetupMiniMap();
				}
			}
		}

		public float miniMapRadarPulseOpacity
		{
			get
			{
				return _miniMapRadarPulseOpacity;
			}
			set
			{
				if (value != _miniMapRadarPulseOpacity)
				{
					_miniMapRadarPulseOpacity = value;
					UpdateMiniMap();
				}
			}
		}

		public float miniMapRadarPulseFrequency
		{
			get
			{
				return _miniMapRadarPulseFrequency;
			}
			set
			{
				if (value != _miniMapRadarPulseFrequency)
				{
					_miniMapRadarPulseFrequency = value;
					UpdateMiniMap();
				}
			}
		}

		public float miniMapRadarPulseFallOff
		{
			get
			{
				return _miniMapRadarPulseFallOff;
			}
			set
			{
				if (value != _miniMapRadarPulseFallOff)
				{
					_miniMapRadarPulseFallOff = value;
					UpdateMiniMap();
				}
			}
		}

		public float miniMapRadarPulseSpeed
		{
			get
			{
				return _miniMapRadarPulseSpeed;
			}
			set
			{
				if (value != _miniMapRadarPulseSpeed)
				{
					_miniMapRadarPulseSpeed = value;
					UpdateMiniMap();
				}
			}
		}

		public bool miniMapRadarFadePOIs
		{
			get
			{
				return _miniMapRadarFadePOIs;
			}
			set
			{
				if (value != _miniMapRadarFadePOIs)
				{
					_miniMapRadarFadePOIs = value;
					UpdateMiniMap();
				}
			}
		}

		public bool miniMapFullScreenState
		{
			get
			{
				return _miniMapFullScreenState;
			}
			set
			{
				if (_miniMapFullScreenState != value)
				{
					if (!_showMiniMap)
					{
						showMiniMap = true;
					}
					OnMiniMapChangeFullScreenState?.Invoke(value);
					MiniMapZoomToggle(value);
				}
			}
		}

		[Tooltip("Center of the world map in full screen mode")]
		public Vector3 miniMapFullScreenWorldCenter
		{
			get
			{
				return _miniMapFullScreenWorldCenter;
			}
			set
			{
				if (_miniMapFullScreenWorldCenter != value)
				{
					_miniMapFullScreenWorldCenter = value;
					needUpdateMiniMapIcons = true;
				}
			}
		}

		[Tooltip("Size of the world map")]
		public Vector3 miniMapFullScreenWorldSize
		{
			get
			{
				return _miniMapFullScreenWorldSize;
			}
			set
			{
				if (_miniMapFullScreenWorldSize != value)
				{
					_miniMapFullScreenWorldSize = value;
					needUpdateMiniMapIcons = true;
				}
			}
		}

		public Vector3 miniMapWorldCenter
		{
			get
			{
				return _miniMapWorldCenter;
			}
			set
			{
				if (_miniMapWorldCenter != value)
				{
					_miniMapWorldCenter = value;
					UpdateMiniMap();
				}
			}
		}

		public Vector3 miniMapWorldSize
		{
			get
			{
				return _miniMapWorldSize;
			}
			set
			{
				if (_miniMapWorldSize != value)
				{
					_miniMapWorldSize = value;
					UpdateMiniMap();
				}
			}
		}

		public float miniMapLutIntensity
		{
			get
			{
				return _miniMapLutIntensity;
			}
			set
			{
				if (_miniMapLutIntensity != value)
				{
					_miniMapLutIntensity = value;
				}
			}
		}

		public Texture2D miniMapLutTexture
		{
			get
			{
				return _miniMapLutTexture;
			}
			set
			{
				if (_miniMapLutTexture != value)
				{
					_miniMapLutTexture = value;
				}
			}
		}

		public Color miniMapVignetteColor
		{
			get
			{
				return _miniMapVignetteColor;
			}
			set
			{
				if (value != _miniMapVignetteColor)
				{
					_miniMapVignetteColor = value;
					SetupMiniMap();
				}
			}
		}

		private bool currentMiniMapUsesFogOfWar
		{
			get
			{
				if (_fogOfWarEnabled)
				{
					if (currentMiniMapContents != MiniMapContents.TopDownWorldView)
					{
						return currentMiniMapContents == MiniMapContents.WorldMappedTexture;
					}
					return true;
				}
				return false;
			}
		}

		[Obsolete("miniMapFollow is obsolete. Please use 'follow'.")]
		public Transform miniMapFollow
		{
			get
			{
				return _follow;
			}
			set
			{
				follow = value;
			}
		}

		[Obsolete("miniMapZoomState is obsolete. Please use 'miniMapFullScreenState'.")]
		public bool miniMapZoomState
		{
			get
			{
				return _miniMapFullScreenState;
			}
			set
			{
				miniMapFullScreenState = value;
			}
		}

		public bool currentMiniMapAllowsUserDrag
		{
			get
			{
				if (!_miniMapFullScreenState)
				{
					return _miniMapAllowUserDrag;
				}
				return _miniMapFullScreenAllowUserDrag;
			}
		}

		private float currentMiniMapClampBorder
		{
			get
			{
				if (!_miniMapFullScreenState)
				{
					return _miniMapClampBorder;
				}
				return _miniMapFullScreenClampBorder;
			}
		}

		private bool currentMiniMapIsCircular
		{
			get
			{
				if (!_miniMapFullScreenState)
				{
					if (!_miniMapClampBorderCircular)
					{
						return _miniMapContents == MiniMapContents.Radar;
					}
					return true;
				}
				if (!_miniMapFullScreenClampBorderCircular)
				{
					return _miniMapFullScreenContents == MiniMapContents.Radar;
				}
				return true;
			}
		}

		private bool currentMiniMapUsesEvents
		{
			get
			{
				if (!_miniMapShowZoomInOutButtons && !_miniMapShowMaximizeButton && !_miniMapIconEvents)
				{
					return currentMiniMapAllowsUserDrag;
				}
				return true;
			}
		}

		private MiniMapContents currentMiniMapContents
		{
			get
			{
				if (!_miniMapFullScreenState)
				{
					return _miniMapContents;
				}
				return _miniMapFullScreenContents;
			}
		}

		private float currentMiniMapZoomLevel
		{
			get
			{
				if (!_miniMapFullScreenState)
				{
					return _miniMapZoomLevel;
				}
				return _miniMapFullScreenZoomLevel;
			}
		}

		private Vector3 currentMiniMapWorldCenter
		{
			get
			{
				if (!_miniMapFullScreenState)
				{
					return _miniMapWorldCenter;
				}
				return _miniMapFullScreenWorldCenter;
			}
		}

		private Vector3 currentMiniMapWorldSize
		{
			get
			{
				if (!_miniMapFullScreenState)
				{
					return _miniMapWorldSize;
				}
				return _miniMapFullScreenWorldSize;
			}
		}

		public static GameObject Create()
		{
			GameObject gameObject = Resources.Load("CNPro/Prefabs/CompassNavigatorPro") as GameObject;
			if (gameObject != null)
			{
				gameObject = UnityEngine.Object.Instantiate(gameObject);
				gameObject.name = "CompassNavigatorPro";
				return gameObject;
			}
			return null;
		}

		public void Refresh()
		{
			HideMiniMapIcons();
			needUpdateMiniMapIcons = true;
			needUpdateCompassBarIcons = true;
			needUpdateIndicators = true;
		}

		public bool POIRegister(CompassProPOI newPOI)
		{
			bool result = false;
			foreach (CompassPro compass in compasses)
			{
				if (compass != null)
				{
					compass.Refresh();
					if (!compass.POIisRegistered(newPOI))
					{
						result = compass.POIRegister_internal(newPOI);
					}
				}
			}
			return result;
		}

		private bool POIRegister_internal(CompassProPOI newPOI)
		{
			newPOI.compass = this;
			pois.Add(newPOI);
			needsIconSorting = true;
			OnPOIRegister?.Invoke(newPOI);
			return true;
		}

		public bool POIisRegistered(CompassProPOI poi)
		{
			int count = pois.Count;
			for (int i = 0; i < count; i++)
			{
				CompassProPOI compassProPOI = pois[i];
				if (!(compassProPOI == null) && compassProPOI.id == poi.id)
				{
					return true;
				}
			}
			return false;
		}

		public void POIResort()
		{
			foreach (CompassPro compass in compasses)
			{
				if (compass != null)
				{
					compass.needsIconSorting = true;
				}
			}
		}

		public void POIUnregister(CompassProPOI newPOI)
		{
			foreach (CompassPro compass in compasses)
			{
				if (compass != null)
				{
					compass.Refresh();
					POIUnregister_internal(newPOI);
				}
			}
		}

		private void POIUnregister_internal(CompassProPOI poi)
		{
			int count = pois.Count;
			for (int i = 0; i < count; i++)
			{
				CompassProPOI compassProPOI = pois[i];
				if (!(compassProPOI == null) && compassProPOI.id == poi.id)
				{
					OnPOIUnregister?.Invoke(poi);
					compassProPOI.Release();
					pois[i] = null;
					break;
				}
			}
		}

		public void POIFocus(CompassProPOI poi)
		{
			poi.showOnScreenIndicator = true;
			foreach (CompassPro compass in compasses)
			{
				if (compass != null)
				{
					compass.focusedPOI = poi;
				}
			}
		}

		public void POIBlur()
		{
			foreach (CompassPro compass in compasses)
			{
				if (compass != null && compass.focusedPOI != null)
				{
					compass.focusedPOI.showOnScreenIndicator = false;
					compass.focusedPOI = null;
				}
			}
		}

		public void POIStartCircleAnimation(CompassProPOI poi)
		{
			if (poi != null)
			{
				poi.StartCircleAnimation();
			}
		}

		public GameObject POIShowBeacon(CompassProPOI existingPOI, float duration, float horizontalScale = 1f)
		{
			return POIShowBeacon(existingPOI, duration, horizontalScale, 1f, Color.white);
		}

		public GameObject POIShowBeacon(CompassProPOI existingPOI, float duration, float horizontalScale, float intensity, Color tintColor)
		{
			Transform transform = existingPOI.transform.Find("POIBeacon");
			if (transform != null)
			{
				return transform.gameObject;
			}
			GameObject obj = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("CNPro/Prefabs/POIBeacon"));
			obj.name = "POIBeacon";
			transform = obj.transform;
			transform.localScale = new Vector3(transform.localScale.x * horizontalScale, transform.localScale.y, transform.localScale.z);
			transform.position = existingPOI.transform.position + new Vector3(0f, transform.localScale.y * 0.5f, 0f);
			transform.SetParent(existingPOI.transform, worldPositionStays: true);
			BeaconAnimator component = transform.GetComponent<BeaconAnimator>();
			component.duration = duration;
			component.tintColor = tintColor;
			component.intensity = intensity;
			if (audioSource != null)
			{
				if (existingPOI.beaconAudioClip != null)
				{
					audioSource.PlayOneShot(existingPOI.beaconAudioClip);
					return obj;
				}
				if (_beaconDefaultAudioClip != null)
				{
					audioSource.PlayOneShot(_beaconDefaultAudioClip);
				}
			}
			return obj;
		}

		public void POIShowBeacon(Vector3 position, float duration, float horizontalScale, float intensity, Color tintColor)
		{
			string text = "POIBeacon " + position;
			if (!(GameObject.Find(text) != null))
			{
				GameObject obj = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("CNPro/Prefabs/POIBeacon"));
				obj.name = text;
				Transform transform = obj.transform;
				transform.localScale = new Vector3(transform.localScale.x * horizontalScale, transform.localScale.y, transform.localScale.z);
				transform.position = position + Misc.Vector3up * transform.transform.localScale.y * 0.5f;
				BeaconAnimator component = transform.gameObject.GetComponent<BeaconAnimator>();
				component.duration = duration;
				component.tintColor = tintColor;
				component.intensity = intensity;
				if (audioSource != null && _beaconDefaultAudioClip != null)
				{
					audioSource.PlayOneShot(_beaconDefaultAudioClip);
				}
			}
		}

		public void POIShowBeacon(float duration, float horizontalScale = 1f)
		{
			POIShowBeacon(duration, horizontalScale, 1f, Color.white);
		}

		public void POIShowBeacon(float duration, float horizontalScale, float intensity, Color tintColor)
		{
			for (int i = 0; i < pois.Count; i++)
			{
				CompassProPOI compassProPOI = pois[i];
				if (!(compassProPOI == null) && !compassProPOI.isVisited && compassProPOI.isVisible)
				{
					POIShowBeacon(compassProPOI, duration, horizontalScale, intensity, tintColor);
				}
			}
		}

		public void FadeIn(float duration)
		{
			fadeDuration = duration;
			fadeStartTime = Time.time;
			prevAlpha = canvasGroup.alpha;
			alpha = 1f;
		}

		public void FadeOut(float duration)
		{
			fadeDuration = duration;
			fadeStartTime = Time.time;
			prevAlpha = canvasGroup.alpha;
			alpha = 0f;
		}

		public void ShowAnimatedText(string text)
		{
			StartCoroutine(AnimateDiscoverText(text));
		}

		public void POIGetVisited(List<CompassProPOI> pois)
		{
			pois.Clear();
			foreach (CompassProPOI poi in this.pois)
			{
				if (poi != null && poi.isVisited)
				{
					pois.Add(poi);
				}
			}
		}

		public void POIGetUnvisited(List<CompassProPOI> pois)
		{
			pois.Clear();
			foreach (CompassProPOI poi in this.pois)
			{
				if (poi != null && !poi.isVisited)
				{
					pois.Add(poi);
				}
			}
		}

		public void POIGetAll(List<CompassProPOI> pois)
		{
			pois.Clear();
			foreach (CompassProPOI poi in this.pois)
			{
				if (poi != null)
				{
					pois.Add(poi);
				}
			}
		}

		public void UpdateFogOfWar()
		{
			if (currentMiniMapUsesFogOfWar)
			{
				if (Application.isPlaying)
				{
					needFogOfWarUpdate = true;
				}
				else
				{
					UpdateFogOfWarTexture();
				}
			}
		}

		public void SetFogOfWarAlpha(Vector3 worldPosition, float radius, float fogNewAlpha, float border)
		{
			if (fogOfWarTexture == null)
			{
				return;
			}
			float num = (worldPosition.x - _fogOfWarCenter.x) / _fogOfWarSize.x + 0.5f;
			if (num < 0f || num > 1f)
			{
				return;
			}
			float num2 = (worldPosition.z - _fogOfWarCenter.z) / _fogOfWarSize.z + 0.5f;
			if (num2 < 0f || num2 > 1f)
			{
				return;
			}
			int num3 = fogOfWarTexture.width;
			int num4 = fogOfWarTexture.height;
			int num5 = Mathf.Clamp((int)(num * (float)num3), 0, num3 - 1);
			int num6 = Mathf.Clamp((int)(num2 * (float)num4), 0, num4 - 1);
			int num7 = num6 * num3 + num5;
			byte b = (byte)(fogNewAlpha * 255f);
			float num8 = radius / _fogOfWarSize.z;
			int num9 = (int)((float)num4 * num8);
			int num10 = num9 * num9;
			for (int i = num6 - num9; i <= num6 + num9; i++)
			{
				if (i < 0 || i >= num4)
				{
					continue;
				}
				for (int j = num5 - num9; j <= num5 + num9; j++)
				{
					if (j < 0 || j >= num3)
					{
						continue;
					}
					int num11 = (num6 - i) * (num6 - i) + (num5 - j) * (num5 - j);
					if (num11 <= num10)
					{
						num7 = i * num3 + j;
						Color32 color = fogOfWarColorBuffer[num7];
						float num12 = (float)num11 * border / (float)num10;
						if (num12 > 1f)
						{
							num12 = 1f;
						}
						byte a = (byte)((double)(int)b * (1.0 - (double)num12) + (double)((float)(int)color.a * num12));
						color.a = a;
						fogOfWarColorBuffer[num7] = color;
						needFogOfWarTextureUpdate = true;
					}
				}
			}
		}

		public void SetFogOfWarAlpha(Bounds bounds, float fogNewAlpha, float border)
		{
			if (fogOfWarTexture == null)
			{
				return;
			}
			Vector3 center = bounds.center;
			float num = (center.x - _fogOfWarCenter.x) / _fogOfWarSize.x + 0.5f;
			if (num < 0f || num > 1f)
			{
				return;
			}
			float num2 = (center.z - _fogOfWarCenter.z) / _fogOfWarSize.z + 0.5f;
			if (num2 < 0f || num2 > 1f)
			{
				return;
			}
			int num3 = fogOfWarTexture.width;
			int num4 = fogOfWarTexture.height;
			int num5 = Mathf.Clamp((int)(num * (float)num3), 0, num3 - 1);
			int num6 = Mathf.Clamp((int)(num2 * (float)num4), 0, num4 - 1);
			byte b = (byte)(fogNewAlpha * 255f);
			float num7 = bounds.extents.x / _fogOfWarSize.x;
			float num8 = bounds.extents.z / _fogOfWarSize.z;
			int num9 = (int)((float)num3 * num7);
			int num10 = (int)((float)num4 * num8);
			for (int i = num6 - num10; i <= num6 + num10; i++)
			{
				if (i < 0 || i >= num4)
				{
					continue;
				}
				int num11 = num6 - i;
				if (num11 < 0)
				{
					num11 = -num11;
				}
				if (num11 > num10)
				{
					continue;
				}
				float num12 = (float)(num10 - num11 + 1) / ((float)num10 * border + 0.0001f);
				for (int j = num5 - num9; j <= num5 + num9; j++)
				{
					if (j < 0 || j >= num3)
					{
						continue;
					}
					int num13 = num5 - j;
					if (num13 < 0)
					{
						num13 = -num13;
					}
					if (num13 <= num9)
					{
						int num14 = i * num3 + j;
						Color32 color = fogOfWarColorBuffer[num14];
						float num15 = (float)(num9 - num13 + 1) / ((float)num9 * border + 0.0001f) * num12;
						if (num15 > 1f)
						{
							num15 = 1f;
						}
						byte a = (byte)((float)(int)color.a * (1f - num15) + (float)(int)b * num15);
						color.a = a;
						fogOfWarColorBuffer[num14] = color;
						needFogOfWarTextureUpdate = true;
					}
				}
			}
		}

		public void ResetFogOfWar(float alpha = 1f)
		{
			if (!(fogOfWarTexture == null))
			{
				int num = fogOfWarTexture.height;
				int num2 = fogOfWarTexture.width;
				int num3 = num * num2;
				if (fogOfWarColorBuffer == null || fogOfWarColorBuffer.Length != num3)
				{
					fogOfWarColorBuffer = new Color32[num3];
				}
				byte b = (byte)(alpha * 255f);
				Color32 color = new Color32(b, b, b, b);
				for (int i = 0; i < num3; i++)
				{
					fogOfWarColorBuffer[i] = color;
				}
			}
		}

		public float GetFogOfWarAlpha(Vector3 worldPosition)
		{
			if (fogOfWarColorBuffer == null)
			{
				return 1f;
			}
			float num = (worldPosition.x - _fogOfWarCenter.x) / _fogOfWarSize.x + 0.5f;
			if (num < 0f || num > 1f)
			{
				return 1f;
			}
			float num2 = (worldPosition.z - _fogOfWarCenter.z) / _fogOfWarSize.z + 0.5f;
			if (num2 < 0f || num2 > 1f)
			{
				return 1f;
			}
			int num3 = fogOfWarTexture.width;
			int num4 = fogOfWarTexture.height;
			int num5 = (int)(num * (float)num3);
			int num6 = (int)(num2 * (float)num4) * num3 + num5;
			if (num6 < 0 || num6 >= fogOfWarColorBuffer.Length)
			{
				return 1f;
			}
			return (float)(int)fogOfWarColorBuffer[num6].a / 255f;
		}

		public void SetFogOfWar(List<Vector3> points, float stepSize = 1f, float alpha = 1f)
		{
			if (points == null)
			{
				return;
			}
			int count = points.Count;
			if (count < 2)
			{
				return;
			}
			for (int i = 0; i < count - 1; i++)
			{
				Vector3 a = points[i];
				Vector3 b = points[i + 1];
				a.y = (b.y = 0f);
				int num = Mathf.CeilToInt(Vector3.Distance(a, b) / stepSize);
				for (int j = 0; j <= num; j++)
				{
					float t = (float)j / (float)num;
					Vector3 worldPosition = Vector3.Lerp(a, b, t);
					SetFogOfWarAlpha(worldPosition, 1f, alpha, 0f);
				}
			}
		}

		public void MiniMapZoomIn(float speed = 1f)
		{
			float num = Time.deltaTime * speed;
			if (miniMapFullScreenState)
			{
				miniMapFullScreenZoomLevel += num * _miniMapFullScreenZoomLevel;
			}
			else
			{
				miniMapZoomLevel += num * _miniMapZoomLevel;
			}
		}

		public void MiniMapZoomOut(float speed = 1f)
		{
			float num = Time.deltaTime * speed;
			if (miniMapFullScreenState)
			{
				miniMapFullScreenZoomLevel -= num * _miniMapFullScreenZoomLevel;
			}
			else
			{
				miniMapZoomLevel -= num * _miniMapZoomLevel;
			}
		}

		public void UpdateMiniMapContents(int numberOfFramesToRefresh = 1)
		{
			if (needMiniMapShot == 0)
			{
				needMiniMapShot += numberOfFramesToRefresh;
			}
			lastViewConeCameraAspect = 0f;
			needUpdateMiniMapIcons = true;
		}

		public bool IsMouseOverMiniMap()
		{
			if (miniMapUIRootRT == null)
			{
				return false;
			}
			return RectTransformUtility.RectangleContainsScreenPoint(miniMapUIRootRT, Input.mousePosition);
		}

		public float GetAltitudeUnderMiniMapCamera()
		{
			if (miniMapCamera == null)
			{
				return 0f;
			}
			Physics.Raycast(miniMapCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out var hitInfo);
			return miniMapCamera.transform.position.y - hitInfo.distance;
		}

		public void ResetDragOffset()
		{
			miniMapFollowOffset = Misc.Vector3zero;
			needUpdateMiniMapIcons = true;
		}

		public void OnEnable()
		{
			if (!compasses.Contains(this))
			{
				compasses.Add(this);
			}
			if (_follow == null && cameraMain != null)
			{
				_follow = _cameraMain.transform;
			}
			if (compassPoints == null || compassPoints.Length == 0)
			{
				Init();
			}
			if (Application.isPlaying && currentMiniMapUsesEvents && Misc.FindObjectOfType<EventSystem>() == null)
			{
				new GameObject("EventSystem", typeof(EventSystem)).AddComponent<InputSystemUIInputModule>();
			}
			EnableCompass();
			SetupTextPool();
			SetupMiniMap();
			if (dontDestroyOnLoad && Application.isPlaying)
			{
				if (Misc.FindObjectsOfType(GetType()).Length > 1)
				{
					UnityEngine.Object.Destroy(base.gameObject);
					return;
				}
				UnityEngine.Object.DontDestroyOnLoad(this);
				SceneManager.sceneLoaded += UpdateFogOfWarOnLoadScene;
			}
			CompassProPOI[] array = Misc.FindObjectsOfType<CompassProPOI>();
			foreach (CompassProPOI compassProPOI in array)
			{
				if (!POIisRegistered(compassProPOI))
				{
					compassProPOI.RegisterPOI();
				}
			}
		}

		private void Start()
		{
			needsSetupMiniMap = true;
		}

		private void OnRectTransformDimensionsChange()
		{
			needsSetupMiniMap = true;
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= UpdateFogOfWarOnLoadScene;
		}

		private void OnDrawGizmosSelected()
		{
			if (currentMiniMapContents == MiniMapContents.WorldMappedTexture && _showMiniMap)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireCube(currentMiniMapWorldCenter, currentMiniMapWorldSize);
			}
		}

		private void OnDestroy()
		{
			DisableCompass();
			DisableMiniMap();
			DisableIndicators();
			foreach (CompassProPOI poi in pois)
			{
				if (poi != null)
				{
					poi.Release();
				}
			}
			pois.Clear();
			if (curvedMat != null)
			{
				UnityEngine.Object.DestroyImmediate(curvedMat);
			}
			if (compassBarMat != null)
			{
				UnityEngine.Object.DestroyImmediate(compassBarMat);
			}
			if (defaultUICurvedMatForCardinals != null)
			{
				UnityEngine.Object.DestroyImmediate(defaultUICurvedMatForCardinals);
			}
			if (defaultUICurvedMatForText != null)
			{
				UnityEngine.Object.DestroyImmediate(defaultUICurvedMatForText);
			}
			MiniMapDispose();
			if (compasses.Contains(this))
			{
				compasses.Remove(this);
			}
		}

		private void OnValidate()
		{
			_miniMapSize = Mathf.Max(0.001f, _miniMapSize);
			_miniMapIconSize = Mathf.Max(0f, _miniMapIconSize);
			_miniMapViewConeDistance = Mathf.Max(_miniMapViewConeDistance, 0f);
			_visitedDistance = Mathf.Max(_visitedDistance, 1f);
			_nearDistance = Mathf.Max(10f, _nearDistance);
			_miniMapRadarRingsDistance = Mathf.Max(1f, _miniMapRadarRingsDistance);
			_onScreenIndicatorScale = Mathf.Max(0.001f, _onScreenIndicatorScale);
			_visibleMaxDistance = Mathf.Max(_visibleMaxDistance, 0f);
			_visibleMinDistance = Mathf.Max(_visibleMinDistance, 0f);
			_miniMapCaptureSize = Mathf.Max(_miniMapCaptureSize, 2f);
			_miniMapRadarPulseFallOff = Mathf.Max(0f, _miniMapRadarPulseFallOff);
			_miniMapRadarPulseFrequency = Mathf.Max(0f, _miniMapRadarPulseFrequency);
			needsUpdateSettings = true;
		}

		private void Init()
		{
			Canvas.ForceUpdateCanvases();
			Invoke("CanvasRefresh", 0f);
			InitDelayed();
		}

		private Camera FindSuitableCamera()
		{
			Camera camera = Camera.main;
			if (camera == null)
			{
				Camera[] array = Misc.FindObjectsOfType<Camera>(includeInactive: true);
				foreach (Camera camera2 in array)
				{
					if ((!(camera2.targetTexture != null) || camera2.targetTexture.format != RenderTextureFormat.Default) && !(camera2.GetComponentInParent<CompassPro>(includeInactive: true) != null))
					{
						camera = camera2;
						break;
					}
				}
			}
			if (hideIfNoCamera)
			{
				base.gameObject.SetActive(camera != null);
			}
			return camera;
		}

		private void CanvasRefresh()
		{
			Canvas.ForceUpdateCanvases();
		}

		private void InitDelayed()
		{
			_canvas = GetComponent<Canvas>();
			_canvas.pixelPerfect = false;
			pois.Clear();
			audioSource = GetComponent<AudioSource>();
			if (compassIconPrefab == null)
			{
				compassIconPrefab = Resources.Load<GameObject>("CNPro/Prefabs/CompassBarIcon");
			}
			if (miniMapIconPrefab == null)
			{
				miniMapIconPrefab = Resources.Load<GameObject>("CNPro/Prefabs/MiniMapIcon");
			}
			if (_titleFont == null)
			{
				_titleFont = Resources.Load<Font>("CNPro/Fonts/Actor-Regular");
			}
			if (_titleFontTMP == null)
			{
				_titleFontTMP = Resources.Load<TMP_FontAsset>("CNPro/Fonts/Title Font SDF");
			}
			GameObject gameObject = base.transform.Find("CompassBack").gameObject;
			compassBackRT = gameObject.GetComponent<RectTransform>();
			compassBackImage = gameObject.GetComponent<Image>();
			canvasGroup = GetMiniMapCanvasGroup(compassBackRT);
			this.text = compassBackRT.transform.Find("Text").GetComponent<Text>();
			textShadow = compassBackRT.transform.Find("TextShadow").GetComponent<Text>();
			Text obj = this.text;
			string text = (textShadow.text = "");
			obj.text = text;
			titleRT = compassBackRT.transform.Find("Title").GetComponent<RectTransform>();
			titleRTDefaultPosition = titleRT.position;
			title = titleRT.GetComponent<Text>();
			titleShadowRT = compassBackRT.transform.Find("TitleShadow").GetComponent<RectTransform>();
			titleShadowRTDefaultPosition = titleShadowRT.position;
			titleShadow = titleShadowRT.GetComponent<Text>();
			Text obj2 = title;
			text = (titleShadow.text = "");
			obj2.text = text;
			titleTMPRT = compassBackRT.transform.Find("TitleTMP").GetComponent<RectTransform>();
			titleTMP = titleTMPRT.GetComponent<TextMeshProUGUI>();
			titleTMP.text = "";
			canvasGroup.alpha = 0f;
			prevAlpha = 0f;
			fadeStartTime = Time.time;
			lastNearestPOIDistanceText = "";
			lastNearestPOIDistance = float.MinValue;
			compassPoints = new CompassPointPOI[8];
			compassPoints[2].text = compassBackRT.Find("CardinalN").GetComponent<Text>();
			compassPoints[4].text = compassBackRT.Find("CardinalW").GetComponent<Text>();
			compassPoints[6].text = compassBackRT.Find("CardinalS").GetComponent<Text>();
			compassPoints[0].text = compassBackRT.Find("CardinalE").GetComponent<Text>();
			compassPoints[3].text = compassBackRT.Find("InterCardinalNW").GetComponent<Text>();
			compassPoints[1].text = compassBackRT.Find("InterCardinalNE").GetComponent<Text>();
			compassPoints[5].text = compassBackRT.Find("InterCardinalSW").GetComponent<Text>();
			compassPoints[7].text = compassBackRT.Find("InterCardinalSE").GetComponent<Text>();
			usedNorthDegrees = -1f;
			MiniMapIconElements[] componentsInChildren = GetComponentsInChildren<MiniMapIconElements>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren[i].gameObject);
			}
			CompassPOIElements[] componentsInChildren2 = GetComponentsInChildren<CompassPOIElements>(includeInactive: true);
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren2[i].gameObject);
			}
			Transform transform = base.transform.Find("OnScreen Indicators Root");
			if (transform != null)
			{
				UnityEngine.Object.DestroyImmediate(transform.gameObject);
			}
			MeshRenderer[] componentsInChildren3 = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren3.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren3[i].gameObject);
			}
			lastUpdateFrameCount = int.MinValue;
			lastUpdateTime = float.MinValue;
			InitIndicators();
			UpdatePOIs();
			ComputeCompassPointsPositions();
			UpdateCompassBarAppearance();
			UpdateHalfWindsAppearance();
			UpdateCompassBarAlpha();
			SetupMiniMap();
			UpdateFogOfWarTexture();
			Refresh();
		}

		private void LateUpdate()
		{
			if (needsUpdateSettings)
			{
				needsUpdateSettings = false;
				UpdateSettings();
			}
			if (_canvas == null)
			{
				return;
			}
			UpdatePOIs();
			if (_showCompassBar || _showMiniMap)
			{
				if (_showCompassBar)
				{
					UpdateCompassBarIcons();
					UpdateCompassBarAlpha();
				}
				if (_showMiniMap)
				{
					UpdateFogOfWarPosition();
					UpdateMiniMap();
					UpdateMiniMapIcons();
				}
			}
			if ((_showOnScreenIndicators || _showOffScreenIndicators) && Application.isPlaying)
			{
				UpdateIndicators();
			}
		}

		internal void BubbleEvent<T>(Action<T> a, T t)
		{
			if (a != null && t != null)
			{
				a(t);
			}
		}

		internal void BubbleEvent<T, Q>(Action<T, Q> a, T t, Q q)
		{
			if (a != null && t != null && q != null)
			{
				a(t, q);
			}
		}

		public void UpdateSettings()
		{
			if (_canvas == null)
			{
				InitDelayed();
			}
			if (!hideIfNoCamera)
			{
				base.gameObject.SetActive(value: true);
			}
			SetupMiniMap();
			UpdateCompassBarAppearance();
			UpdateHalfWindsAppearance();
			UpdateCompassBarAlpha();
			UpdateFogOfWarTexture();
			UpdateTitleAppearance();
			UpdateTextAppearance();
			InitIndicators();
			Refresh();
		}

		private void EnableCompass()
		{
			if (compassBackRT != null)
			{
				compassBackRT.gameObject.SetActive(value: true);
			}
			needUpdateCompassBarIcons = true;
		}

		private void DisableCompass()
		{
			if (compassBackRT != null)
			{
				compassBackRT.gameObject.SetActive(value: false);
			}
		}

		private void UpdatePOIs()
		{
			if (_follow != null)
			{
				followPos = _follow.position;
			}
			if (cameraMain == null)
			{
				return;
			}
			Transform transform = _cameraMain.transform;
			currentCamPos = transform.position;
			currentCamRot = transform.rotation;
			if (lastCamPos != currentCamPos || lastCamRot != currentCamRot || !Application.isPlaying)
			{
				lastCamPos = currentCamPos;
				lastCamRot = currentCamRot;
				RequestPOIIconsUpdate();
			}
			else
			{
				switch (_updateMode)
				{
				case UpdateMode.NumberOfFrames:
				{
					int frameCount = Time.frameCount;
					if (frameCount - lastUpdateFrameCount >= _updateIntervalFrameCount)
					{
						lastUpdateFrameCount = frameCount;
						RequestPOIIconsUpdate();
					}
					break;
				}
				case UpdateMode.Time:
				{
					float time = Time.time;
					if (time - lastUpdateTime >= _updateIntervalTime)
					{
						lastUpdateTime = time;
						RequestPOIIconsUpdate();
					}
					break;
				}
				case UpdateMode.Continuous:
					RequestPOIIconsUpdate();
					break;
				}
			}
			Matrix4x4 projectionMatrix = cameraMain.projectionMatrix;
			Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
			currentCamVP = projectionMatrix * worldToLocalMatrix;
			CheckPOIListConsistency();
			if (needsIconSorting)
			{
				needsIconSorting = false;
				pois.Sort(IconPriorityComparer);
			}
			if (!Application.isPlaying)
			{
				return;
			}
			Vector3 vector = lastVisitedDistanceFollowPos;
			vector.x -= followPos.x;
			vector.z -= followPos.z;
			if (!(vector.x * vector.x + vector.z * vector.z > 1f))
			{
				return;
			}
			lastVisitedDistanceFollowPos = followPos;
			for (int i = 0; i < pois.Count; i++)
			{
				CompassProPOI compassProPOI = pois[i];
				if (compassProPOI.miniMapShowCircle)
				{
					if (compassProPOI.distanceToFollow < 0.02f)
					{
						if (compassProPOI.insideCircle >= 0)
						{
							compassProPOI.insideCircle = -1;
							OnPOIEnterCircle?.Invoke(compassProPOI);
						}
					}
					else if (compassProPOI.insideCircle <= 0)
					{
						compassProPOI.insideCircle = 1;
						OnPOIExitCircle?.Invoke(compassProPOI);
					}
				}
				if (compassProPOI == null || compassProPOI.isVisited)
				{
					continue;
				}
				float num = ((compassProPOI.visitedDistanceOverride > 0f) ? compassProPOI.visitedDistanceOverride : _visitedDistance);
				if (compassProPOI.canBeVisited && !compassProPOI.isVisited && compassProPOI.distanceToFollow > 0f && compassProPOI.distanceToFollow < num)
				{
					compassProPOI.isVisited = true;
					if (compassProPOI.hideWhenVisited)
					{
						compassProPOI.enabled = false;
					}
					OnPOIVisited?.Invoke(compassProPOI);
					if (compassProPOI == null)
					{
						continue;
					}
					if (compassProPOI.playAudioClipWhenVisited && audioSource != null)
					{
						if (compassProPOI.visitedAudioClipOverride != null)
						{
							audioSource.PlayOneShot(compassProPOI.visitedAudioClipOverride);
						}
						else if (_visitedDefaultAudioClip != null)
						{
							audioSource.PlayOneShot(_visitedDefaultAudioClip);
						}
					}
					ShowPOIDiscoveredText(compassProPOI);
				}
				if (compassProPOI.heartbeatEnabled)
				{
					bool flag = compassProPOI.distanceToFollow < compassProPOI.heartbeatDistance;
					if (!compassProPOI.heartbeatIsActive && flag)
					{
						compassProPOI.StartHeartbeat();
					}
					else if (compassProPOI.heartbeatIsActive && !flag)
					{
						compassProPOI.StopHeartbeat();
					}
					if (compassProPOI == null)
					{
						continue;
					}
				}
				CheckPOIListConsistency();
			}
		}

		private void RequestPOIIconsUpdate()
		{
			needUpdateMiniMapIcons = true;
			needUpdateCompassBarIcons = true;
			needUpdateIndicators = true;
		}

		private void CheckPOIListConsistency()
		{
			for (int i = 0; i < pois.Count; i++)
			{
				if (pois[i] == null)
				{
					pois.RemoveAt(i);
					i--;
				}
			}
		}

		private void ComputePOIViewportPos(CompassProPOI poi)
		{
			poi.prevDistanceToFollow = poi.distanceToFollow;
			Vector3 position = poi.transform.position;
			position.x += poi.positionOffset.x;
			position.y += poi.positionOffset.y;
			position.z += poi.positionOffset.z;
			float num = position.x - followPos.x;
			float num2 = position.z - followPos.z;
			float num3 = num * num + num2 * num2;
			if (_use3Ddistance)
			{
				float num4 = position.y - followPos.y;
				num3 += num4 * num4;
			}
			num3 = Mathf.Sqrt(num3);
			num3 -= poi.radius;
			if (num3 <= 0f)
			{
				num3 = 0.01f;
			}
			poi.distanceToFollow = num3;
			Vector4 vector = default(Vector4);
			vector.x = position.x;
			vector.y = position.y;
			vector.z = position.z;
			vector.w = 1f;
			vector = currentCamVP * vector;
			if (vector.w > 0f)
			{
				if (vector.w < 1E-05f)
				{
					vector.w = 1E-05f;
				}
			}
			else if (vector.w > -1E-05f)
			{
				vector.w = -1E-05f;
			}
			vector.w = 0f - vector.w;
			vector.x /= vector.w;
			vector.y /= vector.w;
			poi.viewportPos.x = vector.x / 2f + 0.5f;
			poi.viewportPos.y = vector.y / 2f + 0.5f;
			poi.viewportPos.z = vector.w;
		}

		private void UpdateCompassBarIcons()
		{
			if (!needUpdateCompassBarIcons || _cameraMain == null)
			{
				return;
			}
			needUpdateCompassBarIcons = false;
			float time = Time.time;
			float num = _width * 0.5f - _endCapsWidth / (float)_cameraMain.pixelWidth;
			ComputeCompassPointsPositions();
			UpdateCardinalPoints(num);
			UpdateOrdinalPoints(num);
			UpdateHalfWinds(num);
			poiVisibleCount = 0;
			nearestPOIDistance = float.MaxValue;
			nearestPOI = null;
			Scene activeScene = SceneManager.GetActiveScene();
			int frameCount = Time.frameCount;
			Vector2 renderingDisplaySize = canvas.renderingDisplaySize;
			float num2 = _bendAmount * -0.5f * renderingDisplaySize.y / canvas.transform.localScale.y;
			int count = pois.Count;
			for (int i = 0; i < count; i++)
			{
				CompassProPOI compassProPOI = pois[i];
				if (!compassProPOI.isActiveAndEnabled)
				{
					compassProPOI.ToggleCompassBarIconVisibility(visible: false);
					continue;
				}
				if (frameCount != compassProPOI.viewportPosFrameCount)
				{
					compassProPOI.viewportPosFrameCount = frameCount;
					ComputePOIViewportPos(compassProPOI);
				}
				bool flag = false;
				float t = compassProPOI.distanceToFollow / _nearDistance;
				_ = compassProPOI.visibility;
				_ = 1;
				float num3 = compassProPOI.iconScale;
				if (!compassProPOI.iconScaleIsFixed)
				{
					num3 *= Mathf.Lerp(_maxIconSize, _minIconSize, t);
				}
				compassProPOI.compassCurrentIconScale = num3;
				bool isVisible = compassProPOI.isVisible;
				float num4 = ((compassProPOI.visibleDistanceOverride > 0f) ? compassProPOI.visibleDistanceOverride : _visibleMaxDistance);
				float num5 = ((compassProPOI.visibleMinDistanceOverride > 0f) ? compassProPOI.visibleMinDistanceOverride : _visibleMinDistance);
				bool flag2 = compassProPOI.distanceToFollow >= num5 && compassProPOI.distanceToFollow < num4;
				compassProPOI.isVisible = (flag2 && compassProPOI.visibility == POIVisibility.WhenInRange) || compassProPOI.visibility == POIVisibility.AlwaysVisible;
				if (compassProPOI.isVisible && compassProPOI.dontDestroyOnLoad && compassProPOI.scene != activeScene)
				{
					compassProPOI.isVisible = false;
				}
				if (compassProPOI.isVisited && compassProPOI.hideWhenVisited)
				{
					compassProPOI.isVisible = false;
				}
				if (Application.isPlaying && isVisible != compassProPOI.isVisible)
				{
					if (compassProPOI.isVisible && OnPOIVisible != null)
					{
						OnPOIVisible(compassProPOI);
					}
					else if (!compassProPOI.isVisible && OnPOIHide != null)
					{
						OnPOIHide(compassProPOI);
					}
				}
				if (!compassProPOI.isVisible)
				{
					compassProPOI.ToggleCompassBarIconVisibility(visible: false);
				}
				else
				{
					if (compassProPOI.compassIconRT == null)
					{
						if (compassIconPrefab == null)
						{
							Debug.LogError("Compass icon prefab couldn't be loaded. This prefab should be located at CompassNavigatorPro/Resources/CNPro/Prefabs/CompassBarIcon");
							continue;
						}
						GameObject gameObject = UnityEngine.Object.Instantiate(compassIconPrefab, compassBackRT, worldPositionStays: false);
						CompassPOIElements component = gameObject.GetComponent<CompassPOIElements>();
						if (component == null)
						{
							Debug.LogError("Compass POI prefab missing Compass POI elements component.");
							DestroySafe(gameObject);
							continue;
						}
						gameObject.name = "CompassIcon " + compassProPOI.gameObject.name;
						compassProPOI.compassIconRT = gameObject.GetComponent<RectTransform>();
						compassProPOI.compassIconImage = component.iconImage;
						compassProPOI.compassIconImage.material = null;
						compassProPOI.compassIconDistanceText = component.distanceText;
						if (compassProPOI.compassIconDistanceText != null)
						{
							compassProPOI.compassIconDistanceTextRT = compassProPOI.compassIconDistanceText.GetComponent<RectTransform>();
						}
						compassProPOI.curvedMaterialSet = false;
						compassProPOI.visibleTime = time;
					}
					if (compassProPOI.curvedMaterialSet)
					{
						if (_bendAmount == 0f && !_edgeFadeOut)
						{
							compassProPOI.compassIconImage.material = null;
						}
					}
					else if (_bendAmount != 0f || _edgeFadeOut)
					{
						compassProPOI.compassIconImage.material = curvedMat;
					}
					Vector3 screenPos = GetScreenPos(compassProPOI);
					float num6 = screenPos.x;
					if (compassProPOI.clampPosition || _focusedPOI == compassProPOI)
					{
						if (screenPos.z < 0f)
						{
							num6 = num * (0f - Mathf.Sign(screenPos.x - 0.5f));
							if (compassProPOI.compassCurrentIconScale > 1f)
							{
								compassProPOI.compassCurrentIconScale = 1f;
							}
						}
						else if (num6 < 0f - num)
						{
							num6 = 0f - num;
							if (compassProPOI.compassCurrentIconScale > 1f)
							{
								compassProPOI.compassCurrentIconScale = 1f;
							}
						}
						else if (num6 > num)
						{
							num6 = num;
							if (compassProPOI.compassCurrentIconScale > 1f)
							{
								compassProPOI.compassCurrentIconScale = 1f;
							}
						}
						screenPos.z = 0f;
					}
					float num7 = Mathf.Abs(num6);
					if (num7 > num || screenPos.z < 0f)
					{
						compassProPOI.ToggleCompassBarIconVisibility(visible: false);
					}
					else
					{
						if (compassProPOI.ToggleCompassBarIconVisibility(visible: true))
						{
							compassProPOI.visibleTime = time;
						}
						RectTransform compassIconRT = compassProPOI.compassIconRT;
						Vector2 anchorMin = (compassProPOI.compassIconRT.anchorMax = new Vector2(0.5f + num6 / _width, 0.5f));
						compassIconRT.anchorMin = anchorMin;
						flag = true;
					}
					if (flag)
					{
						poiVisibleCount++;
						if (compassProPOI.isVisited)
						{
							if (compassProPOI.compassIconImage.sprite != compassProPOI.iconVisited)
							{
								compassProPOI.compassIconImage.sprite = compassProPOI.iconVisited;
							}
						}
						else if (compassProPOI.compassIconImage.sprite != compassProPOI.iconNonVisited)
						{
							compassProPOI.compassIconImage.sprite = compassProPOI.iconNonVisited;
						}
						float num8 = 1f;
						if (_scaleInDuration > 0f)
						{
							float num9 = (time - compassProPOI.visibleTime) / _scaleInDuration;
							if (num9 < 1f)
							{
								needUpdateCompassBarIcons = true;
								compassProPOI.compassCurrentIconScale *= num9;
							}
							else
							{
								num9 = 1f;
							}
							num8 = num9;
						}
						Transform transform = compassProPOI.compassIconImage.transform;
						if (compassProPOI.compassCurrentIconScale != transform.localScale.x)
						{
							transform.localScale = new Vector3(compassProPOI.compassCurrentIconScale, compassProPOI.compassCurrentIconScale, 1f);
						}
						if (compassProPOI.visibility != POIVisibility.AlwaysVisible)
						{
							float value = (_visibleMaxDistance - compassProPOI.distanceToFollow) / 4f;
							value = Mathf.Clamp01(value);
							num8 *= value;
						}
						Color tintColor = compassProPOI.tintColor;
						tintColor.a *= num8;
						compassProPOI.compassIconImage.color = tintColor;
						if (_focusedPOI == compassProPOI || (num7 < _labelHotZone && compassProPOI.distanceToFollow < nearestPOIDistance))
						{
							nearestPOI = compassProPOI;
							nearestPOIDistance = compassProPOI.distanceToFollow;
							nearestPOIAlpha = num8;
						}
						if (compassProPOI.compassIconDistanceText != null)
						{
							bool flag3 = false;
							if (_showDistance && compassProPOI.iconShowDistance && compassProPOI.distanceToFollow > 0.1f)
							{
								flag3 = true;
								if (compassProPOI.lastCompassIconDistance != compassProPOI.distanceToFollow)
								{
									compassProPOI.lastCompassIconDistance = compassProPOI.distanceToFollow;
									compassProPOI.lastCompassIconDistanceText = compassProPOI.distanceToFollow.ToString(_showDistanceFormat);
								}
								compassProPOI.compassIconDistanceText.text = compassProPOI.lastCompassIconDistanceText;
								float num10 = Mathf.Abs(screenPos.x);
								float num11 = (_width - num10 * 2f + 0.001f - _edgeFadeOutStart) / (_edgeFadeOutWidth + 0.0001f);
								if (num11 < 0f)
								{
									num11 = 0f;
								}
								else if (num11 > 1f)
								{
									num11 = 1f;
								}
								compassProPOI.compassIconDistanceText.color = new Color(1f, 1f, 1f, num8 * num11);
								RectTransform compassIconDistanceTextRT = compassProPOI.compassIconDistanceTextRT;
								if (_bendAmount != 0f)
								{
									float y = Mathf.Sin(compassIconDistanceTextRT.position.x / renderingDisplaySize.x * MathF.PI) * num2;
									compassIconDistanceTextRT.localPosition = new Vector3(0f, y, 0f);
								}
								else
								{
									compassIconDistanceTextRT.localPosition = Misc.Vector3zero;
								}
								compassIconDistanceTextRT.sizeDelta = new Vector2(200f, 45f * (1f + Mathf.Max(0f, compassProPOI.compassCurrentIconScale - 1f) * 0.52f));
							}
							else
							{
								flag3 = false;
							}
							compassProPOI.compassIconDistanceText.enabled = flag3;
						}
					}
				}
				if (nearestPOI != null && ((nearestPOI.titleVisibility != TitleVisibility.Never) & (nearestPOI.isVisited || nearestPOI.titleVisibility == TitleVisibility.Always)))
				{
					if (nearestPOI != lastNearestPOI)
					{
						lastNearestPOIDistance = -1f;
					}
					if (lastNearestPOIDistance != nearestPOIDistance)
					{
						lastNearestPOIDistance = nearestPOIDistance;
						if (titleText.Length > 0)
						{
							titleText.Length = 0;
						}
						titleText.Append(nearestPOI.title);
						float num12 = ((nearestPOI.titleMinPOIDistanceOverride > 0f) ? nearestPOI.titleMinPOIDistanceOverride : _titleMinPOIDistance);
						if (lastNearestPOIDistance >= num12)
						{
							bool flag4 = false;
							if (nearestPOI.transform.position.y > lastCamPos.y + _sameAltitudeThreshold)
							{
								if (titleText.Length > 0)
								{
									titleText.Append(" ");
								}
								titleText.Append("(Above");
								flag4 = true;
							}
							else if (nearestPOI.transform.position.y < lastCamPos.y - _sameAltitudeThreshold)
							{
								if (titleText.Length > 0)
								{
									titleText.Append(" ");
								}
								titleText.Append("(Below");
								flag4 = true;
							}
							if (_titleShowDistance)
							{
								if (flag4)
								{
									titleText.Append(", ");
								}
								else
								{
									if (titleText.Length > 0)
									{
										titleText.Append(" ");
									}
									titleText.Append("(");
								}
								titleText.Append(lastNearestPOIDistance.ToString(_titleShowDistanceFormat));
								titleText.Append(")");
							}
							else if (flag4)
							{
								titleText.Append(")");
							}
						}
						string text = titleText.ToString();
						if (!text.Equals(lastNearestPOIDistanceText))
						{
							lastNearestPOIDistanceText = text;
							UpdateTitleText(lastNearestPOIDistanceText);
							UpdateTitleAppearance();
						}
					}
					UpdateTitleAlpha(nearestPOIAlpha);
					Vector3 position = nearestPOI.compassIconRT.position;
					if (_bendAmount != 0f)
					{
						RectTransform rectTransform = titleRT;
						Vector3 position2 = (titleShadowRT.position = new Vector3(position.x, titleRT.position.y, 0f));
						rectTransform.position = position2;
					}
					else
					{
						titleTMPRT.position = new Vector3(position.x, titleRT.position.y, 0f);
					}
				}
				else
				{
					if (_bendAmount != 0f)
					{
						Text obj = title;
						string text2 = (titleShadow.text = "");
						obj.text = text2;
						titleRT.position = titleRTDefaultPosition;
						titleShadowRT.position = titleShadowRTDefaultPosition;
					}
					else
					{
						titleTMP.text = "";
						titleTMPRT.position = titleRTDefaultPosition;
					}
					lastNearestPOIDistanceText = "";
				}
			}
		}

		private int IconPriorityComparer(CompassProPOI p1, CompassProPOI p2)
		{
			if (p1.priority < p2.priority)
			{
				return -1;
			}
			if (p1.priority > p2.priority)
			{
				return 1;
			}
			return 0;
		}

		private Vector3 GetScreenPos(CompassProPOI poi)
		{
			Vector3 result = Misc.Vector3zero;
			switch (_worldMappingMode)
			{
			case WorldMappingMode.LimitedToBarWidth:
				result = poi.viewportPos;
				break;
			case WorldMappingMode.Full180Degrees:
			{
				Vector3 toDirection2 = poi.transform.position - lastCamPos;
				Vector3 forward2 = _cameraMain.transform.forward;
				forward2.y = 0f;
				float num2 = (Quaternion.FromToRotation(forward2, toDirection2).eulerAngles.y + 180f) / 180f;
				result.x = 0.5f + (num2 % 2f - 1f) * (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				break;
			}
			case WorldMappingMode.Full360Degrees:
			{
				Vector3 toDirection = poi.transform.position - lastCamPos;
				Vector3 forward = _cameraMain.transform.forward;
				forward.y = 0f;
				float num = (Quaternion.FromToRotation(forward, toDirection).eulerAngles.y + 180f) / 180f;
				result.x = 0.5f + (num % 2f - 1f) * 0.5f * (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				break;
			}
			default:
				result = poi.viewportPos;
				result.x = 0.5f + (result.x - 0.5f) * (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				break;
			}
			result.x -= 0.5f;
			return result;
		}

		private Vector3 GetScreenPos(Vector3 position)
		{
			Vector3 result = Misc.Vector3zero;
			switch (_worldMappingMode)
			{
			case WorldMappingMode.LimitedToBarWidth:
				result = _cameraMain.WorldToViewportPoint(position);
				break;
			case WorldMappingMode.Full180Degrees:
			{
				Vector3 toDirection2 = position - lastCamPos;
				Vector3 forward2 = _cameraMain.transform.forward;
				forward2.y = 0f;
				float num2 = (Quaternion.FromToRotation(forward2, toDirection2).eulerAngles.y + 180f) / 180f;
				result.x = 0.5f + (num2 % 2f - 1f) * (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				break;
			}
			case WorldMappingMode.Full360Degrees:
			{
				Vector3 toDirection = position - lastCamPos;
				Vector3 forward = _cameraMain.transform.forward;
				forward.y = 0f;
				float num = (Quaternion.FromToRotation(forward, toDirection).eulerAngles.y + 180f) / 180f;
				result.x = 0.5f + (num % 2f - 1f) * 0.5f * (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				break;
			}
			default:
				result = _cameraMain.WorldToViewportPoint(position);
				result.x = 0.5f + (result.x - 0.5f) * (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				break;
			}
			result.x -= 0.5f;
			return result;
		}

		public Sprite GetCompassBarSprite()
		{
			if (compassBackImage == null)
			{
				return null;
			}
			return compassBackImage.sprite;
		}

		private void ComputeCompassPointsPositions()
		{
			if (_cameraMain == null || compassPoints == null)
			{
				return;
			}
			int num = compassPoints.Length;
			if (_northDegrees != usedNorthDegrees)
			{
				usedNorthDegrees = _northDegrees;
				for (int i = 0; i < num; i++)
				{
					float f = MathF.PI * 2f * (float)i / (float)num - _northDegrees * (MathF.PI / 180f);
					compassPoints[i].cos = Mathf.Cos(f);
					compassPoints[i].sin = Mathf.Sin(f);
				}
			}
			for (int j = 0; j < num; j++)
			{
				Vector3 position = lastCamPos;
				position.x += compassPoints[j].cos;
				position.z += compassPoints[j].sin;
				compassPoints[j].position = position;
			}
		}

		private void UpdateCardinalPoints(float barMax)
		{
			float num = ((_worldMappingMode == WorldMappingMode.Full180Degrees || _worldMappingMode == WorldMappingMode.Full360Degrees) ? 0f : 0.001f);
			int num2 = cardinals.Length;
			for (int i = 0; i < num2; i++)
			{
				int num3 = cardinals[i];
				if (!_showCardinalPoints || _style.HasDegreesOrTicks())
				{
					if (compassPoints[num3].text.enabled)
					{
						compassPoints[num3].text.enabled = false;
					}
					continue;
				}
				Vector3 screenPos = GetScreenPos(compassPoints[num3].position);
				float x = screenPos.x;
				if (Mathf.Abs(x) > barMax || screenPos.z < num)
				{
					if (compassPoints[num3].text.enabled)
					{
						compassPoints[num3].text.enabled = false;
					}
					continue;
				}
				if (!compassPoints[num3].text.enabled)
				{
					compassPoints[num3].text.enabled = true;
				}
				RectTransform rectTransform = compassPoints[num3].text.rectTransform;
				Vector2 anchorMin = (rectTransform.anchorMax = new Vector2(0.5f + x / _width, 0.5f + _cardinalPointsVerticalOffset / rectTransform.sizeDelta.y));
				rectTransform.anchorMin = anchorMin;
				rectTransform.localScale = new Vector3(0.12f * _cardinalScale, 0.12f * _cardinalScale, 1f);
			}
		}

		private void UpdateOrdinalPoints(float barMax)
		{
			float num = ((_worldMappingMode == WorldMappingMode.Full180Degrees || _worldMappingMode == WorldMappingMode.Full360Degrees) ? 0f : 0.001f);
			for (int i = 0; i < ordinals.Length; i++)
			{
				int num2 = ordinals[i];
				if (compassPoints[num2].text == null)
				{
					continue;
				}
				if (!_showOrdinalPoints || _style.HasDegreesOrTicks())
				{
					if (compassPoints[num2].text.enabled)
					{
						compassPoints[num2].text.enabled = false;
					}
					continue;
				}
				Vector3 screenPos = GetScreenPos(compassPoints[num2].position);
				float x = screenPos.x;
				if (Mathf.Abs(x) > barMax || screenPos.z < num)
				{
					if (compassPoints[num2].text.enabled)
					{
						compassPoints[num2].text.enabled = false;
					}
					continue;
				}
				if (!compassPoints[num2].text.enabled)
				{
					compassPoints[num2].text.enabled = true;
				}
				RectTransform rectTransform = compassPoints[num2].text.rectTransform;
				Vector2 anchorMin = (rectTransform.anchorMax = new Vector2(0.5f + x / _width, 0.5f + _cardinalPointsVerticalOffset / rectTransform.sizeDelta.y));
				rectTransform.anchorMin = anchorMin;
				rectTransform.localScale = new Vector3(0.12f * _ordinalScale, 0.12f * _ordinalScale, 1f);
			}
		}

		private void UpdateCompassBarAlpha()
		{
			if (!_showCompassBar)
			{
				return;
			}
			if (_alwaysVisibleInEditMode && !Application.isPlaying)
			{
				thisAlpha = Mathf.Max(0.2f, _alpha);
			}
			else if (_autoHide)
			{
				if (!autoHiding)
				{
					if (poiVisibleCount == 0)
					{
						if (thisAlpha > 0f)
						{
							autoHiding = true;
							fadeStartTime = Time.time;
							prevAlpha = canvasGroup.alpha;
							thisAlpha = 0f;
						}
					}
					else if (poiVisibleCount > 0 && thisAlpha == 0f)
					{
						thisAlpha = _alpha;
						autoHiding = true;
						fadeStartTime = Time.time;
						prevAlpha = canvasGroup.alpha;
					}
				}
			}
			else
			{
				thisAlpha = _alpha;
			}
			if (_miniMapFullScreenState && _showMiniMap)
			{
				thisAlpha = 0f;
			}
			if (thisAlpha != canvasGroup.alpha)
			{
				float num = (Application.isPlaying ? ((Time.time - fadeStartTime) / _fadeDuration) : 1f);
				canvasGroup.alpha = Mathf.Lerp(prevAlpha, thisAlpha, num);
				if (num >= 1f)
				{
					prevAlpha = canvasGroup.alpha;
				}
				canvasGroup.gameObject.SetActive(canvasGroup.alpha > 0f);
			}
			else if (autoHiding)
			{
				autoHiding = false;
			}
		}

		private void UpdateCompassBarAppearance()
		{
			if (compassBackImage.isActiveAndEnabled != _showCompassBar)
			{
				compassBackRT.gameObject.SetActive(_showCompassBar);
			}
			float num = (1f - _width) * 0.5f;
			float num2 = 1f - num;
			compassBackRT.anchorMin = new Vector2(num + _horizontalPosition, _verticalPosition);
			compassBackRT.anchorMax = new Vector2(num2 + _horizontalPosition, _verticalPosition);
			compassBackRT.sizeDelta = new Vector2(compassBackRT.sizeDelta.x, 25f * _height);
			if (compassBarMat == null)
			{
				compassBarMat = UnityEngine.Object.Instantiate(Resources.Load<Material>("CNPro/Materials/CompassBar"));
			}
			compassBarMat.DisableKeyword("SCROLLABLE");
			compassBarMat.DisableKeyword("SCROLLABLE_180");
			compassBarMat.DisableKeyword("SCROLLABLE_360");
			Sprite sprite;
			switch (_style)
			{
			case CompassStyle.Rounded:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar2");
				break;
			case CompassStyle.Celtic_White:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar3-White");
				break;
			case CompassStyle.Celtic_Black:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar3-Black");
				break;
			case CompassStyle.Fantasy1:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar4");
				break;
			case CompassStyle.Fantasy2:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar5");
				break;
			case CompassStyle.Fantasy3:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar8");
				break;
			case CompassStyle.Fantasy4:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar9");
				break;
			case CompassStyle.SciFi1:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar6");
				break;
			case CompassStyle.SciFi2:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar7");
				break;
			case CompassStyle.SciFi3:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar10");
				break;
			case CompassStyle.SciFi4:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar11");
				break;
			case CompassStyle.SciFi5:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar12");
				break;
			case CompassStyle.SciFi6:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar13");
				break;
			case CompassStyle.Clean:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar14");
				break;
			case CompassStyle.CleanWithIntegratedDegrees:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar15");
				worldMappingMode = WorldMappingMode.Full180Degrees;
				SetCompassScrollableProperties(0.5f);
				break;
			case CompassStyle.CleanWithIntegratedDegreesAndTicks1:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar16");
				worldMappingMode = WorldMappingMode.Full180Degrees;
				SetCompassScrollableProperties(0.5f);
				break;
			case CompassStyle.CleanWithIntegratedDegreesAndTicks2:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar17");
				worldMappingMode = WorldMappingMode.Full180Degrees;
				SetCompassScrollableProperties(0.5f);
				break;
			case CompassStyle.CleanWithIntegratedDegreesAndTicks3:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar18");
				worldMappingMode = WorldMappingMode.Full180Degrees;
				SetCompassScrollableProperties(0.5f);
				break;
			case CompassStyle.CleanWithIntegratedDegreesAndTicks4:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar19");
				worldMappingMode = WorldMappingMode.Full180Degrees;
				SetCompassScrollableProperties(0.5f);
				break;
			case CompassStyle.Custom:
				sprite = _compassBackSprite;
				if (_compassBackSpriteScrollable)
				{
					SetCompassScrollableProperties(_compassBackSpriteScrollOffset);
				}
				break;
			default:
				sprite = Resources.Load<Sprite>("CNPro/Sprites/Bar1");
				break;
			}
			if (sprite != null && compassBackImage.sprite != sprite)
			{
				compassBackImage.sprite = sprite;
			}
			ToggleCurvedCompass();
			if (cameraMain != null)
			{
				float x = (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				Vector4 value = new Vector4(x, _horizontalPosition + 0.5f, _width * 0.5f - _endCapsWidth / (float)_cameraMain.pixelWidth);
				if (_worldMappingMode == WorldMappingMode.LimitedToBarWidth)
				{
					value.x = 1f;
				}
				if (compassBarMat != null)
				{
					compassBarMat.SetVector(ShaderParams.CompassData, value);
				}
				if (defaultUICurvedMatForCardinals != null)
				{
					defaultUICurvedMatForCardinals.SetVector(ShaderParams.CompassData, value);
				}
				if (defaultUICurvedMatForText != null)
				{
					defaultUICurvedMatForText.SetVector(ShaderParams.CompassData, value);
				}
				if (curvedMat != null)
				{
					curvedMat.SetVector(ShaderParams.CompassData, value);
				}
			}
		}

		private void SetCompassScrollableProperties(float offset)
		{
			switch (_worldMappingMode)
			{
			case WorldMappingMode.Full360Degrees:
				compassBarMat.EnableKeyword("SCROLLABLE_360");
				break;
			case WorldMappingMode.Full180Degrees:
				compassBarMat.EnableKeyword("SCROLLABLE_180");
				break;
			default:
				compassBarMat.EnableKeyword("SCROLLABLE");
				break;
			}
			compassBarMat.SetFloat(ShaderParams.ScrollOffset, offset);
		}

		private void UpdateHalfWinds(float barMax)
		{
			if (!(compassBarMat == null))
			{
				compassBarMat.SetFloat(ShaderParams.CompassAngle, currentCamRot.eulerAngles.y - _northDegrees);
				if (_worldMappingMode == WorldMappingMode.LimitedToBarWidth || _worldMappingMode == WorldMappingMode.CameraFrustum)
				{
					compassBarMat.SetMatrix(ShaderParams.CompassIP, _cameraMain.projectionMatrix.inverse);
				}
			}
		}

		private void UpdateHalfWindsAppearance()
		{
			compassBarMat.DisableKeyword("TICKS");
			compassBarMat.DisableKeyword("TICKS_180");
			compassBarMat.DisableKeyword("TICKS_360");
			if (_showHalfWinds && !(cameraMain == null) && !_style.HasDegreesOrTicks())
			{
				float x = (_width - _endCapsWidth / (float)_cameraMain.pixelWidth) * 0.9f;
				Vector4 value = new Vector4(x, _horizontalPosition + 0.5f, _width * 0.5f - _endCapsWidth / (float)_cameraMain.pixelWidth);
				switch (_worldMappingMode)
				{
				case WorldMappingMode.LimitedToBarWidth:
					value.x = 1f;
					compassBarMat.EnableKeyword("TICKS");
					break;
				case WorldMappingMode.CameraFrustum:
					compassBarMat.EnableKeyword("TICKS");
					break;
				case WorldMappingMode.Full180Degrees:
					compassBarMat.EnableKeyword("TICKS_180");
					break;
				case WorldMappingMode.Full360Degrees:
					compassBarMat.EnableKeyword("TICKS_360");
					break;
				}
				compassBarMat.SetVector(ShaderParams.CompassData, value);
				compassBarMat.SetColor(ShaderParams.TicksColor, _halfWindsTintColor);
				compassBarMat.SetVector(ShaderParams.TicksSize, new Vector4(_halfWindsWidth, _halfWindsHeight, _halfWindsInterval, 0f));
			}
		}

		public void UpdateTextAppearanceEditMode()
		{
			if (base.gameObject.activeInHierarchy)
			{
				this.text.gameObject.SetActive(_textRevealEnabled);
				textShadow.gameObject.SetActive(_textRevealEnabled);
				Text obj = this.text;
				string text = (textShadow.text = "SAMPLE TEXT");
				obj.text = text;
				UpdateTextAlpha(1f);
				UpdateTextAppearance();
			}
		}

		private void UpdateTextAppearance()
		{
			text.alignment = TextAnchor.MiddleCenter;
			Vector3 localScale = new Vector3(_textScale, _textScale, 1f);
			RectTransform component = text.GetComponent<RectTransform>();
			component.pivot = new Vector2(0.5f, 0.5f);
			component.anchoredPosition3D = new Vector3(0f, _textVerticalPosition, 0f);
			text.transform.localScale = localScale;
			text.font = _textFont;
			textShadow.enabled = _textShadowEnabled;
			textShadow.alignment = TextAnchor.MiddleCenter;
			RectTransform component2 = textShadow.GetComponent<RectTransform>();
			component2.pivot = new Vector2(0.5f, 0.5f);
			component2.anchoredPosition3D = new Vector3(1f, _textVerticalPosition - 1f, 0f);
			textShadow.transform.localScale = localScale;
			textShadow.font = _textFont;
		}

		private void UpdateTextAlpha(float t)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, t);
			textShadow.color = new Color(0f, 0f, 0f, t);
		}

		public void UpdateTitleAppearanceEditMode()
		{
			if (base.gameObject.activeInHierarchy && !Application.isPlaying)
			{
				UpdateTitleText("SAMPLE TITLE");
				UpdateTitleAlpha(1f);
				UpdateTitleAppearance();
			}
		}

		private void UpdateTitleText(string text)
		{
			if (_bendAmount != 0f)
			{
				Text obj = title;
				string text2 = (titleShadow.text = text);
				obj.text = text2;
			}
			else
			{
				titleTMP.text = text;
			}
		}

		private void UpdateTitleAppearance()
		{
			if (_bendAmount != 0f)
			{
				titleRT.anchoredPosition3D = new Vector3(0f, _titleVerticalPosition, 0f);
				Vector3 localScale = new Vector3(_titleScale, _titleScale, 1f);
				titleRT.localScale = localScale;
				title.font = _titleFont;
				titleShadow.enabled = _titleShadowEnabled;
				titleShadowRT.anchoredPosition3D = new Vector3(1f, _titleVerticalPosition - 1f, 0f);
				titleShadow.transform.localScale = localScale;
				titleShadow.font = _titleFont;
				titleRT.gameObject.SetActive(value: true);
				titleShadowRT.gameObject.SetActive(value: true);
				titleTMPRT.gameObject.SetActive(value: false);
			}
			else
			{
				titleTMPRT.anchoredPosition3D = new Vector3(0f, _titleVerticalPosition, 0f);
				Vector3 localScale2 = new Vector3(_titleScale, _titleScale, 1f);
				titleTMPRT.localScale = localScale2;
				titleTMP.font = _titleFontTMP;
				titleRT.gameObject.SetActive(value: false);
				titleShadowRT.gameObject.SetActive(value: false);
				titleTMPRT.gameObject.SetActive(value: true);
			}
		}

		private void UpdateTitleAlpha(float t)
		{
			if (_bendAmount != 0f)
			{
				title.color = new Color(title.color.r, title.color.g, title.color.b, t);
				titleShadow.color = new Color(0f, 0f, 0f, t);
			}
			else
			{
				titleTMP.color = new Color(titleTMP.color.r, titleTMP.color.g, titleTMP.color.b, t);
			}
		}

		private void SetupTextPool()
		{
			if (Application.isPlaying)
			{
				Text obj = this.text;
				string text = (textShadow.text = "");
				obj.text = text;
				UpdateTextAppearance();
				if (textPool == null || textPool.Length != 256)
				{
					textPool = new LetterAnimator[256];
				}
				GameObject gameObject = GameObject.Find("CompassProTextPool");
				if (gameObject == null)
				{
					gameObject = new GameObject("CompassProTextPool");
				}
				canvasTextPool = gameObject.transform;
				for (int i = 0; i < 256; i++)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(textShadow.gameObject, canvasTextPool, worldPositionStays: false);
					gameObject2.name = "TextShadowPool";
					Text component = gameObject2.GetComponent<Text>();
					GameObject gameObject3 = UnityEngine.Object.Instantiate(this.text.gameObject, canvasTextPool, worldPositionStays: false);
					gameObject3.name = "TextPool";
					Text component2 = gameObject3.GetComponent<Text>();
					LetterAnimator letterAnimator = component.gameObject.AddComponent<LetterAnimator>();
					letterAnimator.poolIndex = i;
					letterAnimator.text = component2;
					letterAnimator.textShadow = component;
					letterAnimator.OnAnimationEnds = (OnAnimationEndDelegate)Delegate.Combine(letterAnimator.OnAnimationEnds, new OnAnimationEndDelegate(PushTextToPool));
					letterAnimator.used = false;
					textPool[i] = letterAnimator;
					textPoolOriginalLocalPosition = gameObject3.transform.localPosition;
					textPoolOriginalShadowLocalPosition = gameObject2.transform.localPosition;
				}
			}
		}

		private void FetchTextFromPool(out Text lt, out Text lts)
		{
			for (int i = 0; i < 256; i++)
			{
				poolIndex++;
				if (poolIndex >= 256)
				{
					poolIndex = 0;
				}
				if (!textPool[poolIndex].used)
				{
					break;
				}
			}
			lts = textPool[poolIndex].textShadow;
			lts.transform.SetParent(compassBackRT, worldPositionStays: false);
			SetCurvedTextMaterial(lts);
			lt = textPool[poolIndex].text;
			lt.transform.SetParent(compassBackRT, worldPositionStays: false);
			SetCurvedTextMaterial(lt);
			textPool[poolIndex].used = true;
		}

		private void PushTextToPool(int index)
		{
			Transform obj = textPool[index].text.transform;
			obj.SetParent(canvasTextPool);
			obj.localPosition = textPoolOriginalLocalPosition;
			Transform obj2 = textPool[index].textShadow.transform;
			obj2.SetParent(canvasTextPool);
			obj2.localPosition = textPoolOriginalShadowLocalPosition;
			textPool[index].used = false;
		}

		private void ShowPOIDiscoveredText(CompassProPOI poi)
		{
			if (_textRevealEnabled && _showCompassBar && !string.IsNullOrEmpty(poi.visitedText))
			{
				StartCoroutine(AnimateDiscoverText(poi.visitedText));
			}
		}

		private IEnumerator AnimateDiscoverText(string discoverText)
		{
			int len = discoverText.Length;
			if (!(_cameraMain == null) && textPool != null && textPool.Length == 256)
			{
				while (Time.time < endTimeOfCurrentTextReveal)
				{
					yield return Misc.WaitForOneSecond;
				}
				float time = Time.time;
				endTimeOfCurrentTextReveal = time + _textRevealDuration + _textDuration + _textFadeOutDuration * 0.5f;
				Text obj = this.text;
				string text = (textShadow.text = "");
				obj.text = text;
				UpdateTextAppearance();
				TextGenerationSettings generationSettings = this.text.GetGenerationSettings(Misc.Vector2zero);
				generationSettings.scaleFactor = 1f;
				TextGenerator cachedTextGenerator = this.text.cachedTextGenerator;
				float num = _textScale * _textLetterSpacing;
				string str = discoverText.Replace(" ", "A");
				float num2 = cachedTextGenerator.GetPreferredWidth(str, generationSettings) * -0.5f * num;
				float num3 = cachedTextGenerator.GetPreferredWidth("A", generationSettings) * num;
				float num4 = 0f;
				for (int i = 0; i < len; i++)
				{
					string text3 = discoverText.Substring(i, 1);
					FetchTextFromPool(out var lt, out var lts);
					lts.text = text3;
					lt.text = text3;
					float num5 = ((!" ".Equals(text3)) ? (cachedTextGenerator.GetPreferredWidth(text3, generationSettings) * num) : num3);
					RectTransform component = lt.GetComponent<RectTransform>();
					component.anchoredPosition3D = new Vector3(num2 + num4 + num5 * 0.5f, component.anchoredPosition3D.y, 0f);
					RectTransform component2 = lts.GetComponent<RectTransform>();
					component2.anchoredPosition3D = new Vector3(num2 + num4 + num5 * 0.5f + 1f, component2.anchoredPosition3D.y, 0f);
					num4 += num5;
					LetterAnimator obj2 = textPool[poolIndex];
					obj2.startTime = time + (float)i * _textRevealLetterDelay;
					obj2.revealDuration = _textRevealDuration;
					obj2.startFadeTime = time + _textRevealDuration + _textDuration;
					obj2.fadeDuration = _textFadeOutDuration;
					obj2.enabled = true;
					obj2.Play();
				}
			}
		}

		private void ToggleCurvedCompass()
		{
			if (compassBackRT == null)
			{
				return;
			}
			if (compassBackImage.GetComponent<CompassBarMeshModifier>() == null)
			{
				compassBackImage.gameObject.AddComponent<CompassBarMeshModifier>();
			}
			Vector4 value = new Vector4(_bendAmount, _width, _edgeFadeOutWidth, _edgeFadeOutStart);
			if (!_edgeFadeOut)
			{
				value.z = (value.w = 0f);
			}
			compassBarMat.SetVector(ShaderParams.FXData, value);
			compassBarMat.SetColor(ShaderParams.TintColor, _compassTintColor);
			compassBackImage.material = compassBarMat;
			if (curvedMat == null)
			{
				curvedMat = UnityEngine.Object.Instantiate(Resources.Load<Material>("CNPro/Materials/SpriteCurved"));
				curvedMat.DisableKeyword("TICKS");
				curvedMat.DisableKeyword("TICKS_180");
				curvedMat.DisableKeyword("TICKS_360");
			}
			if (defaultUICurvedMatForCardinals == null)
			{
				defaultUICurvedMatForCardinals = UnityEngine.Object.Instantiate(Resources.Load<Material>("CNPro/Materials/UIDefaultCurved"));
				defaultUICurvedMatForText = UnityEngine.Object.Instantiate(defaultUICurvedMatForCardinals);
			}
			curvedMat.SetVector(ShaderParams.FXData, value);
			defaultUICurvedMatForCardinals.SetVector(ShaderParams.FXData, value);
			value.z = (value.w = 0f);
			defaultUICurvedMatForText.SetVector(ShaderParams.FXData, value);
			Image[] componentsInChildren = compassBackRT.GetComponentsInChildren<Image>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i] != compassBackImage)
				{
					componentsInChildren[i].material = curvedMat;
				}
			}
			Text[] componentsInChildren2 = compassBackRT.GetComponentsInChildren<Text>(includeInactive: true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				if (componentsInChildren2[j].name.Contains("Cardinal"))
				{
					componentsInChildren2[j].material = defaultUICurvedMatForCardinals;
				}
				else
				{
					componentsInChildren2[j].material = defaultUICurvedMatForText;
				}
			}
			RawImage[] componentsInChildren3 = compassBackRT.GetComponentsInChildren<RawImage>(includeInactive: true);
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				componentsInChildren3[k].material = defaultUICurvedMatForCardinals;
			}
		}

		private void SetCurvedTextMaterial(Text text)
		{
			if (_bendAmount != 0f)
			{
				text.material = defaultUICurvedMatForText;
			}
			else
			{
				text.material = null;
			}
		}

		private void UpdateFogOfWarOnLoadScene(Scene scene, LoadSceneMode loadMode)
		{
			if (loadMode == LoadSceneMode.Single)
			{
				UpdateFogOfWar();
			}
		}

		private void UpdateFogOfWarTexture()
		{
			if (miniMapCamera == null)
			{
				return;
			}
			Transform transform = base.transform.Find("FogOfWarLayer");
			if (transform != null)
			{
				UnityEngine.Object.DestroyImmediate(transform.gameObject);
			}
			if (!currentMiniMapUsesFogOfWar)
			{
				return;
			}
			if (fogOfWarTexture == null || fogOfWarTexture.width != _fogOfWarTextureSize || fogOfWarTexture.height != _fogOfWarTextureSize)
			{
				fogOfWarTexture = new Texture2D(_fogOfWarTextureSize, _fogOfWarTextureSize, TextureFormat.Alpha8, mipChain: false);
				fogOfWarTexture.filterMode = FilterMode.Bilinear;
				fogOfWarTexture.wrapMode = TextureWrapMode.Clamp;
				ResetFogOfWar(_fogOfWarDefaultAlpha);
			}
			else if (fogOfWarColorBuffer == null || fogOfWarColorBuffer.Length != fogOfWarTexture.width * fogOfWarTexture.height || !Application.isPlaying)
			{
				ResetFogOfWar(_fogOfWarDefaultAlpha);
			}
			CompassProFogVolume[] array = Misc.FindObjectsOfType<CompassProFogVolume>();
			Array.Sort(array, VolumeComparer);
			for (int i = 0; i < array.Length; i++)
			{
				Collider component = array[i].GetComponent<Collider>();
				if (component != null && component.gameObject.activeInHierarchy)
				{
					SetFogOfWarAlpha(component.bounds, array[i].alpha, array[i].border);
				}
			}
			needFogOfWarTextureUpdate = true;
		}

		private void UpdateFogOfWarPosition()
		{
			if (!currentMiniMapUsesFogOfWar)
			{
				return;
			}
			if (needFogOfWarUpdate)
			{
				needFogOfWarUpdate = false;
				UpdateFogOfWarTexture();
			}
			if (_fogOfWarAutoClear)
			{
				int num = (int)followPos.x;
				int num2 = (int)followPos.z;
				if (num != fogOfWarAutoClearLastPosX || num2 != fogOfWarAutoClearLastPosZ)
				{
					fogOfWarAutoClearLastPosX = num;
					fogOfWarAutoClearLastPosZ = num2;
					SetFogOfWarAlpha(followPos, _fogOfWarAutoClearRadius, 0f, 1f);
				}
			}
			if (needFogOfWarTextureUpdate)
			{
				needFogOfWarTextureUpdate = false;
				if (fogOfWarTexture != null)
				{
					fogOfWarTexture.SetPixels32(fogOfWarColorBuffer);
					fogOfWarTexture.Apply();
				}
			}
		}

		private int VolumeComparer(CompassProFogVolume v1, CompassProFogVolume v2)
		{
			if (v1.order < v2.order)
			{
				return -1;
			}
			if (v1.order > v2.order)
			{
				return 1;
			}
			return 0;
		}

		private void InitIndicators()
		{
			if (_onScreenIndicatorPrefab == null)
			{
				_onScreenIndicatorPrefab = Resources.Load<GameObject>("CNPro/Prefabs/POIGizmo");
			}
			if (indicatorsRoot == null)
			{
				indicatorsRoot = base.transform.Find("OnScreen Indicators Root");
				if (indicatorsRoot == null)
				{
					GameObject gameObject = Resources.Load<GameObject>("CNPro/Prefabs/OnScreenIndicatorsRoot");
					if (gameObject != null)
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, base.transform, worldPositionStays: false);
						gameObject2.name = "OnScreen Indicators Root";
						indicatorsRoot = gameObject2.transform;
					}
				}
			}
			indicatorsRoot.gameObject.SetActive(_showOnScreenIndicators || _showOffScreenIndicators);
		}

		private void DisableIndicators()
		{
			if (indicatorsRoot != null)
			{
				indicatorsRoot.gameObject.SetActive(value: false);
			}
		}

		private void UpdateIndicators()
		{
			float aspect = _cameraMain.aspect;
			float num = 1f;
			float num2 = _offScreenIndicatorOverlapDistance * 0.9f;
			float num3 = _offScreenIndicatorRect.width;
			float num4 = _offScreenIndicatorRect.height;
			float num5 = (0.5f - _offScreenIndicatorMargin) * num3;
			float num6 = (0.5f - _offScreenIndicatorMargin * aspect) * num4;
			float num7 = _offScreenIndicatorRect.xMin + _offScreenIndicatorMargin;
			float num8 = _offScreenIndicatorRect.xMax - _offScreenIndicatorMargin;
			float num9 = _offScreenIndicatorRect.yMin + _offScreenIndicatorMargin * aspect;
			float num10 = _offScreenIndicatorRect.yMax - _offScreenIndicatorMargin * aspect;
			float x = _offScreenIndicatorRect.center.x;
			float y = _offScreenIndicatorRect.center.y;
			Vector3 vector3one = Misc.Vector3one;
			float t = Time.deltaTime * 10f;
			int frameCount = Time.frameCount;
			int a = 0;
			int count = pois.Count;
			if (needUpdateIndicators)
			{
				needUpdateIndicators = false;
				for (int i = 0; i < count; i++)
				{
					pois[i].lastIndicatorViewportPos.x = -1f;
				}
			}
			for (int j = 0; j < count; j++)
			{
				CompassProPOI compassProPOI = pois[j];
				if (!compassProPOI.isActiveAndEnabled)
				{
					compassProPOI.ToggleIndicatorVisibility(visible: false);
					continue;
				}
				bool flag = !_miniMapFullScreenState || !_showMiniMap;
				if (compassProPOI.isVisited && compassProPOI.hideWhenVisited)
				{
					flag = false;
				}
				if (!flag)
				{
					compassProPOI.ToggleIndicatorVisibility(visible: false);
					continue;
				}
				if (frameCount != compassProPOI.viewportPosFrameCount)
				{
					compassProPOI.viewportPosFrameCount = frameCount;
					ComputePOIViewportPos(compassProPOI);
				}
				float num11 = ((compassProPOI.onScreenIndicatorFarDistance > 0f) ? compassProPOI.onScreenIndicatorFarDistance : _onScreenIndicatorFarDistance);
				if (compassProPOI.distanceToFollow > num11)
				{
					compassProPOI.ToggleIndicatorVisibility(visible: false);
					continue;
				}
				Vector3 vector = compassProPOI.viewportPos;
				bool flag2 = vector.z > 0f && vector.x >= num7 && vector.x < num8 && vector.y >= num9 && vector.y < num10;
				float num12 = 0f;
				float y2 = 1f;
				if (flag2)
				{
					flag = _showOnScreenIndicators && compassProPOI.showOnScreenIndicator;
					if (flag && compassProPOI.isOnScreen >= 0)
					{
						compassProPOI.isOnScreen = -1;
						OnPOIOnScreen?.Invoke(compassProPOI);
					}
					y2 = _onScreenIndicatorScale * compassProPOI.onScreenIndicatorScale;
				}
				else
				{
					flag = _showOffScreenIndicators && compassProPOI.showOffScreenIndicator;
					if (flag)
					{
						if (compassProPOI.isOnScreen <= 0)
						{
							compassProPOI.isOnScreen = 1;
							OnPOIOffScreen?.Invoke(compassProPOI);
						}
						y2 = _offScreenIndicatorScale * compassProPOI.onScreenIndicatorScale;
						vector.x -= 0.5f;
						vector.y -= 0.5f;
						if (vector.z < 0f)
						{
							vector *= -1f;
							if (vector.y > 0f)
							{
								vector.y = 0f - vector.y;
							}
						}
						num12 = Mathf.Atan2(vector.y, vector.x);
						float num13 = Mathf.Tan(num12);
						float num14;
						float num15;
						if (compassProPOI.offScreenIndicatorMarginOverride != 0f)
						{
							num14 = (0.5f - compassProPOI.offScreenIndicatorMarginOverride) * num3;
							num15 = (0.5f - compassProPOI.offScreenIndicatorMarginOverride * aspect) * num4;
						}
						else
						{
							num14 = num5;
							num15 = num6;
						}
						if (vector.x > 0f)
						{
							vector.x = num14;
							vector.y = num14 * num13;
						}
						else
						{
							vector.x = 0f - num14;
							vector.y = (0f - num14) * num13;
						}
						if (vector.y > num15)
						{
							vector.x = num15 / num13;
							vector.y = num15;
						}
						else if (vector.y < 0f - num15)
						{
							vector.x = (0f - num15) / num13;
							vector.y = 0f - num15;
						}
						if (_offScreenIndicatorAvoidOverlap)
						{
							float num16 = 0f;
							bool num17 = vector.x * vector.x > vector.y * vector.y;
							int num18 = Mathf.Min(a, 100);
							if (num17)
							{
								for (int k = 0; k < num18; k++)
								{
									float num19 = lastVPos[k].x - vector.x;
									if (num19 < 0f)
									{
										num19 = 0f - num19;
									}
									float num20 = lastVPos[k].y - vector.y;
									if (num20 < 0f)
									{
										num20 = 0f - num20;
									}
									if (num19 < num2 && num20 < num2)
									{
										if (num16 <= 0f)
										{
											vector = lastVPos[k];
											num16 = _offScreenIndicatorOverlapDistance * num;
										}
										vector.y += num16;
										if (vector.y < -0.4f || vector.y > 0.4f)
										{
											break;
										}
										k = -1;
									}
								}
							}
							else
							{
								for (int l = 0; l < num18; l++)
								{
									float num21 = lastVPos[l].x - vector.x;
									if (num21 < 0f)
									{
										num21 = 0f - num21;
									}
									float num22 = lastVPos[l].y - vector.y;
									if (num22 < 0f)
									{
										num22 = 0f - num22;
									}
									if (num21 < num2 && num22 < num2)
									{
										if (num16 <= 0f)
										{
											vector = lastVPos[l];
											num16 = _offScreenIndicatorOverlapDistance * num;
										}
										vector.x += num16;
										if (vector.x < -0.4f || vector.x > 0.4f)
										{
											break;
										}
										l = -1;
									}
								}
							}
							num = 0f - num;
							lastVPos[a++] = vector;
						}
						vector.x += x;
						vector.y += y;
					}
				}
				if (compassProPOI.indicatorImage != null)
				{
					compassProPOI.ToggleIndicatorVisibility(flag);
					if (!flag)
					{
						continue;
					}
				}
				else
				{
					if (!flag)
					{
						continue;
					}
					GameObject indicator = GetIndicator();
					compassProPOI.indicatorRT = indicator.GetComponent<RectTransform>();
					compassProPOI.indicatorCanvasGroup = indicator.GetComponent<CanvasGroup>();
					GizmoElements componentInChildren = indicator.GetComponentInChildren<GizmoElements>();
					if (componentInChildren == null)
					{
						Debug.LogError("Gizmo prefab missing GizmoElements component.");
						UnityEngine.Object.DestroyImmediate(indicator);
						continue;
					}
					compassProPOI.indicatorImage = componentInChildren.iconImage;
					compassProPOI.indicatorDistanceText = componentInChildren.distanceText;
					compassProPOI.indicatorTitleText = componentInChildren.titleText;
					compassProPOI.indicatorArrowRT = componentInChildren.arrowPivot;
					compassProPOI.indicatorRT.localScale = Misc.Vector3zero;
				}
				RectTransform indicatorRT = compassProPOI.indicatorRT;
				vector3one.x = (vector3one.y = y2);
				Vector3 localScale = Vector3.Lerp(indicatorRT.localScale, vector3one, t);
				indicatorRT.localScale = localScale;
				if (compassProPOI.lastIndicatorViewportPos == vector)
				{
					continue;
				}
				compassProPOI.lastIndicatorViewportPos = vector;
				RectTransform indicatorRT2 = compassProPOI.indicatorRT;
				Vector2 anchorMin = (compassProPOI.indicatorRT.anchorMax = vector);
				indicatorRT2.anchorMin = anchorMin;
				compassProPOI.indicatorImage.sprite = ((compassProPOI.isVisited && compassProPOI.iconVisited != null) ? compassProPOI.iconVisited : compassProPOI.iconNonVisited);
				bool flag3 = flag2 && compassProPOI.onScreenIndicatorShowDistance && _onScreenIndicatorShowDistance;
				if (compassProPOI.indicatorDistanceText.isActiveAndEnabled != flag3)
				{
					compassProPOI.indicatorDistanceText.gameObject.SetActive(flag3);
				}
				bool flag4 = flag2 && compassProPOI.onScreenIndicatorShowTitle && _onScreenIndicatorShowTitle;
				if (compassProPOI.indicatorTitleText.isActiveAndEnabled != flag4)
				{
					compassProPOI.indicatorTitleText.gameObject.SetActive(flag4);
				}
				float num26;
				if (flag2)
				{
					float num23 = ((compassProPOI.onScreenIndicatorNearFadeMin > 0f) ? compassProPOI.onScreenIndicatorNearFadeMin : _onScreenIndicatorNearFadeMin);
					float num24 = ((compassProPOI.onScreenIndicatorNearFadeDistance > 0f) ? compassProPOI.onScreenIndicatorNearFadeDistance : _onScreenIndicatorNearFadeDistance);
					float num25 = ((num24 <= num23) ? 1f : Mathf.Clamp01((compassProPOI.distanceToFollow - num23) / (num24 - num23)));
					num26 = _onScreenIndicatorAlpha * num25;
					if (compassProPOI.onScreenIndicatorShowDistance && _onScreenIndicatorShowDistance && compassProPOI.prevIndicatorDistance != compassProPOI.distanceToFollow)
					{
						compassProPOI.prevIndicatorDistance = compassProPOI.distanceToFollow;
						compassProPOI.lastIndicatorDistanceText = compassProPOI.distanceToFollow.ToString(_onScreenIndicatorShowDistanceFormat);
						compassProPOI.indicatorDistanceText.text = compassProPOI.lastIndicatorDistanceText;
					}
					if (compassProPOI.onScreenIndicatorShowTitle && _onScreenIndicatorShowTitle)
					{
						if (!compassProPOI.indicatorTitleText.enabled)
						{
							compassProPOI.indicatorTitleText.enabled = true;
						}
						compassProPOI.indicatorTitleText.text = compassProPOI.title;
						if (vector.x > 0.85f)
						{
							compassProPOI.indicatorTitleText.alignment = TextAlignmentOptions.MidlineRight;
						}
						else if (vector.x < 0.15f)
						{
							compassProPOI.indicatorTitleText.alignment = TextAlignmentOptions.MidlineLeft;
						}
						else
						{
							compassProPOI.indicatorTitleText.alignment = TextAlignmentOptions.Midline;
						}
					}
				}
				else
				{
					num26 = _offScreenIndicatorAlpha;
					compassProPOI.indicatorArrowRT.localRotation = Quaternion.Euler(0f, 0f, num12 * 57.29578f);
				}
				compassProPOI.indicatorImage.color = compassProPOI.tintColor;
				compassProPOI.indicatorCanvasGroup.alpha = num26;
				compassProPOI.indicatorArrowRT.gameObject.SetActive(!flag2);
			}
		}

		private GameObject GetIndicator()
		{
			return UnityEngine.Object.Instantiate(_onScreenIndicatorPrefab, indicatorsRoot, worldPositionStays: false);
		}

		private void MiniMapDispose()
		{
			MiniMapReleaseRenderTexture();
			if (miniMapOverlayMat != null)
			{
				UnityEngine.Object.DestroyImmediate(miniMapOverlayMat);
			}
		}

		private void SetupMiniMap(bool force = false)
		{
			if (_canvas == null)
			{
				return;
			}
			ResetDragOffset();
			if (_miniMapFullScreenState && !force)
			{
				MiniMapZoomToggle(state: true);
				return;
			}
			if (miniMapUIRootRT == null)
			{
				Transform transform = base.transform.Find("MiniMap Root");
				if (transform != null)
				{
					miniMapUIRootRT = transform.GetComponent<RectTransform>();
				}
			}
			if (miniMapUIRootRT != null)
			{
				miniMapUIRootRT.gameObject.SetActive(_showMiniMap);
			}
			HideMiniMapIcons();
			if (!_showMiniMap)
			{
				return;
			}
			if (miniMapUIRootRT == null)
			{
				Debug.LogError("Mini Map element not found in the hierarchy and could not be intialized.");
				_showMiniMap = false;
				return;
			}
			lastRadarInfoDistance = 0f;
			Transform transform2 = miniMapUIRootRT.Find("MiniMap");
			if (miniMapUI == null)
			{
				miniMapUI = transform2.GetComponent<RectTransform>();
			}
			if (miniMapUI != null)
			{
				MiniMapInteraction miniMapInteraction = miniMapUI.GetComponent<MiniMapInteraction>();
				if (miniMapInteraction == null)
				{
					miniMapInteraction = miniMapUI.gameObject.AddComponent<MiniMapInteraction>();
				}
				miniMapInteraction.compass = this;
			}
			if (miniMapMaskUI == null)
			{
				miniMapMaskUI = miniMapUI.Find("MiniMapMask");
			}
			if (miniMapButtonsPanel == null)
			{
				miniMapButtonsPanel = miniMapUIRootRT.Find("Buttons");
			}
			if (miniMapButtonsPanel != null)
			{
				miniMapButtonsPanel.transform.localScale = new Vector3(_miniMapButtonsScale, _miniMapButtonsScale, 1f);
				ToggleButtonEventHandler("ZoomIn", delegate
				{
					MiniMapZoomIn();
					EventSystem.current.SetSelectedGameObject(null);
				}, continuous: true, _miniMapShowZoomInOutButtons);
				ToggleButtonEventHandler("ZoomOut", delegate
				{
					MiniMapZoomOut();
					EventSystem.current.SetSelectedGameObject(null);
				}, continuous: true, _miniMapShowZoomInOutButtons);
				ToggleButtonEventHandler("ToggleFull", delegate
				{
					miniMapFullScreenState = !miniMapFullScreenState;
					EventSystem.current.SetSelectedGameObject(null);
				}, continuous: false, _miniMapShowMaximizeButton);
			}
			if (miniMapCamera == null)
			{
				miniMapCamera = base.transform.GetComponentInChildren<Camera>(includeInactive: true);
			}
			if (miniMapCamera != null)
			{
				miniMapCamera.enabled = false;
				if (CNP2URPCameraSetup.usesURP)
				{
					CNP2URPCameraSetup.SetupURPCamera(miniMapCamera, _miniMapEnableShadows);
				}
				else if (CNP2HDRPCameraSetup.usesHDRP)
				{
					CNP2HDRPCameraSetup.SetupHDRPCamera(miniMapCamera, _miniMapEnableShadows, _miniMapBackgroundColor);
				}
			}
			if (_miniMapPositionAndSize == MiniMapPositionAndScaleMode.ControlledByCompassNavigatorPro)
			{
				switch (_miniMapLocation)
				{
				case MiniMapPosition.TopLeft:
					miniMapUIRootRT.anchorMin = new Vector2(0f, 1f);
					miniMapUIRootRT.anchorMax = new Vector2(0f, 1f);
					miniMapUIRootRT.pivot = new Vector2(0f, 1f);
					break;
				case MiniMapPosition.TopCenter:
					miniMapUIRootRT.anchorMin = new Vector2(0.5f, 1f);
					miniMapUIRootRT.anchorMax = new Vector2(0.5f, 1f);
					miniMapUIRootRT.pivot = new Vector2(0.5f, 1f);
					break;
				case MiniMapPosition.TopRight:
					miniMapUIRootRT.anchorMin = new Vector2(1f, 1f);
					miniMapUIRootRT.anchorMax = new Vector2(1f, 1f);
					miniMapUIRootRT.pivot = new Vector2(1f, 1f);
					break;
				case MiniMapPosition.MiddleLeft:
					miniMapUIRootRT.anchorMin = new Vector2(0f, 0.5f);
					miniMapUIRootRT.anchorMax = new Vector2(0f, 0.5f);
					miniMapUIRootRT.pivot = new Vector2(0f, 0.5f);
					break;
				case MiniMapPosition.MiddleCenter:
					miniMapUIRootRT.anchorMin = new Vector2(0.5f, 0.5f);
					miniMapUIRootRT.anchorMax = new Vector2(0.5f, 0.5f);
					miniMapUIRootRT.pivot = new Vector2(0.5f, 0.5f);
					break;
				case MiniMapPosition.MiddleRight:
					miniMapUIRootRT.anchorMin = new Vector2(1f, 0.5f);
					miniMapUIRootRT.anchorMax = new Vector2(1f, 0.5f);
					miniMapUIRootRT.pivot = new Vector2(1f, 0.5f);
					break;
				case MiniMapPosition.BottomLeft:
					miniMapUIRootRT.anchorMin = new Vector2(0f, 0f);
					miniMapUIRootRT.anchorMax = new Vector2(0f, 0f);
					miniMapUIRootRT.pivot = new Vector2(0f, 0f);
					break;
				case MiniMapPosition.BottomCenter:
					miniMapUIRootRT.anchorMin = new Vector2(0.5f, 0f);
					miniMapUIRootRT.anchorMax = new Vector2(0.5f, 0f);
					miniMapUIRootRT.pivot = new Vector2(0.5f, 0f);
					break;
				case MiniMapPosition.BottomRight:
					miniMapUIRootRT.anchorMin = new Vector2(1f, 0f);
					miniMapUIRootRT.anchorMax = new Vector2(1f, 0f);
					miniMapUIRootRT.pivot = new Vector2(1f, 0f);
					break;
				}
				miniMapUIRootRT.anchoredPosition = _miniMapScreenPositionOffset;
			}
			if (_miniMapPositionAndSize == MiniMapPositionAndScaleMode.ControlledByCompassNavigatorPro)
			{
				float num = ((_cameraMain != null) ? ((float)_cameraMain.pixelHeight * _miniMapSize) : ((float)Screen.height * _miniMapSize));
				miniMapUIRootRT.sizeDelta = new Vector2(num / _canvas.scaleFactor, num / _canvas.scaleFactor);
			}
			if (miniMapOverlayMat == null)
			{
				miniMapOverlayMat = UnityEngine.Object.Instantiate(Resources.Load<Material>("CNPro/Materials/MiniMapOverlayUnlit"));
			}
			miniMapOverlayMat.DisableKeyword("COMPASS_ROTATE_BORDER");
			MiniMapContents miniMapContents = currentMiniMapContents;
			Texture2D value;
			Sprite sprite;
			if (miniMapContents == MiniMapContents.Radar)
			{
				if (_miniMapRadarGraphicsMethod == MiniMapRadarGraphicsMethod.Texture)
				{
					if (_miniMapFullScreenState)
					{
						value = _miniMapBorderTextureFullScreenMode;
						sprite = _miniMapMaskSpriteFullScreenMode;
					}
					else
					{
						value = _miniMapBorderTexture;
						sprite = _miniMapMaskSprite;
					}
					miniMapOverlayMat.EnableKeyword("COMPASS_ROTATE_BORDER");
				}
				else
				{
					value = null;
					sprite = null;
				}
			}
			else
			{
				switch (_miniMapFullScreenState ? _miniMapFullScreenStyle : _miniMapStyle)
				{
				case MiniMapStyle.TornPaper:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapMask");
					break;
				case MiniMapStyle.SolidBox:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorderSolidBox");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapMaskSolidBox");
					break;
				case MiniMapStyle.SolidCircle:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorderSolidCircle");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapMaskSolidCircle");
					break;
				case MiniMapStyle.Fantasy1:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_Fantasy1");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_Fantasy1_Mask");
					break;
				case MiniMapStyle.Fantasy2:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_Fantasy2");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_Fantasy2_Mask");
					break;
				case MiniMapStyle.Fantasy3:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_Fantasy3");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_Fantasy3_Mask");
					break;
				case MiniMapStyle.Fantasy4:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_Fantasy4");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_Fantasy4_Mask");
					break;
				case MiniMapStyle.Fantasy5:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_Fantasy5");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_Fantasy5_Mask");
					break;
				case MiniMapStyle.Fantasy6:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_Fantasy6");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_Fantasy6_Mask");
					break;
				case MiniMapStyle.SciFi1:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_SciFi1");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_SciFi1_Mask");
					break;
				case MiniMapStyle.SciFi2:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_SciFi2");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_SciFi2_Mask");
					break;
				case MiniMapStyle.SciFi3:
					value = Resources.Load<Texture2D>("CNPro/Textures/MiniMapBorder_SciFi3");
					sprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapBorder_SciFi3_Mask");
					break;
				case MiniMapStyle.None:
					value = null;
					sprite = null;
					break;
				default:
					if (_miniMapFullScreenState)
					{
						value = _miniMapBorderTextureFullScreenMode;
						sprite = _miniMapMaskSpriteFullScreenMode;
					}
					else
					{
						value = _miniMapBorderTexture;
						sprite = _miniMapMaskSprite;
					}
					break;
				}
			}
			if (_miniMapCameraMode == MiniMapCameraMode.Perspective)
			{
				miniMapCameraSnapshotFrequency = MiniMapCameraSnapshotFrequency.Continuous;
			}
			if (_miniMapZoomMin < 0.001f)
			{
				_miniMapZoomMin = 0.001f;
			}
			if (_miniMapZoomMax < _miniMapZoomMin)
			{
				_miniMapZoomMax = _miniMapZoomMin;
			}
			_miniMapZoomLevel = Mathf.Clamp(_miniMapZoomLevel, _miniMapZoomMin, _miniMapZoomMax);
			_miniMapFullScreenZoomLevel = Mathf.Clamp(_miniMapFullScreenZoomLevel, _miniMapZoomMin, _miniMapZoomMax);
			if (_miniMapCameraMaxAltitude < _miniMapCameraMinAltitude)
			{
				_miniMapCameraMaxAltitude = _miniMapCameraMinAltitude;
			}
			if (miniMapUI != null)
			{
				miniMapImage = miniMapUI.GetComponent<Image>();
				if (miniMapImage != null)
				{
					miniMapImage.sprite = null;
					miniMapImage.material = miniMapOverlayMat;
					Material materialForRendering = miniMapImage.materialForRendering;
					Texture value2 = ((sprite != null) ? sprite.texture : null);
					miniMapOverlayMat.SetTexture(ShaderParams.MaskTex, value2);
					miniMapOverlayMat.SetTexture(ShaderParams.BorderTex, value);
					materialForRendering.SetTexture(ShaderParams.MaskTex, value2);
					materialForRendering.SetTexture(ShaderParams.BorderTex, value);
					materialForRendering.DisableKeyword("COMPASS_FOG_OF_WAR");
					materialForRendering.DisableKeyword("COMPASS_RADAR");
					if (miniMapContents == MiniMapContents.Radar && _miniMapRadarGraphicsMethod == MiniMapRadarGraphicsMethod.ProceduralRings)
					{
						materialForRendering.EnableKeyword("COMPASS_RADAR");
						materialForRendering.SetColor(ShaderParams.RingsColor, _miniMapRadarRingsColor);
					}
					else if (_miniMapCameraMode == MiniMapCameraMode.Orthographic && currentMiniMapUsesFogOfWar)
					{
						materialForRendering.EnableKeyword("COMPASS_FOG_OF_WAR");
					}
					if (_miniMapKeepStraight)
					{
						materialForRendering.DisableKeyword("COMPASS_ROTATED");
					}
					else
					{
						materialForRendering.EnableKeyword("COMPASS_ROTATED");
					}
					if (_miniMapShowViewCone && !_miniMapFullScreenState)
					{
						materialForRendering.SetColor(ShaderParams.ViewConeColor, _miniMapViewConeColor);
						if (_miniMapShowViewConeOutline)
						{
							materialForRendering.DisableKeyword("COMPASS_VIEW_CONE");
							materialForRendering.EnableKeyword("COMPASS_VIEW_CONE_OUTLINE");
							materialForRendering.SetColor(ShaderParams.ViewConeOutlineColor, _miniMapViewConeOutlineColor);
						}
						else
						{
							materialForRendering.DisableKeyword("COMPASS_VIEW_CONE_OUTLINE");
							materialForRendering.EnableKeyword("COMPASS_VIEW_CONE");
						}
						lastViewConeCameraAspect = 0f;
					}
					else
					{
						materialForRendering.DisableKeyword("COMPASS_VIEW_CONE_OUTLINE");
						materialForRendering.DisableKeyword("COMPASS_VIEW_CONE");
					}
				}
				if (miniMapMaskUI != null)
				{
					miniMapMaskImage = miniMapMaskUI.GetComponent<Image>();
					if (miniMapMaskImage != null)
					{
						miniMapMaskImage.sprite = sprite;
					}
				}
			}
			if (miniMapCamera != null)
			{
				miniMapCamera.allowHDR = false;
				miniMapCamera.allowMSAA = false;
				miniMapCamera.clearFlags = CameraClearFlags.Color;
				miniMapCamera.backgroundColor = _miniMapBackgroundColor;
				miniMapCamera.orthographic = _miniMapCameraMode == MiniMapCameraMode.Orthographic || miniMapContents == MiniMapContents.Radar;
				miniMapCamera.cullingMask = _miniMapLayerMask;
				miniMapCamera.farClipPlane = _miniMapCameraDepth;
			}
			if (miniMapContents != MiniMapContents.TopDownWorldView)
			{
				MiniMapReleaseRenderTexture();
			}
			if (playerIcon == null)
			{
				playerIcon = miniMapUIRootRT.Find("CameraCompass");
			}
			if (playerIcon != null)
			{
				playerIcon.localEulerAngles = Misc.Vector3zero;
				playerIconRT = playerIcon.GetComponent<RectTransform>();
				playerIconImage = playerIcon.GetComponent<Image>();
				playerIcon.gameObject.SetActive(_miniMapShowPlayerIcon);
				if (playerIconImage != null)
				{
					if (_miniMapPlayerIconSprite == null)
					{
						_miniMapPlayerIconSprite = Resources.Load<Sprite>("CNPro/Sprites/player-icon");
					}
					if (_miniMapPlayerIconSprite != null)
					{
						playerIconImage.sprite = _miniMapPlayerIconSprite;
					}
					playerIconImage.color = _miniMapPlayerIconColor;
				}
			}
			if (miniMapCardinalsRT == null)
			{
				miniMapCardinalsRT = miniMapUI.Find("Cardinals");
			}
			if (miniMapCardinalsRT != null)
			{
				miniMapCardinalsImage = miniMapCardinalsRT.GetComponent<Image>();
				miniMapCardinalsRT.gameObject.SetActive(_miniMapShowCardinals && !_miniMapFullScreenState);
				miniMapCardinalsRT.localScale = new Vector3(_miniMapCardinalsSize, _miniMapCardinalsSize, 1f);
				if (miniMapCardinalsImage != null)
				{
					if (_miniMapCardinalsSprite == null)
					{
						_miniMapCardinalsSprite = Resources.Load<Sprite>("CNPro/Sprites/MiniMapCardinals");
					}
					if (_miniMapCardinalsSprite != null)
					{
						miniMapCardinalsImage.sprite = _miniMapCardinalsSprite;
					}
					miniMapCardinalsImage.color = _miniMapCardinalsColor;
				}
			}
			if (ringsDistanceText == null)
			{
				Transform transform3 = miniMapUI.Find("RingsDistance");
				ringsDistanceText = transform3.GetComponent<TextMeshProUGUI>();
			}
			if (ringsDistanceText != null)
			{
				ringsDistanceText.gameObject.SetActive(_miniMapRadarInfoDisplay != MiniMapRadarInfoType.Nothing && miniMapContents == MiniMapContents.Radar);
			}
			if (miniMapCanvasGroup == null)
			{
				miniMapCanvasGroup = GetMiniMapCanvasGroup(miniMapUIRootRT);
			}
			CanvasGroup obj = miniMapCanvasGroup;
			bool interactable = (miniMapCanvasGroup.blocksRaycasts = currentMiniMapUsesEvents);
			obj.interactable = interactable;
			needMiniMapShot = 2;
			needUpdateMiniMapIcons = true;
		}

		public Texture2D GetMiniMapMaterialBorderTexture()
		{
			return miniMapImage.materialForRendering.GetTexture(ShaderParams.BorderTex) as Texture2D;
		}

		public Texture2D GetMiniMapMaterialMaskTexture()
		{
			return miniMapImage.materialForRendering.GetTexture(ShaderParams.MaskTex) as Texture2D;
		}

		private void MiniMapReleaseRenderTexture()
		{
			if (miniMapTex != null)
			{
				miniMapTex.Release();
			}
		}

		private void MiniMapResizeRenderTexture(int width, int height)
		{
			if (miniMapCamera == null)
			{
				return;
			}
			if (miniMapTex == null || miniMapTex.width != width || miniMapTex.height != height)
			{
				if (miniMapTex != null)
				{
					miniMapTex.Release();
				}
				miniMapTex = new RenderTexture(width, height, 16, RenderTextureFormat.ARGB32);
			}
			miniMapCamera.targetTexture = miniMapTex;
		}

		private void DisableMiniMap()
		{
			if (miniMapUIRootRT != null && miniMapUIRootRT.gameObject.activeSelf)
			{
				miniMapUIRootRT.gameObject.SetActive(value: false);
			}
			if (miniMapCamera != null)
			{
				miniMapCamera.enabled = false;
			}
			if (miniMapTex != null)
			{
				miniMapTex.Release();
				UnityEngine.Object.DestroyImmediate(miniMapTex);
			}
		}

		private void UpdateMiniMap()
		{
			if (!_showMiniMap || miniMapCamera == null || cameraMain == null)
			{
				return;
			}
			if (needsSetupMiniMap)
			{
				needsSetupMiniMap = false;
				SetupMiniMap();
			}
			MiniMapContents miniMapContents = currentMiniMapContents;
			Transform transform = miniMapCamera.transform;
			Transform transform2 = _cameraMain.transform;
			if (_miniMapFullScreenState)
			{
				if (miniMapFullScreenFreezeCamera)
				{
					Quaternion quaternion = (transform2.rotation = miniMapFullScreenFixedCameraRotation);
					currentCamRot = quaternion;
					Vector3 vector = (transform2.position = miniMapFullScreenFixedCameraPosition);
					currentCamPos = vector;
				}
				if (miniMapFullScreenWorldCenterFollows)
				{
					miniMapCenter = GetMiniMapFollowPos();
				}
				else
				{
					miniMapCenter = GetMiniMapFullScreenWorldCenter();
				}
				if (miniMapFullScreenClampToWorldEdges)
				{
					miniMapCenter = ClampMiniMapCenterToWorldSize(miniMapCenter);
				}
				float num = Mathf.Max(miniMapFullScreenWorldSize.x, miniMapFullScreenWorldSize.z) * 0.5f;
				if (_miniMapCameraMode == MiniMapCameraMode.Orthographic)
				{
					transform.position = new Vector3(miniMapCenter.x, miniMapCenter.y + _miniMapCameraHeightVSFollow + 0.1f, miniMapCenter.z);
					miniMapCamera.orthographicSize = num;
				}
				else
				{
					float num2 = miniMapCamera.fieldOfView * (MathF.PI / 180f);
					float num3 = num / Mathf.Tan(num2 * 0.5f);
					transform.position = new Vector3(miniMapCenter.x, miniMapCenter.y + num3, miniMapCenter.z);
				}
			}
			else
			{
				miniMapCenter = GetMiniMapFollowPos();
				if (miniMapContents == MiniMapContents.WorldMappedTexture && miniMapClampToWorldEdges)
				{
					miniMapCenter = ClampMiniMapCenterToWorldSize(miniMapCenter);
				}
				if (_miniMapCameraMode == MiniMapCameraMode.Orthographic)
				{
					transform.position = new Vector3(miniMapCenter.x, miniMapCenter.y + _miniMapCameraHeightVSFollow + 0.1f, miniMapCenter.z);
					miniMapCamera.orthographicSize = _miniMapCaptureSize * 0.5f;
				}
				else
				{
					float num4 = _miniMapCameraMinAltitude + (_miniMapCameraMaxAltitude - _miniMapCameraMinAltitude) * _miniMapZoomLevel;
					transform.position = new Vector3(miniMapCenter.x, miniMapCenter.y + num4, miniMapCenter.z);
				}
			}
			if (miniMapCanvasGroup.alpha != _miniMapAlpha)
			{
				miniMapCanvasGroup.alpha = _miniMapAlpha;
			}
			if (miniMapContents == MiniMapContents.WorldMappedTexture)
			{
				float num5 = (_miniMapFullScreenState ? _miniMapFullScreenWorldSize.x : _miniMapWorldSize.x);
				miniMapCamera.orthographicSize = num5 * 0.5f;
			}
			float num6 = 0f;
			if (_miniMapKeepStraight || _miniMapFullScreenState)
			{
				transform.eulerAngles = new Vector3(90f, 0f, 0f);
				if (playerIcon != null)
				{
					Vector3 localEulerAngles = ((_miniMapOrientation == MiniMapOrientation.Follow) ? _follow.eulerAngles : currentCamRot.eulerAngles);
					localEulerAngles.z = 0f - localEulerAngles.y;
					localEulerAngles.x = (localEulerAngles.y = 0f);
					playerIcon.localEulerAngles = localEulerAngles;
				}
			}
			else
			{
				Vector3 worldUp = ((_miniMapOrientation == MiniMapOrientation.Follow) ? _follow.forward : transform2.forward);
				worldUp.y = miniMapCenter.y;
				transform.LookAt(miniMapCenter, worldUp);
			}
			num6 = ((!(_miniMapCameraTilt > 0f) || _miniMapKeepStraight || _miniMapCameraMode != MiniMapCameraMode.Perspective) ? ((_miniMapOrientation == MiniMapOrientation.Follow) ? _follow.eulerAngles.y : transform2.rotation.eulerAngles.y) : 0f);
			Material materialForRendering = miniMapImage.materialForRendering;
			if (_miniMapShowViewCone || (_miniMapShowPlayerIcon && playerIconRT != null))
			{
				float num7 = currentMiniMapClampBorder;
				Vector2 vector3 = GetMiniMapScreenPos(followPos);
				if (currentMiniMapIsCircular)
				{
					float num8 = vector3.x - 0.5f;
					float num9 = vector3.y - 0.5f;
					float num10 = Mathf.Sqrt(num8 * num8 + num9 * num9) * 2f;
					if (num10 < 0.0001f)
					{
						vector3 = Misc.Vector2half;
					}
					else
					{
						float num11 = Mathf.Min(num10, 1f - num7);
						vector3.x = 0.5f + num8 * num11 / num10;
						vector3.y = 0.5f + num9 * num11 / num10;
					}
				}
				else
				{
					vector3.x = Mathf.Clamp(vector3.x, num7, 1f - num7);
					vector3.y = Mathf.Clamp(vector3.y, num7, 1f - num7);
				}
				vector3 += _miniMapIconPositionShift;
				if (playerIconRT != null)
				{
					RectTransform rectTransform = playerIconRT;
					Vector2 anchorMin = (playerIconRT.anchorMax = vector3);
					rectTransform.anchorMin = anchorMin;
					playerIconRT.localScale = new Vector3(_miniMapPlayerIconSize, _miniMapPlayerIconSize, 1f);
				}
				materialForRendering.SetVector(ShaderParams.FollowPos, new Vector4(vector3.x, vector3.y, 0f, 0f));
			}
			if (_miniMapShowCardinals && !_miniMapFullScreenState && miniMapCardinalsRT != null)
			{
				float num12 = (_miniMapKeepStraight ? 0f : num6);
				miniMapCardinalsRT.localRotation = Quaternion.Euler(0f, 0f, num12 - _northDegrees);
			}
			if (miniMapContents == MiniMapContents.WorldMappedTexture)
			{
				materialForRendering.SetTexture(ShaderParams.MiniMapTex, _miniMapFullScreenState ? _miniMapFullScreenContentsTexture : _miniMapContentsTexture);
				float num13 = currentMiniMapZoomLevel;
				Vector3 position = transform.position;
				Vector4 value;
				float x;
				if (_miniMapFullScreenState)
				{
					value = _miniMapFullScreenWorldCenter - position;
					x = _miniMapFullScreenWorldSize.x;
				}
				else
				{
					value = _miniMapWorldCenter - position;
					x = _miniMapWorldSize.x;
				}
				value.x /= x;
				value.y = value.z / x;
				value.z = num13;
				value.w = miniMapUIRootRT.rect.size.y / miniMapUIRootRT.rect.size.x;
				Vector4 value2 = _fogOfWarCenter - position;
				value2.x = value2.x / x / num13;
				value2.y = value2.z / x / num13;
				value2.z = num13 * x / _fogOfWarSize.x;
				value2.w = num13 * x / _fogOfWarSize.z;
				materialForRendering.SetVector(ShaderParams.UVOffset, value);
				materialForRendering.SetVector(ShaderParams.UVFogOffset, value2);
				materialForRendering.SetTexture(ShaderParams.FoWTexture, fogOfWarTexture);
				materialForRendering.SetColor(ShaderParams.FoWTintColor, _fogOfWarColor);
				if (_miniMapKeepStraight || _miniMapFullScreenState)
				{
					materialForRendering.SetFloat(ShaderParams.Rotation, 0f);
					materialForRendering.SetFloat(ShaderParams.ConeRotation, (0f - num6) * (MathF.PI / 180f));
				}
				else
				{
					materialForRendering.SetFloat(ShaderParams.Rotation, num6 * (MathF.PI / 180f));
					materialForRendering.SetFloat(ShaderParams.ConeRotation, 0f);
				}
			}
			else if (miniMapContents.usesTexture())
			{
				materialForRendering.SetTexture(ShaderParams.MiniMapTex, _miniMapFullScreenState ? _miniMapFullScreenContentsTexture : _miniMapContentsTexture);
				materialForRendering.SetVector(ShaderParams.UVOffset, new Vector4(0f, 0f, 1f, 1f));
				if (_miniMapFullScreenState)
				{
					materialForRendering.SetFloat(ShaderParams.Rotation, 0f);
				}
				else
				{
					materialForRendering.SetFloat(ShaderParams.Rotation, _miniMapContentsTextureAllowRotation ? (num6 * (MathF.PI / 180f)) : 0f);
				}
				if (_miniMapKeepStraight || _miniMapFullScreenState)
				{
					materialForRendering.SetFloat(ShaderParams.ConeRotation, (0f - num6) * (MathF.PI / 180f));
				}
				else
				{
					materialForRendering.SetFloat(ShaderParams.ConeRotation, 0f);
				}
			}
			else
			{
				switch (_miniMapCameraSnapshotFrequency)
				{
				case MiniMapCameraSnapshotFrequency.TimeInterval:
					if (Time.time - miniMapLastSnapshotTime > _miniMapSnapshotInterval)
					{
						needMiniMapShot = 1;
					}
					break;
				case MiniMapCameraSnapshotFrequency.DistanceTravelled:
					if ((miniMapLastSnapshotLocation - transform.position).sqrMagnitude > _miniMapSnapshotDistance * _miniMapSnapshotDistance)
					{
						needMiniMapShot = 1;
					}
					break;
				case MiniMapCameraSnapshotFrequency.Continuous:
					needMiniMapShot = 1;
					break;
				}
				if (needMiniMapShot > 0)
				{
					needMiniMapShot--;
					if (needMiniMapShot <= 0)
					{
						needMiniMapShot = 0;
						Quaternion rotation = transform.rotation;
						bool flag = _miniMapCameraTilt > 0f && _miniMapCameraMode == MiniMapCameraMode.Perspective;
						if (flag)
						{
							transform.Rotate(0f - _miniMapCameraTilt, 0f, 0f, Space.Self);
							float num14 = Vector3.Distance(miniMapCenter, transform.position);
							transform.position = miniMapCenter - transform.forward * num14;
						}
						else
						{
							transform.eulerAngles = new Vector3(90f, 0f, 0f);
						}
						if (_miniMapFullScreenState)
						{
							MiniMapResizeRenderTexture((int)_miniMapFullScreenResolution, (int)_miniMapFullScreenResolution);
						}
						else
						{
							MiniMapResizeRenderTexture((int)_miniMapResolution, (int)_miniMapResolution);
						}
						if (CNP2HDRPCameraSetup.usesHDRP)
						{
							_canvas.enabled = false;
						}
						OnMiniMapBeforeCapture?.Invoke();
						if (!_miniMapEnableShadows && Application.isPlaying)
						{
							ShadowQuality shadows = QualitySettings.shadows;
							QualitySettings.shadows = ShadowQuality.Disable;
							miniMapCamera.Render();
							QualitySettings.shadows = shadows;
						}
						else
						{
							miniMapCamera.Render();
						}
						OnMiniMapAfterCapture?.Invoke();
						if (CNP2HDRPCameraSetup.usesHDRP)
						{
							_canvas.enabled = true;
						}
						if (!_miniMapKeepStraight && !flag)
						{
							transform.rotation = rotation;
						}
						miniMapLastSnapshotTime = Time.time;
						miniMapLastSnapshotLocation = transform.position;
						needUpdateMiniMapIcons = true;
					}
				}
				materialForRendering.SetTexture(ShaderParams.MiniMapTex, miniMapTex);
				float num15 = currentMiniMapZoomLevel;
				Vector3 position2 = transform.position;
				Vector4 value3 = miniMapLastSnapshotLocation - position2;
				float num16 = miniMapCamera.orthographicSize * 2f;
				value3.x /= num16;
				value3.y = value3.z / num16;
				value3.z = num15;
				float miniMapAspectRatio = GetMiniMapAspectRatio();
				value3.w = 1f / miniMapAspectRatio;
				Vector4 value4 = _fogOfWarCenter - position2;
				value4.x = value4.x / num16 / num15;
				value4.y = value4.z / num16 / num15;
				value4.y *= miniMapAspectRatio;
				value4.z = num15 * num16 / _fogOfWarSize.x;
				value4.w = num15 * num16 / _fogOfWarSize.z;
				materialForRendering.SetVector(ShaderParams.UVOffset, value3);
				materialForRendering.SetVector(ShaderParams.UVFogOffset, value4);
				materialForRendering.SetTexture(ShaderParams.FoWTexture, fogOfWarTexture);
				materialForRendering.SetColor(ShaderParams.FoWTintColor, _fogOfWarColor);
				if (_miniMapKeepStraight || _miniMapFullScreenState)
				{
					materialForRendering.SetFloat(ShaderParams.Rotation, 0f);
					materialForRendering.SetFloat(ShaderParams.ConeRotation, (0f - num6) * (MathF.PI / 180f));
				}
				else
				{
					materialForRendering.SetFloat(ShaderParams.Rotation, num6 * (MathF.PI / 180f));
					materialForRendering.SetFloat(ShaderParams.ConeRotation, 0f);
				}
			}
			if (_miniMapShowViewCone)
			{
				float aspect = _cameraMain.aspect;
				float fieldOfView = _cameraMain.fieldOfView;
				if (lastViewConeCameraAspect == 0f || aspect != lastViewConeCameraAspect || fieldOfView != lastViewConeFoV)
				{
					lastViewConeCameraAspect = aspect;
					lastViewConeFoV = fieldOfView;
					float x2 = ((_miniMapViewConeFoVSource != MiniMapViewConeFovSource.FromCamera) ? (_miniMapViewConeFoV * (MathF.PI / 180f) * 0.5f) : Mathf.Atan(Mathf.Tan(_cameraMain.fieldOfView * (MathF.PI / 180f) / 2f) * aspect));
					Vector2 miniMapScreenPosNoShift = GetMiniMapScreenPosNoShift(GetMiniMapFollowPos() + new Vector3(0f, 0f, _miniMapViewConeDistance));
					miniMapScreenPosNoShift.x -= 0.5f;
					miniMapScreenPosNoShift.y -= 0.5f;
					float magnitude = miniMapScreenPosNoShift.magnitude;
					viewConeData.x = x2;
					viewConeData.y = magnitude * magnitude;
					viewConeData.z = viewConeData.y / (_miniMapViewConeFallOff * _miniMapViewConeFallOff);
					materialForRendering.SetVector(ShaderParams.ViewConeData, viewConeData);
				}
			}
			materialForRendering.SetVector(ShaderParams.Effects, new Vector4(_miniMapBrightness, _miniMapContrast, _miniMapLutIntensity, (_miniMapVignette && currentMiniMapContents != MiniMapContents.Radar && !_miniMapFullScreenState) ? (_miniMapVignetteColor.a * 48f) : 0f));
			materialForRendering.SetColor(ShaderParams.BackgroundColor, _miniMapBackgroundColor);
			materialForRendering.SetInt(ShaderParams.BackgroundOpaque, _miniMapBackgroundOpaque ? 1 : 0);
			materialForRendering.SetColor(ShaderParams.TintColor, _miniMapTintColor);
			materialForRendering.SetColor(ShaderParams.VignetteColor, _miniMapVignetteColor);
			if (_miniMapLutTexture != null && _miniMapLutIntensity > 0f)
			{
				materialForRendering.SetTexture(ShaderParams.LUTTexture, _miniMapLutTexture);
				materialForRendering.EnableKeyword("COMPASS_LUT");
			}
			else
			{
				materialForRendering.DisableKeyword("COMPASS_LUT");
			}
			if (miniMapContents != MiniMapContents.Radar || _miniMapRadarGraphicsMethod != MiniMapRadarGraphicsMethod.ProceduralRings)
			{
				return;
			}
			float num17 = ((_miniMapRadarInfoDisplay == MiniMapRadarInfoType.RadarRange) ? (_miniMapCaptureSize * 0.5f) : _miniMapRadarRingsDistance);
			if (num17 != lastRadarInfoDistance)
			{
				float num18 = 0f;
				for (int i = 0; i < 10; i++)
				{
					Vector3 vector5 = GetMiniMapScreenPosNoShift(miniMapCenter + new Vector3(0f, 0f, _miniMapRadarRingsDistance));
					vector5.x -= 0.5f;
					vector5.y -= 0.5f;
					num18 = Mathf.Sqrt(vector5.x * vector5.x + vector5.y * vector5.y) * 2f;
					if (num18 > 0.1f)
					{
						break;
					}
				}
				if (num17 != lastRadarInfoDistance && _miniMapRadarInfoDisplay != MiniMapRadarInfoType.Nothing && ringsDistanceText != null)
				{
					lastRadarInfoDistance = num17;
					ringsDistanceText.text = (int)num17 + "m";
				}
				materialForRendering.SetVector(ShaderParams.RingsData, new Vector4(num18, 10f / _miniMapRadarRingsWidth, 0f, 0f));
			}
			float w = (_miniMapRadarPulseEnabled ? _miniMapRadarPulseOpacity : 0f);
			switch (_miniMapRadarPulseAnimationPreset)
			{
			case MiniMapPulsePreset.Default:
				materialForRendering.SetVector(ShaderParams.RingsPulseData, new Vector4(5f, 50f, 0.1f, w));
				break;
			case MiniMapPulsePreset.LongSweep:
				materialForRendering.SetVector(ShaderParams.RingsPulseData, new Vector4(4f, 15f, 0.25f, w));
				break;
			case MiniMapPulsePreset.Scanning:
				materialForRendering.SetVector(ShaderParams.RingsPulseData, new Vector4(30f, 4f, 3f, w));
				break;
			default:
				materialForRendering.SetVector(ShaderParams.RingsPulseData, new Vector4(_miniMapRadarPulseSpeed, _miniMapRadarPulseFallOff, _miniMapRadarPulseFrequency, w));
				break;
			}
		}

		private Vector3 ClampMiniMapCenterToWorldSize(Vector3 miniMapCenter)
		{
			float num = currentMiniMapZoomLevel;
			Vector3 vector;
			float num2;
			if (_miniMapFullScreenState)
			{
				vector = _miniMapFullScreenWorldCenter;
				num2 = _miniMapFullScreenWorldSize.x * 0.5f;
			}
			else
			{
				vector = _miniMapWorldCenter;
				num2 = _miniMapWorldSize.x * 0.5f;
			}
			float num3 = num2 * num;
			float num4 = Mathf.Clamp(miniMapCenter.x, vector.x - num2 + num3, vector.x + num2 - num3);
			float num5 = Mathf.Clamp(miniMapCenter.z, vector.z - num2 + num3, vector.z + num2 - num3);
			_miniMapFollowOffset.x += num4 - miniMapCenter.x;
			_miniMapFollowOffset.z += num5 - miniMapCenter.z;
			miniMapCenter.x = num4;
			miniMapCenter.z = num5;
			return miniMapCenter;
		}

		private void ClampDragOffset()
		{
			float num = Mathf.Sqrt(_miniMapFollowOffset.x * _miniMapFollowOffset.x + _miniMapFollowOffset.z * _miniMapFollowOffset.z);
			if (_miniMapFullScreenState)
			{
				if (num > _miniMapFullScreenDragMaxDistance)
				{
					_miniMapFollowOffset.y = 0f;
					_miniMapFollowOffset = _miniMapFollowOffset.normalized * _miniMapFullScreenDragMaxDistance;
				}
			}
			else if (num > _miniMapDragMaxDistance)
			{
				_miniMapFollowOffset.y = 0f;
				_miniMapFollowOffset = _miniMapFollowOffset.normalized * _miniMapDragMaxDistance;
			}
		}

		private void UpdateMiniMapIcons()
		{
			if (!needUpdateMiniMapIcons || miniMapCamera == null)
			{
				return;
			}
			needUpdateMiniMapIcons = false;
			float time = Time.time;
			int frameCount = Time.frameCount;
			float miniMapAspectRatio = GetMiniMapAspectRatio();
			float t = (Application.isPlaying ? (Time.deltaTime * 10f) : 1f);
			Vector3 one = Vector3.one;
			Quaternion quaternion = Quaternion.Inverse(currentCamRot);
			MiniMapContents miniMapContents = currentMiniMapContents;
			int count = pois.Count;
			for (int i = 0; i < count; i++)
			{
				CompassProPOI compassProPOI = pois[i];
				if (compassProPOI.miniMapType != POIMiniMapType.Any)
				{
					if (miniMapContents == MiniMapContents.Radar)
					{
						if (compassProPOI.miniMapType != POIMiniMapType.RadarOnly)
						{
							continue;
						}
					}
					else if (compassProPOI.miniMapType != POIMiniMapType.MiniMapOnly)
					{
						continue;
					}
				}
				bool flag = true;
				if (compassProPOI.isVisited && compassProPOI.hideWhenVisited)
				{
					flag = false;
				}
				if (!compassProPOI.isActiveAndEnabled || !flag)
				{
					compassProPOI.ToggleMiniMapIconVisibility(visible: false);
					compassProPOI.ToggleMiniMapCircleVisibility(visible: false);
					continue;
				}
				if (frameCount != compassProPOI.viewportPosFrameCount)
				{
					compassProPOI.viewportPosFrameCount = frameCount;
					ComputePOIViewportPos(compassProPOI);
				}
				Vector3 position = compassProPOI.transform.position;
				float num = ((compassProPOI.miniMapVisibleDistanceOverride > 0f) ? compassProPOI.miniMapVisibleDistanceOverride : _miniMapVisibleMaxDistance);
				bool flag2 = compassProPOI.distanceToFollow < num;
				flag = compassProPOI.miniMapVisibility == POIVisibility.AlwaysVisible || (compassProPOI.miniMapVisibility == POIVisibility.WhenInRange && flag2);
				if (flag)
				{
					Vector3 miniMapScreenPos = GetMiniMapScreenPos(position, miniMapAspectRatio);
					if (compassProPOI.miniMapIconRT == null)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate((compassProPOI.miniMapIconPrefabOverride != null) ? compassProPOI.miniMapIconPrefabOverride : miniMapIconPrefab);
						gameObject.name = "MiniMap Icon " + compassProPOI.name;
						gameObject.transform.SetParent(miniMapMaskUI.transform, worldPositionStays: false);
						compassProPOI.miniMapIconRT = gameObject.GetComponent<RectTransform>();
						MiniMapIconElements component = gameObject.GetComponent<MiniMapIconElements>();
						if (component == null)
						{
							Debug.LogError("MiniMap icon prefab missing MiniMapIconElements component.");
							continue;
						}
						compassProPOI.miniMapIconImage = component.iconImage;
						if (compassProPOI.miniMapIconImage != null)
						{
							compassProPOI.miniMapIconImageRT = compassProPOI.miniMapIconImage.GetComponent<RectTransform>();
							if (_miniMapIconEvents)
							{
								compassProPOI.miniMapIconImage.raycastTarget = true;
								CompassIconEventHandler compassIconEventHandler = gameObject.AddComponent<CompassIconEventHandler>();
								compassIconEventHandler.poi = compassProPOI;
								compassIconEventHandler.compass = this;
							}
						}
						compassProPOI.miniMapCircleRT = component.circle;
						if (compassProPOI.miniMapCircleRT != null)
						{
							compassProPOI.miniMapCircleImage = compassProPOI.miniMapCircleRT.GetComponent<Image>();
							if (compassProPOI.miniMapCircleImage.material == null)
							{
								compassProPOI.miniMapCircleImage.material = Resources.Load<Material>("CNPro/Materials/MiniMapCircle");
							}
						}
					}
					flag = miniMapScreenPos.x >= 0f && miniMapScreenPos.x < 1f && miniMapScreenPos.y >= 0f && miniMapScreenPos.y < 1f;
					float num2 = 1f;
					float num3 = 1f;
					float num4 = miniMapScreenPos.x - 0.5f;
					float num5 = miniMapScreenPos.y - 0.5f;
					float num6 = Mathf.Sqrt(num4 * num4 + num5 * num5) * 2f + 1E-06f;
					if (currentMiniMapContents == MiniMapContents.Radar && _miniMapRadarFadePOIs && !compassProPOI.miniMapClampPosition)
					{
						num3 = 1f - Mathf.Clamp01((num6 - 0.7f) / 0.3f);
					}
					if (compassProPOI.miniMapClampPosition)
					{
						flag = true;
						float num7 = currentMiniMapClampBorder;
						bool flag3 = false;
						if (currentMiniMapIsCircular)
						{
							float num8 = Mathf.Min(num6, 1f - num7);
							miniMapScreenPos.x = 0.5f + num4 * num8 / num6;
							miniMapScreenPos.y = 0.5f + num5 * num8 / num6;
							flag3 = num6 > 1f - num7;
						}
						else
						{
							if (miniMapScreenPos.x < num7)
							{
								miniMapScreenPos.x = num7;
								flag3 = true;
							}
							else if (miniMapScreenPos.x > 1f - num7)
							{
								miniMapScreenPos.x = 1f - num7;
								flag3 = true;
							}
							if (miniMapScreenPos.y < num7)
							{
								miniMapScreenPos.y = num7;
								flag3 = true;
							}
							else if (miniMapScreenPos.y > 1f - num7)
							{
								miniMapScreenPos.y = 1f - num7;
								flag3 = true;
							}
						}
						if (flag3)
						{
							num2 = compassProPOI.miniMapClampedScaleMultiplier;
						}
					}
					if (compassProPOI.radius > 0f && (compassProPOI.miniMapShowCircle || (compassProPOI.circleVisibleTime <= 0f && compassProPOI.miniMapCircleAnimationWhenAppears)))
					{
						flag = true;
						if (compassProPOI.lastCircleRadius != compassProPOI.radius || compassProPOI.lastCircleHeight != miniMapUI.rect.height || compassProPOI.lastCircleZoomLevel != currentMiniMapZoomLevel)
						{
							compassProPOI.lastCircleRadius = compassProPOI.radius;
							compassProPOI.lastCircleHeight = miniMapUI.rect.height;
							compassProPOI.lastCircleZoomLevel = currentMiniMapZoomLevel;
							ComputeCircleScale(compassProPOI, miniMapAspectRatio);
						}
						Material materialForRendering = compassProPOI.miniMapCircleImage.materialForRendering;
						compassProPOI.miniMapCircleImage.color = compassProPOI.miniMapCircleColor;
						materialForRendering.SetColor(ShaderParams.CircleInnerColor, compassProPOI.miniMapCircleInnerColor);
						materialForRendering.SetFloat(ShaderParams.CircleStartRadius, compassProPOI.miniMapCircleStartRadius);
						compassProPOI.ToggleMiniMapCircleVisibility(visible: true);
					}
					else if (!compassProPOI.miniMapCircleAnimationWhenAppears)
					{
						compassProPOI.ToggleMiniMapCircleVisibility(visible: false);
					}
					if (compassProPOI.circleVisibleTime <= 0f)
					{
						compassProPOI.circleVisibleTime = time;
						if (compassProPOI.miniMapCircleAnimationWhenAppears && Application.isPlaying)
						{
							StartCoroutine(AnimateCircle(compassProPOI, time));
						}
					}
					if (flag)
					{
						RectTransform miniMapIconRT = compassProPOI.miniMapIconRT;
						Vector2 anchorMin = (compassProPOI.miniMapIconRT.anchorMax = miniMapScreenPos);
						miniMapIconRT.anchorMin = anchorMin;
						if (compassProPOI.isVisited)
						{
							if (compassProPOI.miniMapIconImage.sprite != compassProPOI.iconVisited)
							{
								compassProPOI.miniMapIconImage.sprite = compassProPOI.iconVisited;
							}
						}
						else if (compassProPOI.miniMapIconImage.sprite != compassProPOI.iconNonVisited)
						{
							compassProPOI.miniMapIconImage.sprite = compassProPOI.iconNonVisited;
						}
						Color tintColor = compassProPOI.tintColor;
						tintColor.a *= num3;
						compassProPOI.miniMapIconImage.color = tintColor;
						compassProPOI.miniMapCurrentIconScale = _miniMapIconSize * compassProPOI.miniMapIconScale * num2;
						Vector3 localScale = compassProPOI.miniMapIconImageRT.localScale;
						if (SignificantlyDifferents(compassProPOI.miniMapCurrentIconScale, localScale.x))
						{
							needUpdateMiniMapIcons = true;
							float y = Mathf.Lerp(localScale.x, compassProPOI.miniMapCurrentIconScale, t);
							one.x = (one.y = y);
							compassProPOI.miniMapIconImageRT.localScale = one;
						}
						if (compassProPOI.miniMapShowRotation)
						{
							float num9 = ((!_miniMapKeepStraight) ? (quaternion * compassProPOI.transform.rotation).eulerAngles.y : compassProPOI.transform.eulerAngles.y);
							Vector3 eulerAngles = new Vector3(0f, 0f, compassProPOI.miniMapRotationAngleOffset - num9);
							compassProPOI.miniMapIconRT.eulerAngles = eulerAngles;
						}
					}
				}
				if (compassProPOI.miniMapIsVisible && !flag)
				{
					OnPOIVisibleInMiniMap?.Invoke(compassProPOI);
				}
				else if (flag && !compassProPOI.miniMapIsVisible)
				{
					OnPOIHidesInMiniMap?.Invoke(compassProPOI);
				}
				compassProPOI.ToggleMiniMapIconVisibility(flag);
			}
		}

		private bool SignificantlyDifferents(float a, float b)
		{
			float num = a - b;
			if (!(num < -0.001f))
			{
				return num > 0.001f;
			}
			return true;
		}

		private void HideMiniMapIcons()
		{
			int count = pois.Count;
			for (int i = 0; i < count; i++)
			{
				CompassProPOI compassProPOI = pois[i];
				if (!(compassProPOI == null) && (compassProPOI.miniMapType == POIMiniMapType.Any || (compassProPOI.miniMapType == POIMiniMapType.RadarOnly && _miniMapContents == MiniMapContents.Radar) || (compassProPOI.miniMapType == POIMiniMapType.MiniMapOnly && _miniMapContents != MiniMapContents.Radar)))
				{
					compassProPOI.ToggleMiniMapIconVisibility(visible: false);
					compassProPOI.ToggleMiniMapCircleVisibility(visible: false);
				}
			}
		}

		private void ComputeCircleScale(CompassProPOI poi, float miniMapAspectRatio)
		{
			Vector3 miniMapScreenPos = GetMiniMapScreenPos(miniMapCenter + new Vector3(0f, 0f, poi.radius), miniMapAspectRatio);
			float num = miniMapScreenPos.x - 0.5f;
			float num2 = miniMapScreenPos.y - 0.5f;
			float num3 = Mathf.Sqrt(num * num + num2 * num2) * 2f;
			poi.circleScale = num3 * miniMapUI.rect.height / poi.miniMapCircleRT.rect.height;
			if (poi.miniMapCircleMaterial == null)
			{
				poi.miniMapCircleMaterial = UnityEngine.Object.Instantiate(poi.miniMapCircleImage.material);
			}
			poi.miniMapCircleRT.localScale = new Vector3(poi.circleScale, poi.circleScale, 1f);
		}

		private IEnumerator AnimateCircle(CompassProPOI poi, float startTime)
		{
			if (poi == null || poi.miniMapCircleRT == null)
			{
				yield break;
			}
			poi.ToggleMiniMapCircleVisibility(visible: true);
			int repetitions = ((_focusedPOI == poi) ? int.MaxValue : poi.miniMapCircleAnimationRepetitions);
			for (int k = 0; k < repetitions; k++)
			{
				Vector3 scale = Misc.Vector3one;
				Color color = poi.miniMapCircleColor;
				float t;
				do
				{
					if (poi == null || !poi.isActiveAndEnabled || poi.miniMapCircleRT == null)
					{
						yield break;
					}
					t = (Time.time - startTime) / _miniMapIconCircleAnimationDuration;
					if (t < 1f)
					{
						scale.x = (scale.y = t * poi.circleScale);
						poi.miniMapCircleRT.localScale = scale;
						if (!poi.miniMapShowCircle)
						{
							color.a = 1f - t;
						}
						poi.miniMapCircleImage.color = color;
					}
					yield return null;
				}
				while (t < 1f);
				startTime = Time.time;
			}
			if (poi != null && !poi.miniMapShowCircle)
			{
				poi.ToggleMiniMapCircleVisibility(visible: false);
			}
		}

		private CanvasGroup GetMiniMapCanvasGroup(Transform transform)
		{
			if (transform == null)
			{
				return null;
			}
			CanvasGroup canvasGroup = transform.GetComponent<CanvasGroup>();
			if (canvasGroup == null)
			{
				canvasGroup = transform.gameObject.AddComponent<CanvasGroup>();
				canvasGroup.blocksRaycasts = false;
			}
			return canvasGroup;
		}

		private void ToggleButtonEventHandler(string buttonName, UnityAction handler, bool continuous, bool isVisible)
		{
			if (miniMapButtonsPanel == null)
			{
				return;
			}
			Transform transform = miniMapButtonsPanel.Find(buttonName);
			if (transform == null)
			{
				return;
			}
			if (!isVisible)
			{
				transform.gameObject.SetActive(value: false);
				return;
			}
			transform.gameObject.SetActive(value: true);
			Button component = transform.GetComponent<Button>();
			if (component == null)
			{
				return;
			}
			if (continuous)
			{
				CompassButtonHandler compassButtonHandler = component.GetComponent<CompassButtonHandler>();
				if (compassButtonHandler == null)
				{
					compassButtonHandler = component.gameObject.AddComponent<CompassButtonHandler>();
				}
				compassButtonHandler.actionHandler = handler;
			}
			else
			{
				component.onClick.RemoveListener(handler);
				component.onClick.AddListener(handler);
			}
		}

		private void MiniMapZoomToggle(bool state)
		{
			if (miniMapUIRootRT == null)
			{
				SetupMiniMap(force: true);
			}
			if (cameraMain == null || miniMapCamera == null)
			{
				return;
			}
			_miniMapFullScreenState = state;
			RectTransform rectTransform = miniMapUIRootRT;
			if (state)
			{
				miniMapRegularZoomLevel = _miniMapZoomLevel;
				_miniMapZoomLevel = _miniMapFullScreenZoomLevel;
				Transform transform = cameraMain.transform;
				miniMapFullScreenFixedCameraRotation = transform.rotation;
				miniMapFullScreenFixedCameraPosition = transform.position;
				miniMapAnchorMin = rectTransform.anchorMin;
				miniMapAnchorMax = rectTransform.anchorMax;
				miniMapPivot = rectTransform.pivot;
				miniMapSizeDelta = rectTransform.sizeDelta;
				miniMapCameraAspect = miniMapCamera.aspect;
				SetupMiniMap(force: true);
				float num = (1f - _miniMapFullScreenSize) * 0.5f;
				float num2;
				float num3;
				float x;
				float x2;
				if (_miniMapFullScreenPlaceholder != null)
				{
					_miniMapFullScreenPlaceholder.gameObject.SetActive(value: false);
					Rect viewportRect = _miniMapFullScreenPlaceholder.GetViewportRect(_cameraMain);
					num2 = viewportRect.yMin + num;
					num3 = viewportRect.yMax - num;
					float num4 = viewportRect.width / viewportRect.height;
					x = viewportRect.xMin + num * num4;
					x2 = viewportRect.xMax - num * num4;
				}
				else
				{
					num2 = num;
					num3 = 1f - num;
					if (_miniMapKeepAspectRatio)
					{
						float num5 = (1f - _miniMapFullScreenSize / cameraMain.aspect) * 0.5f;
						x = num5;
						x2 = 1f - num5;
					}
					else
					{
						x = num2;
						x2 = num3;
					}
				}
				rectTransform.anchorMin = new Vector3(x, num2);
				rectTransform.anchorMax = new Vector3(x2, num3);
				rectTransform.pivot = new Vector2(0.5f, 0.5f);
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.sizeDelta = new Vector2(0f, 0f);
			}
			else
			{
				_miniMapZoomLevel = miniMapRegularZoomLevel;
				rectTransform.anchorMin = miniMapAnchorMin;
				rectTransform.anchorMax = miniMapAnchorMax;
				rectTransform.pivot = miniMapPivot;
				rectTransform.sizeDelta = miniMapSizeDelta;
				SetupMiniMap(force: true);
				miniMapCamera.aspect = miniMapCameraAspect;
			}
			UpdateMiniMap();
			UpdateMiniMapIcons();
		}

		public Vector3 GetMiniMapFollowPos()
		{
			return followPos + _miniMapFollowOffset;
		}

		public Vector3 GetMiniMapFullScreenWorldCenter()
		{
			return _miniMapFullScreenWorldCenter + _miniMapFollowOffset;
		}

		private Vector2 GetMiniMapScreenPos(Vector3 poiPosition)
		{
			float miniMapAspectRatio = GetMiniMapAspectRatio();
			return GetMiniMapScreenPos(poiPosition, miniMapAspectRatio);
		}

		private Vector2 GetMiniMapScreenPosNoShift(Vector3 poiPosition)
		{
			float miniMapAspectRatio = GetMiniMapAspectRatio();
			return GetMiniMapScreenPosNoShift(poiPosition, miniMapAspectRatio);
		}

		private float GetMiniMapAspectRatio()
		{
			Vector2 size = miniMapUIRootRT.rect.size;
			if (!(size.y > 0f))
			{
				return 1f;
			}
			return size.x / size.y;
		}

		private Vector3 GetMiniMapScreenPos(Vector3 poiPosition, float aspectRatio)
		{
			Vector3 miniMapScreenPosNoShift = GetMiniMapScreenPosNoShift(poiPosition, aspectRatio);
			miniMapScreenPosNoShift.x += _miniMapIconPositionShift.x;
			miniMapScreenPosNoShift.y += _miniMapIconPositionShift.y;
			return miniMapScreenPosNoShift;
		}

		private Vector3 GetMiniMapScreenPosNoShift(Vector3 poiPosition, float aspectRatio)
		{
			float num = currentMiniMapZoomLevel;
			Vector3 result = miniMapCamera.WorldToViewportPoint(poiPosition);
			result.x = (result.x - 0.5f) / num + 0.5f;
			result.y = (result.y - 0.5f) / num + 0.5f;
			result.y = (result.y - 0.5f) * aspectRatio + 0.5f;
			return result;
		}

		public Vector3 GetWorldPositionFromPointerEvent(Vector2 position)
		{
			Rect screenRect = miniMapUI.GetScreenRect();
			Vector2 uv = default(Vector2);
			uv.x = (position.x - screenRect.xMin) / screenRect.width;
			uv.y = (position.y - screenRect.yMin) / screenRect.height;
			return GetMiniMapWorldPositionFromUV(uv);
		}

		public Vector3 GetMiniMapWorldPositionFromUV(Vector2 uv)
		{
			if (miniMapCamera == null)
			{
				return Vector3.zero;
			}
			float num = currentMiniMapZoomLevel;
			uv.x = (uv.x - 0.5f) * num + 0.5f;
			uv.y = (uv.y - 0.5f) * num + 0.5f;
			Vector2 size = miniMapUIRootRT.rect.size;
			float num2 = size.y / size.x;
			uv.y = (uv.y - 0.5f) * num2 + 0.5f;
			float z = Mathf.Abs(followPos.y - miniMapCamera.transform.position.y);
			Vector3 result = miniMapCamera.ViewportToWorldPoint(new Vector3(uv.x, uv.y, z));
			result.y = 0f;
			return result;
		}

		private void DestroySafe(UnityEngine.Object o)
		{
			UnityEngine.Object.Destroy(o);
		}
	}
}
