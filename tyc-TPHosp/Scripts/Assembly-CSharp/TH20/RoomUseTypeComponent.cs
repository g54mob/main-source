using System;

namespace TH20
{
	public class RoomUseTypeComponent : EntityComponent
	{
		private bool _diagnosis = true;

		private bool _treatment = true;

		public bool Diagnosis
		{
			get
			{
				return _diagnosis;
			}
			set
			{
				_diagnosis = value;
				if (!_diagnosis && !_treatment)
				{
					_treatment = true;
				}
			}
		}

		public bool Treatment
		{
			get
			{
				return _treatment;
			}
			set
			{
				_treatment = value;
				if (!_treatment && !_diagnosis)
				{
					_diagnosis = true;
				}
			}
		}

		protected override Type ValidEntityType()
		{
			return typeof(Room);
		}
	}
}
