using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Audio")]
	public class PlayAudioAtPosition : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<AudioClip> audioClip;

		[SliderField(0, 1)]
		public float volume;

		public bool waitActionFinish;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
