using UnityEngine;
using UnityEngine.EventSystems;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	[RequireComponent(typeof(RectTransform))]
	public sealed class UIPointer : UIBehaviour
	{
		[Tooltip("Should the hardware pointer be hidden?")]
		[SerializeField]
		private bool _hideHardwarePointer;

		[Tooltip("Sets the pointer to the last sibling in the parent hierarchy. Do not enable this on multiple UIPointers under the same parent transform or they will constantly fight each other for dominance.")]
		[SerializeField]
		private bool _autoSort;

		private Canvas _canvas;

		public bool autoSort
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		protected override void OnTransformParentChanged()
		{
		}

		protected override void OnCanvasGroupChanged()
		{
		}

		public void OnScreenPositionChanged(Vector2 screenPosition)
		{
		}

		private void GetDependencies()
		{
		}
	}
}
