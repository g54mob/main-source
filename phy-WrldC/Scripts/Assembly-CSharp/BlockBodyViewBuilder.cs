using UnityEngine;

public static class BlockBodyViewBuilder
{
	public static GameObject CreateBlockBodyCollider(BodySchematic bodySchematic)
	{
		return CreateBlockBodyCollider(bodySchematic, null);
	}

	public static GameObject CreateBlockBodyCollider(BodySchematic bodySchematic, Transform parent)
	{
		GameObject gameObject = new GameObject("BlockCollider");
		if (parent != null)
		{
			gameObject.transform.SetParent(parent);
		}
		gameObject.tag = "Untagged";
		gameObject.layer = LayerNames.Default;
		GameObject prefab = bodySchematic.ParentSchematic.Prefab;
		if (prefab != null)
		{
			AddBodyMeshCollider(gameObject, prefab.transform.GetChild(bodySchematic.Index).gameObject);
		}
		else
		{
			AddBodyMeshCollider(gameObject, bodySchematic);
		}
		return gameObject;
	}

	private static void AddBodyMeshCollider(GameObject newBlockBodyObject, BodySchematic bodySchematic)
	{
		foreach (Mesh meshCollider2 in bodySchematic.MeshColliderList)
		{
			MeshCollider meshCollider = newBlockBodyObject.AddComponent<MeshCollider>();
			meshCollider.sharedMesh = meshCollider2;
			meshCollider.convex = true;
			meshCollider.isTrigger = true;
		}
		foreach (BodySchematic.UnityColliderType unityCollider in bodySchematic.UnityColliderList)
		{
			switch (unityCollider)
			{
			case BodySchematic.UnityColliderType.Box:
			{
				BoxCollider boxCollider = newBlockBodyObject.AddComponent<BoxCollider>();
				boxCollider.center = bodySchematic.ModelMesh.bounds.center;
				boxCollider.size = bodySchematic.ModelMesh.bounds.size;
				boxCollider.isTrigger = true;
				break;
			}
			case BodySchematic.UnityColliderType.Capsule:
				newBlockBodyObject.AddComponent<CapsuleCollider>().isTrigger = true;
				break;
			case BodySchematic.UnityColliderType.Sphere:
			{
				SphereCollider sphereCollider = newBlockBodyObject.AddComponent<SphereCollider>();
				sphereCollider.center = bodySchematic.ModelMesh.bounds.center;
				sphereCollider.radius = bodySchematic.ModelMesh.bounds.size.x / 2f;
				sphereCollider.isTrigger = true;
				break;
			}
			}
		}
		foreach (Mesh boxCollider3 in bodySchematic.BoxColliderList)
		{
			BoxCollider boxCollider2 = newBlockBodyObject.AddComponent<BoxCollider>();
			boxCollider2.center = boxCollider3.bounds.center;
			boxCollider2.size = boxCollider3.bounds.size;
			boxCollider2.isTrigger = true;
		}
	}

	private static void AddBodyMeshCollider(GameObject newBlockBodyObject, GameObject blockBodyPrefab)
	{
		MeshCollider[] components = blockBodyPrefab.GetComponents<MeshCollider>();
		foreach (MeshCollider meshCollider in components)
		{
			MeshCollider meshCollider2 = newBlockBodyObject.AddComponent<MeshCollider>();
			meshCollider2.sharedMesh = meshCollider.sharedMesh;
			meshCollider2.convex = true;
			meshCollider2.isTrigger = true;
		}
		BoxCollider[] components2 = blockBodyPrefab.GetComponents<BoxCollider>();
		foreach (BoxCollider boxCollider in components2)
		{
			BoxCollider boxCollider2 = newBlockBodyObject.AddComponent<BoxCollider>();
			boxCollider2.center = boxCollider.center;
			boxCollider2.size = boxCollider.size;
			boxCollider2.isTrigger = true;
		}
		CapsuleCollider[] components3 = blockBodyPrefab.GetComponents<CapsuleCollider>();
		foreach (CapsuleCollider capsuleCollider in components3)
		{
			CapsuleCollider capsuleCollider2 = newBlockBodyObject.AddComponent<CapsuleCollider>();
			capsuleCollider2.height = capsuleCollider.height;
			capsuleCollider2.radius = capsuleCollider.radius;
		}
		SphereCollider[] components4 = blockBodyPrefab.GetComponents<SphereCollider>();
		foreach (SphereCollider sphereCollider in components4)
		{
			newBlockBodyObject.AddComponent<SphereCollider>().radius = sphereCollider.radius;
		}
	}

	public static GameObject CreateLargeBlockBodyCollider(BlockBodyView targetBlockBodyView)
	{
		return CreateScalableBlockBodyCollider(targetBlockBodyView, 1.01f);
	}

	public static GameObject CreateSmallerBlockBodyCollider(BlockBodyView targetBlockBodyView)
	{
		return CreateScalableBlockBodyCollider(targetBlockBodyView, 0.87f);
	}

	public static GameObject CreateScalableBlockBodyCollider(BlockBodyView blockBodyView, float scale)
	{
		GameObject gameObject = CreateBlockBodyCollider(blockBodyView.BodySchematic);
		gameObject.name = "BlockScalable";
		gameObject.AddComponent<Rigidbody>().isKinematic = true;
		gameObject.transform.localScale = Vector3.Scale(blockBodyView.transform.localScale, Vector3.one * scale);
		gameObject.AddComponent<ObjectsInCollision>();
		gameObject.transform.position = blockBodyView.transform.position;
		gameObject.transform.rotation = blockBodyView.transform.rotation;
		gameObject.transform.SetParent(blockBodyView.transform);
		return gameObject;
	}

	public static GameObject CreateBlockBodyModel(BodySchematic bodySchematic)
	{
		return CreateBlockBodyModel(bodySchematic, null, LayerNames.Default);
	}

	public static GameObject CreateBlockBodyModel(BodySchematic bodySchematic, Transform parent)
	{
		return CreateBlockBodyModel(bodySchematic, parent, LayerNames.Default);
	}

	public static GameObject CreateBlockBodyModel(BodySchematic bodySchematic, Transform parent, int layer)
	{
		GameObject prefab = bodySchematic.ParentSchematic.Prefab;
		GameObject gameObject;
		if (prefab != null)
		{
			gameObject = Object.Instantiate(prefab.transform.GetChild(bodySchematic.Index).gameObject);
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = true;
			}
		}
		else
		{
			gameObject = CreateBlockBodyCollider(bodySchematic, parent);
			gameObject.AddComponent<MeshFilter>().sharedMesh = bodySchematic.ModelMesh;
			gameObject.AddComponent<MeshRenderer>().sharedMaterial = bodySchematic.MainMaterial;
		}
		gameObject.name = "BlockModel";
		gameObject.tag = "BlockModel";
		gameObject.layer = layer;
		BlockBodyView blockBodyView = gameObject.AddComponent<BlockBodyView>();
		blockBodyView.ParentBlockView = null;
		blockBodyView.Index = 0;
		blockBodyView.BodySchematic = bodySchematic;
		blockBodyView.MaterialSchematic = bodySchematic.ParentSchematic.MaterialSchematic;
		return gameObject;
	}
}
