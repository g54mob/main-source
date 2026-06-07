using Assets.Nimbatus.Scripts.Behaviours.Health;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelEvents
{
	public class ShieldHealthIndicator : MonoBehaviour
	{
		public HealthPool HealthPool;

		public UILabel NimbatusLabel;

		public UILabel HealthLabel;

		public UITexture HealthbarBackground;

		public UITexture Healthbar;

		public Gradient Gradient;

		private void Start()
		{
			if (NimbatusLabel != null)
			{
				NimbatusLabel.text = LocalizationManager.GetTermTranslation("MainScene/ShieldStatus");
			}
		}

		private void Update()
		{
			if (!(HealthPool == null) && !(HealthLabel == null) && !(HealthbarBackground == null) && !(Healthbar == null))
			{
				float num = Mathf.Clamp01(HealthPool.CurrentHealth / HealthPool.ActiveMaxHealth);
				HealthLabel.text = "(" + Mathf.FloorToInt(num * 100f) + "%)";
				Healthbar.width = Mathf.RoundToInt((float)HealthbarBackground.width * num);
				Healthbar.color = Gradient.Evaluate(num);
			}
		}
	}
}
