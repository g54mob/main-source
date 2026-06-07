using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

public class CrossyRoad : GameBase
{
	[CompilerGenerated]
	private sealed class _003CResetAfterDelay_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrossyRoad _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CResetAfterDelay_003Ed__33(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			CrossyRoad crossyRoad = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(2f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				crossyRoad.RpcResetDuckPosition();
				_003C_003E2__current = new WaitForSeconds(1f);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				crossyRoad.ResetGame();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Header("References")]
	[SerializeField]
	private TextMeshPro multiplierText;

	[Header("References")]
	[SerializeField]
	private TextMeshPro potentialWinningsText;

	[SerializeField]
	private Transform startPoint;

	[SerializeField]
	private Transform endPoint;

	[SerializeField]
	private Transform penguin;

	[SerializeField]
	private Animator penguinAnim;

	[SerializeField]
	private Animator[] sidePenguinAnims;

	[SerializeField]
	private Transform[] iceCubes;

	[SerializeField]
	private ParticleSystem waterVfx;

	[Header("Settings")]
	[SerializeField]
	private float stepDistance = 0.2f;

	[SerializeField]
	private float jumpHeight = 0.1f;

	[SerializeField]
	private float stepTweenDuration = 0.4f;

	[SerializeField]
	private int maxSteps = 10;

	[SerializeField]
	private double[] stepMultipliers;

	[SerializeField]
	[SyncVar(hook = "OnMultiplierChanged")]
	private double currentMultiplier;

	[Header("SFX")]
	[SerializeField]
	private EventReference duckSFX;

	[SerializeField]
	private EventReference crossyWinSFX;

	[SerializeField]
	private EventReference crossyLoseSFX;

	[SerializeField]
	private EventReference crossyDuckLoseSFX;

	private int _currentStep;

	private float _currentCrashChance;

	private float _lastStepTime;

	private bool _hasEnded;

	public Action<double, double> _Mirror_SyncVarHookDelegate_currentMultiplier;

	private int MaxPlayableStep
	{
		get
		{
			if (stepMultipliers != null)
			{
				return Mathf.Max(0, Mathf.Min(maxSteps, stepMultipliers.Length - 1));
			}
			return 0;
		}
	}

	public double NetworkcurrentMultiplier
	{
		get
		{
			return currentMultiplier;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentMultiplier, 8uL, _Mirror_SyncVarHookDelegate_currentMultiplier);
		}
	}

	private void OnMultiplierChanged(double oldMultiplier, double newMultiplier)
	{
		if ((bool)multiplierText)
		{
			multiplierText.text = $"{newMultiplier:F1}x";
		}
		if ((bool)potentialWinningsText)
		{
			long num = (long)Math.Round((double)currentBet * newMultiplier);
			potentialWinningsText.text = $"${num:N0}";
		}
	}

	private void Start()
	{
		if (sidePenguinAnims == null)
		{
			return;
		}
		Animator[] array = sidePenguinAnims;
		foreach (Animator animator in array)
		{
			if ((bool)animator)
			{
				animator.speed = UnityEngine.Random.Range(0.8f, 1.2f);
			}
		}
	}

	protected override bool CanGameStart()
	{
		if (MaxPlayableStep > 0)
		{
			return base.CanGameStart();
		}
		return false;
	}

