using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using ModApi.Craft;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class FairingDebrisScript : MonoBehaviour, ICraftDebris
	{
		private ICraftScript _craftScript;

		private Vector3 _direction;

		private Drag _drag;

		private float[] _dragTable = new float[6];

		private List<FairingScript> _fairings = new List<FairingScript>();

		private Rigidbody _rigidBody;

		public Rigidbody RigidBody => _rigidBody;

		public Transform Transform => base.transform;

		public void AddFairing(FairingScript fairing)
		{
			_fairings.Add(fairing);
		}

		public void Initialize(ICraftScript craftScript, Vector3 direction)
		{
			_craftScript = craftScript;
			_direction = direction;
			_craftScript.AddDebris(this);
		}

		public void Jettison(Vector3 bodyVelocity, Vector3 angularVelocity, float jettisonSpeed)
		{
			List<GameObject> list = new List<GameObject>();
			Vector3 zero = Vector3.zero;
			_drag = new Drag();
			float num = 0f;
			foreach (FairingScript fairing in _fairings)
			{
				_drag.AddDrag(fairing.PartScript.Data.PartDrag);
				GameObject gameObject = ((Vector3.Dot(_direction, fairing.PartScript.Transform.right) > 0f) ? fairing.RightSide : fairing.LeftSide);
				gameObject.layer = 30;
				FuselageData modifier = fairing.PartScript.Data.GetModifier<FuselageData>();
				float num2 = (modifier.BottomScale.x + modifier.TopScale.x) / 2f;
				zero += gameObject.transform.position + _direction * num2;
				num += fairing.PartScript.Data.Mass / 2f;
				list.Add(gameObject);
			}
			base.gameObject.transform.position = zero / _fairings.Count;
			foreach (GameObject item in list)
			{
				item.transform.SetParent(base.gameObject.transform, worldPositionStays: true);
			}
			_fairings.Clear();
			_rigidBody = base.gameObject.AddComponent<Rigidbody>();
			_rigidBody.drag = 0f;
			_rigidBody.useGravity = false;
			_rigidBody.mass = Mathf.Max(num, 0.05f);
			_rigidBody.velocity = bodyVelocity + _direction * 2.5f;
			_rigidBody.angularVelocity = angularVelocity;
			_rigidBody.AddForce(_direction * jettisonSpeed, ForceMode.VelocityChange);
		}

		protected virtual void Update()
		{
		}

		private void ApplyDrag()
		{
			Vector3 vector = _rigidBody.velocity + _craftScript.ReferenceFrame.FrameSurfaceVelocity;
			float magnitude = vector.magnitude;
			float airDensity = _craftScript.AtmosphereSample.AirDensity;
			if (magnitude > 1f && airDensity > 0f)
			{
				Vector3 normalized = base.transform.InverseTransformDirection(vector).normalized;
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
						num += _dragTable[i] * _drag.GetDrag((Drag.DragDirection)i);
					}
				}
				Vector3 vector2 = vector / magnitude;
				float num2 = magnitude * magnitude;
				float num3 = 0.005f * airDensity * num2 * num;
				if ((double)num3 > 10000.0)
				{
					float num4 = magnitude / Time.fixedDeltaTime * 0.5f * _rigidBody.mass;
					if (num3 > num4 / 0.875f)
					{
						num3 = num4 / 0.875f;
					}
				}
				if (!float.IsNaN(num3))
				{
					if (num3 > 50000f)
					{
						num3 = 50000f;
					}
					Vector3 force = vector2 * (0f - num3) * 0.875f;
					_rigidBody.AddForce(force);
				}
				else
				{
					Debug.Log("Drag force is NaN");
				}
			}
			else
			{
				_dragTable[0] = 0f;
				_dragTable[1] = 0f;
				_dragTable[4] = 0f;
				_dragTable[5] = 0f;
				_dragTable[2] = 0f;
				_dragTable[3] = 0f;
			}
		}

		private void FixedUpdate()
		{
			if (_craftScript != null && _rigidBody != null)
			{
				_rigidBody.AddForce(Physics.gravity, ForceMode.Acceleration);
				ApplyDrag();
			}
		}
	}
}
