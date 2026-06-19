using UnityEngine;

namespace Minigames
{
	public class ProgressBoltView : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private WrenchMinigameView _wrenchMinigame;

		[SerializeField]
		private RectTransform _boltRect;

		[SerializeField]
		private RectTransform[] _boltHeads;

		[SerializeField]
		private float _minY = -91f;

		[SerializeField]
		private float _headMinSizeY = 0.91f;

		[SerializeField]
		private float _headMaxSizeX = 1.05f;

		[SerializeField]
		private float _maxProgressTillDisaster = 1f;

		private void Update()
		{
			UpdateProgress();
		}

		public void UpdateProgress()
		{
			animator.Play("Rotate", 0, _wrenchMinigame.Progress);
			_boltRect.anchoredPosition = new Vector2(_boltRect.anchoredPosition.x, Mathf.Lerp(0f, _minY, _wrenchMinigame.Progress));
			animator.speed = 0f;
			float t = Mathf.Max(0f, _wrenchMinigame.Progress - _maxProgressTillDisaster);
			RectTransform[] boltHeads = _boltHeads;
			for (int i = 0; i < boltHeads.Length; i++)
			{
				boltHeads[i].transform.localScale = new Vector3(Mathf.Lerp(1f, _headMaxSizeX, t), Mathf.Lerp(1f, _headMinSizeY, t), 1f);
			}
		}
	}
}
