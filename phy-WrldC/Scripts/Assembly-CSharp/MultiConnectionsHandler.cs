using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiConnectionsHandler
{
	public enum WhyCannotConnect
	{
		AlreadyConnected = 0,
		NotTouching = 1
	}

	private LineComponent lineComponent;

	private GameObject largeBlockBodyObject;

	private Vector3 originalLargeBlockPosition;

	private GameObject lastSecondGameObject;

	private GameObject lastUnconnectedGameObject;

	private List<BlockBodyView> firstBlockBodyHighlights;

	private BlockBodyView secondBlockBodyHighlight;

	private bool canConnect;

	private Color highlightColor;

	private WhyCannotConnect whyCannotConnect;

	public event Action<BlockBodyView, BlockBodyView> OnCanConnectBlocks;

	public event Action<BlockBodyView, BlockBodyView> OnRemoveConnectionBlocksEvent;

	public event Action<BlockBodyView, BlockBodyView, WhyCannotConnect> OnCannotConnectBlocks;

	public MultiConnectionsHandler(GameManager GAME)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(GAME.multiConnectionsLinePrefab);
		lineComponent = gameObject.GetComponent<LineComponent>();
		lineComponent.Initialize(GAME.effectsFolder.transform, GAME.CameraManager.OrbitCamera.transform.GetChild(0).transform);
		lineComponent.SetVisibility(isVisible: false);
	}

	public void MouseStartDragHandler(GameObject firstGameObject, Vector3 lineStartPoint)
	{
		DestroyLargeBlock();
		BlockBodyView blockBodyView = firstGameObject.GetBlockBodyView();
		largeBlockBodyObject = BlockBodyViewBuilder.CreateLargeBlockBodyCollider(blockBodyView);
		originalLargeBlockPosition = largeBlockBodyObject.transform.position;
		firstBlockBodyHighlights = BlockDecorator.DrawAllHighlights(blockBodyView);
		lineComponent.SetVisibility(isVisible: true);
		lastSecondGameObject = null;
		lastUnconnectedGameObject = null;
	}

	public void MouseDraggingHandler(GameObject firstGameObject, GameObject secondGameObject, Vector3 lineStartPoint, Vector3 lineCurrentPoint)
	{
		if (secondGameObject != null)
		{
			int id = firstGameObject.GetBlockBodyView().ParentBlockView.Id;
			int id2 = secondGameObject.GetBlockBodyView().ParentBlockView.Id;
			if (id != id2)
			{
				if (IsAlreadyConnected(firstGameObject, secondGameObject))
				{
					canConnect = false;
					lastUnconnectedGameObject = null;
					ResetSecondHighlights();
					if (Input.GetKeyDown(KeyCode.X))
					{
						RemoveConnectionBetweenBlocks(firstGameObject, secondGameObject);
						ResetFirstBlocksHightlights(secondGameObject);
						lastUnconnectedGameObject = secondGameObject;
					}
					whyCannotConnect = WhyCannotConnect.AlreadyConnected;
				}
				else if (secondGameObject != lastUnconnectedGameObject)
				{
					lastUnconnectedGameObject = null;
					if (secondGameObject != lastSecondGameObject)
					{
						largeBlockBodyObject.transform.position = originalLargeBlockPosition;
						Vector3 position = Vector3.MoveTowards(largeBlockBodyObject.transform.position, secondGameObject.transform.position, 0.01f);
						largeBlockBodyObject.transform.position = position;
					}
					else
					{
						if (!IsBlocksColliding(firstGameObject, secondGameObject))
						{
							canConnect = false;
							highlightColor = Color.red;
							whyCannotConnect = WhyCannotConnect.NotTouching;
						}
						else
						{
							canConnect = true;
							highlightColor = Color.green;
						}
						ResetSecondHighlights();
						secondBlockBodyHighlight = BlockDecorator.DrawSelectedHighlight(secondGameObject.GetBlockBodyView(), highlightColor);
					}
				}
			}
		}
		else
		{
			lastUnconnectedGameObject = null;
			ResetSecondHighlights();
		}
		lastSecondGameObject = secondGameObject;
		lineComponent.SetPositions(lineStartPoint, lineCurrentPoint);
	}

	public void MouseValidDropHandler(GameObject firstGameObject, GameObject secondGameObject)
	{
		BlockBodyView blockBodyView = firstGameObject.GetBlockBodyView();
		BlockBodyView blockBodyView2 = secondGameObject.GetBlockBodyView();
		if (canConnect)
		{
			this.OnCanConnectBlocks?.Invoke(blockBodyView, blockBodyView2);
		}
		else
		{
			this.OnCannotConnectBlocks?.Invoke(blockBodyView, blockBodyView2, whyCannotConnect);
		}
	}

	public void MouseEndDropHandler()
	{
		ResetFirstHighlights();
		ResetSecondHighlights();
		DestroyLargeBlock();
		lineComponent.SetVisibility(isVisible: false);
		firstBlockBodyHighlights = null;
		secondBlockBodyHighlight = null;
		canConnect = false;
	}

	private void DestroyLargeBlock()
	{
		if (largeBlockBodyObject != null)
		{
			UnityEngine.Object.Destroy(largeBlockBodyObject);
		}
	}

	private void ResetFirstHighlights()
	{
		if (firstBlockBodyHighlights == null)
		{
			return;
		}
		foreach (BlockBodyView firstBlockBodyHighlight in firstBlockBodyHighlights)
		{
			if (!(firstBlockBodyHighlight == null))
			{
				firstBlockBodyHighlight.SetOutline(isEnabled: false);
			}
		}
	}

	private void ResetFirstBlocksHightlights(GameObject targetBlockBodyObject)
	{
		foreach (BlockBodyView firstBlockBodyHighlight in firstBlockBodyHighlights)
		{
			if (firstBlockBodyHighlight.gameObject == targetBlockBodyObject)
			{
				firstBlockBodyHighlight.SetOutline(isEnabled: false);
			}
		}
	}

	private void ResetSecondHighlights()
	{
		if (secondBlockBodyHighlight != null)
		{
			secondBlockBodyHighlight.SetOutline(isEnabled: false);
		}
	}

	private bool IsAlreadyConnected(GameObject firstBlockBodyObject, GameObject secondBlockBodyObject)
	{
		if (firstBlockBodyObject == null || secondBlockBodyObject == null)
		{
			return true;
		}
		BlockBodyView blockBodyView = firstBlockBodyObject.GetBlockBodyView();
		BlockBodyView secondBlockBodyView = secondBlockBodyObject.GetBlockBodyView();
		if (blockBodyView.GetAllFixedJointViews().Any((FixedJointView fixedJointView) => fixedJointView.ConnectedBlockBodyView.gameObject == secondBlockBodyView.gameObject))
		{
			return true;
		}
		if (blockBodyView.GetAllHingeJointViews().Any((HingeJointView hingeJointView) => hingeJointView.ConnectedBlockBodyView.gameObject == secondBlockBodyView.gameObject))
		{
			return true;
		}
		if (blockBodyView.GetAllOutsideFixedJoints().Any((FixedJointView outsideBlockBodyView) => outsideBlockBodyView.ParentBlockBodyView.gameObject == secondBlockBodyView.gameObject))
		{
			return true;
		}
		if (blockBodyView.GetAllOutsideHingeJoints().Any((HingeJointView outsideHingeJointView) => outsideHingeJointView.ParentBlockBodyView.gameObject == secondBlockBodyView.gameObject))
		{
			return true;
		}
		return false;
	}

	private bool IsBlocksColliding(GameObject firstBlockBodyObject, GameObject secondBlockBodyObject)
	{
		if (firstBlockBodyObject == null || secondBlockBodyObject == null)
		{
			return false;
		}
		ObjectsInCollision component = largeBlockBodyObject.GetComponent<ObjectsInCollision>();
		if (component == null)
		{
			return false;
		}
		if (component.blockObjectsInCollision.Any((GameObject blockObject) => blockObject == secondBlockBodyObject))
		{
			return true;
		}
		return false;
	}

	private void RemoveConnectionBetweenBlocks(GameObject firstBlockBodyObject, GameObject secondBlockBodyObject)
	{
		if (!(firstBlockBodyObject == null) && !(secondBlockBodyObject == null))
		{
			BlockBodyView blockBodyView = firstBlockBodyObject.GetBlockBodyView();
			BlockBodyView blockBodyView2 = secondBlockBodyObject.GetBlockBodyView();
			this.OnRemoveConnectionBlocksEvent?.Invoke(blockBodyView, blockBodyView2);
		}
	}
}
