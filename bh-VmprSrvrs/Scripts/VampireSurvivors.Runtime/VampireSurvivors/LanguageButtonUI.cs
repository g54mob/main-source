using TMPro;
using UnityEngine;

namespace VampireSurvivors
{
	public class LanguageButtonUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI Text;

		private string Code;

		private string Name;

		private LanguageController Controller;

		public void SetLanguage(LanguageController controller, string name, string code)
		{
		}

		public void ApplyLanguage()
		{
		}
	}
}
