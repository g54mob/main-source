using System;
using Assets.Source.UI;
using UnityEngine;

public class OverviewCopyGhost : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _sprite;

	private bool _startClick;

	private Vector2Int _startPosition;

	private Vector2Int _endPosition;

	private void Start()
	{
	}

	private void Update()
	{
		if (PlayerControls.InputCancel)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		_ = UIHelper.IsMouseOverUi;
		Vector2 mouseWorld = PlayerControls.MouseWorld;
		Vector3 localScale = base.transform.parent.localScale;
		Vector2 vector = base.transform.parent.localPosition;
		Vector2Int vector2Int = new Vector2Int(Mathf.RoundToInt((mouseWorld.x - vector.x) / (1.5f * localScale.x)), Mathf.RoundToInt((mouseWorld.y - vector.y) / (1.5f * localScale.y)));
		if (Input.GetMouseButtonDown(0))
		{
			_startClick = true;
			_startPosition = vector2Int;
		}
		if (PlayerControls.InteractRelease)
		{
			OverviewUI.Instance.ShowCopyAreaGhost(_startPosition, _endPosition);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (_startClick)
		{
			_endPosition = vector2Int;
			int num = Math.Abs(_startPosition.x - _endPosition.x) + 1;
			int num2 = Math.Abs(_startPosition.y - _endPosition.y) + 1;
			_sprite.size = new Vector2((float)num * 1.5f, (float)num2 * 1.5f);
			base.transform.localPosition = new Vector3((float)(_startPosition.x + _endPosition.x) / 2f * 1.5f, (float)(_startPosition.y + _endPosition.y) / 2f * 1.5f, 0f);
		}
		else
		{
			base.transform.localPosition = new Vector3((float)vector2Int.x * 1.5f, (float)vector2Int.y * 1.5f, 0f);
		}
	}
}
