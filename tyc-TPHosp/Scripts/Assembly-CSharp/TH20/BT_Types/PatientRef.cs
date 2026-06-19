using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class PatientRef : CharacterRef
	{
		public PatientRef()
		{
		}

		public PatientRef(Patient patient)
			: base(patient)
		{
		}
	}
}
