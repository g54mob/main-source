using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySpin : EnemyController
{
	private float _spinAngle;

	private float _radius;

	private Tween _radiusTween;

	private Tween _scaleTween;

	private Bounds _camBounds;

	private int? _003CDepthOverride_003Ek__BackingField;

	public int? DepthOverride
	{
		get
		{
			return _003CDepthOverride_003Ek__BackingField;
		}
		set
		{
			_003CDepthOverride_003Ek__BackingField = value;
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0252: Expected O, but got F4
		//IL_02ac: Expected O, but got F4
		//IL_01ac: Expected I4, but got O
		//IL_0386: Expected O, but got F4
		//IL_03c9: Expected O, but got Ref
		//IL_0359: Expected I4, but got O
		//IL_0362->IL0376: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		object obj = UnityEngine.Random.value;
		object obj3 = default(object);
		object obj2 = obj3 + obj3;
		_radius = 1f;
		float num = (_spinAngle = (float)obj2 * (float)Math.PI);
		if (_radiusTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_radiusTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float val = default(float);
		((EnemySpin)(object)dOSetter)._003CInitEnemy_003Eb__9_1(val);
		object obj4 = UnityEngine.Random.value;
		float num2 = num * 2000f;
		float num3 = num2 + 2000f;
		float duration = num3 * 0.001f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.65f, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_radiusTween = tweenerCore;
			bool flag = (byte)(int)_cachedTransform != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rbx_v10 (System.Boolean)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rbx_v10 (System.Boolean)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			if (_scaleTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_scaleTween);
			}
			object obj5 = UnityEngine.Random.value;
			object obj6 = default(object);
			float num4 = (float)obj6 * 1000f;
			float num5 = num4 + 300f;
			float duration2 = num5 * 0.001f;
			object obj7 = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&obj7), duration2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((int)(~tweenerCore2) == 0)
			{
				_scaleTween = tweenerCore2;
				Camera main = Camera.main;
				_camBounds = (Bounds)CameraExtensions.OrthographicBounds(main).m_Center;
				base._003CIgnoreNetworkError_003Ek__BackingField = true;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1204 @ rax_v59 (UnityEngine.Bounds)+10]");
				_ = 0;
				OnUpdate();
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_000b: Expected I, but got O
		//IL_0264: Expected F4, but got I
		base.OnUpdate();
		nint num = (nint)this;
		base.SetFlipX(flip: false);
		float deltaTime = PauseSystem.DeltaTime;
		GameSessionData gameSessionData = _gameSessionData;
		float spinAngle = deltaTime + _spinAngle;
		_spinAngle = spinAngle;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				object obj = default(object);
				float num2 = (float)obj * 2f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				object obj2 = default(object);
				float num3 = (float)obj2 + 0.16f;
				Transform cachedTransform = _cachedTransform;
				float num4 = _spinAngle * num2;
				float num5 = num4 * 0.45f;
				float num6 = num5 * _radius;
				float num7 = num6 + num3;
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
				BaseBody baseBody = body;
				bool flag4 = body == null;
				EnemySpin cachedTransform2 = (EnemySpin)(object)_cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Quaternion.AngleAxis_Injected((float)(nint)((UnityEngine.Object)cachedTransform).m_CachedPtr, ref ret, out Quaternion _);
				bool flag5 = (object)_cachedTransform == null;
				bool flag6 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Quaternion*)(&value));
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void UpdateDepth()
	{
		//IL_00c0: Expected I4, but got O
		if ((object)_003CDepthOverride_003Ek__BackingField == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num = default(int);
			if (num != base.currentDepthEnemy)
			{
				base.currentDepthEnemy = num;
				_EnemyRenderer.sortingOrder = num;
			}
			int num2 = num - 1;
			if (num2 != base.currentDepthAlert)
			{
				base.currentDepthAlert = num2;
				_AlertSpriteRenderer.sortingOrder = num2;
			}
		}
		else
		{
			if ((object)_003CDepthOverride_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new NullReferenceException();
			}
			int sortingOrder = (object?)_003CDepthOverride_003Ek__BackingField >> 32;
			_EnemyRenderer.sortingOrder = sortingOrder;
		}
	}

	private float _003CInitEnemy_003Eb__9_0()
	{
		return _radius;
	}

	private void _003CInitEnemy_003Eb__9_1(float val)
	{
		_radius = val;
	}
}
