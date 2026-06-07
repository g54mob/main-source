using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Movement/MM Squash And Stretch")]
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

		[MMInformation("This component will apply squash and stretch based on velocity (either position based or computed from a Rigidbody. It has to be put on an intermediary level in the hierarchy, between the logic (top level) and the model (bottom level).", MMInformationAttribute.InformationType.Info, false)]
		[Header("Velocity Detection")]
		[Tooltip("the possible ways to get velocity from")]
		public Modes Mode = Modes.Position;

		[Tooltip("whether we should use deltaTime or unscaledDeltaTime")]
		public Timescales Timescale;

		[Header("Settings")]
		[Tooltip("the intensity of the squash and stretch")]
		public float Intensity = 0.02f;

		[Tooltip("the maximum velocity of your parent object, used to remap the computed one")]
		public float MaximumVelocity = 1f;

		[Header("Rescale")]
		[Tooltip("the minimum scale to apply to this object")]
		public Vector3 MinimumScale = new Vector3(0.5f, 0.5f, 0.5f);

		[Tooltip("the maximum scale to apply to this object")]
		public Vector3 MaximumScale = new Vector3(2f, 2f, 2f);

		[Tooltip("whether or not to rescale on the x axis")]
		public bool RescaleX = true;

		[Tooltip("whether or not to rescale on the y axis")]
		public bool RescaleY = true;

		[Tooltip("whether or not to rescale on the z axis")]
		public bool RescaleZ = true;

		[Tooltip("whether or not to rotate the transform to align with the current direction")]
		public bool RotateToMatchDirection = true;

		[Header("Squash")]
		[Tooltip("if this is true, the object will squash once velocity goes below the specified threshold")]
		public bool AutoSquashOnStop;

		[Tooltip("the curve to apply when squashing the object (this describes scale on x and z, will be inverted for y to maintain mass)")]
		public AnimationCurve SquashCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the velocity threshold after which a squash can be triggered if the object stops")]
		public float SquashVelocityThreshold = 0.1f;

		[Tooltip("the maximum duration of the squash (will be reduced if velocity is low)")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 SquashDuration = new Vector2(0.25f, 0.5f);

		[Tooltip("the maximum intensity of the squash")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 SquashIntensity = new Vector2(0f, 1f);

		[Header("Spring")]
		[Tooltip("whether or not to add extra spring to the squash and stretch")]
		public bool Spring;

		[Tooltip("the damping to apply to the spring")]
		[MMCondition("Spring", true)]
		public float SpringDamping = 0.3f;

		[Tooltip("the spring's frequency")]
		[MMCondition("Spring", true)]
		public float SpringFrequency = 3f;

		[Header("Debug")]
		[MMReadOnly]
		[Tooltip("the current velocity of the parent object")]
		public Vector3 Velocity;

		[MMReadOnly]
		[Tooltip("the remapped velocity")]
		public float RemappedVelocity;

		[MMReadOnly]
		[Tooltip("the current velocity magnitude")]
		public float VelocityMagnitude;

		protected Rigidbody2D _rigidbody2D;

		protected Rigidbody _rigidbody;

		protected Transform _childTransform;

		protected Transform _parentTransform;

		protected Vector3 _direction;

		protected Vector3 _previousPosition;

		protected Vector3 _newLocalScale;

		protected Vector3 _initialScale;

		protected Quaternion _newRotation = Quaternion.identity;

		protected Quaternion _deltaRotation;

		protected float _squashStartedAt;

		protected bool _squashing;

		protected float _squashIntensity;

		protected float _squashDuration;

		protected bool _movementStarted;

		protected float _lastVelocity;

		protected Vector3 _springScale;

		protected Vector3 _springVelocity = Vector3.zero;

		public virtual float TimescaleTime
		{
			get
			{
				if (Timescale != Timescales.Regular)
				{
					return Time.unscaledTime;
				}
				return Time.time;
			}
		}

		public virtual float TimescaleDeltaTime
		{
			get
			{
				if (Timescale != Timescales.Regular)
				{
					return Time.unscaledDeltaTime;
				}
				return Time.deltaTime;
			}
		}

		protected virtual void Start()
		{
			Initialization();
		}

		protected virtual void Initialization()
		{
			_initialScale = base.transform.localScale;
			_springScale = _initialScale;
			_rigidbody = base.transform.parent.GetComponent<Rigidbody>();
			_rigidbody2D = base.transform.parent.GetComponent<Rigidbody2D>();
			_childTransform = base.transform.GetChild(0).transform;
			_parentTransform = base.transform.parent.GetComponent<Transform>();
			_previousPosition = _parentTransform.position;
		}

		protected virtual void LateUpdate()
		{
			SquashAndStretch();
		}

		protected virtual void SquashAndStretch()
		{
			if (!(TimescaleDeltaTime <= 0f))
			{
				ComputeVelocityAndDirection();
				ComputeNewRotation();
				ComputeNewLocalScale();
				StorePreviousPosition();
			}
		}

		protected virtual void ComputeVelocityAndDirection()
		{
			Velocity = Vector3.zero;
			switch (Mode)
			{
			case Modes.Rigidbody:
				Velocity = _rigidbody.linearVelocity;
				break;
			case Modes.Rigidbody2D:
				Velocity = _rigidbody2D.linearVelocity;
				break;
			case Modes.Position:
				Velocity = (_previousPosition - _parentTransform.position) / TimescaleDeltaTime;
				break;
			}
			VelocityMagnitude = Velocity.magnitude;
			RemappedVelocity = MMMaths.Remap(VelocityMagnitude, 0f, MaximumVelocity, 0f, 1f);
			_direction = Vector3.Normalize(Velocity);
			if (AutoSquashOnStop)
			{
				if (VelocityMagnitude > SquashVelocityThreshold)
				{
					_movementStarted = true;
					_lastVelocity = Mathf.Clamp(VelocityMagnitude, 0f, MaximumVelocity);
				}
				else if (_movementStarted)
				{
					_movementStarted = false;
					_squashing = true;
					float duration = MMMaths.Remap(_lastVelocity, 0f, MaximumVelocity, SquashDuration.x, SquashDuration.y);
					float intensity = MMMaths.Remap(_lastVelocity, 0f, MaximumVelocity, SquashIntensity.x, SquashIntensity.y);
					Squash(duration, intensity);
				}
			}
		}

		protected virtual void ComputeNewRotation()
		{
			if (RotateToMatchDirection)
			{
				if (VelocityMagnitude > 0.01f)
				{
					_newRotation = Quaternion.FromToRotation(Vector3.up, _direction);
				}
				_deltaRotation = _parentTransform.rotation;
				base.transform.rotation = _newRotation;
				_childTransform.rotation = _deltaRotation;
			}
		}

		protected virtual void ComputeNewLocalScale()
		{
			if (_squashing)
			{
				float num = MMMaths.Remap(TimescaleTime - _squashStartedAt, 0f, _squashDuration, 0f, 1f);
				float num2 = SquashCurve.Evaluate(num);
				_newLocalScale.x = _initialScale.x + num2 * _squashIntensity;
				_newLocalScale.y = _initialScale.y - num2 * _squashIntensity;
				_newLocalScale.z = _initialScale.z + num2 * _squashIntensity;
				if (num >= 1f)
				{
					_squashing = false;
				}
			}
			else
			{
				_newLocalScale.x = Mathf.Clamp01(1f / (RemappedVelocity + 0.001f));
				_newLocalScale.y = RemappedVelocity;
				_newLocalScale.z = Mathf.Clamp01(1f / (RemappedVelocity + 0.001f));
				_newLocalScale = Vector3.Lerp(Vector3.one, _newLocalScale, VelocityMagnitude * Intensity);
			}
			_newLocalScale.x = Mathf.Clamp(_newLocalScale.x, MinimumScale.x, MaximumScale.x);
			_newLocalScale.y = Mathf.Clamp(_newLocalScale.y, MinimumScale.y, MaximumScale.y);
			_newLocalScale.z = Mathf.Clamp(_newLocalScale.z, MinimumScale.z, MaximumScale.z);
			if (Spring)
			{
				MMMaths.Spring(ref _springScale, _newLocalScale, ref _springVelocity, SpringDamping, SpringFrequency, Time.deltaTime);
				_newLocalScale = _springScale;
			}
			if (!RescaleX)
			{
				_newLocalScale.x = _initialScale.x;
			}
			if (!RescaleY)
			{
				_newLocalScale.y = _initialScale.y;
			}
			if (!RescaleZ)
			{
				_newLocalScale.z = _initialScale.z;
			}
			base.transform.localScale = _newLocalScale;
		}

		protected virtual void StorePreviousPosition()
		{
			_previousPosition = _parentTransform.position;
		}

		public virtual void Squash(float duration, float intensity)
		{
			_squashStartedAt = TimescaleTime;
			_squashing = true;
			_squashIntensity = intensity;
			_squashDuration = duration;
		}
	}
}
