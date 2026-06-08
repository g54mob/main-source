using KitchenData;
using UnityEngine;

namespace Kitchen.Modules.Data
{
	[CreateAssetMenu(fileName = "Game Credit", menuName = "Kitchen/Credit")]
	public class GameCredit : KitchenObject
	{
		public string Icon;

		[Multiline]
		public string Title;

		[Multiline]
		public string Name;

		public string FirstName;

		public string SecondName;

		[Multiline]
		public string Affiliation;

		public Color Colour;

		private void FromName()
		{
			Name = base.name;
		}

		private void GuessNameParts()
		{
			string[] array = Name.Split(' ');
			FirstName = array[0];
			SecondName = Name.Substring(FirstName.Length + 1);
		}
	}
}
