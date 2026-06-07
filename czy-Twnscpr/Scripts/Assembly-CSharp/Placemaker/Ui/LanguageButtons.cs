using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class LanguageButtons : UIBehaviour, UiMaster.IUiSetup
	{
		private struct S : IComparable<S>
		{
			public string englishName;

			public string nativeName;

			int IComparable<S>.CompareTo(S other)
			{
				return 0;
			}
		}

		[SerializeField]
		private UiMaster master;

		private List<string> languages;

		[SerializeField]
		private BaseButton leftArrow;

		[SerializeField]
		private BaseButton rightArrow;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_Left()
		{
		}

		public void Button_Right()
		{
		}

		private void ChangeLanguage(bool left)
		{
		}

		private void SetLanguage(string language)
		{
		}
	}
}
