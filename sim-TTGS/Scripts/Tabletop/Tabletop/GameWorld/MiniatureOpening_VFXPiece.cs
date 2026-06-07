using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

namespace Tabletop.GameWorld
{
	public class MiniatureOpening_VFXPiece : MonoBehaviour
	{
		public enum EDebugModeVFXBox
		{
			None = 0,
			AlwaysGold = 1,
			AlwaysLead = 2,
			AlwaysPlastic = 3
		}

		private struct MaterialsContainer
		{
			private List<Material> _mats;

			public void Add(Material mat)
			{
				if (!_mats.IsValid())
				{
					_mats = new List<Material>();
				}
				_mats.Add(mat);
			}

			public void SetFloat(string name, float value)
			{
				foreach (Material mat in _mats)
				{
					mat.SetFloat(name, value);
				}
			}
		}

		public enum EPieceState
		{
			InBox = 0,
			GoingToCenter = 1,
			IdleOnCenter = 2,
			LeavingView = 3,
			LeftView = 4
		}

		private Vector3 _wpCenter;

		private Vector3 _startPos;

		private Vector3 _startScale;

		private Matrix4x4 _localToWorldFromCamera;

		[FormerlySerializedAs("inCurve")]
		[Header("Curves")]
		[SerializeField]
		private AnimationCurve inMovementCurve;

		[SerializeField]
		private AnimationCurve inScaleCurve;

		[FormerlySerializedAs("outCurve")]
		[SerializeField]
		private AnimationCurve outMovementCurve;

		[SerializeField]
		private AnimationCurve outScaleCurve;

		private float _t;

		private bool _materialWait;

		private bool _animatingMaterialOut;

		private float _timeCurve;

		[SerializeField]
		private float durationInCurve = 1f;

		[SerializeField]
		private float durationOutCurve = 1f;

		[SerializeField]
		private CinemachineImpulseSource cinemachineImpulseSource;

		[SerializeField]
		private float impulseForce = 0.05f;

		[Header("Sin")]
		[SerializeField]
		private float idleSineSpeed = 3f;

		[SerializeField]
		private float idleSinePower = 0.00375f;

		[Header("idle slow rotation")]
		[SerializeField]
		private float idleNoiseRotationSpeed = 1f;

		[SerializeField]
		private float idleNoiseRotationPower = 5f;

		[Header("leaving View")]
		[SerializeField]
		private float leaveViewMultiplier = 0.5f;

		[SerializeField]
		private float randomAngle = 60f;

		[Header("petit randpom a la sortie de la boite sur la rotation")]
		[SerializeField]
		private float randomANgleForce = 10f;

		[Header("vfx aura")]
		[SerializeField]
		private VisualEffect vfxAura;

		private const string RarityIntNameInVfx = "rarity";

		private Vector3 _leaveViewPos = Vector3.zero;

		private Quaternion _leaveViewRot = Quaternion.identity;

		private Quaternion _baseRot;

		private Vector3 _cachedPos;

		private Vector3 _cachedScale;

		private Quaternion _cachedRot;

		[Header("scale")]
		[SerializeField]
		private Vector3 insidePieceScale = new Vector3(0.1f, 0.1f, 0.1f);

		[SerializeField]
		private Vector3 globalScale = Vector3.one;

		[Header("Rotation sensi")]
		[SerializeField]
		private float rotationSensivity = 120f;

		[SerializeField]
		private float rotationLerpSpeed = 4f;

		[SerializeField]
		private Material plasticMaterial;

		[Tooltip("plomb")]
		[SerializeField]
		private Material leadMaterial;

		[SerializeField]
		private Material goldMaterial;

		[Header("Debug")]
		[SerializeField]
		private EDebugModeVFXBox debugMode;

		private EPieceState state;

