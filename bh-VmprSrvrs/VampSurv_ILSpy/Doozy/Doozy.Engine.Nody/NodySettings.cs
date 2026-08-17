using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody;

public class NodySettings : ScriptableObject
{
	public const string FILE_NAME = "NodySettings";

	private static NodySettings s_instance;

	public float NormalOpacity;

	public float ActiveOpacity;

	public float HoverOpacity;

	public float FooterHeight;

	public float MaxNodeWidth;

	public float MinNodeWidth;

	public float NodeAccentLineHeight;

	public float NodeAddSocketButtonSize;

	public float NodeBodyOpacity;

	public float NodeDeleteButtonSize;

	public float NodeGlowOpacity;

	public float NodeHeaderHeight;

	public float NodeHeaderIconSize;

	public float PingColorChangeSpeed;

	public float SocketConnectedOpacity;

	public float SocketCurveModifierMaxValue;

	public float SocketCurveModifierMinValue;

	public float SocketDividerHeight;

	public float SocketDividerOpacity;

	public float SocketHeight;

	public float SocketNotConnectedOpacity;

	public float SocketVerticalSpacing;

	public float ConnectionPointHeight;

	public float ConnectionPointOffsetFromLeftMargin;

	public float ConnectionPointOffsetFromRightMargin;

	public float ConnectionPointWidth;

	public float CurvePointsMultiplier;

	public float CurveStrengthModifier;

	public float CurveWidth;

	public float DefaultCurveModifier;

	public float MaxCurveModifier;

	public float MinCurveModifier;

	public float GraphTabDividerWidth;

	public float GraphTabElementSpacing;

	public float GraphTabMaximumWidth;

	public float GraphTabMinimumWidth;

	public float GraphTabsAreaHeight;

	public float GraphTabsBackgroundOpacity;

	public double RepaintIntervalDuringPlayMode;

	public double RepaintIntervalWhileIdle;

	public string EditorPrefsKeyWindowToolbar;

	public string EditorPrefsKeyDotAnimationSpeed;

	public float DefaultNodeHeight;

	public float DefaultNodeWidth;

	public float EnterNodeWidth;

	public float ExitNodeWidth;

	public float StartNodeWidth;

	public float SubGraphNodeWidth;

	public float SwitchBackNodeWidth;

	public HideFlags DefaultHideFlagsForNodes;

	private static string ResourcesPath => DoozyPath.ENGINE_NODY_RESOURCES_PATH;

	public static NodySettings Instance
	{
		get
		{
			NodySettings nodySettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)nodySettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				NodySettings nodySettings2 = default(NodySettings);
				s_instance = nodySettings2;
			}
			return s_instance;
		}
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public NodySettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B1E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		NormalOpacity = 0.8f;
		RepaintIntervalDuringPlayMode = 0.4000000059604645;
		RepaintIntervalWhileIdle = 0.6000000238418579;
		ActiveOpacity = 0.6f;
		HoverOpacity = 1f;
		FooterHeight = 10f;
		MaxNodeWidth = 300f;
		MinNodeWidth = 100f;
		NodeAccentLineHeight = 2f;
		NodeAddSocketButtonSize = 12f;
		NodeBodyOpacity = 0.7f;
		NodeDeleteButtonSize = 20f;
		NodeGlowOpacity = 0.2f;
		NodeHeaderHeight = 32f;
		NodeHeaderIconSize = 20f;
		PingColorChangeSpeed = 0.6f;
		SocketConnectedOpacity = 1f;
		SocketCurveModifierMaxValue = 1f;
		SocketCurveModifierMinValue = -1f;
		SocketDividerHeight = 1f;
		SocketDividerOpacity = 0.3f;
		SocketHeight = 24f;
		SocketNotConnectedOpacity = 0.5f;
		ConnectionPointHeight = 16f;
		ConnectionPointOffsetFromLeftMargin = -2f;
		ConnectionPointOffsetFromRightMargin = 2f;
		ConnectionPointWidth = 16f;
		CurvePointsMultiplier = 3f;
		CurveStrengthModifier = 0.48f;
		CurveWidth = 3f;
		MaxCurveModifier = 0.5f;
		MinCurveModifier = -0.5f;
		GraphTabDividerWidth = 1f;
		GraphTabElementSpacing = 4f;
		GraphTabMaximumWidth = 200f;
		GraphTabMinimumWidth = 40f;
		GraphTabsAreaHeight = 40f;
		GraphTabsBackgroundOpacity = 0.8f;
		EditorPrefsKeyWindowToolbar = "Doozy.Nody.WindowToolbar";
		EditorPrefsKeyDotAnimationSpeed = "Doozy.Nody.DotAnimationSpeed";
		DefaultNodeHeight = 216f;
		DefaultNodeWidth = 216f;
		EnterNodeWidth = 120f;
		ExitNodeWidth = 120f;
		StartNodeWidth = 120f;
		SubGraphNodeWidth = 216f;
		SwitchBackNodeWidth = 216f;
		DefaultHideFlagsForNodes = HideFlags.HideInHierarchy;
		base._002Ector();
	}
}
