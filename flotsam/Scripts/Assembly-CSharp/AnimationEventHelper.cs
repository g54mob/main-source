using PajamaLlama.Debugs;
using UnityEngine;

[AddComponentMenu("Flotsam/Animation/Animation Event Helper")]
public class AnimationEventHelper : MonoBehaviour
{
	public void TriggerObject(AnimationEventHelperProperties eventProperties)
	{
		if (eventProperties.PlayAudio)
		{
			if (eventProperties.TrackTransform)
			{
				AudioManager.Play(eventProperties.AudioProperties, base.transform);
			}
			else
			{
				AudioManager.Play(eventProperties.AudioProperties, base.transform);
			}
		}
		if (!eventProperties.SpawnParticle)
		{
			return;
		}
		if (eventProperties.ParticleControllers.Count > 0)
		{
			ParticleController prefab = FlotsamGame.Random(eventProperties.ParticleControllers);
			if (eventProperties.TrackTransform)
			{
				ParticleController.Spawn(prefab, base.transform, eventProperties.Offset);
				return;
			}
			Vector3 vector = base.transform.rotation * eventProperties.Offset;
			ParticleController.Spawn(prefab, base.transform.position + vector, base.transform.rotation);
		}
		else
		{
			Debugger.Warning($"No particle controller available for animation event {eventProperties.name}.");
		}
	}
}
