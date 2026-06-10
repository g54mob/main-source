using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateElementController : ButtonController
{
	public TextMeshProUGUI mainText;

	public TextMeshProUGUI detailText;

	public TextMeshProUGUI fineText;

	public int displayedFine;

	public int fineTotal;

	public JuiceController iconJuice;

	public RectTransform progressBar;

	public Image progressBarImg;

	public StatusPreset preset;

	public StatusController.StatusInstance statusInstance;

	private List<StatusController.StatusCount> counts;

	public List<CanvasRenderer> renderElements;

	public bool minimized;

	public float minimizeTimer;

	public float widthResizingProgress;

	public bool removing;

	public float removalTimer;

	public RectTransform xIcon;

	public CanvasRenderer xIconRend;

	public float maximizeTimer;

	public bool maximized;

	public float heightResizingProgress;

	public float maximizedHeight;

	public bool isWanted;

	public void Setup(StatusController.StatusInstance newInstance)
	{
	}

	private void OnEnable()
	{
	}

	public override void VisualUpdate()
	{
	}

	public void SetRemove(bool val)
	{
	}

	public Color GetColour()
	{
		return default(Color);
	}

	public void SetMinimized(bool val)
	{
	}

	public void SetMaximized(bool val)
	{
	}
}
