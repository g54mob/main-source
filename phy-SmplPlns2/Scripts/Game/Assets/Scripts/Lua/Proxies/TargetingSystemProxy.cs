using System;
using Assets.Scripts.Flight.Combat;
using MoonSharp.Interpreter;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class TargetingSystemProxy
	{
		private ProxyFactory _factory;

		private TargetingSystem _targetingSystem;

		public int CountermeasureAmmo => _targetingSystem.CountermeasureAmmo;

		public TargetingSystemMode Mode
		{
			get
			{
				return (TargetingSystemMode)_targetingSystem.Mode;
			}
			set
			{
				_targetingSystem.Mode = (TargetingSystem.TargetingSystemMode)value;
			}
		}

		public WeaponSystemProxy SelectedWeapon => _factory.GetOrCreateProxy<WeaponSystemProxy>(_targetingSystem.SelectedWeaponSystem);

		public TargetProxy Target => _factory.GetOrCreateProxy<TargetProxy>(_targetingSystem.CurrentTrackedTarget);

		public bool TgpActive => _targetingSystem.TargetingPod?.IsActive ?? false;

		public float TgpDistance => (_targetingSystem.TargetingPod?.TrackedTarget?.Distance).GetValueOrDefault();

		public event EventHandler WeaponListUpdated;

		[MoonSharpHidden]
		public TargetingSystemProxy(TargetingSystem targetingSystem, ProxyFactory factory)
		{
			_factory = factory;
			_targetingSystem = targetingSystem;
			_targetingSystem.WeaponsListUpdated += OnWeaponListUpdated;
		}

		public WeaponSystemProxy GetWeaponSystem(int index)
		{
			int num = index - 1;
			if (num < _targetingSystem?.WeaponSystemsMode.Count)
			{
				return _factory.GetOrCreateProxy<WeaponSystemProxy>(_targetingSystem.WeaponSystemsMode[num]);
			}
			return null;
		}

		public void NextTarget()
		{
			_targetingSystem.NextTarget();
		}

		public void PreviousTarget()
		{
			_targetingSystem.PreviousTarget();
		}

		public void SelectWeapon(int index)
		{
			WeaponSystemProxy weaponSystem = GetWeaponSystem(index);
			_targetingSystem.SelectWeaponSystem(weaponSystem?.WeaponSystem);
		}

		private void OnWeaponListUpdated()
		{
			this.WeaponListUpdated?.Invoke(this, EventArgs.Empty);
		}
	}
}
