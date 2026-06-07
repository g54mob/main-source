using System;
using System.Threading.Tasks;
using UnityEngine.Playables;

namespace GameCreator.Runtime.Characters.Animim
{
	public abstract class TAnimimOutput : PlayableBehaviour
	{
		protected static readonly Task TASK_COMPLETE = Task.FromResult(result: true);

		protected const float SAFE_TIME_EPSILON = 0.01f;

		[NonSerialized]
		protected readonly AnimimGraph m_AnimimGraph;

		[field: NonSerialized]
		protected Playable ScriptPlayable { get; private set; }

		internal abstract float RootMotion { get; }

		protected TAnimimOutput(AnimimGraph animimGraph)
		{
			m_AnimimGraph = animimGraph;
		}

		internal abstract void OnDeleteChild(TAnimimPlayableBehaviour playableBehaviour);

		public override void OnPlayableCreate(Playable playable)
		{
			base.OnPlayableCreate(playable);
			ScriptPlayable = playable;
		}
	}
}
