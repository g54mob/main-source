using UnityEngine;

public class TwoPointBlock : MonoBehaviour
{
	public enum PlaceEnum
	{
		PlaceholderCollider = 0,
		PlaceholderModel = 1,
		Model = 2,
		Rigid = 3
	}

	public Vector3 endPointPosition;

	public Quaternion endPointRotation;

	public Vector3 pivotPointsScale;

	private TwoPointBlockBase twoPointBlockBase;

	private bool isInitialized;

	public BlockBodyView ParentBlockBodyView { get; set; }

	public BodySchematic BodySchematic { get; private set; }

	public PlaceEnum Place { get; set; }

	private void Initialize()
	{
		if (isInitialized)
		{
			return;
		}
		pivotPointsScale = Vector3.one;
		if (Place == PlaceEnum.PlaceholderCollider)
		{
			base.transform.localScale = Vector3.one;
			pivotPointsScale = Vector3.one * 0.87f;
		}
		BlockBodyView component = GetComponent<BlockBodyView>();
		if (component != null)
		{
			BodySchematic = component.BodySchematic;
		}
		else
		{
			ObjectsInCollision component2 = GetComponent<ObjectsInCollision>();
			if (component2 != null)
			{
				BodySchematic = component2.BodySchematic;
			}
		}
		if (BodySchematic.TwoPointProperties.GetProperty("type") == "OneBody")
		{
			twoPointBlockBase = new TwoPointBlockOneBody(this);
		}
		else if (BodySchematic.TwoPointProperties.GetProperty("type") == "TwoBody")
		{
			twoPointBlockBase = new TwoPointBlockTwoBody(this);
		}
		isInitialized = true;
	}

	public void MakeMesh()
	{
		Initialize();
		twoPointBlockBase.MakeMesh();
	}

	public void ResetMesh()
	{
		twoPointBlockBase.ResetMesh();
	}
}
