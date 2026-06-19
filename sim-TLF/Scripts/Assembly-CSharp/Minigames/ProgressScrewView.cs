using UnityEngine;

namespace Minigames
{
	public class ProgressScrewView : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private ScrewdriverMinigameView _screwMinigame;

		[SerializeField]
		private RectTransform _boltRect;

		[SerializeField]
		private RectTransform[] _screwHeads;

		[SerializeField]
		private float _maxProgressTillDisaster = 1f;

		[SerializeField]
		private float _minY = -91f;

		[SerializeField]
		private float _headMaxSizeX = 1.075f;

		[SerializeField]
		private float _headMinSizeY = 0.85f;

		private void Update()
		{
			animator.Play("Rotate", 0, _screwMinigame.Progress);
			_boltRect.anchoredPosition = new Vector2(_boltRect.anchoredPosition.x, Mathf.Lerp(0f, _minY, _screwMinigame.Progress));
			animator.speed = 0f;
			float t = Mathf.Max(0f, _screwMinigame.Progress - _maxProgressTillDisaster);
			RectTransform[] screwHeads = _screwHeads;
			for (int i = 0; i < screwHeads.Length; i++)
			{
				screwHeads[i].transform.localScale = new Vector3(Mathf.Lerp(1f, _headMaxSizeX, t), Mathf.Lerp(1f, _headMinSizeY, t), 1f);
			}
		}
	}
}
