using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class CartridgeObject : MonoBehaviour
	{
		[SerializeField]
		private string m_FOVProperty = "_FOV";

		[Space]
		[SerializeField]
		private MeshRenderer m_ObjectToDisable;

		[SerializeField]
		private MeshRenderer m_ObjectToEnable;

		public void ChangeState(bool enable)
		{
			if ((bool)m_ObjectToDisable)
			{
				m_ObjectToDisable.enabled = enable;
			}
			if ((bool)m_ObjectToEnable)
			{
				m_ObjectToEnable.enabled = !enable;
			}
		}

		public void SetFOV(float fov)
		{
			if ((bool)m_ObjectToDisable)
			{
				m_ObjectToDisable.sharedMaterial.SetFloat(m_FOVProperty, fov);
			}
			if ((bool)m_ObjectToEnable)
			{
				m_ObjectToEnable.sharedMaterial.SetFloat(m_FOVProperty, fov);
			}
		}
	}
}
