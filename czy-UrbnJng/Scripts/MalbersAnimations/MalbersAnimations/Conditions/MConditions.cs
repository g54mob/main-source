using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Conditions
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/global-components/conditions")]
	[AddComponentMenu("Malbers/Interactions/Conditions")]
	[DisallowMultipleComponent]
	public class MConditions : MonoBehaviour
	{
		[Tooltip("Evaluate the conditions on Enable")]
		public bool EvaluateOnEnable;

		public bool EvaluateOnDisable;

		[SerializeReference]
		public List<MCondition> conditions;

		public UnityEvent Then = new UnityEvent();

		public UnityEvent Else = new UnityEvent();

		public MCondition Pinned;

		public bool debug;

		[HideInInspector]
		[SerializeField]
		private int SelectedState = -1;

		[HideInInspector]
		[SerializeField]
		private bool showResponse = true;

		private void OnEnable()
		{
			if (EvaluateOnEnable)
			{
				TryEvaluate();
			}
		}

		private void OnDisable()
		{
			if (EvaluateOnDisable)
			{
				TryEvaluate();
			}
		}

		public virtual void SetTarget(Object target)
		{
			foreach (MCondition condition in conditions)
			{
				condition.SetTarget(target);
			}
		}

		public virtual void Pin_SetTarget(Object target)
		{
			Pinned?.SetTarget(target);
		}

		public virtual void Pin_Condition(int Index)
		{
			Pinned = conditions[Index];
		}

		public void Evaluate()
		{
			TryEvaluate();
		}

		public void Evaluate(Object target)
		{
			SetTarget(target);
			TryEvaluate();
		}

		public void Evaluate_OnTrue(bool value)
		{
			if (value)
			{
				TryEvaluate();
			}
		}

		public void Evaluate_OnFalse(bool value)
		{
			if (!value)
			{
				TryEvaluate();
			}
		}

		public void Evaluate_OnInt(int value)
		{
			if (value > 0)
			{
				TryEvaluate();
			}
		}

		[ContextMenu("Show Conditions")]
		private void ShowAllConditions()
		{
			MCondition[] components = GetComponents<MCondition>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].hideFlags = HideFlags.None;
			}
		}

		[ContextMenu("Hide Conditions")]
		private void HideAllConditions()
		{
			MCondition[] components = GetComponents<MCondition>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].hideFlags = HideFlags.HideInInspector;
			}
		}

		public bool TryEvaluate()
		{
			if (conditions != null && conditions.Count > 0)
			{
				MCondition mCondition = conditions[0];
				bool flag = mCondition.Evaluate();
				Debuggin(mCondition, flag);
				for (int i = 1; i < conditions.Count; i++)
				{
					mCondition = conditions[i];
					bool flag2 = mCondition.Evaluate();
					Debuggin(mCondition, flag2);
					flag = (mCondition.OrAnd ? (flag || flag2) : (flag && flag2));
				}
				if (flag)
				{
					Then.Invoke();
				}
				else
				{
					Else.Invoke();
				}
				if (debug)
				{
					Debug.Log(string.Format("[{0}] → Conditions Result → <B><color={1}>[{2}] </color></B>", base.name, flag ? "green" : "red", flag), this);
				}
				return flag;
			}
			return false;
		}

		public void InvokeThen()
		{
			Then.Invoke();
		}

		public void InvokeElse()
		{
			Else.Invoke();
		}

		private void Debuggin(MCondition c, bool result)
		{
			if (debug)
			{
				Debug.Log(string.Format("[{0}] →  Cond: <B>[{1}] {2}  → <color={3}>[{4}] </color></B>.", base.name, c.GetType().Name, c.invert ? "[!]" : " ", result ? "green" : "red", result), this);
			}
		}
	}
}
