using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;

namespace VampireSurvivors.UI
{
	public class StatItemUI : MonoBehaviour
	{
		[SerializeField]
		private string _Format;

		[FormerlySerializedAs("Type")]
		[SerializeField]
		public PowerUpType _Type;

		[FormerlySerializedAs("DefaultValue")]
		[SerializeField]
		private float _DefaultValue;

		[FormerlySerializedAs("UsePlus")]
		[SerializeField]
		private bool _UsePlus;

		[FormerlySerializedAs("Name")]
		[SerializeField]
		private TextMeshProUGUI _Name;

		[FormerlySerializedAs("Value")]
		[SerializeField]
		private TextMeshProUGUI _Value;

		[FormerlySerializedAs("Icon")]
		[SerializeField]
		private Image _Icon;

		[FormerlySerializedAs("IsPercentage")]
		[SerializeField]
		private bool _IsPercentage;

		[SerializeField]
		private bool _RoundToInt;

		[SerializeField]
		private bool _MultiplyPowerUpByCharacterValue;

		public void SetData(PowerUpData data, PowerUpType t)
		{
		}

		public TextMeshProUGUI GetNameText()
		{
			return null;
		}

		public void SetValue(float finalvalue, bool hasPowerUp)
		{
		}

		public float GetDefaultValue()
		{
			return 0f;
		}

		public void SetValue(float finalValue)
		{
		}

		public void SetFormat(string s)
		{
		}

		private string GetText(float value)
		{
			return null;
		}
	}
}
