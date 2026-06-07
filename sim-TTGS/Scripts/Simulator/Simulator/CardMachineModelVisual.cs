using UnityEngine;

namespace Simulator
{
	public class CardMachineModelVisual : MonoBehaviour
	{
		[SerializeField]
		private Transform m_ButtonContainer;

		private Outline[] m_outlines;

		private void OnEnable()
		{
			m_outlines = m_ButtonContainer.GetComponentsInChildren<Outline>();
			HighLightIndex(-1);
		}

		public void HighLightIndex(int index)
		{
			for (int i = 0; i < m_outlines.Length; i++)
			{
				m_outlines[i].enabled = index == i;
			}
		}
	}
}
