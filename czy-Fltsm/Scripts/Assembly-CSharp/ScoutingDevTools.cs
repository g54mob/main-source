using PajamaLlama.Flotsam.World;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoutingDevTools : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private AgentProfile _actorProfile;

	[SerializeField]
	private LandmarkBehaviourProviderReference _seagullLandmarks;

	[SerializeField]
	private LandmarkBehaviourProviderReference _landmarkToSpawn;

	[Header("Components")]
	[SerializeField]
	private Toggle _ruralToggle;

	[SerializeField]
	private Toggle _forestToggle;

	[SerializeField]
	private Toggle _cityToggle;

	[SerializeField]
	private TMP_InputField _desiredDistanceXField;

	[SerializeField]
	private TMP_InputField _minimumDistanceXField;

	public void ScoutCurrentRegion()
	{
		GameManager.WorldManager.CurrentRegion.Scout(null);
	}

	public void SpawnDrifter()
	{
		if ((bool)_actorProfile)
		{
			SpawnActor(_actorProfile.GetDescriptor());
		}
		else
		{
			SpawnActor(ActorDescriptor.CreateInstance(ActorType.Agent));
		}
	}

	public void SpawnSeagull()
	{
		SpawnLandmark(_seagullLandmarks);
	}

	public void SpawnLandmark()
	{
		SpawnLandmark(_landmarkToSpawn);
	}

	private void SpawnActor(ActorDescriptor actorDescriptor)
	{
		if (GetLandmarkPickerSettings().SpawnDrifter(out var landmarkSpawner, actorDescriptor))
		{
			landmarkSpawner.ClearFogOfWar();
			landmarkSpawner.SetBearingFeatures(BearingFeatures.Compass | BearingFeatures.Marker);
		}
	}

	private void SpawnLandmark(ILandmarkBehaviourProvider landmarkBehaviourProvider)
	{
		if (GetLandmarkPickerSettings().Spawn(out var landmarkSpawner, landmarkBehaviourProvider))
		{
			landmarkSpawner.ClearFogOfWar();
			landmarkSpawner.SetBearingFeatures(BearingFeatures.Compass | BearingFeatures.Marker);
		}
	}

	private ILandmarkPickerSettings GetLandmarkPickerSettings()
	{
		return LandmarkPicker.Settings.Get(float.Parse(_desiredDistanceXField.text), float.Parse(_minimumDistanceXField.text), ReturnRegionArray());
	}

	private WorldRegionType[] ReturnRegionArray()
	{
		using ListPool<WorldRegionType>.List list = ListPool<WorldRegionType>.List.Get();
		if (_ruralToggle.isOn)
		{
			list.Add(WorldRegionType.Rural);
		}
		if (_forestToggle.isOn)
		{
			list.Add(WorldRegionType.Forest);
		}
		if (_cityToggle.isOn)
		{
			list.Add(WorldRegionType.City);
		}
		return list.ToArray();
	}
}
