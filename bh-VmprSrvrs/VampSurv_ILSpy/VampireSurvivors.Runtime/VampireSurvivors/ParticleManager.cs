using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using Zenject;

namespace VampireSurvivors;

public class ParticleManager : IInitializable, IDisposable, ITickable
{
	private SignalBus _signalBus;

	private List<ParticleSystem> _registeredParticleSystems;

	private List<ParticleSystem> _pausedParticleSystems;

	private bool _wasPaused;

	private float _time;

	private int _shaderParam;

	private void UnpauseGame()
	{
		//IL_0087: Expected I4, but got O
		bool flag = _pausedParticleSystems == null;
		ParticleManager particleManager = this;
		if (!flag)
		{
			List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
			if (enumerator.MoveNext())
			{
				ParticleSystem particleSystem = null;
				throw new NullReferenceException();
			}
			particleManager = (ParticleManager)(object)_pausedParticleSystems;
			if (_pausedParticleSystems != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v3 (VampireSurvivors.ParticleManager)+1C]");
				_ = (nint)0 + (nint)1;
				particleManager._registeredParticleSystems = null;
				if ((nint)particleManager._registeredParticleSystems > 0)
				{
					Array.Clear((Array)(object)particleManager._signalBus, 0, (int)particleManager._registeredParticleSystems);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void PauseGame()
	{
		//IL_017c: Expected I4, but got O
		List<ParticleSystem> registeredParticleSystems = _registeredParticleSystems;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 >= registeredParticleSystems._size)
			{
				return;
			}
			List<ParticleSystem> registeredParticleSystems2 = _registeredParticleSystems;
			if (num >= registeredParticleSystems2._size)
			{
				break;
			}
			ParticleSystem[] items = registeredParticleSystems2._items;
			Component component = items[num];
			if ((object)items[num] != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = items[num].gameObject;
				if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject2 = items[num].gameObject;
					if (gameObject2.activeInHierarchy && items[num].isPlaying)
					{
						items[num].Pause();
						_pausedParticleSystems.RemoveAt((int)items[num]);
					}
					goto IL_0225;
				}
			}
			_registeredParticleSystems.RemoveAt(num);
			num--;
			goto IL_0225;
			IL_0225:
			registeredParticleSystems = _registeredParticleSystems;
			num++;
			num2 = num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void RegisterParticleSystem(ParticleSystem particleSystem)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004A40");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
		}
	}

	public void RegisterParticleSystem(ParticleSystem[] particleSystems)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj < particleSystems.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004A40");
			if (obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
			}
			obj2++;
			obj = obj2;
		}
	}

	public void Initialize()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F224]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int shaderParam = Shader.PropertyToID("_PauseTime");
		_shaderParam = shaderParam;
		Shader.EnableKeyword("_USEVSGAMETIME");
	}

	public void Dispose()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F225]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Shader.DisableKeyword("_USEVSGAMETIME");
	}

	public void Tick()
	{
		//IL_00d5: Expected F4, but got I
		if (!PauseSystem._paused)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float time = deltaTime + _time;
			_time = time;
			int shaderParam = _shaderParam;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AC9A]");
			Shader.SetGlobalFloatImpl(shaderParam, 0f);
		}
		if (PauseSystem._paused && !_wasPaused)
		{
			_wasPaused = true;
			PauseGame();
		}
		else if (!PauseSystem._paused && _wasPaused)
		{
			_wasPaused = false;
			UnpauseGame();
		}
	}

	public ParticleManager()
	{
		List<ParticleSystem> registeredParticleSystems = new List<ParticleSystem>();
		_registeredParticleSystems = registeredParticleSystems;
		List<ParticleSystem> pausedParticleSystems = new List<ParticleSystem>();
		_pausedParticleSystems = pausedParticleSystems;
	}
}
