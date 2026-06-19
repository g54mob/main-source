using UnityEngine;

public class LegStructure
{
	public Limb limb;

	public GameObject leg;

	public GameObject foot;

	public GameObject legHolder;

	public Stabilizer stabilizer;

	public GameObject attachedBody;

	public int parallelStructureIndex = -1;

	public bool isGrounded;

	public float groundedCacheFrame = -1f;

	public LegStructure(GameObject leg, GameObject foot, GameObject attachedBody, Stabilizer stabilizer, Limb limb, GameObject legHolder)
	{
		this.leg = leg;
		this.foot = foot;
		this.attachedBody = attachedBody;
		this.limb = limb;
		this.stabilizer = stabilizer;
		this.legHolder = legHolder;
	}
}
