using Dhs5.Utility.Settings;
using Simulator;
using UnityEngine;
using UnityEngine.VFX;

namespace Tabletop.GameWorld
{
	[Settings("Tabletop/Miniature Assembly", Scope.Project)]
	public class MiniatureAssemblySettings : CustomSettings<MiniatureAssemblySettings>
	{
		[Header("VFX")]
		[SerializeField]
		private VisualEffect m_pieceVFXPrefab;

		[Header("Camera offset")]
		[SerializeField]
		private Vector3 m_offsetFromCamera = new Vector3(0f, 0f, 1f);

		[SerializeField]
		private Vector3 m_offsetFromCameraMiniature = new Vector3(0f, 0f, 1f);

		[SerializeField]
		private Vector3 m_itemOffsetMain = Vector3.zero;

		[SerializeField]
		private float m_offsetItemLeft = 0.4f;

		[Header("Start")]
		[SerializeField]
		private float m_impulseForce = 0.002f;

		[SerializeField]
		private float m_itemTopOffsetForStartAnimation;

		[SerializeField]
		private float m_delayBetweenItemsStartAnimation = 0.2f;

		[SerializeField]
		private float m_itemsStartAnimationDuration = 0.5f;

		[SerializeField]
		private AnimationCurve m_itemsStartAnimationCurve;

		[Header("Idle slow rotation")]
		[SerializeField]
		private float m_idleNoiseRotationSpeed = 0.5f;

		[SerializeField]
		private float m_idleNoiseRotationPower = 6.5f;

		[SerializeField]
		private float m_idleNoiseRotationSpeedMiniature = 0.5f;

		[SerializeField]
		private float m_idleNoiseRotationPowerMiniature = 10f;

		[SerializeField]
		private float m_rotationSensivity = 180f;

		[SerializeField]
		private float m_rotationLerpSpeed = 15f;

		[Header("Idle slow sine")]
		[SerializeField]
		private float m_idleSineSpeed = 3f;

		[SerializeField]
		private float m_idleSinePower = 0.00375f;

		[Header("Plug anim")]
		[SerializeField]
		private float m_itemsPlugAnimationDuration = 1f;

		[SerializeField]
		private AnimationCurve m_itemsPlugAnimationCurveY;

		[SerializeField]
		private AnimationCurve m_itemsPlugAnimationCurveXZ;

		[SerializeField]
		private AnimationCurve m_itemsPlugScaleCurve;

		[SerializeField]
		private float m_piecesTransformSquashPower = 0.8f;

		[SerializeField]
		private float m_piecesTransformSquashLerpSpeed = 5f;

		[SerializeField]
		private AnimationCurve m_itemsPlugAnimationBlendPointBC;

		[SerializeField]
		private float m_offsetFromParentPow = 2f;

		[Header("Plug base anim")]
		[SerializeField]
		private float m_basePlugDuration = 0.2f;

		[SerializeField]
		private AnimationCurve m_basePlugAnimationCurve;

		[SerializeField]
		private float m_baseTrYoffset = -0.5f;

		[Header("Sizes")]
		[SerializeField]
		private float m_targetSize = 0.2f;

		[SerializeField]
		private float m_targetSizeMiniature = 0.5f;

		[Header("Spin")]
		[SerializeField]
		private AnimationCurve m_miniatureSpinSpeedCurve;

		[SerializeField]
		private float m_miniatureSpinDuration;

		[SerializeField]
		[Min(1f)]
		private int m_miniatureSpinCount = 3;

		[SerializeField]
		private float m_miniatureTimeToAllowTurn = 0.5f;

		[Header("Miniature fly")]
		[SerializeField]
		private AnimationCurve m_miniatureFlyCurve;

		[SerializeField]
		private AnimationCurve m_miniatureFlyCurveoffset;

		[SerializeField]
		private Vector3 m_miniatureFlyPointBoffset;

		[SerializeField]
		private AnimationCurve m_miniatureFlyScaleCurve;

		[SerializeField]
		private float m_miniatureFlyDuration;

		[SerializeField]
		private Vector3 m_miniatureFlyOffset;

		[SerializeField]
		private float m_flyRotationPower = 50f;

		[Header("Input hint")]
		[SerializeField]
		private InputHint.Data[] m_inputHintData;

		public static VisualEffect PieceVFXPrefab => CustomSettings<MiniatureAssemblySettings>.I.m_pieceVFXPrefab;

		public static Vector3 OffsetFromCamera => CustomSettings<MiniatureAssemblySettings>.I.m_offsetFromCamera;

		public static Vector3 OffsetFromCameraMiniature => CustomSettings<MiniatureAssemblySettings>.I.m_offsetFromCameraMiniature;

		public static Vector3 ItemOffsetMain => CustomSettings<MiniatureAssemblySettings>.I.m_itemOffsetMain;

		public static float OffsetItemLeft => CustomSettings<MiniatureAssemblySettings>.I.m_offsetItemLeft;

