using System.Collections.Generic;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Ui.Inspector
{
	public class DropdownElement : ItemElement
	{
		private TMP_Dropdown _dropdown;

		private TextMeshProUGUI _labelText;

		private DropdownModel _model;

		public DropdownElement(XmlElement xmlElement, DropdownModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			DropdownElement dropdownElement = this;
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_dropdown = xmlElement.GetElementByInternalId<TMP_Dropdown>("dropdown");
			List<string> list = new List<string>();
			foreach (DropdownModel.DropdownOption option in model.Options)
			{
				list.Add(option.DisplayName);
			}
			_dropdown.AddOptions(list);
			_dropdown.onValueChanged.AddListener(delegate(int x)
			{
				if (x >= 0 && x < dropdownElement._model.Options.Count)
				{
					string value = dropdownElement._model.Options[x].Value;
					model.OnChanged(value);
				}
			});
			_dropdown.captionText.alignment = LabelElement.TextAlignmentToTextMeshProAlignment(model.Alignment);
			_dropdown.itemText.alignment = LabelElement.TextAlignmentToTextMeshProAlignment(model.Alignment);
			_labelText.text = model.Label;
			Update();
		}

		public override void Update()
		{
			base.Update();
			if (_dropdown.value < 0 || _dropdown.value >= _model.Options.Count)
			{
				return;
			}
			string value = _model.Options[_dropdown.value].Value;
			string value2 = _model.Value;
			if (!(value != value2))
			{
				return;
			}
			for (int i = 0; i < _model.Options.Count; i++)
			{
				if (_model.Options[i].Value == value2)
				{
					_dropdown.SetValueWithoutNotify(i);
					break;
				}
			}
		}
	}
}
