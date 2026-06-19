using System.Collections.Generic;
using Loxodon.Framework.Binding;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WorldEnvironment.Islands;
using Zenject;

namespace UI.Map
{
	public class MapView : MonoBehaviour
	{
		[SerializeField]
		private MapSegmentView _seg;

		[SerializeField]
		private Transform _content;

		[SerializeField]
		private Transform _viewPort;

		[SerializeField]
		private TextMeshProUGUI _coordinatesText;

		[SerializeField]
		private Button _plusButton;

		[SerializeField]
		private Button _minusButton;

		[SerializeField]
		private Button _centerButton;

		[SerializeField]
		private float _maxZoomIn;

		[SerializeField]
		private float _maxZoomOut;

		[SerializeField]
		private float _zoomStep;

		private List<MapSegmentView> _segments = new List<MapSegmentView>();

		private Canvas _canvas;

		private float _segmentWidth;

		private float _segmentHeight;

		[Inject]
		private WorldGridManager _worldGridManager;

		[Inject]
		private DiContainer _container;

		private void Awake()
		{
			_canvas = GetComponentInParent<Canvas>();
			_segmentWidth = (_seg.transform as RectTransform).rect.width;
			_segmentHeight = (_seg.transform as RectTransform).rect.height;
		}

		private void Start()
		{
			RectTransform obj = _content as RectTransform;
			DrawMapSegments(5);
			obj.sizeDelta = new Vector2(_seg.GetComponent<RectTransform>().rect.width * 11f, _seg.GetComponent<RectTransform>().rect.height * 11f);
			obj.anchoredPosition = Vector2.zero;
			_plusButton.onClick.AddListener(ZoomInMap);
			_minusButton.onClick.AddListener(ZoomOutMap);
			_centerButton.onClick.AddListener(CenterMap);
		}

		private void Update()
		{
			RectTransform rectTransform = _content as RectTransform;
			Camera cam = ((_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : _canvas.worldCamera);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, cam, out var localPoint);
			localPoint.x += (rectTransform.pivot.x - 0.5f) * rectTransform.rect.width;
			localPoint.y += (rectTransform.pivot.y - 0.5f) * rectTransform.rect.height;
			localPoint += new Vector2(_segmentWidth * 0.5f, _segmentHeight * 0.5f);
			int num = Mathf.FloorToInt(localPoint.x / _segmentWidth);
			int num2 = Mathf.FloorToInt(localPoint.y / _segmentHeight);
			float num3 = localPoint.x - (float)num * _segmentWidth;
			float num4 = localPoint.y - (float)num2 * _segmentHeight;
			float num5 = _segmentWidth / 5f;
			float num6 = _segmentHeight / 5f;
			int num7 = Mathf.FloorToInt(num3 / num5);
			int num8 = Mathf.FloorToInt(num4 / num6);
			int num9 = num * 5 + num7;
			int num10 = num2 * 5 + num8;
			_coordinatesText.text = $"Square: [{num9}, {num10}]";
		}

		private void CenterMap()
		{
			(_content as RectTransform).pivot = new Vector2(0.5f, 0.5f);
			_content.localScale = Vector3.one;
			(_content as RectTransform).anchoredPosition = Vector2.zero;
		}

		private void ZoomOutMap()
		{
			Vector3 localScale = _content.localScale;
			if (!(localScale.x < _maxZoomOut))
			{
				Camera cam = ((_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : _canvas.worldCamera);
				SetPivotToScreenPoint(_content as RectTransform, Input.mousePosition, cam);
				localScale.x -= _zoomStep;
				localScale.y -= _zoomStep;
				_content.localScale = localScale;
			}
		}

		private void ZoomInMap()
		{
			Vector3 localScale = _content.localScale;
			if (!(localScale.x > _maxZoomIn))
			{
				Camera cam = ((_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : _canvas.worldCamera);
				SetPivotToScreenPoint(_content as RectTransform, Input.mousePosition, cam);
				localScale.x += _zoomStep;
				localScale.y += _zoomStep;
				_content.localScale = localScale;
			}
		}

		private void SetPivotToScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rect.parent as RectTransform, screenPoint, cam, out var localPoint);
			Vector2 pivot = new Vector2((localPoint.x - rect.rect.x) / rect.rect.width, (localPoint.y - rect.rect.y) / rect.rect.height);
			SetPivot(rect, pivot);
		}

