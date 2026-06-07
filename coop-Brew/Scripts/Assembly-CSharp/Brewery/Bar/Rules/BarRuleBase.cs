using UnityEngine;

namespace Brewery.Bar.Rules
{
	public abstract class BarRuleBase : ScriptableObject, IBarRule
	{
		[Header("Rule Settings")]
		[Tooltip("Display name of this rule")]
		[SerializeField]
		protected string ruleName;

		[Tooltip("Which NPCs this rule affects (Inside, Outside, or All)")]
		[SerializeField]
		protected RuleScope scope;

		[Tooltip("Weight of this rule in mood calculation (0-1). Higher = more impact.")]
		[Range(0f, 1f)]
		[SerializeField]
		protected float weight;

		[Header("UI Display")]
		[Tooltip("Icon to show in the UI when this rule is satisfied")]
		[SerializeField]
		protected Sprite satisfiedIcon;

		[Tooltip("Icon to show in the UI when this rule is not satisfied")]
		[SerializeField]
		protected Sprite unsatisfiedIcon;

		[Tooltip("Description shown in the bar controls UI")]
		[TextArea(2, 4)]
		[SerializeField]
		protected string description;

		public string RuleName => null;

		public RuleScope Scope => default(RuleScope);

		public float Weight => 0f;

		public Sprite SatisfiedIcon => null;

		public Sprite UnsatisfiedIcon => null;

		public string Description => null;

		public abstract RuleStatus Evaluate(BarRuleContext context);

		public abstract string GetComplaintMessage(RuleStatus status);

		public virtual string GetStatusMessage(RuleStatus status)
		{
			return null;
		}

		protected static string GetLocalizedComplaint(string[] keys, string fallbackKey)
		{
			return null;
		}
	}
}
