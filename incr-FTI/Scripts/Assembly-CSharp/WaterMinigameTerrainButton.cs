using System;
using UnityEngine.UI;

public class WaterMinigameTerrainButton : DraggableButton
{
	[NonSerialized]
	public MinigamePanelWater parentMap;

	[NonSerialized]
	public bool isWaterSource;

	public Image dirt;

	public Image water;

	public Image waterSource;

	public Image grass;

	public Image rock;

	public Image endpointImage;

	public Image embeddedFrame;

	public Image primaryPathHighlight;

	public Coord coord;

	public MenuButton.ButtonDelegate pointerDownDelegate;

	private float revealDelay;

	public bool isStart;

	public bool isEnd;

	public bool isInPrimaryPath;

	public bool pathExcludeFlag;

	public int distance;

	public WaterMinigameTerrainButton searchParent;

	public bool isQueued;

	public WaterMinigameTileState tileState;

	public void Init(int x, int y)
	{
		coord = new Coord(x, y);
	}

	public void ClearPathInfo()
	{
		distance = 0;
		searchParent = null;
		isQueued = false;
		pathExcludeFlag = false;
	}

	public void ResetState()
	{
		tileState = WaterMinigameTileState.Grass;
		isWaterSource = false;
		UpdateItemIcon();
		isStart = false;
		isEnd = false;
		isInPrimaryPath = false;
		ClearPathInfo();
	}

	public void UpdateItemIcon()
	{
		dirt.gameObject.SetActive(tileState == WaterMinigameTileState.Dirt);
		grass.gameObject.SetActive(tileState == WaterMinigameTileState.Grass);
		rock.gameObject.SetActive(tileState == WaterMinigameTileState.Rock);
		water.gameObject.SetActive(tileState == WaterMinigameTileState.Water || isWaterSource);
		primaryPathHighlight.gameObject.SetActive(isInPrimaryPath);
		waterSource.gameObject.SetActive(isWaterSource);
		if (isStart)
		{
			endpointImage.gameObject.SetActive(value: true);
			endpointImage.sprite = IconManager.Instance.waterPathStart;
		}
		else if (isEnd)
		{
			endpointImage.gameObject.SetActive(value: true);
			endpointImage.sprite = IconManager.Instance.waterPathEnd;
		}
		else
		{
			endpointImage.gameObject.SetActive(value: false);
		}
		embeddedFrame.gameObject.SetActive(tileState == WaterMinigameTileState.Grass);
	}

	public void Excavate()
	{
		tileState = WaterMinigameTileState.Dirt;
		UpdateItemIcon();
	}
}
