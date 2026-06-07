using System.Collections.Generic;
using UnityEngine;

public class SimpleExplosion : MonoBehaviour
{
	[SerializeField]
	private float radius = 5f;

	[SerializeField]
	private float power = 500f;

	[SerializeField]
	private float damage = 50f;

	private List<Rigidbody> allRigidbodyRegistred;

	public float Radius
	{
		get
		{
			return radius;
		}
		set
		{
			radius = value;
		}
	}

	public float Power
	{
		get
		{
			return power;
		}
		set
		{
			power = value;
		}
	}

	public float Damage
	{
		get
		{
			return damage;
		}
		set
		{
			damage = value;
		}
	}

	private void Awake()
	{
		allRigidbodyRegistred = new List<Rigidbody>();
	}

	public void Explode()
	{
		allRigidbodyRegistred.Clear();
		Vector3 position = base.transform.position;
		Collider[] array = Physics.OverlapSphere(position, Radius);
		foreach (Collider collider in array)
		{
			Rigidbody componentInParent = collider.GetComponentInParent<Rigidbody>();
			if (componentInParent == null)
			{
				continue;
			}
			bool flag = false;
			foreach (Rigidbody item in allRigidbodyRegistred)
			{
				if (componentInParent == item)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				allRigidbodyRegistred.Add(componentInParent);
				componentInParent.AddExplosionForce(Power, position, Radius, 0f, ForceMode.Impulse);
				float num = Vector3.Distance(componentInParent.transform.position, position);
				float num2 = Damage * (1f - num / Radius);
				BlockBodyView blockBodyView = collider.gameObject.GetBlockBodyView();
				if (blockBodyView != null)
				{
					BlockView parentBlockView = blockBodyView.ParentBlockView;
					parentBlockView.Health -= num2 / (float)parentBlockView.BlockBodyViewsCount();
				}
				DynamicObjectBase component = collider.gameObject.GetComponent<DynamicObjectBase>();
				if (component != null)
				{
					component.Health -= num2;
				}
			}
		}
	}
}
