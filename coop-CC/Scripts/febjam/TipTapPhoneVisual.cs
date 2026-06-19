using System;
using System.Collections;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class TipTapPhoneVisual : AggroManagerBase<TipTapPhoneVisual>
{
	[Serializable]
	public class TapTapVideoClip
	{
		public VideoClip videoClip;

		[Range(0f, 100f)]
		public float volume = 20f;

		public string captionText = "yooo haha wow yipee!! #silly";
	}

	private Unity.Mathematics.Random _random;

	public Animator handAnimator;

	public MeshRenderer phoneRenderer;

	private static readonly int Active = Animator.StringToHash("active");

	private static readonly int Share = Animator.StringToHash("share");

	private static readonly int Like = Animator.StringToHash("like");

	private static readonly int Up = Animator.StringToHash("swipeUp");

	private static readonly int Down = Animator.StringToHash("swipeDown");

	private PlayerStress _playerStress;

	public Renderer handRenderer;

	public Volume postVolume;

	public float postVolumeAdaptSpeed = 1f;

	private VehicleController _vehicleController;

	public Transform gForceTransform;

	public float gForceAffect = 20f;

	public float gForceAffectMax = 5f;

	public float gForceAffectSpeed = 1f;

	public bool tiptapOpen;

	public bool swiping;

	private int _positionInFeed;

	public TipTapVideoContainer[] tipTapVideoContainers;

	public int currentVideoContainerIndex;

	public int tipTapPageHeight = 1024;

	public float swipeTime = 1f;

	public float failedSwipeTime = 1f;

	public AnimationCurve swipeCurve;

	public AnimationCurve swipeDownFailedCurve;

	public TextMeshProUGUI timeText;

	public GameObject[] batteryLevelObjects;

	public EventReference swipeSFX;

	public EventReference swipeFailSFX;

	public EventReference shareSFX;

	public EventReference likeSFX;

	public void OpenTipTap()
	{
		tiptapOpen = true;
		handAnimator.SetBool(Active, value: true);
		NetworkAggroManagerBase<TipTapManager>.instance.RefreshLiveFeed();
		_positionInFeed = 0;
		tipTapVideoContainers[currentVideoContainerIndex].SetUpAndPlay(NetworkAggroManagerBase<TipTapManager>.instance.liveTipTaps[0]);
		Aggro.Core.Platform.UnlockAchievement("ach_tiptap_first");
	}

	public void CloseTipTap()
	{
		if (tiptapOpen)
		{
			tiptapOpen = false;
			handAnimator.SetBool(Active, value: false);
			TipTapVideoContainer[] array = tipTapVideoContainers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Stop();
			}
		}
	}

	private IEnumerator SwipeCo(int direction = 1)
	{
		_positionInFeed += direction;
		swiping = true;
		TipTapVideoContainer tipTapVideoContainer = tipTapVideoContainers[currentVideoContainerIndex];
		TipTapVideoContainer tipTapVideoContainer2 = tipTapVideoContainers[(currentVideoContainerIndex + 1) % 2];
		if (_positionInFeed >= NetworkAggroManagerBase<TipTapManager>.instance.liveTipTaps.Count)
		{
			NetworkAggroManagerBase<TipTapManager>.instance.RefreshLiveFeed();
			_positionInFeed = 0;
		}
		tipTapVideoContainer.videoPlayer.Stop();
		tipTapVideoContainer2.SetUpAndPlay(NetworkAggroManagerBase<TipTapManager>.instance.liveTipTaps[_positionInFeed]);
		Transform currentTransform = tipTapVideoContainer.transform;
		Transform otherTransform = tipTapVideoContainer2.transform;
		float y = 0f;
		float y2 = tipTapPageHeight * -direction;
		currentTransform.localPosition = new Vector3(currentTransform.localPosition.x, y, currentTransform.localPosition.z);
		otherTransform.localPosition = new Vector3(otherTransform.localPosition.x, y2, otherTransform.localPosition.z);
		float time = 0f;
		while (time < swipeTime)
		{
			float time2 = time / swipeTime;
			float num = (float)(tipTapPageHeight * direction) * swipeCurve.Evaluate(time2);
			currentTransform.localPosition = new Vector3(currentTransform.localPosition.x, num, currentTransform.localPosition.z);
			otherTransform.localPosition = new Vector3(otherTransform.localPosition.x, num + (float)(tipTapPageHeight * -direction), otherTransform.localPosition.z);
			time += Time.deltaTime;
			yield return null;
		}
		currentTransform.localPosition = new Vector3(currentTransform.localPosition.x, tipTapPageHeight * direction, currentTransform.localPosition.z);
		otherTransform.localPosition = new Vector3(otherTransform.localPosition.x, 0f, otherTransform.localPosition.z);
		currentVideoContainerIndex++;
		currentVideoContainerIndex %= 2;
		swiping = false;
	}

	private IEnumerator SwipeDownFailedCo()
	{
		swiping = true;
		TipTapVideoContainer tipTapVideoContainer = tipTapVideoContainers[currentVideoContainerIndex];
		TipTapVideoContainer tipTapVideoContainer2 = tipTapVideoContainers[(currentVideoContainerIndex + 1) % 2];
		Transform currentTransform = tipTapVideoContainer.transform;
		Transform otherTransform = tipTapVideoContainer2.transform;
		float time = 0f;
		while (time < failedSwipeTime)
		{
			float time2 = time / failedSwipeTime;
			float num = (float)tipTapPageHeight * swipeDownFailedCurve.Evaluate(time2);
			currentTransform.localPosition = new Vector3(currentTransform.localPosition.x, 0f - num, currentTransform.localPosition.z);
			otherTransform.localPosition = new Vector3(otherTransform.localPosition.x, tipTapPageHeight, otherTransform.localPosition.z);
			time += Time.deltaTime;
			yield return null;
		}
		currentTransform.localPosition = new Vector3(currentTransform.localPosition.x, 0f, currentTransform.localPosition.z);
		otherTransform.localPosition = new Vector3(otherTransform.localPosition.x, tipTapPageHeight, otherTransform.localPosition.z);
		swiping = false;
	}

	public void SwipeUp()
	{
		StopAllCoroutines();
		StartCoroutine(SwipeCo());
		AudioManager.PlaySfx(swipeSFX);
	}

	public void SwipeDown()
	{
		StopAllCoroutines();
		if (_positionInFeed <= 0)
		{
			StartCoroutine(SwipeDownFailedCo());
			AudioManager.PlaySfx(swipeFailSFX);
		}
		else
		{
			StartCoroutine(SwipeCo(-1));
			AudioManager.PlaySfx(swipeSFX);
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			return;
		}
		player.GetObject<PlayerAnimation>().tiptapActive = tiptapOpen;
		if (tiptapOpen)
		{
			timeText.text = DateTime.Now.ToString("h:mm tt");
		}
		int currentShift = NetworkAggroManagerBase<ShiftManager>.instance.GetCurrentShift();
		for (int i = 0; i < batteryLevelObjects.Length; i++)
		{
			batteryLevelObjects[i].SetActive(i < 5 - currentShift + 1);
		}
		if (tiptapOpen)
		{
			NetworkAggroManagerBase<TipTapManager>.instance.AddToTipTapSeconds(Time.deltaTime);
			if (AggroInputManager.input.Game.SwipeUpTipTap.WasPressedThisFrame() && !swiping)
			{
				handAnimator.SetTrigger(Up);
				SwipeUp();
			}
			if (AggroInputManager.input.Game.SwipeLeftTipTap.WasPressedThisFrame() && !swiping)
			{
				handAnimator.SetTrigger(Share);
				tipTapVideoContainers[currentVideoContainerIndex].PlayShareAnim();
				NetworkAggroManagerBase<TipTapManager>.instance.RequestShareTipTap(NetworkAggroManagerBase<TipTapManager>.instance.liveTipTaps[_positionInFeed]);
				AudioManager.PlaySfx(shareSFX);
			}
			if (AggroInputManager.input.Game.SwipeRightTipTap.WasPressedThisFrame() && !swiping)
			{
				tipTapVideoContainers[currentVideoContainerIndex].PlayLikeAnim();
				NetworkAggroManagerBase<TipTapManager>.instance.Like(NetworkAggroManagerBase<TipTapManager>.instance.liveTipTaps[_positionInFeed]);
				handAnimator.SetTrigger(Like);
				AudioManager.PlaySfx(likeSFX);
			}
		}
		if (tiptapOpen)
		{
			if (AggroInputManager.input.Game.SwipeDownTipTap.WasPerformedThisFrame())
			{
				CloseTipTap();
			}
		}
		else if (AggroInputManager.input.Game.SwipeUpTipTap.WasPerformedThisFrame())
		{
			OpenTipTap();
		}
		postVolume.weight = Mathf.Clamp01(Mathf.Lerp(postVolume.weight, tiptapOpen ? 1 : (-1), Time.deltaTime * postVolumeAdaptSpeed));
		PlayerColorManager playerColorManager = player.GetObject<PlayerColorManager>();
		phoneRenderer.SetPropertyBlockColor(MaterialUtil.MAIN_COLOR_ID, playerColorManager.GetPlayerColor(ui: true));
		handRenderer.material.SetColor(MaterialUtil.MAIN_COLOR_ID, playerColorManager.GetPlayerColor(ui: true));
		RuntimeManager.StudioSystem.setParameterByName("taptap", tiptapOpen ? 1 : 0);
		_vehicleController = player.GetObject<VehicleController>();
		Vector3 vector = _vehicleController.gForce * gForceAffect;
		Vector3 vector2 = new Vector3(0f - vector.x, 0f - vector.z, 0f);
		vector2 = (tiptapOpen ? Vector3.ClampMagnitude(vector2, gForceAffectMax) : Vector3.zero);
		gForceTransform.localPosition = Vector3.Lerp(gForceTransform.localPosition, vector2, gForceAffectSpeed * Time.deltaTime);
	}
}
