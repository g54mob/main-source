using System;
using System.Collections.Generic;

public abstract class MotorView : BaseComponentView
{
	protected List<HingeJointView> hingeJointViews = new List<HingeJointView>();

	protected int maxJoints;

	private bool isFirstTimeInUse;

	public bool IsMotorInUse { get; private set; }

	public event Action OnTurnOnMotorEvent;

	protected abstract void MotorJointStart(HingeJointView hingeJointView);

	protected abstract bool MotorJointHandler(HingeJointView hingeJointView, bool isAxisConnected = true);

	protected abstract void SteerableJointStart(HingeJointView hingeJointView);

	protected abstract bool SteerableJointHandler(HingeJointView hingeJointView, bool isAxisConnected = true);

	protected abstract void StepperJointStart(HingeJointView hingeJointView);

	protected abstract bool StepperJointHandler(HingeJointView hingeJointView, bool isAxisConnected = true);

	public override ComponentType GetComponentType()
	{
		return ComponentType.Motor;
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		foreach (HingeJointView hingeJointView in hingeJointViews)
		{
			if (hingeJointView.MotorJointView != null)
			{
				MotorJointStart(hingeJointView);
			}
			else if (hingeJointView.SteerableJointView != null)
			{
				SteerableJointStart(hingeJointView);
			}
			else if (hingeJointView.StepperJointView != null)
			{
				StepperJointStart(hingeJointView);
			}
		}
		IsMotorInUse = false;
		isFirstTimeInUse = true;
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		hingeJointViews.Clear();
	}

	protected void FixedUpdate()
	{
		IsMotorInUse = false;
		foreach (HingeJointView hingeJointView in hingeJointViews)
		{
			if (!(hingeJointView.HingeJoint == null))
			{
				bool isAxisConnected = base.BlockBodyView.GroupLeaderBlockBodyView == hingeJointView.ParentBlockBodyView.GroupLeaderBlockBodyView;
				if (hingeJointView.MotorJointView != null)
				{
					IsMotorInUse |= MotorJointHandler(hingeJointView, isAxisConnected);
				}
				else if (hingeJointView.SteerableJointView != null)
				{
					IsMotorInUse |= SteerableJointHandler(hingeJointView, isAxisConnected);
				}
				else if (hingeJointView.StepperJointView != null)
				{
					IsMotorInUse |= StepperJointHandler(hingeJointView, isAxisConnected);
				}
			}
		}
		if (isFirstTimeInUse && IsMotorInUse)
		{
			if (this.OnTurnOnMotorEvent != null)
			{
				this.OnTurnOnMotorEvent();
			}
			isFirstTimeInUse = false;
		}
	}

	public void AddHingeJointViews(HingeJointView hingeJointView)
	{
		if (!hingeJointViews.Contains(hingeJointView))
		{
			hingeJointViews.Add(hingeJointView);
		}
	}

	public void RemoveHingeJointView(HingeJointView hingeJointView)
	{
		if (hingeJointViews.Contains(hingeJointView))
		{
			hingeJointViews.Remove(hingeJointView);
		}
	}

	public ICollection<HingeJointView> GetAllHingeJointViews()
	{
		return hingeJointViews.ToArray();
	}

	protected int JointsCount()
	{
		return hingeJointViews.Count;
	}
}