	[Server]
	protected override void StartGame()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void CrossyRoad::StartGame()' called when server was not active");
			return;
		}
		_currentStep = 0;
		NetworkcurrentMultiplier = GetStepMultiplier(_currentStep);
		_currentCrashChance = GetCrashChanceForStep(_currentStep);
	}

	[Server]
	public void TakeStep()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void CrossyRoad::TakeStep()' called when server was not active");
		}
		else if (isPlaying && !_hasEnded && _currentStep < MaxPlayableStep && !(Time.time - _lastStepTime < stepTweenDuration + 0.1f))
		{
			_lastStepTime = Time.time;
			StartCoroutine(StepRoutine());
		}
	}

	private IEnumerator StepRoutine()
	{
		float num = (float)GetSeededRandom(_currentStep * 9999).NextDouble();
		_currentStep++;
		if (num < _currentCrashChance)
		{
			RpcPenguinStep(_currentStep, (float)GetStepMultiplier(_currentStep));
			_hasEnded = true;
			yield return new WaitForSeconds(stepTweenDuration);
			Crash();
			yield break;
		}
		NetworkcurrentMultiplier = GetStepMultiplier(_currentStep);
		_currentCrashChance = GetCrashChanceForStep(_currentStep);
		RpcPenguinStep(_currentStep, (float)currentMultiplier);
		if (_currentStep >= MaxPlayableStep)
		{
			yield return new WaitForSeconds(stepTweenDuration);
			CashOut();
		}
	}

	[Server]
	private void Crash()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void CrossyRoad::Crash()' called when server was not active");
			return;
		}
		RpcCrashFeedback(_currentStep, (float)currentMultiplier);
		Payout(0.0, ChangeType.GameResult, null, -1L);
		StartCoroutine(ResetAfterDelay());
	}

	[Server]
	public void CashOut()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void CrossyRoad::CashOut()' called when server was not active");
		}
		else if (isPlaying && !_hasEnded && _currentStep > 0)
		{
			_hasEnded = true;
			Payout(currentMultiplier, ChangeType.GameResult, null, -1L);
			RpcWinFeedback((float)currentMultiplier);
			StartCoroutine(ResetAfterDelay());
		}
	}

	[IteratorStateMachine(typeof(_003CResetAfterDelay_003Ed__33))]
	[Server]
	private IEnumerator ResetAfterDelay()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator CrossyRoad::ResetAfterDelay()' called when server was not active");
			return null;
		}
		return new _003CResetAfterDelay_003Ed__33(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	protected override void ResetGame()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void CrossyRoad::ResetGame()' called when server was not active");
			return;
		}
		_hasEnded = false;
		_currentStep = 0;
		NetworkcurrentMultiplier = GetStepMultiplier(_currentStep);
		_currentCrashChance = GetCrashChanceForStep(_currentStep);
		base.ResetGame();
	}

	private float GetCrashChanceForStep(int step)
	{
		if (step < 0)
		{
			return 0f;
		}
		if (step >= MaxPlayableStep)
		{
			return 1f;
		}
		double stepMultiplier = GetStepMultiplier(step);
		double stepMultiplier2 = GetStepMultiplier(step + 1);
		double num = base.EstimatedValue / stepMultiplier;
		double num2 = base.EstimatedValue / stepMultiplier2 / num;
		return Mathf.Clamp01((float)(1.0 - num2));
	}

	private double GetStepMultiplier(int step)
	{
		if (stepMultipliers == null || stepMultipliers.Length == 0)
		{
			return 1.0;
		}
		return stepMultipliers[Mathf.Clamp(step, 0, stepMultipliers.Length - 1)];
	}

	[ClientRpc]
	private void RpcPenguinStep(int step, float mult)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(step);
		writer.WriteFloat(mult);
		SendRPCInternal("System.Void CrossyRoad::RpcPenguinStep(System.Int32,System.Single)", -2082101845, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcResetDuckPosition()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CrossyRoad::RpcResetDuckPosition()", 614803394, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcWinFeedback(float mult)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(mult);
		SendRPCInternal("System.Void CrossyRoad::RpcWinFeedback(System.Single)", 1987450247, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCrashFeedback(int step, float mult)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(step);
		writer.WriteFloat(mult);
		SendRPCInternal("System.Void CrossyRoad::RpcCrashFeedback(System.Int32,System.Single)", 2077413361, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public CrossyRoad()
	{
		_Mirror_SyncVarHookDelegate_currentMultiplier = OnMultiplierChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcPenguinStep__Int32__Single(int step, float mult)
	{
		if ((bool)startPoint && (bool)endPoint && (bool)penguin)
		{
			Vector3 endValue = startPoint.position + (endPoint.position - startPoint.position).normalized * (stepDistance * (float)step);
			penguin.DOJump(endValue, jumpHeight, 1, stepTweenDuration).SetEase(Ease.Linear);
			if ((bool)penguinAnim)
			{
				penguinAnim.SetTrigger("Jump");
			}
			SFXManager.SFXOneShotWithParameters(duckSFX, null, penguin.transform.position, 0.8f + mult * 0.04f);
		}
	}

	protected static void InvokeUserCode_RpcPenguinStep__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcPenguinStep called on server.");
		}
		else
		{
			((CrossyRoad)obj).UserCode_RpcPenguinStep__Int32__Single(reader.ReadVarInt(), reader.ReadFloat());
		}
	}

	protected void UserCode_RpcResetDuckPosition()
	{
		if ((bool)penguin && (bool)startPoint)
		{
			penguin.DOMove(startPoint.position, stepTweenDuration).SetEase(Ease.OutQuad);
		}
	}

	protected static void InvokeUserCode_RpcResetDuckPosition(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcResetDuckPosition called on server.");
		}
		else
		{
			((CrossyRoad)obj).UserCode_RpcResetDuckPosition();
		}
	}

	protected void UserCode_RpcWinFeedback__Single(float mult)
	{
		if ((bool)penguinAnim)
		{
			penguinAnim.SetTrigger("Win");
		}
		if (sidePenguinAnims != null)
		{
			Animator[] array = sidePenguinAnims;
			foreach (Animator animator in array)
			{
				if ((bool)animator)
				{
					animator.SetTrigger("Win");
				}
			}
		}
		SFXManager.SFXOneShotWithParameters(crossyWinSFX, null, penguin ? penguin.transform.position : base.transform.position, 0.8f + mult * 0.04f);
	}

	protected static void InvokeUserCode_RpcWinFeedback__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcWinFeedback called on server.");
		}
		else
		{
			((CrossyRoad)obj).UserCode_RpcWinFeedback__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_RpcCrashFeedback__Int32__Single(int step, float mult)
	{
		if (iceCubes != null && iceCubes.Length != 0)
		{
			Transform transform = iceCubes[Mathf.Clamp(step - 1, 0, iceCubes.Length - 1)];
			if ((bool)transform)
			{
				if ((bool)waterVfx)
				{
					waterVfx.transform.position = transform.position;
				}
				Sequence s = DOTween.Sequence();
				s.Append(transform.DOShakePosition(0.2f, 0.1f).SetEase(Ease.OutCirc));
				s.Append(transform.DOLocalMoveY(-0.2f, 0.8f).SetEase(Ease.InCirc));
				s.AppendInterval(0.5f);
				s.AppendCallback(delegate
				{
					if ((bool)waterVfx)
					{
						waterVfx.Play();
					}
				});
				s.AppendInterval(0.5f);
				s.Append(transform.DOLocalMoveY(0f, 0.5f).SetEase(Ease.OutBack));
			}
		}
		if ((bool)penguinAnim)
		{
			penguinAnim.SetTrigger("Crash");
		}
		SFXManager.SFXOneShotWithParameters(crossyDuckLoseSFX, null, penguin ? penguin.transform.position : base.transform.position, 0.8f + mult * 0.04f);
		SFXManager.SFXOneShotWithParameters(crossyLoseSFX, null, base.transform.position);
	}

	protected static void InvokeUserCode_RpcCrashFeedback__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcCrashFeedback called on server.");
		}
		else
		{
			((CrossyRoad)obj).UserCode_RpcCrashFeedback__Int32__Single(reader.ReadVarInt(), reader.ReadFloat());
		}
	}

	static CrossyRoad()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(CrossyRoad), "System.Void CrossyRoad::RpcPenguinStep(System.Int32,System.Single)", InvokeUserCode_RpcPenguinStep__Int32__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(CrossyRoad), "System.Void CrossyRoad::RpcResetDuckPosition()", InvokeUserCode_RpcResetDuckPosition);
		RemoteProcedureCalls.RegisterRpc(typeof(CrossyRoad), "System.Void CrossyRoad::RpcWinFeedback(System.Single)", InvokeUserCode_RpcWinFeedback__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(CrossyRoad), "System.Void CrossyRoad::RpcCrashFeedback(System.Int32,System.Single)", InvokeUserCode_RpcCrashFeedback__Int32__Single);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteDouble(currentMultiplier);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteDouble(currentMultiplier);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref currentMultiplier, _Mirror_SyncVarHookDelegate_currentMultiplier, reader.ReadDouble());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentMultiplier, _Mirror_SyncVarHookDelegate_currentMultiplier, reader.ReadDouble());
		}
	}
}
