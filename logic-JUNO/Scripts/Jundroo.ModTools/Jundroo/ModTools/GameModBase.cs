using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.ModTools
{
	public abstract class GameModBase
	{
		private static Dictionary<Type, GameModBase> _instances = new Dictionary<Type, GameModBase>();

		private bool _initialized;

		public ILoadedMod Mod { get; private set; }

		public ModInfo ModInfo { get; private set; }

		public IModResourceLoader ResourceLoader { get; private set; }

		public void Initialize(ILoadedMod mod)
		{
			if (_initialized)
			{
				Debug.LogError("Attempted to initialize mod '" + (ModInfo?.Name ?? string.Empty) + "' after it had already been initialized.");
				return;
			}
			Mod = mod;
			ModInfo = mod.ModInfo;
			ResourceLoader = mod.ResourceLoader;
			Type type = GetType();
			if (!_instances.ContainsKey(type))
			{
				Debug.LogError("Game mod object of type '" + type.FullName + "' is being initialized an instance of it could not be found in the dictionary.");
			}
			OnModInitialized();
			_initialized = true;
		}

		public virtual void OnModLoaded()
		{
		}

		protected internal static T GetModInstance<T>() where T : GameModBase
		{
			return (T)GetModInstance(typeof(T));
		}

		protected internal static GameModBase GetModInstance(Type type)
		{
			if (_instances.TryGetValue(type, out var value))
			{
				return value;
			}
			return _instances[type] = (GameModBase)Activator.CreateInstance(type, nonPublic: true);
		}

		protected virtual void OnModInitialized()
		{
		}
	}
}
