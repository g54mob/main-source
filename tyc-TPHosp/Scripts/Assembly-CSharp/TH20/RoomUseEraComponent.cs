using System;

namespace TH20
{
	public class RoomUseEraComponent : EntityComponent
	{
		private bool _eraPrehistory = true;

		private bool _eraMedieval = true;

		private bool _eraPresent = true;

		public bool EraPrehistory
		{
			get
			{
				return _eraPrehistory;
			}
			set
			{
				_eraPrehistory = value;
				if (!_eraPrehistory && !_eraPresent)
				{
					_eraMedieval = true;
				}
			}
		}

		public bool EraMedieval
		{
			get
			{
				return _eraMedieval;
			}
			set
			{
				_eraMedieval = value;
				if (!_eraPrehistory && !_eraMedieval)
				{
					_eraPresent = true;
				}
			}
		}

		public bool EraPresent
		{
			get
			{
				return _eraPresent;
			}
			set
			{
				_eraPresent = value;
				if (!_eraMedieval && !_eraPresent)
				{
					_eraPrehistory = true;
				}
			}
		}

		protected override Type ValidEntityType()
		{
			return typeof(Room);
		}

		public bool CanBeUsedFor(Patient patient)
		{
			AnachronisticTreatmentComponent component = patient.GetComponent<AnachronisticTreatmentComponent>();
			if (component == null)
			{
				return false;
			}
			return component.EraType switch
			{
				IllnessEraType.Prehistory => _eraPrehistory, 
				IllnessEraType.Medieval => _eraMedieval, 
				IllnessEraType.Present => _eraPresent, 
				_ => false, 
			};
		}
	}
}
