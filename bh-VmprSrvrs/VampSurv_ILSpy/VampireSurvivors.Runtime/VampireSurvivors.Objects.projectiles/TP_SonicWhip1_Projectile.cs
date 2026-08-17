using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SonicWhip1_Projectile : TP_WhipCore_Projectile
{
	[NonSerialized]
	public float LineAlpha;

	private MultiTargetTween _lineTween;

	[NonSerialized]
	public float LerpRatio;

	[NonSerialized]
	public float WaveRatio;

	private MultiTargetTween _lerpTween;

	private Timer _durationTimer;

	private int _attackCount;

	private int _attackAmount;

	private float _wavePixelHeight = 20f;

	public List<Gradient> _gradients;

	public override int Nodes => 24;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override float WhipLength()
	{
		//IL_002a: Expected O, but got F4
		float num = _weapon.PArea();
		object obj = UnityEngine.Random.value;
		float num3 = default(float);
		float num2 = num3 + num3;
		bool flag = !(3.14f > num2);
		float result = 3.14f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_012a: Expected O, but got F4
		//IL_0166: Expected O, but got I4
		//IL_0069: Expected I4, but got F4
		//IL_00b6: Expected I4, but got F4
		((Projectile)this).InitProjectile(pool, weapon, index);
		_isCullable = false;
		base.InitWhips();
		LineAlpha = 1f;
		_attackCount = 0;
		startAttack(0f);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Whip, soundConfig, 200f, 3, num2);
		Action onComplete = PlaySFX;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = PlaySFX;
		Timer timer2 = Timers.Register(0.2f, onComplete2, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void PlaySFX()
	{
		//IL_004b: Expected O, but got F4
		//IL_0087: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Whip, soundConfig, 200f, 3, time);
	}

	private void startAttack(float delay)
	{
		//IL_003f: Expected I, but got O
		LerpRatio = 0f;
		if (_lerpTween != null)
		{
			_lerpTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LerpRatio", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			float num2 = _weapon.PDuration();
			object obj2 = default(object);
			float duration = (float)obj2 / 50f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"WaveRatio", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.ease = Ease.Linear;
			float num3 = _weapon.PDuration();
			tweenConfig.duration = duration;
			tweenConfig.delay = delay;
			TweenCallback onComplete = OnWhipComplete;
			tweenConfig.onComplete = onComplete;
			TweenCallback onStart = OnWhipStart;
			tweenConfig.onStart = onStart;
			MultiTargetTween lerpTween = Tweens.Add(tweenConfig);
			_lerpTween = lerpTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	protected override Projectile CreateNodeProjectile(float2 pos)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			nint num = (nint)typeof(TP_SonicWhip1_Weapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SonicWhip1_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SonicWhip1_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v46 @ rax_v4*8]");
				if (0 == (nint)typeof(TP_SonicWhip1_Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SonicWhip1_Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v88 @ rcx_v4*8]");
					object obj4 = 0 - typeof(TP_SonicWhip1_Weapon);
					bool flag = obj4 == null;
					bool flag2 = !flag;
					TP_WhipCore1_Weapon tP_WhipCore1_Weapon = null;
					if (!flag2)
					{
						tP_WhipCore1_Weapon = (TP_WhipCore1_Weapon)_weapon;
					}
					float area = default(float);
					return tP_WhipCore1_Weapon.CreateNodeProjectile(pos, 0, 1, area);
				}
			}
		}
		return (Projectile)(object)new NullReferenceException();
	}

	private void OnWhipStart()
	{
		//IL_0047: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0177->IL0131: Incompatible stack heights: 3 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
			object obj = (flag ? 1 : 0) ^ 1;
			object obj2 = obj * 2;
			float flipNum = (float)obj2 - 1f;
			_flipNum = flipNum;
			_applyNodeControl = true;
			bodyEnabled(enable: true);
			LineRenderer lineRenderer = _lineRenderer;
			Gradient gradient = Extensions.PickRnd(_gradients);
			if ((object)_lineRenderer != null)
			{
				bool flag2 = gradient == null;
				bool flag3 = ((UnityEngine.Object)lineRenderer).m_CachedPtr == (IntPtr)0;
				bool flag4 = gradient.m_Ptr == (IntPtr)0;
				LineRenderer.SetColorGradient_Injected(((UnityEngine.Object)lineRenderer).m_CachedPtr, gradient.m_Ptr);
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 169 Invalid \"Jump target not found in method: 0x18716D760\"");
			}
		}
		throw new NullReferenceException();
	}

	private void OnWhipComplete()
	{
		//IL_003e: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		if (_attackCount >= _attackAmount)
		{
			Projectile[] nodeProjectiles = _nodeProjectiles;
			_applyNodeControl = false;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj < nodeProjectiles.Length)
			{
				Projectile[] nodeProjectiles2 = _nodeProjectiles;
				Projectile projectile = nodeProjectiles2[obj2];
				BaseBody baseBody = projectile.body;
				obj2++;
				baseBody._enable = false;
				nodeProjectiles = _nodeProjectiles;
				obj = obj2;
			}
			Despawn();
		}
		else
		{
			int attackCount = _attackCount + 1;
			_attackCount = attackCount;
			startAttack(0f);
		}
	}

	public override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float num = weapon.PArea();
		object obj = default(object);
		float wavePixelHeight = (float)obj * 20f;
		Weapon weapon2 = _weapon;
		_wavePixelHeight = wavePixelHeight;
		float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 55 Invalid \"Jump target not found in method: 0x18716D760\"");
		throw new NullReferenceException();
	}

	private unsafe void UpdateWhipLineRenderer()
	{
		//IL_0291: Expected O, but got I4
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_0067: Expected O, but got I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected I4, but got Unknown
		//IL_014b: Expected O, but got I
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_0367: Expected I4, but got O
		//IL_0378: Expected O, but got Ref
		//IL_016b->IL027b: Incompatible stack heights: 1 vs 0
		//IL_0191->IL027b: Incompatible stack heights: 1 vs 0
		//IL_0328->IL027b: Incompatible stack heights: 1 vs 0
		//IL_027a->IL037d: Incompatible stack heights: 1 vs 0
		//IL_0224->IL027b: Incompatible stack heights: 1 vs 0
		//IL_0246->IL027b: Incompatible stack heights: 1 vs 0
		//IL_037d->IL02f6: Incompatible stack heights: 2 vs 1
		ApplyManualNodeControl();
		object obj = 5;
		do
		{
			ApplyVerletConstraints();
			obj--;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4676]");
		}
		while ((nint)0 != 0);
		Projectile[] nodeProjectiles = _nodeProjectiles;
		if (_nodeProjectiles != null)
		{
			WhipVerletNode[] nodes = _nodes;
			if (_nodes != null)
			{
				object obj2 = nodes.Length - 1;
				object obj3 = nodeProjectiles.Length / obj2;
				int stepsPerCurve = obj3 - 1;
				List<Vector2> list = TP_WhipCore_Projectile.GenerateSpline(_nodes, stepsPerCurve, 0.5f);
				Projectile[] nodeProjectiles2 = _nodeProjectiles;
				if (_nodeProjectiles != null)
				{
					object obj4 = obj;
					float2 float5 = default(float2);
					float2 float7 = default(float2);
					while (true)
					{
						if ((nint)obj4 >= nodeProjectiles2.Length)
						{
							return;
						}
						Projectile[] nodeProjectiles3 = _nodeProjectiles;
						if (_nodeProjectiles == null || list == null)
						{
							break;
						}
						object obj5 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						bool flag = (nint)obj5 >= 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						if ((nint)0 == 0 || (object)nodeProjectiles3[obj] == null)
						{
							break;
						}
						nodeProjectiles3[obj].position = float5;
						LineRenderer lineRenderer = _lineRenderer;
						if ((object)_lineRenderer != null && ((UnityEngine.Object)lineRenderer).m_CachedPtr != (IntPtr)0)
						{
							object lineRenderer2 = _lineRenderer;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
							Weapon weapon = _weapon;
							if ((object)_weapon == null || (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
							{
								break;
							}
							float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbp_v9 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbp_v9 (System.Object)+10]");
							LineRenderer.SetPosition_Injected((IntPtr)0, (int)obj, ref *(Vector3*)(&float7));
							float7 = float5;
							obj2 = (object)(&float7);
						}
						nodeProjectiles2 = _nodeProjectiles;
						obj++;
						if (_nodeProjectiles == null)
						{
							break;
						}
						obj4 = obj;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ApplyManualNodeControl()
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_00bd: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0177: Expected O, but got I4
		//IL_0188: Expected O, but got I4
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0298: Expected O, but got F4
		WhipVerletNode[] nodes = _nodes;
		WhipVerletNode whipVerletNode = nodes[0];
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = float5 + _characterOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_SonicWhip1_Projectile)+100]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		whipVerletNode.position = float6;
		WhipVerletNode[] nodes2 = _nodes;
		object obj3 = 1;
		object obj4 = 1;
		WhipVerletNode[] nodes3 = _nodes;
		while ((nint)obj3 < nodes2.Length)
		{
			WhipVerletNode whipVerletNode2 = nodes3[obj4];
			obj4++;
			whipVerletNode2.isStatic = _applyNodeControl;
			nodes3 = _nodes;
			obj3 = obj4;
			nodes2 = _nodes;
		}
		if (!_applyNodeControl)
		{
			return;
		}
		WhipVerletNode[] nodes4 = _nodes;
		float num = (float)Math.PI * 2f / (float)nodes4.Length;
		object obj5 = 1;
		WhipVerletNode[] array = nodes4;
		object obj6 = 1;
		bool flag;
		do
		{
			if ((nint)obj5 < nodes4.Length)
			{
				WhipVerletNode whipVerletNode3 = array[obj6];
				WhipVerletNode whipVerletNode4 = array[0];
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,edi\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
				float num2 = 0f * 0.19999999f;
				float num3 = 0f * num;
				float num4 = num2 * _flipNum;
				float num5 = num3 - WaveRatio;
				float num6 = num4 * _whipSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num7 = num5 * _wavePixelHeight;
				float num8 = (float)whipVerletNode4.position + num6;
				float num9 = num7 * 0.01f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v15 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				float num10 = 0f + num9;
				obj6++;
				whipVerletNode3.position = (float2)num8;
				array = _nodes;
				flag = _nodes != null;
				obj5 = obj6;
				nodes4 = _nodes;
				continue;
			}
			return;
		}
		while (flag);
		throw new NullReferenceException();
	}

	protected override float CalculateIndexNodeDistance(int index)
	{
		WhipVerletNode[] nodes = _nodes;
		float num = _nodeDistance / (float)nodes.Length;
		float num2 = num * (float)index;
		return num2 + 0.15f;
	}

	public override void Despawn()
	{
		if (_lineTween != null)
		{
			_lineTween.Kill();
		}
		if (_lerpTween != null)
		{
			_lerpTween.Kill();
		}
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		base.Despawn();
	}
}
