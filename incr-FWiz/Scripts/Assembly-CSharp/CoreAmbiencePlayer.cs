using System.Collections.Generic;
using UnityEngine;

public class CoreAmbiencePlayer : MonoBehaviour
{
	public List<CoreAmbienceLayer> Layers;

	public static CoreAmbiencePlayer Instance { get; private set; }

	public CoreAmbienceLayer CurrentLayer { get; private set; }

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void AddTrack(CoreAmbienceTrack track)
	{
	}

	public void EvaluateLayerOpacity()
	{
	}

	public void OnLayerEmpty(CoreAmbienceLayer layer)
	{
	}

	private CoreAmbienceLayer CreateLayer(int level)
	{
		return null;
	}

	public CoreAmbienceLayer GetLayer(int level)
	{
		return null;
	}
}
