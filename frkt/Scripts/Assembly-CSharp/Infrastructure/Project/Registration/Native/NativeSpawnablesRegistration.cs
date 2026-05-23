using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native
{
	public sealed class NativeSpawnablesRegistration : bgg, bgj
	{
		[field: SerializeField]
		public NativeWeaponsGroupHandler Weapons { get; private set; }

		[field: SerializeField]
		public NativeMiscGroupHandler Misc { get; private set; }

		protected override List<NativePrefabsGroupHandler> iso()
		{
			return null;
		}
	}
}
