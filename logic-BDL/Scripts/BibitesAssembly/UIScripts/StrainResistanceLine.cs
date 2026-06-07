using TMPro;
using UnityEngine;

namespace UIScripts
{
	public class StrainResistanceLine : MonoBehaviour
	{
		public TextMeshProUGUI strain;

		public TextMeshProUGUI value;

		public void InitLine(string _strain, float _resistance)
		{
			strain.text = _strain;
			value.text = _resistance.ToString("F5");
		}
	}
}
