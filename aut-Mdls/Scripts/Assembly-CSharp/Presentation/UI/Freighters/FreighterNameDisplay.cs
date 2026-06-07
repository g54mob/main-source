using Data.FactoryFloor.Freighter;
using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Freighters
{
	public class FreighterNameDisplay : MonoBehaviour
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private Image _colorIcon;

		[SerializeField]
		private TextInfoPanelContent _nameInfoPanel;

		private bool _hasFreighter;

		private FreighterObject _freighter;

		public void Populate(FreighterObject freighter)
		{
			Unsubscribe();
			_freighter = freighter;
			_hasFreighter = true;
			_freighter.OnNameChanged += OnNameChanged;
			OnNameChanged();
		}

		private void Unsubscribe()
		{
			if (_hasFreighter && _freighter != null)
			{
				_freighter.OnNameChanged -= OnNameChanged;
			}
		}

		private void OnNameChanged()
		{
			_nameText.SetText(_freighter.Name);
			_nameInfoPanel.UpdateContent(_freighter.Name);
			_colorIcon.color = _freighter.Color;
		}
	}
}
