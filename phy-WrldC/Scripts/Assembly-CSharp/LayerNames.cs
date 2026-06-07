using UnityEngine;

public static class LayerNames
{
	private const string StrDefault = "Default";

	private const string StrTransparentFX = "TransparentFX";

	private const string StrUI = "UI";

	private const string StrLevel = "Level";

	private const string StrConnector = "Connector";

	private const string StrBlock = "Block";

	private const string StrBlockVisualization = "BlockVisualization";

	private const string StrPlaceholderCreation = "PlaceholderCreation";

	private const string StrConstructionZone = "ConstructionZone";

	private const string StrButton3D = "Button3D";

	private const string StrMiddleCamera = "MiddleCamera";

	private const string StrFrontCamera = "FrontCamera";

	private const string StrUI3DCamera = "UI3DCamera";

	private const string StrThumbnail = "Thumbnail";

	private const string StrLEPermanent = "LE_Permanent";

	private const string StrLEScalable = "LE_Scalable";

	private const string StrLEUnscalable = "LE_Unscalable";

	private const string StrWheel = "Wheel";

	public static readonly int Default = LayerMask.NameToLayer("Default");

	public static readonly int TransparentFX = LayerMask.NameToLayer("TransparentFX");

	public static readonly int UI = LayerMask.NameToLayer("UI");

	public static readonly int Connector = LayerMask.NameToLayer("Connector");

	public static readonly int Level = LayerMask.NameToLayer("Level");

	public static readonly int Block = LayerMask.NameToLayer("Block");

	public static readonly int BlockVisualization = LayerMask.NameToLayer("BlockVisualization");

	public static readonly int PlaceholderCreation = LayerMask.NameToLayer("PlaceholderCreation");

	public static readonly int ConstructionZone = LayerMask.NameToLayer("ConstructionZone");

	public static readonly int Button3D = LayerMask.NameToLayer("Button3D");

	public static readonly int MiddleCamera = LayerMask.NameToLayer("MiddleCamera");

	public static readonly int FrontCamera = LayerMask.NameToLayer("FrontCamera");

	public static readonly int UI3DCamera = LayerMask.NameToLayer("UI3DCamera");

	public static readonly int Thumbnail = LayerMask.NameToLayer("Thumbnail");

	public static readonly int LEPermanent = LayerMask.NameToLayer("LE_Permanent");

	public static readonly int LEScalable = LayerMask.NameToLayer("LE_Scalable");

	public static readonly int LEUnscalable = LayerMask.NameToLayer("LE_Unscalable");

	public static readonly int Wheel = LayerMask.NameToLayer("Wheel");

	public static readonly int UIMask = 1 << LayerMask.NameToLayer("UI");

	public static readonly int LevelMask = 1 << LayerMask.NameToLayer("Level");

	public static readonly int ConnectorMask = 1 << LayerMask.NameToLayer("Connector");

	public static readonly int BlockMask = 1 << LayerMask.NameToLayer("Block");

	public static readonly int BlockVisualizationMask = 1 << LayerMask.NameToLayer("BlockVisualization");

	public static readonly int ConstructionZoneMask = 1 << LayerMask.NameToLayer("ConstructionZone");

	public static readonly int PlaceholderCreationMask = 1 << LayerMask.NameToLayer("PlaceholderCreation");

	public static readonly int Button3DMask = 1 << LayerMask.NameToLayer("Button3D");

	public static readonly int MiddleCameraMask = 1 << LayerMask.NameToLayer("MiddleCamera");

	public static readonly int FrontCameraMask = 1 << LayerMask.NameToLayer("FrontCamera");

	public static readonly int UI3DCameraMask = 1 << LayerMask.NameToLayer("UI3DCamera");

	public static readonly int WheelMask = 1 << LayerMask.NameToLayer("Wheel");

	public static readonly int ThumbnailMask = 1 << LayerMask.NameToLayer("Thumbnail");

	public static readonly int LEPermanentMask = 1 << LayerMask.NameToLayer("LE_Permanent");

	public static readonly int LEScalableMask = 1 << LayerMask.NameToLayer("LE_Scalable");

	public static readonly int LEUnscalableMask = 1 << LayerMask.NameToLayer("LE_Unscalable");
}
