using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CycleTimeUI_centerController : MonoBehaviour
{
	public enum ECenterState
	{
		Sun = 0,
		Moon = 1
	}

	[SerializeField]
	private RawImage sunMoonImage;

	[SerializeField]
	private Texture sunSprite;

	[SerializeField]
	private Texture moonSprite;

	[SerializeField]
	private float transitionDuration = 1f;

	[SerializeField]
	private ECenterState startState;

	private void Awake()
	{
	}

	public void SetCenterState(ECenterState state, bool doTransition = true)
	{
		Texture value = null;
		Material material = sunMoonImage.material;
		switch (state)
		{
		case ECenterState.Sun:
			value = sunSprite;
			break;
		case ECenterState.Moon:
			value = moonSprite;
			break;
		}
		material.SetTexture("_PrimaryTex", material.GetTexture("_SecondaryTex"));
		material.SetTexture("_SecondaryTex", value);
		material.SetFloat("_Transition", 0f);
		if (doTransition)
		{
			material.DOFloat(1f, "_Transition", transitionDuration).SetEase(Ease.InExpo);
		}
		else
		{
			material.SetFloat("_Transition", 1f);
		}
	}
}
