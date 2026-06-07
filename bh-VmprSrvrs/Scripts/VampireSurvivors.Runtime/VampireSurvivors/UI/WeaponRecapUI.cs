using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class WeaponRecapUI : MonoBehaviour
	{
		[FormerlySerializedAs("Name")]
		[SerializeField]
		private TextMeshProUGUI _Name;

		[FormerlySerializedAs("Level")]
		[SerializeField]
		private TextMeshProUGUI _Level;

		[FormerlySerializedAs("Damage")]
		[SerializeField]
		private TextMeshProUGUI _Damage;

		[FormerlySerializedAs("Time")]
		[SerializeField]
		private TextMeshProUGUI _Time;

		[FormerlySerializedAs("DPS")]
		[SerializeField]
		private TextMeshProUGUI _Dps;

		[FormerlySerializedAs("Icon")]
		[SerializeField]
		private Image _Icon;

		public void SetData(RecapPage.StatsDisplay statsDisplay)
		{
		}

		private string FormatNumberValue(float number, int digits)
		{
			return null;
		}
	}
}
