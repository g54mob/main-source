using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

public class ActivateVFXController : MonoBehaviour
{
	[FormerlySerializedAs("_miningVFXs")]
	[SerializeField]
	private List<VisualEffect> _effects = new List<VisualEffect>();

	private const string PLAY_EVENT_NAME = "Play";

	public void Play()
	{
		foreach (VisualEffect effect in _effects)
		{
			effect.SendEvent("Play");
		}
	}
}
