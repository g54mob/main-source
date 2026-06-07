using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public struct PlayableReference : IDisposable
{
	private PlayableGraph _graph;

	private readonly AnimationPlayableOutput _output;

	public PlayableReference(string graph, string output, Animator animator, DirectorUpdateMode updateMode = DirectorUpdateMode.GameTime)
	{
		this = default(PlayableReference);
		_graph = PlayableGraph.Create(graph);
		_output = AnimationPlayableOutput.Create(_graph, output, animator);
	}

	public void Dispose()
	{
		_graph.Destroy();
	}

	public void Play(AnimationClip clip)
	{
		AnimationClipPlayable value = AnimationClipPlayable.Create(_graph, clip);
		_output.SetSourcePlayable(value);
		_graph.Play();
	}
}
