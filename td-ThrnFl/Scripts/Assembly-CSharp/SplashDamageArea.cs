using System.Collections.Generic;
using UnityEngine;

public class SplashDamageArea : MonoBehaviour
{
	public enum EShape
	{
		Sphere = 0,
		Box = 1
	}

	public EShape shape;

	public Vector3 boxSize;

	public float sphereRadius;

	public LayerMask layerMaskRecieveDamage;

	private static Collider[] collidersTemp = new Collider[200];

	private void OnDrawGizmosSelected()
	{
		if (shape == EShape.Box)
		{
			Gizmos.color = Color.red;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(Vector3.zero, boxSize);
		}
		else
		{
			Gizmos.color = Color.red;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawWireSphere(Vector3.zero, sphereRadius);
		}
	}

	public void AddReiveDamageHpScriptsInAreaToList(List<Hp> _listOfHpScripts)
	{
		int num = 0;
		num = ((shape != EShape.Box) ? Physics.OverlapSphereNonAlloc(base.transform.position, sphereRadius, collidersTemp, layerMaskRecieveDamage) : Physics.OverlapBoxNonAlloc(base.transform.position, boxSize, collidersTemp, base.transform.rotation, layerMaskRecieveDamage));
		for (int i = 0; i < num; i++)
		{
			Hp componentInParent = collidersTemp[i].GetComponentInParent<Hp>();
			if (!(componentInParent == null) && !_listOfHpScripts.Contains(componentInParent))
			{
				_listOfHpScripts.Add(componentInParent);
			}
		}
	}
}
