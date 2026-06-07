using FractureField.UI.Components;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace FractureField.UI.CommandConsole
{
	public class CommandConsoleTab : MonoBehaviour, ICommandConsoleTab
	{
		[Header("Values")]
		[SerializeField]
		private string _tabTitle;

		[SerializeField]
		private LocalizedString _localizedTitle;

		[Header("References")]
		[SerializeField]
		private CommandConsoleTabs _tabs;

		[SerializeField]
		private TMP_Text _tabTitleText;

		[SerializeField]
		private RImage _backgroundImage;

		[SerializeField]
		protected Badge _badge;

		public string TabTitle => null;

		public void SetLocalizedTitle(string key, string tabTitle = null)
		{
		}

		protected virtual void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnStringChanged(string value)
		{
		}

		public void Clicked()
		{
		}
	}
}
