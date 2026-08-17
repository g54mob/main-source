using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Video;

namespace VampireSurvivors.App.UI;

public class MenuBackgroundController : MonoBehaviour
{
	private VideoPlayer _VideoPlayer;

	private GameObject _StaticBackground;

	private void Awake()
	{
		if ((object)_StaticBackground != null)
		{
			_StaticBackground.SetActive(value: true);
			if ((object)_VideoPlayer != null)
			{
				GameObject gameObject = _VideoPlayer.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: true);
					VideoPlayer.EventHandler value = OnPrepareCompleted;
					if ((object)_VideoPlayer != null)
					{
						_VideoPlayer.prepareCompleted += value;
						MenuBackgroundController videoPlayer = (MenuBackgroundController)(object)_VideoPlayer;
						if ((object)_VideoPlayer != null)
						{
							bool flag = ((UnityEngine.Object)videoPlayer).m_CachedPtr == (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 132 ConditionalJump @-1, v188 @ ZF_v11 (System.Boolean) --- -1 Nop");
							/*Error: End of method reached without returning.*/;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnPrepareCompleted(VideoPlayer source)
	{
		VideoPlayer videoPlayer = _VideoPlayer;
		bool flag = ((UnityEngine.Object)videoPlayer).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public MenuBackgroundController()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
