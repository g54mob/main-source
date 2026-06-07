using UnityEngine;

public class FanGroup : MonoBehaviour
{
	public GameObject FanLeft;

	public GameObject FanRight;

	private AnimationSprite _leftAnimation;

	private AnimationSprite _rightAnimation;

	public CharDisplay FanPeon;

	private bool _isRunning;

	private bool _isLeftVisible;

	private bool _isRightVisible;

	private Vector2 _leftCenter;

	private Vector2 _leftSize;

	private Vector2 _rightCenter;

	private Vector2 _rightSize;

	private float _timer;

	private void Start()
	{
		_leftCenter = FanLeft.GetComponent<BoxCollider2D>().offset;
		_leftSize = FanLeft.GetComponent<BoxCollider2D>().bounds.size;
		_leftCenter += new Vector2(FanLeft.transform.position.x, FanLeft.transform.position.y);
		_rightCenter = FanRight.GetComponent<BoxCollider2D>().offset;
		_rightSize = FanRight.GetComponent<BoxCollider2D>().bounds.size;
		_rightCenter += new Vector2(FanRight.transform.position.x, FanRight.transform.position.y);
		FanLeft.GetComponent<BoxCollider2D>().enabled = false;
		FanRight.GetComponent<BoxCollider2D>().enabled = false;
		_leftAnimation = FanLeft.GetComponent<AnimationSprite>();
		_rightAnimation = FanRight.GetComponent<AnimationSprite>();
		_isRunning = true;
		_isLeftVisible = true;
		_isRightVisible = true;
		SetStatus(isLeftVisible: false, isRightVisible: false, isRunning: false);
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

	private void MoveGarbage()
	{
		Collider2D[] array2;
		if (_isLeftVisible)
		{
			Collider2D[] array = Physics2D.OverlapBoxAll(_leftCenter, _leftSize, 0f);
			bool flag = false;
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Garbage component = array2[i].gameObject.GetComponent<Garbage>();
				if (component != null && component.Info.IsGarbage)
				{
					flag = true;
					component.SetAsDynamic();
					component.GetComponent<Rigidbody2D>().AddForce(new Vector2(GetForce(), 0f));
				}
			}
			if (flag)
			{
				_leftAnimation.Play("TurnedOn");
			}
			else
			{
				_leftAnimation.Play("");
			}
		}
		if (!_isRightVisible)
		{
			return;
		}
		Collider2D[] array3 = Physics2D.OverlapBoxAll(_rightCenter, _rightSize, 0f);
		bool flag2 = false;
		array2 = array3;
		for (int i = 0; i < array2.Length; i++)
		{
			Garbage component2 = array2[i].gameObject.GetComponent<Garbage>();
			if (component2 != null && component2.Info.IsGarbage)
			{
				flag2 = true;
				component2.SetAsDynamic();
				component2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f - GetForce(), 0f));
			}
		}
		if (flag2)
		{
			_rightAnimation.Play("TurnedOn");
		}
		else
		{
			_rightAnimation.Play("");
		}
	}

	private float GetForce()
	{
		return 50f;
	}

	public void Initialize(BaseBuilding building)
	{
	}

	public void SetStatus(bool isLeftVisible, bool isRightVisible, bool isRunning)
	{
		SetLeftVisibility(isLeftVisible);
		SetRightVisibility(isRightVisible);
		SetRunning(isRunning);
	}

	public void SetLeftVisibility(bool isVisible)
	{
		if (isVisible != _isLeftVisible)
		{
			_isLeftVisible = isVisible;
			FanLeft.SetActive(_isLeftVisible);
			FanPeon.gameObject.SetActive((_isLeftVisible || _isRightVisible) && _isRunning);
		}
	}

	public void SetRightVisibility(bool isVisible)
	{
		if (isVisible != _isRightVisible)
		{
			_isRightVisible = isVisible;
			FanRight.SetActive(_isRightVisible);
			FanPeon.gameObject.SetActive((_isLeftVisible || _isRightVisible) && _isRunning);
		}
	}

	public bool SetRunning(bool isRunning)
	{
		if (isRunning != _isRunning)
		{
			_isRunning = isRunning;
			FanPeon.gameObject.SetActive((_isLeftVisible || _isRightVisible) && _isRunning);
			if (!_isRunning)
			{
				_leftAnimation.Play("");
				_rightAnimation.Play("");
			}
			return true;
		}
		return false;
	}
}
