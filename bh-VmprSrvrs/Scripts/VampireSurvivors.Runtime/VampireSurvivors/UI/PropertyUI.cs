using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class PropertyUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI Name;

		[SerializeField]
		private TextMeshProUGUI Value;

		public void SetValue(string val)
		{
		}

		public void SetName(string name)
		{
		}

		public TextMeshProUGUI GetName()
		{
			return null;
		}

		public TextMeshProUGUI GetValue()
		{
			return null;
		}
	}
}
