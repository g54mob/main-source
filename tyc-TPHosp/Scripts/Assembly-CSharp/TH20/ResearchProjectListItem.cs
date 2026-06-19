using System;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchProjectListItem : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private Image _buttonImage;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		[SerializeField]
		private TMP_Text _progressText;

		[SerializeField]
		private Color _assignedColor;

		[SerializeField]
		private Color _selectedColour = Color.black;

		[SerializeField]
		private Color _nonSelectedColour = Color.white;

		private ResearchProject _project;

		public void Initialise(ResearchProject project, Action<ResearchProject> onSelect)
		{
			_project = project;
			_name.text = _project.Definition.NameLocalised.Translation;
			_icon.sprite = _project.Definition.Icon;
			_button.onClick.AddListener(delegate
			{
				onSelect(_project);
			});
			if (project.Assigned.Count != 0)
			{
				_buttonImage.color = _assignedColor;
			}
			_name.enableAutoSizing = true;
		}

		public void OnSelected(bool selected)
		{
			_name.color = (selected ? _selectedColour : _nonSelectedColour);
			GameObjectUtils.SetInteractable(_button, !selected);
		}

		public ResearchProject GetProject()
		{
			return _project;
		}

		private void Update()
		{
			_progressBar.Progress = _project.ResearchedPoints / _project.Definition.ResearchPoints;
			_progressText.text = $"{(int)_project.ResearchedPoints} / {(int)_project.Definition.ResearchPoints}";
		}
	}
}
