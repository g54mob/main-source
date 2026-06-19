using System.Collections;
using System.Globalization;
using Aggro.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[ExecuteInEditMode]
public class TipTapVideoContainer : EntityBehaviourBase
{
	private static readonly int VOLSFX_ID = AggroSettings.IdToHash("audio-sfx");

	private static readonly int VOLGAME_ID = AggroSettings.IdToHash("audio-game");

	public LocalizedText usernameLoc;

	public LocalizedText descriptionLoc;

	public TextMeshProUGUI likeCountTextMeshProUGUI;

	public RawImage screenRawImage;

	public RenderTexture screenRenderTexture;

	public Texture2D exampleTexture;

	public VideoPlayer videoPlayer;

	public Transform likeButton;

	public Image likeButtonImage;

	public Color likeButtonUnlikedColor;

	public Color likeButtonLikedColor;

	public Transform shareButton;

	public Image shareButtonImage;

	public Color shareButtonUnsharedColor;

	public Color shareButtonSharedColor;

	public float buttonAnimTime = 0.5f;

	public EasingFunction.Ease buttonEaseIn;

	public EasingFunction.Ease buttonEaseOut;

	public float buttonAnimStrength = 0.2f;

	private IEnumerator ButtonPressCo(Transform buttonPressed, Image image, Color originalColor, Color newColor, bool keepColor)
	{
		float time = 0f;
		while (time < buttonAnimTime)
		{
			float num = time / buttonAnimTime;
			if ((double)num < 0.5)
			{
				float num2 = EasingFunction.Evaluate(buttonEaseIn, num * 2f);
				buttonPressed.localScale = Vector3.one + Vector3.one * (buttonAnimStrength * num2);
				image.color = Color.Lerp(originalColor, newColor, num * 2f);
			}
			else
			{
				float num3 = EasingFunction.Evaluate(buttonEaseOut, 1f - (num * 2f - 1f));
				buttonPressed.localScale = Vector3.one + Vector3.one * (buttonAnimStrength * num3);
				if (!keepColor)
				{
					image.color = Color.Lerp(newColor, originalColor, num * 2f - 1f);
				}
			}
			time += Time.deltaTime;
			yield return null;
		}
	}

	public void PlayLikeAnim()
	{
		StartCoroutine(ButtonPressCo(likeButton, likeButtonImage, likeButtonUnlikedColor, likeButtonLikedColor, keepColor: true));
		likeButtonImage.color = likeButtonLikedColor;
	}

	public void PlayShareAnim()
	{
		StartCoroutine(ButtonPressCo(shareButton, shareButtonImage, shareButtonUnsharedColor, shareButtonSharedColor, keepColor: false));
	}

	public void SetUpAndPlay(TipTapObject tipTapObject)
	{
		likeButtonImage.color = (SaveManager.data.IsTipTapLiked(tipTapObject) ? likeButtonLikedColor : likeButtonUnlikedColor);
		shareButtonImage.color = shareButtonUnsharedColor;
		float num = AggroSettings.GetFloat(VOLGAME_ID);
		float num2 = AggroSettings.GetFloat(VOLSFX_ID);
		videoPlayer.SetDirectAudioVolume(0, num2 * num * (tipTapObject.volume / 100f));
		videoPlayer.clip = tipTapObject.videoClips[tipTapObject.activeIndex];
		usernameLoc.SetIndex(tipTapObject.username);
		descriptionLoc.SetIndex(tipTapObject.description);
		likeCountTextMeshProUGUI.text = GetLikeCountString(tipTapObject.likeCount);
		videoPlayer.Play();
		SaveManager.data.TipTapSeen(tipTapObject);
	}

	public void Stop()
	{
		videoPlayer.Stop();
	}

	public string GetLikeCountString(int likeCount)
	{
		float num = likeCount;
		if (num > 999f)
		{
			num /= 1000f;
			return Mathf.Floor(num * 10f) / 10f + "K";
		}
		if (num > 999999f)
		{
			num /= 1000000f;
			return Mathf.Floor(num * 10f) / 10f + "M";
		}
		return num.ToString(CultureInfo.CurrentCulture);
	}
}
