using DarkTonic.MasterAudio;
using UnityEngine;

public class TransformFollower : MonoBehaviour
{
	[Tooltip("This is for diagnostic purposes only. Do not change or assign this field.")]
	public Transform RuntimeFollowingTransform;

	private GameObject _goToFollow;

	private Transform _trans;

	private GameObject _go;

	private string _soundType;

	private string _variationName;

	private bool _willFollowSource;

	private bool _isInsideTrigger;

	private bool _hasPlayedSound;

	private float _playVolume;

	private bool _positionAtClosestColliderPoint;

	private MasterAudio.AmbientSoundExitMode _exitMode;

	private float _exitFadeTime;

	private MasterAudio.AmbientSoundReEnterMode _reEnterMode;

	private float _reEnterFadeTime;

	private Vector3 _lastListenerPos;

	private PlaySoundResult playingVariation;

	private PlaySoundResult fadingVariation;

	public GameObject GameObj => null;

	public Transform Trans => null;

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	public void UpdateAudioVariation(SoundGroupVariation newVariation)
	{
	}

	public void StartFollowing(Transform transToFollow, string soundType, string variationName, float volume, float trigRadius, bool willFollowSource, bool positionAtClosestColliderPoint, bool useTopCollider, bool useChildColliders, MasterAudio.AmbientSoundExitMode exitMode, float exitFadeTime, MasterAudio.AmbientSoundReEnterMode reEnterMode, float reEnterFadeTime)
	{
	}

	private void StopFollowing()
	{
	}

	private void PlaySound()
	{
	}

	public void ManualUpdate()
	{
	}

	public bool RecalcClosestColliderPosition(bool forceRecalc = false)
	{
		return false;
	}

	private void PerformTriggerExit()
	{
	}
}
