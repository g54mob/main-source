using System.Collections.Generic;
using FractureField.Controllers;
using FractureField.Rocks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FractureField.UI
{
	public class BombDragHandler : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
	{
		[Header("Settings")]
		public Color explosionPreviewColor;

		[SerializeField]
		private Canvas _topCanvas;

		[SerializeField]
		private CursorController _cursorController;

		private GameObject _dragVisual;

		private GameObject _explosionPreview;

		private CanvasGroup _canvasGroup;

		private static BombDragHandler _currentlyDragging;

		private static BombDragHandler _currentlyEquipped;

		private bool _isEquipped;

		private bool _isDragging;

		private Color _originalIconColor;

		private Image _iconImage;

		private Vector3 _originalPosition;

		private RectTransform _rectTransform;

		private List<Rock> _currentlyTargetedRocks;

		private bool _isHoldingXKey;

		private float _radiusDisplayTimer;

		private const float RadiusDisplayDuration = 0.5f;

		public const KeyCode BombHotkey = KeyCode.X;

		public static bool IsDraggingBomb => false;

		public static bool IsBombEquipped => false;

		public static bool IsHoldingXForBomb { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		private Sprite CreateCircleOutlineSprite()
		{
			return null;
		}

		private void Equip()
		{
		}

		private void Unequip()
		{
		}

		private void CreateDragVisual()
		{
		}

		private void CreateEquippedPreview()
		{
		}

		private void UpdateEquippedPreview()
		{
		}

		private void TryPlaceBombAtMouse()
		{
		}

		private bool IsPositionInQuarry(Vector2 position)
		{
			return false;
		}

		private bool IsPointerOverBombContainer(PointerEventData eventData)
		{
			return false;
		}

		private void OnDestroy()
		{
		}

		private void UpdateIconOpacity()
		{
		}

		private void UpdateTargetedRocks(Vector2 bombPosition)
		{
		}

		private void ClearTargetedRocks()
		{
		}

		private void HandleXKeyBombPlacement()
		{
		}

		private Vector3 ApplyToolImpactOffset(Vector3 position)
		{
			return default(Vector3);
		}
	}
}
