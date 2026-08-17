using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Overheal_IceBreath(ArcanaType type) : CharacterSkillCard_Base(type)
{
	private float overhealTriggerValue = 16f;

	private Timer overHealTimer;

	private bool canOverheal = true;

	private float overhealDelay = 1000f;

	public override void InitialActivate()
	{
		base.InitialActivate();
		CharacterController linkedCharacter = LinkedCharacter;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(linkedCharacter._onHpRecoveryCallback, b);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		linkedCharacter._onHpRecoveryCallback = (Action<float, float>)obj;
		canOverheal = true;
	}

	private void CharacterHealed(float value, float rawValue)
	{
		//IL_0246: Expected F4, but got O
		//IL_0209->IL024b: Incompatible stack heights: 1 vs 0
		//IL_022b->IL024b: Incompatible stack heights: 1 vs 0
		//IL_024b->IL027f: Incompatible stack heights: 1 vs 0
		float num = rawValue - value;
		if (num < overhealTriggerValue || !canOverheal)
		{
			return;
		}
		canOverheal = false;
		if (overHealTimer != null)
		{
			overHealTimer.Cancel();
		}
		Action onComplete = delegate
		{
			canOverheal = true;
		};
		float duration = overhealDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		overHealTimer = timer;
		if ((object)LinkedCharacter != null)
		{
			float2 position = LinkedCharacter.position;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((Delegate)(object)transform).method_ptr == (IntPtr)0;
						Transform.get_position_Injected(((Delegate)(object)transform).method_ptr, out Vector3 _);
						if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.SORBETTO))
						{
							Vector2 pos = default(Vector2);
							Pickup pickup = PickupManager.CreatePickup(pos, ItemType.SORBETTO);
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._gizmoManager != null)
						{
							float y = default(float);
							core2._gizmoManager.ShowHighlightAt((float)position, y);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CCharacterHealed_003Eb__6_0()
	{
		canOverheal = true;
	}
}
