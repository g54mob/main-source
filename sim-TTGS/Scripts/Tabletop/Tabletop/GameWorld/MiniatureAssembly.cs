using System;
using Dhs5.Utility.Updates;
using Simulator;
using Simulator.GameWorld;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.VFX;

namespace Tabletop.GameWorld
{
	public class MiniatureAssembly : MonoBehaviour, IPlayerInputReceiver
	{
		private enum EMiniatureAnimationStatus
		{
			None = 0,
			InitialAnimation = 1,
			PluggingPieces = 2,
			PluggingBase = 3,
			MiniatureTurn = 4,
			CloseupTurning = 5,
			Leaving = 6,
			Finished = 7
		}

		public struct RelativeTransformData
		{
			private readonly Vector3 _localPosition;

			private readonly Quaternion _localRotation;

			private readonly Vector3 _relativeScale;

			public RelativeTransformData(Transform target, Transform reference)
			{
				_localPosition = reference.InverseTransformPoint(target.position);
				_localRotation = Quaternion.Inverse(reference.rotation) * target.rotation;
				Vector3 lossyScale = target.lossyScale;
				Vector3 lossyScale2 = reference.lossyScale;
				_relativeScale = new Vector3(lossyScale.x / lossyScale2.x, lossyScale.y / lossyScale2.y, lossyScale.z / lossyScale2.z);
			}

			public void ApplyTo(Transform target, Transform reference)
			{
				target.position = GetPositionWithReference(reference);
				target.rotation = GetRotationWithReference(reference);
				target.localScale = GetScaleWithReference(target, reference);
			}

			public Vector3 GetScaleWithReference(Transform target, Transform reference)
			{
				Vector3 vector = Vector3.Scale(reference.lossyScale, _relativeScale);
				Vector3 vector2 = ((target.parent != null) ? target.parent.lossyScale : Vector3.one);
				return new Vector3(vector.x / vector2.x, vector.y / vector2.y, vector.z / vector2.z);
			}

			public Quaternion GetRotationWithReference(Transform reference)
			{
				return reference.rotation * _localRotation;
			}

			public Vector3 GetPositionWithReference(Transform reference)
			{
				return reference.TransformPoint(_localPosition);
			}
		}

		[Serializable]
		private struct PieceData
		{
			public enum EPieceDataStatus
			{
				Waiting = 0,
				Moving = 1,
				Stopped = 2
			}

			public Vector3 localPos;

			public Quaternion localRot;

			public Vector3 localScale;

			public Vector3 cachedScale;

			public Quaternion worldRot;

			private Quaternion _lastRotation;

			private VisualEffect _vfx;

			private Material _mat;

			private const string RarityIntNameInVfx = "rarity";

			private int _rarity;

			public Vector3 positionTop;

			public GameObject go;

			public Transform transform;

			public float t;

			public bool needsToBeSkipped;

			public EPieceDataStatus pieceStatus;

			public Vector3 initalAnimationStartPos;

			public float seed;

			public Vector3 localPosNormalizedFromBoundsCenter;

			private const float SpeedBoostOnSkip = 5000f;

			public Quaternion LastRot => _lastRotation;

			public PieceData(GameObject go, Vector3 positionTop, VisualEffect vfx, int rarity, Material matClone)
			{
				_mat = matClone;
				_rarity = rarity;
				_vfx = vfx;
				this.go = go;
				transform = go.transform;
				localPos = transform.localPosition;
				localPosNormalizedFromBoundsCenter = localPos.normalized;
				localRot = transform.localRotation;
				worldRot = transform.rotation;
				localScale = transform.localScale;
				transform.position = localPos;
				this.positionTop = positionTop;
				pieceStatus = EPieceDataStatus.Waiting;
				initalAnimationStartPos = localPos;
				t = 0f;
				seed = UnityEngine.Random.Range(0f, 999f);
				cachedScale = default(Vector3);
				needsToBeSkipped = false;
				_lastRotation = transform.rotation;
			}

			public void PlayVfx()
			{
				_vfx?.SetInt("rarity", _rarity);
				_vfx?.Play();
			}

			public void SetLastRotWithLerp(Quaternion rotation, float lerpSpeed, float deltaTime)
			{
				_lastRotation = Quaternion.Lerp(_lastRotation, rotation, lerpSpeed * deltaTime);
			}

