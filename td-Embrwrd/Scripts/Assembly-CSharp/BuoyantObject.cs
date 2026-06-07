using StylizedWater;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyantObject : MonoBehaviour
{
	private Color red;

	private Color green;

	private Color blue;

	private Color orange;

	private float steepness;

	private float wavelength;

	private float speed;

	private float[] directions;

	[Header("Water Object")]
	public StylizedWaterURP water;

	[Range(1f, 5f)]
	[Header("Buoyancy")]
	public float strength;

	[Range(0.2f, 5f)]
	public float objectDepth;

	public float velocityDrag;

	public float angularDrag;

	[Header("Effectors")]
	public Transform[] effectors;

	private Rigidbody rb;

	private Vector3[] effectorProjections;

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
