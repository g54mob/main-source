using HQFPSTemplate.Equipment;
using UnityEngine;

namespace HQFPSTemplate.Examples
{
	[RequireComponent(typeof(FPArmsHandler))]
	public class ChangeArmsSkin : MonoBehaviour
	{
		[BHeader("Demo", true)]
		[SerializeField]
		private bool m_EnableChangeArms;

		[SerializeField]
		[ShowIf("m_EnableChangeArms", true, 10f)]
		private KeyCode m_ChangeArmsKey = KeyCode.P;

		private int m_SelectedArmsIndex = -1;

		private FPArmsHandler m_FPArmsHandler;

		private void Start()
		{
			m_FPArmsHandler = GetComponent<FPArmsHandler>();
			m_FPArmsHandler.UpdateArms(ref m_SelectedArmsIndex);
		}

		private void Update()
		{
			if (m_EnableChangeArms && Input.GetKeyDown(m_ChangeArmsKey))
			{
				m_FPArmsHandler.UpdateArms(ref m_SelectedArmsIndex);
			}
		}
	}
}
