using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Platforms;

namespace VampireSurvivors.UI;

public class PlayerInfoUI : MonoBehaviour
{
	private TextMeshProUGUI _Name;

	private Image _Icon;

	private void Start()
	{
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IBaseAccount currentSystem = sInstance.m_CurrentSystem;
		if (currentSystem.m_LoginState <= LoginState.LoggingIn)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
		else
		{
			SystemPlatform sInstance2 = SystemPlatform.sInstance;
			IBaseAccount currentSystem2 = sInstance2.m_CurrentSystem;
			_Name.text = currentSystem2.m_Name;
		}
	}

	public PlayerInfoUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
