using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;

namespace VampireSurvivors.UI;

public class ScenePreloader : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__6_0;

		public static Action _003C_003E9__8_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CTransitionMainMenuIntoGameplay_003Eb__6_0()
		{
			//IL_0019: Expected O, but got I4
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Gameplay", (LoadSceneParameters)0);
		}

		internal void _003CDelayedLoadMainMenuRoutine_003Eb__8_0()
		{
			//IL_0019: Expected O, but got I4
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu", (LoadSceneParameters)0);
		}
	}

	private sealed class _003CDelayedLoadMainMenuRoutine_003Ed__8(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_006e: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				Action onComplete = _003C_003Ec._003C_003E9__8_0;
				if (_003C_003Ec._003C_003E9__8_0 == null)
				{
					onComplete = (_003C_003Ec._003C_003E9__8_0 = delegate
					{
						//IL_0019: Expected O, but got I4
						AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu", (LoadSceneParameters)0);
					});
				}
				MainMenuLoader.Load(onComplete);
			}
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

	public RawImage _loadingBackground;

	public GameObject _loadingIcon;

	public GameObject _loadingText;

	private void Awake()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			if (core2._hideLoadingVisuals)
			{
				GameObject loadingIcon = _loadingIcon;
				if ((object)_loadingIcon != null && ((UnityEngine.Object)loadingIcon).m_CachedPtr != (IntPtr)0)
				{
					_loadingIcon.SetActive(value: false);
				}
				GameObject loadingText = _loadingText;
				if ((object)_loadingText != null && ((UnityEngine.Object)loadingText).m_CachedPtr != (IntPtr)0)
				{
					_loadingText.SetActive(value: false);
				}
			}
		}
		GameManager core3 = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core3).m_CachedPtr != (IntPtr)0)
		{
			GameManager core4 = GM.Core;
			Texture2D recapTex = core4._recapTex;
			if ((object)core4._recapTex != null && ((UnityEngine.Object)recapTex).m_CachedPtr != (IntPtr)0)
			{
				GameManager core5 = GM.Core;
				_loadingBackground.texture = core5._recapTex;
				GameObject gameObject = _loadingBackground.gameObject;
				gameObject.SetActive(value: true);
			}
		}
	}

	private unsafe void Start()
	{
		//IL_00a9: Expected I4, but got O
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Ref, but got Unknown
		//IL_0164: Expected I8, but got I4
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected Ref, but got Unknown
		//IL_008d: Expected O, but got I4
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected Ref, but got Unknown
		//IL_0248: Expected I8, but got I4
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected Ref, but got Unknown
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			if (core2._restartingGameScene)
			{
				core2._restartingGameScene = false;
				ReleaseGameplay();
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Gameplay", (LoadSceneParameters)0);
				return;
			}
		}
		Scene activeScene = SceneManager.GetActiveScene();
		string nameInternal = Scene.GetNameInternal((int)activeScene);
		object obj = "MainMenu";
		if ((object)nameInternal != "MainMenu")
		{
			if (nameInternal != null && "MainMenu" != null)
			{
				int stringLength = nameInternal._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdx_v3+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(nameInternal + 20);
					ulong length = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("MainMenu" + 20), length))
					{
						goto IL_0290;
					}
				}
			}
			object obj2 = "Gameplay";
			if ((object)nameInternal != "Gameplay")
			{
				if (nameInternal == null || "Gameplay" == null)
				{
					return;
				}
				int stringLength2 = nameInternal._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v8+10]");
				if ((nint)stringLength2 != 0)
				{
					return;
				}
				ref byte first2 = ref *(byte*)(nameInternal + 20);
				ulong length2 = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Gameplay" + 20), length2))
				{
					return;
				}
			}
			ReleaseGameplay();
			_003CDelayedLoadMainMenuRoutine_003Ed__8 obj3 = null;
			obj3._003C_003E1__state = 0;
			Coroutine coroutine = StartCoroutine(obj3);
			return;
		}
		goto IL_0290;
		IL_0290:
		TransitionMainMenuIntoGameplay();
	}

	private void TransitionGameplayIntoGameplay()
	{
		//IL_0019: Expected O, but got I4
		ReleaseGameplay();
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Gameplay", (LoadSceneParameters)0);
	}

	private void TransitionMainMenuIntoGameplay()
	{
		//IL_0119: Expected O, but got I4
		while (true)
		{
			SystemPlatform sInstance = SystemPlatform.sInstance;
			if (SystemPlatform.sInstance != null && sInstance._playerOptions != null)
			{
				sInstance._playerOptions.ClearRunData();
			}
			AddressableCache.ReleaseCustomOperationHandleGroup("BGM");
			AddressableCache.ReleaseCustomOperationHandleGroup("SFX");
			AddressableCache.ReleaseCustomOperationHandleGroup("AdventureBackgrounds");
			Action action = _003C_003Ec._003C_003E9__6_0;
			if (_003C_003Ec._003C_003E9__6_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__6_0 = delegate
				{
					//IL_0019: Expected O, but got I4
					AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Gameplay", (LoadSceneParameters)0);
				});
				object obj = 0;
				nint num = 0;
			}
			CharacterLoader.ClearCharacterTextures();
			AddressableCache.RemoveTexturesFromCacheAndSpriteManager("MainMenu");
			AddressableCache.ReleaseCustomOperationHandleGroup("MainMenu");
			IntPtr method = ((Delegate)action).method;
			IntPtr method_code = ((Delegate)action).method_code;
			IntPtr invoke_impl = ((Delegate)action).invoke_impl;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v310 @ rax_v18 (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void TransitionGameplayIntoMainMenu()
	{
		ReleaseGameplay();
		_003CDelayedLoadMainMenuRoutine_003Ed__8 obj = null;
		obj._003C_003E1__state = 0;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DelayedLoadMainMenuRoutine()
	{
		_003CDelayedLoadMainMenuRoutine_003Ed__8 obj = null;
		obj._003C_003E1__state = 0;
		return obj;
	}

	private void ReleaseGameplay()
	{
		AddressableCache.ReleaseCustomOperationHandleGroup("BGM");
		AddressableCache.ReleaseCustomOperationHandleGroup("SFX");
		AddressableCache.ReleaseDynamicOperationHandles();
		GameManager core = GM.Core;
		GameplayLoader gameplayLoader = core._gameplayLoader;
		if (core._gameplayLoader != null)
		{
			CharacterLoader.ClearCharacterTextures();
			AddressableCache.RemoveTexturesFromCacheAndSpriteManager("Gameplay");
			AddressableCache.ReleaseCustomOperationHandleGroup("Gameplay");
			TilesetFactory tilesetFactory = gameplayLoader._tilesetFactory;
			tilesetFactory._mapInstances.Clear();
		}
		core._gameplayLoader = null;
	}

	private void HideVisuals()
	{
		GameObject loadingIcon = _loadingIcon;
		if ((object)_loadingIcon != null && ((UnityEngine.Object)loadingIcon).m_CachedPtr != (IntPtr)0)
		{
			_loadingIcon.SetActive(value: false);
		}
		GameObject loadingText = _loadingText;
		if ((object)_loadingText != null && ((UnityEngine.Object)loadingText).m_CachedPtr != (IntPtr)0)
		{
			_loadingText.SetActive(value: false);
		}
	}

	public ScenePreloader()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
