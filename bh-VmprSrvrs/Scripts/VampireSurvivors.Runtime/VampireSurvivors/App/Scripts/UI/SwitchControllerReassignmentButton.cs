using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.App.Scripts.UI
{
	public class SwitchControllerReassignmentButton : MonoBehaviour
	{
		private Button _button;

		private MultiplayerManager _multiplayerManager;

		[Inject]
		private void Construct(MultiplayerManager multiplayerManager)
		{
		}

		private void Awake()
		{
		}

		private void ShowApplet()
		{
		}
	}
}
