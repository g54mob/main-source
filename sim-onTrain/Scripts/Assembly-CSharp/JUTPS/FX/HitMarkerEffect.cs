using JUTPS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.FX
{
	public class HitMarkerEffect : MonoBehaviour
	{
		public static HitMarkerEffect instance;

		private Image HitImage;

		private AudioSource HitSound;

		[Header("Hit Effect")]
		public bool EnableHitEffect = true;

		public AudioClip HitAudioClip;

		public string[] HitTags;

		public Color HitColor = Color.white;

		public float Speed = 5f;

		private Color ClearWhite = new Color(1f, 1f, 1f, 0f);

		[Header("Damage Count")]
		public bool ShowDamage;

		public AudioClip CriticalDamageAudioClip;

		public Text DamageText;

		public float CriticalHitMax = 50f;

		public float TextFadeSpeed = 3f;

		public Color NormalHitColor = Color.white;

		public Color CriticalHitColor = Color.red;

		private Vector3 HitDamagePosition;

		private float CurrentDamage;

		private void Awake()
		{
			instance = this;
			HitSound = GetComponent<AudioSource>();
			HitImage = GetComponent<Image>();
			if (DamageText != null)
			{
				DamageText.color = Color.clear;
			}
		}

		private void Update()
		{
			if (HitImage != null && EnableHitEffect)
			{
				HitImage.color = Color.Lerp(HitImage.color, ClearWhite, Speed * Time.deltaTime);
			}
			if (ShowDamage && DamageText != null && DamageText.color != ClearWhite)
			{
				UIElementToWorldPosition.SetUIWorldPosition(DamageText.gameObject, HitDamagePosition, Vector3.zero);
				DamageText.color = Color.Lerp(DamageText.color, ClearWhite, TextFadeSpeed * Time.deltaTime);
			}
		}

		private void Hit()
		{
			if (HitImage != null)
			{
				HitImage.color = HitColor;
				HitSound.PlayOneShot(HitAudioClip);
			}
			if (DamageText != null && ShowDamage)
			{
				bool flag = CurrentDamage > CriticalHitMax;
				DamageText.text = ((int)CurrentDamage).ToString();
				DamageText.color = (flag ? CriticalHitColor : NormalHitColor);
				if (CriticalDamageAudioClip != null && flag && HitSound != null)
				{
					HitSound.Stop();
					HitSound.PlayOneShot(CriticalDamageAudioClip);
				}
			}
		}

		public static void HitCheck(string CollidedObjectTag, string BulletOwnerTag, Vector3 hitPosition = default(Vector3), float Damage = 0f)
		{
			if (instance == null || BulletOwnerTag != "Player")
			{
				return;
			}
			string[] hitTags = instance.HitTags;
			foreach (string text in hitTags)
			{
				if (CollidedObjectTag == text)
				{
					instance.HitDamagePosition = hitPosition;
					instance.CurrentDamage = Damage;
					instance.Hit();
				}
			}
		}
	}
}
