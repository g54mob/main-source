using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationGroup
{
	public enum GroupTypeEnum
	{
		None = 0,
		Repeat = 1,
		OneShot = 2
	}

	public string Name = "";

	public string GroupName = "";

	public bool IsDefault;

	public GroupTypeEnum GroupType;

	public List<Sprite> Sprite = new List<Sprite>();

	public int Speed = 1000;

	public int DelayMin;

	public int DelayMax;

	private static Dictionary<string, AnimationGroupInstance> StaticInstances = new Dictionary<string, AnimationGroupInstance>();

	private AnimationGroupInstance _instance;

	public void Reset()
	{
		if (GroupName != "")
		{
			lock (StaticInstances)
			{
				if (StaticInstances.ContainsKey(GroupName))
				{
					_instance = StaticInstances[GroupName];
				}
				else
				{
					_instance = new AnimationGroupInstance();
					_instance.Running = true;
					_instance.CurrentFrame = 0;
					_instance.LastTime = DateTime.Now;
					StaticInstances.Add(GroupName, _instance);
				}
			}
		}
		else
		{
			_instance = new AnimationGroupInstance();
			_instance.Running = true;
			_instance.CurrentFrame = 0;
			_instance.LastTime = DateTime.Now;
		}
		GetDelay();
	}

	public void UpdateFrame()
	{
		if (!_instance.Running)
		{
			return;
		}
		DateTime now = DateTime.Now;
		if (_instance.Delay > 0)
		{
			if ((now - _instance.LastTime).TotalMilliseconds > (double)_instance.Delay)
			{
				_instance.Delay = 0;
				_instance.CurrentFrame = 0;
				_instance.LastTime = now;
			}
			return;
		}
		int num = (int)((now - _instance.LastTime).TotalMilliseconds / (double)Speed);
		if (num <= 0)
		{
			return;
		}
		_instance.LastTime = now;
		_instance.CurrentFrame += num;
		if (_instance.CurrentFrame < Sprite.Count)
		{
			return;
		}
		if (GroupType == GroupTypeEnum.OneShot)
		{
			_instance.Running = false;
			return;
		}
		GetDelay();
		if (_instance.Delay == 0)
		{
			_instance.CurrentFrame %= Sprite.Count;
		}
		else
		{
			_instance.CurrentFrame = -1;
		}
	}

	public Sprite GetSprite()
	{
		if (!_instance.Running)
		{
			return null;
		}
		if (_instance.CurrentFrame == -1)
		{
			return null;
		}
		if (_instance.Delay > 0)
		{
			return null;
		}
		return Sprite[_instance.CurrentFrame];
	}

	public bool IsRunning()
	{
		return _instance.Running;
	}

	private void GetDelay()
	{
		if (DelayMin == 0 && DelayMax == 0)
		{
			_instance.Delay = 0;
		}
		else
		{
			_instance.Delay = UnityEngine.Random.Range(DelayMin, DelayMax);
		}
		if (_instance.Delay > 0)
		{
			_instance.CurrentFrame = -1;
		}
	}
}
