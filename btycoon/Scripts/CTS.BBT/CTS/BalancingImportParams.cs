using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "BalancingParam", menuName = "BBT/BalancingParam")]
	public class BalancingImportParams : ScriptableObject
	{
		[SerializeField]
		private string sheetPath;

		public string GetCleanedPath()
		{
			string text = sheetPath.Replace("https://docs.google.com/spreadsheets/d/", "");
			if (text.Contains("/edit?usp=drive_link"))
			{
				text = text.Replace("/edit?usp=drive_link", "");
			}
			else if (text.Contains("/edit?usp=sharing"))
			{
				text = text.Replace("/edit?usp=sharing", "");
			}
			return text;
		}
	}
}
