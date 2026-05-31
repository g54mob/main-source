using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleGarbage : MonoBehaviour
{
	public enum HoleGarbageTypeEnum
	{
		GarbageS = 0,
		GarbageM = 1,
		GarbageL = 2,
		GarbageXL = 3,
		GarbageSEvil = 4,
		GarbageMEvil = 5,
		GarbageLEvil = 6,
		GarbageXLEvil = 7,
		ShardBlue = 8,
		ShardRed = 9,
		ShardYellow = 10,
		Book = 11,
		Peon = 12,
		Bulldozer = 13,
		Golem = 14
	}

	public List<Sprite> Sprites;

	private HoleGarbageTypeEnum _type;

	private float _timer;

	private bool _isStatic;

	private Hole _parentHole;

	private Rigidbody2D _rb;

	private CircleCollider2D _cc;

	private SpriteRenderer _sr;

	private List<float> _radius = new List<float>
	{
		0.15f, 0.22f, 0.25f, 0.45f, 0.2f, 0.33f, 0.28f, 0.39f, 0.25f, 0.25f,
		0.25f, 0.25f, 0.39f, 0.81f, 0.59f
	};

	private void FixedUpdate()
	{
		if (!_isStatic)
		{
			_timer += Time.fixedDeltaTime;
			if (!Hole.KeepGarbage && _timer >= 1.5f)
			{
				_isStatic = true;
				GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				_parentHole.SetAsStatic(this);
			}
			else if (_timer >= 4f)
			{
				_isStatic = true;
				GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				_parentHole.SetAsStatic(this);
			}
		}
		if (base.transform.position.x < 19f || base.transform.position.x > 51f)
		{
			_parentHole.DestroyGarbage(this);
		}
	}

	public void AddToTimer()
	{
		_timer -= 2f;
	}

	public void SetParent(Hole parentHole)
	{
		_parentHole = parentHole;
	}

	public void Initialize(HoleGarbageTypeEnum type, Color color, Vector3 position, Quaternion rotation, float angularVelocity, Vector2 linearVelocity)
	{
		_type = type;
		if (_rb == null)
		{
			_rb = GetComponent<Rigidbody2D>();
			_cc = GetComponent<CircleCollider2D>();
			_sr = GetComponent<SpriteRenderer>();
		}
		_cc.radius = _radius[(int)_type];
		_sr.sprite = Sprites[(int)_type];
		_sr.color = color;
		_timer = 0f;
		_isStatic = false;
		base.transform.position = position;
		base.transform.rotation = rotation;
		base.gameObject.SetActive(value: true);
		StartCoroutine(InitializePhysic(angularVelocity, linearVelocity));
	}

	private IEnumerator InitializePhysic(float angularVelocity, Vector2 linearVelocity)
	{
		_rb.bodyType = RigidbodyType2D.Dynamic;
		yield return new WaitForFixedUpdate();
		_rb.angularVelocity = angularVelocity;
		_rb.linearVelocity = linearVelocity;
	}
}
