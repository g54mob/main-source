using UnityEngine;

public class Catapult_Fan : MonoBehaviour
{
	public bool IsRight = true;

	public BoxCollider2D WindRange;

	public AnimationSprite FanAnimation;

	private float _timer;

	private Vector2 _center;

	private Vector2 _size;

	private bool _isRunning;

	private void Start()
	{
		_center = WindRange.GetComponent<BoxCollider2D>().offset;
		_size = WindRange.GetComponent<BoxCollider2D>().bounds.size;
		_center += new Vector2(base.transform.position.x, base.transform.position.y);
		WindRange.GetComponent<BoxCollider2D>().enabled = false;
	}

	private void FixedUpdate()
	{
		if (_isRunning)
		{
			_timer += Time.fixedDeltaTime;
			if (_timer >= 1f)
			{
				_timer -= 1f;
				MoveGarbage();
			}
		}
	}

	public void IsRunning(bool isRunning)
	{
		_isRunning = isRunning;
	}

	private void MoveGarbage()
	{
		Collider2D[] array = Physics2D.OverlapBoxAll(_center, _size, 0f);
		bool flag = false;
		Collider2D[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Garbage component = array2[i].gameObject.GetComponent<Garbage>();
			if (component != null && component.Info.IsGarbage)
			{
				flag = true;
				float num = 10f;
				if (IsRight)
				{
					component.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f - num, 0f));
				}
				else
				{
					component.GetComponent<Rigidbody2D>().AddForce(new Vector2(num, 0f));
				}
			}
		}
		if (flag)
		{
			TurnOnFan();
		}
		else
		{
			TurnOffFan();
		}
	}

	private void TurnOnFan()
	{
		FanAnimation.Play("TurnedOn");
	}

	private void TurnOffFan()
	{
		FanAnimation.Play("");
	}
}