			public void ResetLastRot()
			{
				_lastRotation = transform.transform.rotation;
			}

			public void IncrementTime(float deltaTime, float speed = 1f)
			{
				if (!needsToBeSkipped)
				{
					t += deltaTime / speed;
				}
				else
				{
					t += deltaTime * 5000f;
				}
			}

			public void ResetTime()
			{
				t = 0f;
			}

			public void SetInitialAnimationStartPos(float offset)
			{
				initalAnimationStartPos = positionTop + new Vector3(0f, offset, 0f);
			}
		}

		[Header("References")]
		[SerializeField]
		[ReadOnly(false, false)]
		private MiniatureData m_data;

		[Header("Main Components")]
		[SerializeField]
		private GameObject m_visual;

		[SerializeField]
		private Transform m_piecesRoot;

		[SerializeField]
		private Transform m_baseRoot;

		[SerializeField]
		private CinemachineImpulseSource m_cinemachineImpulseSource;

		[Header("Pieces")]
		[SerializeField]
		private GameObject[] m_pieces;

		[SerializeField]
		private MeshRenderer[] m_renderers;

		[SerializeField]
		private VisualEffect[] m_piecesAssemblyEffects;

		[SerializeField]
		private VisualEffect m_vfxMainPiece;

		[Header("Input hint")]
		private InputHint m_inputHint;

		[Header("Debug")]
		[SerializeField]
		[ReadOnly(false, false)]
		private EMiniatureAnimationStatus m_status;

		[SerializeField]
		[ReadOnly(false, false)]
		private int m_currentAnimatedPiece = -1;

		private Action<int> m_onCompleteAnimation;

		private bool m_clickThisFrame;

		private Vector2 m_mousePosition;

		private IPlayerInputReceiver m_previousInputReceiver;

		private bool m_updateRegistered;

		private const float SpeedBoostOnSkip = 20f;

		private PieceData[] m_pieceInfos;

		private Matrix4x4 m_cameraMatrix;

		private Vector3 m_centerPos;

		private Vector3 m_maxLeftPos;

		private Vector3 m_maxRightPos;

		private float m_seedForMiniatureNoise;

		private Bounds m_bounds;

		private bool m_requestSkipBaseAnim;

		private RelativeTransformData m_relativeTransformData;

		private Vector3 m_relativeDirToBounds;

		private float m_randomNoiseForSpin;

		private Vector3 m_cachedPosPieceTransform;

		private Quaternion m_cachedRotPieceTransform;

		private Quaternion m_randomRotPieceTransform;

		private Vector3 m_cachedScalePieceTransform;

		private Vector3 m_flyMiniatureOutPosition;

		private Vector3 m_flyMiniaturePointB;

		private Vector3 m_movedScalePieceTransform;

		private float m_t;

		private Quaternion m_facingCameraRotation;

		private Quaternion m_piecesRootRotationCached;

		public static event Action PieceAdded;

		public static event Action AssemblyCompleted;

		private void Awake()
		{
			OnAwakeInputHint();
		}

		private void Start()
		{
			OnStartInputHint();
		}

		private void RegisterToUpdate(bool register)
		{
			if (m_updateRegistered != register)
			{
				m_updateRegistered = register;
				Updater.RegisterChannelCallback(register, EUpdateChannel.CLASSIC, OnUpdate);
			}
		}

		public void PlayAssembleAnimation(Action<int> onComplete)
		{
			m_onCompleteAnimation = onComplete;
			IPlayerInputReceiver.HasCurrent(out m_previousInputReceiver);
			IPlayerInputReceiver.SetCurrent(this);
			CameraManager.UpdateFPSCameras = false;
			InitAnim();
			RegisterToUpdate(register: true);
		}

