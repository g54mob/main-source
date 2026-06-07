using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Tween")]
	[Icon("DOTTween", true, null)]
	public class TweenPosition : ActionTask<Transform>
	{
		public BBParameter<Vector3> vector;

		public BBParameter<float> delay;

		public BBParameter<float> duration;

		public Ease easeType;

		public bool relative;

		public bool useSnapping;

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
