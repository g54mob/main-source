using UnityEngine;

[ExecuteInEditMode]
public class BaseElevatorAnimator : MonoBehaviour
{
	public MeshRenderer[] ropes;

	public ElevatorGear[] gears;

	public MaterialPropertyBlock ropesPropertyBlock;

	public float speed;

	private float time;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