		public void InitAnim()
		{
			m_piecesRoot.gameObject.SetActive(value: true);
			m_baseRoot.gameObject.SetActive(value: false);
			ComputeItemOffsets();
			RecomputeBounds();
			m_facingCameraRotation = Quaternion.LookRotation(m_cameraMatrix.GetColumn(2), m_cameraMatrix.GetColumn(1)) * Quaternion.Euler(0f, 180f, 0f);
			m_mousePosition = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
			m_pieceInfos = new PieceData[m_pieces.Length];
			Material miniaturesUnpaintedMat = PaintingSettings.GetMiniaturesUnpaintedMat(m_data.Rarity);
			for (int i = 0; i < m_pieces.Length; i++)
			{
				float t = (float)i / (float)(m_pieces.Length - 1);
				GameObject gameObject = m_pieces[i];
				m_renderers[i].material = miniaturesUnpaintedMat;
				Material material = m_renderers[i].material;
				VisualEffect vfx = gameObject.GetComponentsInChildren<VisualEffect>(includeInactive: true)[0];
				m_pieceInfos[i] = new PieceData(gameObject, Vector3.Lerp(m_maxLeftPos, m_maxRightPos, t), vfx, m_data.Rarity, material);
				gameObject.transform.SetParent(null);
			}
			m_relativeDirToBounds = m_piecesRoot.InverseTransformPoint(m_bounds.center);
			for (int j = 0; j < m_renderers.Length; j++)
			{
				float magnitude = m_renderers[j].bounds.size.magnitude;
				float num = MiniatureAssemblySettings.TargetSize / magnitude;
				m_renderers[j].transform.localScale *= num;
			}
			for (int k = 0; k < m_pieces.Length; k++)
			{
				m_pieceInfos[k].cachedScale = m_pieceInfos[k].transform.localScale;
			}
			m_piecesRoot.rotation = m_facingCameraRotation;
			m_status = EMiniatureAnimationStatus.InitialAnimation;
			m_t = 0f;
		}

		private void ComputeItemOffsets()
		{
			m_cameraMatrix = TransientManager<CameraManager>.Instance.transform.localToWorldMatrix;
			m_centerPos = m_cameraMatrix.MultiplyPoint(MiniatureAssemblySettings.OffsetFromCamera);
			Vector3 vector = m_cameraMatrix.MultiplyVector(new Vector3(MiniatureAssemblySettings.OffsetItemLeft, 0f, 0f));
			Vector3 vector2 = m_cameraMatrix.MultiplyVector(MiniatureAssemblySettings.ItemOffsetMain);
			m_maxLeftPos = vector2 + m_centerPos + vector;
			m_maxRightPos = vector2 + m_centerPos - vector;
			m_relativeTransformData = new RelativeTransformData(m_baseRoot, m_piecesRoot);
		}

		private void RecomputeBounds()
		{
			m_bounds = default(Bounds);
			for (int i = 0; i < m_pieces.Length; i++)
			{
				if (m_bounds.center == Vector3.zero)
				{
					m_bounds.center = m_renderers[i].bounds.center;
				}
				m_bounds.Encapsulate(m_renderers[i].bounds);
			}
		}

