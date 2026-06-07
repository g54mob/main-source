using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("System Events")]
	[Name("Check Collision", 0)]
	public class CheckCollision_Rigidbody : ConditionTask<Rigidbody>
	{
		public CollisionTypes checkType;

		public bool specifiedTagOnly;

		[TagField]
		public string objectTag;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGameObjectAs;

		[BlackboardOnly]
		public BBParameter<Vector3> saveContactPoint;

		[BlackboardOnly]
		public BBParameter<Vector3> saveContactNormal;

		private bool stay;

		protected override string info => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}

		public void OnCollisionEnter(EventData<Collision> data)
		{
		}

		public void OnCollisionExit(EventData<Collision> data)
		{
		}
	}
}
