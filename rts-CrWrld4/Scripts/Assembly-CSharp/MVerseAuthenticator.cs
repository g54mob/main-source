using System;
using System.Collections;
using Mirror;
using UnityEngine;

public class MVerseAuthenticator : NetworkAuthenticator
{
	public struct AuthRequestMessage : NetworkMessage
	{
		public string inviteKey;

		public string gameVersion;
	}

	public struct AuthResponseMessage : NetworkMessage
	{
		public byte code;

		public string message;
	}

	public float timeout;

	private Coroutine authRoutine;

	public override void OnStartServer()
	{
	}

	public override void OnStopServer()
	{
	}

	public override void OnServerAuthenticate(NetworkConnection conn)
	{
	}

	public void OnAuthRequestMessage(NetworkConnection conn, AuthRequestMessage msg)
	{
	}

	private IEnumerator DelayedDisconnect(NetworkConnection conn, float waitTime)
	{
		return null;
	}

	public override void OnStartClient()
	{
	}

	public override void OnStopClient()
	{
	}

	public override void OnClientAuthenticate(NetworkConnection conn)
	{
	}

	public void OnAuthResponseMessage(AuthResponseMessage msg)
	{
	}

	[Obsolete]
	public void OnAuthResponseMessage(NetworkConnection conn, AuthResponseMessage msg)
	{
	}

	private IEnumerator BeginAuthentication(NetworkConnection conn)
	{
		return null;
	}
}
