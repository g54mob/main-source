using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Events;
using Doozy.Engine.Soundy;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI.Base;

[Serializable]
public class UIAction
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<GameObject> _003C_003E9__23_0;

		public static Func<AnimatorEvent, bool> _003C_003E9__25_0;

		public static Func<string, bool> _003C_003E9__27_0;

		public static Action<GameObject> _003C_003E9__35_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ector_003Eb__23_0(GameObject _003Cp0_003E)
		{
		}

		internal bool _003CAddAnimatorEvents_003Eb__25_0(AnimatorEvent x)
		{
			bool flag = x == null;
			return !flag;
		}

		internal bool _003CAddGameEvents_003Eb__27_0(string s)
		{
			if (s != null && s._stringLength > 0)
			{
				return true;
			}
			return false;
		}

		internal void _003CReset_003Eb__35_0(GameObject _003Cp0_003E)
		{
		}
	}

	public Action<GameObject> Action;

	public List<AnimatorEvent> AnimatorEvents;

	public UIEffect Effect;

	public UnityEvent Event;

	public List<string> GameEvents;

	public SoundyData SoundData;

	private Canvas m_canvasForEffect;

	public int AnimatorEventsCount
	{
		get
		{
			//IL_001d: Expected I4, but got O
			List<AnimatorEvent> animatorEvents = AnimatorEvents;
			if (AnimatorEvents != null)
			{
				return animatorEvents._size;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public int GameEventsCount
	{
		get
		{
			//IL_001d: Expected I4, but got O
			List<string> gameEvents = GameEvents;
			if (GameEvents != null)
			{
				return gameEvents._size;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public bool HasAnimatorEvents
	{
		get
		{
			//IL_00c6: Expected I4, but got O
			if (AnimatorEvents == null)
			{
				return false;
			}
			List<AnimatorEvent> animatorEvents = AnimatorEvents;
			if (AnimatorEvents != null)
			{
				int num = animatorEvents._size ^ animatorEvents._size;
				int num2 = animatorEvents._size & num;
				bool flag = num2 < 0;
				bool flag2 = animatorEvents._size < 0;
				bool flag3 = animatorEvents._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasEffect
	{
		get
		{
			if (Effect != null)
			{
				UIEffect effect = Effect;
				ParticleSystem particleSystem = effect.ParticleSystem;
				if ((object)effect.ParticleSystem != null)
				{
					bool flag = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
	}

	public bool HasGameEvents
	{
		get
		{
			//IL_00c6: Expected I4, but got O
			if (GameEvents == null)
			{
				return false;
			}
			List<string> gameEvents = GameEvents;
			if (GameEvents != null)
			{
				int num = gameEvents._size ^ gameEvents._size;
				int num2 = gameEvents._size & num;
				bool flag = num2 < 0;
				bool flag2 = gameEvents._size < 0;
				bool flag3 = gameEvents._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public unsafe bool HasSound
	{
		get
		{
			//IL_02d2: Expected I4, but got O
			//IL_003a: Expected O, but got I4
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected Ref, but got Unknown
			//IL_020e: Expected I8, but got I4
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected Ref, but got Unknown
			SoundyData soundData = SoundData;
			if (SoundData != null)
			{
				bool flag = soundData.SoundSource == SoundSource.Soundy;
				if (!flag)
				{
					object obj = soundData.SoundSource - 1;
					if (!flag)
					{
						if ((nint)obj == 1)
						{
							SoundyData soundData2 = SoundData;
							string soundName = soundData2.SoundName;
							if (soundData2.SoundName != null && soundName._stringLength > 0)
							{
								goto IL_00c6;
							}
						}
					}
					else
					{
						SoundyData soundData3 = SoundData;
						AudioClip audioClip = soundData3.AudioClip;
						if ((object)soundData3.AudioClip != null)
						{
							bool flag2 = ((UnityEngine.Object)audioClip).m_CachedPtr == (IntPtr)0;
							return !flag2;
						}
					}
				}
				else
				{
					SoundyData soundData4 = SoundData;
					if (SoundData == null)
					{
						goto IL_02c4;
					}
					string soundName2 = soundData4.SoundName;
					object obj2 = "No Sound";
					if ((object)soundData4.SoundName != "No Sound")
					{
						if (soundData4.SoundName != null && "No Sound" != null)
						{
							int stringLength = soundName2._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v3+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("No Sound" + 20);
								ulong length = (ulong)(soundName2._stringLength + soundName2._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref *(byte*)(soundData4.SoundName + 20), ref second, length))
								{
									goto IL_02be;
								}
							}
						}
						SoundyData soundData5 = SoundData;
						if (SoundData == null)
						{
							goto IL_02c4;
						}
						string soundName3 = soundData5.SoundName;
						if (soundData5.SoundName != null && soundName3._stringLength > 0)
						{
							goto IL_00c6;
						}
					}
				}
				goto IL_02be;
			}
			goto IL_02c4;
			IL_00c6:
			return true;
			IL_02c4:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_02be:
			return false;
		}
	}

	public bool HasUnityEvent
	{
		get
		{
			//IL_00ff: Expected I4, but got O
			if (Event == null)
			{
				return false;
			}
			UnityEvent unityEvent = Event;
			UnityEngine.Events.PersistentCallGroup persistentCalls = ((UnityEventBase)unityEvent).m_PersistentCalls;
			if (((UnityEventBase)unityEvent).m_PersistentCalls != null)
			{
				List<UnityEngine.Events.PersistentCall> calls = persistentCalls.m_Calls;
				if (persistentCalls.m_Calls != null)
				{
					int num = calls._size ^ calls._size;
					int num2 = calls._size & num;
					bool flag = num2 < 0;
					bool flag2 = calls._size < 0;
					bool flag3 = calls._size == 0;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public int UnityEventListenerCount
	{
		get
		{
			//IL_0075: Expected I4, but got O
			UnityEvent unityEvent = Event;
			if (Event != null)
			{
				UnityEngine.Events.PersistentCallGroup persistentCalls = ((UnityEventBase)unityEvent).m_PersistentCalls;
				if (((UnityEventBase)unityEvent).m_PersistentCalls != null)
				{
					List<UnityEngine.Events.PersistentCall> calls = persistentCalls.m_Calls;
					if (persistentCalls.m_Calls != null)
					{
						return calls._size;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public UIAction()
	{
		Action<GameObject> action = _003C_003Ec._003C_003E9__23_0;
		if (_003C_003Ec._003C_003E9__23_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__23_0 = delegate
			{
			});
		}
		Action = action;
		List<AnimatorEvent> animatorEvents = new List<AnimatorEvent>();
		AnimatorEvents = animatorEvents;
		List<string> gameEvents = new List<string>();
		GameEvents = gameEvents;
		Reset();
	}

	public UIAction AddAnimatorEvent(AnimatorEvent animatorEvent)
	{
		if (animatorEvent != null)
		{
			if (AnimatorEvents == null)
			{
				goto IL_007e;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B3C0");
			object obj = default(object);
			if (obj == null)
			{
				if (AnimatorEvents == null)
				{
					goto IL_007e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B430");
			}
		}
		return this;
		IL_007e:
		return (UIAction)(object)new NullReferenceException();
	}

	public UIAction AddAnimatorEvents(List<AnimatorEvent> animatorEvents)
	{
		//IL_02f8: Expected I, but got O
		//IL_030e: Expected O, but got I
		//IL_00c5: Expected O, but got I
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_03e8: Expected O, but got I4
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0197: Expected I4, but got O
		//IL_01b4: Expected I4, but got O
		//IL_01d5: Expected I, but got O
		//IL_01e0: Expected I, but got O
		//IL_01ed: Expected I4, but got O
		if (animatorEvents != null)
		{
			Func<AnimatorEvent, bool> predicate = _003C_003Ec._003C_003E9__25_0;
			int num2 = default(int);
			if (_003C_003Ec._003C_003E9__25_0 == null)
			{
				Func<AnimatorEvent, bool> func = (_003C_003Ec._003C_003E9__25_0 = delegate(AnimatorEvent x)
				{
					bool flag6 = x == null;
					return !flag6;
				});
				nint num = (nint)typeof(_003C_003Ec);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v50 (Il2CppClass<Doozy.Engine.UI.Base.UIAction+<>c>)+B8]");
				object obj = (nint)0 + (nint)16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				num2 = 0;
				predicate = func;
				if (!flag)
				{
					object obj2 = obj >> 12;
					object obj3 = obj2 & 0x1FFFFF;
					object obj4 = obj3 >> 6;
					object obj5 = obj4 * 8;
					object obj6 = 6603577472L + obj5;
					object obj7 = obj3 & 0x3F;
					nint num4;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v22+462E0]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v22+462E0]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v22+462E0]");
						if (num3 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v22+462E0]");
						num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v22+462E0]");
					}
					while (num4 != 0);
					num2 = 0;
					predicate = func;
				}
			}
			IEnumerable<AnimatorEvent> enumerable = Enumerable.Where(animatorEvents, predicate);
			if (enumerable == null)
			{
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v19 (Il2CppClass<System.Collections.Generic.List`1<Doozy.Engine.Events.AnimatorEvent>>)+135]");
			object obj10 = (nint)0 & (nint)1;
			bool flag2 = obj10 == null;
			bool flag3 = !flag2;
			List<object> list = new List<object>(enumerable);
			if (list == null)
			{
				return (UIAction)(object)new NullReferenceException();
			}
			nint num6 = 0;
			List<AnimatorEvent>.Enumerator enumerator = default(List<AnimatorEvent>.Enumerator);
			nint num8 = default(nint);
			while (enumerator.MoveNext())
			{
				Exception animatorEvents2 = (Exception)(object)AnimatorEvents;
				if (AnimatorEvents != null)
				{
					bool flag4 = animatorEvents2._message == null;
					nint num7 = num8;
					nint num9 = num6;
					int num10 = num2;
					bool flag5 = flag3;
					if (!flag4)
					{
						num10 = (int)animatorEvents2._message;
						int num11 = Array.IndexOf((object[])(object)animatorEvents2._className, null, 0, (int)animatorEvents2._message);
						flag5 = num11 != -1;
						num7 = 0;
						num9 = unchecked((nint)null);
						num8 = 0;
						num6 = unchecked((nint)null);
						num2 = (int)animatorEvents2._message;
						flag3 = flag5;
						if (flag5)
						{
							continue;
						}
					}
					animatorEvents2 = (Exception)(object)AnimatorEvents;
					if (AnimatorEvents != null)
					{
						AnimatorEvents._002Ector((IEnumerable<AnimatorEvent>)null);
						num8 = num7;
						num6 = num9;
						num2 = num10;
						flag3 = flag5;
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
		}
		return this;
	}

	public UIAction AddGameEvent(string gameEvent, bool clearGameEventsList = false)
	{
		if (gameEvent != null)
		{
			string text = gameEvent.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (text == null || text._stringLength <= 0)
			{
				goto IL_01d1;
			}
			if (clearGameEventsList)
			{
				List<string> gameEvents = GameEvents;
				if (GameEvents == null)
				{
					goto IL_01d3;
				}
				int version = gameEvents._version + 1;
				gameEvents._version = version;
				gameEvents._size = 0;
				if (gameEvents._size > 0)
				{
					Array.Clear(gameEvents._items, 0, gameEvents._size);
				}
			}
			List<string> gameEvents2 = GameEvents;
			if (GameEvents != null)
			{
				if (gameEvents2._size != 0)
				{
					int num = Array.IndexOf((object[])gameEvents2._items, (object)text, 0, gameEvents2._size);
					if (num != -1)
					{
						goto IL_01d1;
					}
				}
				if (GameEvents != null)
				{
					GameEvents.Add(text);
					goto IL_01d1;
				}
			}
		}
		goto IL_01d3;
		IL_01d3:
		return (UIAction)(object)new NullReferenceException();
		IL_01d1:
		return this;
	}

	public UIAction AddGameEvents(List<string> gameEvents, bool clearGameEventsList = false)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0513: Expected I, but got O
		//IL_0529: Expected O, but got I
		//IL_0545: Expected I, but got O
		//IL_01f7: Expected O, but got I
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_05f1: Expected O, but got I4
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected O, but got Unknown
		//IL_01b1: Expected I, but got O
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_02df: Expected I, but got O
		if (gameEvents != null)
		{
			object obj = 0;
			object obj2 = 0;
			nint num2 = default(nint);
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			nint num7 = default(nint);
			while (true)
			{
				List<string> gameEvents3;
				if ((nint)obj2 < gameEvents._size)
				{
					if ((nint)obj >= gameEvents._size)
					{
						goto IL_0470;
					}
					string[] items = gameEvents._items;
					if (gameEvents._items != null && items[obj] != null)
					{
						string text = items[obj].TrimWhiteSpaceHelper(string.TrimType.Both);
						if ((nint)obj >= gameEvents._size)
						{
							goto IL_0470;
						}
						if (gameEvents._items != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							int version = gameEvents._version + 1;
							gameEvents._version = version;
							obj++;
							obj2 = obj;
							continue;
						}
					}
				}
				else
				{
					Func<string, bool> predicate = _003C_003Ec._003C_003E9__27_0;
					if (_003C_003Ec._003C_003E9__27_0 == null)
					{
						Func<string, bool> func = (_003C_003Ec._003C_003E9__27_0 = (string s) => (s != null && s._stringLength > 0) ? true : false);
						nint num = (nint)typeof(_003C_003Ec);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v58 (Il2CppClass<Doozy.Engine.UI.Base.UIAction+<>c>)+B8]");
						object obj3 = (nint)0 + (nint)24;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
						bool flag = (nint)0 == 0;
						num2 = unchecked((nint)null);
						predicate = func;
						if (!flag)
						{
							object obj4 = obj3 >> 12;
							object obj5 = obj4 & 0x1FFFFF;
							object obj6 = obj5 >> 6;
							object obj7 = obj6 * 8;
							object obj8 = 6603577472L + obj7;
							object obj9 = obj5 & 0x3F;
							nint num4;
							do
							{
								object obj10 = 1 << (int)obj9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rdx_v27+462E0]");
								object obj11 = 0 | obj10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rdx_v27+462E0]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rdx_v27+462E0]");
								if (num3 == 0)
								{
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rdx_v27+462E0]");
								num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rdx_v27+462E0]");
							}
							while (num4 != 0);
							num2 = unchecked((nint)null);
							predicate = func;
						}
					}
					IEnumerable<string> enumerable = Enumerable.Where(gameEvents, predicate);
					if (enumerable == null)
					{
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rax_v25 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+135]");
					object obj12 = (nint)0 & (nint)1;
					bool flag2 = obj12 == null;
					bool flag3 = !flag2;
					List<object> list = new List<object>(enumerable);
					if (clearGameEventsList)
					{
						List<string> gameEvents2 = GameEvents;
						if (GameEvents == null)
						{
							goto IL_047f;
						}
						int version2 = gameEvents2._version + 1;
						gameEvents2._version = version2;
						gameEvents2._size = 0;
						flag3 = gameEvents2._size <= 0;
						if (!flag3)
						{
							Array.Clear(gameEvents2._items, 0, gameEvents2._size);
							num2 = unchecked((nint)null);
						}
					}
					if (list != null)
					{
						while (enumerator.MoveNext())
						{
							gameEvents3 = GameEvents;
							if (GameEvents != null)
							{
								bool flag4 = gameEvents3._size == 0;
								nint num6 = num7;
								nint num8 = num2;
								bool flag5 = flag3;
								if (!flag4)
								{
									int num9 = Array.IndexOf((object[])gameEvents3._items, (object)null, 0, gameEvents3._size);
									flag5 = num9 != -1;
									num6 = 0;
									num8 = gameEvents3._size;
									num7 = 0;
									num2 = gameEvents3._size;
									flag3 = flag5;
									if (flag5)
									{
										continue;
									}
								}
								gameEvents3 = GameEvents;
								if (GameEvents != null)
								{
									GameEvents.Add(null);
									num7 = num6;
									num2 = num8;
									flag3 = flag5;
									continue;
								}
								goto IL_05d6;
							}
							throw new NullReferenceException();
						}
						break;
					}
				}
				goto IL_047f;
				IL_047f:
				return (UIAction)(object)new NullReferenceException();
				IL_05d6:
				throw new NullReferenceException();
				IL_0470:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				gameEvents3 = null;
				goto IL_05d6;
			}
		}
		return this;
	}

	public Canvas GetCanvas(GameObject source, bool refresh = false)
	{
		//IL_01ee: Expected O, but got I
		//IL_02e4: Expected O, but got I4
		//IL_0266: Expected O, but got I
		//IL_022e: Expected O, but got I
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_020e->IL026b: Incompatible stack heights: 1 vs 0
		//IL_026b->IL00d5: Incompatible stack heights: 2 vs 0
		//IL_0254->IL0194: Incompatible stack heights: 2 vs 0
		GameObject gameObject = source;
		bool flag = default(bool);
		if (!flag)
		{
			Canvas canvasForEffect = m_canvasForEffect;
			bool flag2 = (object)m_canvasForEffect == null;
			gameObject = source;
			if (!flag2)
			{
				bool flag3 = ((UnityEngine.Object)canvasForEffect).m_CachedPtr == (IntPtr)0;
				gameObject = source;
				if (!flag3)
				{
					if ((object)m_canvasForEffect != null)
					{
						if (!m_canvasForEffect.isRootCanvas)
						{
							if ((object)m_canvasForEffect == null)
							{
								goto IL_026b;
							}
							bool overrideSorting = m_canvasForEffect.overrideSorting;
							bool flag4 = !overrideSorting;
							gameObject = null;
							if (flag4)
							{
								goto IL_00dc;
							}
						}
						goto IL_00d5;
					}
					goto IL_026b;
				}
			}
		}
		goto IL_00dc;
		IL_00dc:
		m_canvasForEffect = null;
		if ((object)source != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdi_v5 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F1FD0");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+18]");
				bool flag5 = (nint)0 == 0;
				Canvas canvas = null;
				if (!flag5)
				{
					while (true)
					{
						Canvas canvas2 = canvas;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+18]");
						if ((nint)canvas2 >= 0)
						{
							break;
						}
						Canvas canvas3 = canvas;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+18]");
						bool flag6 = (nint)canvas3 >= 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+20+v266 @ rbx_v8 (UnityEngine.Canvas)*8]");
						Canvas canvas4 = (Canvas)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+20+v266 @ rbx_v8 (UnityEngine.Canvas)*8]");
						if ((nint)0 != 0)
						{
							bool flag7 = ((UnityEngine.Object)canvas4).m_CachedPtr == (IntPtr)0;
							object obj2 = Canvas.get_isRootCanvas_Injected(((UnityEngine.Object)canvas4).m_CachedPtr);
							if (obj2 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+20+v266 @ rbx_v8 (UnityEngine.Canvas)*8]");
								if (!((Canvas)0).overrideSorting)
								{
									canvas = (Canvas)(canvas + 1);
									continue;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+20+v266 @ rbx_v8 (UnityEngine.Canvas)*8]");
							m_canvasForEffect = (Canvas)0;
							break;
						}
						goto IL_026b;
					}
				}
			}
			goto IL_00d5;
		}
		goto IL_026b;
		IL_00d5:
		return m_canvasForEffect;
		IL_026b:
		throw new NullReferenceException();
	}

	public void Invoke(GameObject source, bool playSound = true, bool playEffect = true, bool playAnimatorEvents = true, bool sendGameEvents = true, bool invokeUnityEvent = true, bool invokeAction = true)
	{
		if (playSound && HasSound)
		{
			SoundyController soundyController = SoundyManager.Play(SoundData);
		}
		bool flag = default(bool);
		if (flag)
		{
			Canvas canvas = GetCanvas(source);
			ExecuteEffect(canvas);
			flag = false;
		}
		object obj = default(object);
		if (obj != null)
		{
			InvokeAnimatorEvents();
		}
		object obj2 = default(object);
		if (obj2 != null && GameEvents != null)
		{
			List<string> gameEvents = GameEvents;
			if (gameEvents._size > 0)
			{
				GameEventMessage.SendEvents(gameEvents, source);
				flag = false;
			}
		}
		object obj3 = default(object);
		if (obj3 != null && Event != null)
		{
			Event.Invoke();
		}
		object obj4 = default(object);
		if (obj4 != null && Action != null)
		{
			Action<GameObject> action = Action;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v284 @ rax_v7 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
	}

	public void InvokeAction(GameObject source)
	{
		if (Action != null)
		{
			Action<GameObject> action = Action;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ rax_v1 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
	}

	public void InvokeUnityEvent()
	{
		if (Event != null)
		{
			Event.Invoke();
		}
	}

	public void InvokeAnimatorEvents()
	{
		if (AnimatorEvents != null)
		{
			List<AnimatorEvent> animatorEvents = AnimatorEvents;
			List<AnimatorEvent>.Enumerator enumerator = default(List<AnimatorEvent>.Enumerator);
			if (animatorEvents._size > 0 && enumerator.MoveNext())
			{
				throw new NullReferenceException();
			}
		}
	}

	public void ExecuteEffect(Canvas canvas)
	{
		//IL_012a: Expected O, but got I4
		//IL_018f: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		if (!HasEffect)
		{
			return;
		}
		UIEffect effect;
		bool flag2;
		if ((object)canvas != null)
		{
			bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
			effect = Effect;
			if (!flag)
			{
				string sortingLayerName = canvas.sortingLayerName;
				int sortingOrder = canvas.sortingOrder;
				if (effect.Behavior == UIEffectBehavior.Play)
				{
					effect.Play(sortingLayerName, sortingOrder);
					return;
				}
				object obj = effect.Behavior - 1;
				flag2 = obj == null;
				goto IL_0184;
			}
		}
		else
		{
			effect = Effect;
		}
		if (effect.Behavior == UIEffectBehavior.Play)
		{
			effect.Play();
			return;
		}
		object obj2 = effect.Behavior - 1;
		flag2 = obj2 == null;
		goto IL_0184;
		IL_0184:
		object obj3 = !flag2;
		if (obj3 == null)
		{
			effect.Stop(effect.StopBehavior);
		}
	}

	public void PlaySound()
	{
		if (HasSound)
		{
			SoundyController soundyController = SoundyManager.Play(SoundData);
		}
	}

	public void Reset()
	{
		SoundyData soundData = new SoundyData();
		SoundData = soundData;
		List<AnimatorEvent> animatorEvents = new List<AnimatorEvent>();
		AnimatorEvents = animatorEvents;
		List<string> gameEvents = new List<string>();
		GameEvents = gameEvents;
		UnityEvent unityEvent = (UnityEvent)new UnityEventBase();
		unityEvent.m_InvokeArray = null;
		Event = unityEvent;
		Action<GameObject> action = _003C_003Ec._003C_003E9__35_0;
		if (_003C_003Ec._003C_003E9__35_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__35_0 = delegate
			{
			});
		}
		Action = action;
	}

	public void SendGameEvents(GameObject source)
	{
		if (GameEvents != null)
		{
			List<string> gameEvents = GameEvents;
			if (gameEvents._size > 0)
			{
				GameEventMessage.SendEvents(gameEvents, source);
			}
		}
	}

	public UIAction SetAction(Action<GameObject> action)
	{
		Action = action;
		return this;
	}

	public UIAction SetEffect(UIEffect effect)
	{
		if (effect != null)
		{
			Effect = effect;
		}
		return this;
	}

	public UIAction SetSoundyData(SoundyData soundyData)
	{
		if (soundyData != null)
		{
			SoundData = soundyData;
		}
		return this;
	}
}
