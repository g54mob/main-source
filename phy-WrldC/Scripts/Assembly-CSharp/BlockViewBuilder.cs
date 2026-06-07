using System;
using UltimateReplay;
using UnityEngine;
using cakeslice;

public static class BlockViewBuilder
{
	public const float SmallerScaleFactor = 0.87f;

	public static GameObject CreateBlockCollider(Schematic schematic)
	{
		return CreateBlockCollider(schematic, null);
	}

	public static GameObject CreateBlockCollider(Schematic schematic, Transform parent)
	{
		GameObject gameObject = new GameObject("BlockCollider");
		gameObject.transform.SetParent(parent);
		foreach (BodySchematic allBodySchematic in schematic.GetAllBodySchematics())
		{
			BlockBodyViewBuilder.CreateBlockBodyCollider(allBodySchematic, gameObject.transform);
		}
		return gameObject;
	}

	public static GameObject CreateScalableBlockCollider(BlockView targetBlockView, float scale)
	{
		Schematic schematic = targetBlockView.Schematic;
		GameObject gameObject = CreateBlockCollider(schematic);
		gameObject.name = "BlockScalable";
		for (int i = 0; i < schematic.BodySchematicsCount(); i++)
		{
			BlockBodyView blockBodyView = targetBlockView.GetBlockBodyView(i);
			GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
			gameObject2.name = "BlockScalable";
			gameObject2.AddComponent<Rigidbody>().isKinematic = true;
			gameObject2.transform.localScale = Vector3.Scale(blockBodyView.transform.localScale, Vector3.one * scale);
			gameObject2.AddComponent<ObjectsInCollision>();
		}
		gameObject.transform.position = targetBlockView.transform.position;
		gameObject.transform.rotation = targetBlockView.transform.rotation;
		gameObject.transform.SetParent(targetBlockView.transform);
		return gameObject.gameObject;
	}

	public static GameObject CreateLargeBlockCollider(BlockView targetBlockView)
	{
		return CreateScalableBlockCollider(targetBlockView, 1.01f);
	}

	public static GameObject CreateSmallerBlockCollider(BlockView targetBlockView)
	{
		return CreateScalableBlockCollider(targetBlockView, 0.87f);
	}

	public static GameObject CreateBlockModel(int id, Schematic schematic)
	{
		return CreateBlockModel(id, schematic, null, LayerNames.Default);
	}

	public static GameObject CreateBlockModel(int id, Schematic schematic, Transform parent)
	{
		return CreateBlockModel(id, schematic, parent, LayerNames.Default);
	}

	public static GameObject CreateBlockModel(int id, Schematic schematic, Transform parent, int layer)
	{
		GameObject prefab = schematic.Prefab;
		GameObject gameObject;
		if (prefab != null)
		{
			gameObject = UnityEngine.Object.Instantiate(prefab);
			gameObject.transform.SetParent(parent);
		}
		else
		{
			gameObject = CreateBlockCollider(schematic, parent);
		}
		BlockView blockView = gameObject.AddComponent<BlockView>();
		blockView.Id = id;
		blockView.Schematic = schematic;
		blockView.BlockRendererType = BlockView.BlockRendererTypeEnum.Model;
		for (int i = 0; i < schematic.BodySchematicsCount(); i++)
		{
			BodySchematic bodySchematic = schematic.GetBodySchematic(i);
			GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
			gameObject2.name = "BlockModel";
			if (prefab != null)
			{
				Rigidbody component = gameObject2.GetComponent<Rigidbody>();
				if (component != null)
				{
					component.isKinematic = true;
				}
			}
			else
			{
				gameObject2.AddComponent<MeshFilter>().sharedMesh = bodySchematic.ModelMesh;
				gameObject2.AddComponent<MeshRenderer>();
				gameObject2.GetComponent<Renderer>().sharedMaterial = bodySchematic.MainMaterial;
			}
			BlockBodyView blockBodyView = gameObject2.AddComponent<BlockBodyView>();
			blockView.AddBlockBodyView(blockBodyView);
			AddComponents(blockBodyView, bodySchematic);
		}
		gameObject.name = "BlockModel";
		gameObject.SetTagsRecursively("BlockModel");
		gameObject.SetLayersRecursively(layer);
		return gameObject;
	}

