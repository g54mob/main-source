using FractureField.Rocks;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.CommandConsole
{
	public class RocksSectionLayerStats : MonoBehaviour
	{
		[Header("Variables")]
		[SerializeField]
		private RockLayerType _rockLayerType;

		[Header("References")]
		[SerializeField]
		private Image _rockSprite;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private HasRequiredRockLayer _hasRequiredRockLayer;

		[SerializeField]
		private RText _layersDestroyedText;

		[SerializeField]
		private RText _manualHitsText;

		[SerializeField]
		private RText _manualDamageText;

		[SerializeField]
		private RText _droneHitsText;

		[SerializeField]
		private RText _droneDamageText;

		[SerializeField]
		private RText _bombHitsText;

		[SerializeField]
		private RText _bombDamageText;

		private void Awake()
		{
		}

		private void Setup()
		{
		}
	}
}
