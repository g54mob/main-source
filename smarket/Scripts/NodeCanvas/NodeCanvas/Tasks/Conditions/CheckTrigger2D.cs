using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("System Events")]
	[Name("Check Trigger 2D", 0)]
	[DoNotList]
	public class CheckTrigger2D : ConditionTask<Collider2D>
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