	public static GameObject CreateTransparentBlock(int id, Schematic schematic, Transform parent, float alpha)
	{
		GameObject gameObject = CreateBlockModel(id, schematic, parent);
		gameObject.name = "BlockTransparent";
		BlockView blockView = gameObject.GetBlockView();
		for (int i = 0; i < schematic.BodySchematicsCount(); i++)
		{
			BodySchematic bodySchematic = schematic.GetBodySchematic(i);
			GameObject gameObject2 = blockView.GetBlockBodyView(i).gameObject;
			gameObject2.name = "BlockTransparent";
			Material material = new Material(bodySchematic.MainMaterial);
			material.shader = Shader.Find("Transparent/Diffuse");
			material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
			gameObject2.GetComponent<Renderer>().material = material;
		}
		return gameObject;
	}

	public static GameObject CreatePlaceholderBlock(int id, Schematic schematic, Transform parent)
	{
		GameObject gameObject = CreateBlockModel(id, schematic, parent);
		BlockView blockView = gameObject.GetBlockView();
		blockView.BlockRendererType = BlockView.BlockRendererTypeEnum.Placeholder;
		GameObject gameObject2 = CreateSmallerBlockCollider(blockView);
		for (int i = 0; i < schematic.BodySchematicsCount(); i++)
		{
			GameObject gameObject3 = gameObject.transform.GetChild(i).gameObject;
			GameObject gameObject4 = gameObject2.transform.GetChild(i).gameObject;
			PlaceholderBlockBody placeholderBlockBody = gameObject3.AddComponent<PlaceholderBlockBody>();
			ObjectsInCollision component = gameObject4.GetComponent<ObjectsInCollision>();
			component.BodySchematic = schematic.GetBodySchematic(i);
			placeholderBlockBody.BlocksInCollision = component;
		}
		return gameObject;
	}

	public static GameObject CreateBlockModelButton3D(int id, Schematic schematic)
	{
		GameObject gameObject = CreateBlockModel(id, schematic);
		BlockView blockView = gameObject.GetBlockView();
		blockView.BlockRendererType = BlockView.BlockRendererTypeEnum.Button3D;
		foreach (BlockBodyView allBlockBodyView in blockView.GetAllBlockBodyViews())
		{
			allBlockBodyView.gameObject.AddComponent<BlockBodyModelButton3D>();
		}
		gameObject.SetLayersRecursively(LayerNames.Button3D);
		gameObject.SetTagsRecursively("Button3D");
		return gameObject;
	}

	public static GameObject CreateRigidBlock(int id, Schematic schematic, Transform parent)
	{
		return CreateRigidBlock(id, schematic, parent, LayerNames.Block);
	}

