using System.Collections.Generic;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.EditorScript;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_Raycaster : MonoBehaviour, I_BE2_Raycaster
	{
		public struct ConnectionPoint
		{
			public I_BE2_Spot spot;

			public I_BE2_Block block;
		}

		private BE2_DragDropManager _dragDropManager;

		private PointerEventData _pointerEventData;

		[SerializeField]
		private GraphicRaycaster[] raycasters;

		[SerializeField]
		private EventSystem eventSystem;

		private void Awake()
		{
			_dragDropManager = GetComponent<BE2_DragDropManager>();
		}

		public GraphicRaycaster[] AddRaycaster(GraphicRaycaster raycaster = null)
		{
			if (raycaster != null && BE2_ArrayUtils.Find(ref raycasters, (GraphicRaycaster x) => x == raycaster) == null)
			{
				BE2_ArrayUtils.Add(ref raycasters, raycaster);
			}
			return raycasters;
		}

		public GraphicRaycaster[] RemoveRaycaster(GraphicRaycaster raycaster)
		{
			if (BE2_ArrayUtils.Find(ref raycasters, (GraphicRaycaster x) => x == raycaster) != null)
			{
				BE2_ArrayUtils.Remove(ref raycasters, raycaster);
			}
			return raycasters;
		}

		public I_BE2_Drag GetDragAtPosition(Vector2 position)
		{
			_pointerEventData = new PointerEventData(eventSystem);
			if (BE2_Inspector.Instance.CanvasRenderMode == RenderMode.ScreenSpaceOverlay)
			{
				_pointerEventData.position = position;
			}
			else
			{
				_pointerEventData.position = BE2_Inspector.Instance.Camera.WorldToScreenPoint(BE2_Pointer.Instance.transform.position);
			}
			List<RaycastResult> list = new List<RaycastResult>();
			int num = raycasters.Length;
			for (int i = 0; i < num; i++)
			{
				List<RaycastResult> list2 = new List<RaycastResult>();
				raycasters[i].Raycast(_pointerEventData, list2);
				list.AddRange(list2);
			}
			int count = list.Count;
			for (int j = 0; j < count; j++)
			{
				I_BE2_Drag componentInParent = list[j].gameObject.GetComponentInParent<I_BE2_Drag>();
				if (componentInParent != null)
				{
					return componentInParent;
				}
			}
			return null;
		}

		public I_BE2_Spot GetSpotAtPosition(Vector3 position)
		{
			_pointerEventData = new PointerEventData(eventSystem);
			if (BE2_Inspector.Instance.CanvasRenderMode == RenderMode.ScreenSpaceOverlay)
			{
				_pointerEventData.position = position;
			}
			else
			{
				_pointerEventData.position = BE2_Inspector.Instance.Camera.WorldToScreenPoint(BE2_Pointer.Instance.transform.position);
			}
			List<RaycastResult> list = new List<RaycastResult>();
			int num = raycasters.Length;
			for (int i = 0; i < num; i++)
			{
				List<RaycastResult> list2 = new List<RaycastResult>();
				raycasters[i].Raycast(_pointerEventData, list2);
				list.AddRange(list2);
			}
			int count = list.Count;
			for (int j = 0; j < count; j++)
			{
				RaycastResult raycastResult = list[j];
				if (raycastResult.gameObject.activeSelf)
				{
					I_BE2_Spot component = raycastResult.gameObject.GetComponent<I_BE2_Spot>();
					if (component != null)
					{
						return component;
					}
				}
			}
			return null;
		}

		public I_BE2_Spot FindClosestSpotOfType<T>(I_BE2_Drag drag, float maxDistance)
		{
			float num = float.PositiveInfinity;
			I_BE2_Spot result = null;
			int count = _dragDropManager.SpotsList.Count;
			for (int i = 0; i < count; i++)
			{
				I_BE2_Spot i_BE2_Spot = _dragDropManager.SpotsList[i];
				if (!(i_BE2_Spot is T) || !i_BE2_Spot.Transform.gameObject.activeSelf)
				{
					continue;
				}
				I_BE2_Drag componentInParent = i_BE2_Spot.Transform.GetComponentInParent<I_BE2_Drag>();
				I_BE2_ProgrammingEnv componentInParent2 = componentInParent.Transform.GetComponentInParent<BE2_ProgrammingEnv>();
				if (componentInParent != drag && componentInParent2 != null && componentInParent2.Visible)
				{
					float num2 = Vector2.Distance(drag.RayPoint, i_BE2_Spot.DropPosition);
					if (num2 < num && num2 <= maxDistance)
					{
						result = i_BE2_Spot;
						num = num2;
					}
				}
			}
			return result;
		}

		public I_BE2_Spot FindClosestConnectableSpot(I_BE2_Drag drag, float maxDistance)
		{
			float num = float.PositiveInfinity;
			ConnectionPoint connectionPoint = new ConnectionPoint
			{
				spot = null
			};
			int count = _dragDropManager.SpotsList.Count;
			for (int i = 0; i < count; i++)
			{
				I_BE2_Spot i_BE2_Spot = _dragDropManager.SpotsList[i];
				I_BE2_ProgrammingEnv componentInParent = i_BE2_Spot.Transform.GetComponentInParent<BE2_ProgrammingEnv>();
				if (componentInParent != null && componentInParent.Visible && i_BE2_Spot.Transform.gameObject.activeSelf && drag.Block != i_BE2_Spot.Block)
				{
					float num2 = Vector2.Distance(drag.RayPoint, i_BE2_Spot.DropPosition);
					if (num2 < num && num2 <= maxDistance)
					{
						connectionPoint.spot = i_BE2_Spot;
						num = num2;
					}
				}
			}
			return connectionPoint.spot;
		}

		public I_BE2_Block FindClosestConnectableBlock(I_BE2_Drag drag, float maxDistance)
		{
			float num = float.PositiveInfinity;
			ConnectionPoint connectionPoint = new ConnectionPoint
			{
				spot = null
			};
			I_BE2_ProgrammingEnv i_BE2_ProgrammingEnv = null;
			foreach (I_BE2_ProgrammingEnv programmingEnvs in BE2_ExecutionManager.Instance.ProgrammingEnvsList)
			{
				if (programmingEnvs.Visible)
				{
					i_BE2_ProgrammingEnv = programmingEnvs;
					break;
				}
			}
			if (i_BE2_ProgrammingEnv != null)
			{
				Vector3 position = drag.Block.Layout.OuterArea.Transform.position;
				if (drag.Block.Layout.OuterArea.childBlocksCount > 0)
				{
					position = drag.Block.Layout.OuterArea.childBlocksArray[drag.Block.Layout.OuterArea.childBlocksCount - 1].Layout.OuterArea.Transform.position;
				}
				foreach (Transform item in i_BE2_ProgrammingEnv.Transform)
				{
					I_BE2_Block component = item.GetComponent<I_BE2_Block>();
					if (component != null && !(component is BE2_GhostBlock) && component.Type != BlockTypeEnum.define && component.Type != BlockTypeEnum.operation && component.Type != BlockTypeEnum.trigger)
					{
						float num2 = Vector2.Distance(position, component.Drag.RayPoint);
						if (num2 < num && num2 <= maxDistance)
						{
							connectionPoint.spot = null;
							connectionPoint.block = component;
							num = num2;
						}
					}
				}
			}
			return connectionPoint.block;
		}
	}
}
