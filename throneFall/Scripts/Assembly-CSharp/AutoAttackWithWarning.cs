using Shapes;
using UnityEngine;

public class AutoAttackWithWarning : AutoAttack
{
	[SerializeField]
	private Line line;

	private TaggedObject targeting;

	public float breakTargetingDistance = 10f;

	private TagManager tagManager;

	public override void Start()
	{
		base.Start();
		tagManager = TagManager.instance;
		line.transform.SetParent(null);
		line.transform.position = Vector3.zero;
	}

	public override void Update()
	{
		HandleTargeting();
		base.Update();
	}

	private void HandleTargeting()
	{
		if (!targeting)
		{
			targeting = null;
			line.enabled = false;
			return;
		}
		if (!targeting.Tags.Contains(TagManager.ETag.AUTO_Alive))
		{
			targeting = null;
			line.enabled = false;
			return;
		}
		Vector3 vector = base.transform.position + Vector3.up * spawnAttackHeight;
		if (tagManager.MeasureDistanceToTaggedObject(targeting, vector) > breakTargetingDistance)
		{
			targeting = null;
			line.enabled = false;
		}
		else if (targeting.Tags.Contains(TagManager.ETag.Building))
		{
			line.enabled = false;
		}
		else
		{
			line.enabled = true;
			line.Start = vector;
			line.End = targeting.transform.position + Vector3.up * 1f;
		}
	}

	public override void OnAttack(TaggedObject target)
	{
		if ((bool)targeting && target != targeting)
		{
			OnAttack(targeting);
		}
		if (target != targeting)
		{
			targeting = target;
			return;
		}
		weapon.Attack(base.transform.position + spawnAttackHeight * Vector3.up, target.Hp, Vector3.zero, taggedObject, damageMultiplyer);
		lastTargetPosition = target.transform.position;
		onAttackTriggered.Invoke();
		onCooldown = true;
	}

	private void OnDestroy()
	{
		if ((bool)line)
		{
			Object.Destroy(line.gameObject);
		}
	}
}
