using FractureField.Rocks;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.CommandConsole
{
	public class RocksEconomyStats : MonoBehaviour
	{
		[Header("Variables")]
		[SerializeField]
		private RockLayerType _rockLayerType;

		[Header("References")]
		[SerializeField]
		private Image _rockCurrencyIcon;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private HasRequiredRockLayer _hasRequiredRockLayer;

		[SerializeField]
		private RText _totalText;

		[SerializeField]
		private RText _highestText;

		private void Awake()
		{
		}

		private void Setup()
		{
		}
	}
}
