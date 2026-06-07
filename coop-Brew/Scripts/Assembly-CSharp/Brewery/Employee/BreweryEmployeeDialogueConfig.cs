using UnityEngine;

namespace Brewery.Employee
{
	[CreateAssetMenu(fileName = "EmployeeDialogue", menuName = "Brewery/Employee Dialogue Config")]
	public class BreweryEmployeeDialogueConfig : ScriptableObject
	{
		public PersonalityLines[] arriveAtWork;

		public PersonalityLines[] pickingUpItems;

		public PersonalityLines[] loadingStation;

		public PersonalityLines[] processingWait;

		public PersonalityLines[] collectingOutput;

		public PersonalityLines[] bottling;

		public PersonalityLines[] idleNoWork;

		public PersonalityLines[] goingHome;

		public string GetLine(PersonalityLines[] context, BreweryEmployeePersonality personality)
		{
			return null;
		}
	}
}
