using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_DragBlock : MonoBehaviour, I_BE2_Drag
	{
		private RectTransform _rectTransform;

		private Transform _transform;

		private BE2_DragDropManager _dragDropManager => BE2_DragDropManager.Instance;

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
			BE2_UI_ContextMenuManager.instance.OpenContextMenu(0, Block);
		}

		public void OnDragStart()
		{
			BE2_OuterArea outerArea = Block.Layout.OuterArea;
			if (!BE2_DragDropManager.disableGroupDrag)
			{
				if (Block.ParentBlock == null)
				{
					return;
				}
				for (int num = base.transform.parent.childCount - 1; num > base.transform.GetSiblingIndex(); num--)
				{
					Transform child = base.transform.parent.GetChild(num);
					if (child.GetComponent<I_BE2_Block>() != null)
					{
						child.SetParent(outerArea.Transform);
						child.SetAsFirstSibling();
					}
				}
			}
			else
			{
				if (base.transform.parent.GetComponent<I_BE2_ProgrammingEnv>() == null || outerArea.childBlocksCount <= 0)
				{
					return;
				}
				I_BE2_Block component = outerArea.childBlocksArray[0].Transform.GetComponent<I_BE2_Block>();
				BE2_OuterArea outerArea2 = component.Layout.OuterArea;
				component.Transform.SetParent(base.transform.parent);
				for (int num2 = outerArea.childBlocksCount - 1; num2 >= 0; num2--)
				{
					Transform transform = outerArea.childBlocksArray[num2].Transform;
					if (transform.GetComponent<I_BE2_Block>() != null)
					{
						transform.SetParent(outerArea2.Transform);
						transform.SetAsFirstSibling();
					}
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
			I_BE2_Spot spot = connectionPoint.spot;
			I_BE2_Block block = connectionPoint.block;
			Transform ghostBlockTransform = _dragDropManager.GhostBlockTransform;
			if (spot != null)
			{
				if (spot is BE2_SpotOuterArea)
				{
					if (spot.Block.ParentSection != null)
					{
						ghostBlockTransform.SetParent(spot.Block.Transform.parent);
						ghostBlockTransform.localScale = Vector3.one;
						ghostBlockTransform.gameObject.SetActive(value: true);
						ghostBlockTransform.SetSiblingIndex(spot.Block.Transform.GetSiblingIndex() + 1);
						spot.Block.ParentSection.UpdateLayout();
					}
					else
					{
						if (spot.Block.Transform.parent.GetComponent<I_BE2_ProgrammingEnv>() == null)
						{
							ghostBlockTransform.SetParent(spot.Block.Transform.parent);
							ghostBlockTransform.SetSiblingIndex(spot.Block.Transform.GetSiblingIndex() + 1);
						}
						else
						{
							ghostBlockTransform.SetParent(spot.Transform);
							ghostBlockTransform.SetAsFirstSibling();
						}
						ghostBlockTransform.localScale = Vector3.one;
						ghostBlockTransform.gameObject.SetActive(value: true);
						LayoutRebuilder.ForceRebuildLayoutImmediate(spot.Transform.parent as RectTransform);
					}
				}
				else if (spot is BE2_SpotBlockBody && spot.Block != Block)
				{
					ghostBlockTransform.SetParent(spot.Transform);
					ghostBlockTransform.localScale = Vector3.one;
					ghostBlockTransform.gameObject.SetActive(value: true);
					ghostBlockTransform.SetSiblingIndex(0);
				}
				else
				{
					ghostBlockTransform.gameObject.SetActive(value: false);
				}
			}
			else if (block != null)
			{
				ghostBlockTransform.SetParent(block.Transform.parent);
				ghostBlockTransform.localScale = block.Transform.localScale;
				ghostBlockTransform.localPosition = Block.Layout.OuterArea.GetTopDropPosition(block);
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
			if (_dragDropManager.ConnectionPoint.spot != null)
			{
				if (_dragDropManager.ConnectionPoint.spot is BE2_SpotBlockBody)
				{
					DropTo(_dragDropManager.ConnectionPoint.spot, 0);
				}
				else if (_dragDropManager.ConnectionPoint.spot is BE2_SpotOuterArea)
				{
					DropTo(_dragDropManager.GhostBlockTransform.parent, _dragDropManager.GhostBlockTransform.GetSiblingIndex());
				}
				else
				{
					DropTo(_dragDropManager.ConnectionPoint.spot.Block.Transform.parent, _dragDropManager.ConnectionPoint.spot.Block.Transform.GetSiblingIndex() + 1);
				}
				Transform transform = Block.Layout.OuterArea.Transform;
				int siblingIndex = base.transform.GetSiblingIndex();
				for (int num = transform.childCount - 1; num >= 0; num--)
				{
					Transform child = transform.GetChild(num);
					if (child.GetComponent<I_BE2_Block>() != null)
					{
						child.SetParent(base.transform.parent);
						child.SetSiblingIndex(siblingIndex + 1);
					}
				}
			}
			else if (_dragDropManager.ConnectionPoint.block != null)
			{
				Block.Transform.SetParent(_dragDropManager.ConnectionPoint.block.Transform.parent);
				_dragDropManager.ConnectionPoint.block.Transform.SetParent(Block.Layout.OuterArea.Transform);
				Transform transform2 = _dragDropManager.ConnectionPoint.block.Layout.OuterArea.Transform;
				int siblingIndex2 = _dragDropManager.ConnectionPoint.block.Transform.GetSiblingIndex();
				for (int num2 = transform2.childCount - 1; num2 >= 0; num2--)
				{
					Transform child2 = transform2.GetChild(num2);
					if (child2.GetComponent<I_BE2_Block>() != null)
					{
						child2.SetParent(_dragDropManager.ConnectionPoint.block.Transform.parent);
						child2.SetSiblingIndex(siblingIndex2 + 1);
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

		private void DropTo(Transform spot, int siblinIndex)
		{
			Transform.SetParent(spot);
			Transform.SetSiblingIndex(siblinIndex);
		}

		private void DropTo(I_BE2_Spot spot, int siblinIndex)
		{
			DropTo(spot.Transform, siblinIndex);
		}

		public void DropTo(I_BE2_Block parentBlock, int sectionIndex, int siblinIndex)
		{
			if (parentBlock.Layout.SectionsArray.Length > sectionIndex && parentBlock.Layout.SectionsArray[sectionIndex].Body != null)
			{
				DropTo(parentBlock.Layout.SectionsArray[sectionIndex].Body.Spot, siblinIndex);
				parentBlock.Instruction.InstructionBase.BlocksStack.PopulateStack();
			}
		}
	}
}
