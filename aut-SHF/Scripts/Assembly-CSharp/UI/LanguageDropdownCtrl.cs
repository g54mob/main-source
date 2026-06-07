using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class LanguageDropdownCtrl : MonoBehaviour
	{
		[Serializable]
		public struct LocaleInfo
		{
			public string name;

			public string locale;
		}

		[SerializeField]
		private TMP_Dropdown dropdown;

		[SerializeField]
		private List<LocaleInfo> locales;

		private bool isInitialized;

		private int oldLocaleValue;

		private void Init()
		{
		}

		private void Start()
		{
		}

		public void OnChangeLocale(int value)
		{
		}

		private void ChangeLocale(string localeString)
		{
		}
	}
}
