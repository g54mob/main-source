using System;
using QFSW.MOP2;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects.VFX;

public class HeroVfxManager : IInitializable, IDisposable
{
	private static HeroVfxFactory _factory;

	private void Construct(HeroVfxFactory factory)
	{
		_factory = factory;
	}

	public void Initialize()
	{
		_factory.InitPools();
	}

	public void Dispose()
	{
		_factory.PurgePools();
	}

	public static ObjectPool GetPool(HeroVfxType type)
	{
		if ((object)_factory != null)
		{
			return _factory.GetPool(type);
		}
		return (ObjectPool)(object)new NullReferenceException();
	}
}
