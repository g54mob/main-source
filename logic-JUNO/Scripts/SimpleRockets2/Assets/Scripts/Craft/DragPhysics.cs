using ModApi.Craft;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class DragPhysics
	{
		private DragTable _dragTable = new DragTable();

		private Transform _transform;

		private Vector3[] _velocityTable = new Vector3[6];

		public static bool HeatDamageEnabled { get; set; }

		public DragTable DragTable => _dragTable;

		public float MachNumber { get; private set; }

		public Vector3 Velocity { get; private set; }

		public float VelocityMagnitude { get; private set; }

		public Vector3 VelocityNormalized { get; private set; }

		public float VelocitySquared { get; private set; }

		public DragPhysics(Transform transform)
		{
			_transform = transform;
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

		public void ApplyFrameDrag(Drag frameDrag, Rigidbody rigidbody, float fluidDensity)
		{
			Vector3 velocityNormalized = VelocityNormalized;
			float velocitySquared = VelocitySquared;
			for (int i = 0; i < 6; i++)
			{
				float drag = frameDrag.GetDrag((Drag.DragDirection)i);
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
				Vector3 centerOfDrag = frameDrag.GetCenterOfDrag((Drag.DragDirection)i);
				rigidbody.AddForceAtPosition(force, centerOfDrag);
			}
		}

		public float EstimatePartDragForce(Drag partDrag, float fluidDensity)
		{
			float num = _dragTable.CalculateDragCoefficientTimesArea(partDrag);
			return 0.005f * fluidDensity * VelocitySquared * num * 0.875f * Game.Instance.Settings.Game.Flight.DragScale.Value;
		}

		public float EstimatePartDragForceDelta(Drag partDrag, float fluidDensityA, float fluidDensityB)
		{
			float num = _dragTable.CalculateDragCoefficientTimesArea(partDrag);
			return 0.005f * VelocitySquared * num * Mathf.Max(0f, fluidDensityB - fluidDensityA) * 0.875f;
		}

		public Vector3 GetDragForce(Drag drag, float mass, float fluidDensity, bool enableDragLift)
		{
			Vector3 velocityNormalized = VelocityNormalized;
			float velocityMagnitude = VelocityMagnitude;
			Vector3 result = Vector3.zero;
			if (velocityMagnitude > 1f && fluidDensity > 0f)
			{
				if (enableDragLift)
				{
					Vector3 zero = Vector3.zero;
					for (int i = 0; i < 6; i++)
					{
						if (_dragTable.Values[i] > 0f)
						{
							zero += drag.GetDrag((Drag.DragDirection)i) * Game.Instance.Settings.Game.Flight.DragScale.Value * 0.875f * _velocityTable[i];
						}
					}
					zero *= 0.005f * fluidDensity;
					zero = LimitDragForce(zero, zero.magnitude, mass);
					result = _transform.TransformDirection(zero);
				}
				else
				{
					float num = _dragTable.CalculateDragCoefficientTimesArea(drag);
					float num2 = 0.005f * fluidDensity * VelocitySquared * num;
					result = (0f - num2) * Game.Instance.Settings.Game.Flight.DragScale.Value * 0.875f * velocityNormalized;
					result = LimitDragForce(result, num2, mass);
				}
			}
			return result;
		}

		public void InitializeFrame(Vector3 velocity, float speedOfSound, bool enableDragLift)
		{
			Velocity = velocity;
			float num = (VelocityMagnitude = velocity.magnitude);
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
				Vector3 vector = _transform.InverseTransformDirection(velocity);
				Vector3 normalized = vector.normalized;
				_dragTable.SetValuesFromVector(normalized);
				if (enableDragLift)
				{
					_velocityTable[0] = new Vector3(0f, 0f, 0f - vector.z * vector.z);
					_velocityTable[1] = new Vector3(0f, 0f, vector.z * vector.z);
					_velocityTable[4] = new Vector3(vector.x * vector.x, 0f, 0f);
					_velocityTable[5] = new Vector3(0f - vector.x * vector.x, 0f, 0f);
					_velocityTable[2] = new Vector3(0f, 0f - vector.y * vector.y, 0f);
					_velocityTable[3] = new Vector3(0f, vector.y * vector.y, 0f);
				}
			}
			else
			{
				VelocityNormalized = Vector3.zero;
				VelocitySquared = 0f;
				_dragTable.Clear();
			}
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
