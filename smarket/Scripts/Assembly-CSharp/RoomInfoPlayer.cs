using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Photon.Realtime;
using Steamworks;
using Steamworks.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class RoomInfoPlayer : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CTryLoadAvatar_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public RoomInfoPlayer _003C_003E4__this;

		public ulong steamId64;

		private SteamId _003CfacepunchId_003E5__2;

		private TaskAwaiter<Steamworks.Data.Image?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[SerializeField]
	private TextMeshProUGUI nicknameText;

	[SerializeField]
	private TextMeshProUGUI pingText;

	[SerializeField]
	private RawImage avatar;

	[SerializeField]
	private Button banButton;

	[SerializeField]
	private Button kickButton;

	[SerializeField]
	private GamepadDeepSwitch m_GamepadDeepSwitch;

	[SerializeField]
	private GameObject roomOwner;

	private string _userID;

	private Player _player;

	private Texture2D _avatarTex;

	private void Awake()
	{
	}

	public void Setup(Player p)
	{
	}

	private static ulong ConvertToUlong(object v)
	{
		return 0uL;
	}

	public void UpdatePing(int? ping)
	{
	}

	[AsyncStateMachine(typeof(_003CTryLoadAvatar_003Ed__14))]
	public void TryLoadAvatar(ulong steamId64)
	{
	}

	private void SetAvatarPlaceholder()
	{
	}

	public void Ban()
	{
	}

	public void Kick()
	{
	}
}
