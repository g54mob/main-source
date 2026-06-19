using Items.Box;
using UnityEngine;

namespace Items.AirDrop
{
	public class ParachuteHolder : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private FixedJoint _joint;

		[SerializeField]
		private GameObject _parachuteVisual;

		[SerializeField]
		private Beacon _beacon;

		[Header("Parachute Settings")]
		[SerializeField]
		private float _drag = 5f;

		[SerializeField]
		private float _angularDrag = 2f;

		[SerializeField]
		private float _maxFallSpeed = 3f;

		private float _originalDrag;

		private float _originalAngularDrag;

		private ItemBoxView _box;

		private void Awake()
		{
			if (_rigidbody == null)
			{
				_rigidbody = GetComponent<Rigidbody>();
			}
			_originalDrag = _rigidbody.linearDamping;
			_originalAngularDrag = _rigidbody.angularDamping;
		}

		private void OnTriggerEnter(Collider other)
		{
			_box?.SetInteractable(interactable: true);
			if (_beacon != null && _box != null)
			{
				_beacon.transform.SetParent(_box.transform, worldPositionStays: true);
				_beacon.Activate();
			}
			foreach (Transform item in base.transform)
			{
				item.SetParent(null);
			}
			_joint.connectedBody = null;
			base.gameObject.SetActive(value: false);
			_parachuteVisual.SetActive(value: false);
		}

		private void OnEnable()
		{
			_rigidbody.linearDamping = _drag;
			_rigidbody.angularDamping = _angularDrag;
			_box?.SetInteractable(interactable: false);
		}

		private void OnDisable()
		{
			_rigidbody.linearDamping = _originalDrag;
			_rigidbody.angularDamping = _originalAngularDrag;
		}

		private void FixedUpdate()
		{
			ClampFallSpeed();
		}

		private void ClampFallSpeed()
		{
			Vector3 linearVelocity = _rigidbody.linearVelocity;
			if (linearVelocity.y < 0f - _maxFallSpeed)
			{
				linearVelocity.y = 0f - _maxFallSpeed;
				_rigidbody.linearVelocity = linearVelocity;
			}
		}

		public void ConnectBox(ItemBoxView box)
		{
			_box = box;
			box.transform.position = base.transform.position;
			_joint.connectedBody = box.GetComponent<Rigidbody>();
			box.SetInteractable(interactable: false);
		}
	}
}
