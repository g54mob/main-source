using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[ExecuteInEditMode]
	[AddComponentMenu("Heat UI/Input/Hotkey Event")]
	public class HotkeyEvent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public enum HotkeyType
		{
			Dynamic = 0,
			Custom = 1
		}

		public HotkeyType hotkeyType = HotkeyType.Custom;

		public ControllerPreset controllerPreset;

		public InputAction hotkey;

		public string keyID = "Escape";

		public string hotkeyLabel = "Exit";

		[SerializeField]
		private GameObject iconParent;

		[SerializeField]
		private GameObject textParent;

		[SerializeField]
		private Image iconObj;

		[SerializeField]
		private TextMeshProUGUI labelObj;

		[SerializeField]
		private TextMeshProUGUI textObj;

		[SerializeField]
		private CanvasGroup normalCG;

		[SerializeField]
		private CanvasGroup highlightCG;

		public bool useSounds;

		public bool useLocalization = true;

		[Range(1f, 15f)]
		public float fadingMultiplier = 8f;

		public UnityEvent onHotkeyPress = new UnityEvent();

		private bool isInitialized;

		public bool useCooldown;

		public static bool isInCooldown;

		private void OnEnable()
		{
			if (!isInitialized)
			{
				Initialize();
			}
			UpdateUI();
		}

		private void Update()
		{
			if (Application.isPlaying && hotkey.triggered && !useCooldown)
			{
				onHotkeyPress.Invoke();
			}
			else if (Application.isPlaying && hotkey.triggered && useCooldown && !isInCooldown)
			{
				onHotkeyPress.Invoke();
				StopCoroutine("StartCooldown");
				StartCoroutine("StartCooldown");
			}
		}

		private void Initialize()
		{
			hotkey.Enable();
			if (hotkeyType == HotkeyType.Dynamic && base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			if (ControllerManager.instance != null && hotkeyType == HotkeyType.Dynamic)
			{
				ControllerManager.instance.hotkeyObjects.Add(this);
				controllerPreset = ControllerManager.instance.currentControllerPreset;
			}
			if (useLocalization)
			{
				LocalizedObject localizedObject = base.gameObject.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
				else if (localizedObject != null && !string.IsNullOrEmpty(localizedObject.localizationKey))
				{
					hotkeyLabel = localizedObject.GetKeyOutput(localizedObject.localizationKey);
					localizedObject.onLanguageChanged.AddListener(delegate
					{
						hotkeyLabel = localizedObject.GetKeyOutput(localizedObject.localizationKey);
						SetLabel(hotkeyLabel);
					});
				}
			}
			if (UIManagerAudio.instance == null)
			{
				useSounds = false;
			}
			if (useSounds)
			{
				onHotkeyPress.AddListener(delegate
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
				});
			}
			isInitialized = true;
		}

		public void UpdateUI()
		{
			if (hotkeyType == HotkeyType.Custom)
			{
				return;
			}
			if (hotkeyType == HotkeyType.Dynamic)
			{
				if (controllerPreset == null)
				{
					return;
				}
				if (highlightCG != null)
				{
					highlightCG.alpha = 0f;
				}
				bool flag = false;
				for (int i = 0; i < controllerPreset.items.Count; i++)
				{
					if (!(controllerPreset.items[i].itemID == keyID))
					{
						continue;
					}
					flag = true;
					base.gameObject.SetActive(value: true);
					if (labelObj != null)
					{
						labelObj.text = hotkeyLabel;
					}
					if (controllerPreset.items[i].itemType == ControllerPreset.ItemType.Icon)
					{
						if (iconParent != null)
						{
							iconParent.SetActive(value: true);
						}
						if (textParent != null)
						{
							textParent.SetActive(value: false);
						}
						if (iconObj != null)
						{
							iconObj.sprite = controllerPreset.items[i].itemIcon;
						}
					}
					else if (controllerPreset.items[i].itemType == ControllerPreset.ItemType.Text)
					{
						if (iconParent != null)
						{
							iconParent.SetActive(value: false);
						}
						if (textParent != null)
						{
							textParent.SetActive(value: true);
						}
						if (textObj != null)
						{
							textObj.text = controllerPreset.items[i].itemText;
						}
					}
					break;
				}
				if (!flag)
				{
					return;
				}
			}
			if (base.gameObject.activeInHierarchy && Application.isPlaying)
			{
				StartCoroutine("LayoutFix");
				return;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			if (normalCG != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(normalCG.GetComponent<RectTransform>());
			}
		}

		public void SetLabel(string value)
		{
			if (labelObj == null)
			{
				return;
			}
			labelObj.text = value;
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("LayoutFix");
				return;
			}
			if (normalCG != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(normalCG.GetComponent<RectTransform>());
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform.parent.GetComponent<RectTransform>());
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			onHotkeyPress.Invoke();
			if (useSounds)
			{
				UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
			}
			if (!(normalCG == null) && !(highlightCG == null) && base.gameObject.activeInHierarchy)
			{
				StopCoroutine("SetHighlight");
				StartCoroutine("SetNormal");
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (useSounds)
			{
				UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
			}
			if (!(normalCG == null) && !(highlightCG == null))
			{
				StopCoroutine("SetNormal");
				StartCoroutine("SetHighlight");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!(normalCG == null) && !(highlightCG == null))
			{
				StopCoroutine("SetHighlight");
				StartCoroutine("SetNormal");
			}
		}

		private IEnumerator LayoutFix()
		{
			yield return new WaitForSecondsRealtime(0.025f);
			if (normalCG != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(normalCG.GetComponent<RectTransform>());
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform.parent.GetComponent<RectTransform>());
		}

		private IEnumerator SetNormal()
		{
			while (highlightCG.alpha > 0.01f)
			{
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			while (highlightCG.alpha < 0.99f)
			{
				highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 1f;
		}

		private IEnumerator StartCooldown()
		{
			isInCooldown = true;
			yield return new WaitForSecondsRealtime(0.05f);
			isInCooldown = false;
		}
	}
}
