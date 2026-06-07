using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Movement/MMSquashAndStretch")]
	public class MMSquashAndStretch : MonoBehaviour
	{
		public enum Timescales
		{
			Regular = 0,
			Unscaled = 1
		}

		public enum Modes
		{
			Rigidbody = 0,
			Rigidbody2D = 1,
			Position = 2
		}

		[Header("Velocity Detection")]
		[MMInformation("This component will apply squash and stretch based on velocity (either position based or computed from a Rigidbody. It has to be put on an intermediary level in the hierarchy, between the logic (top level) and the model (bottom level).", MMInformationAttribute.InformationType.Info, false)]
		public Modes Mode;

		public Timescales Timescale;

		[Header("Settings")]
		public float Intensity;

		public float MaximumVelocity;

		[Header("Rescale")]
		public Vector2 MinimumScale;

		public Vector2 MaximumScale;

		[Header("Squash")]
		public bool AutoSquashOnStop;

		public AnimationCurve SquashCurve;

		public float SquashVelocityThreshold;

		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 SquashDuration;

		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 SquashIntensity;

		[Header("Spring")]
		public bool Spring;

		[MMCondition("Spring", true)]
		public float SpringDamping;

		[MMCondition("Spring", true)]
		public float SpringFrequency;

		[MMCondition("Spring", true)]
		public float SpringSpeed;

		[MMReadOnly]
		[Header("Debug")]
		public Vector3 Velocity;

		[MMReadOnly]
		public float RemappedVelocity;

		[MMReadOnly]
		public float VelocityMagnitude;

		protected Rigidbody2D _rigidbody2D;

		protected Rigidbody _rigidbody;

		protected Transform _childTransform;

		protected Transform _parentTransform;

		protected Vector3 _direction;

		protected Vector3 _previousPosition;

		protected Vector3 _newLocalScale;

		protected Vector3 _initialScale;

		protected Quaternion _newRotation;

		protected Quaternion _deltaRotation;

		protected float _squashStartedAt;

		protected bool _squashing;

		protected float _squashIntensity;

		protected float _squashDuration;

		protected bool _movementStarted;

		protected float _lastVelocity;

		protected Vector3 _springScale;

		protected Vector3 _springVelocity;

		public float TimescaleTime => 0f;

		public float TimescaleDeltaTime => 0f;

		protected virtual void Start()
		{
		}

		protected virtual void Initialization()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected virtual void SquashAndStretch()
		{
		}

		protected virtual void ComputeVelocityAndDirection()
		{
		}

		protected virtual void ComputeNewRotation()
		{
		}

		protected virtual void ComputeNewLocalScale()
		{
		}

		protected virtual void StorePreviousPosition()
		{
		}

		public virtual void Squash(float duration, float intensity)
		{
		}
	}
}
