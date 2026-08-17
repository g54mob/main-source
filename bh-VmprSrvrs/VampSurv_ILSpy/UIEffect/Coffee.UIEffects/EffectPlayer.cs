using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIEffects;

[Serializable]
public class EffectPlayer
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Canvas.WillRenderCanvases _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnEnable_003Eb__7_0()
		{
			//IL_0025: Expected O, but got I4
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			List<Action> s_UpdateActions = EffectPlayer.s_UpdateActions;
			bool flag = s_UpdateActions._size <= 0;
			object obj = 0;
			if (flag)
			{
				return;
			}
			while (true)
			{
				List<Action> s_UpdateActions2 = EffectPlayer.s_UpdateActions;
				if ((nint)obj >= s_UpdateActions2._size)
				{
					break;
				}
				Action[] items = s_UpdateActions2._items;
				Action action = items[obj];
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				obj++;
				if ((nint)obj < s_UpdateActions._size)
				{
					continue;
				}
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}
	}

	public bool play;

	public float initialPlayDelay;

	public float duration = 1f;

	public bool loop;

	public float loopDelay;

	public AnimatorUpdateMode updateMode;

	private static List<Action> s_UpdateActions;

	private float _time;

	private Action<float> _callback;

	public void OnEnable(Action<float> callback = null)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected F4, but got Unknown
		//IL_006f: Expected F4, but got I4
		if (s_UpdateActions == null)
		{
			List<Action> list = new List<Action>();
			s_UpdateActions = list;
			Canvas.WillRenderCanvases value = _003C_003Ec._003C_003E9__7_0;
			if (_003C_003Ec._003C_003E9__7_0 == null)
			{
				value = (_003C_003Ec._003C_003E9__7_0 = delegate
				{
					//IL_0025: Expected O, but got I4
					//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a5: Expected O, but got Unknown
					List<Action> list2 = s_UpdateActions;
					bool flag = list2._size <= 0;
					object obj = 0;
					if (flag)
					{
						return;
					}
					while (true)
					{
						List<Action> list3 = s_UpdateActions;
						if ((nint)obj >= list3._size)
						{
							break;
						}
						Action[] items = list3._items;
						Action action2 = items[obj];
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						obj++;
						if ((nint)obj >= list2._size)
						{
							return;
						}
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new NullReferenceException();
				});
			}
			Canvas.willRenderCanvases += value;
		}
		Action action = OnWillRenderCanvases;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		float time;
		if (!play)
		{
			time = 0f;
		}
		else
		{
			float num = initialPlayDelay;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			time = num ^ 0;
		}
		_time = time;
		_callback = callback;
	}

	public void OnDisable()
	{
		_callback = null;
		Action item = OnWillRenderCanvases;
		bool flag = ((List<object>)(object)s_UpdateActions).Remove((object)item);
	}

	public void Play(bool reset, Action<float> callback = null)
	{
		if (reset)
		{
			_time = 0f;
		}
		play = true;
		if (callback != null)
		{
			_callback = callback;
		}
	}

	public void Stop(bool reset)
	{
		if (reset)
		{
			bool flag = _callback == null;
			_time = 0f;
			if (!flag)
			{
				Action<float> callback = _callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v36 @ rax_v1 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
				play = false;
				return;
			}
		}
		play = false;
	}

	private void OnWillRenderCanvases()
	{
		//IL_013b: Expected O, but got I4
		//IL_0102: Expected F4, but got I4
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected F4, but got Unknown
		if (!play)
		{
			return;
		}
		object obj = Application.isPlaying;
		if (obj == null || _callback == null)
		{
			return;
		}
		if (updateMode == AnimatorUpdateMode.UnscaledTime)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45B10");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
		}
		float num2 = default(float);
		float num = (_time += num2);
		float num3 = num / duration;
		if (!(num < duration))
		{
			play = loop;
			if (~(loop ? 1u : 0u) == 0)
			{
				float num4 = loopDelay;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				num2 = num4 ^ 0;
			}
			else
			{
				num2 = 0f;
			}
			_time = num2;
		}
		Action<float> callback = _callback;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v241 @ rax_v11 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
	}
}
