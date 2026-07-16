using UnityEngine;

public class FakeRope : MonoBehaviour
{
	[Header("Objects to Connect")]
	[SerializeField]
	private Transform objectA;

	[SerializeField]
	private Transform objectB;

	[Header("Rope Settings")]
	[SerializeField]
	private float ropeWidth = 0.1f;

	[SerializeField]
	private SpriteRenderer ropeSprite;

	[SerializeField]
	private bool updateEveryFrame = true;

	private void Start()
	{
		if (ropeSprite == null)
		{
			ropeSprite = GetComponent<SpriteRenderer>();
		}
		UpdateRopePosition();
	}

	private void Update()
	{
		if (updateEveryFrame)
		{
			UpdateRopePosition();
		}
	}

	private void UpdateRopePosition()
	{
		if (!(objectA == null) && !(objectB == null) && !(ropeSprite == null))
		{
			Vector2 vector = objectA.position;
			Vector2 vector2 = objectB.position;
			Vector2 vector3 = vector2 - vector;
			float magnitude = vector3.magnitude;
			base.transform.position = (vector + vector2) / 2f;
			float z = Mathf.Atan2(vector3.y, vector3.x) * 57.29578f;
			base.transform.rotation = Quaternion.Euler(0f, 0f, z);
			float x = ropeSprite.sprite.bounds.size.x;
			float x2 = magnitude / x;
			base.transform.localScale = new Vector3(x2, ropeWidth, 1f);
		}
	}

	public void SetObjectA(Transform newObjectA)
	{
		objectA = newObjectA;
	}

	public void SetObjectB(Transform newObjectB)
	{
		objectB = newObjectB;
	}
}
