using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Pinata : MonoBehaviour
{
	public int tier;

	public int health;

	public int candies;

	private bool hasBroken;

	[SerializeField]
	private Transform candySpawnPoint;

	[Header("Breaking")]
	[SerializeField]
	private GameObject broken_Prefab;

	private float damageBuffer = 0.2f;

	private float damageBuffer_Curr;

	[Header("Rope")]
	[SerializeField]
	private LineRenderer rope_LineRend;

	[SerializeField]
	private GameObject ropeAttachPoint_Roof;

	[SerializeField]
	private GameObject ropeAttachPoint_Body;

	[Header("Particles")]
	[SerializeField]
	private GameObject confettiPop_Particles;

	[SerializeField]
	private GameObject confettiImpacts_Particles;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_Impact;

	private List<GameObject> chosenLoot_Prefabs = new List<GameObject>();

	private void Start()
	{
		ropeAttachPoint_Roof.transform.SetParent(null);
		ropeAttachPoint_Roof.transform.position = new Vector3(ropeAttachPoint_Roof.transform.position.x, 11.75f, ropeAttachPoint_Roof.transform.position.z);
		AttachBallToAnchor(base.gameObject.GetComponent<Rigidbody>(), ropeAttachPoint_Roof.transform);
	}

	private void Update()
	{
		if (damageBuffer_Curr > 0f)
		{
			damageBuffer_Curr -= Time.deltaTime;
		}
	}

	private void FixedUpdate()
	{
		UpdateRopeVisuals();
	}

	private void UpdateRopeVisuals()
	{
		rope_LineRend.SetPosition(0, ropeAttachPoint_Body.transform.position);
		rope_LineRend.SetPosition(1, ropeAttachPoint_Roof.transform.position);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (damageBuffer_Curr > 0f || !collision.collider.transform.root.CompareTag("PickUp"))
		{
			return;
		}
		PickUppable component = collision.collider.transform.root.GetComponent<PickUppable>();
		try
		{
			if (component.GetPickUpType() == PickUpType.Berry || component.GetItemIdentity() == ItemIdentity.SledgeHammer || component.GetItemIdentity() == ItemIdentity.Cultist)
			{
				Object.Instantiate(confettiImpacts_Particles, collision.GetContact(0).point, Quaternion.identity);
				feedback_Impact?.PlayFeedbacks();
				if (component.GetPickUpType() == PickUpType.Berry)
				{
					DamagePinata(component.gameObject.GetComponent<Berry>().berryTier + 1);
				}
				else if (component.GetItemIdentity() == ItemIdentity.SledgeHammer)
				{
					DamagePinata((PlayerStats.Singleton.SledgeHammer_Tier + 1) * 3);
				}
				else if (component.GetItemIdentity() == ItemIdentity.Cultist)
				{
					DamagePinata(component.GetComponent<BerryCultist_AI>().GetBerryTier() + 1);
				}
			}
		}
		catch
		{
		}
	}

	public void DamagePinata(int _amt)
	{
		damageBuffer_Curr = damageBuffer;
		health -= _amt;
		if (health <= 0)
		{
			BreakPinata();
		}
		Debug.Log("Damaged Pinata, " + _amt);
	}

	public void SetHealth(int _amt)
	{
		health = _amt;
	}

	public void SetNumOfCandies(int _amt)
	{
		candies = _amt;
	}

	public void BreakPinata()
	{
		if (hasBroken)
		{
			return;
		}
		hasBroken = true;
		Object.Instantiate(broken_Prefab, base.transform.position, base.transform.rotation);
		List<Rigidbody> list = new List<Rigidbody>();
		for (int i = 0; i < candies; i++)
		{
			PickUppable component = Object.Instantiate(GameManager.Singleton.prefabBank.candy_Prefab, candySpawnPoint.position, Quaternion.identity).GetComponent<PickUppable>();
			component.DisableColliders_Local();
			component.DisableCollisionForACertainTime(0.2f);
			list.Add(component.GetComponent<Rigidbody>());
		}
		int maxExclusive = (tier + 1) * 5;
		int num = Random.Range(1, maxExclusive);
		int num2 = 0;
		for (int j = 0; j < num; j++)
		{
			num2 = Random.Range(0, PlayerStats.Singleton.highestBerryTierGrown + 1);
			PickUppable component2 = Object.Instantiate(GameManager.Singleton.prefabBank.berryProfiles[num2].berryPrefab, candySpawnPoint.position, Quaternion.identity).GetComponent<PickUppable>();
			component2.DisableColliders_Local();
			component2.DisableCollisionForACertainTime(0.2f);
			list.Add(component2.GetComponent<Rigidbody>());
		}
		Vector3 vector = default(Vector3);
		foreach (Rigidbody item in list)
		{
			if ((bool)item)
			{
				vector = new Vector3(Random.Range(-4f, 4f), Random.Range(6f, 10f), Random.Range(-4f, 4f));
				item.AddForce(vector, ForceMode.VelocityChange);
			}
		}
		AudioManager.Singleton.PlayPinataBreakSFX(base.transform.position);
		Object.Destroy(base.gameObject);
	}

	public static void AttachBallToAnchor(Rigidbody ball, Transform anchor)
	{
		ConfigurableJoint component = ball.GetComponent<ConfigurableJoint>();
		if (component != null)
		{
			Object.Destroy(component);
		}
		ConfigurableJoint configurableJoint = ball.gameObject.AddComponent<ConfigurableJoint>();
		Rigidbody rigidbody = anchor.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = anchor.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
		}
		configurableJoint.connectedBody = rigidbody;
		configurableJoint.xMotion = ConfigurableJointMotion.Limited;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
		configurableJoint.linearLimit = new SoftJointLimit
		{
			limit = Vector3.Distance(ball.position, anchor.position) * 0.1f
		};
		configurableJoint.autoConfigureConnectedAnchor = false;
		Vector3 anchor2 = ball.transform.InverseTransformPoint(anchor.position);
		configurableJoint.anchor = anchor2;
		configurableJoint.connectedAnchor = Vector3.zero;
		JointDrive zDrive = (configurableJoint.yDrive = (configurableJoint.xDrive = new JointDrive
		{
			positionSpring = 0f,
			positionDamper = 0f,
			maximumForce = float.PositiveInfinity
		}));
		configurableJoint.zDrive = zDrive;
	}

	public void SetPinataTier(int _tier)
	{
		tier = _tier;
		SetHealth(3 + _tier * 3);
		RandomLootRoll();
	}

	public void RandomLootRoll()
	{
		int num = Random.Range(0, 101);
		if (num > 90)
		{
			SetNumOfCandies(2);
		}
		else if (num > 60)
		{
			SetNumOfCandies(1);
		}
		else
		{
			SetNumOfCandies(0);
		}
	}
}
