using System;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;
using Cpp2ILInjected;
using UnityEngine;

public class MenuVisuals : MonoBehaviour
{
	public Terrain terrain;

	public GrassChunkManager grassRenderer;

	public StageData defaultStageVisuals;

	public MapData defaultMapVisuals;

	public AudioClip dungeonAmbience;

	public GameObject general;

	public GameObject dungeon;

	private StageData currentStageData;

	public Transform camera;

	public GameObject particles;

	public GameObject forestBg;

	public GameObject desertBg;

	public Light sunLight;

	public AudioSource ambience;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<RunConfig> b = OnRunConfigChanged;
		Delegate obj = Delegate.Combine(MapSelectionUi.A_RunConfigChanged, b);
		if ((object)obj == null)
		{
			MapSelectionUi.A_RunConfigChanged = (Action<RunConfig>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<RunConfig> action = default(Action<RunConfig>);
		if (action != null)
		{
			MapSelectionUi.A_RunConfigChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<RunConfig>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<RunConfig>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<RunConfig> value = OnRunConfigChanged;
		Delegate obj = Delegate.Remove(MapSelectionUi.A_RunConfigChanged, value);
		if ((object)obj == null)
		{
			MapSelectionUi.A_RunConfigChanged = (Action<RunConfig>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<RunConfig> action = default(Action<RunConfig>);
		if (action != null)
		{
			MapSelectionUi.A_RunConfigChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<RunConfig>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<RunConfig>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnRunConfigChanged(RunConfig runConfig)
	{
		if (currentStageData != runConfig.stageData)
		{
			MapData mapData = runConfig.mapData;
			Set(runConfig.mapData, runConfig.stageData, mapData.eMap);
		}
	}

	private void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E07]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Set(defaultMapVisuals, defaultStageVisuals, EMap.Forest);
		Invoke("StartDelayed", 0.25f);
	}

	private void StartDelayed()
	{
		Set(defaultMapVisuals, defaultStageVisuals, EMap.Forest);
	}

	public unsafe void Set(MapData mapData, StageData stageData, EMap map)
	{
		//IL_0127: Expected O, but got Ref
		//IL_027f: Expected O, but got I4
		//IL_02b0: Expected O, but got I4
		if (!(stageData != null))
		{
			return;
		}
		if (particles != null)
		{
			UnityEngine.Object.Destroy(particles);
		}
		terrain.materialTemplate = stageData.triplanarMaterial;
		stageData.ApplyFogAndSky(sunLight);
		RenderSettings.fogDensity = 0.007f;
		GameObject gameObject = stageData.SpawnParticles();
		particles = gameObject;
		if (particles != null)
		{
			Transform transform = particles.transform;
			Transform transform2 = camera.transform;
			Vector3 position = transform2.position;
			object obj = default(object);
			transform.position = (Vector3)(&obj);
			Transform transform3 = particles.transform;
			transform3.parent = camera;
		}
		if (stageData.grassMaterial != null && stageData.grassPerChunk > 0)
		{
			grassRenderer.Set(stageData.grassMaterial, stageData.grassPerChunk);
			GameObject gameObject2 = grassRenderer.gameObject;
			gameObject2.SetActive(value: true);
		}
		ambience.clip = mapData.ambience;
		if (mapData.eMap == EMap.Graveyard)
		{
			ambience.clip = dungeonAmbience;
		}
		ambience.loop = true;
		ambience.Play();
		currentStageData = stageData;
		object obj2 = map - 1;
		bool active = obj2 == null;
		forestBg.SetActive(active);
		object obj3 = map - 2;
		bool active2 = obj3 == null;
		desertBg.SetActive(active2);
		GameObject gameObject3;
		AudioSource audioSource;
		float volume;
		if (map == EMap.Forest)
		{
			RenderSettings.fogDensity = 0.007f;
			gameObject3 = dungeon;
		}
		else if (map == EMap.Desert)
		{
			RenderSettings.fogDensity = 0.0048f;
			gameObject3 = dungeon;
		}
		else
		{
			gameObject3 = dungeon;
			if (map == EMap.Graveyard)
			{
				dungeon.SetActive(value: true);
				general.SetActive(value: false);
				audioSource = ambience;
				volume = 0.45f;
				goto IL_03f1;
			}
		}
		gameObject3.SetActive(value: false);
		general.SetActive(value: true);
		audioSource = ambience;
		volume = 0.3f;
		goto IL_03f1;
		IL_03f1:
		audioSource.volume = volume;
	}
}
