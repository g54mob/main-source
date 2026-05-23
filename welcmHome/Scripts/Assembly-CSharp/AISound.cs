using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AISound : MonoBehaviour
{
	public NPCBaseController AI;

	private EventReference soundToPlayCarpet;

	private EventReference soundToPlayWoodInside;

	private EventReference soundToPlayDirt;

	private EventReference soundToPlayWoodOutside;

	private EventReference soundToPlayStairs;

	private EventReference soundToPlayGrass;

	public AISoundEnum terrain;

	private float noiseTime;

	private void Start()
	{
		soundToPlayCarpet = RuntimeManager.PathToEventReference("event:/World/NPCWalk/CarpetFootstep3D");
		soundToPlayDirt = RuntimeManager.PathToEventReference("event:/World/NPCWalk/DirtFootstep3D");
		soundToPlayWoodInside = RuntimeManager.PathToEventReference("event:/World/NPCWalk/WoodFootstep3D");
		soundToPlayWoodOutside = RuntimeManager.PathToEventReference("event:/World/NPCWalk/WoodOutside3D");
		soundToPlayStairs = RuntimeManager.PathToEventReference("event:/World/NPCWalk/StairFootstep3D");
		soundToPlayGrass = RuntimeManager.PathToEventReference("event:/World/NPCWalk/GrassFootstep3D");
	}

	private void Update()
	{
		Debug.Log(noiseTime);
		if ((double)noiseTime >= 0.61 && AI.Activity == EActivity.WALKING)
		{
			PlayFootSound();
			noiseTime = 0f;
		}
		noiseTime += Time.deltaTime;
	}

	public void PlayFootSound()
	{
		switch (terrain)
		{
		case AISoundEnum.WoodInside:
			PlayWoodInsideSound();
			break;
		case AISoundEnum.Carpet:
			PlayCarpetSound();
			break;
		case AISoundEnum.Dirt:
			PlayDirtSound();
			break;
		case AISoundEnum.Grass:
			PlayGrassSound();
			break;
		case AISoundEnum.WoodOutside:
			PlayWoodOutsideSound();
			break;
		case AISoundEnum.Stairs:
			PlayStairSound();
			break;
		}
	}

	public void PlayCarpetSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayCarpet);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayWoodInsideSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayWoodInside);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayStairSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayStairs);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayDirtSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayDirt);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayWoodOutsideSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayWoodOutside);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayGrassSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayGrass);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
