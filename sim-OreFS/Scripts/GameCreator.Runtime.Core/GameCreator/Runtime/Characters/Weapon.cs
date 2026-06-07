using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class Weapon
	{
		public int Id => Asset?.Id.Hash ?? IdString.EMPTY.Hash;

		[field: NonSerialized]
		public IWeapon Asset { get; }

		[field: NonSerialized]
		public GameObject Instance { get; }

		public Weapon(IWeapon weapon, GameObject instance)
		{
			Asset = weapon;
			Instance = instance;
		}
	}
}
