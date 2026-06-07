using System;
using ModApi.Common.Attributes;
using ModApi.Common.Extensions;
using ModApi.Flight.Sim;
using ModApi.Input;
using ModApi.Planet;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.PlanetStudio
{
	public class MovementScript : MonoBehaviour
	{
		private enum PlanetStudioMovementMode
		{
			[DisplayName("Move Camera")]
			MoveCamera = 0,
			[DisplayName("Rotate Camera")]
			RotateCamera = 1,
			[DisplayName("Rotate Planet")]
			RotatePlanet = 2
		}

		private const float AnimationDuration = 2f;

		private Action _animationCompleteCallback;

		private Vector3 _animationEnd;

		private Vector3 _animationLook;

		private Vector3 _animationStart;

		private float _animationTime;

		private bool _cameraLookLeftRightRollSwapped;

		private Vector3d? _focusTarget;

		private PlanetStudioMovementMode _movementMode;

		[SerializeField]
		private float _speedMultiplier = 1f;

		[SerializeField]
		private float _speedMultiplierRotations = 1f;

		private CelestialBodyViewerScript _viewer;

		public Vector3d FocusTargetPci
		{
			get
			{
				if (_focusTarget.HasValue)
				{
					return _viewer.PlanetScript.PlanetNode.SurfaceVectorToPlanetVector(_focusTarget.Value);
				}
				return Vector3d.zero;
			}
		}

		public bool HasFocusTarget => _focusTarget.HasValue;

		public bool IsAnimating => _animationTime > 0f;

		public double PlanetRotation { get; private set; }

		public IQuadSphere QuadSphere { get; set; }

		public bool RotateCameraWithPlanet { get; private set; }

		public bool SnapToGround { get; set; }

		public float SpeedMultiplier
		{
			get
			{
				return _speedMultiplier;
			}
			set
			{
				_speedMultiplier = value;
			}
		}

		public float SpeedMultiplierRotations
		{
			get
			{
				return _speedMultiplierRotations;
			}
			set
			{
				_speedMultiplierRotations = value;
			}
		}

		public float SunTiltAngle { get; private set; }

		private Vector3d PlanetPosition
		{
			get
			{
				return _viewer.ReferenceFrame.FrameToPlanetPosition(base.transform.position);
			}
			set
			{
				base.transform.position = _viewer.ReferenceFrame.PlanetToFramePosition(value);
			}
		}

		public event EventHandler PlanetRotated;

		public void AnimateToPlanetPosition(Vector3d position, Vector3d focusTarget, float animationTime = 2f, Action animationCompleteCallback = null)
		{
			_animationTime = animationTime;
			_animationEnd = _viewer.ReferenceFrame.PlanetToFramePosition(position) - QuadSphere.Transform.position;
			_animationStart = base.transform.position - QuadSphere.Transform.position;
			SetFocusTarget(focusTarget);
			_animationCompleteCallback = animationCompleteCallback;
		}

		public void AnimateToSurfacePosition(double latitude, double longitude, AltitudeType altitudeType, double altitude, double cameraDistance, Action animationCompleteCallback = null)
		{
			IPlanetNode planetNode = _viewer.PlanetScript.PlanetNode;
			Vector3d surfacePosition = planetNode.GetSurfacePosition(latitude, longitude, altitudeType, altitude);
			Vector3d focusTarget = planetNode.SurfaceVectorToPlanetVector(surfacePosition);
			Vector3d position = focusTarget.normalized * (focusTarget.magnitude + cameraDistance);
			AnimateToPlanetPosition(position, focusTarget, 2f, animationCompleteCallback);
		}

		public void Drag(PointerEventData eventData)
		{
			Vector2 delta = eventData.delta;
			if (_focusTarget.HasValue)
			{
				Vector3d vector3d = PlanetPosition - FocusTargetPci;
				Vector3d vector3d2 = _viewer.ReferenceFrame.FrameToPlanetVector(base.transform.right);
				if (eventData.button == PointerEventData.InputButton.Left)
				{
					float num = 0.5f;
					Vector3d normalized = FocusTargetPci.normalized;
					float a = 0f - delta.y;
					float b = Vector3.Angle(normalized.ToVector3(), -base.transform.forward) * 0.5f;
					Vector3d planetPosition = Quaterniond.AngleAxis(Mathf.Min(a, b) * num, vector3d2) * Quaterniond.AngleAxis(delta.x * num, normalized) * vector3d + FocusTargetPci;
					PlanetPosition = planetPosition;
					Vector3 worldPosition = _viewer.ReferenceFrame.PlanetToFramePosition(FocusTargetPci);
					Vector3 worldUp = _viewer.ReferenceFrame.PlanetToFrameVector(FocusTargetPci.normalized);
					base.transform.LookAt(worldPosition, worldUp);
				}
				else if (eventData.button == PointerEventData.InputButton.Right)
				{
					Vector3d vector3d3 = _viewer.ReferenceFrame.FrameToPlanetVector(base.transform.up);
					double num2 = vector3d.magnitude * 0.002;
					Vector3d vector3d4 = (vector3d2 * (0f - eventData.delta.x) + vector3d3 * (0f - eventData.delta.y)) * num2;
					PlanetPosition += vector3d4;
					SetFocusTarget(FocusTargetPci + vector3d4);
				}
			}
			else
			{
				SetFocusTarget(null);
				base.transform.Rotate(base.transform.up, delta.x, Space.World);
				base.transform.Rotate(base.transform.right, 0f - delta.y, Space.World);
			}
		}

		public void Focus(Vector3d target)
		{
			AnimateToPlanetPosition(PlanetPosition, target, 0.5f);
		}

		public void Initialize(CelestialBodyViewerScript viewer)
		{
			_viewer = viewer;
		}

		public void OnQuadSphereLoaded(IQuadSphere quadSphere)
		{
			QuadSphere = quadSphere;
		}

		public void OnQuadSphereUnloaded()
		{
			QuadSphere = null;
		}

		public void OnViewReset()
		{
			SnapToGround = false;
			SunTiltAngle = 0f;
			PlanetRotation = 0.0;
			base.transform.localPosition = Vector3.zero;
			base.transform.rotation = _viewer.ReferenceFrame.PlanetToFrameRotation(Quaterniond.Euler(0.0, 90.0, 0.0));
			_focusTarget = null;
			_animationTime = 0f;
		}

		public void UpdateMovement()
		{
			if (Game.Instance.UserInterface.IgnoreKeyboardInputs)
			{
				return;
			}
			if (IsAnimating)
			{
				if (UpdateAnimation())
				{
					_animationCompleteCallback?.Invoke();
				}
				_animationCompleteCallback = null;
				return;
			}
			IGameInputs inputs = Game.Instance.Inputs;
			int num = (inputs.PlanetStudioMovementModeNext.GetButtonDown() ? 1 : (inputs.PlanetStudioMovementModePrevious.GetButtonDown() ? (-1) : 0));
			if (num != 0)
			{
				switch (_movementMode)
				{
				case PlanetStudioMovementMode.MoveCamera:
					_movementMode = ((num > 0) ? PlanetStudioMovementMode.RotateCamera : PlanetStudioMovementMode.RotatePlanet);
					break;
				case PlanetStudioMovementMode.RotateCamera:
					_movementMode = ((num > 0) ? PlanetStudioMovementMode.RotatePlanet : PlanetStudioMovementMode.MoveCamera);
					break;
				case PlanetStudioMovementMode.RotatePlanet:
					_movementMode = ((num <= 0) ? PlanetStudioMovementMode.RotateCamera : PlanetStudioMovementMode.MoveCamera);
					break;
				default:
					throw new NotSupportedException();
				}
				PlanetStudioScript.Instance.PlanetStudioUI.ShowMessage("Movement mode changed: " + _movementMode.DisplayName());
			}
			float axis = inputs.AccelerateMovementModifier.GetAxis();
			float axis2 = inputs.DecelerateMovementModifier.GetAxis();
			bool flag = axis != 0f;
			bool flag2 = axis2 != 0f;
			if (inputs.IncreaseSpeed.GetButtonDown())
			{
				_speedMultiplier *= 2f;
			}
			else if (inputs.DecreaseSpeed.GetButtonDown())
			{
				_speedMultiplier *= 0.5f;
			}
			if (inputs.IncreaseRotationalSpeed.GetButtonDown())
			{
				_speedMultiplierRotations *= 2f;
			}
			else if (inputs.DecreaseRotationalSpeed.GetButtonDown())
			{
				_speedMultiplierRotations *= 0.5f;
			}
			float num2 = 5000f * _speedMultiplier * Time.deltaTime;
			if (flag)
			{
				num2 *= Mathf.Lerp(1f, 20f, axis * axis);
			}
			else if (flag2)
			{
				num2 /= Mathf.Lerp(1f, 20f, axis2 * axis2);
			}
			if (inputs.CameraSwapLeftRightRoll.GetButtonDown())
			{
				_cameraLookLeftRightRollSwapped = !_cameraLookLeftRightRollSwapped;
				PlanetStudioScript.Instance.PlanetStudioUI.ShowMessage("Camera look left/right and roll swapped.");
			}
			float axis3 = inputs.CameraLookUpDown.GetAxis();
			float num3 = (_cameraLookLeftRightRollSwapped ? inputs.CameraRollLeftRight.GetAxis() : inputs.CameraLookLeftRight.GetAxis());
			float num4 = (_cameraLookLeftRightRollSwapped ? inputs.CameraLookLeftRight.GetAxis() : inputs.CameraRollLeftRight.GetAxis());
			if (axis3 != 0f)
			{
				base.transform.Rotate(base.transform.right, 0f - axis3, Space.World);
			}
			if (num3 != 0f)
			{
				base.transform.Rotate(base.transform.up, num3, Space.World);
			}
			if (num4 != 0f)
			{
				base.transform.Rotate(base.transform.forward, 0f - num4, Space.World);
			}
			bool flag3 = false;
			float axis4 = inputs.MoveCameraForward.GetAxis();
			float axis5 = inputs.MoveCameraBackward.GetAxis();
			float axis6 = inputs.MoveCameraLeft.GetAxis();
			float axis7 = inputs.MoveCameraRight.GetAxis();
			float axis8 = inputs.MoveCameraUp.GetAxis();
			float axis9 = inputs.MoveCameraDown.GetAxis();
			if (_movementMode == PlanetStudioMovementMode.MoveCamera)
			{
				if (axis4 != 0f)
				{
					base.transform.position += base.transform.forward * axis4 * num2;
					flag3 = true;
				}
				if (axis5 != 0f)
				{
					base.transform.position -= base.transform.forward * axis5 * num2;
					flag3 = true;
				}
				if (axis6 != 0f)
				{
					base.transform.position -= base.transform.right * axis6 * num2;
					flag3 = true;
				}
				if (axis7 != 0f)
				{
					base.transform.position += base.transform.right * axis7 * num2;
					flag3 = true;
				}
			}
			if (inputs.SnapToGround.GetButtonDown())
			{
				SnapToGround = !SnapToGround;
				flag3 = true;
			}
			if (QuadSphere != null)
			{
				Vector3 position = QuadSphere.Transform.position;
				float num5 = 5f * Time.deltaTime * _speedMultiplierRotations;
				if (flag)
				{
					num5 *= 10f;
				}
				else if (flag2)
				{
					num5 /= 10f;
				}
				if (_movementMode == PlanetStudioMovementMode.MoveCamera)
				{
					if (axis9 != 0f)
					{
						base.transform.position -= (base.transform.position - position).normalized * axis9 * num2;
						flag3 = true;
					}
					if (axis8 != 0f)
					{
						base.transform.position += (base.transform.position - position).normalized * axis8 * num2;
						flag3 = true;
					}
				}
				float num6 = inputs.RotateCameraDown.GetAxis();
				float num7 = inputs.RotateCameraUp.GetAxis();
				float num8 = inputs.RotateCameraLeft.GetAxis();
				float num9 = inputs.RotateCameraRight.GetAxis();
				float num10 = inputs.RollCameraLeft.GetAxis();
				float num11 = inputs.RollCameraRight.GetAxis();
				if (_movementMode == PlanetStudioMovementMode.RotateCamera)
				{
					num6 += axis5;
					num7 += axis4;
					num8 += axis6;
					num9 += axis7;
					num10 += axis9;
					num11 += axis8;
				}
				if (num6 != 0f)
				{
					base.transform.RotateAround(position, base.transform.right, (0f - num5) * num6);
					flag3 = true;
				}
				if (num7 != 0f)
				{
					base.transform.RotateAround(position, base.transform.right, num5 * num7);
					flag3 = true;
				}
				if (num8 != 0f)
				{
					base.transform.RotateAround(position, base.transform.up, num5 * num8);
					flag3 = true;
				}
				if (num9 != 0f)
				{
					base.transform.RotateAround(position, base.transform.up, (0f - num5) * num9);
					flag3 = true;
				}
				if (num10 != 0f)
				{
					base.transform.RotateAround(position, base.transform.forward, num5 * num10);
					flag3 = true;
				}
				if (num11 != 0f)
				{
					base.transform.RotateAround(position, base.transform.forward, (0f - num5) * num11);
					flag3 = true;
				}
				IPlanetData planetData = QuadSphere.PlanetData;
				double num12 = ((planetData.AngularVelocity == 0.0) ? 0.0001 : planetData.AngularVelocity);
				double num13 = Math.PI * 2.0 / num12 / 10.0 * (double)Time.deltaTime;
				num13 *= (double)_speedMultiplierRotations;
				if (flag)
				{
					num13 *= 4.0;
				}
				else if (flag2)
				{
					num13 /= 4.0;
				}
				float num14 = inputs.RotateWithPlanetRight.GetAxis();
				float num15 = inputs.RotateWithPlanetLeft.GetAxis();
				float num16 = inputs.RotatePlanetRight.GetAxis();
				float num17 = inputs.RotatePlanetLeft.GetAxis();
				float num18 = inputs.TiltSunDown.GetAxis();
				float num19 = inputs.TiltSunUp.GetAxis();
				if (_movementMode == PlanetStudioMovementMode.RotatePlanet)
				{
					num14 += axis8;
					num15 += axis9;
					num16 += axis7;
					num17 += axis6;
					num18 += axis4;
					num19 += axis5;
				}
				PlanetRotation = 0.0;
				if (num14 != 0f)
				{
					PlanetRotation = (0.0 - num13) * (double)num14;
					RotateCameraWithPlanet = true;
				}
				else if (num15 != 0f)
				{
					PlanetRotation = num13 * (double)num15;
					RotateCameraWithPlanet = true;
				}
				else if (num16 != 0f)
				{
					PlanetRotation = (0.0 - num13) * (double)num16;
					RotateCameraWithPlanet = false;
					flag3 = true;
				}
				else if (num17 != 0f)
				{
					PlanetRotation = num13 * (double)num17;
					RotateCameraWithPlanet = false;
					flag3 = true;
				}
				if (PlanetRotation != 0.0)
				{
					this.PlanetRotated?.Invoke(this, new EventArgs());
				}
				float num20 = 45f * Time.deltaTime * _speedMultiplierRotations;
				if (flag)
				{
					num20 *= 2f;
				}
				else if (flag2)
				{
					num20 /= 2f;
				}
				if (num18 != 0f)
				{
					SunTiltAngle += num20 * num18;
					flag3 = true;
				}
				if (num19 != 0f)
				{
					SunTiltAngle -= num20 * num19;
					flag3 = true;
				}
				SunTiltAngle = (inputs.ResetSunTiltAngle.GetButton() ? 0f : Mathf.Clamp(SunTiltAngle, -90f, 90f));
			}
			if (flag3)
			{
				_focusTarget = null;
				_animationTime = 0f;
			}
		}

		public bool Zoom(double zoomPercentage)
		{
			if (!IsAnimating && _focusTarget.HasValue)
			{
				Vector3d vector3d = PlanetPosition - FocusTargetPci;
				double value = vector3d.magnitude * zoomPercentage;
				value = Mathd.Clamp(value, 10.0, 10000000000.0);
				PlanetPosition = FocusTargetPci + value * vector3d.normalized;
				return true;
			}
			return false;
		}

		protected virtual void OnDestroy()
		{
			this.PlanetRotated = null;
		}

		private void SetFocusTarget(Vector3d? planetPosition)
		{
			if (planetPosition.HasValue)
			{
				_focusTarget = _viewer.PlanetScript.PlanetNode.PlanetVectorToSurfaceVector(planetPosition.Value);
			}
			else
			{
				_focusTarget = null;
			}
		}

		private bool UpdateAnimation()
		{
			bool result = false;
			_animationTime -= Time.deltaTime;
			if (_animationTime < 0f)
			{
				_animationTime = 0f;
				result = true;
			}
			float num = Mathf.InverseLerp(2f, 0f, _animationTime);
			float num2 = Mathf.Lerp(0f, _animationEnd.magnitude - _animationStart.magnitude, num);
			Quaternion b = Quaternion.FromToRotation(_animationStart, _animationEnd);
			Vector3 vector = Quaternion.Lerp(Quaternion.identity, b, num) * _animationStart;
			base.transform.position = vector + vector.normalized * num2 + QuadSphere.Transform.position;
			Vector3 worldPosition = _viewer.ReferenceFrame.PlanetToFramePosition(FocusTargetPci);
			Vector3 worldUp = _viewer.ReferenceFrame.PlanetToFrameVector(FocusTargetPci.normalized);
			Quaternion rotation = base.transform.rotation;
			base.transform.LookAt(worldPosition, worldUp);
			Quaternion rotation2 = base.transform.rotation;
			base.transform.rotation = Quaternion.Lerp(rotation, rotation2, Mathf.Pow(num, 4f));
			return result;
		}
	}
}
