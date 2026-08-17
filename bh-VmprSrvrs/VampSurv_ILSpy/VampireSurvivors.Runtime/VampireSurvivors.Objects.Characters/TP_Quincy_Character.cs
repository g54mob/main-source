using System;
using System.Threading;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Quincy_Character : TP_Character
{
	private TP_Neutron_Weapon neutronWeapon;

	private Image _HealthBar;

	private Image _HealthBarFill;

	private bool _isCharging;

	private float _chargeTime;

	private float _maxChargeTimeMS = 75000f;

	private PhaserSprite _cursor1;

	private PhaserSprite _cursor2;

	private MultiTargetTween _angle1Tween;

	private MultiTargetTween _angle2Tween;

	private MultiTargetTween _scaleTween;

	public unsafe override void AfterFullInitialization()
	{
		//IL_00fc: Expected I4, but got I8
		//IL_0143: Expected I4, but got I8
		//IL_0287: Expected I, but got O
		//IL_029a: Expected O, but got I4
		//IL_03bf: Expected I, but got O
		//IL_03d2: Expected O, but got I4
		//IL_0550: Expected I, but got O
		//IL_0563: Expected O, but got I4
		//IL_0581: Expected O, but got I4
		//IL_058f: Expected O, but got I4
		//IL_01ff->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_0275->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_0253->IL0253: Incompatible stack heights: 3 vs 2
		//IL_0337->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_03ad->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_038b->IL038b: Incompatible stack heights: 3 vs 2
		//IL_046f->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_053e->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_04c3->IL04c3: Incompatible stack heights: 3 vs 2
		//IL_051c->IL051c: Incompatible stack heights: 3 vs 2
		base.AfterFullInitialization();
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UISquare");
		if ((object)_HealthBarFill != null)
		{
			_HealthBarFill.sprite = unpackedSprite;
			if ((object)_HealthBar != null)
			{
				_HealthBar.sprite = unpackedSprite;
				_chargeTime = 0f;
				_isCharging = false;
				HideCharge();
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Arms01");
				_cursor1 = cursor;
				if ((object)_cursor1 != null)
				{
					PhaserSprite phaserSprite = _cursor1.setDepth(-1);
					GameObject gameObject2 = base.gameObject;
					PhaserSprite cursor2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Arms02");
					_cursor2 = cursor2;
					PhaserSprite phaserSprite2 = _cursor2.setDepth(-1);
					PhaserSprite phaserSprite3 = _cursor1.setAlpha(0f);
					PhaserSprite phaserSprite4 = _cursor2.setAlpha(0f);
					Transform transform = _cursor1.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector2 value = default(Vector2);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					Transform transform2 = _cursor2.transform;
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector2 value2 = default(Vector2);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
					if (_angle1Tween != null)
					{
						_angle1Tween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						if ((object)_cursor1 != null)
						{
							void* value3 = ((IntPtr*)(&array))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag3 = obj == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
							((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1157234688;
							_ = 4294967295L;
							((MaskableGraphic)(object)tweenConfig).m_ShouldRecalculateStencil = true;
							MultiTargetTween angle1Tween = Tweens.Add(tweenConfig);
							_angle1Tween = angle1Tween;
							if (_angle2Tween != null)
							{
								_angle2Tween.Kill();
							}
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							if (array2 != null)
							{
								if ((object)_cursor2 != null)
								{
									void* value4 = ((IntPtr*)(&array2))->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									bool flag4 = obj2 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig2 != null)
								{
									((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
									((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1158660096;
									_ = 4294967295L;
									((MaskableGraphic)(object)tweenConfig2).m_ShouldRecalculateStencil = true;
									MultiTargetTween angle2Tween = Tweens.Add(tweenConfig2);
									_angle2Tween = angle2Tween;
									if (_scaleTween != null)
									{
										_scaleTween.Kill();
									}
									TweenConfig tweenConfig3 = new TweenConfig();
									object[] array3 = new object[2];
									if (array3 != null)
									{
										if ((object)_cursor1 != null)
										{
											void* value5 = ((IntPtr*)(&array3))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj3 = default(object);
											bool flag5 = obj3 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if ((object)_cursor2 != null)
										{
											void* value6 = ((IntPtr*)(&array3))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj4 = default(object);
											bool flag6 = obj4 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig3 != null)
										{
											((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
											((MonoBehaviour)(object)tweenConfig3).m_CancellationTokenSource = (CancellationTokenSource)1133903872;
											_ = 4294967295L;
											_ = 1;
											((Graphic)(object)tweenConfig3).m_Material = (Material)4;
											((Graphic)(object)tweenConfig3).m_OnDirtyMaterialCallback = (UnityAction)1;
											Func<int, float> sprite = Tweens.Stagger(150f, new StaggerConfig
											{
												ease = Ease.Linear,
												start = 0f
											});
											((Image)(object)tweenConfig3).m_Sprite = (Sprite)(object)sprite;
											MultiTargetTween scaleTween = Tweens.Add(tweenConfig3);
											_scaleTween = scaleTween;
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
		throw new NullReferenceException();
	}

	private unsafe void HideCharge()
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		Color color = _HealthBar.color;
		object obj = default(object);
		_HealthBar.color = (Color)(&obj);
		Color color2 = _HealthBarFill.color;
		_HealthBarFill.color = (Color)(&obj);
		_isCharging = false;
	}

	private unsafe void ShowCharge()
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		Color color = _HealthBar.color;
		object obj = default(object);
		_HealthBar.color = (Color)(&obj);
		Color color2 = _HealthBarFill.color;
		_HealthBarFill.color = (Color)(&obj);
		if (!_isCharging)
		{
			_isCharging = true;
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_001b: Invalid comparison between F4 and I4
		//IL_0055: Expected O, but got Ref
		//IL_0078: Expected O, but got Ref
		base.OnUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187641E5Eh\"");
		if (((CharacterController)this)._walked == 0f)
		{
			Color color = _HealthBar.color;
			object obj = default(object);
			_HealthBar.color = (Color)(&obj);
			Color color2 = _HealthBarFill.color;
			_HealthBarFill.color = (Color)(&obj);
			if (!_isCharging)
			{
				_isCharging = true;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			float num2 = base.PPower();
			bool flag = 5f > deltaTime;
			float num3 = deltaTime;
			if (!flag)
			{
				num3 = 5f;
			}
			float num4 = num3 * num;
			float num5 = (_chargeTime = num4 + _chargeTime) / _maxChargeTimeMS;
			float num6 = num5 * 0.75f;
			float alpha = num6 + 0.25f;
			PhaserSprite phaserSprite = _cursor1.setAlpha(alpha);
			PhaserSprite phaserSprite2 = _cursor2.setAlpha(alpha);
			_HealthBarFill.fillAmount = num5;
			if (!(_chargeTime < _maxChargeTimeMS))
			{
				PhaserSprite phaserSprite3 = _cursor1.setAlpha(0f);
				PhaserSprite phaserSprite4 = _cursor2.setAlpha(0f);
				HideCharge();
				_chargeTime = 0f;
				FireAllSpells();
			}
		}
		else
		{
			PhaserSprite phaserSprite5 = _cursor1.setAlpha(0f);
			PhaserSprite phaserSprite6 = _cursor2.setAlpha(0f);
			HideCharge();
		}
	}

	private void FireAllSpells()
	{
		//IL_0135: Expected O, but got F4
		//IL_0095: Expected O, but got I
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.TP_NEUTRON_BOMB))
		{
			Pickup pickup = PickupManager.CreatePickup(vector, ItemType.TP_NEUTRON_BOMB);
		}
		float num = base.PLuck();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A0FED8]");
		bool flag = (nint)vector >= 0;
		Vector2 vector2 = vector;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A0FED8]");
			vector2 = (Vector2)0;
		}
		object obj = UnityEngine.Random.value;
		float num2 = 1f / (float)vector2;
		float num3 = (float)vector * num2;
		if (num3 > 0.55f)
		{
			float num4 = base.MaxHp();
			float num5 = num3 * 0.35f;
			bool flag2 = !(1f < num5);
			float damageAmount = 1f;
			if (!flag2)
			{
				damageAmount = num5;
			}
			base.GetDamagedByOwnWeapon(damageAmount);
		}
	}

	public override void LevelUp()
	{
		base.LevelUp();
	}
}
