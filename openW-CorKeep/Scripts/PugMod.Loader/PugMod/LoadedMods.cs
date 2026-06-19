using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugMod
{
	public class LoadedMods
	{
		private class ModContainer : IMod
		{
			private readonly List<IMod> _mods = new List<IMod>();

			private readonly List<bool> _modInitialized = new List<bool>();

			private bool _hasPrintedException;

			public IMod GetMod(int index)
			{
				if (index >= _mods.Count)
				{
					return null;
				}
				return _mods[index];
			}

			public int GetIndex(Type type)
			{
				for (int i = 0; i < _mods.Count; i++)
				{
					if (_mods[i].GetType() == type)
					{
						return i;
					}
				}
				return -1;
			}

			public void AddMod(IMod mod)
			{
				_mods.Add(mod);
				_modInitialized.Add(item: false);
			}

			public void RemoveMod(IMod mod)
			{
				int index = _mods.IndexOf(mod);
				_mods.RemoveAt(index);
				_modInitialized.RemoveAt(index);
			}

			public void EarlyInit()
			{
				throw new NotImplementedException();
			}

			public void Init()
			{
				for (int i = 0; i < _mods.Count; i++)
				{
					if (_modInitialized[i])
					{
						continue;
					}
					_modInitialized[i] = true;
					try
					{
						_mods[i].Init();
					}
					catch (Exception exception)
					{
						if (!_hasPrintedException)
						{
							_hasPrintedException = true;
							Debug.LogException(exception);
						}
					}
				}
			}

			public void Shutdown()
			{
				foreach (IMod mod in _mods)
				{
					try
					{
						mod.Shutdown();
					}
					catch (Exception exception)
					{
						if (!_hasPrintedException)
						{
							_hasPrintedException = true;
							Debug.LogException(exception);
						}
					}
				}
				_mods.Clear();
			}

			public bool CanBeUnloaded()
			{
				throw new NotImplementedException();
			}

			public void Update()
			{
				foreach (IMod mod in _mods)
				{
					try
					{
						mod.Update();
					}
					catch (Exception exception)
					{
						if (!_hasPrintedException)
						{
							_hasPrintedException = true;
							Debug.LogException(exception);
						}
					}
				}
			}

			public void ModObjectLoaded(UnityEngine.Object obj)
			{
				foreach (IMod mod in _mods)
				{
					try
					{
						mod.ModObjectLoaded(obj);
					}
					catch (Exception exception)
					{
						if (!_hasPrintedException)
						{
							_hasPrintedException = true;
							Debug.LogException(exception);
						}
					}
				}
			}
		}

		private ModContainer _modContainer = new ModContainer();

		public IMod Call => _modContainer;

		internal void Add(IMod mod)
		{
			_modContainer.AddMod(mod);
		}

		internal void Remove(IMod mod)
		{
			_modContainer.RemoveMod(mod);
		}

		internal IMod GetMod(int index)
		{
			return _modContainer.GetMod(index);
		}

		internal int GetIndex(Type type)
		{
			return _modContainer.GetIndex(type);
		}
	}
}
