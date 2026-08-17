using System;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{
	public AudioSource source;

	private bool isPaused;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> b = OnPause;
		Delegate obj = Delegate.Combine(MyTime.A_Pause, b);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> value = OnPause;
		Delegate obj = Delegate.Remove(MyTime.A_Pause, value);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnValidate()
	{
		AudioSource component = GetComponent<AudioSource>();
		source = component;
	}

	private void OnPause(bool paused)
	{
		//IL_001c: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		bool isPlaying = source.isPlaying;
		object obj = paused & isPlaying;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 == null)
		{
			if (isPaused)
			{
				source.UnPause();
				isPaused = false;
			}
		}
		else
		{
			source.Pause();
			isPaused = true;
		}
	}
}