		private void OnUpdate(float deltaTime)
		{
			float smoothDeltaTime = Time.smoothDeltaTime;
			Vector2 mousePosRemaped = VfxStuff.MousePosRemaped(m_mousePosition);
			mousePosRemaped *= MiniatureAssemblySettings.RotationSensivity;
			bool flag = true;
			float time = Time.time;
			switch (m_status)
			{
			case EMiniatureAnimationStatus.None:
				return;
			case EMiniatureAnimationStatus.InitialAnimation:
			{
				for (int i = 0; i < m_pieceInfos.Length; i++)
				{
					PieceData piece = m_pieceInfos[i];
					switch (piece.pieceStatus)
					{
					case PieceData.EPieceDataStatus.Waiting:
						Skip(ref piece);
						Waiting(i, ref piece, MiniatureAssemblySettings.DelayBetweenItemsStartAnimation);
						flag = false;
						break;
					case PieceData.EPieceDataStatus.Moving:
						Skip(ref piece);
						piece.IncrementTime(deltaTime, MiniatureAssemblySettings.ItemsStartAnimationDuration);
						piece.transform.position = SineNoise(piece) + Vector3.Lerp(piece.positionTop + new Vector3(0f, MiniatureAssemblySettings.ItemTopOffsetForStartAnimation, 0f), piece.positionTop, MiniatureAssemblySettings.ItemsStartAnimationCurve.Evaluate(piece.t));
						if (piece.t >= 1f)
						{
							piece.ResetTime();
							piece.pieceStatus = PieceData.EPieceDataStatus.Stopped;
						}
						flag = false;
						ApplyRotation(ref piece);
						break;
					case PieceData.EPieceDataStatus.Stopped:
						piece.transform.position = SineNoise(piece) + piece.positionTop;
						ApplyRotation(ref piece);
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					m_pieceInfos[i] = piece;
				}
				if (flag)
				{
					m_piecesRoot.position = m_cameraMatrix.MultiplyPoint(MiniatureAssemblySettings.OffsetFromCameraMiniature);
					m_seedForMiniatureNoise = UnityEngine.Random.Range(0f, 500f);
					float num = MiniatureAssemblySettings.TargetSizeMiniature / m_bounds.size.magnitude;
					m_piecesRoot.localScale *= num;
					m_cachedScalePieceTransform = m_piecesRoot.localScale;
					m_status = EMiniatureAnimationStatus.PluggingPieces;
					ResetAllPieces();
					m_currentAnimatedPiece = -1;
				}
				break;
			}
			case EMiniatureAnimationStatus.PluggingPieces:
			{
				ApplyRotPiecesTransfrom();
				for (int j = 0; j < m_pieceInfos.Length; j++)
				{
					PieceData piece2 = m_pieceInfos[j];
					switch (piece2.pieceStatus)
					{
					case PieceData.EPieceDataStatus.Waiting:
						Skip(ref piece2);
						Waiting(j, ref piece2, GameplayApplicationOptions.DelayBetweenPiecesPlugIn);
						ApplySine(piece2, piece2.positionTop);
						ApplyRotation(ref piece2);
						flag = false;
						break;
					case PieceData.EPieceDataStatus.Moving:
					{
						Skip(ref piece2);
						piece2.IncrementTime(deltaTime, MiniatureAssemblySettings.ItemsPlugAnimationDuration);
						float t3 = MiniatureAssemblySettings.ItemsPlugAnimationCurveXZ.Evaluate(piece2.t);
						float t4 = MiniatureAssemblySettings.ItemsPlugAnimationCurveY.Evaluate(piece2.t);
						float t5 = MiniatureAssemblySettings.ItemsPlugAnimationBlendPointBC.Evaluate(piece2.t);
						Vector3 vector = m_piecesRoot.TransformPoint(m_relativeDirToBounds);
						Vector3 vector2 = m_piecesRoot.TransformPoint(piece2.localPos);
						Vector3 vector3 = (vector - vector2) * MiniatureAssemblySettings.OffsetFromParentPow + vector2;
						Debug.DrawLine(vector, vector2, Color.green);
						Debug.DrawLine(vector, vector3, Color.yellow);
						Vector3 vector4 = Vector3.Lerp(vector3, vector2, t5);
						Vector3 vector5 = new Vector3(Mathf.LerpUnclamped(piece2.positionTop.x, vector4.x, t3), Mathf.LerpUnclamped(piece2.positionTop.y, vector4.y, t4), Mathf.LerpUnclamped(piece2.positionTop.z, vector4.z, t3));
						piece2.transform.rotation = Quaternion.Lerp(GetRotation(ref piece2), m_piecesRoot.rotation * piece2.localRot, piece2.t);
						Vector3 vector6 = Vector3.Lerp(SineNoise(piece2), Vector3.zero, piece2.t);
						piece2.transform.position = vector5 + vector6;
						piece2.transform.localScale = Vector3.Lerp(piece2.cachedScale, Vector3.Scale(m_piecesRoot.lossyScale, piece2.localScale), MiniatureAssemblySettings.ItemsPlugScaleCurve.Evaluate(piece2.t));
						if (piece2.t >= 1f)
						{
							piece2.ResetTime();
							piece2.pieceStatus = PieceData.EPieceDataStatus.Stopped;
							piece2.transform.rotation = m_piecesRoot.rotation * piece2.localRot;
							piece2.transform.position = vector2;
							piece2.transform.parent = m_piecesRoot;
							piece2.transform.localScale = piece2.localScale;
							m_cinemachineImpulseSource.GenerateImpulseWithForce(MiniatureAssemblySettings.ImpulseForce);
							piece2.PlayVfx();
							MiniatureAssembly.PieceAdded?.Invoke();
							m_movedScalePieceTransform *= MiniatureAssemblySettings.PiecesTransformSquashPower;
						}
						flag = false;
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
					case PieceData.EPieceDataStatus.Stopped:
						break;
					}
					m_pieceInfos[j] = piece2;
				}
				SquashPiecesTransform();
				if (flag)
				{
					m_status = EMiniatureAnimationStatus.PluggingBase;
					m_t = 0f;
					ResetAllPieces();
					m_baseRoot.gameObject.SetActive(value: true);
					MiniatureAssembly.AssemblyCompleted?.Invoke();
					m_baseRoot.position = m_relativeTransformData.GetPositionWithReference(m_piecesRoot) + new Vector3(0f, MiniatureAssemblySettings.BaseTrYoffset, 0f);
					m_baseRoot.localScale = m_relativeTransformData.GetScaleWithReference(m_baseRoot, m_piecesRoot);
					m_baseRoot.rotation = m_relativeTransformData.GetRotationWithReference(m_piecesRoot);
				}
				break;
			}
			case EMiniatureAnimationStatus.PluggingBase:
			{
				if (m_clickThisFrame)
				{
					m_requestSkipBaseAnim = true;
				}
				if (m_requestSkipBaseAnim)
				{
					time = 1f;
				}
				m_t += smoothDeltaTime / (m_requestSkipBaseAnim ? (MiniatureAssemblySettings.BasePlugDuration / 20f) : MiniatureAssemblySettings.BasePlugDuration);
				float t = MiniatureAssemblySettings.BasePlugAnimationCurve.Evaluate(m_t);
				m_piecesRoot.rotation = Quaternion.Lerp(GetRotationPiecesTransform(), m_facingCameraRotation, t);
				SquashPiecesTransform();
				m_baseRoot.localScale = m_relativeTransformData.GetScaleWithReference(m_baseRoot, m_piecesRoot);
				Vector3 positionWithReference = m_relativeTransformData.GetPositionWithReference(m_piecesRoot);
				m_baseRoot.position = Vector3.LerpUnclamped(positionWithReference + new Vector3(0f, MiniatureAssemblySettings.BaseTrYoffset, 0f), positionWithReference, t);
				m_baseRoot.rotation = m_relativeTransformData.GetRotationWithReference(m_piecesRoot);
				if (m_t > 1f)
				{
					m_status = EMiniatureAnimationStatus.MiniatureTurn;
					m_t = 0f;
					m_randomNoiseForSpin = UnityEngine.Random.Range(0.9f, 1.1f);
					ResetAllPieces();
					m_movedScalePieceTransform *= MiniatureAssemblySettings.PiecesTransformSquashPower * 2f;
					m_vfxMainPiece.Play();
					m_piecesRootRotationCached = m_piecesRoot.rotation;
				}
				break;
			}
			case EMiniatureAnimationStatus.MiniatureTurn:
			{
				m_t += smoothDeltaTime / MiniatureAssemblySettings.MiniatureSpinDuration;
				float b2 = m_facingCameraRotation.eulerAngles.y + MiniatureAssemblySettings.MiniatureSpinCount * 360f;
				float t2 = MiniatureAssemblySettings.MiniatureSpinSpeedCurve.Evaluate(m_t);
				float y = Mathf.Lerp(0f, b2, t2);
				m_piecesRoot.rotation = m_piecesRootRotationCached * Quaternion.Euler(0f, y, 0f);
				SquashPiecesTransform();
				m_relativeTransformData.ApplyTo(m_baseRoot, m_piecesRoot);
				if (m_t > 1f)
				{
					m_status = EMiniatureAnimationStatus.CloseupTurning;
					m_cachedPosPieceTransform = m_piecesRoot.position;
					m_cachedRotPieceTransform = m_piecesRoot.rotation;
					m_cachedScalePieceTransform = m_piecesRoot.localScale;
					m_t = 0f;
				}
				break;
			}
			case EMiniatureAnimationStatus.CloseupTurning:
				m_t += smoothDeltaTime / MiniatureAssemblySettings.MiniatureTimeToAllowTurn;
				m_piecesRoot.rotation = Quaternion.Lerp(m_cachedRotPieceTransform, GetRotationPiecesTransform(), m_t);
				m_relativeTransformData.ApplyTo(m_baseRoot, m_piecesRoot);
				SquashPiecesTransform();
				if (m_clickThisFrame)
				{
					m_status = EMiniatureAnimationStatus.Leaving;
					m_cachedPosPieceTransform = m_piecesRoot.position;
					m_cachedRotPieceTransform = m_piecesRoot.rotation;
					m_cachedScalePieceTransform = m_piecesRoot.localScale;
					m_movedScalePieceTransform = m_cachedScalePieceTransform * MiniatureAssemblySettings.PiecesTransformSquashPower;
					m_flyMiniatureOutPosition = m_cameraMatrix.MultiplyPoint(MiniatureAssemblySettings.MiniatureFlyOffset);
					m_flyMiniaturePointB = m_cameraMatrix.MultiplyPoint(MiniatureAssemblySettings.MiniatureFlyPointBoffset);
					m_randomRotPieceTransform = Quaternion.AngleAxis(MiniatureAssemblySettings.FlyRotationPower, UnityEngine.Random.onUnitSphere);
					m_t = 0f;
				}
				break;
			case EMiniatureAnimationStatus.Leaving:
			{
				m_t += smoothDeltaTime / MiniatureAssemblySettings.MiniatureFlyDuration;
				SetSquashVal();
				Vector3 b = Vector3.LerpUnclamped(m_flyMiniaturePointB, m_flyMiniatureOutPosition, MiniatureAssemblySettings.MiniatureFlyCurveoffset.Evaluate(m_t));
				m_piecesRoot.position = Vector3.LerpUnclamped(m_cachedPosPieceTransform, b, MiniatureAssemblySettings.MiniatureFlyCurve.Evaluate(m_t));
				m_piecesRoot.localScale = Vector3.LerpUnclamped(m_movedScalePieceTransform, Vector3.zero, MiniatureAssemblySettings.MiniatureFlyScaleCurve.Evaluate(m_t));
				m_piecesRoot.rotation = Quaternion.Lerp(m_cachedRotPieceTransform, GetRotationPiecesTransform() * m_randomRotPieceTransform, m_t);
				m_relativeTransformData.ApplyTo(m_baseRoot, m_piecesRoot);
				if (m_t > 1f)
				{
					OnCompleteAnimation();
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
			m_clickThisFrame = false;
			void ApplyRotPiecesTransfrom()
			{
				m_piecesRoot.rotation = GetRotationPiecesTransform();
			}
			void ApplyRotation(ref PieceData reference)
			{
				reference.transform.rotation = GetRotation(ref reference);
			}
			void ApplySine(PieceData piece3, Vector3 pos)
			{
				piece3.transform.position = pos + SineNoise(piece3);
			}
			Quaternion GetRotation(ref PieceData reference)
			{
				Quaternion quaternion = RandomNoisePieces(reference.seed);
				Quaternion rotation = reference.worldRot * Quaternion.Euler(mousePosRemaped.x, mousePosRemaped.y, 0f) * quaternion;
				reference.SetLastRotWithLerp(rotation, MiniatureAssemblySettings.RotationLerpSpeed, smoothDeltaTime);
				return reference.LastRot;
			}
			Quaternion GetRotationPiecesTransform()
			{
				Quaternion quaternion = RotationNoiseMiniature();
				Quaternion b3 = m_facingCameraRotation * Quaternion.Euler(0f, mousePosRemaped.y, 0f) * quaternion;
				return Quaternion.Lerp(m_piecesRoot.rotation, b3, MiniatureAssemblySettings.RotationLerpSpeed * smoothDeltaTime);
			}
			Quaternion RandomNoisePieces(float seed)
			{
				return Quaternion.Euler(VfxStuff.NoisedVector(seed, time, MiniatureAssemblySettings.IdleNoiseRotationSpeed, MiniatureAssemblySettings.IdleNoiseRotationPower));
			}
			Quaternion RotationNoiseMiniature()
			{
				return Quaternion.Euler(VfxStuff.NoisedVector(m_seedForMiniatureNoise, time, MiniatureAssemblySettings.IdleNoiseRotationSpeedMiniature, MiniatureAssemblySettings.IdleNoiseRotationPowerMiniature));
			}
			void SetSquashVal()
			{
				m_movedScalePieceTransform = Vector3.Lerp(m_movedScalePieceTransform, m_cachedScalePieceTransform, smoothDeltaTime * MiniatureAssemblySettings.PiecesTransformSquashLerpSpeed);
			}
			Vector3 SineNoise(PieceData pieceData)
			{
				return VfxStuff.SineAlongVector(Vector3.up, pieceData.seed, time, MiniatureAssemblySettings.IdleSineSpeed, MiniatureAssemblySettings.IdleSinePower);
			}
			void Skip(ref PieceData reference)
			{
				if (m_clickThisFrame)
				{
					m_clickThisFrame = false;
					reference.needsToBeSkipped = true;
				}
			}
			void SquashPiecesTransform()
			{
				SetSquashVal();
				m_piecesRoot.localScale = Vector3.Lerp(m_piecesRoot.localScale, m_movedScalePieceTransform, MiniatureAssemblySettings.PiecesTransformSquashLerpSpeed * smoothDeltaTime);
			}
			void Waiting(int num2, ref PieceData reference, float delayBewtween)
			{
				if (reference.t > delayBewtween || reference.needsToBeSkipped || m_currentAnimatedPiece > num2 || m_currentAnimatedPiece == -1)
				{
					reference.pieceStatus = PieceData.EPieceDataStatus.Moving;
					if (!reference.needsToBeSkipped)
					{
						reference.ResetTime();
					}
					m_currentAnimatedPiece = num2;
				}
				else if (m_currentAnimatedPiece == num2 - 1)
				{
					reference.IncrementTime(deltaTime);
				}
			}
		}

		private void OnCompleteAnimation()
		{
			IPlayerInputReceiver.SetCurrent(m_previousInputReceiver);
			CameraManager.UpdateFPSCameras = true;
			RegisterToUpdate(register: false);
			UnityEngine.Object.Destroy(base.gameObject);
			m_onCompleteAnimation?.Invoke(m_data.UID);
		}

		private void CallOnAllPieces(Func<PieceData, PieceData> pieceData)
		{
			for (int i = 0; i < m_pieceInfos.Length; i++)
			{
				PieceData arg = m_pieceInfos[i];
				arg = pieceData(arg);
				m_pieceInfos[i] = arg;
			}
		}

		private void ResetAllPieces(bool skipNotResetting = false)
		{
			m_currentAnimatedPiece = -1;
			CallOnAllPieces(delegate(PieceData data)
			{
				data.ResetTime();
				if (!skipNotResetting)
				{
					data.needsToBeSkipped = false;
				}
				data.pieceStatus = PieceData.EPieceDataStatus.Waiting;
				return data;
			});
		}

		public void OnPlayerInput_Look(Vector2 delta)
		{
			m_mousePosition = new Vector2(Mathf.Clamp(m_mousePosition.x + delta.x, 0f, Screen.width), Mathf.Clamp(m_mousePosition.y + delta.y, 0f, Screen.height));
		}

		public void OnPlayerInput_Move(Vector3 moveInput)
		{
		}

		public void OnPlayerInput_Jump()
		{
		}

		public void OnPlayerInput_Crouch()
		{
		}

		public void OnPlayerInput_NextDayHoldProcessing(HoldInteraction holdInteraction)
		{
		}

		public void OnPlayerInput_NextDayHoldStart()
		{
		}

		public void OnPlayerInput_NextDayHoldStop()
		{
		}

		public void OnPlayerInput_NextDayHoldCancel()
		{
		}

		public void OnPlayerInput_SprintStarted()
		{
		}

		public void OnPlayerInput_SprintEnded()
		{
		}

		public void OnPlayerInput_MainInteractTap(ISensable sensable)
		{
			m_clickThisFrame = true;
		}

		public void OnPlayerInput_MainHoldInteractStart(ISensable sensable)
		{
		}

		public void OnPlayerInput_MainHoldProcessing(HoldInteraction holdInteraction, ISensable sensable)
		{
		}

		public void OnPlayerInput_MainHoldInteractStop(ISensable sensable)
		{
		}

		public void OnPlayerInput_MainHoldInteractCancel(ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondInteractTap(ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldInteractStart(ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldProcessing(HoldInteraction holdInteraction, ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldInteractStop(ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldInteractCancel(ISensable sensable)
		{
		}

		public void OnPlayerInput_ThirdInteractTap(ISensable sensable)
		{
		}

		public void OnPlayerInput_Rotate(float rotateInput)
		{
		}

		public void OnPlayerInput_Pause()
		{
		}

		public void OnLoseReceiver()
		{
		}

		private void OnAwakeInputHint()
		{
			m_inputHint = base.gameObject.AddComponent<InputHint>();
		}

		private void OnStartInputHint()
		{
			m_inputHint.SetDatas(MiniatureAssemblySettings.InputHintData);
			m_inputHint.enabled = true;
		}
	}
}
