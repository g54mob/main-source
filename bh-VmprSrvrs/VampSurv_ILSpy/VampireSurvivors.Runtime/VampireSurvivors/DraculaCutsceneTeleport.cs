using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class DraculaCutsceneTeleport : GameMonoBehaviour
{
	public enum TeleportPosition
	{
		Throne,
		Foreground
	}

	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public DraculaCutsceneTeleport _003C_003E4__this;

		public Action onFadeToBlackComplete;

		public Action onComplete;

		internal void _003CPlayTeleportEffect_003Eb__0()
		{
			_003COuterColumnCoroutine_003Ed__29 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = _003C_003E4__this;
			obj.onFadeToBlackComplete = onFadeToBlackComplete;
			obj.onComplete = onComplete;
			Coroutine coroutine = _003C_003E4__this.StartCoroutine(obj);
		}
	}

	private sealed class _003CColourTween_003Ed__31(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SpriteRenderer spriteRenderer;

		public Color startColour;

		public Color endColour;

		public float duration;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_002e: Expected F4, but got I4
			//IL_0064: Expected I4, but got I8
			//IL_00cf: Invalid comparison between I4 and F4
			//IL_011a: Expected F4, but got I4
			if (_003C_003E1__state == 0)
			{
				_003Ctimer_003E5__2 = _003C_003E1__state;
			}
			else if (_003C_003E1__state != 1)
			{
				return false;
			}
			_003C_003E1__state = -1;
			if (duration > _003Ctimer_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				object obj = this.spriteRenderer;
				float num = (_003Ctimer_003E5__2 = deltaTime + _003Ctimer_003E5__2) / duration;
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				bool flag = (object)this.spriteRenderer == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rsi_v4 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rsi_v4 (System.Object)+10]");
				float value = default(float);
				SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			SpriteRenderer spriteRenderer = this.spriteRenderer;
			bool flag3 = (object)this.spriteRenderer == null;
			bool flag4 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Color value2 = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref value2);
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CInnerColumnCoroutine_003Ed__28(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutsceneTeleport _003C_003E4__this;

		public Action onScaleInComplete;

		private float _003Ctimer_003E5__2;

		private Vector3 _003CendScale_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0315: Expected I4, but got I8
			//IL_0039: Expected O, but got I4
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_00c2: Expected I4, but got I8
			//IL_0344: Expected O, but got I4
			//IL_01e6: Invalid comparison between I4 and F4
			//IL_009b: Expected I4, but got I8
			//IL_0231: Expected F4, but got I4
			//IL_04e7: Expected O, but got F4
			//IL_0504->IL02ff: Incompatible stack heights: 6 vs 0
			//IL_0250->IL043c: Incompatible stack heights: 2 vs 0
			//IL_02ff->IL043c: Incompatible stack heights: 6 vs 0
			DraculaCutsceneTeleport draculaCutsceneTeleport = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			bool result;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						bool flag2 = (nint)obj2 != 1;
						result = false;
						if (!flag2)
						{
							_003C_003E1__state = -1;
							result = false;
						}
						goto IL_0334;
					}
					Action action = onScaleInComplete;
					_003C_003E1__state = -1;
					if (onScaleInComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v54.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					_003CendScale_003E5__3 = (Vector3)0;
					if ((object)_003C_003E4__this == null || (object)draculaCutsceneTeleport._InnerColumn == null)
					{
						goto IL_02ff;
					}
					Transform transform = draculaCutsceneTeleport._InnerColumn.transform;
					_003CScaleTransform_003Ed__30 obj3 = null;
					obj3._003C_003E1__state = 0;
					obj3.transformToScale = transform;
					obj3.endScale = _003CendScale_003E5__3;
					obj3.startScale = _003CendScale_003E5__3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.DraculaCutsceneTeleport+<InnerColumnCoroutine>d__28)+3C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.DraculaCutsceneTeleport+<InnerColumnCoroutine>d__28)+3C]");
					_ = 0;
					obj3.duration = draculaCutsceneTeleport._InnerColumnScaleOutDuration;
					_003C_003E2__current = obj3;
					_003C_003E1__state = 3;
					goto IL_043c;
				}
			}
			else
			{
				_003Ctimer_003E5__2 = 0f;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this == null)
			{
				goto IL_02ff;
			}
			Vector3 value = default(Vector3);
			if (draculaCutsceneTeleport._InnerColumnMoveInDuration > _003Ctimer_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime + _003Ctimer_003E5__2;
				_003Ctimer_003E5__2 = num;
				if ((object)draculaCutsceneTeleport._InnerColumn == null)
				{
					goto IL_02ff;
				}
				Transform transform2 = draculaCutsceneTeleport._InnerColumn.transform;
				float num2 = _003Ctimer_003E5__2 / draculaCutsceneTeleport._InnerColumnMoveInDuration;
				if (!(0f > num2))
				{
					if (num2 > 1f)
					{
						num2 = 1f;
					}
				}
				else
				{
					num2 = 0f;
				}
				bool flag3 = (object)transform2 == null;
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
			}
			else
			{
				bool flag5 = (object)draculaCutsceneTeleport._InnerColumn == null;
				Transform transform3 = draculaCutsceneTeleport._InnerColumn.transform;
				bool flag6 = (object)transform3 == null;
				bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
				bool flag8 = (object)draculaCutsceneTeleport._InnerColumn == null;
				Transform transform4 = draculaCutsceneTeleport._InnerColumn.transform;
				bool flag9 = (object)transform4 == null;
				bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out Vector3 ret);
				_003CendScale_003E5__3 = ret;
				_ = 0;
				_003CendScale_003E5__3 = (Vector3)draculaCutsceneTeleport._InnerColumnScaleInXScale;
				if ((object)draculaCutsceneTeleport._InnerColumn == null)
				{
					goto IL_02ff;
				}
				Transform transform5 = draculaCutsceneTeleport._InnerColumn.transform;
				_003CScaleTransform_003Ed__30 obj4 = null;
				obj4._003C_003E1__state = 0;
				obj4.transformToScale = transform5;
				obj4.startScale = ret;
				obj4.endScale = _003CendScale_003E5__3;
				_ = 0;
				obj4.duration = draculaCutsceneTeleport._InnerColumnScaleInDuration;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.DraculaCutsceneTeleport+<InnerColumnCoroutine>d__28)+3C]");
				_ = 0;
				_003C_003E2__current = obj4;
				_003C_003E1__state = 2;
			}
			goto IL_043c;
			IL_0334:
			return result;
			IL_043c:
			result = true;
			goto IL_0334;
			IL_02ff:
			throw new NullReferenceException();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003COuterColumnCoroutine_003Ed__29(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutsceneTeleport _003C_003E4__this;

		public Action onFadeToBlackComplete;

		public Action onComplete;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 44 Invalid \"Jump target not found in method: 0x186DC5B4E\"");
			return (byte)_003C_003E1__state != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CScaleTransform_003Ed__30(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform transformToScale;

		public Vector3 startScale;

		public Vector3 endScale;

		public float duration;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_002e: Expected F4, but got I4
			//IL_0064: Expected I4, but got I8
			//IL_00cf: Invalid comparison between I4 and F4
			//IL_011a: Expected F4, but got I4
			if (_003C_003E1__state == 0)
			{
				_003Ctimer_003E5__2 = _003C_003E1__state;
			}
			else if (_003C_003E1__state != 1)
			{
				return false;
			}
			_003C_003E1__state = -1;
			Vector3 value = default(Vector3);
			if (duration > _003Ctimer_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				object obj = transformToScale;
				float num = (_003Ctimer_003E5__2 = deltaTime + _003Ctimer_003E5__2) / duration;
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				bool flag = (object)transformToScale == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rsi_v4 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rsi_v4 (System.Object)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref value);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			Transform transform = transformToScale;
			bool flag3 = (object)transformToScale == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitForSecondsPausable_003Ed__32(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float seconds;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_002e: Expected F4, but got I4
			//IL_0064: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003Ctimer_003E5__2 = _003C_003E1__state;
			}
			else if (_003C_003E1__state != 1)
			{
				goto IL_00c8;
			}
			_003C_003E1__state = -1;
			if (seconds > _003Ctimer_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime + _003Ctimer_003E5__2;
				_003C_003E2__current = null;
				_003Ctimer_003E5__2 = num;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_00c8;
			IL_00c8:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private Vector3 _ScaleAtThrone;

	private Vector3 _ScaleInForeground;

	private Vector3 _ThronePosition;

	private Vector3 _ForeGroundPosition;

	private SpriteRenderer _InnerColumn;

	private float _InnerColumnMoveInDuration;

	private Vector3 _InnerColumnEndPosition;

	private float _InnerColumnScaleInDuration;

	private float _InnerColumnScaleInXScale;

	private float _InnerColumnScaleOutDuration;

	private Transform _OuterColumnParent;

	private SpriteRenderer _OuterColumn;

	private float _OuterColumnScaleInDuration;

	private float _OuterColumnScaleInYScale;

	private float _OuterColumnAlphaInDuration;

	private float _OuterColumnFadeToBlackDuration;

	private float _OuterColumnWaitBeforeAlphaOut;

	private float _OuterColumnAlphaOutDuration;

	private Vector3 _innerColumnStartPosition;

	private Vector3 _innerColumnStartScale;

	private Color _outerColumnStartColour;

	private const string GradientSpriteName = "Gradient2";

	private const string VfxTextureName = "vfx";

	private void Start()
	{
		//IL_01cf->IL014f: Incompatible stack heights: 1 vs 0
		//IL_0062->IL014f: Incompatible stack heights: 1 vs 0
		//IL_0238->IL014f: Incompatible stack heights: 2 vs 0
		//IL_00b1->IL014f: Incompatible stack heights: 3 vs 0
		//IL_0100->IL014f: Incompatible stack heights: 3 vs 0
		//IL_013b->IL014f: Incompatible stack heights: 3 vs 0
		if ((object)_InnerColumn != null)
		{
			Transform transform = _InnerColumn.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				_innerColumnStartPosition = ret;
				_ = 0;
				if ((object)_InnerColumn != null)
				{
					Transform transform2 = _InnerColumn.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
						Transform outerColumn = (Transform)(object)_OuterColumn;
						_innerColumnStartScale = ret;
						_ = 0;
						if ((object)_OuterColumn != null)
						{
							bool flag3 = ((UnityEngine.Object)outerColumn).m_CachedPtr == (IntPtr)0;
							SpriteRenderer.get_color_Injected(((UnityEngine.Object)outerColumn).m_CachedPtr, out Color ret2);
							_outerColumnStartColour = ret2;
							Vector2 newPivot = default(Vector2);
							Sprite sprite = SpriteManager.GetSprite("Gradient2", newPivot, "vfx", respectOriginalXPivot: true);
							if ((object)_InnerColumn != null)
							{
								_InnerColumn.sprite = sprite;
								Sprite sprite2 = SpriteManager.GetSprite("Gradient2", newPivot, "vfx", respectOriginalXPivot: true);
								if ((object)_OuterColumn != null)
								{
									_OuterColumn.sprite = sprite2;
									GameObject gameObject = base.gameObject;
									if ((object)gameObject != null)
									{
										gameObject.SetActive(value: false);
										return;
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

	protected override void OnDestroy()
	{
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v50 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	private void Reset()
	{
		//IL_00eb->IL00a5: Incompatible stack heights: 1 vs 0
		//IL_004c->IL00a5: Incompatible stack heights: 1 vs 0
		//IL_013a->IL00a5: Incompatible stack heights: 2 vs 0
		//IL_0082->IL00a5: Incompatible stack heights: 2 vs 0
		//IL_0193->IL00a5: Incompatible stack heights: 3 vs 0
		//IL_01f2->IL00a5: Incompatible stack heights: 4 vs 0
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			MonoBehaviour.StopAllCoroutines_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if ((object)_InnerColumn != null)
			{
				Transform transform = _InnerColumn.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if ((object)_InnerColumn != null)
					{
						Transform transform2 = _InnerColumn.transform;
						if ((object)transform2 != null)
						{
							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value2 = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
							object outerColumnParent = _OuterColumnParent;
							if ((object)_OuterColumnParent != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rsi_v14 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rsi_v14 (System.Object)+10]");
								Vector3 value3 = default(Vector3);
								Transform.set_localScale_Injected((IntPtr)0, ref value3);
								Transform outerColumn = (Transform)(object)_OuterColumn;
								if ((object)_OuterColumn != null)
								{
									bool flag5 = ((UnityEngine.Object)outerColumn).m_CachedPtr == (IntPtr)0;
									Color value4 = default(Color);
									SpriteRenderer.set_color_Injected(((UnityEngine.Object)outerColumn).m_CachedPtr, ref value4);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void PlayTeleportEffect(TeleportPosition position, Action onFadeToBlackComplete, Action onComplete)
	{
		//IL_0119: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_027d: Expected O, but got Ref
		//IL_01f2: Expected O, but got Ref
		//IL_01f7->IL02c8: Incompatible stack heights: 4 vs 5
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass27_0();
		if (CS_0024_003C_003E8__locals8 != null)
		{
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			CS_0024_003C_003E8__locals8.onFadeToBlackComplete = onFadeToBlackComplete;
			CS_0024_003C_003E8__locals8.onComplete = onComplete;
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				Reset();
				Vector3 value = default(Vector3);
				Vector3 value2 = default(Vector3);
				if (position == TeleportPosition.Throne)
				{
					Transform transform = base.transform;
					bool flag = (object)transform == null;
					bool flag2 = ((Delegate)(object)transform).method_ptr == (IntPtr)0;
					Transform.set_localPosition_Injected(((Delegate)(object)transform).method_ptr, ref value);
					Transform transform2 = base.transform;
					bool flag3 = (object)transform2 == null;
					Vector3 scaleAtThrone = _ScaleAtThrone;
					TeleportPosition teleportPosition = (TeleportPosition)(nint)((Delegate)(object)transform2).method_ptr;
					bool flag4 = ((Delegate)(object)transform2).method_ptr == (IntPtr)0;
					object obj = 0;
					object obj2 = (object)(&value2);
				}
				else
				{
					bool flag5 = position != TeleportPosition.Foreground;
					Transform transform3 = base.transform;
					bool flag6 = (object)transform3 == null;
					bool flag7 = ((Delegate)(object)transform3).method_ptr == (IntPtr)0;
					Transform.set_localPosition_Injected(((Delegate)(object)transform3).method_ptr, ref value2);
					Transform transform4 = base.transform;
					bool flag8 = (object)transform4 == null;
					Vector3 scaleAtThrone = _ScaleInForeground;
					TeleportPosition teleportPosition = (TeleportPosition)(nint)((Delegate)(object)transform4).method_ptr;
					bool flag9 = ((Delegate)(object)transform4).method_ptr == (IntPtr)0;
					object obj = 0;
					object obj2 = (object)(&value);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1030 @ rax_v44 (should have been resolved before IL gen)");
				Action onScaleInComplete = delegate
				{
					_003COuterColumnCoroutine_003Ed__29 obj4 = null;
					obj4._003C_003E1__state = 0;
					obj4._003C_003E4__this = CS_0024_003C_003E8__locals8._003C_003E4__this;
					obj4.onFadeToBlackComplete = CS_0024_003C_003E8__locals8.onFadeToBlackComplete;
					obj4.onComplete = CS_0024_003C_003E8__locals8.onComplete;
					Coroutine coroutine2 = CS_0024_003C_003E8__locals8._003C_003E4__this.StartCoroutine(obj4);
				};
				_003CInnerColumnCoroutine_003Ed__28 obj3 = null;
				obj3._003C_003E1__state = 0;
				obj3._003C_003E4__this = this;
				obj3.onScaleInComplete = onScaleInComplete;
				Coroutine coroutine = StartCoroutine(obj3);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator InnerColumnCoroutine(Action onScaleInComplete)
	{
		_003CInnerColumnCoroutine_003Ed__28 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.onScaleInComplete = onScaleInComplete;
		return obj;
	}

	private IEnumerator OuterColumnCoroutine(Action onFadeToBlackComplete, Action onComplete)
	{
		_003COuterColumnCoroutine_003Ed__29 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.onFadeToBlackComplete = onFadeToBlackComplete;
		obj.onComplete = onComplete;
		return obj;
	}

	private IEnumerator ScaleTransform(Transform transformToScale, Vector3 startScale, Vector3 endScale, float duration)
	{
		//IL_0017: Expected O, but got F4
		//IL_0029: Expected O, but got F4
		_003CScaleTransform_003Ed__30 obj = null;
		obj._003C_003E1__state = 0;
		obj.transformToScale = transformToScale;
		obj.startScale = (Vector3)startScale.x;
		obj.endScale = (Vector3)endScale.x;
		_ = startScale.z;
		_ = endScale.z;
		float duration2 = default(float);
		obj.duration = duration2;
		return obj;
	}

	private IEnumerator ColourTween(SpriteRenderer spriteRenderer, Color startColour, Color endColour, float duration)
	{
		//IL_0017: Expected O, but got F4
		//IL_0036: Expected O, but got F4
		_003CColourTween_003Ed__31 obj = null;
		obj._003C_003E1__state = 0;
		obj.spriteRenderer = spriteRenderer;
		obj.startColour = (Color)startColour.r;
		float duration2 = default(float);
		obj.duration = duration2;
		obj.endColour = (Color)endColour.r;
		return obj;
	}

	private IEnumerator WaitForSecondsPausable(float seconds)
	{
		_003CWaitForSecondsPausable_003Ed__32 obj = null;
		obj.seconds = seconds;
		obj._003C_003E1__state = 0;
		return obj;
	}

	public DraculaCutsceneTeleport()
	{
		//IL_0015: Expected I, but got O
		//IL_005b: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_ScaleAtThrone = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		base._onResumeSent = true;
		nint num3 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
