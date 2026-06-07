using UnityEngine;

public class FootstepsAudioPlayer : MonoBehaviour
{
	private const float WATER_PUDDLE_THRESHOLD = 1.2f;

	private const float LANDING_VOLUME_VELOCITY_MULTIPLIER = 0.04f;

	public AFootstepsAudioProvider provider;

	private int previousFootstepIndex;

	public void PlayFootstepSound(FootstepsAudioScriptableObject.SurfaceType surface, Vector3 footstepPosition, float volume, Transform audioParent)
	{
		FootstepsAudioScriptableObject.FootstepsData footstepsData = provider.Data.defaultFootstepsData;
		if (surface != FootstepsAudioScriptableObject.SurfaceType.None)
		{
			FootstepsAudioScriptableObject.FootstepsData[] allData = provider.Data.allData;
			for (int i = 0; i < allData.Length; i++)
			{
				FootstepsAudioScriptableObject.FootstepsData footstepsData2 = allData[i];
				if (footstepsData2.surface == surface)
				{
					footstepsData = footstepsData2;
					break;
				}
			}
		}
		int count = footstepsData.footstepSoundClips.Count;
		int num;
		if (count == 1)
		{
			num = 0;
		}
		else
		{
			num = Random.Range(0, footstepsData.footstepSoundClips.Count);
			if (num == previousFootstepIndex)
			{
				num = (num + 1) % count;
			}
		}
		float pitch = 1f + Random.Range(0f - footstepsData.maxPitchShift, footstepsData.maxPitchShift);
		AudioClip clip = footstepsData.footstepSoundClips[num];
		provider.Play(clip, footstepPosition, volume, pitch, audioParent);
		previousFootstepIndex = num;
	}

	private FootstepsAudioScriptableObject.SurfaceType GetFootstepSurface(Vector3 footstepPosition, RaycastHit hit)
	{
		if (provider.IsPlayerAtWaterSurface(footstepPosition))
		{
			return FootstepsAudioScriptableObject.SurfaceType.Water;
		}
		if (provider.SurfacesDictionary == null || provider.TerrainTextureIndexToSurfaceType == null)
		{
			Debug.LogWarning("[FootstepsAudioPlayer] provider SurfacesDictionary or TerrainTextureIndexToSurfaceType is null", this);
			return FootstepsAudioScriptableObject.SurfaceType.None;
		}
		if (hit.collider.sharedMaterial != null && provider.SurfacesDictionary.TryGetValue(hit.collider.sharedMaterial.name, out var value))
		{
			if (value == FootstepsAudioScriptableObject.SurfaceType.Asphalt)
			{
				return (provider.SamplePuddle(footstepPosition) > 1.2f) ? FootstepsAudioScriptableObject.SurfaceType.Liquid : FootstepsAudioScriptableObject.SurfaceType.None;
			}
			return value;
		}
		if (hit.collider.gameObject.layer == provider.Data.terrainLayer)
		{
			TerrainCollider component = hit.transform.GetComponent<TerrainCollider>();
			TerrainData terrainData = ((component != null) ? component.terrainData : null);
			if (terrainData != null)
			{
				int dominantTextureIndex = GetDominantTextureIndex(terrainData, footstepPosition, hit.transform.position);
				if (provider.TerrainTextureIndexToSurfaceType.TryGetValue(dominantTextureIndex, out value))
				{
					return value;
				}
				return FootstepsAudioScriptableObject.SurfaceType.None;
			}
		}
		return FootstepsAudioScriptableObject.SurfaceType.None;
	}

	private void PlayLandingSound(Vector3 footstepPosition, float volume, Transform audioParent)
	{
		if (volume >= 0.1f && volume < 0.5f)
		{
			provider.Play(provider.Data.landingSoundSoft, footstepPosition, volume, 1f, audioParent);
		}
		else if (volume >= 0.5f)
		{
			provider.Play(provider.Data.landingSoundHard, footstepPosition, volume, 1f, audioParent);
		}
	}

	public void RequestPlayFootstepSound(FootstepsAudioScriptableObject.MovementType movType, Vector3 footstepPosition, float playerVelocityMagnitude = 0f, float sphereCastRadius = 0.135f, Transform audioParent = null)
	{
		if (provider.Data == null || !Physics.SphereCast(new Ray(footstepPosition + new Vector3(0f, 1f, 0f), Vector3.down), sphereCastRadius, out var hitInfo, 2f, provider.Data.traversableLayers))
		{
			return;
		}
		FootstepsAudioScriptableObject.SurfaceType footstepSurface = GetFootstepSurface(footstepPosition, hitInfo);
		float num = 0f;
		switch (movType)
		{
		case FootstepsAudioScriptableObject.MovementType.Walking:
			num = provider.Data.walkFootstepVolume;
			PlayFootstepSound(footstepSurface, footstepPosition, num, audioParent);
			break;
		case FootstepsAudioScriptableObject.MovementType.Running:
			num = provider.Data.runFootstepVolume;
			PlayFootstepSound(footstepSurface, footstepPosition, num, audioParent);
			break;
		case FootstepsAudioScriptableObject.MovementType.Crouching:
			num = provider.Data.crouchFootstepVolume;
			PlayFootstepSound(footstepSurface, footstepPosition, num, audioParent);
			break;
		case FootstepsAudioScriptableObject.MovementType.Landing:
			if (footstepSurface != FootstepsAudioScriptableObject.SurfaceType.Liquid && footstepSurface != FootstepsAudioScriptableObject.SurfaceType.Water)
			{
				num = playerVelocityMagnitude * 0.04f;
				PlayLandingSound(footstepPosition, num, audioParent);
			}
			break;
		}
	}

	private int GetDominantTextureIndex(TerrainData terrainData, Vector3 worldPos, Vector3 terrainPos)
	{
		int x = (int)Mathf.Clamp((worldPos.x - terrainPos.x) / terrainData.size.x * (float)terrainData.alphamapWidth, 0f, terrainData.alphamapWidth - 1);
		int y = (int)Mathf.Clamp((worldPos.z - terrainPos.z) / terrainData.size.z * (float)terrainData.alphamapHeight, 0f, terrainData.alphamapHeight - 1);
		float[,,] alphamaps = terrainData.GetAlphamaps(x, y, 1, 1);
		float num = 0f;
		int result = 0;
		int length = alphamaps.GetLength(2);
		for (int i = 0; i < length; i++)
		{
			float num2 = alphamaps[0, 0, i];
			if (num2 > num)
			{
				result = i;
				num = num2;
			}
		}
		return result;
	}
}
