using System;
using System.Collections.Generic;
using System.Threading;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors;

public class TreasureFireworksManager : MonoBehaviour
{
	private GameObject _ParticlePrefab;

	private Material _BaseParticleMaterial;

	private List<Sprite> _Sprites;

	private Image _WhiteBackground;

	private float _MaxOffsetX;

	private float _MaxOffsetY;

	private ParticleSystemForceField _ForceField;

	private GameObject _FireworksRenderTextureView;

	private List<KeyValuePair<ParticleSystem, int>> _fireworks;

	private List<Material> _materials;

	private void Start()
	{
	}

	public unsafe void PlayFireWorks()
	{
		//IL_00b4: Expected I4, but got O
		//IL_00b4: Expected O, but got I
		//IL_01ea: Expected O, but got Ref
		//IL_0f99: Expected O, but got I4
		//IL_0fce: Expected O, but got I
		//IL_0254: Expected O, but got I
		//IL_02be: Expected O, but got I
		//IL_1018: Unknown result type (might be due to invalid IL or missing references)
		//IL_101d: Expected O, but got Unknown
		//IL_04a2: Expected I, but got O
		//IL_04b8: Expected O, but got I
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		//IL_052f: Expected I, but got O
		//IL_106d: Expected O, but got I4
		//IL_1084: Expected I, but got I8
		//IL_0518: Expected I, but got I8
		//IL_0747: Expected I, but got O
		//IL_075d: Expected O, but got I
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Expected O, but got Unknown
		//IL_07d4: Expected I, but got O
		//IL_116f: Expected I, but got I8
		//IL_07bd: Expected I, but got I8
		//IL_0949: Expected I, but got O
		//IL_095f: Expected O, but got I
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Expected O, but got Unknown
		//IL_09d6: Expected I, but got O
		//IL_11de: Expected I, but got I8
		//IL_09bf: Expected I, but got I8
		//IL_0c22: Expected I, but got O
		//IL_0c38: Expected O, but got I
		//IL_0c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c46: Expected O, but got Unknown
		//IL_0cb4: Expected I, but got O
		//IL_128b: Expected I, but got I8
		//IL_0c87: Expected I, but got I8
		//IL_0290->IL1321: Incompatible stack heights: 2 vs 1
		//IL_1035->IL134b: Incompatible stack heights: 3 vs 0
		//IL_0313->IL1005: Incompatible stack heights: 4 vs 3
		List<KeyValuePair<ParticleSystem, int>> fireworks = _fireworks;
		bool flag = _fireworks == null;
		TreasureFireworksManager treasureFireworksManager = this;
		Sequence sequence;
		if (!flag)
		{
			List<KeyValuePair<ParticleSystem, int>>.Enumerator enumerator = default(List<KeyValuePair<ParticleSystem, int>>.Enumerator);
			if (enumerator.MoveNext())
			{
				Component component = null;
				throw new NullReferenceException();
			}
			treasureFireworksManager = (TreasureFireworksManager)(object)_fireworks;
			if (_fireworks != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v20 (VampireSurvivors.TreasureFireworksManager)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)treasureFireworksManager).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)treasureFireworksManager).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)treasureFireworksManager).m_CachedPtr, 0, (int)((MonoBehaviour)treasureFireworksManager).m_CancellationTokenSource);
					fireworks = null;
				}
				CancellationTokenSource cancellationTokenSource = null;
				object obj = default(object);
				Vector2 anchoredPosition3 = default(Vector2);
				object obj2 = default(object);
				do
				{
					Transform parent = base.transform;
					GameObject gameObject = UnityEngine.Object.Instantiate(_ParticlePrefab, parent);
					RectTransform component2 = gameObject.GetComponent<RectTransform>();
					ParticleSystem component3 = gameObject.GetComponent<ParticleSystem>();
					float minInclusive = _MaxOffsetX ^ -0f;
					float num = UnityEngine.Random.Range(minInclusive, _MaxOffsetX);
					float minInclusive2 = _MaxOffsetY ^ -0f;
					float num2 = UnityEngine.Random.Range(minInclusive2, _MaxOffsetY);
					Vector2 anchoredPosition = component2.anchoredPosition;
					Vector2 anchoredPosition2 = component2.anchoredPosition;
					float num3 = (float)obj + num2;
					component2.anchoredPosition = anchoredPosition3;
					float num4 = (float)cancellationTokenSource / 5f;
					float num5 = num4 * 32f;
					float num6 = num5 + num5;
					float num7 = num6 + 32f;
					double num8 = Math.Round(num7);
					_fireworks.Add((KeyValuePair<ParticleSystem, int>)(&obj2));
					List<Sprite> sprites = _Sprites;
					KeyValuePair<ParticleSystem, int> keyValuePair = (KeyValuePair<ParticleSystem, int>)UnityEngine.Random.RandomRangeInt(0, sprites._size);
					bool flag2 = (nint)keyValuePair >= sprites._size;
					Sprite[] items = sprites._items;
					Sprite sprite = items[(object)keyValuePair];
					if ((object)items[(object)keyValuePair] != null)
					{
						CancellationTokenSource cancellationTokenSource2 = (CancellationTokenSource)(nint)((UnityEngine.Object)sprite).m_CachedPtr;
					}
					else
					{
						CancellationTokenSource cancellationTokenSource2 = null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						bool flag3 = obj3 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1381 @ rax_v55 (should have been resolved before IL gen)");
					GameObject forceField = (GameObject)(object)_ForceField;
					bool flag4 = (object)_ForceField == null;
					bool flag5 = ((UnityEngine.Object)forceField).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCB8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCB8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						bool flag6 = obj4 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1490 @ rax_v60 (should have been resolved before IL gen)");
					cancellationTokenSource = (CancellationTokenSource)(cancellationTokenSource + 1);
				}
				while ((nint)cancellationTokenSource < 5);
				sequence = DOTween.Sequence();
				object message;
				if (sequence != null)
				{
					if (((Tween)sequence)._003Cactive_003Ek__BackingField)
					{
						if (!((Tween)sequence).creationLocked)
						{
							sequence.lastTweenInsertTime = ((Tween)sequence).duration;
							float duration = ((Tween)sequence).duration + 0.1f;
							((Tween)sequence).duration = duration;
							goto IL_0457;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						message = "You can't add elements to an inactive/killed Sequence";
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message = "You can't add elements to a NULL Sequence";
				}
				Debugger.LogWarning(message);
				goto IL_0457;
			}
		}
		throw new NullReferenceException();
		IL_1158:
		TweenCallback tweenCallback;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Sequence sequence2 = TweenSettingsExtensions.AppendCallback(sequence, tweenCallback);
		float num9;
		object message2;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					sequence.lastTweenInsertTime = ((Tween)sequence).duration;
					float duration2 = ((Tween)sequence).duration + num9;
					((Tween)sequence).duration = duration2;
					goto IL_08fe;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message2);
		goto IL_08fe;
		IL_060d:
		object message3;
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				sequence.lastTweenInsertTime = ((Tween)sequence).duration;
				float duration3 = ((Tween)sequence).duration + 0.3f;
				((Tween)sequence).duration = duration3;
				num9 = 0.3f;
				goto IL_10bd;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message3 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_1378;
		IL_1064:
		object obj5 = 24;
		TweenCallback tweenCallback2;
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		if (sequence != null)
		{
			object message4;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
					goto IL_060d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "You can't add elements to an inactive/killed Sequence";
			}
			Debugger.LogWarning(message4);
			goto IL_060d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Debugger.LogWarning("You can't add elements to a NULL Sequence");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		message3 = "You can't add elements to a NULL Sequence";
		goto IL_1378;
		IL_0457:
		tweenCallback2 = null;
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1634 @ r10_v11 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback2).method = (nint)__ldftn(TreasureFireworksManager._003CPlayFireWorks_003Eb__11_0);
		((Delegate)tweenCallback2).m_target = this;
		((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1634 @ r10_v11 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num11;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1634 @ r10_v11 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num11 = unchecked((nint)6447293664L);
				goto IL_1064;
			}
		}
		((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
		num11 = ((Delegate)tweenCallback2).method_ptr;
		goto IL_1064;
		IL_1378:
		Debugger.LogWarning(message3);
		num9 = 0.3f;
		goto IL_10bd;
		IL_08fe:
		TweenCallback tweenCallback3 = null;
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2248 @ r10_v13 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback3).method = (nint)__ldftn(TreasureFireworksManager._003CPlayFireWorks_003Eb__11_2);
		((Delegate)tweenCallback3).m_target = this;
		((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2248 @ r10_v13 (Il2CppMethodInfo)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		nint num13;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2248 @ r10_v13 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num13 = unchecked((nint)6447293664L);
				goto IL_11c7;
			}
		}
		((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
		num13 = ((Delegate)tweenCallback3).method_ptr;
		goto IL_11c7;
		IL_10bd:
		tweenCallback = null;
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2004 @ r10_v12 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(TreasureFireworksManager._003CPlayFireWorks_003Eb__11_1);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2004 @ r10_v12 (Il2CppMethodInfo)+4C]");
		object obj10 = (nint)0 >> 4;
		object obj11 = obj10 & 1;
		nint num15;
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2004 @ r10_v12 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num15 = unchecked((nint)6447293664L);
				goto IL_1158;
			}
		}
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		num15 = ((Delegate)tweenCallback).method_ptr;
		goto IL_1158;
		IL_0ea8:
		TweenCallback callback = delegate
		{
			//IL_003d: Expected O, but got I
			//IL_007a: Expected O, but got I
			//IL_00a6: Expected O, but got I
			List<KeyValuePair<ParticleSystem, int>> fireworks2 = _fireworks;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
			if ((nint)0 > (nint)4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
				if ((nint)0 > (nint)4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+60]");
					nint num18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9+60]");
					((ParticleSystem)num18).Emit(0);
					DoFlash();
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		};
		Sequence sequence4 = TweenSettingsExtensions.AppendCallback(sequence, callback);
		return;
		IL_0ab4:
		object message5;
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				sequence.lastTweenInsertTime = ((Tween)sequence).duration;
				float duration4 = ((Tween)sequence).duration + num9;
				((Tween)sequence).duration = duration4;
				goto IL_0bd7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message5 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message5 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_13ae;
		IL_0d85:
		object message6;
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				sequence.lastTweenInsertTime = ((Tween)sequence).duration;
				float duration5 = ((Tween)sequence).duration + num9;
				((Tween)sequence).duration = duration5;
				goto IL_0ea8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message6 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message6 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_13cc;
		IL_13cc:
		Debugger.LogWarning(message6);
		goto IL_0ea8;
		IL_13ae:
		Debugger.LogWarning(message5);
		goto IL_0bd7;
		IL_1274:
		TweenCallback tweenCallback4;
		((Delegate)tweenCallback4).extra_arg = unchecked((nint)6447293568L);
		if (sequence != null)
		{
			object message7;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					Sequence sequence5 = Sequence.DoInsertCallback(sequence, tweenCallback4, ((Tween)sequence).duration);
					goto IL_0d85;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message7 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message7 = "You can't add elements to an inactive/killed Sequence";
			}
			Debugger.LogWarning(message7);
			goto IL_0d85;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Debugger.LogWarning("You can't add elements to a NULL Sequence");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		message6 = "You can't add elements to a NULL Sequence";
		goto IL_13cc;
		IL_0bd7:
		tweenCallback4 = null;
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ r10_v14 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback4).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback4).method = (nint)__ldftn(TreasureFireworksManager._003CPlayFireWorks_003Eb__11_3);
		((Delegate)tweenCallback4).m_target = this;
		((Delegate)tweenCallback4).method_code = (IntPtr)tweenCallback4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ r10_v14 (Il2CppMethodInfo)+4C]");
		object obj12 = (nint)0 >> 4;
		object obj13 = obj12 & 1;
		nint num17;
		if (obj13 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ r10_v14 (Il2CppMethodInfo)+52]");
			bool flag7 = (nint)0 == 0;
			num17 = unchecked((nint)6447293664L);
			if (flag7)
			{
				goto IL_1274;
			}
		}
		num17 = ((Delegate)tweenCallback4).method_ptr;
		((Delegate)tweenCallback4).method_code = (IntPtr)((Delegate)tweenCallback4).m_target;
		goto IL_1274;
		IL_11c7:
		((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
		if (sequence != null)
		{
			object message8;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					Sequence sequence6 = Sequence.DoInsertCallback(sequence, tweenCallback3, ((Tween)sequence).duration);
					goto IL_0ab4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message8 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message8 = "You can't add elements to an inactive/killed Sequence";
			}
			Debugger.LogWarning(message8);
			goto IL_0ab4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Debugger.LogWarning("You can't add elements to a NULL Sequence");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		message5 = "You can't add elements to a NULL Sequence";
		goto IL_13ae;
	}

	public int OrderInLayer()
	{
		if ((object)_FireworksRenderTextureView != null)
		{
			Canvas component = _FireworksRenderTextureView.GetComponent<Canvas>();
			if ((object)component != null)
			{
				bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 74 ConditionalJump @-1, v129 @ ZF_v8 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}
		throw new NullReferenceException();
	}

	public void OrderInLayer(int newLayer)
	{
		Canvas component = _FireworksRenderTextureView.GetComponent<Canvas>();
		component.sortingOrder = newLayer;
	}

	private void DoFlash()
	{
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_WhiteBackground, 0.3f, 0.03f);
		TweenCallback tweenCallback = delegate
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_WhiteBackground, 0f, 0.03f);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	public TreasureFireworksManager()
	{
		List<Sprite> sprites = new List<Sprite>();
		_Sprites = sprites;
		List<KeyValuePair<ParticleSystem, int>> fireworks = new List<KeyValuePair<ParticleSystem, int>>();
		_fireworks = fireworks;
		List<Material> materials = new List<Material>();
		_materials = materials;
	}

	private void _003CPlayFireWorks_003Eb__11_0()
	{
		//IL_003d: Expected O, but got I
		//IL_007a: Expected O, but got I
		//IL_00a6: Expected O, but got I
		List<KeyValuePair<ParticleSystem, int>> fireworks = _fireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9+20]");
				((ParticleSystem)num).Emit(0);
				DoFlash();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CPlayFireWorks_003Eb__11_1()
	{
		//IL_003d: Expected O, but got I
		//IL_007a: Expected O, but got I
		//IL_00a6: Expected O, but got I
		List<KeyValuePair<ParticleSystem, int>> fireworks = _fireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
		if ((nint)0 > (nint)1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
			if ((nint)0 > (nint)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+30]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9+30]");
				((ParticleSystem)num).Emit(0);
				DoFlash();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CPlayFireWorks_003Eb__11_2()
	{
		//IL_003d: Expected O, but got I
		//IL_007a: Expected O, but got I
		//IL_00a6: Expected O, but got I
		List<KeyValuePair<ParticleSystem, int>> fireworks = _fireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
		if ((nint)0 > (nint)2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
			if ((nint)0 > (nint)2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+40]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9+40]");
				((ParticleSystem)num).Emit(0);
				DoFlash();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CPlayFireWorks_003Eb__11_3()
	{
		//IL_003d: Expected O, but got I
		//IL_007a: Expected O, but got I
		//IL_00a6: Expected O, but got I
		List<KeyValuePair<ParticleSystem, int>> fireworks = _fireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
		if ((nint)0 > (nint)3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
			if ((nint)0 > (nint)3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+50]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9+50]");
				((ParticleSystem)num).Emit(0);
				DoFlash();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CPlayFireWorks_003Eb__11_4()
	{
		//IL_003d: Expected O, but got I
		//IL_007a: Expected O, but got I
		//IL_00a6: Expected O, but got I
		List<KeyValuePair<ParticleSystem, int>> fireworks = _fireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
		if ((nint)0 > (nint)4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+18]");
			if ((nint)0 > (nint)4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<UnityEngine.ParticleSystem, System.Int32>>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+60]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9+60]");
				((ParticleSystem)num).Emit(0);
				DoFlash();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CDoFlash_003Eb__14_0()
	{
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_WhiteBackground, 0f, 0.03f);
	}
}
