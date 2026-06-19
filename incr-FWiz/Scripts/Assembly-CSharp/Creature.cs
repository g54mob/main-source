using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Creature : MonoBehaviour
{
	[SerializeField]
	private List<CreatureBehaviour> _creatureBehaviours;

	public CreatureSpawner CreatureSpawner { get; private set; }

	public event Action<Creature> AnnounceDestroy
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate(CreatureSpawner creatureSpawner)
	{
	}

	public virtual void Destroy()
	{
	}
}
