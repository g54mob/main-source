using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using QFSW.MOP2;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects
{
	[UsedImplicitly]
	public class DestructibleManager : IInitializable, IDisposable
	{
		private static DestructibleFactory _factory;

		[Inject]
		private void Construct(DestructibleFactory factory)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static ObjectPool GetPool(PropType type)
		{
			return null;
		}

		public static List<Destructible> AllActiveDestructibles()
		{
			return null;
		}
	}
}
