using UnityEngine;

public class Bird : MonoBehaviour
{
	[SerializeField]
	private Vector2 randomScale = new Vector2(0.8f, 1.2f);

	[SerializeField]
	private ColorSet randomColor;

	[SerializeField]
	private float swarmColorJitter = 0.1f;

	private MeshRenderer meshRenderer;

	[SerializeField]
	private AudioClipOptions birdLoop;

	private void Awake()
	{
		meshRenderer = GetComponentInChildren<MeshRenderer>();
		AudioManager.Instance.PlaySoundAtTransform(birdLoop, base.transform);
	}

	public void Randomize(float baseColor)
	{
		base.transform.localScale = Random.Range(randomScale.x, randomScale.y) * Vector3.one;
		foreach (ColorOption colorOption in randomColor.colorOptions)
		{
			meshRenderer.material.SetColor(colorOption.propertyName, colorOption.possibleColors.Evaluate(baseColor + Random.value * swarmColorJitter));
		}
	}
}
