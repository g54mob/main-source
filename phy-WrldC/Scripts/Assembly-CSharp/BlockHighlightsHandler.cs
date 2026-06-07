using System.Collections.Generic;
using UnityEngine;

public class BlockHighlightsHandler
{
	private GameManager gameManager;

	private List<BlockBodyView> highlightedBlockBodys;

	private GameObject connectorsGridObject;

	private BlockBodyView currentBlockBodyView;

	public bool ShowBlockConnectorsGrid { get; set; }

	public BlockHighlightsHandler(GameManager gameManager)
	{
		this.gameManager = gameManager;
		ShowBlockConnectorsGrid = true;
	}

	public void MouseEnterBlockBodyHandler(GameObject mouseOverBlockBodyObject, bool isInterconnectedHighlights = false)
	{
		BlockBodyView blockBodyView = mouseOverBlockBodyObject.GetBlockBodyView();
		if (blockBodyView.ParentBlockView.ParentCreationView.IsEditable)
		{
			currentBlockBodyView = blockBodyView;
			if (ShowBlockConnectorsGrid)
			{
				RemoveBlockConnectorGrid();
				connectorsGridObject = BlockDecorator.DrawBlockConnectors(blockBodyView.ParentBlockView, gameManager.connectorGridPrefab, gameManager.connectorColliderPrefab, gameManager.ConstructionToolsModel.ConnectorGridSize);
			}
			if (isInterconnectedHighlights)
			{
				highlightedBlockBodys = BlockDecorator.DrawInterconnectedBlocksHighlights(blockBodyView.ParentBlockView);
			}
			else
			{
				highlightedBlockBodys = BlockDecorator.DrawAllHighlights(blockBodyView.ParentBlockView, shouldIncludeBodyChildren: true);
			}
		}
	}

	public void MouseExitBlockBodyHandler(GameObject mouseOverBlockBodyObject)
	{
		RemoveBlockConnectorGrid();
		RemoveBlockHighlights();
		currentBlockBodyView = null;
	}

	public void RedrawBlockConnectorsGrid()
	{
		if (ShowBlockConnectorsGrid && !(currentBlockBodyView == null))
		{
			RemoveBlockConnectorGrid();
			connectorsGridObject = BlockDecorator.DrawBlockConnectors(currentBlockBodyView.ParentBlockView, gameManager.connectorGridPrefab, gameManager.connectorColliderPrefab, gameManager.ConstructionToolsModel.ConnectorGridSize);
		}
	}

	private void RemoveBlockConnectorGrid()
	{
		if (connectorsGridObject != null)
		{
			Object.Destroy(connectorsGridObject);
		}
	}

	private void RemoveBlockHighlights()
	{
		if (highlightedBlockBodys == null)
		{
			return;
		}
		foreach (BlockBodyView highlightedBlockBody in highlightedBlockBodys)
		{
			if (!(highlightedBlockBody == null))
			{
				highlightedBlockBody.SetOutline(isEnabled: false);
			}
		}
		highlightedBlockBodys = null;
	}
}
