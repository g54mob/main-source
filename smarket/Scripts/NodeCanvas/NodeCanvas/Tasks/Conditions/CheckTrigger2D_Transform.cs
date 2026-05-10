using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("System Events")]
	[Name("Check Trigger 2D", 0)]
	[Description("The agent is type of Transform so that Triggers can either work with a Collider or a Rigidbody attached.")]
	public class CheckTrigger2D_Transform : ConditionTask<Transform>
	{
		public TriggerTypes CheckType;

		public bool specifiedTagOnly;

		[TagField]
		public string objectTag;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGameObjectAs;

		private bool stay;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public void OnTriggerEnter2D(EventData<Collider2D> data)
		{
		}

		public void OnTriggerExit2D(EventData<Collider2D> data)
		{
		}
	}
}
