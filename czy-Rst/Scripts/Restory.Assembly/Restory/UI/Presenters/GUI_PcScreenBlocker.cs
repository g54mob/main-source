using UnityEngine;

namespace Restory.UI.Presenters
{
	public class GUI_PcScreenBlocker : MonoBehaviour
	{
		public bool IsActive => base.gameObject.activeSelf;

		public void Activate()
		{
			base.gameObject.SetActive(value: true);
		}

		public void Deactivate()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
