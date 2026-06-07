using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(ParticleSystem))]
public class ParticleNormalFlip : MonoBehaviour
{
	[SerializeField]
	private bool DefaultIsFrontFaceCulling;

	[Header("Debug")]
	[SerializeField]
	private bool hasFlippedNormal;

	private Renderer ren;

	private float defaultCull;

	private float negativeCull;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
