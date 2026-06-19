using System.Collections.Generic;
using UnityEngine;

public class GravboostDog : MonoBehaviour
{
	private float groundedGravboostMult = 1.5f;

	private float currentUngroundedTimer;

	private float anyFootLastGroundedWindow = 0.25f;

	private List<int> legHolderIndices = new List<int>();

	private List<int> nonLegHolderIndices = new List<int>();

	private List<Rigidbody> rbList = new List<Rigidbody>();

	private bool validRotation;

	private float lastRoomMultiplier = 1f;

	private float? customMultiplier;

	private DogAI aiRef;

	private TurnInPlace turnRef;

	private LegController legRef;

	private BoundingBoxComponent bbcRef;

	private DogHome homeRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		turnRef = GetComponent<TurnInPlace>();
		legRef = GetComponent<LegController>();
		bbcRef = GetComponent<BoundingBoxComponent>();
		if (bbcRef == null)
		{
			bbcRef = base.gameObject.AddComponent<BoundingBoxComponent>();
		}
		RegisterRigidbodies(base.gameObject, topLevel: true);
		RegisterLegHolders();
		homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
	}

	private void FixedUpdate()
	{
		validRotation = aiRef.IsValidRotation();
		float customMult = 1f;
		if (bbcRef != null && homeRef.AnyGravModsActive())
		{
			customMult = homeRef.GetGravModForRoomUID(bbcRef.GetRoomUID(requireInRoom: false, requireIntersectInstead: true));
		}
		if (customMultiplier.HasValue)
		{
			customMult = customMultiplier.Value;
		}
		for (int i = 0; i < legHolderIndices.Count; i++)
		{
			ProcessRigidbody(rbList[legHolderIndices[i]], isLegHolder: true, customMult);
		}
		for (int j = 0; j < nonLegHolderIndices.Count; j++)
		{
			ProcessRigidbody(rbList[nonLegHolderIndices[j]], isLegHolder: false, customMult);
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

	private void RegisterRigidbodies(GameObject obj, bool topLevel = false)
	{
		if (topLevel)
		{
			Rigidbody component = obj.GetComponent<Rigidbody>();
			if (component != null)
			{
				rbList.Add(component);
			}
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			Rigidbody component2 = obj.transform.GetChild(i).GetComponent<Rigidbody>();
			if (component2 != null)
			{
				rbList.Add(component2);
			}
			RegisterRigidbodies(obj.transform.GetChild(i).gameObject);
		}
	}

	private void RegisterLegHolders()
	{
		for (int i = 0; i < rbList.Count; i++)
		{
			if (legRef.IsLegHolder(rbList[i].transform.parent.gameObject))
			{
				legHolderIndices.Add(i);
			}
			else
			{
				nonLegHolderIndices.Add(i);
			}
		}
	}

	private void ProcessRigidbody(Rigidbody rb, bool isLegHolder, float customMult = 1f)
	{
		if (rb == null || (lastRoomMultiplier == customMult && (rb.IsSleeping() || MathUtil.Vector3AlmostEqual(rb.velocity, Vector3.zero))))
		{
			return;
		}
		lastRoomMultiplier = customMult;
		if (validRotation && !turnRef.IsDoingPlantedTurn() && isLegHolder && legRef.IsLegHolderAndGrounded(rb.transform.parent.gameObject) && !legRef.GetLegGroupForLegHolder(rb.transform.parent.gameObject).IsMovingUp())
		{
			currentUngroundedTimer = 0f;
			ApplyAdditionalForce(rb, Physics.gravity * rb.mass * groundedGravboostMult, customMult);
			return;
		}
		if (legRef.AnyLegGrounded())
		{
			currentUngroundedTimer = 0f;
			ApplyAdditionalForce(rb, Physics.gravity * rb.mass * GlobalProperties.gravboostMultDog, customMult);
			return;
		}
		currentUngroundedTimer += Time.deltaTime;
		if (currentUngroundedTimer < anyFootLastGroundedWindow)
		{
			ApplyAdditionalForce(rb, Physics.gravity * rb.mass * GlobalProperties.gravboostMultDog, customMult);
		}
		else if (customMult != 1f)
		{
			ApplyAdditionalForce(rb, Vector3.zero, customMult);
		}
	}

	private void ApplyAdditionalForce(Rigidbody rb, Vector3 newGrav, float gravMult)
	{
		rb.AddForce(newGrav);
		if (gravMult != 1f)
		{
			Vector3 vector = Physics.gravity * rb.mass + newGrav;
			Vector3 force = vector * gravMult - vector;
			rb.AddForce(force);
		}
	}
}
