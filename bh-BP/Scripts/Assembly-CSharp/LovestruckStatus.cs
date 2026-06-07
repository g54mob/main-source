using UnityEngine;

[ExecuteInEditMode]
public class LovestruckStatus : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform arrow;

	[SerializeField]
	private Transform heart;

	private Vector3 prevPos;

	private Vector3 pos;

	private Vector3 dir;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
