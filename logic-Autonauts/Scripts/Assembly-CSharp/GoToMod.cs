using UnityEngine;

public class GoToMod : GoTo
{
	[HideInInspector]
	public enum State
	{
		None = 0,
		Moving = 1,
		RequestMove = 2,
		Total = 3
	}

	public State m_State;

	public float m_StateTimer;

	public override void Restart()
	{
		base.Restart();
		m_State = State.None;
		Vector3 Scale = new Vector3(-1f, 1f, 1f);
		ModManager.Instance.ModGoToClass.GetModelScale(m_TypeIdentifier, out Scale);
		m_ModelRoot.transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
		Vector3 Rot;
		if (ModManager.Instance.ModGoToClass.GetModelRotation(m_TypeIdentifier, out Rot))
		{
			m_ModelRoot.transform.localRotation = Quaternion.Euler(Rot.x, Rot.y, Rot.z);
		}
		Vector3 Trans;
		if (ModManager.Instance.ModGoToClass.GetModelTranslation(m_TypeIdentifier, out Trans))
		{
			m_ModelRoot.transform.localPosition = new Vector3(Trans.x, Trans.y, Trans.z);
		}
	}

	public virtual void SetState(State NewState)
	{
		m_State = NewState;
		m_StateTimer = 0f;
	}

	public override bool RequestGoTo(TileCoord Destination, Actionable TargetObject = null, bool LessOne = false, int Range = 0)
	{
		if (m_State != State.None && m_State != State.Moving && m_State != State.RequestMove)
		{
			return false;
		}
		SetState(State.RequestMove);
		return base.RequestGoTo(Destination, TargetObject, LessOne, Range);
	}

	public override bool StartGoTo(TileCoord Destination, Actionable TargetObject = null, bool LessOne = false, int Range = 0)
	{
		if (m_State != State.None && m_State != State.Moving && m_State != State.RequestMove)
		{
			return false;
		}
		SetState(State.Moving);
		return base.StartGoTo(Destination, TargetObject, LessOne, Range);
	}

	public override void EndGoTo()
	{
		SetState(State.None);
	}

	protected virtual void UpdateStateMove()
	{
		UpdateMovement();
	}

	protected virtual void Update()
	{
		if (!TimeManager.Instance || TimeManager.Instance.m_NormalTimeEnabled)
		{
			State state = m_State;
			if (state == State.Moving)
			{
				UpdateStateMove();
			}
			if ((bool)TimeManager.Instance)
			{
				m_StateTimer += TimeManager.Instance.m_NormalDelta;
			}
		}
	}
}
