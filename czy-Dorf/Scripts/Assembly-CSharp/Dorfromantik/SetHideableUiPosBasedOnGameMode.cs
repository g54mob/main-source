using Dorfromantik.UI;
using UnityEngine;

namespace Dorfromantik
{
	[RequireComponent(typeof(HideableUi))]
	public class SetHideableUiPosBasedOnGameMode : MonoBehaviour
	{
		[SerializeField]
		private GameMode targetGameMode;

		[SerializeField]
		private Vector2 targetHiddenAnchoredPos;

		private HideableUi hideableUi;

		private void OnEnable()
		{
			hideableUi = GetComponent<HideableUi>();
			if (OverwritingSingleton<GameSession>.Instance.GameMode == targetGameMode)
			{
				hideableUi.SetHiddenAnchoredPos(targetHiddenAnchoredPos);
			}
		}
	}
}
