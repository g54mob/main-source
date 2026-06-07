using UnityEngine;

namespace VampireSurvivors.App.UI
{
	public class FastForwardButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject _icon1;

		[SerializeField]
		private GameObject _icon2;

		[SerializeField]
		private GameObject _icon3;

		private float _tempTimeScale;

		private const float PaddingBelowTopMaskBar = 20f;

		private const float PaddingBelowKillCount = 80f;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void CheckTimescale()
		{
		}

		private void FastForward()
		{
		}

		private void RepositionFastForwardButton()
		{
		}

		private static bool IsKillsCountAboveTopAspectBarBottom(RectTransform topMask, RectTransform killCount)
		{
			return false;
		}

		private static float GetBottomY(RectTransform rectTransform)
		{
			return 0f;
		}
	}
}
