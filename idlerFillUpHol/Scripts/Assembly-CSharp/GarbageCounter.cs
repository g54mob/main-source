using System;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCounter : MonoBehaviour
{
	private int _garbageLimit = 100;

	private int _garbageCount;

	private bool _isOverLimit;

	private const float TIMER_LENGTH = 1f;

	private Vector2 _center;

	private Vector2 _size;

	private float _timer;

	public List<GameObject> Exclamation;

	public bool ShowExclamation = true;

	public int GarbageCount => _garbageCount;

	public int GarbageLimit => _garbageLimit;

	public bool IsOverLimit => _isOverLimit;

	public event Action OverLimitChange;

	private void Start()
	{
		_center = (Vector2)base.transform.position + GetComponent<BoxCollider2D>().offset;
		_size = GetComponent<BoxCollider2D>().bounds.size;
		GetComponent<BoxCollider2D>().enabled = false;
		foreach (GameObject item in Exclamation)
		{
			item.SetActive(value: false);
		}
		_timer = 0f;
	}

	private void Update()
	{
		_timer += Time.deltaTime;
		if (_timer >= 1f)
		{
			GetNewCount();
			ValidateLimit();
			_timer -= 1f;
		}
	}

	public void ResetPosition()
	{
		_center = (Vector2)base.transform.position + GetComponent<BoxCollider2D>().offset;
	}

	public void ChangeGarbageLimit(int newLimit)
	{
		if (_garbageLimit != newLimit)
		{
			_garbageLimit = newLimit;
			ValidateLimit();
		}
	}

	private void GetNewCount()
	{
		int num = 0;
		Collider2D[] array = Physics2D.OverlapBoxAll(_center, _size, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			Garbage component = array[i].GetComponent<Garbage>();
			if (component != null)
			{
				num = ((component.Info.GarbageType != GarbageInfo.GarbageTypeEnum.GarbageM) ? ((component.Info.GarbageType != GarbageInfo.GarbageTypeEnum.GarbageL) ? ((component.Info.GarbageType != GarbageInfo.GarbageTypeEnum.GarbageXL) ? (num + 1) : (num + 8)) : (num + 4)) : (num + 2));
			}
		}
		_garbageCount = num;
	}

	private void ValidateLimit()
	{
		if (_garbageLimit <= 0)
		{
			if (_isOverLimit)
			{
				_isOverLimit = false;
				UpdateGraphics();
				this.OverLimitChange?.Invoke();
			}
		}
		else if (_isOverLimit && _garbageCount < _garbageLimit)
		{
			_isOverLimit = false;
			UpdateGraphics();
			this.OverLimitChange?.Invoke();
		}
		else if (!_isOverLimit && _garbageCount >= _garbageLimit)
		{
			_isOverLimit = true;
			UpdateGraphics();
			this.OverLimitChange?.Invoke();
		}
	}

	private void UpdateGraphics()
	{
		if (_isOverLimit && ShowExclamation)
		{
			foreach (GameObject item in Exclamation)
			{
				item.SetActive(value: true);
			}
			return;
		}
		foreach (GameObject item2 in Exclamation)
		{
			item2.SetActive(value: false);
		}
	}
}
