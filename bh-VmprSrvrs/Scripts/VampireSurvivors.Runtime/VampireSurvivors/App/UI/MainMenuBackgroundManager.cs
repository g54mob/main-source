using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.App.UI
{
	public class MainMenuBackgroundManager : MonoBehaviour
	{
		[SerializeField]
		private Transform _CustomBackgroundHolder;

		private MainMenuBackgroundFactory _mainMenuBackgroundFactory;

		private AdventureManager _adventureManager;

		[Inject]
		private void Construct(MainMenuBackgroundFactory mainMenuBackgroundFactory, AdventureManager adventureManager)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void SetBackgroundForAdventure(AdventureType adventureType)
		{
		}

		public void ForceCustomBackground(Transform customBackground)
		{
		}

		public void ResetBackgroundToMainGame()
		{
		}
	}
}
