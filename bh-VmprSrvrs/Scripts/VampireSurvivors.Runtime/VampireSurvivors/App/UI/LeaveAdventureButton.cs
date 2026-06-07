using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using Zenject;

namespace VampireSurvivors.App.UI
{
	[RequireComponent(typeof(Button))]
	public class LeaveAdventureButton : MonoBehaviour
	{
		private Button _button;

		private AdventureManager _adventureManager;

		[Inject]
		private void Construct(AdventureManager adventureManager)
		{
		}

		private void Awake()
		{
		}

		private void LeaveAdventure()
		{
		}
	}
}
