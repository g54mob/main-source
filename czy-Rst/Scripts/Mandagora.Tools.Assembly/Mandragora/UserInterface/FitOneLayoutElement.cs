using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mandragora.UserInterface
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public class FitOneLayoutElement : UIBehaviour, ILayoutElement
	{
		public enum Axies
		{
			Both = 0,
			Horizontal = 1,
			Vertical = 2
		}

		[SerializeField]
		private UIBehaviour child;

		[SerializeField]
		private Axies axies;

		private ILayoutElement childLayoutElement;

		private float _preferredWidth = -1f;

		private float _preferredHeight = -1f;

		public float minWidth => -1f;

		public float minHeight => -1f;

		public float preferredWidth => _preferredWidth;

		public float preferredHeight => _preferredHeight;

		public float flexibleWidth => -1f;

		public float flexibleHeight => -1f;

		public int layoutPriority => 1;

		protected override void Awake()
		{
			childLayoutElement = child.GetComponent<ILayoutElement>();
		}

		public void CalculateLayoutInputHorizontal()
		{
			if (axies == Axies.Horizontal || axies == Axies.Both)
			{
				_preferredWidth = ((childLayoutElement != null) ? childLayoutElement.preferredWidth : (-1f));
			}
		}

		public void CalculateLayoutInputVertical()
		{
			if (axies == Axies.Vertical || axies == Axies.Both)
			{
				_preferredHeight = ((childLayoutElement != null) ? childLayoutElement.preferredHeight : (-1f));
			}
		}
	}
}