		public void Init(MiniaturePieceData pieceData, Vector3 offsetFromCam, Vector3 startPosition, Matrix4x4 localToWorldMatrixCamera)
		{
			_wpCenter = localToWorldMatrixCamera.MultiplyPoint(offsetFromCam);
			_startPos = startPosition;
			_localToWorldFromCamera = localToWorldMatrixCamera;
			Transform obj = UnityEngine.Object.Instantiate(pieceData.Prefab, base.transform).transform;
			obj.localScale = insidePieceScale;
			_startScale = globalScale;
			MeshRenderer[] componentsInChildren = obj.GetComponentsInChildren<MeshRenderer>();
			int rarity = pieceData.MiniatureData.Rarity;
			Material miniaturesUnpaintedMat = PaintingSettings.GetMiniaturesUnpaintedMat(rarity);
			vfxAura.SetInt("rarity", (int)MiniatureSettings.GetTypeFromRarity(rarity));
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].material = miniaturesUnpaintedMat;
			}
			_baseRot = base.transform.rotation;
			float num = UnityEngine.Random.Range(0f - randomAngle, randomAngle);
			Quaternion quaternion = Quaternion.Euler(0f, 0f, num);
			Quaternion quaternion2 = Quaternion.Euler(0f, 0f, (0f - num) * 90f);
			Vector3 vector = quaternion * new Vector3(0f, leaveViewMultiplier, 0f);
			_leaveViewPos = _wpCenter + _localToWorldFromCamera.MultiplyVector(vector);
			_leaveViewRot = base.transform.rotation * quaternion2;
		}

		public void RequestLeaveCenter()
		{
			if (state != EPieceState.LeftView && state != EPieceState.LeavingView)
			{
				bool num = state != EPieceState.IdleOnCenter;
				state = EPieceState.LeavingView;
				_cachedPos = _wpCenter;
				base.transform.localScale = _startScale;
				_cachedScale = base.transform.localScale;
				_cachedRot = base.transform.rotation;
				_timeCurve = 0f;
				if (num)
				{
					vfxAura.Play();
					cinemachineImpulseSource.GenerateImpulseWithForce(impulseForce);
				}
			}
		}

		public void RequestLeaveBox()
		{
			_timeCurve = 0f;
			state = EPieceState.GoingToCenter;
			_materialWait = true;
		}

		public EPieceState Animate(float deltaTime, Vector2 mousePosition)
		{
			switch (state)
			{
			case EPieceState.InBox:
				return state;
			case EPieceState.GoingToCenter:
				_timeCurve += deltaTime / durationInCurve;
				base.transform.position = Vector3.LerpUnclamped(_startPos, _wpCenter, inMovementCurve.Evaluate(_timeCurve));
				base.transform.localScale = Vector3.LerpUnclamped(Vector3.zero, _startScale, inScaleCurve.Evaluate(_timeCurve));
				if (_timeCurve > 1f)
				{
					state = EPieceState.IdleOnCenter;
					_cachedPos = base.transform.position;
					base.transform.localScale = _startScale;
					_cachedScale = base.transform.localScale;
					_timeCurve = 0f;
					vfxAura.Play();
					cinemachineImpulseSource.GenerateImpulseWithForce(impulseForce);
				}
				MoveVfxToCenter();
				break;
			case EPieceState.IdleOnCenter:
				_timeCurve += deltaTime;
				base.transform.position = _cachedPos + VfxStuff.SineAlongVector(Vector3.up, 0f, _timeCurve, idleSineSpeed, idleSinePower);
				break;
			case EPieceState.LeavingView:
				_timeCurve += deltaTime / durationOutCurve;
				base.transform.position = Vector3.LerpUnclamped(_cachedPos, _leaveViewPos, outMovementCurve.Evaluate(_timeCurve));
				base.transform.localScale = Vector3.LerpUnclamped(_cachedScale, Vector3.zero, outScaleCurve.Evaluate(_timeCurve));
				base.transform.rotation = Quaternion.LerpUnclamped(_cachedRot, _leaveViewRot, outMovementCurve.Evaluate(_timeCurve));
				if (_timeCurve > 1f)
				{
					state = EPieceState.LeftView;
				}
				MoveVfxToCenter();
				return state;
			case EPieceState.LeftView:
				return state;
			default:
				throw new ArgumentOutOfRangeException();
			}
			Quaternion quaternion = Quaternion.Euler(VfxStuff.NoisedVector(0f, _timeCurve, idleNoiseRotationSpeed, idleNoiseRotationPower));
			Quaternion b = _baseRot * VfxStuff.MousePosRemappedToRotation(mousePosition, rotationSensivity) * quaternion;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, rotationLerpSpeed * deltaTime);
			return state;
			void MoveVfxToCenter()
			{
				if (vfxAura.isActiveAndEnabled && !vfxAura.culled)
				{
					vfxAura.transform.position = _wpCenter;
				}
			}
		}
	}
}
