using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.UI;

public class MobileCheatsMenu : MonoBehaviour
{
	private Button _ShowMobileCheatsButton;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	private void Construct(PlayerOptions playerOptions, DataManager dataManager)
	{
		_playerOptions = playerOptions;
		_dataManager = dataManager;
	}

	private void Awake()
	{
		Button showMobileCheatsButton = _ShowMobileCheatsButton;
		if ((object)_ShowMobileCheatsButton != null && ((UnityEngine.Object)showMobileCheatsButton).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _ShowMobileCheatsButton.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		}
		GameObject obj2 = base.gameObject;
		UnityEngine.Object.Destroy(obj2, 0f);
	}

	public void CheatF2()
	{
	}

	public void ForcePreMoongolowSave()
	{
	}

	private static void Reload()
	{
		//IL_0017: Expected I4, but got O
		//IL_0033: Expected O, but got I4
		Scene activeScene = SceneManager.GetActiveScene();
		string nameInternal = Scene.GetNameInternal((int)activeScene);
		Scene scene = SceneManager.LoadScene(nameInternal, (LoadSceneParameters)0);
	}

	public MobileCheatsMenu()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
