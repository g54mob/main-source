using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/Localization/Localized Object")]
	public class LocalizedObject : MonoBehaviour
	{
		[Serializable]
		public class LanguageChangedEvent : UnityEvent<string>
		{
		}

		public enum UpdateMode
		{
			OnEnable = 0,
			OnDemand = 1
		}

		public enum ObjectType
		{
			TextMeshPro = 0,
			Custom = 1,
			ComponentDriven = 2,
			Audio = 3,
			Image = 4
		}

		public LocalizationSettings localizationSettings;

		public TextMeshProUGUI textObj;

		public AudioSource audioObj;

		public Image imageObj;

		public int tableIndex = -1;

		public string localizationKey;

		public ObjectType objectType;

		public UpdateMode updateMode;

		public bool rebuildLayoutOnUpdate;

		[SerializeField]
		private bool forceAddToManager;

		public LanguageChangedEvent onLanguageChanged = new LanguageChangedEvent();

		public bool isInitialized;

		private void Awake()
		{
			if (LocalizationManager.instance != null && !LocalizationManager.instance.UIManagerAsset.enableLocalization)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				InitializeItem();
			}
		}

		private void OnEnable()
		{
			if (LocalizationManager.instance == null)
			{
				UnityEngine.Object.Destroy(this);
			}
			else if (isInitialized && !(LocalizationManager.instance.currentLanguageAsset == null) && updateMode == UpdateMode.OnEnable)
			{
				UpdateItem();
			}
		}

		public void InitializeItem()
		{
			if (isInitialized)
			{
				return;
			}
			if (LocalizationManager.instance == null)
			{
				UIManager uIManager = (UIManager)Resources.FindObjectsOfTypeAll(typeof(UIManager))[0];
				if (uIManager == null || !uIManager.enableLocalization)
				{
					return;
				}
				new GameObject("Localization Manager [Auto Generated]").AddComponent<LocalizationManager>();
			}
			if (LocalizationManager.instance != null && !LocalizationManager.instance.UIManagerAsset.enableLocalization)
			{
				UnityEngine.Object.Destroy(this);
			}
			else if (!(LocalizationManager.instance == null) && !(LocalizationManager.instance.UIManagerAsset == null) && LocalizationManager.instance.UIManagerAsset.enableLocalization)
			{
				if (forceAddToManager && !LocalizationManager.instance.localizedItems.Contains(this))
				{
					LocalizationManager.instance.localizedItems.Add(this);
				}
				if (objectType == ObjectType.TextMeshPro && textObj == null)
				{
					textObj = base.gameObject.GetComponent<TextMeshProUGUI>();
				}
				else if (objectType == ObjectType.Audio && audioObj == null)
				{
					audioObj = base.gameObject.GetComponent<AudioSource>();
				}
				else if (objectType == ObjectType.Image && imageObj == null)
				{
					imageObj = base.gameObject.GetComponent<Image>();
				}
				LocalizationManager.instance.localizedItems.Add(this);
				isInitialized = true;
			}
		}

		public void ReInitializeItem()
		{
			isInitialized = false;
			InitializeItem();
		}

		public void UpdateItem()
		{
			if (!isInitialized || LocalizationManager.instance == null || LocalizationManager.instance.currentLanguageAsset == null || LocalizationManager.instance.currentLanguageAsset.tableList.Count == 0)
			{
				return;
			}
			if (objectType == ObjectType.TextMeshPro && textObj != null)
			{
				for (int i = 0; i < LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent.Count; i++)
				{
					if (!(localizationKey == LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].key))
					{
						continue;
					}
					if (string.IsNullOrEmpty(LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].value))
					{
						if (LocalizationManager.enableLogs)
						{
							Debug.Log("<b>[Localized Object]</b> The specified key '" + localizationKey + "' could not be found or the output value is empty for " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
						}
					}
					else
					{
						textObj.text = LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].value;
						onLanguageChanged.Invoke(LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].value);
					}
					break;
				}
			}
			else if (objectType == ObjectType.Audio && audioObj != null)
			{
				for (int j = 0; j < LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent.Count; j++)
				{
					if (!(localizationKey == LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[j].key))
					{
						continue;
					}
					if (LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[j].audioValue == null)
					{
						if (LocalizationManager.enableLogs)
						{
							Debug.Log("<b>[Localized Object]</b> The specified key '" + localizationKey + "' could not be found or the output value is empty for " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
						}
					}
					else
					{
						audioObj.clip = LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[j].audioValue;
					}
					break;
				}
			}
			else if (objectType == ObjectType.Image && imageObj != null)
			{
				for (int k = 0; k < LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent.Count; k++)
				{
					if (!(localizationKey == LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[k].key))
					{
						continue;
					}
					if (LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[k].spriteValue == null)
					{
						if (LocalizationManager.enableLogs)
						{
							Debug.Log("<b>[Localized Object]</b> The specified key '" + localizationKey + "' could not be found or the output value is empty for " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
						}
					}
					else
					{
						imageObj.sprite = LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[k].spriteValue;
					}
					break;
				}
			}
			else if (objectType == ObjectType.Custom || objectType == ObjectType.ComponentDriven)
			{
				for (int l = 0; l < LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent.Count; l++)
				{
					if (localizationKey == LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[l].key)
					{
						if (!string.IsNullOrEmpty(LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[l].value))
						{
							onLanguageChanged.Invoke(LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[l].value);
						}
						break;
					}
				}
			}
			if (rebuildLayoutOnUpdate && base.gameObject.activeInHierarchy)
			{
				StartCoroutine("RebuildLayout");
			}
		}

		public bool CheckLocalizationStatus()
		{
			if (!isInitialized)
			{
				InitializeItem();
			}
			if (LocalizationManager.instance == null || LocalizationManager.instance.UIManagerAsset == null || !LocalizationManager.instance.UIManagerAsset.enableLocalization)
			{
				return false;
			}
			return true;
		}

		public string GetKeyOutput(string key)
		{
			string text = null;
			bool flag = false;
			if (LocalizationManager.instance != null && LocalizationManager.instance.currentLanguageAsset == null)
			{
				LocalizationManager.instance.InitializeLanguage();
			}
			if (!isInitialized || LocalizationManager.instance == null || LocalizationManager.instance.currentLanguageAsset == null || LocalizationManager.instance.currentLanguageAsset.tableList.Count == 0)
			{
				return LocalizationSettings.notInitializedText;
			}
			for (int i = 0; i < LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent.Count; i++)
			{
				if (key == LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].key)
				{
					text = LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].value;
					flag = true;
					break;
				}
			}
			if (flag && string.IsNullOrEmpty(text))
			{
				if (LocalizationManager.enableLogs)
				{
					Debug.Log("<b>[Localized Object]</b> The output value for '" + key + "' is empty in " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
				}
				return "EMPTY_KEY_IN_" + LocalizationManager.instance.currentLanguageAsset.languageID + ": " + key;
			}
			if (!flag)
			{
				if (LocalizationManager.enableLogs)
				{
					Debug.Log("<b>[Localized Object]</b> The specified key '" + key + "' could not be found in " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
				}
				return "MISSING_KEY_IN_" + LocalizationManager.instance.currentLanguageAsset.languageID + ": " + key;
			}
			return text;
		}

		public AudioClip GetKeyOutputAudio(string key)
		{
			AudioClip audioClip = null;
			bool flag = false;
			if (LocalizationManager.instance != null && LocalizationManager.instance.currentLanguageAsset == null)
			{
				LocalizationManager.instance.InitializeLanguage();
			}
			if (!isInitialized || LocalizationManager.instance == null || LocalizationManager.instance.currentLanguageAsset == null || LocalizationManager.instance.currentLanguageAsset.tableList.Count == 0)
			{
				return null;
			}
			for (int i = 0; i < LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent.Count; i++)
			{
				if (key == LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].key)
				{
					audioClip = LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].audioValue;
					flag = true;
					break;
				}
			}
			if (flag && audioClip == null)
			{
				if (LocalizationManager.enableLogs)
				{
					Debug.Log("<b>[Localized Object]</b> The output value for '" + key + "' is empty in " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
				}
				return null;
			}
			if (!flag)
			{
				if (LocalizationManager.enableLogs)
				{
					Debug.Log("<b>[Localized Object]</b> The specified key '" + key + "' could not be found in " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
				}
				return null;
			}
			return audioClip;
		}

		public Sprite GetKeyOutputSprite(string key)
		{
			Sprite sprite = null;
			bool flag = false;
			if (LocalizationManager.instance != null && LocalizationManager.instance.currentLanguageAsset == null)
			{
				LocalizationManager.instance.InitializeLanguage();
			}
			if (!isInitialized || LocalizationManager.instance == null || LocalizationManager.instance.currentLanguageAsset == null || LocalizationManager.instance.currentLanguageAsset.tableList.Count == 0)
			{
				return null;
			}
			for (int i = 0; i < LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent.Count; i++)
			{
				if (key == LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].key)
				{
					sprite = LocalizationManager.instance.currentLanguageAsset.tableList[tableIndex].tableContent[i].spriteValue;
					flag = true;
					break;
				}
			}
			if (flag && sprite == null)
			{
				if (LocalizationManager.enableLogs)
				{
					Debug.Log("<b>[Localized Object]</b> The output value for '" + key + "' is empty in " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
				}
				return null;
			}
			if (!flag)
			{
				if (LocalizationManager.enableLogs)
				{
					Debug.Log("<b>[Localized Object]</b> The specified key '" + key + "' could not be found in " + LocalizationManager.instance.currentLanguageAsset.languageName + ".", this);
				}
				return null;
			}
			return sprite;
		}

		public static string GetKeyOutput(string tableID, string tableKey)
		{
			UIManager uIManager = (UIManager)Resources.FindObjectsOfTypeAll(typeof(UIManager))[0];
			if (uIManager == null || !uIManager.enableLocalization)
			{
				return null;
			}
			int num = -1;
			string result = null;
			for (int i = 0; i < uIManager.currentLanguage.tableList.Count; i++)
			{
				if (uIManager.currentLanguage.tableList[i].table.tableID == tableID)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return null;
			}
			for (int j = 0; j < uIManager.currentLanguage.tableList[num].tableContent.Count; j++)
			{
				if (uIManager.currentLanguage.tableList[num].tableContent[j].key == tableKey)
				{
					result = uIManager.currentLanguage.tableList[num].tableContent[j].value;
					break;
				}
			}
			return result;
		}

		public static AudioClip GetKeyOutputAudio(string tableID, string tableKey)
		{
			UIManager uIManager = (UIManager)Resources.FindObjectsOfTypeAll(typeof(UIManager))[0];
			if (uIManager == null || !uIManager.enableLocalization)
			{
				return null;
			}
			int num = -1;
			AudioClip result = null;
			for (int i = 0; i < uIManager.currentLanguage.tableList.Count; i++)
			{
				if (uIManager.currentLanguage.tableList[i].table.tableID == tableID)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return null;
			}
			for (int j = 0; j < uIManager.currentLanguage.tableList[num].tableContent.Count; j++)
			{
				if (uIManager.currentLanguage.tableList[num].tableContent[j].key == tableKey)
				{
					result = uIManager.currentLanguage.tableList[num].tableContent[j].audioValue;
					break;
				}
			}
			return result;
		}

		public static Sprite GetKeyOutputSprite(string tableID, string tableKey)
		{
			UIManager uIManager = (UIManager)Resources.FindObjectsOfTypeAll(typeof(UIManager))[0];
			if (uIManager == null || !uIManager.enableLocalization)
			{
				return null;
			}
			int num = -1;
			Sprite result = null;
			for (int i = 0; i < uIManager.currentLanguage.tableList.Count; i++)
			{
				if (uIManager.currentLanguage.tableList[i].table.tableID == tableID)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return null;
			}
			for (int j = 0; j < uIManager.currentLanguage.tableList[num].tableContent.Count; j++)
			{
				if (uIManager.currentLanguage.tableList[num].tableContent[j].key == tableKey)
				{
					result = uIManager.currentLanguage.tableList[num].tableContent[j].spriteValue;
					break;
				}
			}
			return result;
		}

		private IEnumerator RebuildLayout()
		{
			yield return new WaitForSecondsRealtime(0.025f);
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform.parent.GetComponent<RectTransform>());
		}
	}
}
