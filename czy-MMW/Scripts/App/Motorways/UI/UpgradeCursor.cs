using Client;
using Factory;
using Factory.Pools;
using Motorways.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	[RequireComponent(typeof(RectTransform))]
	public class UpgradeCursor : MonoBehaviour, IView, IReusable
	{
		public enum UpgradeCursorOffsetType
		{
			OnPointer = 0,
			TopLeft = 1,
			TopRight = 2
		}

		public static Diagnostics.Log.Channel Log = new Diagnostics.Log.Channel("UpgradeCursor");

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private TilemapView _tilemapView;

		private RectTransform _rectTransform;

		[SerializeField]
		private RectTransform _cursorIconTransform;

		private bool _assetPlaced;

		private bool _assetActionCancelled;

		[SerializeField]
		private Image _upgradeSprite;

		public float verticalOffset = 20f;

		public float horizontalOffset = 20f;

		public Vector2 Position => _cursorIconTransform.anchoredPosition;

		public void Initialize(Sprite sprite, RectTransform parentTransform)
		{
			_assetPlaced = false;
			_assetActionCancelled = false;
			_upgradeSprite.sprite = sprite;
			_rectTransform = GetComponent<RectTransform>();
			_rectTransform.SetParent(parentTransform);
			_rectTransform.localPosition = Vector3.zero;
			_rectTransform.localScale = Vector3.one;
			_viewClient.AddView(this);
		}

		public void SetPosition(Vector2 screenPosition, UpgradeCursorOffsetType offsetType = UpgradeCursorOffsetType.TopLeft)
		{
			_rectTransform.anchoredPosition = screenPosition;
			switch (offsetType)
			{
			case UpgradeCursorOffsetType.OnPointer:
				_cursorIconTransform.anchoredPosition = Vector2.zero;
				break;
			case UpgradeCursorOffsetType.TopLeft:
				_cursorIconTransform.anchoredPosition = new Vector2(0f - horizontalOffset, verticalOffset);
				break;
			case UpgradeCursorOffsetType.TopRight:
				_cursorIconTransform.anchoredPosition = new Vector2(horizontalOffset, verticalOffset);
				break;
			}
		}

		public Vector2Int GetTileCoordinates()
		{
			return _tilemapView.GetTileCoordinatesFromWorldPosition(_cursorIconTransform.position);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_assetActionCancelled)
			{
				base.gameObject.SetActive(value: false);
				return TickResult.Destroy;
			}
			if (_assetPlaced)
			{
				base.gameObject.SetActive(value: false);
				return TickResult.Destroy;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void PlaceAssetAtPosition(Vector2Int tilePosition)
		{
			_assetPlaced = true;
		}

		public void CancelUpgradeCursor()
		{
			_assetActionCancelled = true;
			base.gameObject.SetActive(value: false);
		}

		public void Reset()
		{
			_assetPlaced = false;
			_assetActionCancelled = false;
			base.transform.localPosition = Vector3.zero;
		}
	}
}
