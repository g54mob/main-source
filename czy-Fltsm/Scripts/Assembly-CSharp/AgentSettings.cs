using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/Agent Settings")]
public class AgentSettings : ScriptableObject
{
	[SerializeField]
	private ActorProperties[] _actors;

	[Header("Icons")]
	[Tooltip("Icon properties for a warning.")]
	public IconProperties WarningIconProperties;

	[Tooltip("Icon properties for not having a house.")]
	public IconProperties NoHousingIconProperties;

	public IconProperties IdlingIconProperties;

	[Space]
	public IconProperties SeagullIdleIconProperties;

	public IconProperties SeagullEatingIconProperties;

	public IconProperties SeagullSalvagingIconProperties;

	public IconProperties SeagullSleepingIconProperties;

	public IconProperties SeagullMovingIconProperties;

	public IconProperties SeagullHungryIconProperties;

	public IconProperties SeagullHappyIconProperties;

	public IconProperties SeagullNormalIconProperties;

	public IconProperties SeagullUnhappyIconProperties;

	[Space]
	public IconProperties DrifterMortalDangerIconProperties;

	public void Initialize()
	{
		ActorProperties[] actors = _actors;
		for (int i = 0; i < actors.Length; i++)
		{
			actors[i].Initialize();
		}
	}

	public T GetActorProperties<T>() where T : ActorProperties
	{
		T val = null;
		ActorProperties[] actors = _actors;
		for (int i = 0; i < actors.Length; i++)
		{
			val = actors[i] as T;
			if ((bool)val)
			{
				return val;
			}
		}
		Debug.LogException(new Exception("Unable to find ActorProperties of Type '" + typeof(T).Name + "'. Add an ActorProperties for this Type to AgentSettings!"));
		return null;
	}

	public bool TryGetActorProperties<T>(out T properties) where T : ActorProperties
	{
		ActorProperties[] actors = _actors;
		foreach (ActorProperties actorProperties in actors)
		{
			properties = actorProperties as T;
			if ((bool)properties)
			{
				return true;
			}
		}
		properties = null;
		return false;
	}

	public bool TryGetActorProperties<T>(out T properties, ActorType actorType) where T : ActorProperties
	{
		int num = _actors.Length;
		while (0 < num--)
		{
			properties = _actors[num] as T;
			if ((bool)properties && properties.ActorType == actorType)
			{
				return true;
			}
		}
		properties = null;
		return false;
	}
}
