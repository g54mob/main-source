using Events.UI;
using Events.UI.BarInfo;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BlueprintBarInfoView : BaseBarInfoView
	{
		[SerializeField]
		private ShowBlueprintBarInfoEvent _showBarInfoEvent;

		[SerializeField]
		private DeleteBlueprintEvent _deleteBlueprintEvent;

		[SerializeField]
		private EditBlueprintEvent _editBlueprintEvent;

		[SerializeField]
		private Button _deleteButton;

		[SerializeField]
		private Button _editButton;

		[Space]
		[SerializeField]
		[LocaKey]
		private string _title;

		private BlueprintBarInfoDto _barInfoDto;

		protected override void Awake()
		{
			_showBarInfoEvent.Register(Show);
			_editButton.onClick.AddListener(EditBlueprint);
			_deleteButton.onClick.AddListener(DeleteBlueprint);
			base.Awake();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_showBarInfoEvent.UnRegister(Show);
			_editButton.onClick.RemoveListener(EditBlueprint);
			_deleteButton.onClick.RemoveListener(DeleteBlueprint);
		}

		public void Show(BlueprintBarInfoDto barinfoDto)
		{
			PopulateWithUIData(barinfoDto);
		}

		private void PopulateWithUIData(BlueprintBarInfoDto barInfo)
		{
			_barInfoDto = barInfo;
			UpdateLocalization();
			base.gameObject.SetActive(value: true);
		}

		protected override void UpdateLocalization()
		{
			string text = "";
			if (!string.IsNullOrEmpty(_barInfoDto.UIData.FileName))
			{
				string text2 = string.Format(LocalizationUtility.GetLocalizedText(_title), _barInfoDto.UIData.SlotChar);
				ColorUtility.ToHtmlStringRGB(_barInfoDto.UIData.Color);
				text = "<font-weight='400'><color=#7FCAEA>" + text2 + "</color></font-weight> " + _barInfoDto.UIData.BlueprintName;
			}
			_text.SetText(text);
		}

		private void EditBlueprint()
		{
			_editBlueprintEvent.Fire(_barInfoDto.UIData);
		}

		private void DeleteBlueprint()
		{
			_deleteBlueprintEvent.Fire(_barInfoDto.UIData);
		}
	}
}
