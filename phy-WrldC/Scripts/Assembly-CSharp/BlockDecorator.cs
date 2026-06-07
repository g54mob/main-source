using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class BlockDecorator
{
	private static int zoomLevel = 3;

	public static List<BlockBodyView> DrawInterconnectedBlocksHighlights(BlockView targetBlockView)
	{
		List<BlockBodyView> list = new List<BlockBodyView>();
		foreach (BlockView allInterconnectedBlock in targetBlockView.GetAllInterconnectedBlocks())
		{
			foreach (BlockBodyView allBlockBodyView in allInterconnectedBlock.GetAllBlockBodyViews())
			{
				list.Add(DrawSelectedHighlight(allBlockBodyView, Color.green));
			}
		}
		return list;
	}

	public static List<BlockBodyView> DrawAllHighlights(BlockBodyView targetBlockBodyView)
	{
		List<BlockBodyView> list = new List<BlockBodyView>();
		list.Add(DrawSelectedHighlight(targetBlockBodyView, Color.green));
		foreach (BlockBodyView allBlockBodyView in targetBlockBodyView.ParentBlockView.GetAllBlockBodyViews())
		{
			if (!(allBlockBodyView == targetBlockBodyView))
			{
				list.Add(DrawSelectedHighlight(allBlockBodyView, Color.yellow));
			}
		}
		list.AddRange(from fixedJointView in targetBlockBodyView.GetAllFixedJointViews()
			select DrawSelectedHighlight(fixedJointView.ConnectedBlockBodyView, Color.blue));
		list.AddRange(from hingeJointView in targetBlockBodyView.GetAllHingeJointViews()
			select DrawSelectedHighlight(hingeJointView.ConnectedBlockBodyView, Color.blue));
		list.AddRange(from outsideBodyView in targetBlockBodyView.GetAllOutsideFixedJoints()
			select DrawSelectedHighlight(outsideBodyView.ParentBlockBodyView, Color.blue));
		list.AddRange(from outsideHingeJointView in targetBlockBodyView.GetAllOutsideHingeJoints()
			select DrawSelectedHighlight(outsideHingeJointView.ParentBlockBodyView, Color.blue));
		return list;
	}

	public static List<BlockBodyView> DrawAllHighlights(BlockView targetBlockView, bool shouldIncludeBodyChildren = false)
	{
		List<BlockBodyView> list = new List<BlockBodyView>();
		foreach (BlockBodyView allBlockBodyView in targetBlockView.GetAllBlockBodyViews())
		{
			list.Add(DrawSelectedHighlight(allBlockBodyView, Color.green, shouldIncludeBodyChildren));
			list.AddRange(from fixedJointView in allBlockBodyView.GetAllFixedJointViews()
				select DrawSelectedHighlight(fixedJointView.ConnectedBlockBodyView, Color.blue));
			list.AddRange(from hingeJointView in allBlockBodyView.GetAllHingeJointViews()
				select DrawSelectedHighlight(hingeJointView.ConnectedBlockBodyView, Color.blue));
			list.AddRange(from outsideBodyView in allBlockBodyView.GetAllOutsideFixedJoints()
				select DrawSelectedHighlight(outsideBodyView.ParentBlockBodyView, Color.blue));
			list.AddRange(from outsideHingeJointView in allBlockBodyView.GetAllOutsideHingeJoints()
				select DrawSelectedHighlight(outsideHingeJointView.ParentBlockBodyView, Color.blue));
		}
		return list;
	}

	public static BlockBodyView DrawSelectedHighlight(BlockBodyView blockBodyView, Color color, bool shouldIncludeChildren = false)
	{
		blockBodyView.SetOutline(isEnabled: true, Util.OutlineColorParser(color), shouldIncludeChildren);
		return blockBodyView;
	}

	public static GameObject DrawBlockConnectors(BlockView blockView, GameObject connectorModel, GameObject connectorCollider, int parameterZoomLevel)
	{
		GameObject gameObject = new GameObject("Connectors");
		foreach (BlockBodyView allBlockBodyView in blockView.GetAllBlockBodyViews())
		{
			GameObject gameObject2 = DrawBodyConnectors(allBlockBodyView, connectorModel, connectorCollider, parameterZoomLevel);
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.transform.position = allBlockBodyView.transform.position;
			gameObject2.transform.rotation = allBlockBodyView.transform.rotation;
			if (allBlockBodyView.TryGetComponent<TwoPointBlock>(out var component))
			{
				GameObject gameObject3 = DrawBodyConnectors(allBlockBodyView, connectorModel, connectorCollider, parameterZoomLevel);
				gameObject3.transform.SetParent(gameObject.transform);
				gameObject3.transform.position = allBlockBodyView.transform.TransformPoint(component.endPointPosition);
				gameObject3.transform.rotation = allBlockBodyView.transform.rotation * component.endPointRotation;
			}
		}
		return gameObject;
	}

	private static GameObject DrawBodyConnectors(BlockBodyView blockBodyView, GameObject connectorModel, GameObject connectorCollider, int parameterZoomLevel)
	{
		GameObject gameObject = new GameObject("Connectors");
		zoomLevel = parameterZoomLevel;
		BodySchematic bodySchematic = blockBodyView.BodySchematic;
		if (bodySchematic.PointsConnectors.Count > 0)
		{
			DrawPointConnectors(gameObject, bodySchematic.PointsConnectors.ToArray(), connectorModel, connectorCollider);
		}
		if (bodySchematic.RectangleFConnectors.Count > 0)
		{
			DrawRectangleConnectors(gameObject, bodySchematic.RectangleFConnectors.ToArray(), connectorModel, connectorCollider);
		}
		if (bodySchematic.RectangleSConnectors.Count > 0)
		{
			GameObject gameObject2 = BlockBodyViewBuilder.CreateBlockBodyCollider(bodySchematic);
			gameObject2.tag = "BlockReference";
			gameObject2.transform.SetParent(gameObject.transform);
			DrawRectangleConnectors(gameObject, bodySchematic.RectangleSConnectors.ToArray(), connectorModel, connectorCollider, gameObject2);
			Object.Destroy(gameObject2);
		}
		return gameObject;
	}

	private static void DrawPointConnectors(GameObject connectorsParent, Vector3[] connectorVertices, GameObject connectorModel, GameObject connectorCollider)
	{
		for (int i = 0; i < connectorVertices.Length; i += 3)
		{
			Vector3 position = connectorVertices[i];
			Vector3 vector = connectorVertices[i + 1];
			Vector3 upwards = connectorVertices[i + 2];
			GameObject gameObject = Object.Instantiate(connectorCollider, position, Quaternion.LookRotation(-vector, upwards));
			gameObject.tag = "Connector";
			gameObject.layer = LayerNames.Connector;
			gameObject.transform.SetParent(connectorsParent.transform);
			GameObject gameObject2 = Object.Instantiate(connectorModel, position, Quaternion.LookRotation(vector, upwards));
			gameObject2.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
			gameObject2.transform.SetParent(connectorsParent.transform);
			gameObject2.transform.Translate(0f, 0f, -0.001f, Space.Self);
		}
	}

	private static void DrawRectangleConnectors(GameObject connectorsParent, Vector3[] connectorVertices, GameObject connectorModel, GameObject connectorCollider, GameObject blockReference = null)
	{
		float num = 0f;
		float num2 = 4f;
		for (int i = 0; i < connectorVertices.Length; i += 4)
		{
			int num3 = zoomLevel;
			int num4 = zoomLevel;
			Vector3 vector = connectorVertices[i];
			Vector3 vector2 = connectorVertices[i + 1];
			Vector3 vector3 = connectorVertices[i + 2];
			Vector3 vector4 = connectorVertices[i + 3];
			Vector3 vector5 = vector;
			Vector3 vector6 = (vector5 - vector3) * num2 / zoomLevel;
			Vector3 vector7 = (vector5 - vector4) * num2 / zoomLevel;
			Vector3 vector8 = vector2;
			Vector3 normalized = (vector5 - vector4).normalized;
			vector5 = vector5 - vector6 * zoomLevel / 2f - vector7 * zoomLevel / 2f;
			while (vector6.magnitude < 0.15f && num3 != 1)
			{
				vector6 *= (float)num3;
				num3--;
				vector6 /= (float)num3;
			}
			while (vector7.magnitude < 0.15f && num4 != 1)
			{
				vector7 *= (float)num4;
				num4--;
				vector7 /= (float)num4;
			}
			GameObject gameObject = Object.Instantiate(connectorModel, vector, Quaternion.LookRotation(vector8, normalized), connectorsParent.transform);
			gameObject.transform.localScale = new Vector3(vector6.magnitude * (float)num3, vector7.magnitude * (float)num4, 1f);
			Renderer component = gameObject.GetComponent<Renderer>();
			component.sharedMaterial = new Material(connectorModel.GetComponent<Renderer>().sharedMaterial);
			component.sharedMaterial.mainTextureScale = new Vector2(num3, num4);
			gameObject.transform.Translate(0f, 0f, -0.002f, Space.Self);
			for (int j = 0; j < num3; j++)
			{
				for (int k = 0; k < num4; k++)
				{
					bool flag = true;
					if (blockReference != null)
					{
						flag = false;
						Collider[] array = Physics.OverlapSphere(connectorsParent.transform.position + vector5 + (vector6 * j + vector6 / 2f) + (vector7 * k + vector7 / 2f), 0.05f);
						for (int l = 0; l < array.Length; l++)
						{
							if (array[l].gameObject.CompareTag("BlockReference"))
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						Vector3 position = connectorsParent.transform.position + vector5 + (vector6 * j + vector6 / 2f) + (vector7 * k + vector7 / 2f);
						Quaternion rotation = Quaternion.LookRotation(-vector8, normalized);
						GameObject gameObject2 = Object.Instantiate(connectorCollider, position, rotation, connectorsParent.transform);
						gameObject2.transform.localScale = new Vector3((vector6.magnitude / 0.15f - num) * 1f, (vector7.magnitude / 0.15f - num) * 1f, 1f);
						gameObject2.tag = "Connector";
						gameObject2.layer = LayerNames.Connector;
					}
				}
			}
		}
	}
}
