using DG.Tweening;
using UnityEngine;

public class Helicopter_Entity : MonoBehaviour
{
	public enum StateEnum
	{
		Idle = 0,
		Coming = 1,
		Dumping = 2,
		Parting = 3
	}

	public Helicopter Parent;

	private Vector3 _originalLocation;

	private bool _isActive;

	public GarbageCounter GarbageCount;

	private StateEnum _state;

	private float _movingTime;

	private float _dumpingTimer;

	private int _totalDump;

	private bool _isDumpSpecial;

	private bool _alphaFlag;

	private void Start()
	{
		_originalLocation = base.transform.position;
	}

	private void FixedUpdate()
	{
		if (!_isActive || GameController.Instance.IsHoleFilled())
		{
			return;
		}
		if (_state == StateEnum.Parting)
		{
			GarbageCount.ShowExclamation = false;
			if (base.transform.position.y < 8f)
			{
				base.transform.position += new Vector3(0f, GetSpeed() * Time.fixedDeltaTime, 0f);
				return;
			}
			GetComponent<SpriteRenderer>().flipX = true;
			base.transform.position += new Vector3((0f - GetSpeed()) * Time.fixedDeltaTime, 0f, 0f);
			_movingTime += Time.fixedDeltaTime;
			if (_movingTime >= 5f && !_alphaFlag)
			{
				_alphaFlag = true;
				GetComponent<SpriteRenderer>().DOFade(0f, 5f);
			}
			if (_movingTime >= 15f)
			{
				_state = StateEnum.Coming;
				GetComponent<SpriteRenderer>().DOFade(1f, 5f);
				SpriteRenderer component = GetComponent<SpriteRenderer>();
				component.color = new Color(component.color.r, component.color.g, component.color.b, 1f);
			}
		}
		else if (_state == StateEnum.Coming)
		{
			GarbageCount.ShowExclamation = false;
			_alphaFlag = false;
			GetComponent<SpriteRenderer>().flipX = false;
			base.transform.position += new Vector3(GetSpeed() * Time.fixedDeltaTime, 0f, 0f);
			float num = _originalLocation.x;
			if (num > GameController.Instance.HoleFarLocation.transform.position.x)
			{
				num = GameController.Instance.HoleFarLocation.transform.position.x;
			}
			if (Parent.HasDropNextColumnAttribute.IsEnabled)
			{
				num += 7f * (float)Parent.HasDropNextColumnAttribute.Level;
			}
			if (base.transform.position.x >= num)
			{
				_state = StateEnum.Dumping;
				_dumpingTimer = 0f;
				_totalDump = 0;
				if (Parent.MiniGame.IsSuccess)
				{
					_isDumpSpecial = true;
					Parent.MiniGame.SuccessCount--;
				}
				else
				{
					_isDumpSpecial = false;
				}
				GarbageCount.ResetPosition();
			}
		}
		else
		{
			if (_state != StateEnum.Dumping)
			{
				return;
			}
			GarbageCount.ShowExclamation = true;
			_dumpingTimer += Time.fixedDeltaTime;
			if (_dumpingTimer >= 0.1f)
			{
				_dumpingTimer = 0f;
				if (!GarbageCount.IsOverLimit)
				{
					int helicopterGarbageSize = Parent.GetHelicopterGarbageSize();
					if (Helicopter.GlobalInfo.CanOutputLessButMediumAttribute.IsEnabled)
					{
						Parent.ParentColumn.LocalSfx2Controller.PlayOneFromDistance(SoundManager.SoundTypeEnum.bs_helicopter_drop, base.transform.position.x);
						GameController.Instance.GarbageController.Generate(base.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f), helicopterGarbageSize, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Helicopter, _isDumpSpecial);
					}
					else
					{
						Parent.ParentColumn.LocalSfx2Controller.PlayOneFromDistance(SoundManager.SoundTypeEnum.bs_helicopter_drop, base.transform.position.x);
						GameController.Instance.GarbageController.Generate(base.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f), helicopterGarbageSize, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Helicopter, _isDumpSpecial);
					}
					_totalDump++;
				}
			}
			if (_totalDump >= GetAmountToDump())
			{
				_isDumpSpecial = false;
				_state = StateEnum.Parting;
				_movingTime = 0f;
			}
		}
	}

	private float GetSpeed()
	{
		return 1f;
	}

	private int GetAmountToDump()
	{
		int num = Parent.GetHelicopterDropAmount();
		if (_isDumpSpecial)
		{
			num *= 2;
		}
		return num;
	}

	public void SetActive()
	{
		if (!_isActive)
		{
			_isActive = true;
			_state = StateEnum.Parting;
			_movingTime = 0f;
			_alphaFlag = false;
		}
	}

	public void SetInactive()
	{
		if (_isActive)
		{
			_isActive = false;
			base.transform.position = _originalLocation;
			_state = StateEnum.Idle;
			_alphaFlag = false;
		}
	}
}
