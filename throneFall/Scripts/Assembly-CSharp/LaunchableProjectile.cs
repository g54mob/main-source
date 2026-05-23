using System.Collections.Generic;
using UnityEngine;

public class LaunchableProjectile : MonoBehaviour
{
	public float speed = 20f;

	public float lifetime = 3f;

	public bool groundedTranslation;

	public LayerMask groundLayer;

	public Vector3 groundingOfffset;

	public List<DamageModifyer> dmgModifiers = new List<DamageModifyer>();

	public LayerMask hitLayer;

	public Vector3 damageBoxExtents;

	private bool launched;

	private float timer;

	private List<Hp> touchedEnemies = new List<Hp>();

	public void Launch()
	{
		launched = true;
		if (groundedTranslation && Physics.Raycast(new Ray(base.transform.position, Vector3.down), out var hitInfo, float.PositiveInfinity, groundLayer))
		{
			base.transform.position = hitInfo.point + groundingOfffset;
		}
	}

	private void Update()
	{
		if (!launched)
		{
			return;
		}
		timer += Time.deltaTime;
		base.transform.position += base.transform.forward * speed * Time.deltaTime;
		Collider[] array = Physics.OverlapBox(base.transform.position, damageBoxExtents / 2f, base.transform.rotation, hitLayer);
		for (int i = 0; i < array.Length; i++)
		{
			Hp componentInParent = array[i].GetComponentInParent<Hp>();
			if ((bool)componentInParent && !touchedEnemies.Contains(componentInParent))
			{
				touchedEnemies.Add(componentInParent);
				componentInParent.TakeDamage(DamageModifyer.CalculateDamageOnTarget(componentInParent.TaggedObj, dmgModifiers));
			}
		}
		if (timer >= lifetime)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireCube(base.transform.position, damageBoxExtents);
	}
}
