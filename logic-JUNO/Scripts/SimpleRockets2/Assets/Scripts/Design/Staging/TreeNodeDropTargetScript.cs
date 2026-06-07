using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.Staging
{
	public class TreeNodeDropTargetScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private TreeNodeScript _treeNode;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_treeNode.StagingEditor.IsDragging)
			{
				_treeNode.StagingEditor.EnterDropTarget(GetStageNodeScript(_treeNode), eventData);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (_treeNode.StagingEditor.IsDragging)
			{
				_treeNode.StagingEditor.ExitDropTarget(GetStageNodeScript(_treeNode));
			}
		}

		private void Awake()
		{
			_treeNode = GetComponentInParent<TreeNodeScript>();
		}

		private StageNodeScript GetStageNodeScript(TreeNodeScript treeNode)
		{
			if (treeNode.Parent != null)
			{
				return GetStageNodeScript(treeNode.Parent);
			}
			return treeNode as StageNodeScript;
		}
	}
}
