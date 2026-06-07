using System;
using UnityEngine;

public class Placer : MonoBehaviour
{
	public PlacerPoints placer;

	public KeyCode key;

	public Transform player;

	private void Start()
	{
		for (int i = 0; i < placer.points.Length; i++)
		{
			AddPhysical(placer.points[i]);
		}
	}

	private void AddPhysical(Vector3 point)
	{
		GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(obj.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(obj.GetComponent<Rigidbody>());
		obj.transform.position = point;
		obj.transform.localScale = new Vector3(15f, 60f, 15f);
		obj.transform.Translate(new Vector3(0f, 30f, 0f));
	}

	private void Update()
	{
		if (Input.GetKeyDown(key))
		{
			Vector3 position = player.position;
			Array.Resize(ref placer.points, placer.points.Length + 1);
			placer.points[placer.points.Length - 1] = position;
			AddPhysical(position);
		}
	}

	private void OnDrawGizmos()
	{
		if ((bool)placer && placer.points != null)
		{
			for (int i = 0; i < placer.points.Length; i++)
			{
				Gizmos.DrawWireSphere(placer.points[i], 30f);
			}
		}
	}
}
