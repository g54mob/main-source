using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GRP.Pages.NSProjectFrame
{
	public class ModuleItemView : View<ModuleItemViewable>
	{
		public Transform anchor;

		public Canvas anchorCanvas;

		public ScrollRect scrollRect;

		public TooltipArea tooltip;

		public OrbitCameraController orbitCamera;

		public RawImage thumbnail;

		public Transform edge;

		public bool showGround;

		public float createDistance;

		public float destroyDistance;

		public CreatedPartContainer partContainer;

		private Vector3 offset;

		private Vector3 defaultPosition;

		private Texture thumbnailTexture;

		private bool isDrag;

		private Debouncer debouncer;

		protected override void OnViewCreated()
		{
		}

		protected override void Update()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		public void Select()
		{
		}

		private void CheckThumbnail()
		{
		}

		public void UpdateThumbnail()
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
	}
}
