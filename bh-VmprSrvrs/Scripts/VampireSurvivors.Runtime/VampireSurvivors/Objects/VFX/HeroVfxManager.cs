using System;
using JetBrains.Annotations;
using QFSW.MOP2;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects.VFX
{
	[UsedImplicitly]
	public class HeroVfxManager : IInitializable, IDisposable
	{
		private static HeroVfxFactory _factory;

		[Inject]
		private void Construct(HeroVfxFactory factory)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static ObjectPool GetPool(HeroVfxType type)
		{
			return null;
		}
	}
}
