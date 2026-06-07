using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Sea;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class ArrestingCable : MonoBehaviour
	{
		private readonly Vector3[] _tempArray2 = new Vector3[2];

		private readonly Vector3[] _tempArray7 = new Vector3[7];

		private ArrestingHookScript _arrestingHook;

		private LineRenderer _cableLine;

		private AudioSource _cableSound;

		private Rigidbody _criminalRigidbody;

		[SerializeField]
		private float _magicMultiplier = 100f;

		[SerializeField]
		private float _maxForce = 25f;

		[SerializeField]
		private float _maxStretchDistance = 150f;

		private Rigidbody _parent;

		private AircraftCarrierSyncScript _sync;

		public bool InUse { get; private set; }

		public void Arrest(ArrestingHookScript criminal)
		{
			_sync?.SynchronizeArrestingCableStatus(this, criminal);
		}

		public void InitializeSync(AircraftCarrierSyncScript aircraftCarrierSyncScript)
		{
			_sync = aircraftCarrierSyncScript;
		}

		public void ReleaseHook()
		{
			_sync.SynchronizeArrestingCableStatus(this, null);
		}

		public void SetArrestingHook(ArrestingHookScript arrestingHook, bool local)
		{
			if (arrestingHook != null)
			{
				InUse = true;
				_arrestingHook = arrestingHook;
				if (local)
				{
					_criminalRigidbody = arrestingHook.PartScript.Body.RigidBody.PhysxRigidBody;
					arrestingHook.Hooked = true;
				}
				_cableSound.Play();
				return;
			}
			InUse = false;
			_criminalRigidbody = null;
			if (_arrestingHook != null)
			{
				_arrestingHook.Hooked = false;
				_arrestingHook = null;
				if (_cableSound.isPlaying)
				{
					_cableSound.Stop();
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			if (_criminalRigidbody == null || _arrestingHook == null)
			{
				return;
			}
			Vector3 vector = base.transform.InverseTransformVector(base.transform.position.x - _arrestingHook.HookPoint.x, base.transform.position.y - _arrestingHook.HookPoint.y, base.transform.position.z - _arrestingHook.HookPoint.z);
			Vector3 vector2 = base.transform.InverseTransformVector(_criminalRigidbody.linearVelocity) - ((_parent == null) ? Vector3.zero : base.transform.InverseTransformVector(_parent.linearVelocity));
			if (base.transform.InverseTransformVector(_arrestingHook.HookPoint).z <= base.transform.InverseTransformVector(base.transform.position).z)
			{
				_arrestingHook.LastCableForce = Vector3.zero;
				if (vector2.z < 0f)
				{
					ReleaseHook();
				}
				return;
			}
			if (vector2.z > 0f)
			{
				vector.z *= vector2.z * 5f;
			}
			else
			{
				vector.z /= Mathf.Abs(vector.z);
				vector.z *= vector2.z;
			}
			vector = Vector3.ClampMagnitude(vector, _maxForce);
			Vector3 vector3 = base.transform.TransformVector(Vector3.Scale(vector, new Vector3(1f / base.transform.localScale.x, 1f / base.transform.localScale.y, 1f / base.transform.localScale.z)) * _magicMultiplier) - base.transform.forward * _magicMultiplier;
			_criminalRigidbody.AddForceAtPosition(vector3 * _arrestingHook.CableDeceleration, _arrestingHook.transform.position, ForceMode.Force);
			_arrestingHook.LastCableForce = vector3;
			if (Vector3.Distance(_arrestingHook.transform.position, base.transform.position) > _maxStretchDistance || !_arrestingHook.Active)
			{
				ReleaseHook();
			}
		}

		protected virtual void Start()
		{
			_parent = GetComponentInParent<Rigidbody>();
			_cableLine = GetComponent<LineRenderer>();
			_cableSound = GetComponent<AudioSource>();
		}

		protected virtual void Update()
		{
			_cableSound.pitch = Time.timeScale;
			if (InUse && _arrestingHook != null)
			{
				if (base.transform.InverseTransformVector(_arrestingHook.HookPoint).z >= base.transform.InverseTransformVector(base.transform.position).z)
				{
					_cableLine.positionCount = 7;
					Vector3[] tempArray = _tempArray7;
					tempArray[0] = base.transform.position + base.transform.right * base.transform.lossyScale.x / 2f - base.transform.up * base.transform.lossyScale.y / 2.1f;
					tempArray[1] = _arrestingHook.HookPoint + _arrestingHook.HookTransform.right * 0.065f;
					tempArray[2] = _arrestingHook.HookPoint - _arrestingHook.HookTransform.right * 0.065f;
					tempArray[3] = base.transform.position + base.transform.right * (0f - base.transform.lossyScale.x) / 2f - base.transform.up * base.transform.lossyScale.y / 2.1f;
					tempArray[4] = _arrestingHook.HookPoint - _arrestingHook.HookTransform.right * 0.065f;
					tempArray[5] = _arrestingHook.HookPoint + _arrestingHook.HookTransform.right * 0.065f;
					tempArray[6] = base.transform.position + base.transform.right * base.transform.lossyScale.x / 2f - base.transform.up * base.transform.lossyScale.y / 2.1f;
					_cableLine.SetPositions(tempArray);
				}
				else
				{
					_cableLine.positionCount = 2;
					Vector3[] tempArray2 = _tempArray2;
					tempArray2[0] = base.transform.position + base.transform.right * base.transform.lossyScale.x / 2f - base.transform.up * base.transform.lossyScale.y / 2.1f;
					tempArray2[1] = base.transform.position + base.transform.right * (0f - base.transform.lossyScale.x) / 2f - base.transform.up * base.transform.lossyScale.y / 2.1f;
					_cableLine.SetPositions(tempArray2);
				}
			}
			else
			{
				_cableLine.positionCount = 2;
				Vector3[] tempArray3 = _tempArray2;
				tempArray3[0] = base.transform.position + base.transform.right * base.transform.lossyScale.x / 2f - base.transform.up * base.transform.lossyScale.y / 2.1f;
				tempArray3[1] = base.transform.position + base.transform.right * (0f - base.transform.lossyScale.x) / 2f - base.transform.up * base.transform.lossyScale.y / 2.1f;
				_cableLine.SetPositions(tempArray3);
			}
		}
	}
}
