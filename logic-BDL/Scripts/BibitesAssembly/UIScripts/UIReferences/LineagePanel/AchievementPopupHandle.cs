using System.Collections;
using ManagementScripts;
using OneUseScripts;
using SteamIntegrations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIScripts.UIReferences.LineagePanel
{
	public class AchievementPopupHandle : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public static AchievementPopupHandle instance;

		public Image icon;

		public TextMeshProUGUI title;

		public TextMeshProUGUI desc;

		private CanvasGroup cG;

		private RectTransform rt;

		private WaitForSecondsRealtime initialWait = new WaitForSecondsRealtime(5f);

		private bool hasInit;

		private Coroutine disapearing;

		private Camera cam;

		private GameObject unlockSource;

		private void Awake()
		{
			if (!hasInit)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			instance = this;
			if (!hasInit)
			{
				rt = GetComponent<RectTransform>();
				cG = GetComponent<CanvasGroup>();
				cam = UICamera.cam;
				base.gameObject.SetActive(value: false);
				hasInit = true;
			}
		}

		public void UnlockAchievement(Achievement unlockedAchievement, GameObject source = null)
		{
			if (!SteamManager.isDemo)
			{
				if (!hasInit)
				{
					Initialize();
				}
				unlockSource = source;
				icon.sprite = unlockedAchievement.spriteAchieved;
				title.text = unlockedAchievement.title;
				desc.text = unlockedAchievement.desc;
				base.gameObject.SetActive(value: true);
				if (disapearing != null)
				{
					StopCoroutine(disapearing);
				}
				disapearing = StartCoroutine("WaitAndFadeOut");
			}
		}

		private IEnumerator WaitAndFadeOut()
		{
			cG.alpha = 1f;
			float alpha = 1f;
			yield return initialWait;
			while (alpha > 0f)
			{
				if (!base.gameObject.activeSelf)
				{
					yield break;
				}
				RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, cam, out var localPoint);
				localPoint /= rt.rect.size;
				alpha = ((!(localPoint.x < -1f) && !(localPoint.x > 0f) && !(localPoint.y < 0f) && !(localPoint.y > 1f)) ? 1f : (alpha - Time.unscaledDeltaTime / 2f));
				cG.alpha = Mathf.Clamp01(alpha);
				yield return null;
			}
			base.gameObject.SetActive(value: false);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!(unlockSource == null) && !(UserControl.Instance == null))
			{
				UserControl.Instance.SelectTarget(unlockSource);
			}
		}
	}
}
