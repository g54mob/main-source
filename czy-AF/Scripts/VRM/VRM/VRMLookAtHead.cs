using System;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	public class VRMLookAtHead : MonoBehaviour, IVRMComponent
	{
		public bool DrawGizmo = true;

		[SerializeField]
		public UpdateType UpdateType = UpdateType.Update;

		[SerializeField]
		public Transform Target;

		[SerializeField]
		public Transform Head;

		[SerializeField]
		[Header("Debug")]
		private float m_yaw;

		[SerializeField]
		private float m_pitch;

		public Matrix4x4 YawMatrix
		{
			get
			{
				Quaternion q = Quaternion.AngleAxis(m_yaw, Vector3.up);
				Matrix4x4 result = default(Matrix4x4);
				result.SetTRS(Vector3.zero, q, Vector3.one);
				return result;
			}
		}

		public float Yaw => m_yaw;

		public float Pitch => m_pitch;

		public event Action<float, float> YawPitchChanged;

		public Texture2D CreateThumbnail()
		{
			Texture2D texture2D = new Texture2D(2048, 2048);
			GameObject gameObject = new GameObject("ThumbCamera");
			Camera camera = gameObject.AddComponent<Camera>();
			CreateThumbnail(camera, texture2D);
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
			return texture2D;
		}

		private void CreateThumbnail(Camera camera, Texture2D dst)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture obj = (RenderTexture.active = (camera.targetTexture = new RenderTexture(dst.width, dst.height, 24)));
			LookFace(camera.transform);
			camera.Render();
			dst.ReadPixels(new Rect(0f, 0f, dst.width, dst.height), 0, 0);
			RenderTexture.active = active;
			camera.targetTexture = null;
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(obj);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
		}

		public void LookFace(Transform t)
		{
			if (!(Head == null))
			{
				Vector3 vector = Head.position + new Vector3(0f, 0.05f, 0f);
				t.position = vector + Head.localToWorldMatrix.ExtractRotation() * new Vector3(0f, 0f, 0.7f);
				t.LookAt(vector);
			}
		}

		private void Awake()
		{
			Animator component = GetComponent<Animator>();
			if (component == null)
			{
				Debug.LogWarning("animator is not found");
				return;
			}
			Transform boneTransform = component.GetBoneTransform(HumanBodyBones.Head);
			if (boneTransform == null)
			{
				Debug.LogWarning("head is not found");
			}
			else
			{
				Head = boneTransform;
			}
		}

		public void OnImported(VRMImporterContext context)
		{
			switch (context.GLTF.extensions.VRM.firstPerson.lookAtType)
			{
			case LookAtType.Bone:
				base.gameObject.AddComponent<VRMLookAtBoneApplyer>().OnImported(context);
				break;
			case LookAtType.BlendShape:
				base.gameObject.AddComponent<VRMLookAtBlendShapeApplyer>().OnImported(context);
				break;
			}
		}

		private static Matrix4x4 LookAtMatrixFromWorld(Vector3 from, Vector3 target)
		{
			return LookAtMatrix(UnityExtensions.Matrix4x4FromColumns(c3: new Vector4(from.x, from.y, from.z, 1f), c0: Vector3.right, c1: Vector3.up, c2: Vector3.forward), target);
		}

		private static Matrix4x4 LookAtMatrix(Vector3 up_vector, Vector3 localPosition)
		{
			Vector3 normalized = localPosition.normalized;
			Vector3 normalized2 = Vector3.Cross(up_vector, normalized).normalized;
			Vector3 normalized3 = Vector3.Cross(normalized, normalized2).normalized;
			return UnityExtensions.Matrix4x4FromColumns(normalized2, normalized3, normalized, new Vector4(0f, 0f, 0f, 1f));
		}

		private static Matrix4x4 LookAtMatrix(Matrix4x4 m, Vector3 target)
		{
			return LookAtMatrix(Vector3.up, m.inverse.MultiplyPoint(target));
		}

		public void RaiseYawPitchChanged(float yaw, float pitch)
		{
			m_yaw = yaw;
			m_pitch = pitch;
			this.YawPitchChanged?.Invoke(yaw, pitch);
		}

		private void Update()
		{
			if (Head == null)
			{
				base.enabled = false;
			}
			else if (UpdateType == UpdateType.Update)
			{
				LookWorldPosition();
			}
		}

		private void LateUpdate()
		{
			if (Head == null)
			{
				base.enabled = false;
			}
			else if (UpdateType == UpdateType.LateUpdate)
			{
				LookWorldPosition();
			}
		}

		public void LookWorldPosition()
		{
			if (!(Target == null))
			{
				LookWorldPosition(Target.position, out var _, out var _);
			}
		}

		public void LookWorldPosition(Vector3 targetPosition, out float yaw, out float pitch)
		{
			Vector3 target = Head.worldToLocalMatrix.MultiplyPoint(targetPosition);
			Matrix4x4.identity.CalcYawPitch(target, out yaw, out pitch);
			RaiseYawPitchChanged(yaw, pitch);
		}
	}
}
