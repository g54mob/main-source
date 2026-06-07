using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class CoinsUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI PriceValue;

		[SerializeField]
		private Image _MoneyImage;

		[SerializeField]
		private Image _FrameImage;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		[Inject]
		private void Construct(PlayerOptions playerOptions, AdventureManager adventureManager)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdatePrice()
		{
		}

		private void OnAdventureStarted(AdventureType adventureType)
		{
		}

		private void OnAdventureEnded()
		{
		}

		private void SwitchCoinsUI()
		{
		}
	}
}
