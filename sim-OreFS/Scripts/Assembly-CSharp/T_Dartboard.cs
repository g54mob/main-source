using System;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class T_Dartboard : NetworkBehaviour
{
	[Header("Scoring Zones (radius in local units)")]
	[SerializeField]
	private float bullseyeRadius = 0.02f;

	[SerializeField]
	private float innerRingRadius = 0.06f;

	[SerializeField]
	private float middleRingRadius = 0.12f;

	[SerializeField]
	private float outerRingRadius = 0.2f;

	[Header("Zone Points")]
	[SerializeField]
	private int bullseyePoints = 50;

	[SerializeField]
	private int innerRingPoints = 25;

	[SerializeField]
	private int middleRingPoints = 10;

	[SerializeField]
	private int outerRingPoints = 5;

	[Header("World UI")]
	[SerializeField]
	private DartGameUI worldUI;

	public readonly SyncList<DartPlayerScore> playerScores = new SyncList<DartPlayerScore>();

	private readonly List<T_Dart> boardDarts = new List<T_Dart>();

	public override void OnStartClient()
	{
		base.OnStartClient();
		SyncList<DartPlayerScore> syncList = playerScores;
		syncList.Callback = (Action<SyncList<DartPlayerScore>.Operation, int, DartPlayerScore, DartPlayerScore>)Delegate.Combine(syncList.Callback, new Action<SyncList<DartPlayerScore>.Operation, int, DartPlayerScore, DartPlayerScore>(OnPlayerScoresChanged));
		if (worldUI != null && playerScores.Count > 0)
		{
			worldUI.RefreshScoreboard(playerScores);
			worldUI.Show();
		}
	}

	private void OnPlayerScoresChanged(SyncList<DartPlayerScore>.Operation op, int index, DartPlayerScore oldItem, DartPlayerScore newItem)
	{
		if (!(worldUI == null))
		{
			worldUI.RefreshScoreboard(playerScores);
			if (playerScores.Count > 0)
			{
				worldUI.Show();
			}
		}
	}

	[Server]
	public void ServerRegisterDartHit(T_Dart dart, Vector3 hitPoint)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dartboard::ServerRegisterDartHit(T_Dart,UnityEngine.Vector3)' called when server was not active");
			return;
		}
		boardDarts.Add(dart);
		Vector3 vector = base.transform.InverseTransformPoint(hitPoint);
		float magnitude = new Vector2(vector.x, vector.y).magnitude;
		int num = CalculateScore(magnitude);
		string ownerPlayerName = dart.OwnerPlayerName;
		uint ownerPlayerNetId = dart.OwnerPlayerNetId;
		int num2 = -1;
		for (int i = 0; i < playerScores.Count; i++)
		{
			if (playerScores[i].playerNetId == ownerPlayerNetId)
			{
				num2 = i;
				break;
			}
		}
		if (num2 >= 0)
		{
			DartPlayerScore value = playerScores[num2];
			value.score += num;
			playerScores[num2] = value;
		}
		else
		{
			playerScores.Add(new DartPlayerScore
			{
				playerNetId = ownerPlayerNetId,
				playerName = ownerPlayerName,
				score = num
			});
		}
		RpcOnDartScored(num, ownerPlayerName);
	}

	private int CalculateScore(float distance)
	{
		if (distance <= bullseyeRadius)
		{
			return bullseyePoints;
		}
		if (distance <= innerRingRadius)
		{
			return innerRingPoints;
		}
		if (distance <= middleRingRadius)
		{
			return middleRingPoints;
		}
		if (distance <= outerRingRadius)
		{
			return outerRingPoints;
		}
		return 0;
	}

	[Command(requiresAuthority = false)]
	public void CmdResetScore()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdResetScore();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Dartboard::CmdResetScore()", -2043303608, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerResetScore()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dartboard::ServerResetScore()' called when server was not active");
			return;
		}
		playerScores.Clear();
		ServerCleanupDarts();
		RpcOnScoreReset();
	}

	[Server]
	private void ServerCleanupDarts()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dartboard::ServerCleanupDarts()' called when server was not active");
			return;
		}
		foreach (T_Dart boardDart in boardDarts)
		{
			if (boardDart != null)
			{
				NetworkServer.Destroy(boardDart.gameObject);
			}
		}
		boardDarts.Clear();
	}

	[ClientRpc]
	private void RpcOnDartScored(int score, string throwerName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(score);
		writer.WriteString(throwerName);
		SendRPCInternal("System.Void T_Dartboard::RpcOnDartScored(System.Int32,System.String)", -681881361, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnScoreReset()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Dartboard::RpcOnScoreReset()", -1528502456, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		DrawLocalCircle(bullseyeRadius);
		Gizmos.color = new Color(1f, 0.5f, 0f);
		DrawLocalCircle(innerRingRadius);
		Gizmos.color = Color.yellow;
		DrawLocalCircle(middleRingRadius);
		Gizmos.color = Color.green;
		DrawLocalCircle(outerRingRadius);
	}

	private void DrawLocalCircle(float radius)
	{
		int num = 32;
		float num2 = 360f / (float)num;
		for (int i = 0; i < num; i++)
		{
			float f = MathF.PI / 180f * (num2 * (float)i);
			float f2 = MathF.PI / 180f * (num2 * (float)(i + 1));
			Vector3 position = new Vector3(Mathf.Cos(f) * radius, Mathf.Sin(f) * radius, 0f);
			Vector3 position2 = new Vector3(Mathf.Cos(f2) * radius, Mathf.Sin(f2) * radius, 0f);
			Vector3 vector = base.transform.TransformPoint(position);
			Vector3 to = base.transform.TransformPoint(position2);
			Gizmos.DrawLine(vector, to);
		}
	}

	public T_Dartboard()
	{
		InitSyncObject(playerScores);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdResetScore()
	{
		ServerResetScore();
	}

	protected static void InvokeUserCode_CmdResetScore(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdResetScore called on client.");
		}
		else
		{
			((T_Dartboard)obj).UserCode_CmdResetScore();
		}
	}

	protected void UserCode_RpcOnDartScored__Int32__String(int score, string throwerName)
	{
		if (worldUI != null)
		{
			worldUI.ShowDartScore(score, throwerName);
		}
	}

	protected static void InvokeUserCode_RpcOnDartScored__Int32__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnDartScored called on server.");
		}
		else
		{
			((T_Dartboard)obj).UserCode_RpcOnDartScored__Int32__String(reader.ReadVarInt(), reader.ReadString());
		}
	}

	protected void UserCode_RpcOnScoreReset()
	{
		if (worldUI != null)
		{
			worldUI.OnScoreReset();
			worldUI.Hide();
		}
	}

	protected static void InvokeUserCode_RpcOnScoreReset(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnScoreReset called on server.");
		}
		else
		{
			((T_Dartboard)obj).UserCode_RpcOnScoreReset();
		}
	}

	static T_Dartboard()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Dartboard), "System.Void T_Dartboard::CmdResetScore()", InvokeUserCode_CmdResetScore, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Dartboard), "System.Void T_Dartboard::RpcOnDartScored(System.Int32,System.String)", InvokeUserCode_RpcOnDartScored__Int32__String);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Dartboard), "System.Void T_Dartboard::RpcOnScoreReset()", InvokeUserCode_RpcOnScoreReset);
	}
}
