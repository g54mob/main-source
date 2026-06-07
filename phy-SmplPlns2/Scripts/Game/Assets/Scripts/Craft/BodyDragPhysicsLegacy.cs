using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class BodyDragPhysicsLegacy : IBodyDragPhysics
	{
		private BodyScript _body;

		private float[] _dragTable = new float[6];

		private PartDrag _frameDrag = new PartDrag();

		private float _frameWaterAngularDrag;

		private PartDrag _totalPartDrag;

		private bool _waterDragApplied;

		private PartDrag _waterFrameDrag = new PartDrag();

		public float TotalDragForceMagnitude { get; private set; }

		public float WaveDragMultiplier => 1f;

		public BodyDragPhysicsLegacy(BodyScript body)
		{
			_body = body;
		}

		public void AddDrag(PartDrag partDrag)
		{
			_totalPartDrag.AddDrag(partDrag);
		}

		public void AddFrameDrag(PartDrag.DragDirection direction, float drag, Vector3 position)
		{
			_frameDrag.AddDrag(direction, drag, position, 0f);
		}

		public void AddWaterFrameDrag(PartDrag waterFrameDrag)
		{
			_waterDragApplied = true;
			_waterFrameDrag.AddDrag(waterFrameDrag);
		}

		public void AddWaterFrameDrag(PartDrag.DragDirection direction, float drag, Vector3 position)
		{
			_waterDragApplied = true;
			_waterFrameDrag.AddDrag(direction, drag, position, 0f);
		}

		public void ApplyDrag(Vector3 velocity)
		{
			if (_totalPartDrag != null)
			{
				velocity -= _body.Aircraft.WindVelocity;
				float dragScale = 1f;
				if (_waterDragApplied)
				{
					ApplyDrag(_body.RigidBody.velocity, _waterFrameDrag, 1f);
					float num = 0f;
					for (int i = 0; i < _body.RigidBodyGroup.Parts.Count; i++)
					{
						num += Mathf.Clamp01(_body.RigidBodyGroup.Parts[i].PartScript.EstimateOfUnderwaterPercent);
					}
					dragScale = 1f - num / (float)_body.RigidBodyGroup.Parts.Count;
				}
				ApplyDrag(velocity, _frameDrag, dragScale);
				if (_body.UpdateAngularDrag)
				{
					_body.RigidBody.angularDrag = _frameWaterAngularDrag;
				}
			}
			_waterDragApplied = false;
			_waterFrameDrag.ClearDrag();
			_frameDrag.ClearDrag();
			_frameWaterAngularDrag = 0.05f;
		}

		public void CalculateDrag()
		{
			_totalPartDrag = new PartDrag();
			foreach (PartData part in _body.RigidBodyGroup.Parts)
			{
				_totalPartDrag.AddDrag(part.PartDrag);
			}
		}

		public IPartDragPhysics CreatePartDragPhysics(PartScript part)
		{
			return new PartDragPhysicsLegacy(part, this);
		}

		public void OnFloatingOriginChanged(Vector3 delta)
		{
			for (int i = 0; i < 6; i++)
			{
				PartDrag.DragDirection direction = (PartDrag.DragDirection)i;
				Vector3 centerOfDrag = _frameDrag.GetCenterOfDrag(direction);
				centerOfDrag -= delta;
				_frameDrag.SetCenterOfDrag(direction, centerOfDrag);
				centerOfDrag = _waterFrameDrag.GetCenterOfDrag(direction);
				centerOfDrag -= delta;
				_waterFrameDrag.SetCenterOfDrag(direction, centerOfDrag);
			}
		}

		public void OnRepositioned()
		{
			_frameDrag.ClearDrag();
		}

		public void SetFrameAngularDrag(float frameAngularDrag)
		{
			if (frameAngularDrag > _frameWaterAngularDrag)
			{
				_frameWaterAngularDrag = Mathf.Clamp(frameAngularDrag, 0.05f, 4f);
			}
		}

		private void ApplyDrag(Vector3 velocity, PartDrag frameDrag, float dragScale)
		{
			float magnitude = velocity.magnitude;
			if (magnitude > 1f)
			{
				Vector3 normalized = _body.transform.InverseTransformDirection(velocity).normalized;
				_dragTable[0] = normalized.z;
				_dragTable[1] = 0f - normalized.z;
				_dragTable[4] = normalized.x;
				_dragTable[5] = 0f - normalized.x;
				_dragTable[2] = normalized.y;
				_dragTable[3] = 0f - normalized.y;
				float num = 0f;
				for (int i = 0; i < 6; i++)
				{
					if (_dragTable[i] > 0f)
					{
						num += _dragTable[i] * _totalPartDrag.GetDrag((PartDrag.DragDirection)i);
					}
				}
				Vector3 vector = velocity / magnitude;
				float num2 = magnitude * magnitude;
				float num3 = 0.005f * _body.Aircraft.AtmosphereSample.AirDensityRatio * num2 * num;
				num3 *= dragScale;
				if ((double)num3 > 10000.0)
				{
					float num4 = magnitude / Time.fixedDeltaTime * 0.5f * _body.RigidBody.mass;
					if (num3 > num4 / 1.25f)
					{
						num3 = num4 / 1.25f;
					}
				}
				if (!float.IsNaN(num3))
				{
					if (num3 > 50000f)
					{
						num3 = 50000f;
					}
					Vector3 force = vector * ((0f - num3) * 1.25f);
					_body.RigidBody.AddForce(force);
					ApplyFrameDrag(frameDrag, vector, num2, dragScale);
					TotalDragForceMagnitude = num3;
				}
			}
			else
			{
				TotalDragForceMagnitude = 0f;
			}
		}

		private void ApplyFrameDrag(PartDrag frameDrag, Vector3 velocityNormalized, float velocitySquared, float dragScale)
		{
			for (int i = 0; i < 6; i++)
			{
				if (!(_dragTable[i] > 0f))
				{
					continue;
				}
				float num = _dragTable[i] * frameDrag.GetDrag((PartDrag.DragDirection)i);
				float num2 = 0.005f * _body.Aircraft.AtmosphereSample.AirDensityRatio * velocitySquared * num;
				num2 *= dragScale;
				if ((double)num2 > 10000.0)
				{
					float num3 = Mathf.Sqrt(velocitySquared) / Time.fixedDeltaTime * 0.5f * _body.RigidBody.mass;
					if (num2 > num3 / 1.25f)
					{
						num2 = num3 / 1.25f;
					}
				}
				if (float.IsNaN(num2))
				{
					break;
				}
				if (num2 > 50000f)
				{
					num2 = 50000f;
				}
				Vector3 force = velocityNormalized * ((0f - num2) * 1.25f);
				Vector3 centerOfDrag = frameDrag.GetCenterOfDrag((PartDrag.DragDirection)i);
				_body.RigidBody.AddForceAtPosition(force, centerOfDrag);
			}
		}
	}
}
