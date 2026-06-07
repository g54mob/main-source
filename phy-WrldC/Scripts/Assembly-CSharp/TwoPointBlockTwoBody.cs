using UnityEngine;

public class TwoPointBlockTwoBody : TwoPointBlockBase
{
	private readonly GameObject secondBodyObject;

	public TwoPointBlockTwoBody(TwoPointBlock twoPointBlock)
		: base(twoPointBlock)
	{
		secondBodyObject = twoPointBlock.transform.parent.transform.GetChild(1).gameObject;
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderCollider || twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderModel)
		{
			secondBodyObject.SetActive(value: false);
		}
	}

	protected override void InternalMakeMesh()
	{
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.Rigid || twoPointBlock.Place == TwoPointBlock.PlaceEnum.Model)
		{
			secondBodyObject.transform.localPosition = twoPointBlock.endPointPosition;
			secondBodyObject.transform.localRotation = twoPointBlock.endPointRotation;
			if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.Rigid)
			{
				MeshCollider meshCollider = barObject.AddComponent<MeshCollider>();
				meshCollider.sharedMesh = barObject.GetComponent<MeshFilter>().mesh;
				meshCollider.sharedMaterial = twoPointBlock.GetComponent<MeshCollider>().sharedMaterial;
				meshCollider.convex = true;
			}
		}
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderCollider || twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderModel)
		{
			CreateMeshFilterAndColliders();
		}
	}

	protected override void InternalResetMesh()
	{
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderCollider || twoPointBlock.Place == TwoPointBlock.PlaceEnum.PlaceholderModel)
		{
			RemoveExtraMeshesColliders();
		}
	}
}
