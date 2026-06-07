using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class TPCreditsScene : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _Background;

		[SerializeField]
		private SpriteRenderer _Castle;

		[SerializeField]
		private Transform _RingContainer;

		[SerializeField]
		private GameObject _DoilieSpritePrefab;

		[SerializeField]
		private Transform _DoilieOrigin;

		private List<string> _DoilieSprites;

		[FormerlySerializedAs("_Animation")]
		[SerializeField]
		private AnimationClip _AnimationLandscape;

		[SerializeField]
		private AnimationClip _AnimationPortrait;

		[SerializeField]
		private Animator _Animator;

		[SerializeField]
		private GameObject _AnimCamera;

		[SerializeField]
		private List<GameObject> _RingPrefabs;

		[SerializeField]
		private AnimationCurve _CameraRotationCurve;

		[SerializeField]
		private Transform _Space;

		[SerializeField]
		private VideoPlayer _Video;

		[SerializeField]
		private TextMeshProUGUI _DebugText;

		[SerializeField]
		private Transform _Rotator;

		[SerializeField]
		private TextAsset _TimeCodes;

		private AnimationClip _currentAnimationClip;

		private float _normalizedTime;

		private float _animLength;

		private Vector3 _cameraStartPos;

		private Vector3 _cameraEndPos;

		private float _ringDistanceInterval;

		private Vector3 _cameraDirection;

		private float _cameraVelocity;

		private SignalBus _signalBus;

		private MultiplayerManager _multiplayer;

		private PlayerOptions _playerOptions;

		private AchievementManager _achievementManager;

		private DataManager _data;

		private LobbiesManager _lobbiesManager;

		private TPCreditsPage _page;

		private bool isPlaying;

		private float _currentTime;

		private List<KeyValuePair<float, string>> _timeCodesFromAudio;

		private List<CharacterType> _charsToUnlock;

		private int _charIndex;

		public static string CreditsVideo_1080_60;

		public static string CreditsVideo_1080_30;

		public static string GetCreditsVideoForCurrentPlatform()
		{
			return null;
		}

		public static string GetExcludedCreditsVideo()
		{
			return null;
		}

		[Inject]
		private void Construct(SignalBus signal, MultiplayerManager _multi, PlayerOptions playerOptions, AchievementManager achievementManager, DataManager data, LobbiesManager lobbiesManager)
		{
		}

		public void Preload(AsyncLoader loader, string cacheGroupName)
		{
		}

		private void ParseText()
		{
		}

		private List<string> TextAssetToList(TextAsset ta)
		{
			return null;
		}

		private void PrepareVideo(VideoClip clip, Action onComplete)
		{
		}

		public void Initialize(TPCreditsPage page)
		{
		}

		public void GenerateFramesAndEvents()
		{
		}

		public void ActivateCamera()
		{
		}

		private void Update()
		{
		}

		public void SkipToTime(float skipTime)
		{
		}

		private void AddAnimationEvents(List<AnimationEvent> existingEvents)
		{
		}

		private void StopMusic()
		{
		}

		public AnimationEvent AddEvent(float time, string functionName)
		{
			return null;
		}

		private void SpawnMinorDoilie()
		{
		}

		private void UnlockNext()
		{
		}

		private void SpawnRings()
		{
		}

		private void AddCameraPositionKeyFrames()
		{
		}

		private void MathsStuff()
		{
		}

		private void AddCameraRotationKeyFrames()
		{
		}

		public void PlayVideo()
		{
		}

		public void SetPlaying(bool v, float startTime)
		{
		}

		public void ReturnToMenu()
		{
		}

		public void GoToCharacterSelectScreen()
		{
		}

		public void SelectDraculaAndRelease()
		{
		}

		private void RunManualAchievementChecks()
		{
		}

		public void SetAnimTime(float time)
		{
		}

		public void SpawnDoilie()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
