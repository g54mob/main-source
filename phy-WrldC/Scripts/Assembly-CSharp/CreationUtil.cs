using System.Collections.Generic;
using UnityEngine;

public class CreationUtil
{
	public static GameObject AddConnector(CreationController creationController, GameObject connectorModelPrefab)
	{
		int selectedBlockId = creationController.model.SelectedBlockId;
		int selectedBodyIndex = creationController.model.SelectedBodyIndex;
		GameObject gameObject = creationController.view.GetBlockView(selectedBlockId).gameObject;
		Vector3[] array = creationController.model.DefaultConnectors.ToArray();
		if (array.Length == 0)
		{
			array = gameObject.GetComponent<BlockView>().GetBlockBodyView(selectedBodyIndex).BodySchematic.DefaultConnectors.ToArray();
		}
		GameObject gameObject2 = DrawConnectorModel(connectorModelPrefab, gameObject.transform, array);
		creationController.view.transform.SetParent(gameObject2.transform);
		return gameObject2;
	}

	public static GameObject DrawConnectorModel(GameObject connectorModelPrefab, Transform blockReference, Vector3[] connectorVertices)
	{
		GameObject gameObject = Object.Instantiate(connectorModelPrefab);
		PositionConnectorModel(gameObject.transform, blockReference, connectorVertices);
		return gameObject;
	}

	public static void PositionConnector(CreationModel creationModel, GameObject selectedBlockObject, GameObject connectorModelObject)
	{
		Vector3[] array = creationModel.DefaultConnectors.ToArray();
		if (array.Length == 0)
		{
			array = selectedBlockObject.GetComponent<BlockView>().GetBlockBodyView(0).BodySchematic.DefaultConnectors.ToArray();
		}
		PositionConnectorModel(connectorModelObject.transform, selectedBlockObject.transform, array);
	}

	public static void PositionConnectorModel(Transform connectorModel, Transform blockReference, Vector3[] connectorVertices)
	{
		Vector3 localPosition = connectorVertices[0];
		Vector3 forward = connectorVertices[1];
		Vector3 upwards = connectorVertices[2];
		Transform parent = connectorModel.parent;
		connectorModel.SetParent(blockReference);
		connectorModel.localPosition = localPosition;
		connectorModel.localRotation = Quaternion.LookRotation(forward, upwards);
		connectorModel.SetParent(parent);
	}

	public static void NormalizeCreationScale(CreationView creationView, float scaleFactor = 1f)
	{
		Bounds bounds = CreationBounds(creationView);
		float num = ((bounds.size.x >= bounds.size.y && bounds.size.x >= bounds.size.z) ? bounds.size.x : ((!(bounds.size.y >= bounds.size.z)) ? bounds.size.z : bounds.size.y));
		creationView.transform.localScale = Vector3.one / num * scaleFactor;
	}

	public static Bounds CreationBounds(CreationView creationView)
	{
		if (creationView.BlockViewsCount() == 0)
		{
			return new Bounds(Vector3.zero, Vector3.one);
		}
		List<Bounds> list = new List<Bounds>();
		foreach (BlockView allBlockView in creationView.GetAllBlockViews())
		{
			foreach (BlockBodyView allBlockBodyView in allBlockView.GetAllBlockBodyViews())
			{
				list.Add(allBlockBodyView.GetMeshRendererBounds());
			}
		}
		Bounds result = list[0];
		for (int i = 1; i < list.Count; i++)
		{
			result.Encapsulate(list[i]);
		}
		return result;
	}

	public static Vector3 CreationBoundsCenter(CreationView creationView, bool isWorldRelative = true)
	{
		Vector3 vector = CreationBounds(creationView).center;
		if (!isWorldRelative)
		{
			vector = creationView.transform.InverseTransformVector(vector);
		}
		return vector;
	}

	public static Vector3 CreationGeometricCenter(CreationView creationView, bool isWorldRelative = true)
	{
		int num = 0;
		Vector3 zero = Vector3.zero;
		if (creationView.BlockViewsCount() == 0)
		{
			if (!isWorldRelative)
			{
				return creationView.transform.localPosition;
			}
			return creationView.transform.position;
		}
		foreach (BlockView allBlockView in creationView.GetAllBlockViews())
		{
			zero += (isWorldRelative ? allBlockView.transform.position : allBlockView.transform.localPosition);
			num++;
		}
		return zero / num;
	}

	public static Vector3 CreationMassCenter(CreationView creationView, bool isWorldRelative = true)
	{
		float num = 0f;
		Vector3 zero = Vector3.zero;
		if (creationView.BlockViewsCount() == 0)
		{
			if (!isWorldRelative)
			{
				return creationView.transform.localPosition;
			}
			return creationView.transform.position;
		}
		foreach (BlockView allBlockView in creationView.GetAllBlockViews())
		{
			Vector3 vector = (isWorldRelative ? allBlockView.transform.position : allBlockView.transform.localPosition);
			float num2 = allBlockView.Schematic.Volume * allBlockView.Schematic.MaterialSchematic.Density;
			zero += vector * num2;
			num += num2;
		}
		return zero / num;
	}

	public static void CentralizeCreationView(CreationView creationView)
	{
		Vector3 vector = CreationBoundsCenter(creationView);
		Vector3 position = creationView.transform.position;
		creationView.transform.position = vector;
		foreach (BlockView allBlockView in creationView.GetAllBlockViews())
		{
			allBlockView.transform.localPosition -= vector - position;
		}
	}

	public static void SetPivotPoint(CreationModel creationModel, GameObject blockBodyObject, GameObject pivotPointObject)
	{
		BlockBodyView blockBodyView = blockBodyObject.GetBlockBodyView();
		creationModel.SelectedBlockId = blockBodyView.ParentBlockView.Id;
		creationModel.SelectedBodyIndex = blockBodyView.Index;
		Transform parent = pivotPointObject.transform.parent;
		pivotPointObject.transform.SetParent(blockBodyObject.transform);
		Vector3 localPosition = pivotPointObject.transform.localPosition;
		pivotPointObject.transform.Translate(0f, 0f, 1f, Space.Self);
		Vector3 normalized = (localPosition - pivotPointObject.transform.localPosition).normalized;
		pivotPointObject.transform.Translate(0f, 1f, -1f, Space.Self);
		Vector3 normalized2 = (localPosition - pivotPointObject.transform.localPosition).normalized;
		Vector3[] collection = new Vector3[3] { localPosition, normalized, normalized2 };
		creationModel.DefaultConnectors.Clear();
		creationModel.DefaultConnectors.AddRange(collection);
		pivotPointObject.transform.SetParent(parent);
	}
}
