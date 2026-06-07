using UnityEngine;

public class BeltScript : MonoBehaviour
{
	public MeshFilter Belt;

	public Mesh BeltNone;

	public Mesh BeltIn;

	public Mesh BeltOut;

	public Mesh BeltBoth;

	public bool Perpendicular;

	public bool Scale;

	public void UpdateBelt(bool cIn, bool cOut, bool pOut)
	{
		if (cIn)
		{
			Belt.sharedMesh = (cOut ? BeltBoth : BeltIn);
		}
		else
		{
			Belt.sharedMesh = (cOut ? BeltOut : BeltNone);
		}
		if (Scale)
		{
			Vector3 localPosition = base.transform.localPosition;
			if (!cOut && pOut)
			{
				base.transform.localScale = new Vector3(1f, 1f, 1.15f);
				base.transform.localPosition = new Vector3(localPosition.x, localPosition.y, 0.075f);
			}
			else
			{
				base.transform.localScale = Vector3.one;
				base.transform.localPosition = new Vector3(localPosition.x, localPosition.y, 0f);
			}
		}
	}
}
