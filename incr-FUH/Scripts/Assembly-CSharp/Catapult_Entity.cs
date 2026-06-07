using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Catapult_Entity : MonoBehaviour
{
	public BuildingCustomOutput Output;

	public BuildingLevelInfo Info;

	public Catapult Parent;

	public bool IsCatapult;

	public float WaitingSpeed = 5.5f;

	public int DebugIndex;

	public List<GarbageInfo> _storedGarbage = new List<GarbageInfo>();

	private bool _isActive;

	private bool _isThrowing;

	private float _timer;

	public void Update()
	{
		if (_storedGarbage.Count > 0 && !_isThrowing)
		{
			_timer += Time.deltaTime;
			if (_timer >= WaitingSpeed)
			{
				_timer = 0f;
				ExecuteThrow();
			}
		}
	}

	public int AmountStored()
	{
		return _storedGarbage.Count;
	}

	public void AddGarbage(GarbageInfo g)
	{
		lock (_storedGarbage)
		{
			_storedGarbage.Add(g);
		}
	}

	public void ExecuteThrow()
	{
		if (GameController.Instance.IsHoleFilled())
		{
			return;
		}
		_isThrowing = true;
		if (IsCatapult)
		{
			base.transform.DORotate(new Vector3(0f, 0f, 25f), 0.5f).SetEase(Ease.Linear).OnComplete(delegate
			{
				base.transform.DORotate(new Vector3(0f, 0f, -25f), 0.1f).SetEase(Ease.Linear).OnComplete(delegate
				{
					Parent.ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_catapult, base.transform.position.x);
					ThrowGarbage(hasCloud: false);
					base.transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f).SetEase(Ease.Linear);
				});
			});
		}
		else
		{
			Parent.ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_cannon, base.transform.position.x);
			ThrowGarbage(Catapult.GlobalInfo.CanCannonCloudAttribute.IsEnabled);
		}
	}

	public void ThrowGarbage(bool hasCloud)
	{
		lock (_storedGarbage)
		{
			foreach (GarbageInfo item in _storedGarbage)
			{
				Garbage garbage = GameController.Instance.GarbageController.Generate(Vector3.zero, item);
				Output.StoreGarbage(garbage);
			}
			Parent.IncreaseExecutionStats(_storedGarbage.Count);
			_storedGarbage.Clear();
		}
		if (hasCloud)
		{
			Output.OutputGarbage(Parent.AddPowerMoreCloud(GameController.Instance.GetCloudChance()));
		}
		else
		{
			Output.OutputGarbage(0f);
		}
		_isThrowing = false;
	}

	public void SetActive()
	{
		if (!_isActive)
		{
			_isActive = true;
			_timer = 0f;
		}
	}

	public void SetInactive()
	{
		if (_isActive)
		{
			_isActive = false;
			_timer = 0f;
		}
	}
}
