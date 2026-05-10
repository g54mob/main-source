using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Tween")]
	[Icon("DOTTween", true, null)]
	public class TweenPunchRotation : ActionTask<Transform>
	{
		public BBParameter<Vector3> ammount;

		public BBParameter<float> delay;

		public BBParameter<float> duration;

		public Ease easeType;

		public int vibrato;

		public float elasticity;

		public bool waitActionFinish;

		private string id;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnStop()
		{
		}
	}
}
