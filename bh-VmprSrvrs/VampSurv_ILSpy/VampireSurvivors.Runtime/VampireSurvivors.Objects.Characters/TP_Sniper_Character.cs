using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class TP_Sniper_Character : TP_Character
{
	private Vector2 _whipOffset;

	private float _spriteWhipOffset;

	private SpriteRenderer _back2Sprite;

	private SpriteAnimation _back2Anim;

	private const string IdleAnimName = "idle";

	private const string SniperTextureName = "character_tp_sniper";

	public override float2 GetVectorWhipOffset
	{
		get
		{
			CheckRenderer();
			if ((object)((ArcadeSprite)this)._spriteRenderer != null)
			{
				Vector2 vector = ((ArcadeSprite)this)._spriteRenderer.size;
				bool flag = base.flipX;
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					Vector2 vector2 = ((ArcadeSprite)this)._spriteRenderer.size;
					float2 result = default(float2);
					return result;
				}
			}
			return (float2)new NullReferenceException();
		}
	}

	public override float GetSpriteWhipOffset => _spriteWhipOffset;

	public override bool NeedsCart => false;

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}

	protected override void OnStop()
	{
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_016a: Expected I4, but got O
		//IL_0259: Expected I4, but got O
		base.AfterFullInitialization();
		if ((object)((CharacterController)this)._spriteTrail != null)
		{
			((CharacterController)this)._spriteTrail.Reset();
			SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
			if ((object)((CharacterController)this)._spriteTrail != null)
			{
				spriteTrail._MaxHistory = 0;
				((CharacterController)this)._spriteTrail.InitialiseGhosts(expandExisting: true);
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					((ArcadeSprite)this)._spriteRenderer.enabled = false;
					float2 float5 = base.cachedPosition;
					GameObject gameObject = base.gameObject;
					Vector2 vector = default(Vector2);
					string text = default(string);
					SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "character_tp_sniper", text);
					((UnityEngine.Object)spriteRenderer).SetName("SniperAnim");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v28 (UnityEngine.SpriteRenderer)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v28 (UnityEngine.SpriteRenderer)+10]");
					Renderer.set_sortingOrder_Injected((IntPtr)0, 1);
					_back2Sprite = spriteRenderer;
					CheckRenderer();
					Transform parent = ((ArcadeSprite)this)._spriteRenderer.transform;
					Transform transform = _back2Sprite.transform;
					transform.SetParent(parent, worldPositionStays: true);
					Transform transform2 = _back2Sprite.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v39 (UnityEngine.Transform)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v39 (UnityEngine.Transform)+10]");
					Vector2 value = default(Vector2);
					Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
					List<Sprite> animation = SpriteManager.GetAnimation("TP_Sniper_i0", 1, 5, "character_tp_sniper", (byte)(int)text != 0);
					GameObject gameObject2 = _back2Sprite.gameObject;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdi_v13 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					bool flag3 = (object)gameObject2 == null;
					SpriteAnimation back2Anim = ((!gameObject2.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject2.AddComponent<SpriteAnimation>() : component);
					_back2Anim = back2Anim;
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					_back2Anim.AddAnimation("idle", animation, 12, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
					_back2Anim.SetAnimation("idle");
					SetCustomOutlineReferenceRenderer(_back2Sprite);
					_customDamageOverlayRenderer = _back2Sprite;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		if ((object)_back2Sprite != null)
		{
			bool flag = base.flipX;
			_back2Sprite.flipX = flag;
		}
	}
}
