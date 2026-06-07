using UnityEngine;

namespace Helios.GUI
{
	public class PanelDependency : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] otherPanels;

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}
	}
}
