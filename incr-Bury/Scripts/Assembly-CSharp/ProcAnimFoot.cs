using System;
using UnityEngine;

public class ProcAnimFoot : MonoBehaviour
{
	public LayerMask terrainLayer;

	public ProcAnimFoot otherFoot;

	public float stepDistance;

	public float stepHeight;

	public float stepLenght;

	public float footSpacing;

	public float speed;

	public Transform body;

	public Vector3 footOffset;

	private Vector3 oldPosition;

	private Vector3 newPosition;

	private Vector3 currentPosition;

	private Vector3 oldNormal;

	private Vector3 currentNormal;

	private Vector3 newNormal;

	private float lerp;

	private Vector3 forceNewLegCheckPos = new Vector3(0f, -1000f, 0f);

	private BerryCultist_AI ourBerryCultistAI;

	private bool resetOnNextStateChange;

	[Header("Ragdoll Foot Handling")]
	[SerializeField]
	private float maxLegLength;

	[SerializeField]
	private Transform legOrigin;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		ourBerryCultistAI = GetComponentInParent<BerryCultist_AI>();
	}

	private void Start()
	{
		Reset();
	}

	private void Update()
	{
		if (ourBerryCultistAI.airState == BerryCultist_AI.AirState.Ragdolled)
		{
			resetOnNextStateChange = true;
			return;
		}
		if (resetOnNextStateChange)
		{
			newPosition = forceNewLegCheckPos;
			lerp = 0f;
			resetOnNextStateChange = false;
		}
		base.transform.position = currentPosition;
		base.transform.up = currentNormal;
		if (Physics.Raycast(new Ray(body.position + body.right * footSpacing, Vector3.down), out var hitInfo, 10f, terrainLayer) && Vector3.Distance(newPosition, hitInfo.point) > stepDistance && !otherFoot.isMoving() && lerp >= 1f)
		{
			lerp = 0f;
			int num = ((body.InverseTransformPoint(hitInfo.point).z > body.InverseTransformPoint(newPosition).z) ? 1 : (-1));
			newPosition = hitInfo.point + body.forward * stepLenght * num + footOffset;
			newNormal = hitInfo.normal;
		}
		if (lerp < 1f)
		{
			Vector3 vector = Vector3.Lerp(oldPosition, newPosition, lerp);
			vector.y += Mathf.Sin(lerp * MathF.PI) * stepHeight;
			currentPosition = vector;
			currentNormal = Vector3.Lerp(oldNormal, newNormal, lerp);
			lerp += Time.deltaTime * speed;
		}
		else
		{
			oldPosition = newPosition;
			oldNormal = newNormal;
		}
	}

	private void FixedUpdate()
	{
		_ = ourBerryCultistAI.airState;
	}

	private void Reset()
	{
		footSpacing = base.transform.localPosition.x;
		oldPosition = (newPosition = (currentPosition = base.transform.position));
		oldNormal = (currentNormal = (newNormal = base.transform.up));
		lerp = 1f;
	}

	public bool isMoving()
	{
		return lerp < 1f;
	}

	private void HandleRagdollLegPlacement()
	{
		if (Vector3.Distance(legOrigin.position, base.transform.position) > maxLegLength)
		{
			base.transform.position = legOrigin.position + -legOrigin.up * maxLegLength;
		}
	}
}
