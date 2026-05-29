using UnityEngine;

namespace CTS
{
	public class CameraMenuParticles : MonoBehaviour
	{
		private void Awake()
		{
			MenusManager.OnMainMenuShown += OnMainMenu;
			base.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			MenusManager.OnMainMenuShown -= OnMainMenu;
		}

		private void OnMainMenu(bool p_active)
		{
			base.gameObject.SetActive(p_active);
		}
	}
}
