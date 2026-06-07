using Placemaker.Ui;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker
{
	public class GroundClicker : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, UiMaster.IUiSetup
	{
		public enum DragMode
		{
			NotDragging = 0,
			Undecided = 1,
			Spinning = 2,
			Panning = 3,
			TouchZooming = 4,
			TouchPanning = 5
		}

		[SerializeField]
		private UiMaster master;

		public VoxelType currentVoxelType;

		public bool hovered;

		public bool pressed;

		public bool pressUsed;

		public bool bobbing;

		public bool aboutToRemove;

		public float pressTime;

		public const float removeClickThreshold = 0.32f;

		public const float colorPickClickThreshold = 2f;

		public AudioSource pressSource;

		public DragMode dragMode;

		private int clickFrame;

		private int hoverFrame;

		private Vector3[] drags;

		private int dragIndex;

		private const int dragCount = 5;

		private Maker maker => null;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		private void LateUpdate()
		{
		}

		private void MaybeUpdateHover(Vector2 pos)
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		private void AddClick()
		{
		}

		private void RemoveClick()
		{
		}

		private void PaintClick()
		{
		}

		private void BucketClick()
		{
		}

		private void BulldozeClick()
		{
		}

		private void ColorPick()
		{
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		private void Update()
		{
		}

		private void OnGUI()
		{
		}
	}
}
