using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics.Blitters;

namespace VampireSurvivors.Objects;

public class BobGroup : IDisposable
{
	public enum TweenState
	{
		Showing,
		Holding,
		Hiding,
		Completed
	}

	private const int GrowAmount = 64;

	private static Stack<BobGroup> emptyGroups;

	public TweenState tweenState;

	private List<Bob> _bobs;

	private Vector2 _basePosition;

	private Vector2 _raisedPosition;

	private Vector2 _baseScale;

	private Vector2 _raisedScale;

	private Vector2 _currentScale;

	private float _progress;

	private float _currentTime;

	private float _targetTime;

	private float _showDuration;

	private float _holdDuration;

	private float _hideDuration;

	private int _intCount;

	private float _characterWidth;

	private readonly List<float> _baseXPositions;

	private readonly List<float> _xDifferences;

	private bool _disposed;

	private BobGroup()
	{
		//IL_0065: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0083: Expected I, but got O
		//IL_00c6: Expected O, but got F4
		//IL_00d6: Expected O, but got I4
		//IL_000a: Expected I, but got O
		//IL_0023: Expected I, but got O
		_basePosition = (Vector2)0;
		_raisedPosition = (Vector2)0;
		_baseScale = Vector3.zeroVector;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = (float)Vector3.oneVector * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num4 = 0f * 2f;
		_raisedScale = (Vector2)num3;
		_currentScale = (Vector2)0;
		_progress = 0f;
		_targetTime = 0f;
		_showDuration = 0.3f;
		_holdDuration = 0.01f;
		_hideDuration = 0.65f;
		_characterWidth = 0f;
		List<float> baseXPositions = null;
		nint num5 = unchecked((nint)null);
		_baseXPositions = baseXPositions;
		List<float> xDifferences = null;
		nint num6 = unchecked((nint)null);
		_xDifferences = xDifferences;
		List<Bob> list = null;
		Bob[] items = null;
		list._items = items;
		_bobs = list;
		tweenState = TweenState.Showing;
	}

	private void Reset()
	{
		//IL_00eb: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_0109: Expected I, but got O
		//IL_014c: Expected O, but got F4
		//IL_015c: Expected O, but got I4
		_basePosition = (Vector2)0;
		_raisedPosition = (Vector2)0;
		_baseScale = Vector3.zeroVector;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = (float)Vector3.oneVector * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num4 = 0f * 2f;
		_raisedScale = (Vector2)num3;
		_currentScale = (Vector2)0;
		List<float> baseXPositions = _baseXPositions;
		_progress = 0f;
		_targetTime = 0f;
		_showDuration = 0.3f;
		_holdDuration = 0.01f;
		_hideDuration = 0.65f;
		_characterWidth = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<float> xDifferences = _xDifferences;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<Bob> bobs = _bobs;
		int version = bobs._version + 1;
		bobs._version = version;
		bobs._size = 0;
		if (bobs._size > 0)
		{
			Array.Clear(bobs._items, 0, bobs._size);
		}
		_disposed = false;
		tweenState = TweenState.Showing;
	}

