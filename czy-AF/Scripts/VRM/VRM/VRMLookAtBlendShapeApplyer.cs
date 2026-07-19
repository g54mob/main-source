using UnityEngine;

namespace VRM
{
	public class VRMLookAtBlendShapeApplyer : MonoBehaviour, IVRMComponent
	{
		public bool DrawGizmo = true;

		[SerializeField]
		[Header("Degree Mapping")]
		public CurveMapper Horizontal = new CurveMapper(90f, 1f);

		[SerializeField]
		public CurveMapper VerticalDown = new CurveMapper(90f, 1f);

		[SerializeField]
		public CurveMapper VerticalUp = new CurveMapper(90f, 1f);

		[SerializeField]
		public bool m_notSetValueApply = true;

		private VRMLookAtHead m_head;

		private VRMBlendShapeProxy m_proxy;

		public void OnImported(VRMImporterContext context)
		{
			glTF_VRM_Firstperson firstPerson = context.GLTF.extensions.VRM.firstPerson;
			Horizontal.Apply(firstPerson.lookAtHorizontalOuter);
			VerticalDown.Apply(firstPerson.lookAtVerticalDown);
			VerticalUp.Apply(firstPerson.lookAtVerticalUp);
		}

		private void Start()
		{
			m_head = GetComponent<VRMLookAtHead>();
			m_proxy = GetComponent<VRMBlendShapeProxy>();
			if (m_head == null)
			{
				base.enabled = false;
			}
			else
			{
				m_head.YawPitchChanged += ApplyRotations;
			}
		}

		private void ApplyRotations(float yaw, float pitch)
		{
			if (yaw < 0f)
			{
				m_proxy.SetValue(BlendShapePreset.LookRight, 0f, !m_notSetValueApply);
				m_proxy.SetValue(BlendShapePreset.LookLeft, Mathf.Clamp(Horizontal.Map(0f - yaw), 0f, 1f), !m_notSetValueApply);
			}
			else
			{
				m_proxy.SetValue(BlendShapePreset.LookLeft, 0f, !m_notSetValueApply);
				m_proxy.SetValue(BlendShapePreset.LookRight, Mathf.Clamp(Horizontal.Map(yaw), 0f, 1f), !m_notSetValueApply);
			}
			if (pitch < 0f)
			{
				m_proxy.SetValue(BlendShapePreset.LookUp, 0f, !m_notSetValueApply);
				m_proxy.SetValue(BlendShapePreset.LookDown, Mathf.Clamp(VerticalDown.Map(0f - pitch), 0f, 1f), !m_notSetValueApply);
			}
			else
			{
				m_proxy.SetValue(BlendShapePreset.LookDown, 0f, !m_notSetValueApply);
				m_proxy.SetValue(BlendShapePreset.LookUp, Mathf.Clamp(VerticalUp.Map(pitch), 0f, 1f), !m_notSetValueApply);
			}
		}
	}
}
