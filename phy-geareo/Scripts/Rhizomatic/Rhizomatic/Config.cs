using System;
using UnityEngine;

namespace Rhizomatic
{
	public abstract class Config : MonoBehaviour
	{
		public virtual string type => null;

		public T CreateThing<T>(Context context = null) where T : Thing
		{
			return null;
		}

		public static T CreateThing<T>(Config config, Context context) where T : Thing
		{
			return null;
		}

		public static Thing CreateThing<T>(T config, Context context) where T : Config, IThingCreator
		{
			return null;
		}

		public static Thing CreateThing(Type type, Config config, Context context)
		{
			return null;
		}

		private static Thing _CreateThing(Thing thing, Config config, Context context)
		{
			return null;
		}
	}
}
