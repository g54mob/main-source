using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Play Audio")]
	public class PlayAudioTask : MTask
	{
		[Space]
		public AudioClipReference Clips;

		public string AudioSource = "BrainAudio";

		public override string DisplayName => "General/Play Audio";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			Transform transform = brain.transform.FindGrandChild(AudioSource);
			if (!transform)
			{
				transform = new GameObject(AudioSource).transform;
				transform.parent = brain.transform;
			}
			if (!transform.TryGetComponent<AudioSource>(out var component))
			{
				component = transform.gameObject.AddComponent<AudioSource>();
			}
			brain.TasksVars[index].AddComponent(component);
			Clips.Play(component);
			brain.TaskDone(index);
		}

		private void Reset()
		{
			Description = "Plays an Audioclip in the Audio Source. If there's no Audio Source with the name assigned []. I will add a new Audio Source Component ";
		}
	}
}
