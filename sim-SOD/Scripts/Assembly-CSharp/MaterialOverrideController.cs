using UnityEngine;

public class MaterialOverrideController : MonoBehaviour
{
	[Range(0f, 1f)]
	[Header("Override Properties")]
	public float concrete;

	[Range(0f, 1f)]
	public float plaster;

	[Range(0f, 1f)]
	public float wood;

	[Range(0f, 1f)]
	public float carpet;

	[Range(0f, 1f)]
	public float tile;

	[Range(0f, 1f)]
	public float metal;

	[Range(0f, 1f)]
	public float glass;

	[Range(0f, 1f)]
	public float fabric;
}
