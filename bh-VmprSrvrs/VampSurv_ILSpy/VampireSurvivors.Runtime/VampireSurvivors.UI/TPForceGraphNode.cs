using Cpp2ILInjected;
using Doozy.Engine.Nody;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class TPForceGraphNode : MonoBehaviour
{
	private GraphController _Graph;

	private PlayerOptions _playerOptions;

	private bool _isSubscribed;

	private void Construct(PlayerOptions po)
	{
		_playerOptions = po;
		PlayerOptions playerOptions = _playerOptions;
		if (!playerOptions._003CIsInitialized_003Ek__BackingField)
		{
			PlayerOptions.OnInitialized value = SetNode;
			playerOptions.PlayerOptionsInitialized += value;
			_isSubscribed = true;
		}
	}

	private void Start()
	{
		PlayerOptions playerOptions = _playerOptions;
		if (playerOptions._003CIsInitialized_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36AD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PlayerOptionsData config = _playerOptions.Config;
			config._003CShowTPCredits_003Ek__BackingField = true;
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CShowTPCredits_003Ek__BackingField)
			{
				_Graph.GoToNodeByName("TPCredits");
			}
		}
	}

	private void OnDestroy()
	{
		if (_isSubscribed)
		{
			PlayerOptions.OnInitialized value = SetNode;
			_playerOptions.PlayerOptionsInitialized -= value;
		}
	}

	private void SetNode()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36AD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PlayerOptionsData config = _playerOptions.Config;
		config._003CShowTPCredits_003Ek__BackingField = true;
		PlayerOptionsData config2 = _playerOptions.Config;
		if (config2._003CShowTPCredits_003Ek__BackingField)
		{
			_Graph.GoToNodeByName("TPCredits");
		}
	}

	public TPForceGraphNode()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
