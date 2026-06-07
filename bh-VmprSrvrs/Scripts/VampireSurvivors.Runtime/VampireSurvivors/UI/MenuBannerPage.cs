using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MenuBannerPage : BaseUIPage
	{
		[SerializeField]
		private RectTransform _Banner;

		[SerializeField]
		private RectTransform _SafeArea;

		[SerializeField]
		private GameObject _TwitchModeEnabled;

		[SerializeField]
		private GameObject _AccountButton;

		[SerializeField]
		private GameObject _LeaveAdventureButton;

		[SerializeField]
		private GameObject _QuitGameButton;

		[SerializeField]
		private RectTransform _LocalSafeArea;

		private AdventureManager _adventure;

		[Inject]
		private void Construct(AdventureManager adventure)
		{
		}

		private void Start()
		{
		}

		protected override void Update()
		{
		}

		private void UpdateLayout()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		public void LeaveAdventure()
		{
		}
	}
}
