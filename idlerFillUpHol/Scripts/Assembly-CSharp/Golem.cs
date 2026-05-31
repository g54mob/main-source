using System.Collections;
using UnityEngine;

public class Golem : MonoBehaviour
{
	public LocalSfx2Controller LocalSfx2Controller;

	private bool _isUp;

	public bool IsMoving;

	public bool IsDestroyed;

	private Animator _animator;

	private float _walkingSpeed = 1f;

	public int _trashWeight;

	public int _trashSize;

	private float _nextColumnHit;

	private float _walkSfx;

	public const float GOLEM_HIT = 0.75f;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Start()
	{
		_nextColumnHit = FindNextColumn();
	}

	private void FixedUpdate()
	{
		if (!IsMoving)
		{
			return;
		}
		_walkSfx += Time.fixedDeltaTime;
		if (_walkSfx > 1f)
		{
			_walkSfx = 0f;
			LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.ga_golem_walk, base.transform.position.x);
		}
		base.transform.position += new Vector3(_walkingSpeed * Time.deltaTime, 0f, 0f);
		if (base.transform.position.x >= _nextColumnHit)
		{
			if (GameController.Instance.ColumnsController.CanGolemHit(base.transform.position.x))
			{
				DoHit();
			}
			_nextColumnHit += 7f;
		}
		if (base.transform.position.x >= GameController.Instance.ColumnsController.HoleColumn.transform.position.x)
		{
			Garbage g = GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, base.transform.position.y + 1f, 0f), GetValueAfterBoost(_trashWeight), GarbageInfo.GarbageTypeEnum.Golem, GarbageInfo.CameFromEnum.None, isEvil: false);
			GameController.Instance.ColumnsController.HoleColumn.DumpGarbage(g);
			DestroyGolem();
		}
	}

	private int GetValueAfterBoost(int amount)
	{
		amount += amount / 2;
		return amount;
	}

	public bool HadGolem()
	{
		if (IsMoving || IsDestroyed)
		{
			return true;
		}
		return false;
	}

	public void SetupFromLoad(bool isMoving, bool isDestroyed, float positionX)
	{
		IsMoving = isMoving;
		IsDestroyed = isDestroyed;
		base.transform.position = new Vector3(positionX, base.transform.position.y, base.transform.position.z);
		if (IsMoving)
		{
			StartMovement();
		}
		if (IsDestroyed)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public int GetSize()
	{
		return GetValueAfterBoost(_trashSize);
	}

	public void StartMovement()
	{
		if (!_isUp)
		{
			_animator.SetBool("IsBuild", value: true);
			_animator.SetBool("IsHit", value: false);
			_animator.SetBool("IsWalk", value: false);
			StartCoroutine(FinishBuilding());
		}
		else if (!IsMoving)
		{
			IsMoving = true;
			_animator.SetBool("IsBuild", value: true);
			_animator.SetBool("IsHit", value: false);
			_animator.SetBool("IsWalk", value: true);
			AchievementDefinition.ProcessWakeUpTheGolem(GameController.Instance.Achievements);
		}
	}

	public void DoHit()
	{
		if (IsMoving)
		{
			IsMoving = false;
			_animator.SetBool("IsBuild", value: false);
			_animator.SetBool("IsHit", value: true);
			_animator.SetBool("IsWalk", value: false);
			StartCoroutine(FinishHit());
		}
	}

	private IEnumerator FinishBuilding()
	{
		yield return new WaitForSeconds(0.5f);
		_isUp = true;
		StartMovement();
	}

	private IEnumerator FinishHit()
	{
		yield return new WaitForSeconds(0.5f);
		LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.ga_golem_hit, base.transform.position.x);
		GameController.Instance.ColumnsController.DoGolemHit(base.transform.position.x);
		IsMoving = true;
		_animator.SetBool("IsBuild", value: false);
		_animator.SetBool("IsHit", value: false);
		_animator.SetBool("IsWalk", value: true);
	}

	private void DestroyGolem()
	{
		IsMoving = false;
		IsDestroyed = true;
		base.gameObject.SetActive(value: false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Garbage component = collision.gameObject.GetComponent<Garbage>();
		if (component != null && component.Info.IsGarbage)
		{
			_trashWeight += component.Info.Weight;
			_trashSize += component.Info.GetSize();
			GameController.Instance.GarbageController.DestroyGarbage(component);
		}
	}

	private float FindNextColumn()
	{
		float num = 999f;
		foreach (ColumnController column in GameController.Instance.ColumnsController.GetColumns())
		{
			if (column.transform.position.x < num)
			{
				num = column.transform.position.x;
			}
		}
		for (int i = 0; i < 20; i++)
		{
			if (!(num - 7f >= base.transform.position.x))
			{
				break;
			}
			if (num - 7f - 1f < base.transform.position.x && num - 7f + 1f > base.transform.position.x)
			{
				break;
			}
			num -= 7f;
		}
		return num;
	}
}
