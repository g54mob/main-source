using FractureField.UI.Components;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class CommandConsoleRightBottomPanel : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private CommandConsoleTabs _tabs;

		[SerializeField]
		private Badge _upgradesBadge;

		[SerializeField]
		private Badge _rocksBadge;

		[SerializeField]
		private Badge _dronesBadge;

		[SerializeField]
		private Badge _bombsBadge;

		private void Awake()
		{
		}

		private void Setup()
		{
		}

		private void OnKeyPressed()
		{
		}
	}
}
