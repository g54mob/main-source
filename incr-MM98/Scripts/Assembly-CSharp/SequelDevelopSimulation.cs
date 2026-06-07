using System;
using MessagePipe;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Sequel Develop", fileName = "SequelDevelopSimulation")]
public class SequelDevelopSimulation : ScriptableObject, IIncrementalSimulation
{
	private IDisposable _subscriptions;

	public void Registered(UIRegistry? registry)
	{
		EventHub.Scene.For().Subscribe(delegate
		{
			HandlePrestige();
		}, Array.Empty<MessageHandlerFilter<FirstGameReleased>>()).Subscribe(delegate
		{
			HandlePrestige();
		}, Array.Empty<MessageHandlerFilter<Prestiged>>())
			.Subscribe(delegate
			{
				HandleDevelopment();
			}, Array.Empty<MessageHandlerFilter<DevelopmentAttempted>>())
			.Build(out _subscriptions);
	}

	public void Unregistered()
	{
		_subscriptions?.Dispose();
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		DatabaseState.SequelState sequel = Database.State.Sequel;
		if (sequel.Developing.Value)
		{
			sequel.Time.AddValue(deltaTime);
			if (sequel.IsDoneDeveloping)
			{
				FinishDevelopment();
			}
		}
	}

	private void HandlePrestige()
	{
		CalculateProgressIncrease();
		AssignNextDevelopmentCost();
	}

	private void HandleDevelopment()
	{
		if (!Database.State.Sequel.Developing.Value && Database.Commands.Resource.AttemptBuyMoney(Database.State.Sequel.Cost.Value))
		{
			Database.State.Sequel.Time.SetValue(0f);
			Database.State.Sequel.Duration.SetValue(ModifierType.DevelopmentTime.Float());
			Database.State.Sequel.Developing.Value = true;
			Database.Commands.IRC.Print(IRCSystem.DevelopmentStart);
		}
	}

	private void FinishDevelopment()
	{
		Database.State.Sequel.Time.SetValue(0f);
		Database.State.Sequel.Duration.SetValue(0f);
		Database.State.Sequel.Round.Increment();
		CalculateProgressIncrease();
		AssignNextDevelopmentCost();
		Database.State.Sequel.Developing.Value = false;
		Database.State.Sequel.DevelopmentNotification = !(UI.CurrentView is SequelView);
		Database.Commands.IRC.Print(IRCSystem.DevelopmentEnded);
		Audio.PlaySfx(AudioDataType.DevelopmentComplete, Mathf.Lerp(0.8f, 1.2f, Database.State.Sequel.Progress.Normalized));
	}

	private void CalculateProgressIncrease()
	{
		DatabaseState.SequelState sequel = Database.State.Sequel;
		float num = ((sequel.Round.Value == 1) ? ModifierType.DevelopmentFirstRoundMultiplier.Float() : 1f);
		sequel.Progress.GameDesign.Value += Mathf.Clamp01(UnityEngine.Random.Range(0.05f, 0.15f)) * num;
		sequel.Progress.Art.Value += Mathf.Clamp01(UnityEngine.Random.Range(0.05f, 0.15f)) * num;
		sequel.Progress.Netcode.Value += Mathf.Clamp01(UnityEngine.Random.Range(0.05f, 0.15f)) * num;
		sequel.Progress.Marketing.Value += Mathf.Clamp01(UnityEngine.Random.Range(0.05f, 0.15f)) * num;
		sequel.Progress.Qa.Value += Mathf.Clamp01(UnityEngine.Random.Range(0.05f, 0.15f)) * num;
		float normalized = sequel.Progress.Normalized;
		float x = Mathf.Max(normalized - ModifierType.DevelopmentFansRange.Float(), 0f);
		float y = Mathf.Min(normalized + ModifierType.DevelopmentFansRange.Float(), 1f);
		sequel.Progress.FactorRange.Value = new Vector2(x, y);
	}

	private void AssignNextDevelopmentCost()
	{
		(float, int) tuple = (ModifierType.DevelopmentCostDevFactor.Float(), Database.State.Sequel.Round.Value);
		(float, int) tuple2 = (ModifierType.DevelopmentCostReleaseFactor.Float(), Database.State.Metrics.Releases.Value - 1);
		Database.State.Sequel.Cost.SetValue(Database.Commands.Resource.CalculateScaledCost(ModifierType.DevelopmentCost.Double(), tuple, tuple2));
	}
}
