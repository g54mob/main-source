using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.UI
{
	[AddComponentMenu("JU TPS/UI/UI Health Bar")]
	public class UIHealhBar : MonoBehaviour
	{
		[Header("UI Health Bar Settings")]
		[SerializeField]
		private JUHealth HealthComponent;

		[SerializeField]
		private bool IsPlayerHealthBar = true;

		[SerializeField]
		private Image HealthBarImage;

		[SerializeField]
		private float Speed = 6f;

		[SerializeField]
		private Text HealthPointsText;

		[Header("Health Bar Color Change")]
		[SerializeField]
		private Color EmptyHPColor = Color.red;

		[SerializeField]
		private Color FullHPColor = Color.green;

		[SerializeField]
		private Color HPHealingColor = Color.cyan;

		[SerializeField]
		private Color HPLossColor = Color.yellow;

		[SerializeField]
		private bool ChangeHPTextColorToo = true;

		private float oldFillAmount;

		private bool isInitialized;

		private void OnEnable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		}

		private void OnDisable()
		{
			Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.RemoveListener(Initialize);
		}

		private void Initialize(TSPlayerController tsPlayer)
		{
			if (isInitialized)
			{
				isInitialized = true;
				return;
			}
			if (IsPlayerHealthBar)
			{
				GameObject gameObject = tsPlayer.gameObject;
				HealthComponent = gameObject.GetComponent<JUHealth>();
			}
			oldFillAmount = HealthBarImage.fillAmount;
		}

		private void Update()
		{
			if (HealthComponent == null || HealthBarImage == null)
			{
				return;
			}
			float target = HealthComponent.Health / HealthComponent.MaxHealth;
			HealthBarImage.fillAmount = Mathf.MoveTowards(HealthBarImage.fillAmount, target, Speed * Time.deltaTime);
			HealthBarImage.color = Color.Lerp(EmptyHPColor, FullHPColor, HealthBarImage.fillAmount);
			if (HealthPointsText != null)
			{
				HealthPointsText.text = HealthComponent.Health.ToString("000") + "/" + HealthComponent.MaxHealth;
				if (ChangeHPTextColorToo)
				{
					HealthPointsText.color = Color.Lerp(HealthBarImage.color, Color.white, 0.6f);
				}
			}
			if (oldFillAmount != HealthBarImage.fillAmount)
			{
				if (oldFillAmount < HealthBarImage.fillAmount)
				{
					HealthBarImage.color = HPHealingColor;
				}
				if (oldFillAmount > HealthBarImage.fillAmount)
				{
					HealthBarImage.color = HPLossColor;
				}
				oldFillAmount = HealthBarImage.fillAmount;
			}
		}
	}
}
