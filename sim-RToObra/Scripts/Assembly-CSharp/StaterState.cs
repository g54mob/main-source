using System;
using System.Collections.Generic;
using UnityEngine;

public class StaterState<Id> where Id : struct, IConvertible
{
	public readonly Id id;

	public float interpDuration;

	public float stepDuration;

	public Id afterStateId;

	public bool hasAfterStateId;

	public bool needsStep;

	public float stepTime;

	private float seqBaseTime;

	private List<StaterFunc> funcs = new List<StaterFunc>();

	private List<StaterTarget> targets = new List<StaterTarget>();

	public StaterState(Id id_)
	{
		id = id_;
	}

	public StaterState<Id> AddFunc(StaterFunc func)
	{
		funcs.Add(func);
		needsStep = func.time == StaterFunc.Time.Step || func.time == StaterFunc.Time.AtStep;
		if (func.time == StaterFunc.Time.SeqInterp)
		{
			func.f1 = seqBaseTime + func.f0;
			func.f0 = seqBaseTime;
			seqBaseTime = func.f1;
		}
		else if (func.time == StaterFunc.Time.Seq)
		{
			func.f0 = seqBaseTime;
		}
		return this;
	}

	public void ApplySeqTimeToStepDuration()
	{
		stepDuration = seqBaseTime;
	}

	public StaterState<Id> AddTarget(StaterTarget target)
	{
		targets.Add(target);
		return this;
	}

	public StaterState<Id> AddTarget(StaterProp prop, StaterVariant value1, StaterInterp interp = null)
	{
		if (interp == null)
		{
			interp = new StaterInterp_Linear();
		}
		targets.Add(new StaterTarget(prop, value1, interp));
		return this;
	}

	public StaterState<Id> SetDurations(float interpDuration_, float stepDuration_ = 0f)
	{
		interpDuration = interpDuration_;
		stepDuration = stepDuration_;
		needsStep = stepDuration > 0f;
		return this;
	}

	public StaterState<Id> SetDurations(float interpDuration_, float stepDuration_, Id afterStateId_)
	{
		interpDuration = interpDuration_;
		stepDuration = stepDuration_;
		afterStateId = afterStateId_;
		hasAfterStateId = true;
		needsStep = stepDuration > 0f;
		return this;
	}

	public void Enter(bool interpFromCurrent = false)
	{
		if (interpFromCurrent)
		{
			foreach (StaterTarget target in targets)
			{
				target.value0 = target.prop.val;
			}
		}
		foreach (StaterFunc func in funcs)
		{
			if (func.time == StaterFunc.Time.Enter)
			{
				func.vFunc();
			}
			func.called = false;
		}
		stepTime = 0f;
		Apply((!interpFromCurrent) ? 1 : 0);
	}

	public void Step(float dt)
	{
		float num = stepTime;
		stepTime += dt;
		foreach (StaterFunc func in funcs)
		{
			if (func.time == StaterFunc.Time.AtStep)
			{
				float f = func.f0;
				if (!func.called && stepTime >= f)
				{
					func.called = true;
					func.vFunc();
				}
			}
			else if (func.time == StaterFunc.Time.Step)
			{
				func.vFunc();
			}
			else if (func.time == StaterFunc.Time.EveryFrame)
			{
				func.vFunc();
			}
			else if (func.time == StaterFunc.Time.SeqInterp)
			{
				if (stepTime >= func.f0)
				{
					if (stepTime < func.f1)
					{
						func.iFunc(Util.LerpScale(stepTime, func.f0, func.f1, 0f, 1f));
					}
					else if (!func.called)
					{
						func.iFunc(1f);
						func.called = true;
					}
				}
			}
			else if (func.time == StaterFunc.Time.Seq)
			{
				if (!func.called && stepTime >= func.f0)
				{
					func.vFunc();
					func.called = true;
				}
			}
			else if (func.time == StaterFunc.Time.Periodic)
			{
				float input = stepTime % func.f0;
				func.ciFunc(Mathf.FloorToInt(stepTime / func.f0), Util.LerpScale(input, 0f, func.f0, 0f, 1f));
			}
			else if (func.time == StaterFunc.Time.AtPeriodic)
			{
				int num2 = Mathf.FloorToInt((num - func.f1) / func.f0);
				int num3 = Mathf.FloorToInt((stepTime - func.f1) / func.f0);
				if (num2 != num3)
				{
					func.cFunc(Mathf.FloorToInt(stepTime / func.f0));
				}
				else if (func.f1 == 0f && !func.called)
				{
					func.cFunc(0);
					func.called = true;
				}
			}
		}
	}

	public void Trigger(string triggerId)
	{
		bool flag = false;
		foreach (StaterFunc func in funcs)
		{
			if (func.time == StaterFunc.Time.OnTrigger && func.s0 == triggerId)
			{
				func.vFunc();
				flag = true;
			}
		}
		if (!flag)
		{
			Debug.LogWarningFormat("{0} does not handle trigger \"{1}\"!", id.ToString(), triggerId);
		}
	}

	public void Exit()
	{
		RunInterpFuncs(1f);
		foreach (StaterFunc func in funcs)
		{
			if (func.time == StaterFunc.Time.Exit)
			{
				func.vFunc();
			}
		}
	}

	private void RunInterpFuncs(float interp)
	{
		foreach (StaterFunc func in funcs)
		{
			if (func.time == StaterFunc.Time.Interp)
			{
				func.iFunc(interp);
			}
			else if (func.time == StaterFunc.Time.AtInterp && !func.called && interp > func.f0)
			{
				func.vFunc();
				func.called = true;
			}
			else if (func.time == StaterFunc.Time.EveryFrame)
			{
				func.vFunc();
			}
		}
	}

	public void Apply(float interp)
	{
		RunInterpFuncs(interp);
		foreach (StaterTarget target in targets)
		{
			target.prop.val = StaterVariant.Lerp(target.value0, target.value1, target.interp.Interp(interp));
		}
	}
}
