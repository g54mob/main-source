using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.EditorScript;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_DragSelectionFunction : MonoBehaviour, I_BE2_Drag
	{
		private RectTransform _rectTransform;

		private BE2_UI_SelectionBlock _uiSelectionBlock;

		private ScrollRect _scrollRect;

		private I_BE2_BlockLayout _blockLayout;

		private Transform _transform;

		[HideInInspector]
		public BE2_Ins_FunctionBlock functionBlockInstruction;

		public BE2_Ins_DefineFunction defineFunctionInstruction;

		private Vector3 _envScale = Vector3.one;

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

		public I_BE2_Block Block => null;

		private void Awake()
		{
			_transform = base.transform;
			_rectTransform = GetComponent<RectTransform>();
			_uiSelectionBlock = GetComponent<BE2_UI_SelectionBlock>();
			_scrollRect = GetComponentInParent<ScrollRect>();
			_blockLayout = GetComponent<I_BE2_BlockLayout>();
		}

		private void OnEnable()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypesBlock.OnFunctionDefinitionRemoved, Remove);
		}

		private void OnDestroy()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypesBlock.OnFunctionDefinitionRemoved, Remove);
		}

		private void Remove(I_BE2_Block block)
		{
			if (defineFunctionInstruction.Block == block)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void OnPointerDown()
		{
			_envScale = BE2_ExecutionManager.Instance.ProgrammingEnvsList.Find((I_BE2_ProgrammingEnv x) => x.Visible).Transform.localScale;
		}

		public void OnRightPointerDownOrHold()
		{
		}

		public void OnDragStart()
		{
		}

		public void OnDrag()
		{
			_scrollRect.StopMovement();
			_scrollRect.enabled = false;
			GameObject gameObject = Object.Instantiate(_uiSelectionBlock.prefabBlock);
			gameObject.name = _uiSelectionBlock.prefabBlock.name;
			I_BE2_Block component = gameObject.GetComponent<I_BE2_Block>();
			functionBlockInstruction = gameObject.GetComponent<BE2_Ins_FunctionBlock>();
			functionBlockInstruction.Initialize(defineFunctionInstruction);
			I_BE2_BlockLayout component2 = gameObject.GetComponent<I_BE2_BlockLayout>();
			int num = 0;
			I_BE2_BlockSectionHeaderItem[] itemsArray = defineFunctionInstruction.Block.Layout.SectionsArray[0].Header.ItemsArray;
			foreach (I_BE2_BlockSectionHeaderItem i_BE2_BlockSectionHeaderItem in itemsArray)
			{
				if (num == 0)
				{
					num++;
					continue;
				}
				if (i_BE2_BlockSectionHeaderItem is BE2_BlockSectionHeader_Label)
				{
					Object.Instantiate(BE2_Inspector.Instance.LabelTextTemplate, Vector3.zero, Quaternion.identity, component2.SectionsArray[0].Header.RectTransform).GetComponent<TMP_Text>().text = i_BE2_BlockSectionHeaderItem.Transform.GetComponent<TMP_Text>().text;
				}
				else if (i_BE2_BlockSectionHeaderItem is BE2_BlockSectionHeader_LocalVariable)
				{
					Object.Instantiate(BE2_Inspector.Instance.InputFieldTemplate, Vector3.zero, Quaternion.identity, component2.SectionsArray[0].Header.RectTransform).GetComponent<TMP_InputField>().text = "";
				}
				num++;
			}
			component.Drag.Transform.SetParent(_dragDropManager.DraggedObjectsTransform, worldPositionStays: true);
			gameObject.GetComponent<I_BE2_BlocksStack>();
			gameObject.transform.localScale = _envScale;
			gameObject.transform.position = base.transform.position;
			_dragDropManager.CurrentDrag = component.Drag;
			component.Drag.OnPointerDown();
			component.Drag.OnDrag();
			component.Transform.localEulerAngles = Vector3.zero;
		}

		public void OnPointerUp()
		{
		}
	}
}
