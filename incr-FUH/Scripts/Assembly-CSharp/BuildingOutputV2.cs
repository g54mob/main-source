using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingOutputV2 : MonoBehaviour
{
	public BuildingOutputPartV2 CurrentPart;

	public Sprite ClosedSprite;

	private bool _isClosed;

	private bool _isThrowing;

	private bool _canClose;

	private bool _canThrow;

	private bool _canHaveDust = true;

	private List<Garbage> _storedGarbage = new List<Garbage>();

	private void Awake()
	{
	}

	public void SetCanHaveDust(bool canHaveDust)
	{
		if (_canHaveDust != canHaveDust)
		{
			_canHaveDust = canHaveDust;
		}
	}

	public virtual bool CanOutput()
	{
		return !_isClosed;
	}

	public virtual void SetCanClose(bool canClose)
	{
		if (_canClose != canClose)
		{
			_canClose = canClose;
			if (!_canClose)
			{
				UpdateCloseStatus(isClosed: false);
			}
		}
	}

	public void SetCanThrow(bool canThrow)
	{
		if (_canThrow != canThrow)
		{
			_canThrow = canThrow;
			if (!_canThrow)
			{
				_isThrowing = false;
			}
		}
	}

	public void SetIsThrowing(bool isThrowing)
	{
		if (_canThrow && _isThrowing != isThrowing)
		{
			_isThrowing = isThrowing;
		}
	}

	public void StoreGarbage(List<Garbage> garbages)
	{
		foreach (Garbage garbage in garbages)
		{
			StoreGarbage(garbage);
		}
	}

	public void StoreGarbage(Garbage garbage)
	{
		Vector3 vector = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
		garbage.transform.position = CurrentPart.OutputLocation.transform.position + vector;
		lock (_storedGarbage)
		{
			_storedGarbage.Add(garbage);
		}
	}

	public void StoreGarbage(int size, GarbageInfo.GarbageTypeEnum garbateType, GarbageInfo.CameFromEnum cameFrom, bool isEvil)
	{
		Vector3 vector = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
		Garbage garbage = GameController.Instance.GarbageController.Generate(CurrentPart.OutputLocation.transform.position + vector, size, garbateType, cameFrom, isEvil);
		StoreGarbage(garbage);
	}

	public void OutputGarbage(float dustPercentage)
	{
		StartCoroutine(PlayOutputGarbage(dustPercentage));
	}

	public void OutputDust(float dustPercentage)
	{
		if (CurrentPart.DustGenerator != null && dustPercentage > 0f && _canHaveDust)
		{
			CurrentPart.DustGenerator.Generate(Random.Range(0f, 1f) < dustPercentage);
		}
	}

	protected virtual Vector3 GetForce()
	{
		return Vector3.zero;
	}

	private IEnumerator PlayOutputGarbage(float dustPercentage)
	{
		lock (_storedGarbage)
		{
			if (_storedGarbage.Count == 0)
			{
				yield break;
			}
			if (CurrentPart.MainAnimation != null)
			{
				CurrentPart.MainAnimation.Play("Pump");
				yield return new WaitForSeconds(0.0033333334f);
			}
			foreach (Garbage item in _storedGarbage)
			{
				item.transform.parent = GameController.Instance.GarbageController.transform;
				if (_isThrowing)
				{
					item.ThrowToLocation(GameController.Instance.GetThrowLocation(item.transform.position, item));
				}
				else
				{
					item.GetComponent<Rigidbody2D>().AddForce(GetForce(), ForceMode2D.Impulse);
				}
			}
			if (CurrentPart.SmallDustParticle != null && _canHaveDust)
			{
				CurrentPart.SmallDustParticle.Play();
			}
			if (CurrentPart.DustGenerator != null && dustPercentage > 0f && _canHaveDust)
			{
				CurrentPart.DustGenerator.Generate(Random.Range(0f, 1f) < dustPercentage);
			}
			_storedGarbage.Clear();
		}
	}

	public void ProcessClick()
	{
		if (_canClose)
		{
			UpdateCloseStatus(!_isClosed);
		}
	}

	private void UpdateCloseStatus(bool isClosed)
	{
		if (isClosed != _isClosed)
		{
			_isClosed = isClosed;
			if (_isClosed)
			{
				CurrentPart.ChangeSprite(ClosedSprite);
			}
			else
			{
				CurrentPart.ChangeSprite(null);
			}
		}
	}
}
