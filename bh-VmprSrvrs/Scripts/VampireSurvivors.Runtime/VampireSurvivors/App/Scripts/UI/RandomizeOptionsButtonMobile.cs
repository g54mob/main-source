using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.App.Scripts.UI
{
	public class RandomizeOptionsButtonMobile : MobileConfig
	{
		[SerializeField]
		private Button _Fader;

		private PlayerOptions _playerOptions;

		[Inject]
		private void Construct(PlayerOptions playerOptions)
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		protected override void Apply()
		{
		}

		private void SetupValuesBasedOnCollectionState()
		{
		}
	}
}
