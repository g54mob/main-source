using Events.UI;
using UnityEngine;

namespace Presentation.UI
{
	public abstract class InfoPanelView : MonoBehaviour
	{
		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		protected RectTransform _panel;

		private readonly float _bufferDistance = 250f;

		private readonly Vector2[] _offsets = new Vector2[4]
		{
			new Vector2(-50f, 20f),
			new Vector2(50f, 20f),
			new Vector2(120f, -30f),
			new Vector2(0f, -70f)
		};

		private readonly Vector2[] _pivot = new Vector2[4]
		{
			new Vector2(1f, 0f),
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f)
		};

		private int _index;

		protected abstract void Awake();

		protected abstract void OnDestroy();

		protected void Show(InfoPanelDto dto)
		{
			_canvas.sortingOrder = (dto.MoveToTop ? 10 : 5);
			base.gameObject.SetActive(value: true);
			SetContent(dto);
			SetPanelPositioning();
			LateUpdate();
		}

		private void LateUpdate()
		{
			_panel.position = GetMousePosition();
			_panel.anchoredPosition += _offsets[_index];
		}

		protected abstract void SetContent(InfoPanelDto dto);

		protected virtual void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		private void SetPanelPositioning()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out var localPoint);
			bool num = localPoint.x + _bufferDistance < (float)(Screen.width / 2);
			bool flag = localPoint.y + _bufferDistance < (float)(Screen.height / 2);
			if (num)
			{
				_index = (flag ? 1 : 2);
			}
			else
			{
				_index = ((!flag) ? 3 : 0);
			}
			_panel.pivot = _pivot[_index];
		}

		private Vector3 GetMousePosition()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out var localPoint);
			return _canvas.transform.TransformPoint(localPoint);
		}
	}
}
