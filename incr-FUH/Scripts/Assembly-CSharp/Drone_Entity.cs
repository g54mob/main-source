using UnityEngine;

public class Drone_Entity : MonoBehaviour
{
	private enum StateEnum
	{
		Idle = 0,
		Exit = 1,
		MoveUp = 2,
		MoveRight = 3,
		MoveLeft = 4
	}

	public Drone Parent;

	public ParticleSystem Particle;

	private Vector3 _originalPosition;

	public Sprite SmallDroneSprite;

	public Sprite BigDroneSprite;

	private StateEnum _state;

	private float _timer;

	private Vector2 _center;

	private Vector2 _size;

	private bool _isSmall = true;

	private void Awake()
	{
		_originalPosition = base.transform.localPosition;
	}

	private void Start()
	{
		_center = GetComponent<BoxCollider2D>().offset;
		_size = GetComponent<BoxCollider2D>().bounds.size;
		GetComponent<BoxCollider2D>().enabled = false;
	}

	private void Update()
	{
		if (Drone.GlobalInfo.CanStrongerParticleAttribute.Level > 0 && _isSmall)
		{
			_isSmall = true;
			GetComponent<SpriteRenderer>().sprite = BigDroneSprite;
		}
	}

	private void FixedUpdate()
	{
		if (GameController.Instance.IsHoleFilled())
		{
			return;
		}
		_timer += Time.fixedDeltaTime;
		if (_timer >= 0.2f)
		{
			_timer -= 0.2f;
			if (!GameController.Instance.GarbageController.HasALotOnScreen() && (_state == StateEnum.MoveRight || (_state == StateEnum.MoveLeft && Drone.GlobalInfo.CanBothSideAttribute.IsEnabled)))
			{
				Collider2D[] array = Physics2D.OverlapBoxAll((Vector2)base.transform.position + _center, _size, 0f);
				int particlesCount = Drone.GlobalInfo.GetParticlesCount();
				int particlesStrength = Drone.GlobalInfo.GetParticlesStrength();
				int num = 0;
				Collider2D[] array2 = array;
				foreach (Collider2D collider2D in array2)
				{
					if (collider2D.GetComponent<Cloud>() != null)
					{
						collider2D.GetComponent<Cloud>().HandleParticles(particlesStrength, 1 + Drone.GlobalInfo.StabilityLevel);
						num++;
					}
					if (num >= particlesCount)
					{
						break;
					}
				}
			}
		}
		switch (_state)
		{
		case StateEnum.Exit:
			base.transform.position += new Vector3(GetSpeed() * Time.fixedDeltaTime, 0f, 0f);
			if (base.transform.localPosition.x >= 2.5f)
			{
				_state = StateEnum.MoveUp;
			}
			break;
		case StateEnum.MoveUp:
			if (base.transform.position.y < 9f)
			{
				base.transform.position += new Vector3(0f, GetSpeed() * Time.fixedDeltaTime, 0f);
				break;
			}
			Particle.gameObject.SetActive(value: true);
			_state = StateEnum.MoveRight;
			break;
		case StateEnum.MoveRight:
			base.transform.position += new Vector3(GetSpeed() * Time.fixedDeltaTime, 0f, 0f);
			if (base.transform.position.x >= GameController.Instance.HoleFarLocation.transform.position.x)
			{
				if (Drone.GlobalInfo.CanBothSideAttribute.IsEnabled)
				{
					Particle.gameObject.SetActive(value: true);
				}
				else
				{
					Particle.gameObject.SetActive(value: false);
				}
				_state = StateEnum.MoveLeft;
			}
			break;
		case StateEnum.MoveLeft:
			base.transform.position += new Vector3((0f - GetSpeed()) * Time.fixedDeltaTime, 0f, 0f);
			if (base.transform.localPosition.x <= _originalPosition.x)
			{
				Particle.gameObject.SetActive(value: true);
				_state = StateEnum.MoveRight;
			}
			break;
		}
	}

	private float GetSpeed()
	{
		return 1f;
	}

	public void SetActive()
	{
		if (_state == StateEnum.Idle)
		{
			base.transform.localPosition = _originalPosition;
			_state = StateEnum.Exit;
			Particle.gameObject.SetActive(value: false);
		}
	}

	public void SetInactive()
	{
		base.transform.localPosition = _originalPosition;
		_state = StateEnum.Idle;
		Particle.gameObject.SetActive(value: false);
	}
}
