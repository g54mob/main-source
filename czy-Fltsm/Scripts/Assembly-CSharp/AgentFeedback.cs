using System.Collections.Generic;

public class AgentFeedback
{
	public enum State
	{
		Idle = 0,
		AttentionSeeking = 1
	}

	private static List<AgentFeedback> _instances;

	private Agent _agent;

	private State _state;

	private float _idleTime;

	private float _attentionTime;

	private float _attentionInvervalTime;

	public Project BlockedProject { get; private set; }

	public AgentFeedback(Agent agent)
	{
		_agent = agent;
		_agent.Properties.IdleTimeBeforeFeedback.NextValue();
		_agent.Properties.AttentionInterval.NextValue();
		_state = State.Idle;
		if (_instances == null)
		{
			_instances = new List<AgentFeedback>(32);
		}
		_instances.Add(this);
	}

	public void Dispose()
	{
		_instances.Remove(this);
	}

	public void Update(float deltaTime, int frame)
	{
		if (_instances[frame % _instances.Count] != this)
		{
			return;
		}
		switch (_agent.CurrentActivity)
		{
		case Activity.Idling:
			UpdateIdle(deltaTime);
			break;
		case Activity.AttentionSeeking:
			UpdateAttentionSeeking(deltaTime);
			break;
		default:
			if (_agent.Assignment == null)
			{
				_agent.UpdateActivity(Activity.Idling);
			}
			_idleTime = 0f;
			_agent.Properties.IdleTimeBeforeFeedback.NextValue();
			SetState(State.Idle);
			return;
		}
		_idleTime += deltaTime;
	}

	private void UpdateIdle(float deltaTime)
	{
		BlockedProject = ReturnBlockedProject();
		if ((float)_agent.Properties.IdleTimeBeforeFeedback < _idleTime && (float)_agent.Properties.AttentionInterval < _attentionInvervalTime && BlockedProject != null)
		{
			SetState(State.AttentionSeeking);
		}
		_attentionInvervalTime += deltaTime;
	}

	private void UpdateAttentionSeeking(float deltaTime)
	{
		BlockedProject = ReturnBlockedProject();
		if (BlockedProject == null || _agent.Properties.AttentionDuration < _attentionTime)
		{
			SetState(State.Idle);
		}
		_agent.LookAtObject(CameraController.Instance.Camera.transform);
		_attentionTime += deltaTime;
	}

	public void SetState(State state)
	{
		if (_state == state)
		{
			return;
		}
		switch (state)
		{
		case State.Idle:
			if (_agent.CurrentActivity == Activity.AttentionSeeking)
			{
				_agent.UpdateActivity(Activity.Idling);
			}
			_agent.WorldIconHandler.RemoveIcon(GameManager.Settings.AgentSettings.WarningIconProperties);
			_agent.Properties.AttentionInterval.NextValue();
			_attentionTime = 0f;
			_attentionInvervalTime = 0f;
			break;
		case State.AttentionSeeking:
			_agent.UpdateActivity(Activity.AttentionSeeking);
			_agent.WorldIconHandler.AddIcon(GameManager.Settings.AgentSettings.WarningIconProperties);
			AudioManager.Play(_agent.Descriptor.VoicePack.AttentionSounds, _agent.transform);
			break;
		}
		_state = state;
	}

	private Project ReturnBlockedProject()
	{
		if (_agent.Community.TryReturnAgentRunableBlockedProject(_agent, out var project, _agent.Properties.HandledBlockers))
		{
			return project;
		}
		return null;
	}
}
