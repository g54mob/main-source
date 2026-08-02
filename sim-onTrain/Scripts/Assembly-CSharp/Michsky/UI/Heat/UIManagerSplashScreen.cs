using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class UIManagerSplashScreen : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		private UIManager UIManagerAsset;

		[SerializeField]
		private bool mobileMode;

		[Header("Resources")]
		[SerializeField]
		private TextMeshProUGUI PAKStart;

		[SerializeField]
		private TextMeshProUGUI PAKKey;

		[SerializeField]
		private TextMeshProUGUI PAKEnd;

		private void Awake()
		{
			base.enabled = true;
			if (UIManagerAsset == null)
			{
				UIManagerAsset = Resources.Load<UIManager>("Heat UI Manager");
			}
			if (!UIManagerAsset.enableDynamicUpdate)
			{
				UpdatePAK();
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (!(UIManagerAsset == null))
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					UpdatePAK();
				}
				if (Application.isPlaying)
				{
					base.enabled = false;
				}
			}
		}

		private void AnalyzePAKText()
		{
			if (mobileMode)
			{
				return;
			}
			string[] array = UIManagerAsset.pakText.Split(char.Parse("{"));
			string text = array[0];
			if (!string.IsNullOrEmpty(text) && PAKStart != null)
			{
				PAKStart.gameObject.SetActive(value: true);
				PAKStart.text = text.Substring(0, text.Length - 1);
			}
			else if (PAKStart != null)
			{
				PAKStart.gameObject.SetActive(value: false);
			}
			if (array.Length <= 1)
			{
				if (PAKKey != null)
				{
					PAKKey.transform.parent.gameObject.SetActive(value: false);
				}
				if (PAKEnd != null)
				{
					PAKEnd.gameObject.SetActive(value: false);
				}
				return;
			}
			string[] array2 = array[1].Split(new string[1] { "}" }, StringSplitOptions.None);
			if (!string.IsNullOrEmpty(array2[0].ToString()) && PAKKey != null)
			{
				PAKKey.transform.parent.gameObject.SetActive(value: true);
				PAKKey.text = array2[0].ToString();
			}
			else if (PAKKey != null)
			{
				PAKKey.transform.parent.gameObject.SetActive(value: false);
			}
			if (array2.Length <= 1)
			{
				if (PAKEnd != null)
				{
					PAKEnd.gameObject.SetActive(value: false);
				}
			}
			else if (!string.IsNullOrEmpty(array2[1].ToString()) && PAKEnd != null)
			{
				PAKEnd.gameObject.SetActive(value: true);
				PAKEnd.text = array2[1].Substring(1, array2[1].ToString().Length - 1).ToString();
			}
			else if (PAKEnd != null)
			{
				PAKEnd.gameObject.SetActive(value: false);
			}
		}

		private void AnalyzePAKLocalizationText()
		{
			if (!Application.isPlaying || mobileMode)
			{
				return;
			}
			LocalizedObject component = PAKStart.GetComponent<LocalizedObject>();
			LocalizedObject component2 = PAKKey.GetComponent<LocalizedObject>();
			LocalizedObject component3 = PAKEnd.GetComponent<LocalizedObject>();
			if (component == null || component2 == null || component3 == null)
			{
				return;
			}
			string[] array = UIManagerAsset.pakLocalizationText.Split(char.Parse("{"));
			string text = array[0];
			if (!string.IsNullOrEmpty(text) && PAKStart != null)
			{
				text = text.Substring(0, text.Length - 1);
				text = component.GetKeyOutput(text);
				PAKStart.gameObject.SetActive(value: true);
				PAKStart.text = text;
				LayoutRebuilder.ForceRebuildLayoutImmediate(PAKStart.transform.parent.GetComponent<RectTransform>());
			}
			else if (PAKStart != null)
			{
				PAKStart.gameObject.SetActive(value: false);
			}
			if (array.Length <= 1)
			{
				if (PAKKey != null)
				{
					PAKKey.transform.parent.gameObject.SetActive(value: false);
				}
				if (PAKEnd != null)
				{
					PAKEnd.gameObject.SetActive(value: false);
				}
				return;
			}
			string[] array2 = array[1].Split(new string[1] { "}" }, StringSplitOptions.None);
			string key = array2[0].ToString();
			if (!string.IsNullOrEmpty(array2[0].ToString()) && PAKKey != null)
			{
				key = component2.GetKeyOutput(key);
				PAKKey.transform.parent.gameObject.SetActive(value: true);
				PAKKey.text = key;
				LayoutRebuilder.ForceRebuildLayoutImmediate(PAKKey.transform.parent.GetComponent<RectTransform>());
			}
			else if (PAKKey != null)
			{
				PAKKey.transform.parent.gameObject.SetActive(value: false);
			}
			if (array2.Length <= 1)
			{
				if (PAKEnd != null)
				{
					PAKEnd.gameObject.SetActive(value: false);
				}
			}
			else if (!string.IsNullOrEmpty(array2[1].ToString()) && PAKEnd != null)
			{
				string key2 = array2[1].Substring(1, array2[1].ToString().Length - 1).ToString();
				key2 = component3.GetKeyOutput(key2);
				PAKEnd.gameObject.SetActive(value: true);
				PAKEnd.text = key2;
				LayoutRebuilder.ForceRebuildLayoutImmediate(PAKEnd.transform.parent.GetComponent<RectTransform>());
			}
			else if (PAKEnd != null)
			{
				PAKEnd.gameObject.SetActive(value: false);
			}
		}

		private void UpdatePAK()
		{
			if (UIManagerAsset.pakType != UIManager.PressAnyKeyTextType.Custom)
			{
				if (UIManagerAsset.pakType == UIManager.PressAnyKeyTextType.Default && !UIManagerAsset.enableLocalization)
				{
					AnalyzePAKText();
				}
				else if (UIManagerAsset.pakType == UIManager.PressAnyKeyTextType.Default && UIManagerAsset.enableLocalization)
				{
					AnalyzePAKLocalizationText();
				}
			}
		}
	}
}
