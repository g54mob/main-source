using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class OnParticleDeath : MonoBehaviour
{
	public SFXTableIDField deathSound;

	private ParticleSystem part;

	private List<ParticleCollisionEvent> collisionEvents;

	private void Start()
	{
		part = GetComponent<ParticleSystem>();
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	private void OnParticleCollision(GameObject other)
	{
		int num = part.GetCollisionEvents(other, collisionEvents);
		if (num == 0)
		{
			return;
		}
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		Vector3Int renderOrigo = Manager.camera.RenderOrigo;
		for (int i = 0; i < num; i++)
		{
			Vector3 intersection = collisionEvents[i].intersection;
			Vector3 vec = renderOrigo + intersection;
			AudioManager.Sfx(deathSound.value, intersection, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
			bool hasWater;
			TileInfo topTileAndCheckWater = tileLayerLookup.GetTopTileAndCheckWater(vec.RoundToInt2(), out hasWater);
			if (hasWater && topTileAndCheckWater.tileType != TileType.bridge)
			{
				WaterSim.AddImpulse(intersection);
			}
		}
	}
}
