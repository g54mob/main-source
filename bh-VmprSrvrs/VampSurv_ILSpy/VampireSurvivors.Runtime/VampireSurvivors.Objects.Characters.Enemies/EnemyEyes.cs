using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyEyes : EnemyController
{
	private PhaserSprite _Eyes;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_03e0: Expected O, but got I4
		//IL_03e0: Expected F4, but got O
		//IL_0123: Expected O, but got I4
		//IL_01a9: Expected O, but got I
		//IL_0223: Expected O, but got I
		//IL_047f: Expected O, but got I
		//IL_02b3: Expected O, but got I
		//IL_034d: Expected O, but got I
		//IL_0457->IL0389: Incompatible stack heights: 1 vs 0
		//IL_0141->IL0389: Incompatible stack heights: 1 vs 0
		//IL_0181->IL0389: Incompatible stack heights: 1 vs 0
		//IL_01c9->IL0389: Incompatible stack heights: 1 vs 0
		//IL_020d->IL045c: Incompatible stack heights: 1 vs 2
		//IL_049f->IL0389: Incompatible stack heights: 2 vs 0
		//IL_029d->IL04a4: Incompatible stack heights: 2 vs 3
		//IL_04e7->IL0389: Incompatible stack heights: 3 vs 0
		//IL_0337->IL04ec: Incompatible stack heights: 3 vs 4
		base.InitEnemy(enemyType, asRemote);
		PhaserSprite eyes = _Eyes;
		if ((object)_Eyes != null)
		{
			Sprite sprite = SpriteManager.GetSprite("Head_eyes", "enemies2");
			if ((object)eyes._spriteRenderer != null)
			{
				eyes._spriteRenderer.sprite = sprite;
				if ((object)_Eyes != null)
				{
					PhaserSprite phaserSprite = _Eyes.setDepth(3200);
					BaseBody baseBody = body;
					if (body != null)
					{
						ArcadeTransform arcadeTransform = baseBody._transform;
						if (baseBody._transform != null && (object)_Eyes != null)
						{
							PhaserSprite phaserSprite2 = _Eyes.setOrigin((float)arcadeTransform._origin, (float?)(object)1);
							PhaserSprite cachedTransform = (PhaserSprite)(object)_cachedTransform;
							if ((object)_cachedTransform != null)
							{
								bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
								float ret;
								Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
								if ((object)_Eyes != null)
								{
									PhaserSprite phaserSprite3 = _Eyes.setScale(ret, (float?)(object)0);
									if ((object)_Eyes != null)
									{
										PhaserSprite phaserSprite4 = _Eyes.setVisible(visible: true);
										List<uint> list = new List<uint>();
										if (list != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+10]");
											object obj = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
												nint num = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v14+18]");
												if (num >= 0)
												{
													list.AddWithResize(8947814u);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
													object obj2 = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
													nint num2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v14+18]");
													bool flag2 = num2 >= 0;
													_ = 8947814;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+10]");
												object obj3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
													nint num3 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v16+18]");
													if (num3 >= 0)
													{
														list.AddWithResize(8939110u);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
														object obj4 = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
														nint num4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v16+18]");
														bool flag3 = num4 >= 0;
														_ = 8939110;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+10]");
													uint item = 0u;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
														nint num5 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rdx_v19 (System.UInt32)+18]");
														if (num5 >= 0)
														{
															list.AddWithResize(8947780u);
															item = 8947780u;
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
															object obj5 = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v27 (System.Collections.Generic.List`1<System.UInt32>)+18]");
															nint num6 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rdx_v19 (System.UInt32)+18]");
															bool flag4 = num6 >= 0;
															_ = 8947780;
														}
														list.Add(item);
														uint num7 = default(uint);
														_saveTint = num7;
														ArcadeSprite arcadeSprite = setTint(num7);
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
		throw new NullReferenceException();
	}

	public override void Disappear()
	{
		base.Disappear();
		PhaserSprite phaserSprite = _Eyes.setVisible(visible: false);
	}

	public override void Despawn()
	{
		base.Despawn();
		PhaserSprite phaserSprite = _Eyes.setVisible(visible: false);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		object enemyRenderer = _EnemyRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbx_v2 (System.Object)+10]");
		bool flag2 = SpriteRenderer.get_flipX_Injected((IntPtr)0);
		PhaserSprite phaserSprite = _Eyes.setFlipX(flag2);
	}

	protected override void Die()
	{
		base.Die();
		PhaserSprite phaserSprite = _Eyes.setVisible(visible: false);
	}
}
