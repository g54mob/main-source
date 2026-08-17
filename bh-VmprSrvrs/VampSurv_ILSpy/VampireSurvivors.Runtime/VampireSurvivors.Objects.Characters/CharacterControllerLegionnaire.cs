using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerLegionnaire : CharacterController
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		HealthBar healthBar = RenderingExtensions.SetScale(base._healthBar, 0.00125f);
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne(dontGetCharacterDataForCurrentLevel);
		CheckRenderer();
		object spriteRenderer = ((ArcadeSprite)this)._spriteRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v2 (System.Object)+10]");
		Color value = default(Color);
		SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
		CheckRenderer();
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(((ArcadeSprite)this)._spriteRenderer, 0.65f);
	}

	public override void RestoreTint()
	{
		//IL_00de: Expected O, but got I
		SpriteRenderer customDamageOverlayRenderer = _customDamageOverlayRenderer;
		Renderer renderer = (((object)_customDamageOverlayRenderer == null || ((UnityEngine.Object)customDamageOverlayRenderer).m_CachedPtr == (IntPtr)0) ? _CharacterRenderer : _customDamageOverlayRenderer);
		if ((object)renderer != null)
		{
			renderer.Internal_GetPropertyBlock(_propBlock);
			RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: false);
			MaterialPropertyBlock propBlock = _propBlock;
			if (_propBlock != null)
			{
				bool flag = propBlock.m_Ptr == (IntPtr)0;
				Color value = default(Color);
				MaterialPropertyBlock.SetColorImpl_Injected(propBlock.m_Ptr, RenderingExtensions.TintFillColor, ref value);
				CheckRenderer();
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(((ArcadeSprite)this)._spriteRenderer, 0.65f);
				MaterialPropertyBlock propBlock2 = _propBlock;
				bool flag2 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
				if (_propBlock != null)
				{
					propBlock2 = (MaterialPropertyBlock)(nint)propBlock2.m_Ptr;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 217 ConditionalJump @-1, v356 @ ZF_v18 (System.Boolean) --- -1 Nop");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 286 ConditionalJump @-1, v448 @ ZF_v22 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}
		throw new NullReferenceException();
	}
}
