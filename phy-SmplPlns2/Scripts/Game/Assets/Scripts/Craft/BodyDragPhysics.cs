using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.Simulation;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class BodyDragPhysics : IBodyDragPhysics
	{
		private BodyScript _body;

		private DragTable _dragTable = new DragTable();

		private PartDrag _frameDrag = new PartDrag();

		private int _lastLogFrame;

		private PartDrag _totalPartDrag;

		private Transform _transform;

		public static bool EnableDragLift { get; set; } = true;

		public static bool HeatDamageEnabled { get; set; }

		public Vector3 DragForce { get; private set; }

		public DragTable DragTable => _dragTable;

		public float FluidDensity { get; private set; }

		public float MachNumber { get; private set; }

		public float TotalDragForceMagnitude { get; private set; }

		public Vector3 Velocity { get; private set; }

		public float VelocityMagnitude { get; private set; }

		public Vector3 VelocityNormalized { get; private set; }

		public float VelocitySquared { get; private set; }

		public float WaveDragMultiplier { get; private set; } = 1f;

		public BodyDragPhysics(BodyScript body)
		{
			_body = body;
			_transform = body.transform;
		}

		public static float CalculateConvectionHeat(float h, float fluidTemperature, float objectTemperature, float mass, float area, float deltaTime)
		{
			return h * (fluidTemperature - objectTemperature) * area * deltaTime / mass / 921f;
		}

		public static float CalculateConvectionHeat(float h1, float fluidTemperature1, float area1, float h2, float fluidTemperature2, float area2, float objectTemperature, float mass, float deltaTime)
		{
			if (mass < float.Epsilon)
			{
				return 0f;
			}
			return (h1 * (fluidTemperature1 - objectTemperature) * area1 + h2 * (fluidTemperature2 - objectTemperature) * area2) * deltaTime / mass / 921f;
		}

		public static float CalculateStagnationPointTemperature(float atmosphericTemperature, float machNumber)
		{
			float num = 1.4f;
			float t = machNumber / 36f;
			num = Mathf.Lerp(1.4f, 1.055f, t);
			return atmosphericTemperature * (1f + machNumber * machNumber * (num - 1f) / 2f);
		}

		public static float GetDragForceMagnitude(float velocitySquared, float area, float dragCoefficient, float fluidDensity)
		{
			return 0.005f * fluidDensity * velocitySquared * dragCoefficient * area * 0.875f;
		}

		public void AddDrag(PartDrag partDrag)
		{
			_totalPartDrag.AddDrag(partDrag);
		}

		public void AddFrameDrag(PartDrag.DragDirection direction, float drag, Vector3 position)
		{
			_frameDrag.AddDrag(direction, drag, position, 0f);
		}

		public void ApplyDrag(Vector3 velocity)
		{
			AtmosphereSample atmosphereSample = _body.Aircraft.AtmosphereSample;
			InitializeFrame(velocity, atmosphereSample.SpeedOfSound, EnableDragLift);
			if (_totalPartDrag != null)
			{
				float num = CalculateUnderwaterAmount();
				float t = Mathf.Pow(num, 2.5f);
				FluidDensity = Mathf.Lerp(atmosphereSample.AirDensity, 1000f, t);
				ApplyDrag(FluidDensity);
				if (_body.UpdateAngularDrag)
				{
					float target = Mathf.Lerp(0.05f, 4f, num);
					_body.RigidBody.angularDrag = Utilities.StepTowards(_body.RigidBody.angularDrag, Time.deltaTime * 10f, target);
				}
			}
		}

		public void CalculateDrag()
		{
			_totalPartDrag = new PartDrag();
			foreach (PartData part in _body.RigidBodyGroup.Parts)
			{
				if (part.DragType == PartDragType.Standard)
				{
					_totalPartDrag.AddDrag(part.PartDrag);
				}
			}
		}

		public IPartDragPhysics CreatePartDragPhysics(PartScript part)
		{
			return new PartDragPhysics(part, this);
		}

		public float EstimatePartDragForce(PartDrag partDrag, float fluidDensity)
		{
			float num = _dragTable.CalculateDragCoefficientTimesArea(partDrag);
			return 0.005f * fluidDensity * VelocitySquared * num * 0.875f * Game.Instance.Settings.Gameplay.Flight.DragScale.Value;
		}

		public float EstimatePartDragForceDelta(PartDrag partDrag, float fluidDensityA, float fluidDensityB)
		{
			float num = _dragTable.CalculateDragCoefficientTimesArea(partDrag);
			return 0.005f * VelocitySquared * num * Mathf.Max(0f, fluidDensityB - fluidDensityA) * 0.875f;
		}

		public Vector3 GetDragForce(PartDrag drag, float mass, float fluidDensity, bool enableDragLift)
		{
			Vector3 velocityNormalized = VelocityNormalized;
			float velocityMagnitude = VelocityMagnitude;
			Vector3 result = Vector3.zero;
			WaveDragMultiplier = 1f;
			if (velocityMagnitude > 1f && fluidDensity > 0f)
			{
				Vector3 vector = _transform.InverseTransformDirection(Velocity);
				float num = _body.Aircraft.CalculateStreamlineMagnitude();
				float num2 = (WaveDragMultiplier = GetWaveDragMultiplier(MachNumber, 5f));
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < 3; i++)
				{
					float num3 = vector[i];
					float drag2 = drag.GetDrag(i switch
					{
						0 => (num3 > 0f) ? PartDrag.DragDirection.Rightward : PartDrag.DragDirection.Leftward, 
						1 => (num3 > 0f) ? PartDrag.DragDirection.Upward : PartDrag.DragDirection.Downward, 
						_ => (!(num3 > 0f)) ? PartDrag.DragDirection.Backward : PartDrag.DragDirection.Forward, 
					});
					drag2 *= num;
					drag2 *= num2;
					zero[i] = drag2 * num3 * Mathf.Abs(num3);
				}
				float num4 = drag.CalculateSkinDrag() * VelocitySquared;
				float num5 = 0.005f * fluidDensity * Game.Instance.Settings.Gameplay.Flight.DragScale.Value * 0.875f;
				Vector3 vector2 = _transform.TransformDirection(zero) * -1f;
				Vector3 vector3 = velocityNormalized * (0f - num4);
				if (enableDragLift)
				{
					result = (vector2 + vector3) * num5;
				}
				else
				{
					float magnitude = (vector2 + vector3).magnitude;
					result = num5 * magnitude * -velocityNormalized;
				}
				if (_body.Id == 0 && Time.frameCount > _lastLogFrame && Time.frameCount % 10 == 0)
				{
					_lastLogFrame = Time.frameCount;
					_ = result.magnitude / (num5 * VelocitySquared);
				}
				result = LimitDragForce(result, result.magnitude, mass);
				TotalDragForceMagnitude = result.magnitude;
			}
			return result;
		}

		public void InitializeFrame(Vector3 velocity, float speedOfSound, bool enableDragLift)
		{
			Velocity = velocity;
			float num = (VelocityMagnitude = velocity.magnitude);
			TotalDragForceMagnitude = 0f;
			if (speedOfSound > 0f)
			{
				MachNumber = num / speedOfSound;
			}
			else
			{
				MachNumber = 0f;
			}
			if (num > 1f)
			{
				VelocityNormalized = velocity / num;
				VelocitySquared = num * num;
				Vector3 normalized = _transform.InverseTransformDirection(velocity).normalized;
				_dragTable.SetValuesFromVector(normalized);
			}
			else
			{
				VelocityNormalized = Vector3.zero;
				VelocitySquared = 0f;
				_dragTable.Clear();
			}
		}

		public void OnFloatingOriginChanged(Vector3 delta)
		{
			for (int i = 0; i < 6; i++)
			{
				PartDrag.DragDirection direction = (PartDrag.DragDirection)i;
				Vector3 centerOfDrag = _frameDrag.GetCenterOfDrag(direction);
				centerOfDrag -= delta;
				_frameDrag.SetCenterOfDrag(direction, centerOfDrag);
			}
		}

		public void OnRepositioned()
		{
			_frameDrag.ClearDrag();
		}

		private static float GetWaveDragMultiplier(float mach, float peakMult)
		{
			if (mach < 0.75f)
			{
				return 1f;
			}
			if (mach < 1.05f)
			{
				float t = (mach - 0.75f) / 0.29999995f;
				return Mathf.Lerp(1f, peakMult, t);
			}
			float t2 = Mathf.Clamp01((mach - 1.05f) / 1f);
			float b = Mathf.Max(2f, peakMult * 0.4f);
			return Mathf.Lerp(peakMult, b, t2);
		}

		private void ApplyDrag(float fluidDensity)
		{
			if (VelocityMagnitude > 0f && fluidDensity > 0f)
			{
				DragForce = GetDragForce(_totalPartDrag, _body.RigidBody.mass, fluidDensity, EnableDragLift);
				_body.RigidBody.AddForce(DragForce);
				ApplyFrameDrag(_frameDrag, _body.RigidBody, fluidDensity);
				_frameDrag.ClearDrag();
			}
			else
			{
				DragForce = Vector3.zero;
			}
		}

		private void ApplyFrameDrag(PartDrag frameDrag, IRigidBody rigidbody, float fluidDensity)
		{
			Vector3 velocityNormalized = VelocityNormalized;
			float velocitySquared = VelocitySquared;
			for (int i = 0; i < 6; i++)
			{
				float drag = frameDrag.GetDrag((PartDrag.DragDirection)i);
				if (drag == 0f || !(_dragTable.Values[i] > 0f))
				{
					continue;
				}
				float num = _dragTable.Values[i] * drag;
				float num2 = 0.005f * fluidDensity * velocitySquared * num * 0.875f;
				if ((double)num2 > 10000.0)
				{
					float num3 = VelocityMagnitude / Time.fixedDeltaTime * 0.5f * rigidbody.mass;
					if (num2 > num3)
					{
						num2 = num3;
					}
				}
				if (float.IsNaN(num2))
				{
					break;
				}
				if (num2 > 1000000f)
				{
					num2 = 1000000f;
				}
				Vector3 force = velocityNormalized * (0f - num2);
				Vector3 centerOfDrag = frameDrag.GetCenterOfDrag((PartDrag.DragDirection)i);
				rigidbody.AddForceAtPosition(force, centerOfDrag);
			}
		}

		private float CalculateUnderwaterAmount()
		{
			if (_body.RigidBodyGroup.Parts.Count > 0)
			{
				float num = 0f;
				for (int i = 0; i < _body.RigidBodyGroup.Parts.Count; i++)
				{
					num += Mathf.Clamp01(_body.RigidBodyGroup.Parts[i].PartScript.EstimateOfUnderwaterPercent);
				}
				return num / (float)_body.RigidBodyGroup.Parts.Count;
			}
			return 0f;
		}

		private Vector3 LimitDragForce(Vector3 dragForce, float magnitude, float mass)
		{
			if ((double)magnitude > 10000.0)
			{
				float a = VelocityMagnitude * 0.95f * mass / Time.fixedDeltaTime;
				a = Mathf.Min(a, 10000000f);
				if (magnitude > a)
				{
					magnitude = a;
					dragForce = dragForce.normalized * magnitude;
				}
			}
			if (float.IsNaN(magnitude))
			{
				dragForce = Vector3.zero;
			}
			return dragForce;
		}
	}
}
