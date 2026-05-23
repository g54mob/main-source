using UnityEngine;

namespace LVA.Puppeteers.Humanoid
{
	public class MeshEnableManagement : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer[] m_meshRenderers;

		[SerializeField]
		private bool m_enable;

		private bool rlt;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
