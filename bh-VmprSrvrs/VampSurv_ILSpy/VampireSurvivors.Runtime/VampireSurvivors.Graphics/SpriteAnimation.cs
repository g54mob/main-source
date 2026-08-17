using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Graphics;

public class SpriteAnimation : BaseSpriteAnimation
{
	private SpriteRenderer _spriteRenderer;

	private ArcadeSprite _arcadeSpriteToUpdate;

	private float2 _originalSpriteSize;

	protected override void Awake()
	{
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		_spriteRenderer = component;
		Transform transform = base.transform;
		Transform parent = transform.parent;
		if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
		{
			Transform transform2 = base.transform;
			Transform parent2 = transform2.parent;
			ArcadeSprite component2 = parent2.GetComponent<ArcadeSprite>();
			_arcadeSpriteToUpdate = component2;
		}
		base.Awake();
	}

	public void ForceInit()
	{
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		_spriteRenderer = component;
		Transform transform = base.transform;
		Transform parent = transform.parent;
		if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
		{
			Transform transform2 = base.transform;
			Transform parent2 = transform2.parent;
			ArcadeSprite component2 = parent2.GetComponent<ArcadeSprite>();
			_arcadeSpriteToUpdate = component2;
		}
	}

	protected override void ApplySpriteFrame(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874BE336h\"");
		if ((object)_originalSpriteSize == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874BE336h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.SpriteAnimation)+6C]");
			if ((nint)0 == 0)
			{
				ArcadeSprite arcadeSpriteToUpdate = _arcadeSpriteToUpdate;
				if ((object)_arcadeSpriteToUpdate != null)
				{
					BaseBody body = arcadeSpriteToUpdate.body;
					if (arcadeSpriteToUpdate.body != null && body._transform != null)
					{
						body._transform.OnSpriteChanged();
					}
				}
				return;
			}
		}
		ArcadeSprite arcadeSpriteToUpdate2 = _arcadeSpriteToUpdate;
		if ((object)_arcadeSpriteToUpdate != null)
		{
			BaseBody body2 = arcadeSpriteToUpdate2.body;
			if (arcadeSpriteToUpdate2.body != null && body2._transform != null)
			{
				float2 originalSize = default(float2);
				body2._transform.OnSpriteChanged(originalSize);
			}
		}
	}

	public void SetOriginalSpriteSize(float2 spriteSize)
	{
		_originalSpriteSize = spriteSize;
	}

	public void AddAnimation(string animName, SpriteAnimationData spriteAnimation, int fps, bool shouldLoop, bool startRandomFrame = false, Action onComplete = null, bool autoSetAnimation = true)
	{
		//IL_005a: Expected I4, but got O
		//IL_015e: Expected O, but got I4
		//IL_0112: Expected O, but got I
		//IL_0125: Expected O, but got I4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0150: Expected O, but got I
		int end = spriteAnimation.StartFrame >> 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(spriteAnimation.SpriteNameStart, (int)spriteAnimation.SpriteNameStart, end, spriteAnimation.Texture, num);
		bool startRandomFrame2 = default(bool);
		Action onComplete2 = default(Action);
		bool autoSetAnimation2 = default(bool);
		AddAnimation(animName, animationFrames, fps, (byte)num != 0, startRandomFrame2, onComplete2, autoSetAnimation2);
		if (base._currentAnimation != null)
		{
			Sprite frame = base._currentAnimation.GetFrame();
			string key = ((UnityEngine.Object)frame).GetName();
			if (SpriteOriginalSizes._originalSizesDict != null)
			{
				Dictionary<string, float2> originalSizesDict = SpriteOriginalSizes._originalSizesDict;
				int num2 = SpriteOriginalSizes._originalSizesDict.FindEntry(key);
				float2 originalSpriteSize;
				if (num2 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdi_v5 (System.Collections.Generic.Dictionary`2<System.String, Unity.Mathematics.float2>)+18]");
					object obj = 0;
					object obj2 = num2 + 2;
					object obj3 = obj2 * 2;
					object obj4 = obj2 + obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v22+v359 @ rax_v24*8]");
					originalSpriteSize = (float2)0;
				}
				else
				{
					originalSpriteSize = (float2)0;
				}
				_originalSpriteSize = originalSpriteSize;
				return;
			}
		}
		throw new NullReferenceException();
	}
}
