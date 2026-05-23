using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI;
using UnityEngine;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_DragOperation : MonoBehaviour, I_BE2_Drag
	{
		private RectTransform _rectTransform;

		[HideInInspector]
		[SerializeField]
		private Transform _usedSpotTransform;

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
		}

		public void OnDrag()
		{
			if (_usedSpotTransform != null)
			{
				_usedSpotTransform.SetSiblingIndex(Transform.GetSiblingIndex());
				_usedSpotTransform.gameObject.SetActive(value: true);
				_usedSpotTransform = null;
			}
			if (Transform.parent != _dragDropManager.DraggedObjectsTransform)
			{
				Transform.SetParent(_dragDropManager.DraggedObjectsTransform, worldPositionStays: true);
			}
			BE2_Raycaster.ConnectionPoint connectionPoint = default(BE2_Raycaster.ConnectionPoint);
			I_BE2_Spot i_BE2_Spot = _dragDropManager.Raycaster.FindClosestSpotOfType<BE2_SpotBlockInput>(this, _dragDropManager.detectionDistance);
			if (i_BE2_Spot != null)
			{
				if (_dragDropManager.ConnectionPoint.spot != null && _dragDropManager.ConnectionPoint.spot != i_BE2_Spot)
				{
					(_dragDropManager.ConnectionPoint.spot as BE2_SpotBlockInput).outline.enabled = false;
				}
				connectionPoint.spot = i_BE2_Spot;
				_dragDropManager.ConnectionPoint = connectionPoint;
				(_dragDropManager.ConnectionPoint.spot as BE2_SpotBlockInput).outline.enabled = true;
			}
			else if (_dragDropManager.ConnectionPoint.spot != null)
			{
				(_dragDropManager.ConnectionPoint.spot as BE2_SpotBlockInput).outline.enabled = false;
				connectionPoint.spot = null;
				_dragDropManager.ConnectionPoint = connectionPoint;
			}
		}

		public void OnPointerUp()
		{
			if (_dragDropManager.ConnectionPoint.spot != null)
			{
				DropTo(_dragDropManager.ConnectionPoint.spot);
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

		private void OnDisable()
		{
			if (_usedSpotTransform != null)
			{
				_usedSpotTransform.gameObject.SetActive(value: true);
				_usedSpotTransform = null;
			}
			if (Transform.parent != _dragDropManager.DraggedObjectsTransform)
			{
				Transform.gameObject.SetActive(value: false);
			}
		}

		private void DropTo(I_BE2_Spot spot)
		{
			Transform.SetParent(spot.Transform.parent);
			Transform.SetSiblingIndex(spot.Transform.GetSiblingIndex());
			(spot as BE2_SpotBlockInput).outline.enabled = false;
			_usedSpotTransform = spot.Transform;
			_usedSpotTransform.gameObject.SetActive(value: false);
		}

		public void DropTo(I_BE2_Block parentBlock, int sectionIndex, int inputIndex)
		{
			if (parentBlock.Layout.SectionsArray.Length > sectionIndex && parentBlock.Layout.SectionsArray[sectionIndex].Header.InputsArray.Length > inputIndex)
			{
				I_BE2_Spot component = parentBlock.Layout.SectionsArray[sectionIndex].Header.InputsArray[inputIndex].Transform.GetComponent<I_BE2_Spot>();
				if (component != null)
				{
					DropTo(component);
					parentBlock.Layout.SectionsArray[sectionIndex].Header.UpdateInputsArray();
					parentBlock.Layout.SectionsArray[sectionIndex].Header.UpdateItemsArray();
					parentBlock.Instruction.InstructionBase.BlocksStack.PopulateStack();
					parentBlock.Instruction.InstructionBase.UpdateTargetObject();
				}
			}
		}
	}
}
