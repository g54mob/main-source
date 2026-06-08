using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class SelectionToolPreviewer : MonoBehaviour
	{
		[FormerlySerializedAs("id")]
		[SerializeField]
		private ToolId toolId;

		[SerializeField]
		private InputRouter inputRouter;

		[FormerlySerializedAs("deletionPreview")]
		[SerializeField]
		private GameObject previewObject;

		private SelectionToolPreview toolPreview;

		private void Start()
		{
			toolPreview = previewObject.GetComponentInChildren<SelectionToolPreview>();
			inputRouter.OnToolPreview += ShowPreviewAtTile;
			inputRouter.OnToolUsed += UseTool;
			toolPreview.Show(show: false, animate: false);
		}

		private void EnableTool(ToolId targetTool, bool isEnabled)
		{
			if (toolId == targetTool && !isEnabled)
			{
				toolPreview.Show(show: false);
			}
		}

		private void UseTool(ToolId toolId)
		{
			if (toolId == this.toolId)
			{
				toolPreview.ShowPressedFeedback();
			}
		}

		private void ShowPreviewAtTile(ToolId toolId, ISelectable target)
		{
			if (toolId == this.toolId)
			{
				toolPreview.Show(target != null);
				if (target != null)
				{
					previewObject.transform.position = target.Transform.position;
				}
			}
		}

		private void OnDestroy()
		{
			inputRouter.OnToolPreview -= ShowPreviewAtTile;
			inputRouter.OnToolUsed -= UseTool;
		}
	}
}
