using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Curves;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TongueProjectile : Projectile
{
	protected TrailRenderer _trail;

	protected float _attackSpeed = 1f;

	protected Sprite _trailSprite;

	protected float _AttackLerp;

	private float _minAngleRotDeg = 15f;

	private float _maxAngleRotDeg = 20f;

	private float _angleRng;

	protected bool _retracting;

	protected float2 _lastTargetPoint;

	protected bool _hasHitAnObject;

	protected EnemyController _targetEnemy;

	protected SfxType[] s_sounds;

	protected override void Awake()
	{
		base.Awake();
		InitTrailSprite();
		SetupTrail();
	}

	protected virtual void InitTrailSprite()
	{
		Sprite sprite = SpriteManager.GetSprite("TongueP", "vfx");
		_trailSprite = sprite;
	}

	protected unsafe void SetupTrail()
	{
		//IL_00ee: Expected O, but got Ref
		object trailSprite = _trailSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		Sprite.GetTextureRect_Injected((IntPtr)0, out Rect _);
		Material material = ((Renderer)_trail).GetMaterial();
		Material material2 = new Material(material);
		Texture2D texture = ((Sprite)trailSprite).texture;
		material2.mainTexture = texture;
		((Renderer)_trail).SetMaterial(material2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		Sprite.GetTextureRect_Injected((IntPtr)0, out Rect _);
		Texture2D texture2 = ((Sprite)trailSprite).texture;
		int width = texture2.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		Sprite.GetTextureRect_Injected((IntPtr)0, out Rect _);
		Texture2D texture3 = ((Sprite)trailSprite).texture;
		int height = texture3.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		bool flag4 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		Sprite.GetTextureRect_Injected((IntPtr)0, out Rect _);
		Texture2D texture4 = ((Sprite)trailSprite).texture;
		int width2 = texture4.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		Sprite.GetTextureRect_Injected((IntPtr)0, out Rect ret5);
		Texture2D texture5 = ((Sprite)trailSprite).texture;
		int height2 = texture5.height;
		Material material3 = ((Renderer)_trail).GetMaterial();
		material3.SetVector("_SpriteRect", (Vector4)(&ret5));
		object obj = default(object);
		float num = (float)obj / 100f;
		_trail.startWidth = num;
		_trail.endWidth = num;
		Material material4 = ((Renderer)_trail).GetMaterial();
		int num2 = Shader.PropertyToID("_FlipY");
		material4.SetFloatImpl(num2, 1f);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0141: Expected I4, but got O
		//IL_01ac->IL00fe: Incompatible stack heights: 1 vs 0
		//IL_00a7->IL00fe: Incompatible stack heights: 1 vs 0
		//IL_00d6->IL00fe: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
			_isCullable = false;
			_AttackLerp = 0f;
			_retracting = false;
			float2 lastTargetPoint = base.position;
			_lastTargetPoint = lastTargetPoint;
			_ = 3238002688L;
			_hasHitAnObject = false;
			int num = (int)_trail;
			if ((object)_trail != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdi_v5 (System.Int32)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdi_v5 (System.Int32)+10]");
				TrailRenderer.Clear_Injected((IntPtr)0);
				if ((object)_trail != null)
				{
					_trail.emitting = false;
					if ((object)_trail != null)
					{
						_trail.enabled = false;
						if ((object)_trail != null)
						{
							Material material = ((Renderer)_trail).GetMaterial();
							RenderingExtensions.SetAlpha(material, 0f);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetTargetEnemy(EnemyController enemy)
	{
		_targetEnemy = enemy;
	}

	private void InitTrail()
	{
		object trail = _trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		_trail.emitting = false;
		_trail.enabled = false;
		Material material = ((Renderer)_trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0f);
	}

	protected float2 GetMouthPosition()
	{
		Weapon weapon = _weapon;
		Weapon weapon3 = default(Weapon);
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			List<Vector2> headOffsets = ((Equipment)weapon)._003COwner_003Ek__BackingField.GetHeadOffsets();
			if (headOffsets != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
				Weapon weapon2 = _weapon;
				if ((object)_weapon == null || (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
				{
					goto IL_010b;
				}
				if (((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX)
				{
					goto IL_00d2;
				}
			}
			weapon3 = _weapon;
			if ((object)_weapon != null)
			{
				goto IL_00d2;
			}
		}
		goto IL_010b;
		IL_010b:
		return (float2)new NullReferenceException();
		IL_00d2:
		if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
			float2 result = default(float2);
			return result;
		}
		goto IL_010b;
	}

	protected virtual Vector3[] GetCurve(float2 startPoint, float2 currentPoint)
	{
		float num = _angleRng * _maxAngleRotDeg;
		float num2 = num + _minAngleRotDeg;
		float num3 = num2 * _AttackLerp;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18732FD60");
		QuadraticBezierCurve quadraticBezierCurve = null;
		quadraticBezierCurve._p0 = currentPoint;
		System.Linq.Buffer<Vector3> p = default(System.Linq.Buffer<Vector3>);
		quadraticBezierCurve._p1 = (Vector2)p;
		quadraticBezierCurve._p2 = startPoint;
		Vector3[] points = quadraticBezierCurve.GetPoints(5);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD370");
		IEnumerable<Vector3> enumerable = default(IEnumerable<Vector3>);
		if (enumerable != null)
		{
			System.Linq.Buffer<Vector3> buffer = new System.Linq.Buffer<Vector3>(enumerable);
			System.Linq.Buffer<Vector3> buffer2 = default(System.Linq.Buffer<Vector3>);
			return buffer2.ToArray();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	protected void UpdateTrail()
	{
		//IL_01cd: Expected F4, but got I4
		//IL_02e4->IL024b: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL024b: Incompatible stack heights: 1 vs 0
		//IL_00e5->IL024b: Incompatible stack heights: 1 vs 0
		//IL_0116->IL024b: Incompatible stack heights: 1 vs 0
		//IL_015c->IL024b: Incompatible stack heights: 1 vs 0
		//IL_01f5->IL024b: Incompatible stack heights: 2 vs 0
		//IL_0185->IL024b: Incompatible stack heights: 2 vs 0
		//IL_0221->IL024b: Incompatible stack heights: 2 vs 0
		//IL_01b1->IL024b: Incompatible stack heights: 2 vs 0
		float2 mouthPosition = GetMouthPosition();
		float2 currentPoint = base.position;
		float2 startPoint = default(float2);
		Vector3[] curve = GetCurve(startPoint, currentPoint);
		int num2;
		float value;
		Material material2;
		if ((object)_trail != null)
		{
			_trail.emitting = true;
			if ((object)_trail != null)
			{
				_trail.enabled = true;
				TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 1f);
				object trail = _trail;
				if ((object)_trail != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdi_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdi_v7 (System.Object)+10]");
					TrailRenderer.Clear_Injected((IntPtr)0);
					if ((object)_trail != null)
					{
						_trail.AddPositions(curve);
						Weapon weapon = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
						{
							int num = ((Equipment)weapon)._003COwner_003Ek__BackingField.depth;
							if ((object)_trail != null)
							{
								int sortingOrder = num - 10;
								_trail.sortingOrder = sortingOrder;
								object cachedTransform = _cachedTransform;
								if ((object)_cachedTransform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v9 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v9 (System.Object)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
									if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref mouthPosition) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
									{
										if ((object)_trail != null)
										{
											Material material = ((Renderer)_trail).GetMaterial();
											if ((object)material != null)
											{
												num2 = Shader.PropertyToID("_FlipY");
												value = 0f;
												material2 = material;
												goto IL_033b;
											}
										}
									}
									else if ((object)_trail != null)
									{
										Material material3 = ((Renderer)_trail).GetMaterial();
										if ((object)material3 != null)
										{
											num2 = Shader.PropertyToID("_FlipY");
											value = 1f;
											material2 = material3;
											goto IL_033b;
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
		IL_033b:
		material2.SetFloatImpl(num2, value);
	}

	public override void InternalUpdate()
	{
		//IL_0115: Expected O, but got I4
		//IL_0070: Invalid comparison between I4 and F4
		//IL_007f: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		object obj;
		if (_retracting)
		{
			float deltaTime = PauseSystem.DeltaTime;
			Weapon weapon = _weapon;
			float num = weapon.PSpeed();
			float num2 = _attackSpeed * deltaTime;
			float num3 = deltaTime * num2;
			bool flag = 0f < (_AttackLerp -= num3);
			obj = 0;
			if (!flag)
			{
				obj = 1;
			}
		}
		else
		{
			float deltaTime2 = PauseSystem.DeltaTime;
			Weapon weapon2 = _weapon;
			float num4 = weapon2.PSpeed();
			float num5 = _attackSpeed * deltaTime2;
			float num6 = deltaTime2 * num5;
			bool flag2 = (_AttackLerp = num6 + _AttackLerp) < 1f;
			obj = 0;
			if (!flag2)
			{
				_retracting = true;
				obj = 0;
			}
		}
		EnemyController targetEnemy = _targetEnemy;
		if ((object)_targetEnemy != null && ((UnityEngine.Object)targetEnemy).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite targetEnemy2 = _targetEnemy;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v15 (ArcadeSprite)+260]");
			if ((nint)0 == 0)
			{
				if (targetEnemy2.body == null)
				{
					float2 lastTargetPoint = targetEnemy2.position;
					_lastTargetPoint = lastTargetPoint;
				}
				else
				{
					BaseBody baseBody = targetEnemy2.body;
					_lastTargetPoint = baseBody._center;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v20 (BaseBody)+6C]");
					_ = 0;
				}
			}
			else
			{
				_targetEnemy = null;
			}
		}
		float2 mouthPosition = GetMouthPosition();
		float2 float5 = default(float2);
		base.position = float5;
		UpdateTrail();
		if (obj != null)
		{
			Despawn();
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_004b: Expected O, but got I4
		if (!_hasHitAnObject)
		{
			_hasHitAnObject = true;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float detune = (float)_indexInWeapon * 4.294967E+09f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.DLC3_TongueTrueHitt, soundConfig, 200f, 4, time);
		}
	}

	protected unsafe void PlayLickSound()
	{
		//IL_00e1: Expected O, but got I4
		//IL_00f1: Expected O, but got I
		//IL_0114: Expected O, but got I4
		//IL_0155: Expected O, but got I
		//IL_003f: Expected O, but got I8
		//IL_00b9: Expected F4, but got I4
		//IL_0079: Expected O, but got I8
		//IL_0044->IL013b: Incompatible stack heights: 1 vs 0
		//IL_007e->IL0122: Incompatible stack heights: 1 vs 0
		SfxType[] array = s_sounds;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		object obj3 = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag2 = obj2 == null;
			obj3 = 6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v142 @ rax_v20 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag3 = obj4 == null;
			obj3 = 6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v201 @ rax_v23 (should have been resolved before IL gen)");
		SfxType[] array2 = s_sounds;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), 10f, 5, 0f, volume, rate, detune, loop, 1f);
	}

	public override void Despawn()
	{
		TrailRenderer trail = _trail;
		if ((object)_trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_trail.emitting = false;
			_trail.enabled = false;
			Material material = ((Renderer)_trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
		}
		base.Despawn();
	}

	public TongueProjectile()
	{
		SfxType[] array = new SfxType[2];
		_ = 163;
		_ = 164;
		s_sounds = array;
		base._002Ector();
	}
}
