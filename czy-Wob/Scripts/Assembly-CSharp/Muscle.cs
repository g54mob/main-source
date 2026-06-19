using System.Collections.Generic;
using UnityEngine;

public class Muscle : MonoBehaviour
{
	public Rigidbody bodyA;

	public Rigidbody bodyB;

	public Transform attachmentPointA;

	public Transform attachmentPointB;

	public float strength = 200f;

	public GameObject linkRef;

	public KeyCode expandKey = KeyCode.Z;

	public KeyCode contractKey = KeyCode.X;

	private Rigidbody muscleBodyA;

	private Rigidbody muscleBodyB;

	private float muscleChainRadius = 0.75f;

	private List<GameObject> muscleChain = new List<GameObject>();

	private bool debugvis = true;

	private Color attachmentPointColor = Color.red;

	private Color muscleColor = Color.green;

	private void Awake()
	{
		Setup();
	}

	private void Update()
	{
		if (Input.GetKey(expandKey))
		{
			Expand();
		}
		if (Input.GetKey(contractKey))
		{
			Contract();
		}
	}

	private void Setup()
	{
		muscleBodyA = attachmentPointA.gameObject.AddComponent<Rigidbody>();
		muscleBodyA.drag = 0f;
		muscleBodyA.angularDrag = 0f;
		muscleBodyA.mass = 10f;
		muscleBodyB = attachmentPointB.gameObject.AddComponent<Rigidbody>();
		muscleBodyB.drag = 0f;
		muscleBodyB.angularDrag = 0f;
		muscleBodyB.mass = 10f;
		attachmentPointA.gameObject.AddComponent<FixedJoint>().connectedBody = bodyA;
		attachmentPointB.gameObject.AddComponent<FixedJoint>().connectedBody = bodyB;
	}

	private void CreateMuscleChain()
	{
		int num = (int)(Vector3.Distance(attachmentPointA.position, attachmentPointB.position) / (muscleChainRadius / 2f));
		Vector3 localScale = new Vector3(muscleChainRadius, muscleChainRadius, muscleChainRadius);
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = Object.Instantiate(linkRef);
			gameObject.transform.localScale = localScale;
			Vector3 position = Vector3.Lerp(attachmentPointA.position, attachmentPointB.position, (float)i / (float)num);
			gameObject.transform.position = position;
			muscleChain.Add(gameObject);
		}
		muscleChain[0].AddComponent<FixedJoint>().connectedBody = muscleBodyA;
		for (int num2 = num - 1; num2 > 0; num2--)
		{
			SpringJoint springJoint = muscleChain[num2].AddComponent<SpringJoint>();
			springJoint.maxDistance = 0.001f;
			springJoint.minDistance = 0f;
			springJoint.spring = 5000f;
			springJoint.damper = 1000f;
			springJoint.tolerance = 0.001f;
			springJoint.enablePreprocessing = false;
			springJoint.connectedBody = muscleChain[num2 - 1].GetComponent<Rigidbody>();
		}
		muscleChain[muscleChain.Count - 1].AddComponent<FixedJoint>().connectedBody = muscleBodyB;
		for (int j = 0; j < num; j++)
		{
			SphereCollider component = muscleChain[j].GetComponent<SphereCollider>();
			for (int k = j; k < num - j; k++)
			{
				Physics.IgnoreCollision(component, muscleChain[k].GetComponent<SphereCollider>());
			}
		}
	}

	private void Expand()
	{
		MuscleMovement(strength);
	}

	private void Contract()
	{
		MuscleMovement(0f - strength);
	}

	private void MuscleMovement(float torqueStrength)
	{
		Vector3 vector = Vector3.Normalize(attachmentPointA.position - attachmentPointB.position);
		Vector3 vector2 = Vector3.Normalize(attachmentPointA.position - attachmentPointB.position);
		Vector3 force = torqueStrength * vector;
		Vector3 force2 = (0f - torqueStrength) * vector2;
		muscleBodyA.AddForce(force);
		muscleBodyB.AddForce(force2);
	}

	private void OnDrawGizmos()
	{
		if (debugvis)
		{
			Gizmos.color = attachmentPointColor;
			Gizmos.DrawSphere(attachmentPointA.position, 0.5f);
			Gizmos.DrawSphere(attachmentPointB.position, 0.5f);
			Gizmos.color = muscleColor;
			Gizmos.DrawLine(attachmentPointA.position, attachmentPointB.position);
		}
	}
}
