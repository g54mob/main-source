using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Tween")]
	[Icon("DOTTween", true, null)]
	public class TweenColor : ActionTask<Renderer>
	{
		public BBParameter<Color> color;

		public BBParameter<float> delay;

		public BBParameter<float> duration;

		public Ease easeType;

		public bool waitActionFinish;

		private string id;

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
