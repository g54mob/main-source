using UnityEngine;

namespace LayerLab.FantasyRPG
{
	public class PanelFantasyRPG : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] otherPanels;

		public void OnEnable()
		{
			for (int i = 0; i < otherPanels.Length; i++)
			{
				otherPanels[i].SetActive(value: true);
			}
		}

		public void OnDisable()
		{
			for (int i = 0; i < otherPanels.Length; i++)
			{
				otherPanels[i].SetActive(value: false);
			}
		}
	}
}
