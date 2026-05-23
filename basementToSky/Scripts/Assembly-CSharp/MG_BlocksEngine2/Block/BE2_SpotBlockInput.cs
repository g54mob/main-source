using MG_BlocksEngine2.DragDrop;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	public class BE2_SpotBlockInput : MonoBehaviour, I_BE2_Spot
	{
		private BE2_DragDropManager _dragDropManager;

		private RectTransform _rectTransform;

		private Transform _transform;

		public UnityEngine.UI.Outline outline;

		public Transform Transform
		{
			get
			{
				if (!_transform)
				{
					return base.transform;
				}
				return _transform;
			}
		}

		public Vector2 DropPosition => _rectTransform.position;

		public I_BE2_Block Block { get; set; }

		private void Awake()
		{
			_transform = base.transform;
			_dragDropManager = BE2_DragDropManager.Instance;
			_rectTransform = GetComponent<RectTransform>();
			outline = GetComponent<UnityEngine.UI.Outline>();
			Block = GetComponentInParent<I_BE2_Block>();
		}

		private void OnEnable()
		{
			_dragDropManager.AddToSpotsList(this);
		}

		private void OnDisable()
		{
			_dragDropManager.RemoveFromSpotsList(this);
		}
	}
}
