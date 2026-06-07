using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ModApi;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class NavSphereScript : MonoBehaviour, INavSphere
	{
		[SerializeField]
		private Transform _cameraRoot;

		[SerializeField]
		private NavSphereDiscScript _discHeading;

		[SerializeField]
		private NavSphereDiscScript _discPitch;

		private FlightSceneScript _flightScene;

		private Func<NavSphereIndicatorType, Vector3d?> _getVectorFunc;

		[SerializeField]
		private Transform _heading;

		private bool _headingLocked;

		private double? _lastPeriapsis;

		private NavSphereIndicatorScript _lockedIndicator;

		private NavSphereIndicatorType? _lockedVector;

		[SerializeField]
		private Transform _maneueverNodeIndicator;

		[SerializeField]
		private Transform _navRoot;

		private ICraftNode _node;

		private IReferenceFrame _referenceFrame;

		private INavSphereTarget _target;

		[SerializeField]
		private Transform _targetIndicator;

		[SerializeField]
		private Transform _tutorialIndicator;

		private Dictionary<NavSphereIndicatorType, Vector3d?> _vectors = new Dictionary<NavSphereIndicatorType, Vector3d?>();

		[SerializeField]
		private Transform _velocityIndicator;

		private double _velocityMagnitude;

		public float Heading
		{
			get
			{
				return _discHeading.Angle;
			}
			private set
			{
				_discHeading.Angle = value;
			}
		}

		public bool HeadingLocked => _headingLocked;

		public NavSphereIndicatorType? LockedIndicator
		{
			get
			{
				return _lockedVector;
			}
			set
			{
				_lockedVector = value;
				if (value.HasValue)
				{
					NavSphereIndicatorScript[] componentsInChildren = GetComponentsInChildren<NavSphereIndicatorScript>(includeInactive: true);
					foreach (NavSphereIndicatorScript navSphereIndicatorScript in componentsInChildren)
					{
						if (navSphereIndicatorScript.IndicatorType == value)
						{
							LockIndicator(navSphereIndicatorScript);
							return;
						}
					}
				}
				LockIndicator(null);
			}
		}

		public Vector3d? ManeuverNodeDirection { get; set; }

		public float Pitch
		{
			get
			{
				return _discPitch.Angle;
			}
			private set
			{
				_discPitch.Angle = value;
			}
		}

		public INavSphereTarget Target
		{
			get
			{
				return _target;
			}
			set
			{
				if (_target != value)
				{
					_target = value;
					if (_target == null && VelocityMode == NavSphereVelocityMode.Target)
					{
						VelocityMode = NavSphereVelocityMode.Orbit;
					}
				}
			}
		}

		public double VelocityMagnitude => _velocityMagnitude;

		public NavSphereVelocityMode VelocityMode { get; set; }

		public static void UpdateVectors(Dictionary<NavSphereIndicatorType, Vector3d?> vectors, NavSphereVelocityMode velocityMode, ICraftNode craftNode, INavSphereTarget target, Vector3d? manuever)
		{
			Vector3d? vector3d;
			if (velocityMode == NavSphereVelocityMode.Target && target != null && target.Parent == craftNode.Parent)
			{
				vector3d = craftNode.Velocity - target.Velocity;
				if (vector3d.Value.sqrMagnitude < 0.009999999776482582)
				{
					vector3d = null;
				}
				vectors[NavSphereIndicatorType.VelocityPrograde] = vector3d;
				vectors[NavSphereIndicatorType.VelocityRetrograde] = -vector3d;
				vectors[NavSphereIndicatorType.RadialIn] = null;
				vectors[NavSphereIndicatorType.RadialOut] = null;
				vectors[NavSphereIndicatorType.Normal] = null;
				vectors[NavSphereIndicatorType.AntiNormal] = null;
				vectors[NavSphereIndicatorType.North] = null;
				vectors[NavSphereIndicatorType.East] = null;
				vectors[NavSphereIndicatorType.South] = null;
				vectors[NavSphereIndicatorType.West] = null;
				vectors[NavSphereIndicatorType.Up] = null;
				vectors[NavSphereIndicatorType.Down] = null;
			}
			else if (velocityMode == NavSphereVelocityMode.Surface)
			{
				vector3d = craftNode.CraftScript.FlightData.SurfaceVelocity;
				if (vector3d.Value.sqrMagnitude < 1.0)
				{
					vector3d = null;
				}
				vectors[NavSphereIndicatorType.VelocityPrograde] = vector3d;
				vectors[NavSphereIndicatorType.VelocityRetrograde] = -vector3d;
				vectors[NavSphereIndicatorType.RadialIn] = null;
				vectors[NavSphereIndicatorType.RadialOut] = null;
				vectors[NavSphereIndicatorType.Normal] = null;
				vectors[NavSphereIndicatorType.AntiNormal] = null;
				Vector3d north = craftNode.CraftScript.FlightData.North;
				vectors[NavSphereIndicatorType.North] = north;
				vectors[NavSphereIndicatorType.South] = -north;
				north = craftNode.CraftScript.FlightData.East;
				vectors[NavSphereIndicatorType.East] = north;
				vectors[NavSphereIndicatorType.West] = -north;
				north = craftNode.CraftScript.FlightData.PositionNormalized + 9.999999747378752E-05 * craftNode.CraftScript.FlightData.East;
				vectors[NavSphereIndicatorType.Up] = north;
				vectors[NavSphereIndicatorType.Down] = -north;
			}
			else
			{
				vector3d = craftNode.Velocity;
				if (vector3d.Value.sqrMagnitude < 0.009999999776482582)
				{
					vector3d = null;
				}
				vectors[NavSphereIndicatorType.VelocityPrograde] = vector3d;
				vectors[NavSphereIndicatorType.VelocityRetrograde] = -vector3d;
				if (vector3d.HasValue)
				{
					Vector3d normalized = craftNode.Orbit.OrbitalPlaneNormal.normalized;
					vectors[NavSphereIndicatorType.Normal] = normalized;
					vectors[NavSphereIndicatorType.AntiNormal] = -normalized;
					vector3d = (vectors[NavSphereIndicatorType.RadialOut] = Vector3d.Cross(normalized, vector3d.Value).normalized);
					vectors[NavSphereIndicatorType.RadialIn] = -vector3d;
				}
				vectors[NavSphereIndicatorType.North] = null;
				vectors[NavSphereIndicatorType.East] = null;
				vectors[NavSphereIndicatorType.South] = null;
				vectors[NavSphereIndicatorType.West] = null;
				vectors[NavSphereIndicatorType.Up] = null;
				vectors[NavSphereIndicatorType.Down] = null;
			}
			vector3d = null;
			if (target != null && !target.IsDestroyed)
			{
				vector3d = ((target.Parent != craftNode.Parent) ? new Vector3d?(target.SolarPosition - craftNode.SolarPosition) : new Vector3d?(target.Position - craftNode.Position));
			}
			vectors[NavSphereIndicatorType.Target] = vector3d;
			vectors[NavSphereIndicatorType.AntiTarget] = -vector3d;
			vectors[NavSphereIndicatorType.ManeuverNode] = manuever?.normalized;
		}

		public void EnableTutorialIndicator(bool enabled, float angle)
		{
			_tutorialIndicator.gameObject.SetActive(enabled);
			_tutorialIndicator.localRotation = Quaternion.Euler(angle, 0f, 0f);
		}

		public Vector3d? GetVector(NavSphereIndicatorType vector)
		{
			if (!_vectors.TryGetValue(vector, out var value))
			{
				value = null;
			}
			return value;
		}

		public Func<NavSphereIndicatorType, Vector3d?> GetVectorFunc()
		{
			return _getVectorFunc ?? (_getVectorFunc = GetVector);
		}

		public void Initialize(ICraftNode node, IReferenceFrame referenceFrame)
		{
			_node = node;
			_referenceFrame = referenceFrame;
			_flightScene = FlightSceneScript.Instance;
			_flightScene.CraftChanged += OnPlayerCraftNodeChanged;
		}

		public void LockCraftHeading(Vector3d headingDirection, ICraftNode craft)
		{
			Vector3 p = _navRoot.InverseTransformDirection(headingDirection.ToVector3());
			LockLocalPoint(p, 0f, craft);
		}

		public void LockCurrentHeading()
		{
			LockIndicator(null);
			_lockedIndicator = null;
			_lockedVector = null;
			Vector3d headingDirection = _node.ReferenceFrame.FrameToPlanetVector(_node.CraftScript.CenterOfMass.transform.forward);
			LockHeading(headingDirection);
		}

		public void LockHeading(float pitch, float heading, ICraftNode craft = null)
		{
			if (craft == null)
			{
				craft = _node;
				_headingLocked = true;
				Pitch = Utilities.LimitAngle180(pitch);
				Heading = Utilities.LimitAngle180(heading);
				_discHeading.Flipped = Mathf.Abs(Pitch) > 91f;
			}
			Quaternion q = _navRoot.localRotation * Quaternion.Euler(0f, 0f, heading) * Quaternion.Euler(pitch, 0f, 0f);
			craft.Controls.TargetHeading = Quaterniond.FromQuaternion(q);
		}

		public void LockHeading(Vector3d headingDirection)
		{
			Vector3 p = _navRoot.InverseTransformDirection(headingDirection.ToVector3());
			LockLocalPoint(p, 0f);
		}

		public void ToggleLock(NavSphereIndicatorType mode)
		{
			string text = Regex.Replace(mode.ToString(), "([a-z])([A-Z])", "$1 $2");
			if (LockedIndicator != mode)
			{
				LockedIndicator = mode;
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Locked " + text);
			}
			else
			{
				UnlockHeading();
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Unlocked " + text);
			}
		}

		public void ToggleProgradeLock()
		{
			if (LockedIndicator != NavSphereIndicatorType.VelocityPrograde)
			{
				LockedIndicator = NavSphereIndicatorType.VelocityPrograde;
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Locked Velocity Prograde");
			}
			else
			{
				UnlockHeading();
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Unlocked Velocity Prograde");
			}
		}

		public void ToggleRetrogradeLock()
		{
			if (LockedIndicator != NavSphereIndicatorType.VelocityRetrograde)
			{
				LockedIndicator = NavSphereIndicatorType.VelocityRetrograde;
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Locked Velocity Retrograde");
			}
			else
			{
				UnlockHeading();
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Unlocked Velocity Retrograde");
			}
		}

		public void ToggleTargetLock()
		{
			if (Target != null)
			{
				if (LockedIndicator != NavSphereIndicatorType.Target)
				{
					LockedIndicator = NavSphereIndicatorType.Target;
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Locked Target");
				}
				else
				{
					UnlockHeading();
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Unlocked Target");
				}
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("No target is selected in Map View");
			}
		}

		public void UnlockCraftHeading(ICraftNode craft)
		{
			craft.Controls.TargetHeading = null;
		}

		public void UnlockHeading()
		{
			_headingLocked = false;
			LockedIndicator = null;
			_node.Controls.TargetHeading = null;
		}

		protected virtual void Awake()
		{
			VelocityMode = NavSphereVelocityMode.Surface;
			Pitch = 90f;
			Heading = 90f;
		}

		protected virtual void Update()
		{
			if (_node == null)
			{
				return;
			}
			UpdateVectors(_vectors, VelocityMode, _node, _target, ManeuverNodeDirection);
			double periapsisDistance = _node.Orbit.PeriapsisDistance;
			if (_lastPeriapsis.HasValue)
			{
				double radius = _node.Parent.PlanetData.Radius;
				if (periapsisDistance > radius && _lastPeriapsis < radius && VelocityMode == NavSphereVelocityMode.Surface)
				{
					VelocityMode = NavSphereVelocityMode.Orbit;
				}
				radius *= 0.95;
				if (periapsisDistance < radius * 0.95 && _lastPeriapsis > radius * 0.95 && _node.Orbit.OrbitType == OrbitType.Elliptical && VelocityMode == NavSphereVelocityMode.Orbit)
				{
					VelocityMode = NavSphereVelocityMode.Surface;
				}
			}
			_lastPeriapsis = periapsisDistance;
			_velocityMagnitude = GetVector(NavSphereIndicatorType.VelocityPrograde)?.magnitude ?? 0.0;
			ICraftFlightData flightData = _node.CraftScript.FlightData;
			Vector3 forward = flightData.PositionNormalized.ToVector3();
			_navRoot.localRotation = Quaternion.LookRotation(forward, flightData.North.ToVector3());
			_heading.localRotation = _node.Heading.ToQuaternion();
			Vector3d? vector = GetVector(NavSphereIndicatorType.VelocityPrograde);
			if (_velocityIndicator.gameObject.activeSelf != vector.HasValue)
			{
				_velocityIndicator.gameObject.SetActive(vector.HasValue);
				if (!vector.HasValue && LockedIndicator == NavSphereIndicatorType.VelocityRetrograde)
				{
					LockCurrentHeading();
				}
			}
			if (vector.HasValue)
			{
				_velocityIndicator.localRotation = Quaternion.FromToRotation(Vector3.up, vector.Value.ToVector3());
			}
			vector = GetVector(NavSphereIndicatorType.Target);
			_targetIndicator.gameObject.SetActive(vector.HasValue);
			if (vector.HasValue)
			{
				_targetIndicator.localRotation = Quaternion.FromToRotation(Vector3.up, vector.Value.ToVector3());
			}
			if (ManeuverNodeDirection.HasValue)
			{
				_maneueverNodeIndicator.gameObject.SetActive(value: true);
				_maneueverNodeIndicator.localRotation = Quaternion.FromToRotation(Vector3.up, ManeuverNodeDirection.Value.ToVector3());
			}
			else
			{
				_maneueverNodeIndicator.gameObject.SetActive(value: false);
			}
			Quaternion localRotation;
			if (_flightScene.ViewManager.GameView.RenderView)
			{
				Transform transform = _flightScene.ViewManager.GameView.GameCamera.Transform;
				localRotation = _referenceFrame.FrameToPlanetRotation(transform.rotation).ToQuaternion();
			}
			else
			{
				localRotation = _flightScene.ViewManager.MapViewManager.MapViewCamera.transform.rotation;
			}
			_cameraRoot.localRotation = localRotation;
			float timeStep = Time.unscaledDeltaTime;
			if (_flightScene.TimeManager.CurrentMode.WarpMode)
			{
				timeStep = 0f;
			}
			UpdateIndicatorLock(timeStep);
			AnimateTutorialIndicator();
		}

		private void AnimateTutorialIndicator()
		{
			if (_tutorialIndicator.gameObject.activeSelf)
			{
				MeshRenderer componentInChildren = _tutorialIndicator.GetComponentInChildren<MeshRenderer>();
				if (componentInChildren != null)
				{
					Color color = componentInChildren.material.color;
					float t = (Mathf.Sin(Time.unscaledTime * 6f) + 1f) * 0.5f;
					componentInChildren.material.color = color;
					componentInChildren.material.SetFloat("_Opacity", Mathf.Lerp(0.4f, 1f, t));
				}
			}
		}

		private void LockIndicator(NavSphereIndicatorScript indicator)
		{
			if (_lockedIndicator != null)
			{
				_lockedIndicator.Selected = false;
			}
			_lockedIndicator = indicator;
			if (_lockedIndicator != null)
			{
				_lockedIndicator.Selected = true;
			}
		}

		private void LockLocalPoint(Vector3 p, float stepScale, ICraftNode craft = null)
		{
			float num = Mathf.Atan2(p.z, Mathf.Sqrt(p.x * p.x + p.y * p.y)) * 57.29578f;
			float num2 = Mathf.Atan2(0f - p.x, p.y) * 57.29578f;
			if (stepScale > 0f)
			{
				float pitch = Pitch;
				float heading = Heading;
				float num3 = Utilities.LimitAngle180(num - pitch);
				pitch += num3 * stepScale;
				float num4 = Utilities.LimitAngle180(num2 - heading);
				heading += num4 * stepScale;
				LockHeading(pitch, heading, craft);
			}
			else
			{
				if (num > 85f)
				{
					num2 = Heading;
				}
				LockHeading(num, num2, craft);
			}
		}

		private void OnPlayerCraftNodeChanged(ICraftNode craftNode)
		{
			_node = craftNode;
			_lastPeriapsis = null;
			if (_node.Controls.TargetHeading.HasValue)
			{
				LockHeading(_node.Controls.TargetHeading.Value * Vector3.up);
			}
			else
			{
				UnlockHeading();
			}
		}

		private void UpdateIndicatorLock(float timeStep)
		{
			if (_lockedVector.HasValue)
			{
				Vector3d? vector = GetVector(_lockedVector.Value);
				if (vector.HasValue)
				{
					Vector3 normalized = _navRoot.InverseTransformDirection(vector.Value.ToVector3()).normalized;
					LockLocalPoint(normalized, timeStep * 5f);
				}
			}
		}
	}
}
