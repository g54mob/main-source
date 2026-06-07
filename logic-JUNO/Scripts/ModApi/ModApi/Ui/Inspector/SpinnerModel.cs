using System;

namespace ModApi.Ui.Inspector
{
	public class SpinnerModel : ItemModel
	{
		private Func<string> _valueGetter;

		public bool NextButtonVisible { get; set; }

		public Action<SpinnerModel> NextClicked { get; set; }

		public bool PrevButtonVisible { get; set; }

		public Action<SpinnerModel> PrevClicked { get; set; }

		public string Value => _valueGetter();

		public SpinnerModel(Func<string> valueGetter, Action<SpinnerModel> nextClicked = null, Action<SpinnerModel> prevClicked = null)
		{
			_valueGetter = valueGetter;
			NextClicked = nextClicked;
			PrevClicked = prevClicked;
			NextButtonVisible = true;
			PrevButtonVisible = true;
		}
	}
}
