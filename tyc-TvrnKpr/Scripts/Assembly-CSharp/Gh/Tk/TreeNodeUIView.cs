using System.Collections.Generic;
using DG.Tweening;
using I18n;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gh.Tk
{
	public class TreeNodeUIView : Interactable2DUIView, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		public enum NodeState
		{
			NoChildren = 0,
			Open = 1,
			Collapsed = 2
		}

		[SerializeField]
		private Button _expandCollapseButton;

		private HorizontalLayoutGroup _layoutGroup;

		[SerializeField]
		private TextMeshProUGUII18n _nodeLabelText;

		[SerializeField]
		private Transform _arrowTransform;

		private int _depthOffset;

		public int collapseButtonPadding;

		private List<TreeNodeUIView> _childNodes;

		private Tween _dragReturnTween;

		private Vector2 startDragLocalPosition;

		[SerializeField]
		private List<Image> _clickTargets;

		private static TreeNodeUIView CurrentDragTarget;

		private Vector3 _dragPosition;

		[SerializeField]
		private GameObject _edgeOfNodeHoverVisual;

		public TreeList3DUIView ParentTreeList { get; private set; }

		public NodeState CurrentState { get; protected set; }

		public ITreeNode TreeNode { get; private set; }

		public TreeNodeUIView TreeNodeViewParent { get; set; }

		public int Depth { get; set; }

		protected override void Awake()
		{
		}

		public virtual void SetNode(ITreeNode node, TreeNodeUIView nodeParent, TreeList3DUIView listParent)
		{
		}

		protected override void OnClickedSecondaryInternal()
		{
		}

		public void ExpandNode()
		{
		}

		public void CollapseNode()
		{
		}

		public void Kill()
		{
		}

		[ContextMenu("UpdateVisuals")]
		protected void UpdateVisuals()
		{
		}

		public TreeNodeUIView[] GetAllNodes()
		{
			return null;
		}

		private void RepopulateChildNodes(IEnumerable<ITreeNode> childNodes)
		{
		}

		private void ClearChildNodes()
		{
		}

		private void RemoveNodes(IEnumerable<TreeNodeUIView> removeNodes)
		{
		}

		public void UpdateChildNodes()
		{
		}

		public void UpdateChildNodes(IEnumerable<ITreeNode> childNodes)
		{
		}

		public int GetAllChildNodesCount()
		{
			return 0;
		}

		protected virtual List<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		protected override void OnDisable()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		private void LateUpdate()
		{
		}

		private TreeNodeUIView GetFirstValidNode(List<GameObject> objs)
		{
			return null;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		private void SetDraggingState(bool isDragging)
		{
		}

		private bool IsOnVerticalEdgeOfNode(PointerEventData eventData)
		{
			return false;
		}

		public bool IsOnTopEdgeOfNode(PointerEventData eventData)
		{
			return false;
		}

		private void EndDrag()
		{
		}

		private void ResetDrag()
		{
		}

		protected override void OnHoveringInternal(PointerEventData eventData)
		{
		}

		protected override void OnIsHoveredChangedInternal(bool oldValue, bool newValue)
		{
		}

		private void SetEdgeOfNodeHoverVisualActive(bool active)
		{
		}
	}
}
