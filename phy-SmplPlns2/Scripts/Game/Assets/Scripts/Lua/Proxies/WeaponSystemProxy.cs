using Assets.Scripts.Flight.Combat;
using MoonSharp.Interpreter;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class WeaponSystemProxy
	{
		public int Ammo => WeaponSystem.Ammo;

		public string Name => WeaponSystem.WeaponPartName;

		public bool Selected => WeaponSystem.TargetingSystem.SelectedWeaponSystem == WeaponSystem;

		[MoonSharpHidden]
		public WeaponSystem WeaponSystem { get; }

		[MoonSharpHidden]
		public WeaponSystemProxy(WeaponSystem weaponSystem, ProxyFactory factory)
		{
			WeaponSystem = weaponSystem;
		}
	}
}
