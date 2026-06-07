using UnityEngine;

namespace Doozy.Engine.Nody
{
	public class NodySettings : ScriptableObject
	{
		public const string FILE_NAME = "NodySettings";

		private static NodySettings s_instance;

		[Header("Opacity Values")]
		public float NormalOpacity;

		public float ActiveOpacity;

		public float HoverOpacity;

		[Header("Node GUI")]
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

		[Header("Socket GUI")]
		public float SocketConnectedOpacity;

		public float SocketCurveModifierMaxValue;

		public float SocketCurveModifierMinValue;

		public float SocketDividerHeight;

		public float SocketDividerOpacity;

		public float SocketHeight;

		public float SocketNotConnectedOpacity;

		public float SocketVerticalSpacing;

		[Header("Connection GUI")]
		public float ConnectionPointHeight;

		public float ConnectionPointOffsetFromLeftMargin;

		public float ConnectionPointOffsetFromRightMargin;

		public float ConnectionPointWidth;

		[Header("Curve Settings")]
		public float CurvePointsMultiplier;

		public float CurveStrengthModifier;

		public float CurveWidth;

		public float DefaultCurveModifier;

		public float MaxCurveModifier;

		public float MinCurveModifier;

		[Header("Graph Tabs")]
		public float GraphTabDividerWidth;

		public float GraphTabElementSpacing;

		public float GraphTabMaximumWidth;

		public float GraphTabMinimumWidth;

		public float GraphTabsAreaHeight;

		public float GraphTabsBackgroundOpacity;

		[Header("Repaint Intervals")]
		public double RepaintIntervalDuringPlayMode;

		public double RepaintIntervalWhileIdle;

		[Header("Editor Prefs Keys")]
		public string EditorPrefsKeyWindowToolbar;

		public string EditorPrefsKeyDotAnimationSpeed;

		[Header("Default Node Sizes")]
		public float DefaultNodeHeight;

		public float DefaultNodeWidth;

		public float EnterNodeWidth;

		public float ExitNodeWidth;

		public float StartNodeWidth;

		public float SubGraphNodeWidth;

		public float SwitchBackNodeWidth;

		[Header("Misc")]
		public HideFlags DefaultHideFlagsForNodes;

		private static string ResourcesPath => null;

		public static NodySettings Instance => null;

		public void SetDirty(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}
	}
}