	public unsafe static BobGroup Create()
	{
		//IL_0055: Expected O, but got Ref
		//IL_0070: Expected O, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		Stack<BobGroup> stack = emptyGroups;
		if (emptyGroups != null)
		{
			if (stack._size != 0)
			{
				goto IL_0153;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Grow bob groups by {0}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			object obj2 = 0;
			while (true)
			{
				BobGroup item = new BobGroup();
				if (emptyGroups == null)
				{
					break;
				}
				((Stack<object>)(object)emptyGroups).Push((object)item);
				obj2++;
				if ((nint)obj2 >= 64)
				{
					goto IL_0153;
				}
			}
		}
		goto IL_00e7;
		IL_0153:
		if (emptyGroups != null)
		{
			object obj3 = ((Stack<object>)(object)emptyGroups).Pop();
			if (obj3 != null)
			{
				((BobGroup)obj3).Reset();
				return (BobGroup)obj3;
			}
		}
		goto IL_00e7;
		IL_00e7:
		return (BobGroup)(object)new NullReferenceException();
	}

	public void SetIntCount(int num)
	{
		_intCount = num;
	}

	public void Update(float deltaTime)
	{
		//IL_0075: Expected O, but got I4
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_0383: Expected F4, but got I4
		//IL_038c: Expected F4, but got I4
		//IL_07c4: Invalid comparison between I4 and F4
		//IL_03c8: Expected F4, but got I4
		//IL_0721: Expected O, but got I
		//IL_077b: Expected O, but got F4
		//IL_0790: Invalid comparison between F4 and I
		//IL_03dd: Expected O, but got I
		//IL_040f: Expected O, but got I
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Expected O, but got Unknown
		//IL_04e0: Expected O, but got I
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_0539: Invalid comparison between F4 and I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0107: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_05fa: Expected I, but got O
		//IL_061f: Invalid comparison between I4 and F4
		//IL_014c: Expected F4, but got I4
		//IL_0660: Expected O, but got I
		//IL_06ba: Expected O, but got F4
		//IL_0161: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_022c: Expected O, but got I
		//IL_024b: Expected O, but got I
		//IL_026a: Expected O, but got I
		//IL_0289: Expected O, but got I
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		float num = deltaTime + _currentTime;
		List<Bob> bobs = _bobs;
		_currentTime = num;
		float progress = num / _targetTime;
		_progress = progress;
		if (_bobs != null && bobs._items != null)
		{
			bool flag = tweenState == TweenState.Showing;
			if (!flag)
			{
				object obj = tweenState - 1;
				if (flag)
				{
					if (!(_progress < 1f))
					{
						_progress = 0f;
						_targetTime = _hideDuration;
						tweenState = TweenState.Hiding;
					}
					return;
				}
				if ((nint)obj != 1)
				{
					return;
				}
				if (!(_progress < 1f))
				{
					tweenState = TweenState.Completed;
					return;
				}
				if (bobs._size <= 0)
				{
					return;
				}
				object obj2 = bobs._items + 32;
				object obj3 = 0;
				object obj4 = 0;
				while (true)
				{
					object obj5 = obj2;
					nint num2 = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rax_v18 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num3 = 0;
					float num4 = _progress;
					if (!(0f > _progress))
					{
						if (num4 > 1f)
						{
							num4 = 1f;
						}
					}
					else
					{
						num4 = 0f;
					}
					object obj6 = Vector2.oneVector - _raisedScale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+3C]");
					object obj7 = num5 - 0;
					float num6 = (float)obj6 * num4;
					float num7 = (float)obj7 * num4;
					float num8 = num6 + (float)_raisedScale;
					float num9 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+3C]");
					float num10 = num9 + 0f;
					List<float> xDifferences = _xDifferences;
					_currentScale = (Vector2)num8;
					object obj8 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rcx_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)obj8 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rcx_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+2C]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+2C]");
					object obj10 = num11 - 0;
					float num12 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rcx_v18+20+v509 @ rdi_v11*4]");
					float num13 = num12 * 0f;
					object obj11 = obj10 * _progress;
					float num14 = num13 + (float)_basePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+2C]");
					object obj12 = obj11 + 0;
					float num15 = num14 - num14;
					float num16 = num15 * _progress;
					float num17 = num16 + num14;
					_ = _currentScale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+44]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rsi_v9+28]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rsi_v9+28]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rsi_v9+28]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rsi_v9+28]");
					object obj16 = 0;
					object obj17 = obj4 + 1;
					obj3++;
					obj2 += 8;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					bool flag2 = (nint)obj3 < bobs._size;
					obj4 = obj17;
					if (!flag2)
					{
						return;
					}
				}
			}
			else
			{
				if (bobs._size <= 0)
				{
					goto IL_0555;
				}
				object obj18 = bobs._items + 32;
				float num18 = 0f;
				float num19 = 0f;
				while (true)
				{
					float num20 = _progress;
					object obj19 = obj18;
					if (!(0f > _progress))
					{
						if (num20 > 1f)
						{
							num20 = 1f;
						}
					}
					else
					{
						num20 = 0f;
					}
					object obj20 = _raisedScale - _baseScale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+3C]");
					nint num21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+34]");
					object obj21 = num21 - 0;
					float num22 = (float)obj20 * num20;
					float num23 = (float)obj21 * num20;
					float num24 = num22 + (float)_baseScale;
					float num25 = num23;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+34]");
					float num26 = num25 + 0f;
					List<float> xDifferences2 = _xDifferences;
					_currentScale = (Vector2)num24;
					float num27 = num19;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
					if (!(num27 < 0f))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v10 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj22 = 0;
					num18++;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+2C]");
					nint num28 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+24]");
					object obj23 = num28 - 0;
					obj18 += 8;
					float num29 = num19 + 1f;
					float num30 = num24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rcx_v11+20+v417 @ rdx_v6 (System.Single)*4]");
					float num31 = num30 * 0f;
					object obj24 = obj23 * _progress;
					float num32 = num31 + (float)_basePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+24]");
					object obj25 = obj24 + 0;
					float num33 = num32 - num32;
					float num34 = num33 * _progress;
					float num35 = num34 + num32;
					object obj26 = _raisedScale - _baseScale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+3C]");
					nint num36 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+34]");
					object obj27 = num36 - 0;
					object obj28 = obj26 * _progress;
					object obj29 = obj27 * _progress;
					object obj30 = obj28 + (object)_baseScale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.BobGroup)+34]");
					object obj31 = obj29 + 0;
					bool flag3 = num18 < (float)bobs._size;
					num19 = num29;
					if (flag3)
					{
						continue;
					}
					goto IL_0555;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		else
		{
			tweenState = TweenState.Completed;
		}
		return;
		IL_0555:
		if (!(_progress < 1f))
		{
			_targetTime = _holdDuration;
			_progress = 0f;
			tweenState = TweenState.Holding;
		}
	}

	public void Start(Vector2 basePos, float raise = 2f)
	{
		//IL_0076: Expected O, but got F4
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_03a9: Expected O, but got I4
		//IL_0102: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_016d: Expected O, but got I
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_0152: Expected F4, but got O
		//IL_01a6: Expected O, but got I
		//IL_0200: Expected O, but got I
		object obj = default(object);
		float num = (float)obj + 0.15f;
		_basePosition = basePos;
		List<Bob> bobs = _bobs;
		_raisedPosition = basePos;
		if (bobs._size > 0)
		{
			Bob[] items = bobs._items;
			Bob bob = items[0];
			float characterWidth = (float)bob.halfSize + (float)bob.halfSize;
			_raisedScale = (Vector2)raise;
			_characterWidth = characterWidth;
			float num2 = (float)_intCount * 0.5f;
			float num3 = num2 * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			if (_intCount <= 1)
			{
				List<float> baseXPositions = _baseXPositions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v8+18]");
				if (num4 >= 0)
				{
					baseXPositions.AddWithResize((float)_basePosition);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj4 = (nint)0 + (nint)1;
					_ = _basePosition;
				}
				List<float> xDifferences = _xDifferences;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r8_v10+18]");
				if (num5 >= 0)
				{
					xDifferences.AddWithResize(0f);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj6 = (nint)0 + (nint)1;
					_ = 0;
				}
			}
			else
			{
				object obj8 = default(object);
				object obj7 = _intCount + obj8;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
				object obj9 = obj8;
				if (!flag)
				{
					object obj13;
					do
					{
						int num6 = _intCount & 1;
						bool flag2 = num6 == 0;
						float num7 = _characterWidth;
						object obj10 = obj9 * _characterWidth;
						object obj11 = obj10 + (object)_basePosition;
						object obj12 = !flag2;
						if (obj12 == null)
						{
							num7 *= 0.5f;
						}
						float num8 = (float)obj11 + num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD60");
						float num9 = (float)_basePosition - num8;
						float num10 = num9 * -1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD60");
						obj9++;
						obj13 = _intCount + obj8;
					}
					while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13));
				}
			}
			_progress = 0f;
			tweenState = TweenState.Showing;
			_targetTime = _showDuration;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	private void Show()
	{
		_progress = 0f;
		tweenState = TweenState.Showing;
		_targetTime = _showDuration;
	}

	[MethodImpl((MethodImplOptions)256)]
	private void Hold()
	{
		_progress = 0f;
		_targetTime = _holdDuration;
		tweenState = TweenState.Holding;
	}

	[MethodImpl((MethodImplOptions)256)]
	private void Hide()
	{
		_progress = 0f;
		_targetTime = _hideDuration;
		tweenState = TweenState.Hiding;
	}

	[MethodImpl((MethodImplOptions)256)]
	private void Complete()
	{
		tweenState = TweenState.Completed;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			((Stack<object>)(object)emptyGroups).Push((object)this);
		}
	}

	public unsafe void RemoveBobs(Blitter blitter)
	{
		//IL_0026: Expected O, but got Ref
		//IL_00e6: Expected I4, but got O
		//IL_00e6: Expected O, but got I4
		bool flag = _bobs == null;
		BobGroup bobGroup = this;
		if (!flag)
		{
			List<Bob>.Enumerator enumerator = default(List<Bob>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				bool flag2 = (object)blitter == null;
				List<Bob>.Enumerator enumerator2 = (List<Bob>.Enumerator)(&enumerator);
				if (!flag2)
				{
					if (blitter._bobs != null)
					{
						bool flag3 = ((List<object>)(object)blitter._bobs).Remove((object)null);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			bobGroup = (BobGroup)(object)_bobs;
			if (_bobs != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v4 (VampireSurvivors.Objects.BobGroup)+1C]");
				_ = (nint)0 + (nint)1;
				bobGroup._bobs = null;
				if ((nint)bobGroup._bobs > 0)
				{
					Array.Clear((Array)bobGroup.tweenState, 0, (int)bobGroup._bobs);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void AddBob(Bob bob)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA20D0");
	}

	static BobGroup()
	{
		Stack<BobGroup> stack = new Stack<BobGroup>(128);
		emptyGroups = stack;
	}
}
