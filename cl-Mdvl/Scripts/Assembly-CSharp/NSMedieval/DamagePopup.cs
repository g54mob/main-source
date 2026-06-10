using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.DevConsole;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval
{
	public class DamagePopup : MonoBehaviour
	{
		private static GameObject critHitPfrefab;

		private const float YMoveSpeed = 8f;

		private const float DisappearSpeed = 3f;

		private const float DisappearTimerMax = 2.6f;

		private const float IncreaseScaleAmount = 0f;

		private TextMeshPro textMesh;

		private float disappearTimer;

		private Color color;

		private Vector3 moveVector;

		private Camera mainCamera;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			critHitPfrefab = null;
		}

		private void Start()
		{
			mainCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera;
		}

		public static void Create(CombatHitInfo info, Vector3 position)
		{
			if (!DeveloperVariables.ShowCombatNumbers)
			{
				return;
			}
			GenerateContent(info, out var text, out var color);
			if (!(text == string.Empty))
			{
				if (info.Critical && (bool)critHitPfrefab)
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("crithit", position);
				}
				else
				{
					Create(position, text, color);
				}
			}
		}

		public static void GenerateContent(CombatHitInfo info, out string text, out Color color)
		{
			if (info.Damage <= 0f && info.ArmorDamage <= 0f)
			{
				text = string.Empty;
				color = default(Color);
			}
			else if (info.HasBlocked)
			{
				text = AssetUtils.GetSpriteAsset("blocked") + "   ";
				color = Color.red;
			}
			else if (info.Critical)
			{
				text = string.Format("{0} {1}", AssetUtils.GetSpriteAsset("critical_strike"), Mathf.CeilToInt(info.Damage));
				color = Color.red;
			}
			else
			{
				text = Mathf.CeilToInt(info.Damage).ToString();
				color = default(Color);
			}
		}

		public static string GenerateMissContent(CombatMissType missType)
		{
			return missType switch
			{
				CombatMissType.Evade => MonoSingleton<LocalizationController>.Instance.GetText("general_evade"), 
				CombatMissType.Other => string.Empty, 
				_ => MonoSingleton<LocalizationController>.Instance.GetText("general_miss"), 
			};
		}

		public static DamagePopup Create(Vector3 position, string text)
		{
			DamagePopup component = Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("DamagePopup"), position, Quaternion.identity).transform.GetComponent<DamagePopup>();
			component.Setup(text);
			return component;
		}

		public static DamagePopup Create(Vector3 position, string text, Color color)
		{
			DamagePopup damagePopup = Create(position, text);
			damagePopup.SetColor(color);
			return damagePopup;
		}

		public void Setup(string text)
		{
			textMesh.SetText(text);
			color = textMesh.color;
			disappearTimer = 2.6f;
			moveVector = new Vector3(0f, 1.2f) * 8f;
		}

		public void SetColor(Color c)
		{
			color = c;
			textMesh.color = c;
		}

		private void Update()
		{
			if (!(base.transform == null) && !(mainCamera == null) && !(mainCamera.transform == null))
			{
				base.transform.position += moveVector * Time.unscaledDeltaTime;
				moveVector -= moveVector * (3f * Time.unscaledDeltaTime);
				if (disappearTimer > 1.3f)
				{
					base.transform.localScale += Vector3.one * (0f * Time.unscaledDeltaTime);
				}
				else
				{
					base.transform.localScale -= Vector3.one * (0f * Time.unscaledDeltaTime);
				}
				disappearTimer -= Time.unscaledDeltaTime;
				if (disappearTimer < 0f)
				{
					color.a -= 3f * Time.unscaledDeltaTime;
					textMesh.color = color;
				}
				if (color.a <= 0f)
				{
					Object.Destroy(base.gameObject);
					return;
				}
				Quaternion rotation = mainCamera.transform.rotation;
				base.transform.LookAt(base.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
			}
		}

		private void Awake()
		{
			textMesh = base.transform.GetComponent<TextMeshPro>();
		}
	}
}
