using System.Collections;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using I2.Loc;
using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class OrePenaltyScreen : MonoBehaviour
	{
		public UILabel Label;

		public UITexture Icon;

		public UITexture TankTexture;

		public ParticleSystem ParticleSystem;

		public string PenaltySound;

		public string LoseOreSound;

		public void Init(OreReceivable penalty)
		{
			string value = LabelHelper.Orange + Mathf.Abs(penalty.Amount);
			string translation = LocalizationManager.GetTermTranslation("GalaxyMap/YouLostAmount");
			LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", value);
			Label.text = LabelHelper.LightGrey + translation;
			Icon.mainTexture = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(penalty.Reward).Icon;
			TankTexture.fillAmount = 1f;
			StartCoroutine(FillTankTexture());
			if (!PenaltySound.IsNullOrWhitespace())
			{
				AudioController.Play(PenaltySound);
			}
			if (!LoseOreSound.IsNullOrWhitespace())
			{
				AudioController.Play(LoseOreSound);
			}
		}

		private IEnumerator FillTankTexture()
		{
			bool isPlaying = false;
			ParticleSystem.EmissionModule emission = ParticleSystem.emission;
			emission.enabled = false;
			do
			{
				TankTexture.fillAmount -= Time.smoothDeltaTime * 0.15f;
				yield return true;
				if (TankTexture.fillAmount <= 0.93f && !isPlaying)
				{
					isPlaying = true;
					emission.enabled = true;
				}
			}
			while (!(TankTexture.fillAmount <= 0.63f));
			emission.enabled = false;
		}
	}
}
