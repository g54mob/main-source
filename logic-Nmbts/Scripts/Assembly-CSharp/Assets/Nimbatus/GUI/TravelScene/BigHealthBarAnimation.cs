using System.Collections;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class BigHealthBarAnimation : MonoBehaviour
	{
		public UILabel HealthLabel;

		public UISprite HealthBar;

		public UISprite DifferenceBar;

		public UISprite Seperator;

		public GameObject CorpLaser;

		private float _currentHealth = 1f;

		private float _healthPenalty;

		public void Init(int hp)
		{
			int maxHealth = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			float num = 0.1f;
			float num2 = (float)maxHealth + (float)(maxHealth - 1) * num;
			float num3 = (float)Seperator.width / num2 * num;
			float num4 = (float)Seperator.width / num2;
			for (int i = 0; i < maxHealth - 1; i++)
			{
				UISprite component = Object.Instantiate(Seperator.gameObject, Seperator.transform.position, Seperator.transform.rotation).GetComponent<UISprite>();
				component.transform.parent = base.transform;
				component.transform.localScale = Vector3.one;
				component.width = Mathf.CeilToInt(num3);
				if (i == 0)
				{
					component.transform.localPosition += new Vector3(num4, 0f, 0f);
				}
				else
				{
					component.transform.localPosition += new Vector3(num4 * (float)(i + 1) + num3 * (float)i, 0f, 0f);
				}
			}
			Object.Destroy(Seperator.gameObject);
			_healthPenalty = (float)Mathf.Abs(hp) / (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			_currentHealth = (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth / (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			HealthLabel.text = LocalizationManager.GetTermTranslation("CampaignMode/Hull") + ": " + LabelHelper.Orange + SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth;
			HealthBar.fillAmount = _currentHealth;
			DifferenceBar.fillAmount = HealthBar.fillAmount;
		}

		public IEnumerator StartHealthBarAnimation()
		{
			yield return null;
		}

		public IEnumerator ShootCorpWeapon()
		{
			CorpLaser.SetActive(true);
			_currentHealth -= _healthPenalty;
			yield return new WaitForSeconds(1f);
			CorpLaser.SetActive(false);
		}

		public void Update()
		{
			_currentHealth = Mathf.Clamp01(_currentHealth);
			HealthLabel.text = LocalizationManager.GetTermTranslation("CampaignMode/Hull") + ": " + LabelHelper.Orange + Mathf.RoundToInt(_currentHealth * (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth);
			HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, _currentHealth, Time.deltaTime * 5f);
			DifferenceBar.fillAmount = Mathf.Lerp(DifferenceBar.fillAmount, HealthBar.fillAmount, Time.deltaTime * 2f);
		}
	}
}
