using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Particles;

public class GravityWell : GameMonoBehaviour
{
	private GravityWellConfig _config;

	private Transform _cachedTransform;

	private readonly List<ParticleSystem> _targets;

	private readonly List<ParticleSystem.Particle[]> _particlesCaches;

	private float _power;

	private float _epsilon;

	private float _gravity;

	private bool _requiresLateUpdate;

	public float Epsilon
	{
		get
		{
			//IL_000b: Invalid comparison between I4 and F4
			//IL_002f: Expected F4, but got I4
			if (!(0f > _epsilon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
				return 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			return _epsilon;
		}
		set
		{
			float epsilon = value * value;
			_epsilon = epsilon;
		}
	}

	public float Power
	{
		get
		{
			return _power / _gravity;
		}
		set
		{
			float power = value * _gravity;
			_power = power;
		}
	}

	public float Gravity
	{
		get
		{
			return _gravity;
		}
		set
		{
			float num = _power / _gravity;
			_gravity = value;
			float power = num * value;
			_power = power;
		}
	}

	private void Awake()
	{
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
	}

	protected override void OnUpdate()
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		if (_requiresLateUpdate || _targets == null)
		{
			return;
		}
		List<ParticleSystem> targets = _targets;
		if (targets._size == 0)
		{
			return;
		}
		ParticleSystem.Particle[] array = null;
		ParticleSystem.Particle[] cache = null;
		ParticleSystem.Particle[] array2 = null;
		List<ParticleSystem> list = targets;
		while (true)
		{
			if ((nint)array2 < list._size)
			{
				if ((nint)array >= targets._size)
				{
					break;
				}
				ParticleSystem[] items = targets._items;
				List<ParticleSystem.Particle[]> particlesCaches = _particlesCaches;
				if ((nint)array >= particlesCaches._size)
				{
					break;
				}
				ParticleSystem.Particle[][] items2 = particlesCaches._items;
				UpdateSystem(items[(object)array], ref cache);
				targets = _targets;
				array = (ParticleSystem.Particle[])(array + 1);
				cache = items2[(object)array];
				array2 = array;
				list = _targets;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void LateUpdate()
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		if (!_requiresLateUpdate || _targets == null)
		{
			return;
		}
		List<ParticleSystem> targets = _targets;
		if (targets._size == 0)
		{
			return;
		}
		ParticleSystem.Particle[] array = null;
		ParticleSystem.Particle[] cache = null;
		ParticleSystem.Particle[] array2 = null;
		List<ParticleSystem> list = targets;
		while (true)
		{
			if ((nint)array2 < list._size)
			{
				if ((nint)array >= targets._size)
				{
					break;
				}
				ParticleSystem[] items = targets._items;
				List<ParticleSystem.Particle[]> particlesCaches = _particlesCaches;
				if ((nint)array >= particlesCaches._size)
				{
					break;
				}
				ParticleSystem.Particle[][] items2 = particlesCaches._items;
				UpdateSystem(items[(object)array], ref cache);
				targets = _targets;
				array = (ParticleSystem.Particle[])(array + 1);
				cache = items2[(object)array];
				array2 = array;
				list = _targets;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Init(GravityWellConfig config)
	{
		//IL_0041: Expected F4, but got I4
		_config = config;
		float num;
		float num2;
		float num3;
		if (config == null)
		{
			num = 50f;
			num2 = 0f;
			num3 = 100f;
		}
		else
		{
			num2 = config._power;
			num3 = config._epsilon;
			num = config._gravity;
			_requiresLateUpdate = config.requiresLateUpdate;
		}
		_gravity = num;
		float power = num * num2;
		float epsilon = num3 * num3;
		_power = power;
		_epsilon = epsilon;
	}

	public void AddParticleSystem(ParticleSystem ps)
	{
		//IL_0121: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004A40");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
		List<object> particlesCaches = (List<object>)(object)_particlesCaches;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v322 @ rax_v12 (should have been resolved before IL gen)");
		object obj3 = default(object);
		ParticleSystem.Particle[] item = new ParticleSystem.Particle[obj3];
		int version = particlesCaches._version + 1;
		particlesCaches._version = version;
		object[] items = particlesCaches._items;
		if (particlesCaches._size >= items.Length)
		{
			particlesCaches.AddWithResize((object)item);
			return;
		}
		int size = particlesCaches._size + 1;
		particlesCaches._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemoveParticleSystem(ParticleSystem ps)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004A40");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)_targets).Remove((object)ps);
		}
	}

	public void Clear()
	{
		List<ParticleSystem> targets = _targets;
		int version = targets._version + 1;
		targets._version = version;
		targets._size = 0;
		if (targets._size > 0)
		{
			Array.Clear(targets._items, 0, targets._size);
		}
		List<ParticleSystem.Particle[]> particlesCaches = _particlesCaches;
		int version2 = particlesCaches._version + 1;
		particlesCaches._version = version2;
		particlesCaches._size = 0;
		if (particlesCaches._size > 0)
		{
			Array.Clear(particlesCaches._items, 0, particlesCaches._size);
		}
	}

	private unsafe void UpdateSystem(ParticleSystem system, ref ParticleSystem.Particle[] cache)
	{
		//IL_016a: Expected O, but got I
		//IL_009b: Expected I4, but got I8
		//IL_011e: Expected O, but got I
		ref ParticleSystem.Particle[] reference = default(ref ParticleSystem.Particle[]);
		bool flag = reference == null;
		ParticleSystem particleSystem2 = default(ParticleSystem);
		ParticleSystem particleSystem = particleSystem2;
		ref ParticleSystem.Particle[] reference2 = ref reference;
		if (!flag)
		{
			ParticleSystem.Particle[] array = reference;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v272 @ rax_v40 (should have been resolved before IL gen)");
			object obj2 = default(object);
			bool flag2 = array.Length >= (nint)obj2;
			particleSystem = particleSystem2;
			reference2 = ref reference;
			if (flag2)
			{
				goto IL_007f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v336 @ rax_v20 (should have been resolved before IL gen)");
		object obj4 = default(object);
		ParticleSystem.Particle[] array2 = new ParticleSystem.Particle[obj4];
		reference = ref *(ParticleSystem.Particle[]*)array2;
		goto IL_007f;
		IL_007f:
		int particles = particleSystem2.GetParticles(reference, -1, 0);
		bool flag3 = particles <= 0;
		int num = 0;
		if (!flag3)
		{
			do
			{
				UpdateParticle(num, reference);
				num++;
			}
			while (num < particles);
		}
		particleSystem2.SetParticles(reference, particles, 0);
	}

	private void UpdateParticle(int index, ParticleSystem.Particle[] cache)
	{
		//IL_0013: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_009c: Invalid comparison between I4 and F4
		//IL_0074: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_0325->IL0325: Incompatible stack heights: 1 vs 0
		//IL_0357->IL01c9: Incompatible stack heights: 1 vs 0
		if (cache != null)
		{
			object obj = index * 132;
			object obj2 = default(object);
			if (0 < (nint)obj2)
			{
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform == null)
				{
					goto IL_01c9;
				}
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
				Vector3 vector = ret;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+20+cache @ r8 (Particle[])]");
				object obj3 = vector - 0;
				float num = (float)obj3 * 100f;
				object obj5 = default(object);
				object obj4 = obj5 - obj2;
				float num2 = num * num;
				float num3 = (float)obj4 * 100f;
				float num4 = num3 * num3;
				float num5 = num4 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186B4FD4Eh\"");
				if (num5 == 0f)
				{
					object obj6 = index * 132;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+20+cache @ r8 (Particle[])]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+30+cache @ r8 (Particle[])]");
					_ = 0;
				}
				else
				{
					if (!(0f > num5))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm9,xmm6\"");
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
					}
					if (!(_epsilon < num5))
					{
						GravityWellConfig config = _config;
						if (_config == null)
						{
							goto IL_01c9;
						}
						if (config._usePauseSystem)
						{
							float deltaTime = PauseSystem.DeltaTime;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
						}
						object obj6 = index * 132;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+20+cache @ r8 (Particle[])]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+30+cache @ r8 (Particle[])]");
						_ = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+40+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+50+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+60+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+70+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+80+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+90+cache @ r8 (Particle[])]");
				_ = 0;
			}
			else
			{
				Debug.Log("Particle should be dead");
				object obj6 = index * 132;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+20+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+30+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+40+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+50+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+60+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+70+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+80+cache @ r8 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+90+cache @ r8 (Particle[])]");
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v9+A0+cache @ r8 (Particle[])]");
			_ = 0;
			return;
		}
		goto IL_01c9;
		IL_01c9:
		throw new NullReferenceException();
	}

	public GravityWell()
	{
		List<ParticleSystem> targets = new List<ParticleSystem>();
		_targets = targets;
		List<ParticleSystem.Particle[]> particlesCaches = new List<ParticleSystem.Particle[]>();
		_particlesCaches = particlesCaches;
		base._onResumeSent = true;
	}
}
