using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_Survarot_Draft : NetworkPickup
{
	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("SVCard", 1, 4, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 12, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	private void OnRecycle()
	{
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("SVCard", 1, 4, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 12, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			bool flag = _taken;
			IntPtr intPtr = default(IntPtr);
			int cardsToShow = (int)(nint)intPtr;
			if (!flag)
			{
				((Pickup)this).GetTaken();
				_taken = true;
				cardsToShow = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rbx+0FCh]\"");
			GM.Core.QueueOpenSurvarots(cardsToShow, _targetPlayer);
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (body == null)
		{
			return;
		}
		BaseBody baseBody = body;
		if (!baseBody._enable || !_coherenceSync.HasStateAuthority)
		{
			return;
		}
		float2 float5 = SafeXY();
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187375651h\"");
		if ((object)float5 == (object)float6)
		{
			float2 float7 = base.position;
			object obj = default(object);
			bool flag = obj == obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187375651h\"");
			if (flag)
			{
				return;
			}
		}
		float2 float8 = default(float2);
		base.position = float8;
	}
}
