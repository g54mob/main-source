using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Graphics;

public class SpriteScroller : GameMonoBehaviour
{
	private float _ScrollSpeedX;

	private float _ScrollSpeedY;

	private float _ScrollOffsetX;

	private float _ScrollOffsetY;

	private float _TextureOffsetX;

	private float _TextureOffsetY;

	private SpriteRenderer _spriteRenderer;

	private float _prevScrollSpeedX;

	private float _prevScrollSpeedY;

	private float _spriteWidthUnits;

	private float _spriteHeightUnits;

	private float _textureWidthUnits;

	private float _textureHeightUnits;

	public SpriteRenderer Renderer => _spriteRenderer;

	private void Awake()
	{
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		_spriteRenderer = component;
	}

	private unsafe void Start()
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Ref, but got Unknown
		//IL_00d8: Expected I8, but got I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Ref, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected Ref, but got Unknown
		//IL_01dd: Expected I8, but got I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Ref, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected Ref, but got Unknown
		//IL_02e2: Expected I8, but got I4
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected Ref, but got Unknown
		Material material = ((Renderer)_spriteRenderer).GetMaterial();
		string text = ((UnityEngine.Object)material).GetName();
		object obj = "ScrollableSprite (Instance)";
		if ((object)text != "ScrollableSprite (Instance)")
		{
			if (text != null && "ScrollableSprite (Instance)" != null)
			{
				int stringLength = text._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rdx_v4+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(text + 20);
					ulong length = (ulong)(text._stringLength + text._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("ScrollableSprite (Instance)" + 20), length))
					{
						goto IL_0383;
					}
				}
			}
			Material material2 = ((Renderer)_spriteRenderer).GetMaterial();
			string text2 = ((UnityEngine.Object)material2).GetName();
			object obj2 = "ScrollableSpriteAdditive (Instance)";
			if ((object)text2 != "ScrollableSpriteAdditive (Instance)")
			{
				if (text2 != null && "ScrollableSpriteAdditive (Instance)" != null)
				{
					int stringLength2 = text2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdx_v16+10]");
					if ((nint)stringLength2 == 0)
					{
						ref byte first2 = ref *(byte*)(text2 + 20);
						ulong length2 = (ulong)(text2._stringLength + text2._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("ScrollableSpriteAdditive (Instance)" + 20), length2))
						{
							goto IL_0383;
						}
					}
				}
				Material material3 = ((Renderer)_spriteRenderer).GetMaterial();
				string text3 = ((UnityEngine.Object)material3).GetName();
				object obj3 = "ScrollableSpriteLit (Instance)";
				if ((object)text3 != "ScrollableSpriteLit (Instance)")
				{
					if (text3 != null && "ScrollableSpriteLit (Instance)" != null)
					{
						int stringLength3 = text3._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rdx_v20+10]");
						if ((nint)stringLength3 == 0)
						{
							ref byte first3 = ref *(byte*)(text3 + 20);
							ulong length3 = (ulong)(text3._stringLength + text3._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("ScrollableSpriteLit (Instance)" + 20), length3))
							{
								goto IL_0383;
							}
						}
					}
					Material material4 = ((Renderer)_spriteRenderer).GetMaterial();
					string text4 = ((UnityEngine.Object)material4).GetName();
					string message = "NAME: " + text4;
					Debug.Log(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					object message2 = default(object);
					Debug.LogError(message2);
					base.enabled = false;
					return;
				}
			}
		}
		goto IL_0383;
		IL_0383:
		SpriteUpdated();
		SetScrollSpeedX(_ScrollSpeedX);
		SetScrollSpeedY(_ScrollSpeedY);
		SetScrollOffsetX(_ScrollOffsetX);
		SetScrollOffsetY(_ScrollOffsetY);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D00]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_TextureOffsetX = _TextureOffsetX;
		Material material5 = ((Renderer)_spriteRenderer).GetMaterial();
		int num = Shader.PropertyToID("_TextureOffsetX");
		float value = _TextureOffsetX / _textureWidthUnits;
		material5.SetFloatImpl(num, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D01]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_TextureOffsetY = _TextureOffsetY;
		Material material6 = ((Renderer)_spriteRenderer).GetMaterial();
		int num2 = Shader.PropertyToID("_TextureOffsetY");
		float value2 = _TextureOffsetY / _textureHeightUnits;
		material6.SetFloatImpl(num2, value2);
	}

	protected override void OnPause()
	{
		_prevScrollSpeedX = _ScrollSpeedX;
		_prevScrollSpeedY = _ScrollSpeedY;
		SetScrollSpeedX(0f);
		SetScrollSpeedY(0f);
	}

	protected override void OnResume()
	{
		SetScrollSpeedX(_prevScrollSpeedX);
		SetScrollSpeedY(_prevScrollSpeedY);
		_prevScrollSpeedX = 0f;
	}

	public void SetScrollSpeedX(float speed)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CFC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_ScrollSpeedX = speed;
		Material material = ((Renderer)_spriteRenderer).GetMaterial();
		int num = Shader.PropertyToID("_ScrollSpeedX");
		material.SetFloatImpl(num, _ScrollSpeedX);
	}

	public void SetScrollSpeedY(float speed)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CFD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_ScrollSpeedY = speed;
		Material material = ((Renderer)_spriteRenderer).GetMaterial();
		int num = Shader.PropertyToID("_ScrollSpeedY");
		material.SetFloatImpl(num, _ScrollSpeedY);
	}

	public void SetScrollOffsetX(float offset)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CFE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_ScrollOffsetX = offset;
		Material material = ((Renderer)_spriteRenderer).GetMaterial();
		int num = Shader.PropertyToID("_ScrollOffsetX");
		float value = offset / _spriteWidthUnits;
		material.SetFloatImpl(num, value);
	}

	public void SetScrollOffsetY(float offset)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CFF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_ScrollOffsetY = offset;
		Material material = ((Renderer)_spriteRenderer).GetMaterial();
		int num = Shader.PropertyToID("_ScrollOffsetY");
		float value = offset / _spriteHeightUnits;
		material.SetFloatImpl(num, value);
	}

	public void SetTextureOffsetX(float offset)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D00]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_TextureOffsetX = offset;
		Material material = ((Renderer)_spriteRenderer).GetMaterial();
		int num = Shader.PropertyToID("_TextureOffsetX");
		float value = offset / _textureWidthUnits;
		material.SetFloatImpl(num, value);
	}

	public void SetTextureOffsetY(float offset)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D01]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_TextureOffsetY = offset;
		Material material = ((Renderer)_spriteRenderer).GetMaterial();
		int num = Shader.PropertyToID("_TextureOffsetY");
		float value = offset / _textureHeightUnits;
		material.SetFloatImpl(num, value);
	}

	public unsafe void SpriteUpdated()
	{
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_0190: Expected O, but got I
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		//IL_02e1: Expected O, but got I
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected O, but got Unknown
		//IL_05d2: Expected O, but got I
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Expected O, but got Unknown
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_0668: Expected O, but got I
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Expected O, but got Unknown
		//IL_0422->IL0393: Incompatible stack heights: 1 vs 0
		//IL_00d0->IL0393: Incompatible stack heights: 1 vs 0
		//IL_0117->IL0393: Incompatible stack heights: 1 vs 0
		//IL_0490->IL0393: Incompatible stack heights: 2 vs 0
		//IL_016e->IL0393: Incompatible stack heights: 2 vs 0
		//IL_01ca->IL0393: Incompatible stack heights: 2 vs 0
		//IL_04fe->IL0393: Incompatible stack heights: 3 vs 0
		//IL_0221->IL0393: Incompatible stack heights: 3 vs 0
		//IL_0268->IL0393: Incompatible stack heights: 3 vs 0
		//IL_056c->IL0393: Incompatible stack heights: 4 vs 0
		//IL_02bf->IL0393: Incompatible stack heights: 4 vs 0
		//IL_06e1->IL0393: Incompatible stack heights: 8 vs 0
		//IL_0366->IL0393: Incompatible stack heights: 8 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D02]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)_spriteRenderer != null)
		{
			Sprite sprite = _spriteRenderer.sprite;
			if ((object)_spriteRenderer != null)
			{
				Material material = ((Renderer)_spriteRenderer).GetMaterial();
				int num = Shader.PropertyToID("_MinX");
				if ((object)sprite != null)
				{
					_ = 0;
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					object obj2 = default(object);
					object obj = obj2 - 72;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj);
					Texture2D texture = sprite.texture;
					if ((object)texture != null)
					{
						int width = texture.width;
						if ((object)material != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
							float value = 0f / (float)width;
							material.SetFloatImpl(num, value);
							if ((object)_spriteRenderer != null)
							{
								Material material2 = ((Renderer)_spriteRenderer).GetMaterial();
								int num2 = Shader.PropertyToID("_MaxX");
								_ = 0;
								bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
								object obj3 = obj2 - 72;
								Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj3);
								Texture2D texture2 = sprite.texture;
								if ((object)texture2 != null)
								{
									int width2 = texture2.width;
									if ((object)material2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
										object obj4 = num3 + 0;
										float value2 = (float)obj4 / (float)width2;
										material2.SetFloatImpl(num2, value2);
										if ((object)_spriteRenderer != null)
										{
											Material material3 = ((Renderer)_spriteRenderer).GetMaterial();
											int num4 = Shader.PropertyToID("_MinY");
											_ = 0;
											bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
											object obj5 = obj2 - 72;
											Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj5);
											Texture2D texture3 = sprite.texture;
											if ((object)texture3 != null)
											{
												int height = texture3.height;
												if ((object)material3 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-44]");
													float value3 = 0f / (float)height;
													material3.SetFloatImpl(num4, value3);
													if ((object)_spriteRenderer != null)
													{
														Material material4 = ((Renderer)_spriteRenderer).GetMaterial();
														int num5 = Shader.PropertyToID("_MaxY");
														_ = 0;
														bool flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
														object obj6 = obj2 - 72;
														Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj6);
														Texture2D texture4 = sprite.texture;
														if ((object)texture4 != null)
														{
															int height2 = texture4.height;
															if ((object)material4 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-44]");
																nint num6 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-3C]");
																object obj7 = num6 + 0;
																float value4 = (float)obj7 / (float)height2;
																material4.SetFloatImpl(num5, value4);
																_ = 0;
																bool flag5 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
																object obj8 = obj2 - 72;
																Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj8);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																nint num7 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																object obj9 = num7 + 0;
																_ = 0;
																bool flag6 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
																object obj10 = obj2 - 56;
																Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj10);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-38]");
																object obj11 = obj9 - 0;
																float spriteWidthUnits = (float)obj11 * 0.01f;
																_spriteWidthUnits = spriteWidthUnits;
																_ = 0;
																bool flag7 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
																object obj12 = obj2 - 72;
																Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj12);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-44]");
																nint num8 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-3C]");
																object obj13 = num8 + 0;
																_ = 0;
																bool flag8 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
																object obj14 = obj2 - 56;
																Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj14);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
																object obj15 = obj13 - 0;
																float spriteHeightUnits = (float)obj15 * 0.01f;
																_spriteHeightUnits = spriteHeightUnits;
																Texture2D texture5 = sprite.texture;
																if ((object)texture5 != null)
																{
																	int width3 = texture5.width;
																	float textureWidthUnits = (float)width3 * 0.01f;
																	_textureWidthUnits = textureWidthUnits;
																	Texture2D texture6 = sprite.texture;
																	if ((object)texture6 != null)
																	{
																		int height3 = texture6.height;
																		float textureHeightUnits = (float)height3 * 0.01f;
																		_textureHeightUnits = textureHeightUnits;
																		return;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public SpriteScroller()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
