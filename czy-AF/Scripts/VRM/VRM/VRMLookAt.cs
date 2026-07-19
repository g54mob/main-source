using System;
using System.Collections.Generic;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	[Obsolete("Use VRMLookAtHead")]
	public class VRMLookAt : MonoBehaviour
	{
		public bool DrawGizmo = true;

		[SerializeField]
		public bool UseUpdate = true;

		[SerializeField]
		public Transform Target;

		[SerializeField]
		public OffsetOnTransform LeftEye;

		[SerializeField]
		public OffsetOnTransform RightEye;

		[SerializeField]
		public OffsetOnTransform Head;

		[SerializeField]
		[Header("Degree Mapping")]
		public CurveMapper HorizontalOuter = new CurveMapper(90f, 10f);

		[SerializeField]
		public CurveMapper HorizontalInner = new CurveMapper(90f, 10f);

		[SerializeField]
		public CurveMapper VerticalDown = new CurveMapper(90f, 10f);

		[SerializeField]
		public CurveMapper VerticalUp = new CurveMapper(90f, 10f);

		private const float SIZE = 0.5f;

		[SerializeField]
		[Header("Debug")]
		public float Yaw;

		public float Pitch;

		public Matrix4x4 YawMatrix
		{
			get
			{
				Quaternion q = Quaternion.AngleAxis(Yaw, Head.OffsetRotation.GetColumn(1));
				Matrix4x4 result = default(Matrix4x4);
				result.SetTRS(Vector3.zero, q, Vector3.one);
				return result;
			}
		}

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
			if (!(Head.Transform == null))
			{
				Vector3 vector = Head.Transform.position + new Vector3(0f, 0.05f, 0f);
				t.position = vector + Head.WorldMatrix.ExtractRotation() * new Vector3(0f, 0f, 0.7f);
				t.LookAt(vector);
			}
		}

		public void CopyTo(GameObject _dst, Dictionary<Transform, Transform> map)
		{
			VRMLookAt vRMLookAt = _dst.AddComponent<VRMLookAt>();
			vRMLookAt.Target = Target;
			vRMLookAt.Head = OffsetOnTransform.Create(map[Head.Transform]);
			vRMLookAt.RightEye = OffsetOnTransform.Create(map[RightEye.Transform]);
			vRMLookAt.LeftEye = OffsetOnTransform.Create(map[LeftEye.Transform]);
			vRMLookAt.HorizontalOuter = HorizontalOuter;
			vRMLookAt.HorizontalInner = HorizontalInner;
			vRMLookAt.VerticalDown = VerticalDown;
			vRMLookAt.VerticalUp = VerticalUp;
		}

		private void Reset()
		{
			Target = Camera.main.transform;
			GetBones();
		}

		private void OnValidate()
		{
			HorizontalInner.OnValidate();
			HorizontalOuter.OnValidate();
			VerticalUp.OnValidate();
			VerticalDown.OnValidate();
		}

		public void GetBones()
		{
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				LeftEye = OffsetOnTransform.Create(component.GetBoneTransform(HumanBodyBones.LeftEye));
				RightEye = OffsetOnTransform.Create(component.GetBoneTransform(HumanBodyBones.RightEye));
				Head = OffsetOnTransform.Create(component.GetBoneTransform(HumanBodyBones.Head));
			}
		}

		private void Awake()
		{
			Head.Setup();
			LeftEye.Setup();
			RightEye.Setup();
		}

		private static void DrawMatrix(Matrix4x4 m, float size)
		{
			Gizmos.matrix = m;
			Gizmos.color = Color.red;
			Gizmos.DrawLine(Vector3.zero, Vector3.right * size);
			Gizmos.color = Color.green;
			Gizmos.DrawLine(Vector3.zero, Vector3.up * size);
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(Vector3.zero, Vector3.forward * size);
		}

		private void OnDrawGizmos()
		{
			if (DrawGizmo)
			{
				if ((LeftEye.Transform != null) & (RightEye.Transform != null))
				{
					DrawMatrix(LeftEye.WorldMatrix, 0.5f);
					DrawMatrix(RightEye.WorldMatrix, 0.5f);
				}
				else
				{
					DrawMatrix(Head.WorldMatrix, 0.5f);
				}
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

		private void LateUpdate()
		{
			if (UseUpdate && !(Target == null))
			{
				LookWorldPosition(Target.position);
			}
		}

		public void LookWorldPosition(Vector3 targetPosition)
		{
			Vector3 target = Head.InitialWorldMatrix.inverse.MultiplyPoint(targetPosition);
			Head.OffsetRotation.CalcYawPitch(target, out Yaw, out Pitch);
			ApplyRotations(Yaw, Pitch);
		}

		private void ApplyRotations(float yaw, float pitch)
		{
			float yaw2;
			float yaw3;
			if (yaw < 0f)
			{
				yaw2 = 0f - HorizontalOuter.Map(0f - yaw);
				yaw3 = 0f - HorizontalInner.Map(0f - yaw);
			}
			else
			{
				yaw3 = HorizontalOuter.Map(yaw);
				yaw2 = HorizontalInner.Map(yaw);
			}
			pitch = ((!(pitch < 0f)) ? VerticalUp.Map(pitch) : (0f - VerticalDown.Map(0f - pitch)));
			if (LeftEye.Transform != null && RightEye.Transform != null)
			{
				LeftEye.Transform.rotation = LeftEye.InitialWorldMatrix.ExtractRotation() * Head.OffsetRotation.YawPitchRotation(yaw2, pitch);
				RightEye.Transform.rotation = RightEye.InitialWorldMatrix.ExtractRotation() * Head.OffsetRotation.YawPitchRotation(yaw3, pitch);
			}
			else if (Head.Transform != null)
			{
				Head.Transform.rotation = Head.InitialWorldMatrix.ExtractRotation() * Head.OffsetRotation.YawPitchRotation(yaw, pitch);
			}
		}
	}
}
