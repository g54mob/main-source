using UnityEngine;

public class Flies : MonoBehaviour
{
	public enum Height
	{
		Normal = 0,
		Short = 1,
		Middle = 2
	}

	public Height height;

	private const float kMaxHeight = 1.5f;

	private void Start()
	{
		Renderer component = GetComponent<Renderer>();
		float y = 1f;
		if (height == Height.Short)
		{
			y = 0f;
		}
		else if (height == Height.Middle)
		{
			y = 0.5f;
		}
		component.material.SetVector("_FliesParams", new Vector2(Random.Range(0, 10), y));
	}
}
