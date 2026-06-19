namespace TH20
{
	public abstract class HospitalEventStaff : HospitalEvent, IHospitalEventStaff
	{
		protected Staff _staff;

		protected GameDate _expiryDate;

		protected HospitalEventStaff(Staff staff, GameDate expiryDate)
		{
			_staff = staff;
			Date = expiryDate;
			_expiryDate = expiryDate;
		}

		public override bool HasExpired(GameDate currentDate)
		{
			if (_staff != null)
			{
				if (!_staff.HasBeenDestroyed())
				{
					_expiryDate = currentDate;
					return false;
				}
				_staff = null;
			}
			if (_config != null)
			{
				return currentDate.DaysSince(_expiryDate) >= _config._durationInMonths * 31;
			}
			return true;
		}

		public abstract CharacterName GetStaffName();
	}
}
