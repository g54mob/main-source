using JetBrains.Annotations;
using UnityEngine;
using UnityStandardAssets.Water;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class MetagameMapScene : MonoBehaviour
	{
		[SerializeField]
		private GameObject _rootObject;

		[SerializeField]
		private Light _sceneLight;

		[SerializeField]
		private Light[] _sceneLights;

		[SerializeField]
		private GoboProjector _projector;

		[SerializeField]
		private MetagameCutsceneAudioPlayer _cutsceneAudioPlayer;

		[SerializeField]
		private MetagameEventBehaviour _cutsceneEventBehaviour;

		[SerializeField]
		private MapPin[] _mapPins;

		[SerializeField]
		private MapVisualsActivation[] _mapVisuals;

		[SerializeField]
		private Water _water;

		[SerializeField]
		private Transform _defaultCollaborativeModeCameraTransform;

		[SerializeField]
		private MetagameCutsceneLocation _collaborativeIntroCutsceneLocation;

		public GameObject RootObject => _rootObject;

		public Light SceneLight => _sceneLight;

		public Light[] SceneLights => _sceneLights;

		public GoboProjector Projector => _projector;

		public MetagameCutsceneAudioPlayer CutsceneAudioPlayer => _cutsceneAudioPlayer;

		public MetagameEventBehaviour CutsceneEventBehaviour => _cutsceneEventBehaviour;

		public MapPin[] MapPins => _mapPins;

		public MapVisualsActivation[] MapVisuals => _mapVisuals;

		public Water Water => _water;

		public Transform DefaultCollaborativeModeCameraTransform => _defaultCollaborativeModeCameraTransform;

		public MetagameCutsceneLocation CollaborativeIntroCutsceneLocation => _collaborativeIntroCutsceneLocation;
	}
}
