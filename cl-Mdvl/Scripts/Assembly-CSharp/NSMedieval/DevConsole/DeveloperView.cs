using UnityEngine;

namespace NSMedieval.DevConsole
{
	public abstract class DeveloperView : MonoBehaviour
	{
		public abstract void SetupPanel(DeveloperPanelCategory category);

		public abstract void SetActive(bool active);

		public abstract void Reset();
	}
}
