using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class DebugTargetScript : MonoBehaviour, ITarget
	{
		[SerializeField]
		private Vector3 _angularVelocity;

		[SerializeField]
		private bool _isLocked;

		[SerializeField]
		private bool _isLost;

		private Rigidbody _rigidBody;

		[SerializeField]
		private Vector3 _velocity;

		public Vector3 AngularVelocity => _angularVelocity;

		public bool IsDead => base.gameObject == null;

		public bool IsLocked => _isLocked;

		public bool IsLost => _isLost;

		public float MaxVisibleRange => 0f;

		public Vector3 Position => base.transform.position;

		public TargetType TargetType => TargetType.Air;

		public Vector3 Velocity => _velocity;

		public static ITarget CreateDebugTarget(Vector3 position)
		{
			DebugTargetScript debugTargetScript = new GameObject().AddComponent<DebugTargetScript>();
			debugTargetScript.transform.position = position;
			debugTargetScript.name = "DebugTarget";
			Debug.Log("Debug target created");
			return debugTargetScript;
		}

		public void Alert(bool locked, ITargetLockSource source, TrackedTarget trackedTarget)
		{
		}

		protected virtual void Awake()
		{
			_rigidBody = base.gameObject.AddComponent<Rigidbody>();
			_rigidBody.useGravity = false;
			_rigidBody.isKinematic = true;
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			obj.transform.localScale = Vector3.one * 2f;
		}

		protected virtual void Update()
		{
			if (_rigidBody != null)
			{
				_rigidBody.angularVelocity = AngularVelocity;
				_rigidBody.linearVelocity = Velocity;
			}
		}
	}
}
