using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class MasterClicker : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler, IEndDragHandler, IDragHandler, IBeginDragHandler, UiMaster.IUiSetup
	{
		[SerializeField]
		private GraphicRaycaster graphicRaycaster;

		[SerializeField]
		private EventSystem eventSystem;

		[SerializeField]
		private PointerEventData pointerEventData;

		[SerializeField]
		private UiMaster master;

		public VoxelType currentVoxelType;

		public bool hovered;

		public bool bobbing;

		public bool aboutToRemove;

		public bool dragging;

		public bool pointerPressed;

		public bool pointerPressUsed;

		public float pointerPressTime;

		public Vector2 pointerPosition;

		public const float removeVoxelThreshold = 0.25f;

		public const float bobbingStartThreshold = 0.35f;

		public const float colorPickThreshold = 1.5f;

		public AudioSource pressSource;

		private int clickFrame;

		private int hoverFrame;

		private Vector3[] drags;

		private int dragIndex;

		private const int dragCount = 5;

		[SerializeField]
		private const float sameTouchDistanceValue = 0.022f;

		[SerializeField]
		private float touchLocationThreshold;

		private Maker maker => null;

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		private void RemoveHover()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void MaybeUpdateHover(Vector2 position)
		{
		}

		public void TouchDown(Vector2 position)
		{
		}

		public void TouchUp(bool couldAct)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		public Voxel AddClick()
		{
			return null;
		}

		public bool RemoveClick()
		{
			return false;
		}

		public bool ColorPick()
		{
			return false;
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

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		private bool InputReady()
		{
			return false;
		}

		private void OnGUI()
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}
	}
}