		public static float ImpulseForce => CustomSettings<MiniatureAssemblySettings>.I.m_impulseForce;

		public static float ItemTopOffsetForStartAnimation => CustomSettings<MiniatureAssemblySettings>.I.m_itemTopOffsetForStartAnimation;

		public static float DelayBetweenItemsStartAnimation => CustomSettings<MiniatureAssemblySettings>.I.m_delayBetweenItemsStartAnimation;

		public static float ItemsStartAnimationDuration => CustomSettings<MiniatureAssemblySettings>.I.m_itemsStartAnimationDuration;

		public static AnimationCurve ItemsStartAnimationCurve => CustomSettings<MiniatureAssemblySettings>.I.m_itemsStartAnimationCurve;

		public static float IdleNoiseRotationSpeed => CustomSettings<MiniatureAssemblySettings>.I.m_idleNoiseRotationSpeed;

		public static float IdleNoiseRotationPower => CustomSettings<MiniatureAssemblySettings>.I.m_idleNoiseRotationPower;

		public static float IdleNoiseRotationSpeedMiniature => CustomSettings<MiniatureAssemblySettings>.I.m_idleNoiseRotationSpeedMiniature;

		public static float IdleNoiseRotationPowerMiniature => CustomSettings<MiniatureAssemblySettings>.I.m_idleNoiseRotationPowerMiniature;

		public static float RotationSensivity => CustomSettings<MiniatureAssemblySettings>.I.m_rotationSensivity;

		public static float RotationLerpSpeed => CustomSettings<MiniatureAssemblySettings>.I.m_rotationLerpSpeed;

		public static float IdleSineSpeed => CustomSettings<MiniatureAssemblySettings>.I.m_idleSineSpeed;

		public static float IdleSinePower => CustomSettings<MiniatureAssemblySettings>.I.m_idleSinePower;

		public static float ItemsPlugAnimationDuration => CustomSettings<MiniatureAssemblySettings>.I.m_itemsPlugAnimationDuration;

		public static AnimationCurve ItemsPlugAnimationCurveY => CustomSettings<MiniatureAssemblySettings>.I.m_itemsPlugAnimationCurveY;

		public static AnimationCurve ItemsPlugAnimationCurveXZ => CustomSettings<MiniatureAssemblySettings>.I.m_itemsPlugAnimationCurveXZ;

		public static AnimationCurve ItemsPlugScaleCurve => CustomSettings<MiniatureAssemblySettings>.I.m_itemsPlugScaleCurve;

		public static float PiecesTransformSquashPower => CustomSettings<MiniatureAssemblySettings>.I.m_piecesTransformSquashPower;

		public static float PiecesTransformSquashLerpSpeed => CustomSettings<MiniatureAssemblySettings>.I.m_piecesTransformSquashLerpSpeed;

		public static AnimationCurve ItemsPlugAnimationBlendPointBC => CustomSettings<MiniatureAssemblySettings>.I.m_itemsPlugAnimationBlendPointBC;

		public static float OffsetFromParentPow => CustomSettings<MiniatureAssemblySettings>.I.m_offsetFromParentPow;

		public static float BasePlugDuration => CustomSettings<MiniatureAssemblySettings>.I.m_basePlugDuration;

		public static AnimationCurve BasePlugAnimationCurve => CustomSettings<MiniatureAssemblySettings>.I.m_basePlugAnimationCurve;

		public static float BaseTrYoffset => CustomSettings<MiniatureAssemblySettings>.I.m_baseTrYoffset;

		public static float TargetSize => CustomSettings<MiniatureAssemblySettings>.I.m_targetSize;

		public static float TargetSizeMiniature => CustomSettings<MiniatureAssemblySettings>.I.m_targetSizeMiniature;

		public static AnimationCurve MiniatureSpinSpeedCurve => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureSpinSpeedCurve;

		public static float MiniatureSpinDuration => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureSpinDuration;

		public static float MiniatureSpinCount => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureSpinCount;

		public static float MiniatureTimeToAllowTurn => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureTimeToAllowTurn;

		public static AnimationCurve MiniatureFlyCurve => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureFlyCurve;

		public static AnimationCurve MiniatureFlyCurveoffset => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureFlyCurveoffset;

		public static Vector3 MiniatureFlyPointBoffset => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureFlyPointBoffset;

		public static AnimationCurve MiniatureFlyScaleCurve => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureFlyScaleCurve;

		public static float MiniatureFlyDuration => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureFlyDuration;

		public static Vector3 MiniatureFlyOffset => CustomSettings<MiniatureAssemblySettings>.I.m_miniatureFlyOffset;

		public static float FlyRotationPower => CustomSettings<MiniatureAssemblySettings>.I.m_flyRotationPower;

		public static InputHint.Data[] InputHintData => CustomSettings<MiniatureAssemblySettings>.I.m_inputHintData;
	}
}
