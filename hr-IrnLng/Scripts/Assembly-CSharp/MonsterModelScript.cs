using UnityEngine;

public class MonsterModelScript : MonoBehaviour
{
	public float MoveSpeed;

	public bool amactive;

	private Renderer MyRenderer;

	private void Start()
	{
		MyRenderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		if (amactive)
		{
			float x = base.transform.position.x;
			x += Time.deltaTime * MoveSpeed;
			base.transform.position = new Vector3(x, base.transform.position.y, base.transform.position.z);
		}
	}

	private void FixedUpdate()
	{
		if (amactive)
		{
			MyRenderer.enabled = true;
		}
		else
		{
			MyRenderer.enabled = false;
		}
	}
}
