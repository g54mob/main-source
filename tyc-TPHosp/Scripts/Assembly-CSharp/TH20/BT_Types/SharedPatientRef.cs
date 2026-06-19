using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedPatientRef : SharedCharacterRef
	{
		public new Patient Get => (Patient)base.Value.Get;

		public static implicit operator SharedPatientRef(PatientRef value)
		{
			return new SharedPatientRef
			{
				Value = value
			};
		}
	}
}