	public static GameObject CreateRigidBlock(int id, Schematic schematic, Transform parent, int layer)
	{
		GameObject gameObject = CreateBlockModel(id, schematic, parent);
		gameObject.GetBlockView().BlockRendererType = BlockView.BlockRendererTypeEnum.Rigid;
		BlockBodyView[] componentsInChildren = gameObject.GetComponentsInChildren<BlockBodyView>();
		foreach (BodySchematic allBodySchematic in schematic.GetAllBodySchematics())
		{
			BlockBodyView obj = componentsInChildren[allBodySchematic.Index];
			GameObject gameObject2 = obj.gameObject;
			gameObject2.name = "BlockLevel";
			SetupCollidersToRigidbody(gameObject2, allBodySchematic);
			Rigidbody rigidbody = gameObject2.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = gameObject2.AddComponent<Rigidbody>();
			}
			obj.BlockRigidbody = rigidbody;
			float num = schematic.Volume / (float)schematic.GetAllBodySchematics().Count;
			float density = schematic.MaterialSchematic.Density;
			rigidbody.mass = num * density;
			rigidbody.maxAngularVelocity = float.PositiveInfinity;
			rigidbody.isKinematic = true;
			gameObject2.AddComponent<Outline>().enabled = false;
			gameObject2.AddComponent<BlockBodyStylesApplier>();
			obj.ReplayObject = AddReplayComponents(gameObject2);
		}
		gameObject.name = "BlockLevel";
		gameObject.SetTagsRecursively("Block");
		gameObject.SetLayersRecursively(layer);
		return gameObject;
	}

	private static ReplayObject AddReplayComponents(GameObject newBlockBodyObject)
	{
		ReplayTransform replayTransform = newBlockBodyObject.AddComponent<ReplayTransform>();
		replayTransform.recordPosition = ReplayTransform.ReplayTransformRecordSpace.World;
		replayTransform.recordRotation = ReplayTransform.ReplayTransformRecordSpace.World;
		newBlockBodyObject.AddComponent<BlockBodyViewReplay>();
		ReplayObject replayObject = newBlockBodyObject.GetComponent<ReplayObject>();
		if (replayObject == null)
		{
			replayObject = newBlockBodyObject.AddComponent<ReplayObject>();
		}
		return replayObject;
	}

	private static void SetupCollidersToRigidbody(GameObject newBlockBodyObject, BodySchematic bodySchematic)
	{
		MeshCollider[] components = newBlockBodyObject.GetComponents<MeshCollider>();
		foreach (MeshCollider obj in components)
		{
			obj.material = bodySchematic.ParentSchematic.MaterialSchematic.PhysicMaterial;
			obj.isTrigger = false;
		}
		BoxCollider[] components2 = newBlockBodyObject.GetComponents<BoxCollider>();
		foreach (BoxCollider obj2 in components2)
		{
			obj2.material = bodySchematic.ParentSchematic.MaterialSchematic.PhysicMaterial;
			obj2.isTrigger = false;
		}
		CapsuleCollider[] components3 = newBlockBodyObject.GetComponents<CapsuleCollider>();
		foreach (CapsuleCollider obj3 in components3)
		{
			obj3.material = bodySchematic.ParentSchematic.MaterialSchematic.PhysicMaterial;
			obj3.isTrigger = false;
		}
		SphereCollider[] components4 = newBlockBodyObject.GetComponents<SphereCollider>();
		foreach (SphereCollider obj4 in components4)
		{
			obj4.material = bodySchematic.ParentSchematic.MaterialSchematic.PhysicMaterial;
			obj4.isTrigger = false;
		}
	}

	private static void AddComponents(BlockBodyView bodyView, BodySchematic bodySchematic)
	{
		foreach (ComponentSchematic value in bodySchematic.ComponentSchematics.Values)
		{
			Type type = Type.GetType(value.Name);
			BaseComponentView baseComponentView = bodyView.gameObject.AddComponent(type) as BaseComponentView;
			baseComponentView.SetComponentActive(isActive: false);
			bodyView.AddComponentView(baseComponentView);
		}
	}

	public static FixedJoint FixedJointTwoBlocks(BlockBodyView firstBlockBodyView, BlockBodyView secondBlockBodyView)
	{
		float num = firstBlockBodyView.MaterialSchematic.FixationRate * 1000f;
		float num2 = secondBlockBodyView.MaterialSchematic.FixationRate * 1000f;
		float num3 = (num + num2) / 2f;
		FixedJoint fixedJoint = firstBlockBodyView.gameObject.AddComponent<FixedJoint>();
		fixedJoint.connectedBody = secondBlockBodyView.GetComponent<Rigidbody>();
		fixedJoint.breakForce = num3;
		fixedJoint.breakTorque = num3;
		return fixedJoint;
	}

	public static HingeJoint HingeJointTwoBlocks(BlockBodyView firstBlockBodyView, BlockBodyView secondBlockBodyView, Vector3 targetPosition, Vector3 axisDirection)
	{
		float num = firstBlockBodyView.MaterialSchematic.FixationRate * 1000f;
		float num2 = secondBlockBodyView.MaterialSchematic.FixationRate * 1000f;
		float num3 = (num + num2) / 2f;
		HingeJoint hingeJoint = firstBlockBodyView.gameObject.AddComponent<HingeJoint>();
		hingeJoint.connectedBody = secondBlockBodyView.GetComponent<Rigidbody>();
		hingeJoint.anchor = Vector3.Scale(targetPosition, firstBlockBodyView.transform.localScale);
		hingeJoint.axis = axisDirection;
		hingeJoint.breakForce = num3;
		hingeJoint.breakTorque = num3;
		return hingeJoint;
	}
}