		private void SetPivot(RectTransform rect, Vector2 pivot)
		{
			Vector2 size = rect.rect.size;
			Vector2 vector = rect.pivot - pivot;
			Vector3 vector2 = new Vector3(vector.x * size.x * rect.localScale.x, vector.y * size.y * rect.localScale.y);
			rect.pivot = pivot;
			rect.localPosition -= vector2;
		}

		public void SetMapPoint(Vector3 worldPos, MapIndicatorView mapIndicator)
		{
			IslandWorldGrid targetGrid = GetGridOfObjective(worldPos);
			Vector3 cellWorldPos = targetGrid.GetCellWorldPos(2, 2, _worldGridManager.WorldCenter.position);
			Vector3 vector = worldPos - cellWorldPos;
			float num = _worldGridManager.GridParams.GridSize * _worldGridManager.GridParams.ChunkSize;
			float num2 = (_seg.transform as RectTransform).sizeDelta.x / num;
			Vector2 vector2 = new Vector2(vector.x * num2, vector.z * num2);
			MapSegmentView mapSegmentView = _segments.Find((MapSegmentView s) => (s.GetDataContext() as MapSegmentViewModel).X == targetGrid.GridX && (s.GetDataContext() as MapSegmentViewModel).Y == targetGrid.GridY);
			mapIndicator = Object.Instantiate(mapIndicator, _content);
			RectTransform obj = mapIndicator.transform as RectTransform;
			RectTransform rectTransform = mapSegmentView.transform as RectTransform;
			obj.localPosition = rectTransform.localPosition + new Vector3(vector2.x, vector2.y, 0f);
			mapIndicator.transform.SetAsLastSibling();
		}

		public void SetMapPointAtMousePosition(MapIndicatorView mapIndicatorPrefab)
		{
			SetMapPointAtScreenPosition(Input.mousePosition, mapIndicatorPrefab);
		}

		public void SetMapPointAtScreenPosition(Vector2 screenPoint, MapIndicatorView mapIndicatorPrefab, Sprite sprite = null)
		{
			RectTransform rect = _content as RectTransform;
			RectTransform rect2 = _viewPort as RectTransform;
			Camera cam = ((_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : _canvas.worldCamera);
			if (!RectTransformUtility.RectangleContainsScreenPoint(rect2, screenPoint, cam))
			{
				Debug.LogWarning("SetMapPointAtScreenPosition: outside viewport.");
				return;
			}
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, cam, out var localPoint);
			MapIndicatorView mapIndicatorView = Object.Instantiate(mapIndicatorPrefab, _content);
			(mapIndicatorView.transform as RectTransform).localPosition = localPoint;
			mapIndicatorView.transform.SetAsLastSibling();
			Debug.Log($"[MapView] Marker spawned at content local pos: {localPoint}");
		}

		private IslandWorldGrid GetGridOfObjective(Vector3 pos)
		{
			return _worldGridManager.GetGridWithWorldPosition(pos);
		}

		private void DrawMapSegments(int range)
		{
			for (int i = -range; i <= range; i++)
			{
				for (int j = -range; j <= range; j++)
				{
					_worldGridManager.GetGridAt(j, i);
					MapSegmentView mapSegmentView = _container.InstantiatePrefabForComponent<MapSegmentView>(_seg, _content);
					MapSegmentViewModel dataContext = new MapSegmentViewModel(j, i);
					mapSegmentView.SetDataContext(dataContext);
					mapSegmentView.CreateBinidng();
					_segments.Add(mapSegmentView);
				}
			}
		}
	}
}
