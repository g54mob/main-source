using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class WorldMapDirectorReveal : WorldMapReveal
{
	[Serializable]
	private struct ScoutedGameObject
	{
		public GameObject GameObject;

		[Tooltip("Is the GameObject active when the POI has not been revealed.")]
		public bool preRevealActive;

		[Tooltip("Is the GameObject active when the POI has been revealed.")]
		public bool postRevealActive;

		public void SetRevealedState(bool revealed)
		{
			GameObject.SetActive(revealed ? postRevealActive : preRevealActive);
		}
	}

	[SerializeField]
	private PlayableDirector _director;

	[SerializeField]
	[Tooltip("List of GameObjects which state depends on wether the POI is scouted or not.")]
	private ScoutedGameObject[] _scoutedGameObjects;

	private WorldMapPointOfInterest _poi;

	private bool _revealed;

	private void OnEnable()
	{
		SetRevealed(_revealed);
	}

	public override void Initialize(WorldMapPointOfInterest poi)
	{
		_poi = poi;
		SetRevealed(_poi.Spawner.ScoutingState == ScoutingState.Scouted);
	}

	public override bool InitializeReveal(WorldMapPointOfInterest poi)
	{
		SetRevealed(revealed: false);
		return true;
	}

	public override IEnumerator Reveal(WorldMapPointOfInterest poi)
	{
		_director.Play();
		while (_director.time < _director.duration)
		{
			yield return null;
		}
		_revealed = true;
	}

	private void SetRevealed(bool revealed)
	{
		_revealed = revealed;
		ScoutedGameObject[] scoutedGameObjects = _scoutedGameObjects;
		foreach (ScoutedGameObject scoutedGameObject in scoutedGameObjects)
		{
			scoutedGameObject.SetRevealedState(revealed);
		}
	}

	public void ClearFogOfWar()
	{
		if ((bool)_poi)
		{
			_poi.Spawner.ClearFogOfWar();
		}
	}
}
