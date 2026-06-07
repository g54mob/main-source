using UnityEngine;

public abstract class bqq : MonoBehaviour
{
	public Transform gravityTarget;

	public float gravityMultiplier;

	public float airborneThreshold;

	public float slopeStartAngle;

	public float slopeEndAngle;

	public float spherecastRadius;

	public LayerMask groundLayers;

	private PhysicsMaterial uly;

	private PhysicsMaterial ulz;

	protected Rigidbody uma;

	protected const float umb = 0.5f;

	protected float umc;

	protected Vector3 umd;

	protected CapsuleCollider ume;

	protected void ql()
	{
	}

	protected void bvs()
	{
	}

	protected virtual RaycastHit lhi()
	{
		return default(RaycastHit);
	}

	public float fcy(Vector3 a)
	{
		return 0f;
	}

	protected void nej(float a)
	{
	}

	protected virtual void Start()
	{
	}

	protected void cb(float a)
	{
	}

	public float hkw(Vector3 a)
	{
		return 0f;
	}

	protected void lhn()
	{
	}

	protected void lhm()
	{
	}

	protected void bnj()
	{
	}

	public abstract void Move(Vector3 deltaPosition, Quaternion deltaRotation);

	protected Vector3 kow()
	{
		return default(Vector3);
	}

	protected Vector3 hor()
	{
		return default(Vector3);
	}

	protected void lhl(float a)
	{
	}

	protected Vector3 lhh()
	{
		return default(Vector3);
	}

	protected void lhk(Vector3 a, Vector3 b, float c)
	{
	}

	protected float cvf(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public float lhj(Vector3 a)
	{
		return 0f;
	}

	protected void hlp()
	{
	}

	protected Vector3 cpm()
	{
		return default(Vector3);
	}

	protected void bbs(float a)
	{
	}

	protected float lho(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	protected Vector3 lb()
	{
		return default(Vector3);
	}
}
