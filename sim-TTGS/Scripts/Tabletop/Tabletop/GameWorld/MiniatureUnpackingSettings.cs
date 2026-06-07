using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.VFX;

namespace Tabletop.GameWorld
{
	[Settings("Tabletop/Miniature Unpacking", Scope.Project)]
	public class MiniatureUnpackingSettings : CustomSettings<MiniatureUnpackingSettings>
	{
		[Header("References")]
		[SerializeField]
		private VisualEffect m_visualEffect;

		[SerializeField]
		private GameObject m_pieceVFXPrefab;

		[Header("Parameters")]
		[SerializeField]
		private Vector3 m_visualEffectOffset = Vector3.up;

		[SerializeField]
		private Vector3 m_camPosOffsetForPieces = Vector3.one;

		[SerializeField]
		private AnimationCurve m_boxToTargetCurve;

		[SerializeField]
		private float m_boxToTargetDuration = 0.5f;

		[SerializeField]
		private Vector3 m_boxPosTargetRelativeToCamera = Vector3.zero;

		[SerializeField]
		private Vector3 m_boxScaleTarget = Vector3.one;

		public static VisualEffect VisualEffect => CustomSettings<MiniatureUnpackingSettings>.I.m_visualEffect;

		public static GameObject PieceVFXPrefab => CustomSettings<MiniatureUnpackingSettings>.I.m_pieceVFXPrefab;

		public static Vector3 VisualEffectOffset => CustomSettings<MiniatureUnpackingSettings>.I.m_visualEffectOffset;

		public static Vector3 CamPosOffsetForPieces => CustomSettings<MiniatureUnpackingSettings>.I.m_camPosOffsetForPieces;

		public static AnimationCurve BoxToTargetCurve => CustomSettings<MiniatureUnpackingSettings>.I.m_boxToTargetCurve;

		public static float BoxToTargetDuration => CustomSettings<MiniatureUnpackingSettings>.I.m_boxToTargetDuration;

		public static Vector3 BoxPosTargetRelativeToCamera => CustomSettings<MiniatureUnpackingSettings>.I.m_boxPosTargetRelativeToCamera;

		public static Vector3 BoxScaleTarget => CustomSettings<MiniatureUnpackingSettings>.I.m_boxScaleTarget;
	}
}
