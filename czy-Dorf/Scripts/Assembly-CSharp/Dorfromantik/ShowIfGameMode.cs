using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class ShowIfGameMode : MonoBehaviour
	{
		[SerializeField]
		private List<GameModeId> visibleGameModes;

		[SerializeField]
		private GameObject target;

		private void OnEnable()
		{
			if ((bool)OverwritingSingleton<GameSession>.Instance)
			{
				target.gameObject.SetActive(visibleGameModes.Contains(OverwritingSingleton<GameSession>.Instance.GameMode.id));
			}
		}
	}
}
