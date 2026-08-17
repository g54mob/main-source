using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public static class PrefsData
{
	public static string NumericBoundariesColorKey;

	public static Color NumericBoundariesColorValue;

	public static string TargetsMidPointColorKey;

	public static Color TargetsMidPointColorValue;

	public static string InfluencesColorKey;

	public static Color InfluencesColorValue;

	public static string ShakeInfluenceColorKey;

	public static Color ShakeInfluenceColorValue;

	public static string OverallOffsetColorKey;

	public static Color OverallOffsetColorValue;

	public static string CamDistanceColorKey;

	public static Color CamDistanceColorValue;

	public static string CamTargetPositionColorKey;

	public static Color CamTargetPositionColorValue;

	public static string CamTargetPositionSmoothedColorKey;

	public static Color CamTargetPositionSmoothedColorValue;

	public static string CurrentCameraPositionColorKey;

	public static Color CurrentCameraPositionColorValue;

	public static string CameraWindowColorKey;

	public static Color CameraWindowColorValue;

	public static string ForwardFocusColorKey;

	public static Color ForwardFocusColorValue;

	public static string ZoomToFitColorKey;

	public static Color ZoomToFitColorValue;

	public static string BoundariesTriggerColorKey;

	public static Color BoundariesTriggerColorValue;

	public static string InfluenceTriggerColorKey;

	public static Color InfluenceTriggerColorValue;

	public static string ZoomTriggerColorKey;

	public static Color ZoomTriggerColorValue;

	public static string TriggerShapeColorKey;

	public static Color TriggerShapeColorValue;

	public static string RailsColorKey;

	public static Color RailsColorValue;

	public static float RailsSnapping;

	public static string PanEdgesColorKey;

	public static Color PanEdgesColorValue;

	public static string RoomsColorKey;

	public static Color RoomsColorValue;

	public static float RoomsSnapping;

	public static string FitterFillColorKey;

	public static Color FitterFillColorValue;

	public static string FitterLineColorKey;

	public static Color FitterLineColorValue;

	static PrefsData()
	{
		//IL_0016: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_0076: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_00d6: Expected O, but got I
		//IL_00f6: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0136: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0176: Expected O, but got I
		//IL_0196: Expected O, but got I
		//IL_01b6: Expected O, but got I
		//IL_01d6: Expected O, but got I
		//IL_01f6: Expected O, but got I
		//IL_0216: Expected O, but got I
		//IL_0240: Expected O, but got I
		//IL_0260: Expected O, but got I
		//IL_028a: Expected O, but got I
		//IL_02aa: Expected O, but got I
		NumericBoundariesColorKey = "Numeric Boundaries";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		NumericBoundariesColorValue = (Color)0;
		TargetsMidPointColorKey = "Targets Mid Point";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
		TargetsMidPointColorValue = (Color)0;
		InfluencesColorKey = "Influences Sum";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		InfluencesColorValue = (Color)0;
		ShakeInfluenceColorKey = "Shake Influence";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		ShakeInfluenceColorValue = (Color)0;
		OverallOffsetColorKey = "Overall Offset";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
		OverallOffsetColorValue = (Color)0;
		CamDistanceColorKey = "Camera Distance Limit";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		CamDistanceColorValue = (Color)0;
		CamTargetPositionColorKey = "Camera Target Position";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12080]");
		CamTargetPositionColorValue = (Color)0;
		CamTargetPositionSmoothedColorKey = "Camera Target Position Smoothed";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12090]");
		CamTargetPositionSmoothedColorValue = (Color)0;
		CurrentCameraPositionColorKey = "Current Camera Position";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120A0]");
		CurrentCameraPositionColorValue = (Color)0;
		CameraWindowColorKey = "Camera Window";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		CameraWindowColorValue = (Color)0;
		ForwardFocusColorKey = "Forward Focus";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		ForwardFocusColorValue = (Color)0;
		ZoomToFitColorKey = "Zoom To Fit";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12420]");
		ZoomToFitColorValue = (Color)0;
		BoundariesTriggerColorKey = "Trigger Boundaries";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11D80]");
		BoundariesTriggerColorValue = (Color)0;
		InfluenceTriggerColorKey = "Trigger Influence";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11D80]");
		InfluenceTriggerColorValue = (Color)0;
		ZoomTriggerColorKey = "Trigger Zoom";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11D80]");
		ZoomTriggerColorValue = (Color)0;
		TriggerShapeColorKey = "Trigger Shape";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11D80]");
		TriggerShapeColorValue = (Color)0;
		RailsColorKey = "Rails";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		RailsColorValue = (Color)0;
		RailsSnapping = 0.1f;
		PanEdgesColorKey = "Pan Edges";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		PanEdgesColorValue = (Color)0;
		RoomsColorKey = "Rooms";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		RoomsColorValue = (Color)0;
		RoomsSnapping = 0.1f;
		FitterFillColorKey = "Fitter Fill";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11D30]");
		FitterFillColorValue = (Color)0;
		FitterLineColorKey = "Fitter Line";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11E10]");
		FitterLineColorValue = (Color)0;
	}
}
