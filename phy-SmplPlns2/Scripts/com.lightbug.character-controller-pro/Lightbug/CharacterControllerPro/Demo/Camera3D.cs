using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Camera/Camera 3D")]
	[DefaultExecutionOrder(120)]
	public class Camera3D : MonoBehaviour
	{
		public enum CameraMode
		{
			FirstPerson = 0,
			ThirdPerson = 1
		}

		[Header("Inputs")]
		[SerializeField]
		private InputHandlerSettings inputHandlerSettings = new InputHandlerSettings();

		[SerializeField]
		private string axes = "Camera";

		[SerializeField]
		private string zoomAxis = "Camera Zoom";

		[Header("Target")]
		[Tooltip("Select the graphics root object as your target, the one containing all the meshes, sprites, animated models, etc. \n\nImportant: This will be the considered as the actual target (visual element).")]
		[SerializeField]
		private Transform targetTransform;

		[SerializeField]
		private Vector3 offsetFromHead = Vector3.zero;

		[Tooltip("The interpolation speed used when the height of the character changes.")]
		[SerializeField]
		private float heightLerpSpeed = 10f;

		[Header("View")]
		public CameraMode cameraMode = CameraMode.ThirdPerson;

		[Header("First Person")]
		public bool hideBody = true;

		[SerializeField]
		private GameObject bodyObject;

		[Header("Yaw")]
		public bool updateYaw = true;

		public float yawSpeed = 180f;

		[Header("Pitch")]
		public bool updatePitch = true;

		[SerializeField]
		private float initialPitch = 45f;

		public float pitchSpeed = 180f;

		[Range(1f, 85f)]
		public float maxPitchAngle = 80f;

		[Range(1f, 85f)]
		public float minPitchAngle = 80f;

		[Header("Roll")]
		public bool updateRoll;

		[Header("Zoom (Third person)")]
		public bool updateZoom = true;

		[Min(0f)]
		[SerializeField]
		private float distanceToTarget = 5f;

		[Min(0f)]
		public float zoomInOutSpeed = 40f;

		[Min(0f)]
		public float zoomInOutLerpSpeed = 5f;

		[Min(0f)]
		public float minZoom = 2f;

		[Min(0.001f)]
		public float maxZoom = 12f;

		[Header("Collision")]
		public bool collisionDetection = true;

		public bool collisionAffectsZoom;

		public float detectionRadius = 0.5f;

		public LayerMask layerMask = 0;

		public bool considerKinematicRigidbodies = true;

		public bool considerDynamicRigidbodies = true;

		private CharacterActor characterActor;

		private Rigidbody characterRigidbody;

		private float currentDistanceToTarget;

		private float smoothedDistanceToTarget;

		private float deltaYaw;

		private float deltaPitch;

		private float deltaZoom;

		private Vector3 lerpedCharacterUp = Vector3.up;

		private Transform viewReference;

		private Renderer[] bodyRenderers;

		private RaycastHit[] hitsBuffer = new RaycastHit[10];

		private RaycastHit[] validHits = new RaycastHit[10];

		private Vector3 characterPosition;

		private float lerpedHeight;

		private Vector3 previousLerpedCharacterUp = Vector3.up;

		public void ToggleCameraMode()
		{
			cameraMode = ((cameraMode == CameraMode.FirstPerson) ? CameraMode.ThirdPerson : CameraMode.FirstPerson);
		}

		private void OnValidate()
		{
			initialPitch = Mathf.Clamp(initialPitch, 0f - minPitchAngle, maxPitchAngle);
		}

		private void Awake()
		{
			Initialize(targetTransform);
		}

		public bool Initialize(Transform targetTransform)
		{
			if (targetTransform == null)
			{
				return false;
			}
			characterActor = targetTransform.GetComponentInBranch<CharacterActor>();
			if (characterActor == null || !characterActor.isActiveAndEnabled)
			{
				Debug.Log("The character actor component is null, or it is not active/enabled.");
				return false;
			}
			characterRigidbody = characterActor.GetComponent<Rigidbody>();
			inputHandlerSettings.Initialize(base.gameObject);
			GameObject gameObject = new GameObject("Camera reference");
			viewReference = gameObject.transform;
			if (bodyObject != null)
			{
				bodyRenderers = bodyObject.GetComponentsInChildren<Renderer>();
			}
			return true;
		}

		private void OnEnable()
		{
			if (!(characterActor == null))
			{
				characterActor.OnTeleport += OnTeleport;
			}
		}

		private void OnDisable()
		{
			if (!(characterActor == null))
			{
				characterActor.OnTeleport -= OnTeleport;
			}
		}

		private void Start()
		{
			characterPosition = targetTransform.position;
			previousLerpedCharacterUp = targetTransform.up;
			lerpedCharacterUp = previousLerpedCharacterUp;
			currentDistanceToTarget = distanceToTarget;
			smoothedDistanceToTarget = currentDistanceToTarget;
			viewReference.rotation = targetTransform.rotation;
			viewReference.Rotate(Vector3.right, initialPitch);
			lerpedHeight = characterActor.BodySize.y;
		}

		private void Update()
		{
			if (targetTransform == null)
			{
				base.enabled = false;
				return;
			}
			Vector2 vector = inputHandlerSettings.InputHandler.GetVector2(axes);
			if (updatePitch)
			{
				deltaPitch = 0f - vector.y;
			}
			if (updateYaw)
			{
				deltaYaw = vector.x;
			}
			if (updateZoom)
			{
				deltaZoom = 0f - inputHandlerSettings.InputHandler.GetFloat(zoomAxis);
			}
			float fixedDeltaTime = Time.fixedDeltaTime;
			UpdateCamera(fixedDeltaTime);
		}

		private void OnTeleport(Vector3 position, Quaternion rotation)
		{
			viewReference.rotation = rotation;
			base.transform.rotation = viewReference.rotation;
			lerpedCharacterUp = characterActor.Up;
			previousLerpedCharacterUp = lerpedCharacterUp;
		}

		private void HandleBodyVisibility()
		{
			if (cameraMode == CameraMode.FirstPerson)
			{
				if (bodyRenderers == null)
				{
					return;
				}
				for (int i = 0; i < bodyRenderers.Length; i++)
				{
					if (bodyRenderers[i].GetType().IsSubclassOf(typeof(SkinnedMeshRenderer)))
					{
						SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)bodyRenderers[i];
						if (skinnedMeshRenderer != null)
						{
							skinnedMeshRenderer.forceRenderingOff = hideBody;
						}
					}
					else
					{
						bodyRenderers[i].enabled = !hideBody;
					}
				}
			}
			else
			{
				if (bodyRenderers == null)
				{
					return;
				}
				for (int j = 0; j < bodyRenderers.Length; j++)
				{
					if (bodyRenderers[j] == null)
					{
						continue;
					}
					if (bodyRenderers[j].GetType().IsSubclassOf(typeof(SkinnedMeshRenderer)))
					{
						SkinnedMeshRenderer skinnedMeshRenderer2 = (SkinnedMeshRenderer)bodyRenderers[j];
						if (skinnedMeshRenderer2 != null)
						{
							skinnedMeshRenderer2.forceRenderingOff = false;
						}
					}
					else
					{
						bodyRenderers[j].enabled = true;
					}
				}
			}
		}

		private void UpdateCamera(float dt)
		{
			HandleBodyVisibility();
			lerpedCharacterUp = targetTransform.up;
			Quaternion quaternion = Quaternion.FromToRotation(previousLerpedCharacterUp, lerpedCharacterUp);
			previousLerpedCharacterUp = lerpedCharacterUp;
			viewReference.rotation = quaternion * viewReference.rotation;
			viewReference.Rotate(lerpedCharacterUp, deltaYaw * yawSpeed * dt, Space.World);
			float num = Vector3.Angle(viewReference.forward, lerpedCharacterUp);
			float min = 0f - num + (90f - minPitchAngle);
			float max = 180f - num - (90f - maxPitchAngle);
			float angle = Mathf.Clamp(deltaPitch * pitchSpeed * dt, min, max);
			viewReference.Rotate(Vector3.right, angle);
			if (updateRoll)
			{
				viewReference.up = lerpedCharacterUp;
			}
			characterPosition = targetTransform.position;
			lerpedHeight = Mathf.Lerp(lerpedHeight, characterActor.BodySize.y, heightLerpSpeed * dt);
			Vector3 vector = characterPosition + targetTransform.up * lerpedHeight + targetTransform.TransformDirection(offsetFromHead);
			viewReference.position = vector;
			Vector3 position = viewReference.position;
			if (cameraMode == CameraMode.ThirdPerson)
			{
				currentDistanceToTarget += deltaZoom * zoomInOutSpeed * dt;
				currentDistanceToTarget = Mathf.Clamp(currentDistanceToTarget, minZoom, maxZoom);
				smoothedDistanceToTarget = Mathf.Lerp(smoothedDistanceToTarget, currentDistanceToTarget, zoomInOutLerpSpeed * dt);
				Vector3 displacement = -viewReference.forward * smoothedDistanceToTarget;
				if (collisionDetection)
				{
					bool flag = DetectCollisions(ref displacement, vector);
					if (collisionAffectsZoom && flag)
					{
						currentDistanceToTarget = (smoothedDistanceToTarget = displacement.magnitude);
					}
				}
				position = vector + displacement;
			}
			base.transform.position = position;
			base.transform.rotation = viewReference.rotation;
		}

		private bool DetectCollisions(ref Vector3 displacement, Vector3 lookAtPosition)
		{
			int num = Physics.SphereCastNonAlloc(lookAtPosition, detectionRadius, Vector3.Normalize(displacement), hitsBuffer, currentDistanceToTarget, layerMask, QueryTriggerInteraction.Ignore);
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit = hitsBuffer[i];
				Rigidbody attachedRigidbody = raycastHit.collider.attachedRigidbody;
				if (raycastHit.distance != 0f && (!(attachedRigidbody != null) || ((!considerKinematicRigidbodies || attachedRigidbody.isKinematic) && (!considerDynamicRigidbodies || !attachedRigidbody.isKinematic) && !(attachedRigidbody == characterRigidbody))))
				{
					validHits[num2] = raycastHit;
					num2++;
				}
			}
			if (num2 == 0)
			{
				return false;
			}
			float num3 = float.PositiveInfinity;
			for (int j = 0; j < num2; j++)
			{
				RaycastHit raycastHit2 = validHits[j];
				if (raycastHit2.distance < num3)
				{
					num3 = raycastHit2.distance;
				}
			}
			displacement = CustomUtilities.Multiply(Vector3.Normalize(displacement), num3);
			return true;
		}
	}
}
