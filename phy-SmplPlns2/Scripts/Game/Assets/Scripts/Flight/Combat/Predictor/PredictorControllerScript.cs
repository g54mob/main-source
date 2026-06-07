using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight.UI.Targeting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public abstract class PredictorControllerScript : MonoBehaviour
	{
		[SerializeField]
		protected Camera _mainCamera;

		[SerializeField]
		private DecalProjector _aimProjector;

		private AirPredictor _airPredictor;

		private BombEntity _bombEntity = new BombEntity();

		private GroundPredictor _bombPredictor;

		private CannonEntity _cannonEntity = new CannonEntity();

		[SerializeField]
		private LayerMask _layerMask = 9437201;

		[SerializeField]
		private LineRenderer _lineRenderer;

		[SerializeField]
		private TargetingScript _targetingScript;

		[SerializeField]
		private DecalProjector _targetProjector;

		public Vector3? AimIndicatorPos { get; set; }

		public int? AimProjectorLayer { get; set; }

		public Vector3? AimProjectorPos { get; set; }

		public Vector3? GunAimReticlePos { get; set; }

		public bool LineEnabled { get; set; }

		public Vector3? TargetIndicatorPos { get; set; }

		public int? TargetProjectorLayer { get; set; }

		public Vector3? TargetProjectorPos { get; set; }

		protected abstract MonoBehaviour AimReticle { get; }

		protected abstract MonoBehaviour GunReticle { get; }

		protected abstract MonoBehaviour TargetReticle { get; }

		public PredictorEntity GetEntityForCurrentWeapon()
		{
			WeaponSystem weaponSystem = FlightSceneScript.Instance.LocalPlayer?.Aircraft?.TargetingSystem.SelectedWeaponSystem;
			if (weaponSystem is BombWeaponSystem)
			{
				foreach (WeaponPart weapon in weaponSystem.Weapons)
				{
					if (weapon.IsActive && weapon.Weapon.CurrentAmmo > 0)
					{
						BombScript modifier = weapon.Part.GetModifier<BombScript>();
						if (modifier != null && !modifier.Modifier.IsLaserGuided)
						{
							_bombEntity.ResetSim(modifier);
							return _bombEntity;
						}
					}
				}
			}
			else if (weaponSystem is CannonWeaponSystem cannonWeaponSystem)
			{
				CannonScript cannonScript = cannonWeaponSystem.NextToFire?.Part.GetModifier<CannonScript>();
				if (cannonScript != null)
				{
					_cannonEntity.ResetSim(cannonScript);
					return _cannonEntity;
				}
			}
			return null;
		}

		protected virtual void Awake()
		{
		}

		protected virtual Quaternion GetRotation(Vector3 forward)
		{
			return Quaternion.identity;
		}

		protected abstract Vector3 GetScreenPos(Vector3 worldPos, out bool shouldDisplay);

		protected abstract Vector3 GetWorldPoint(Vector3 screenPos);

		protected void InitializePredictors(TargetingScript targetingScript)
		{
			_targetingScript = targetingScript;
			_airPredictor = new AirPredictor
			{
				TargetingScript = _targetingScript,
				Controller = this
			};
			_bombPredictor = new GroundPredictor
			{
				TargetingScript = _targetingScript,
				LineRenderer = _lineRenderer,
				LayerMask = _layerMask,
				Controller = this
			};
		}

		protected abstract void SetReticleColor(MonoBehaviour reticle, Color color);

		protected virtual void Start()
		{
			InitializePredictors(_targetingScript);
		}

		protected virtual void Update()
		{
			ClearStates();
			if (!PauseManager.Paused)
			{
				switch (_targetingScript.Aircraft?.TargetingSystem.Mode ?? TargetingSystem.TargetingSystemMode.Off)
				{
				case TargetingSystem.TargetingSystemMode.AirToAir:
					_airPredictor.Update();
					break;
				case TargetingSystem.TargetingSystemMode.AirToGround:
					_bombPredictor.Update();
					break;
				}
			}
			PositionReticle(AimReticle, AimIndicatorPos);
			PositionReticle(TargetReticle, TargetIndicatorPos);
			PositionReticle(GunReticle, GunAimReticlePos, new Color(0f, 1f, 0.129f));
			PositionProjector(_aimProjector, AimProjectorPos, AimProjectorLayer);
			PositionProjector(_targetProjector, TargetProjectorPos, TargetProjectorLayer);
			_lineRenderer.enabled = LineEnabled;
			if (_aimProjector.enabled)
			{
				float magnitude = (Camera.main.transform.position - _aimProjector.transform.position).magnitude;
				_aimProjector.size = new Vector3(magnitude * 0.1f, magnitude * 0.1f, 500f);
				AnimationCurve widthCurve = _lineRenderer.widthCurve;
				Keyframe key = widthCurve.keys[1];
				key.value = Mathf.Lerp(0.1f, 2f, magnitude / 500f);
				widthCurve.MoveKey(1, key);
				_lineRenderer.widthCurve = widthCurve;
			}
			if (_targetProjector.enabled)
			{
				float magnitude2 = (Camera.main.transform.position - _targetProjector.transform.position).magnitude;
				_targetProjector.size = new Vector3(magnitude2 * 0.07f, magnitude2 * 0.07f, 500f);
			}
		}

		private void ClearStates()
		{
			AimIndicatorPos = null;
			TargetIndicatorPos = null;
			AimProjectorPos = null;
			AimProjectorLayer = null;
			TargetProjectorPos = null;
			TargetProjectorLayer = null;
			LineEnabled = false;
			GunAimReticlePos = null;
		}

		private bool IsPositionOccluded(Vector3 worldPos)
		{
			Vector3 direction = Camera.main.transform.position - worldPos;
			return Physics.Raycast(worldPos, direction, direction.magnitude, _layerMask, QueryTriggerInteraction.Ignore);
		}

		private int LayerMaskExcluding(int layer)
		{
			layer = 1 << layer;
			return -1 - layer;
		}

		private void PositionProjector(DecalProjector projector, Vector3? pos, int? layer)
		{
			if (pos.HasValue)
			{
				projector.transform.position = pos.Value;
				projector.transform.forward = Vector3.down;
				projector.enabled = true;
			}
			else
			{
				projector.enabled = false;
			}
		}

		private void PositionReticle(MonoBehaviour reticle, Vector3? hitPos, Color? baseColor = null)
		{
			Color color = baseColor ?? Color.white;
			if (!hitPos.HasValue)
			{
				reticle.gameObject.SetActive(value: false);
				return;
			}
			bool shouldDisplay;
			Vector3 screenPos = GetScreenPos(hitPos.Value, out shouldDisplay);
			if (shouldDisplay)
			{
				screenPos.z = 0f;
				Vector3 worldPoint = GetWorldPoint(screenPos);
				reticle.transform.SetPositionAndRotation(worldPoint, GetRotation(hitPos.Value - _mainCamera.transform.position));
				SetReticleColor(reticle, IsPositionOccluded(hitPos.Value) ? (color * new Color(0.6f, 0.6f, 0.6f)) : color);
				reticle.gameObject.SetActive(value: true);
			}
			else
			{
				reticle.gameObject.SetActive(value: false);
			}
		}
	}
}
