using System.Collections;
using Assets.Source.World;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9UnshackledWidgetPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T9UnshackledWidgetBrick _brickPrefab;

		[SerializeField]
		private T9UnshackledWidgetBall _ballPrefab;

		[SerializeField]
		private Transform _brickParent;

		[SerializeField]
		private Vector2 _brickStart;

		[SerializeField]
		private Vector2 _brickOffset;

		[SerializeField]
		private Vector2Int _brickCount;

		[SerializeField]
		private Collider2D _startCollider;

		[SerializeField]
		private TMP_Text _startText;

		private T9UnshackledWidgetBall _ball;

		public bool PuzzleActive;

		private void Start()
		{
			InitPuzzle();
		}

		private void OnEnable()
		{
			if (!_ball)
			{
				CreateBall();
			}
			_startCollider.enabled = true;
			PuzzleActive = false;
			_startText.gameObject.SetActive(value: true);
		}

		private void OnMouseUpAsButton()
		{
			_startCollider.enabled = false;
			PuzzleActive = true;
			_startText.gameObject.SetActive(value: false);
		}

		public void InitPuzzle()
		{
			_brickParent.DestroyChildren();
			CreateBall();
			for (int i = 0; i < _brickCount.x; i++)
			{
				for (int j = 0; j < _brickCount.y; j++)
				{
					Object.Instantiate(_brickPrefab, _brickParent).transform.localPosition = new Vector3(_brickStart.x + (float)i * _brickOffset.x, _brickStart.y + (float)j * _brickOffset.y, -0.1f);
				}
			}
		}

		public void CreateBall()
		{
			if ((bool)_ball)
			{
				Object.Destroy(_ball.gameObject);
			}
			_ball = Object.Instantiate(_ballPrefab, base.transform);
			_ball.transform.localPosition = new Vector3(0f, -3.75f, -0.1f);
		}

		public void BallLost()
		{
			StartCoroutine(_ballLost());
		}

		public void BrickDestroyed()
		{
			UISounds.CraftStep();
			GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			if (_brickParent.childCount >= 10)
			{
				return;
			}
			foreach (Transform item in _brickParent)
			{
				item.localPosition += new Vector3(0f, _brickOffset.y, 0f);
			}
			for (int i = 0; i < _brickCount.x; i++)
			{
				Object.Instantiate(_brickPrefab, _brickParent).transform.localPosition = new Vector3(_brickStart.x + (float)i * _brickOffset.x, _brickStart.y, -0.1f);
			}
		}

		private IEnumerator _ballLost()
		{
			yield return new WaitForSeconds(1.5f);
			CreateBall();
		}
	}
}
