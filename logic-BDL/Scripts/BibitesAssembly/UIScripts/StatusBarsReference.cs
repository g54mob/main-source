using ManagementScripts;
using SettingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class StatusBarsReference : MonoBehaviour
	{
		private GameObject target;

		private float healthRatio;

		[SerializeField]
		private Image healthBar;

		[SerializeField]
		public TextMeshProUGUI healthText;

		private float energyRatio;

		[SerializeField]
		private Image energyBar;

		[SerializeField]
		public TextMeshProUGUI energyText;

		private float offset = 25f;

		private float targetScale = 1f;

		private void Awake()
		{
			CameraManager.OnCameraZoomChange.AddListener(UpdatePlacement);
			UserSettings.ShowStatusBars.OnChange.AddListener(UpdateVisibility);
			base.gameObject.SetActive(value: false);
		}

		public void TargetThat(GameObject GO)
		{
			target = GO;
			if (GO != null)
			{
				targetScale = GO.transform.localScale.x;
			}
			UpdateVisibility();
			UpdatePlacement();
		}

		private void UpdateVisibility()
		{
			base.gameObject.SetActive(target != null && UserSettings.ShowStatusBars.val);
		}

		private void UpdatePlacement()
		{
			if (!(target == null))
			{
				float num = targetScale * 200f / CameraManager.camSize;
				base.transform.localScale = Vector3.one * num;
				base.transform.localPosition = new Vector3(0f, offset * num, 0f);
			}
		}

		public void UpdateHealth(float health, float maxHealth)
		{
			healthRatio = health / maxHealth;
			healthBar.fillAmount = healthRatio;
			healthText.text = $"{Mathf.Round(health)} / {Mathf.Round(maxHealth)}";
		}

		public void UpdateEnergy(float energy, float maxEnergy)
		{
			energyRatio = energy / maxEnergy;
			energyBar.fillAmount = energyRatio;
			energyText.text = $"{Mathf.Round(energy)} / {Mathf.Round(maxEnergy)}";
		}

		private void OnDestroy()
		{
			CameraManager.OnCameraZoomChange.RemoveListener(UpdatePlacement);
			UserSettings.ShowStatusBars.OnChange.RemoveListener(UpdateVisibility);
		}
	}
}
