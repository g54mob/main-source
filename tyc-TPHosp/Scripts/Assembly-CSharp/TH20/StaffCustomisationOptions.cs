using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Staff Customisation Options", order = 1102)]
	public class StaffCustomisationOptions : ScriptableObjectWithID
	{
		public CustomisationOption[] Doctor;

		public CustomisationOption[] Nurse;

		public CustomisationOption[] Assistant;

		public CustomisationOption[] Janitor;

		public CustomisationOption[] GetOptions(StaffDefinition.Type staffType)
		{
			return staffType switch
			{
				StaffDefinition.Type.Doctor => Doctor, 
				StaffDefinition.Type.Nurse => Nurse, 
				StaffDefinition.Type.Assistant => Assistant, 
				StaffDefinition.Type.Janitor => Janitor, 
				_ => null, 
			};
		}
	}
}
