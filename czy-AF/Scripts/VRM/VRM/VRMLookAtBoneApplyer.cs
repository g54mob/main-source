using UniGLTF;
using UnityEngine;

namespace VRM
{
	public class VRMLookAtBoneApplyer : MonoBehaviour, IVRMComponent
	{
		public bool DrawGizmo;

		[SerializeField]
		public OffsetOnTransform LeftEye;

		[SerializeField]
		public OffsetOnTransform RightEye;

		[SerializeField]
		[Header("Degree Mapping")]
		public CurveMapper HorizontalOuter = new CurveMapper(90f, 10f);

		[SerializeField]
		public CurveMapper HorizontalInner = new CurveMapper(90f, 10f);

		[SerializeField]
		public CurveMapper VerticalDown = new CurveMapper(90f, 10f);

		[SerializeField]
		public CurveMapper VerticalUp = new CurveMapper(90f, 10f);

		private VRMLookAtHead m_head;

		private const float SIZE = 0.5f;

		public void OnImported(VRMImporterContext context)
		{
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				LeftEye = OffsetOnTransform.Create(component.GetBoneTransform(HumanBodyBones.LeftEye));
				RightEye = OffsetOnTransform.Create(component.GetBoneTransform(HumanBodyBones.RightEye));
			}
			glTF_VRM_Firstperson firstPerson = context.GLTF.extensions.VRM.firstPerson;
			HorizontalInner.Apply(firstPerson.lookAtHorizontalInner);
			HorizontalOuter.Apply(firstPerson.lookAtHorizontalOuter);
			VerticalDown.Apply(firstPerson.lookAtVerticalDown);
			VerticalUp.Apply(firstPerson.lookAtVerticalUp);
		}

		private void OnValidate()
		{
			HorizontalInner.OnValidate();
			HorizontalOuter.OnValidate();
			VerticalUp.OnValidate();
			VerticalDown.OnValidate();
		}

		private void Start()
		{
			m_head = GetComponent<VRMLookAtHead>();
			if (m_head == null)
			{
				base.enabled = false;
				Debug.LogError("[VRMLookAtBoneApplyer]VRMLookAtHead not found");
			}
			else
			{
				m_head.YawPitchChanged += ApplyRotations;
				LeftEye.Setup();
				RightEye.Setup();
			}
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
			if (DrawGizmo && ((LeftEye.Transform != null) & (RightEye.Transform != null)))
			{
				DrawMatrix(LeftEye.WorldMatrix, 0.5f);
				DrawMatrix(RightEye.WorldMatrix, 0.5f);
			}
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
				LeftEye.Transform.rotation = LeftEye.InitialWorldMatrix.ExtractRotation() * Matrix4x4.identity.YawPitchRotation(yaw2, pitch);
				RightEye.Transform.rotation = RightEye.InitialWorldMatrix.ExtractRotation() * Matrix4x4.identity.YawPitchRotation(yaw3, pitch);
			}
		}
	}
}
