using System;
using Loxodon.Framework.Commands;
using Loxodon.Framework.ViewModels;

namespace UI.Stats
{
	public class StatsViewModel : ViewModelBase
	{
		private float _nicotineValue;

		private float _alcoholValue;

		private SimpleCommand<float> _nicotineValueChanged;

		private SimpleCommand<float> _alcoholValueChanged;

		public float NicotineValue
		{
			get
			{
				return _nicotineValue;
			}
			set
			{
				Set(ref _nicotineValue, value, "NicotineValue");
			}
		}

		public float AlcoholValue
		{
			get
			{
				return _alcoholValue;
			}
			set
			{
				Set(ref _alcoholValue, value, "AlcoholValue");
			}
		}

		public StatsViewModel()
		{
			_nicotineValueChanged = new SimpleCommand<float>(OnNicotineChanged);
			_alcoholValueChanged = new SimpleCommand<float>(OnAlcoholChanged);
		}

		private void OnAlcoholChanged(float value)
		{
			throw new NotImplementedException();
		}

		private void OnNicotineChanged(float value)
		{
			throw new NotImplementedException();
		}
	}
}
