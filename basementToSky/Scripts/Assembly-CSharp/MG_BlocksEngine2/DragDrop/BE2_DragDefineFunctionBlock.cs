using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI;
using UnityEngine;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_DragDefineFunctionBlock : MonoBehaviour, I_BE2_Drag
	{
		private RectTransform _rectTransform;

		private Transform _transform;

		private BE2_DragDropManager _dragDropManager => BE2_DragDropManager.Instance;

		private BE2_ExecutionManager _executionManager => BE2_ExecutionManager.Instance;

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

		public Vector2 RayPoint => _rectTransform.position;

		public I_BE2_Block Block { get; set; }

		private void Awake()
		{
			_transform = base.transform;
			_rectTransform = GetComponent<RectTransform>();
			Block = GetComponent<I_BE2_Block>();
		}

		public void OnPointerDown()
		{
		}

		public void OnRightPointerDownOrHold()
		{
			BE2_UI_ContextMenuManager.instance.OpenContextMenu(0, Block, "noDuplicate");
		}

		public void OnDragStart()
		{
			I_BE2_BlockSectionBody body = Block.Layout.SectionsArray[0].Body;
			if (!BE2_DragDropManager.disableGroupDrag || base.transform.parent.GetComponent<I_BE2_ProgrammingEnv>() == null || body.ChildBlocksCount <= 0)
			{
				return;
			}
			I_BE2_Block component = body.ChildBlocksArray[0].Transform.GetComponent<I_BE2_Block>();
			BE2_OuterArea outerArea = component.Layout.OuterArea;
			component.Transform.SetParent(base.transform.parent);
			for (int num = body.ChildBlocksCount - 1; num >= 0; num--)
			{
				Transform transform = body.ChildBlocksArray[num].Transform;
				if (transform.GetComponent<I_BE2_Block>() != null)
				{
					transform.SetParent(outerArea.Transform);
					transform.SetAsFirstSibling();
				}
			}
		}

		public void OnDrag()
		{
			DetectSpot();
		}

		private void DetectSpot()
		{
			if (Transform.parent != _dragDropManager.DraggedObjectsTransform)
			{
				Transform.SetParent(_dragDropManager.DraggedObjectsTransform, worldPositionStays: true);
			}
			BE2_Raycaster.ConnectionPoint connectionPoint = new BE2_Raycaster.ConnectionPoint
			{
				spot = (_dragDropManager.Raycaster as BE2_Raycaster).FindClosestConnectableSpot(this, _dragDropManager.detectionDistance)
			};
			if (connectionPoint.spot == null)
			{
				connectionPoint.block = (_dragDropManager.Raycaster as BE2_Raycaster).FindClosestConnectableBlock(this, _dragDropManager.detectionDistance);
			}
			_dragDropManager.ConnectionPoint = connectionPoint;
			I_BE2_Block block = connectionPoint.block;
			Transform ghostBlockTransform = _dragDropManager.GhostBlockTransform;
			if (block != null)
			{
				ghostBlockTransform.SetParent(block.Transform.parent);
				ghostBlockTransform.localScale = block.Transform.localScale;
				ghostBlockTransform.localPosition = block.Transform.localPosition + new Vector3(0f, (ghostBlockTransform as RectTransform).sizeDelta.y - 10f, 0f);
				ghostBlockTransform.gameObject.SetActive(value: true);
			}
			else
			{
				ghostBlockTransform.gameObject.SetActive(value: false);
			}
			ghostBlockTransform.localPosition = new Vector3(ghostBlockTransform.localPosition.x, ghostBlockTransform.localPosition.y, 0f);
			ghostBlockTransform.localEulerAngles = Vector3.zero;
		}

		public void OnPointerUp()
		{
			if (_dragDropManager.ConnectionPoint.block != null)
			{
				Block.Transform.SetParent(_dragDropManager.ConnectionPoint.block.Transform.parent);
				_dragDropManager.ConnectionPoint.block.Transform.SetParent(Block.Layout.SectionsArray[0].Body.RectTransform);
				Transform transform = _dragDropManager.ConnectionPoint.block.Layout.OuterArea.Transform;
				int siblingIndex = _dragDropManager.ConnectionPoint.block.Transform.GetSiblingIndex();
				for (int num = transform.childCount - 1; num >= 0; num--)
				{
					Transform child = transform.GetChild(num);
					if (child.GetComponent<I_BE2_Block>() != null)
					{
						child.SetParent(_dragDropManager.ConnectionPoint.block.Transform.parent);
						child.SetSiblingIndex(siblingIndex + 1);
					}
				}
			}
			else
			{
				I_BE2_Spot spotAtPosition = _dragDropManager.Raycaster.GetSpotAtPosition(RayPoint);
				if (spotAtPosition == null)
				{
					spotAtPosition = _dragDropManager.Raycaster.GetSpotAtPosition(BE2_InputManager.Instance.CanvasPointerPosition);
				}
				if (spotAtPosition != null)
				{
					I_BE2_ProgrammingEnv componentInParent = spotAtPosition.Transform.GetComponentInParent<I_BE2_ProgrammingEnv>();
					if (componentInParent == null && spotAtPosition.Transform.GetChild(0) != null)
					{
						componentInParent = spotAtPosition.Transform.GetChild(0).GetComponentInParent<I_BE2_ProgrammingEnv>();
					}
					if (componentInParent != null)
					{
						Transform.SetParent(componentInParent.Transform);
					}
					else
					{
						Object.Destroy(Transform.gameObject);
					}
				}
				else
				{
					Object.Destroy(Transform.gameObject);
				}
			}
			Transform.localPosition = new Vector3(Transform.localPosition.x, Transform.localPosition.y, 0f);
			Transform.localEulerAngles = Vector3.zero;
			Block.Instruction.InstructionBase.UpdateTargetObject();
		}
	}
}
