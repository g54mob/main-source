using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Projectiles;

public class SilverWind2Projectile : SilverWindProjectile
{
	[NonSerialized]
	private uint[] _colors = new uint[4] { 8978312u, 65280u, 16776960u, 65416u };

	[NonSerialized]
	private uint[] _tints = new uint[4] { 8978312u, 65280u, 16776960u, 65416u };

	[NonSerialized]
	private List<string> _particles;

	protected override uint[] Colors => _colors;

	protected override uint[] Tints => _tints;

	protected override List<string> Particles => _particles;

	protected override void OnHasHitAnObject(IDamageable target)
	{
		//IL_003d: Expected I, but got O
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_00d5: Expected O, but got I4
		//IL_0091: Expected O, but got I
		//IL_00c7: Expected O, but got I4
		//IL_0124: Invalid comparison between O and F4
		//IL_014a: Expected O, but got I
		//IL_0164: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)target;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v3 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v3 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v21+FFFFFFF8+v73 @ rax_v5*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj4 = 1;
				goto IL_01c4;
			}
		}
		obj4 = 0;
		goto IL_01c4;
		IL_01c4:
		bool flag = obj4 == null;
		IDamageable damageable = null;
		if (!flag)
		{
			damageable = target;
		}
		if (damageable == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rbx_v3 (VampireSurvivors.Interfaces.IDamageable)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		object obj5 = default(object);
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2f);
		bool flag3 = !flag2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rbx_v3 (VampireSurvivors.Interfaces.IDamageable)+214]");
		object obj6 = (nint)0 & (nint)(flag3 ? 1 : 0);
		bool flag4 = obj6 == null;
		object obj7 = !flag4;
		if (obj7 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rbx_v3 (VampireSurvivors.Interfaces.IDamageable)+1D4]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rbx_v3 (VampireSurvivors.Interfaces.IDamageable)+1D0]");
			if (num4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rbx_v3 (VampireSurvivors.Interfaces.IDamageable)+1D0]");
				float num5 = 0f + 0.02f;
			}
		}
	}

	public SilverWind2Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxHoly2.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxGreen.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_particles = list;
		base._002Ector();
	}
}
