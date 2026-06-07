using UnityEngine;

public abstract class TwoPointBlockBase
{
	protected TwoPointBlock twoPointBlock;

	protected Mesh startMesh;

	protected Mesh endMesh;

	protected Mesh barMesh;

	protected Vector3 startPointBarPos;

	protected Vector3 endPointBarPos;

	protected Transform startTransform;

	protected Transform endTransform;

	protected Matrix4x4 startMatrix4x4;

	protected Matrix4x4 endMatrix4x4;

	protected Matrix4x4 barMatrix4x4;

	protected CombineInstance[] combine;

	protected float barLength;

	protected GameObject barObject;

	public TwoPointBlockBase(TwoPointBlock twoPointBlock)
	{
		this.twoPointBlock = twoPointBlock;
		startMesh = twoPointBlock.BodySchematic.TwoPointBlockSchematic.startMesh;
		endMesh = twoPointBlock.BodySchematic.TwoPointBlockSchematic.endMesh;
		barMesh = twoPointBlock.BodySchematic.TwoPointBlockSchematic.barMesh;
		startPointBarPos = Util.Vector3Parser(twoPointBlock.BodySchematic.TwoPointProperties.GetProperty("startPointBarPos"));
		endPointBarPos = Util.Vector3Parser(twoPointBlock.BodySchematic.TwoPointProperties.GetProperty("endPointBarPos"));
		combine = new CombineInstance[3];
	}

	public void MakeMesh()
	{
		startTransform = new GameObject().transform;
		startTransform.SetParent(twoPointBlock.transform);
		startTransform.position = twoPointBlock.transform.position;
		startTransform.rotation = twoPointBlock.transform.rotation;
		endTransform = new GameObject().transform;
		endTransform.SetParent(twoPointBlock.transform);
		endTransform.localPosition = twoPointBlock.endPointPosition;
		endTransform.localRotation = twoPointBlock.endPointRotation;
		startMatrix4x4 = Matrix4x4.TRS(startTransform.localPosition, startTransform.localRotation, twoPointBlock.pivotPointsScale);
		endMatrix4x4 = Matrix4x4.TRS(endTransform.localPosition, endTransform.localRotation, twoPointBlock.pivotPointsScale);
		startTransform.Translate(startPointBarPos);
		endTransform.Translate(endPointBarPos);
		barLength = Vector3.Distance(startTransform.position, endTransform.position);
		startTransform.localScale = new Vector3(1f, barLength, 1f);
		startTransform.LookAt(endTransform.position);
		startTransform.Rotate(90f, 0f, 0f);
		Vector3 s = ((twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderCollider) ? startTransform.localScale.WithChange(startTransform.localScale.x * 0.87f, null, startTransform.localScale.z * 0.87f) : startTransform.localScale);
		barMatrix4x4 = Matrix4x4.TRS(startTransform.localPosition, startTransform.localRotation, s);
		combine[0].mesh = startMesh;
		combine[0].transform = startMatrix4x4;
		combine[1].mesh = endMesh;
		combine[1].transform = endMatrix4x4;
		combine[2].mesh = barMesh;
		combine[2].transform = barMatrix4x4;
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.Rigid || twoPointBlock.Place == TwoPointBlock.PlaceEnum.Model)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, startTransform.localScale);
			barObject = CreateBarObject(barMesh, matrix4x);
			barObject.transform.Translate(startPointBarPos);
			barObject.transform.LookAt(endTransform);
			barObject.transform.Rotate(90f, 0f, 0f);
		}
		InternalMakeMesh();
		Object.Destroy(startTransform.gameObject);
		Object.Destroy(endTransform.gameObject);
	}

	protected abstract void InternalMakeMesh();

	public void ResetMesh()
	{
		InternalResetMesh();
		if (barObject != null)
		{
			if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.Rigid)
			{
				twoPointBlock.ParentBlockBodyView.RemoveChildObject(barObject);
			}
			Object.Destroy(barObject);
		}
	}

	protected abstract void InternalResetMesh();

	protected GameObject CreateBarObject(Mesh barMesh, Matrix4x4 barMatrix4x4)
	{
		GameObject gameObject = new GameObject("Bar")
		{
			tag = "Block",
			layer = LayerNames.Block
		};
		gameObject.transform.SetParent(twoPointBlock.gameObject.transform, worldPositionStays: false);
		CombineInstance combineInstance = new CombineInstance
		{
			mesh = barMesh,
			transform = barMatrix4x4
		};
		Mesh mesh = new Mesh();
		mesh.CombineMeshes(new CombineInstance[1] { combineInstance });
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.material = twoPointBlock.gameObject.GetComponent<MeshRenderer>().sharedMaterial;
		meshRenderer.material.SetTextureScale("_MainTex", new Vector2(1f, barLength));
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.Rigid)
		{
			twoPointBlock.ParentBlockBodyView.AddChildObject(gameObject);
		}
		return gameObject;
	}

	protected void CreateMeshFilterAndColliders()
	{
		Mesh mesh = new Mesh();
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderCollider || twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderModel)
		{
			mesh.CombineMeshes(combine);
		}
		else
		{
			mesh.CombineMeshes(new CombineInstance[2]
			{
				combine[0],
				combine[1]
			});
		}
		MeshFilter component = twoPointBlock.gameObject.GetComponent<MeshFilter>();
		if (component != null)
		{
			component.sharedMesh = mesh;
		}
		MeshCollider[] allMeshesColliders = twoPointBlock.gameObject.GetComponents<MeshCollider>();
		MeshCollider originalMeshCollider;
		if (allMeshesColliders != null && allMeshesColliders.Length >= 1)
		{
			originalMeshCollider = allMeshesColliders[0];
			Mesh mesh2 = new Mesh();
			mesh2.CombineMeshes(new CombineInstance[1] { combine[0] });
			originalMeshCollider.sharedMesh = mesh2;
			CombineOtherMesh(combine[1], 1);
			CombineOtherMesh(combine[2], 2);
		}
		void CombineOtherMesh(CombineInstance combineInstance, int index)
		{
			Mesh mesh3 = new Mesh();
			mesh3.CombineMeshes(new CombineInstance[1] { combineInstance });
			MeshCollider meshCollider = ((allMeshesColliders.Length <= index) ? twoPointBlock.gameObject.AddComponent<MeshCollider>() : allMeshesColliders[index]);
			meshCollider.sharedMesh = mesh3;
			meshCollider.sharedMaterial = originalMeshCollider.sharedMaterial;
			meshCollider.convex = originalMeshCollider.convex;
			if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderCollider)
			{
				meshCollider.isTrigger = true;
			}
		}
	}

	protected void RemoveExtraMeshesColliders()
	{
		Mesh sharedMesh = twoPointBlock.BodySchematic.TwoPointBlockSchematic.startMesh;
		MeshFilter component = twoPointBlock.gameObject.GetComponent<MeshFilter>();
		if (component != null)
		{
			component.sharedMesh = sharedMesh;
		}
		MeshCollider[] components = twoPointBlock.gameObject.GetComponents<MeshCollider>();
		if (components != null && components.Length >= 2)
		{
			for (int num = components.Length - 1; num >= 1; num--)
			{
				Object.Destroy(components[num]);
			}
		}
	}
}
