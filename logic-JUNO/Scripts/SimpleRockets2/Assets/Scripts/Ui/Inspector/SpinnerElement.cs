using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Ui.Inspector
{
	public class SpinnerElement : ItemElement
	{
		private SpinnerModel _model;

		private SpinnerScript _spinner;

		public TextMeshProUGUI Text => _spinner.Text;

		public SpinnerElement(XmlElement xmlElement, SpinnerModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_spinner = xmlElement.GetElementByInternalId<SpinnerScript>("spinner");
			_spinner.NextButton.onClick.AddListener(delegate
			{
				OnNextClicked();
			});
			_spinner.PrevButton.onClick.AddListener(delegate
			{
				OnPrevClicked();
			});
			Update();
		}

		public override void Update()
		{
			base.Update();
			_spinner.Value = _model.Value;
			if (_spinner.PrevButtonVisible != _model.PrevButtonVisible)
			{
				_spinner.PrevButtonVisible = _model.PrevButtonVisible;
			}
			if (_spinner.NextButtonVisible != _model.NextButtonVisible)
			{
				_spinner.NextButtonVisible = _model.NextButtonVisible;
			}
		}

		private void OnNextClicked()
		{
			_model.NextClicked(_model);
		}

		private void OnPrevClicked()
		{
			_model.PrevClicked(_model);
		}
	}
}
