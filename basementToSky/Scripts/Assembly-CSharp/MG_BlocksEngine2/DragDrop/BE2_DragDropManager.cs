using System.Collections;
using System.Collections.Generic;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI;
using UnityEngine;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_DragDropManager : MonoBehaviour
	{
		private BE2_UI_ContextMenuManager _contextMenuManager;

		private static BE2_DragDropManager _instance;

		public Transform draggedObjectsTransform;

		private List<I_BE2_Spot> _spotsList;

		[SerializeField]
		private Transform _ghostBlock;

		public bool isDragging;

		public float detectionDistance = 40f;

		private static Canvas _dragDropComponentsCanvas;

		public static bool disableGroupDrag;

		public static BE2_DragDropManager Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = Object.FindObjectOfType<BE2_DragDropManager>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public I_BE2_Raycaster Raycaster { get; set; }

		public Transform DraggedObjectsTransform => draggedObjectsTransform;

		public I_BE2_Drag CurrentDrag { get; set; }

		public BE2_Raycaster.ConnectionPoint ConnectionPoint { get; set; }

		public List<I_BE2_Spot> SpotsList
		{
			get
			{
				if (_spotsList == null)
				{
					_spotsList = new List<I_BE2_Spot>();
				}
				return _spotsList;
			}
			set
			{
				_spotsList = value;
			}
		}

		public Transform GhostBlockTransform => _ghostBlock;

		public static Canvas DragDropComponentsCanvas
		{
			get
			{
				if (!_dragDropComponentsCanvas)
				{
					_dragDropComponentsCanvas = Instance.draggedObjectsTransform.GetComponentInParent<Canvas>();
				}
				return _dragDropComponentsCanvas;
			}
		}

		private static void DisableGroupDrag()
		{
			disableGroupDrag = true;
		}

		private static void EnableGroupDrag()
		{
			disableGroupDrag = false;
		}

		private void Awake()
		{
			Raycaster = GetComponent<I_BE2_Raycaster>();
			_dragDropComponentsCanvas = Instance.draggedObjectsTransform.GetComponentInParent<BE2_Canvas>().Canvas;
		}

		private void Start()
		{
			_contextMenuManager = BE2_UI_ContextMenuManager.instance;
		}

		private void OnEnable()
		{
			Instance = this;
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyDown, OnPointerDown);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnSecondaryKeyDown, OnRightPointerDownOrHold);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyHold, OnRightPointerDownOrHold);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnDrag, OnDrag);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUp, OnPointerUp);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAuxKeyDown, DisableGroupDrag);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAuxKeyUp, EnableGroupDrag);
		}

		private void OnDisable()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyDown, OnPointerDown);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnSecondaryKeyDown, OnRightPointerDownOrHold);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyHold, OnRightPointerDownOrHold);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnDrag, OnDrag);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUp, OnPointerUp);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAuxKeyDown, DisableGroupDrag);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAuxKeyUp, EnableGroupDrag);
		}

		private IEnumerator C_OnPointerDown()
		{
			yield return new WaitForEndOfFrame();
			I_BE2_Drag dragAtPosition = Raycaster.GetDragAtPosition(BE2_InputManager.Instance.ScreenPointerPosition);
			if (dragAtPosition != null)
			{
				CurrentDrag = dragAtPosition;
				dragAtPosition.OnPointerDown();
			}
			else
			{
				CurrentDrag = null;
			}
		}

		private void OnPointerDown()
		{
			StartCoroutine(C_OnPointerDown());
		}

		private void OnRightPointerDownOrHold()
		{
		}

		private void OnDrag()
		{
			if (CurrentDrag != null)
			{
				if (!isDragging)
				{
					CurrentDrag.OnDragStart();
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnDragStart);
					StartCoroutine(C_HandleDragEvents(CurrentDrag.Block));
				}
				CurrentDrag.OnDrag();
				isDragging = true;
			}
		}

		private void OnPointerUp()
		{
			if (CurrentDrag != null && isDragging)
			{
				CurrentDrag.OnPointerUp();
				StartCoroutine(C_HandleDropEvents(CurrentDrag.Block));
			}
			CurrentDrag = null;
			ConnectionPoint = default(BE2_Raycaster.ConnectionPoint);
			GhostBlockTransform.SetParent(null);
			isDragging = false;
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnPrimaryKeyUpEnd);
		}

		private IEnumerator C_HandleDropEvents(I_BE2_Block block)
		{
			yield return new WaitForEndOfFrame();
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDrop, (block as Object) ? block : null);
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnBlockDrop);
			if (block as Object != null)
			{
				block.Instruction.InstructionBase.BlocksStack = block.Transform.GetComponentInParent<I_BE2_BlocksStack>();
				block.ParentSection = block.Transform.GetComponentInParent<I_BE2_BlockSection>();
				if (block.ParentSection == null)
				{
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDropAtProgrammingEnv, block);
				}
				else if (block.Transform.parent.GetComponent<I_BE2_BlockSectionHeader>() != null)
				{
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDropAtInputSpot, block);
				}
				else
				{
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDropAtStack, block);
				}
			}
			else
			{
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDropDestroy, null);
			}
		}

		private IEnumerator C_HandleDragEvents(I_BE2_Block block)
		{
			I_BE2_BlockSectionHeader parentHeader = null;
			if (block as Object != null)
			{
				block.Instruction.InstructionBase.BlocksStack = block.Transform.GetComponentInParent<I_BE2_BlocksStack>();
				block.ParentSection = block.Transform.GetComponentInParent<I_BE2_BlockSection>();
				parentHeader = block.Transform.parent.GetComponent<I_BE2_BlockSectionHeader>();
			}
			yield return new WaitForEndOfFrame();
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDragOut, (block as Object) ? block : null);
			if (block as Object != null)
			{
				if (parentHeader != null)
				{
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDragFromInputSpot, block);
				}
				else if (block.ParentSection == null)
				{
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDragFromProgrammingEnv, block);
				}
				else
				{
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDragFromStack, block);
				}
			}
			else
			{
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnDragFromOutside, null);
			}
		}

		public void AddToSpotsList(I_BE2_Spot spot)
		{
			if (!SpotsList.Contains(spot) && spot != null)
			{
				SpotsList.Add(spot);
			}
		}

		public void RemoveFromSpotsList(I_BE2_Spot spot)
		{
			if (SpotsList.Contains(spot))
			{
				SpotsList.Remove(spot);
			}
		}
	}
}
