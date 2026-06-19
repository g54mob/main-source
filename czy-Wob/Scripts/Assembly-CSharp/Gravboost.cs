using UnityEngine;

public class Gravboost : MonoBehaviour
{
	private float? customMultiplier;

	private float cachedRoomMult = 1f;

	private int lastRoomMultCacheTime = -1;

	private Rigidbody rb;

	private BoundingBoxComponent bbcRef;

	private DogHome homeRef;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		bbcRef = base.transform.root.gameObject.GetComponent<BoundingBoxComponent>();
		if (bbcRef == null)
		{
			bbcRef = base.transform.root.gameObject.AddComponent<BoundingBoxComponent>();
		}
		homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
	}

	public void SetOrCreateBBCManual(GameObject rootObj)
	{
		bbcRef = rootObj.GetComponent<BoundingBoxComponent>();
		if (bbcRef == null)
		{
			bbcRef = rootObj.AddComponent<BoundingBoxComponent>();
		}
	}

	private void FixedUpdate()
	{
		float num = 1f;
		if (customMultiplier.HasValue)
		{
			num = customMultiplier.Value;
		}
		else if (lastRoomMultCacheTime == Time.frameCount)
		{
			num = cachedRoomMult;
		}
		else
		{
			lastRoomMultCacheTime = Time.frameCount;
			if (bbcRef != null && homeRef.AnyGravModsActive())
			{
				num = homeRef.GetGravModForRoomUID(bbcRef.GetRoomUID(requireInRoom: false, requireIntersectInstead: true));
			}
			cachedRoomMult = num;
		}
		if (num != 1f)
		{
			ApplyAdditionalForce(num);
		}
	}

	public void SetCustomMultiplier(float value)
	{
		customMultiplier = value;
	}

	public void ClearCustomMultiplier()
	{
		customMultiplier = null;
	}

	private void ApplyAdditionalForce(float gravMult)
	{
		if (gravMult != 1f)
		{
			Vector3 vector = Physics.gravity * rb.mass;
			Vector3 force = vector * gravMult - vector;
			rb.AddForce(force);
		}
	}
}
