using Assets.Scripts.Actors.Player;
using UnityEngine;

public class FootstepFx : MonoBehaviour
{
	public RandomSfx sfx;

	public ParticleSystem ps;

	private bool inited;

	private void Awake()
	{
		if (!inited)
		{
			inited = true;
			RandomSfx randomSfx = sfx;
			MyPlayer instance = MyPlayer.Instance;
			CharacterData characterData = DataManager.Instance.GetCharacterData(instance.character);
			randomSfx.sounds = characterData.audioFootsteps;
		}
	}

	private void OnEnable()
	{
		sfx.Play();
		ps.Play();
	}
}
