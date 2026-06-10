using UnityEngine;

public class PlayerLocationOverwriter : MonoBehaviour
{
	[Range(100f, 200f)]
	public float ColliderSizePercent;

	public LayerMask layerMask;

	private CharacterController characterController;

	private void Start()
	{
	}

	public void OverWriteLocation()
	{
	}
}
