using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitDashJumpEnemy : MonoBehaviour
{
	private float nextJumpPossibleIn = 3f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float recheckInterval = 0.75f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float jumpCooldown = 12f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float snapRange = 1f;

	[SerializeField]
	private AutoAttack autoAttack;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float minAttackJumpDistance;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float maxAttackJumpDistance;

	[SerializeField]
	private float jumpDuration = 1f;

	[SerializeField]
	private float jumpHeight = 10f;

	public List<TargetPriority> targetPriorities;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float additionalInvulnerabilityTime;

	[SerializeField]
	private Weapon weaponOnLanding;

	[SerializeField]
	private Transform aliveParent;

	[SerializeField]
	private GameObject meshParent;

	[SerializeField]
	private Hp hp;

	[SerializeField]
	private PathfindMovementEnemy unitMovement;

	[SerializeField]
	private TaggedObject taggedObject;

	public UnityEvent<Vector3> onStartJump;

	private bool dashJumpAnimRunning;

	private void Start()
	{
		nextJumpPossibleIn = Random.value * recheckInterval;
	}

	private void Update()
	{
		if (dashJumpAnimRunning || !hp.Alive)
		{
			return;
		}
		nextJumpPossibleIn -= Time.deltaTime;
		if (nextJumpPossibleIn > 0f)
		{
			return;
		}
		nextJumpPossibleIn = recheckInterval;
		TaggedObject taggedObject = AutoAttack.FindAutoAttackTarget(targetPriorities, base.transform.position);
		if (!(taggedObject == null))
		{
			float magnitude = (taggedObject.transform.position - base.transform.position).magnitude;
			if (!(magnitude < minAttackJumpDistance) && !(magnitude > maxAttackJumpDistance))
			{
				nextJumpPossibleIn = jumpCooldown;
				StartCoroutine(DashJumpAnimation(taggedObject, magnitude));
			}
		}
	}

	private IEnumerator DashJumpAnimation(TaggedObject _objToAttack, float _distance)
	{
		dashJumpAnimRunning = true;
		autoAttack.enabled = false;
		hp.invulnerable = true;
		unitMovement.enabled = false;
		Vector3 targetPosition = _objToAttack.transform.position;
		Vector3 nearestGroundPosition = unitMovement.GetNearestGroundPosition(targetPosition);
		if ((nearestGroundPosition - targetPosition).magnitude < snapRange)
		{
			onStartJump.Invoke(nearestGroundPosition);
			Vector3 startPos = base.transform.position;
			targetPosition = nearestGroundPosition;
			for (float t = 0f; t < 1f; t += Time.deltaTime / jumpDuration)
			{
				float num = jumpHeight * ((0f - t) * t + t);
				base.transform.position = Vector3.Lerp(startPos, targetPosition, t) + jumpHeight * num * Vector3.up;
				yield return null;
			}
			base.transform.position = targetPosition;
			if ((bool)_objToAttack)
			{
				Vector3 vector = base.transform.position + autoAttack.spawnAttackHeight * Vector3.up;
				weaponOnLanding.Attack(vector, _objToAttack.Hp, _objToAttack.transform.position - vector, taggedObject, autoAttack.DamageMultiplyer);
			}
		}
		unitMovement.enabled = true;
		unitMovement.OriginalPathRequest();
		aliveParent.localRotation = Quaternion.identity;
		aliveParent.localPosition = Vector3.zero;
		dashJumpAnimRunning = false;
		autoAttack.enabled = true;
		yield return new WaitForSeconds(additionalInvulnerabilityTime);
		hp.invulnerable = false;
	}

	private void InstantiateHere(GameObject _go)
	{
		if ((bool)_go)
		{
			FireArcherBurn component = Object.Instantiate(_go, base.transform.position, Quaternion.identity).GetComponent<FireArcherBurn>();
			if ((bool)component)
			{
				component.DamageMultiplyer = GetComponent<AutoAttack>().DamageMultiplyer;
			}
		}
	}
}
