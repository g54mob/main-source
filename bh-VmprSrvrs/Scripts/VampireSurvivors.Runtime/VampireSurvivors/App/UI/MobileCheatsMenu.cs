using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.App.UI
{
	public class MobileCheatsMenu : MonoBehaviour
	{
		[SerializeField]
		private Button _ShowMobileCheatsButton;

		private PlayerOptions _playerOptions;

		private DataManager _dataManager;

		[Inject]
		private void Construct(PlayerOptions playerOptions, DataManager dataManager)
		{
		}

		private void Awake()
		{
		}

		public void CheatF2()
		{
		}

		public void ForcePreMoongolowSave()
		{
		}

		private static void Reload()
		{
		}
	}
}
