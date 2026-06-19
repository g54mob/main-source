using UnityEngine;

public class LightUpHintIcon : MonoBehaviour
{
	public Animator animator;

	public float flashValue;

	public SpriteRenderer icon;

	private void Awake()
	{
		HideLightUpHint();
	}

	protected void LateUpdate()
	{
		icon.material.SetFloat("_FlashAmount", flashValue);
	}

	public void ShowLightUpHint()
	{
		animator.SetTrigger(-1345429757);
	}

	public void HideLightUpHint()
	{
		animator.SetTrigger(-601574123);
	}
}
