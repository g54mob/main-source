using UnityEngine;
using UnityEngine.UI;

public class BlockVisualizationView : BaseGUIView
{
	public const string CloseEvent = "BlockVisualizationView.CloseEvent";

	private Button closeButton;

	private RectTransform contentPanel;

	private RectTransform parentCanvasRecTransform;

	public override void Initialize()
	{
		parentCanvasRecTransform = base.ParentCanvas.GetComponent<RectTransform>();
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		contentPanel = mainPanel.transform.FindComponent<RectTransform>("ContentPanel", isRecursively: true);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("BlockVisualizationView.CloseEvent");
		});
	}

	public void FitCameraInContentPanel(Camera camera)
	{
		Vector3[] array = new Vector3[4];
		Vector3[] array2 = new Vector3[4];
		contentPanel.GetWorldCorners(array);
		parentCanvasRecTransform.GetWorldCorners(array2);
		float num = array[1].y - array[0].y;
		float num2 = array[2].x - array[1].x;
		float num3 = array2[1].y - array2[0].y;
		float num4 = array2[2].x - array2[1].x;
		float height = num / num3;
		float width = num2 / num4;
		float x = array[0].x;
		float y = array[0].y;
		float x2 = array2[0].x;
		float y2 = array2[0].y;
		float x3 = (x - x2) / num4;
		float y3 = (y - y2) / num3;
		camera.rect = new Rect(x3, y3, width, height);
	}
}
