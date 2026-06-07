using TMPro;
using UnityEngine;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.App.UI
{
	public class AdventureStarsCurrencyUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _StarsCurrencyText;

		private PlayerOptions _playerOptions;

		[Inject]
		private void Construct(PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdateStarsText()
		{
		}
	}
}
