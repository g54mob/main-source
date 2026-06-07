using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MusicButtonMobile : MobileConfig
	{
		[SerializeField]
		private Button _Fader;

		private PlayerOptions _playerOptions;

		[Inject]
		private void Construct(PlayerOptions player)
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
