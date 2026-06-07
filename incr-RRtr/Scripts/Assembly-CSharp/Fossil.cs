using DG.Tweening;
using UnityEngine;

public class Fossil : MonoBehaviour
{
	private CropSlot currentSlot;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[Header("Crossover")]
	[SerializeField]
	private Color giovannaBlue;

	public void SpawnOnRandomCrop(out CropSlot randomCropSlot)
	{
		randomCropSlot = GameManager.ins.getRandomCropSlot();
		if (randomCropSlot != null)
		{
			randomCropSlot.RemoveCropNoSound();
			randomCropSlot.state = CropSlot.State.Fossil;
			currentSlot = randomCropSlot;
			base.transform.position = randomCropSlot.transform.position;
			base.gameObject.SetActive(value: true);
		}
	}

	public void Despawn()
	{
		ResetColor();
		if ((bool)currentSlot)
		{
			currentSlot.state = CropSlot.State.Empty;
		}
		base.gameObject.SetActive(value: false);
	}

	public void PlayBlueColor()
	{
		spriteRenderer.DOKill();
		spriteRenderer.DOColor(giovannaBlue, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
	}

	private void ResetColor()
	{
		spriteRenderer.DOKill();
		spriteRenderer.color = Color.white;
	}
}
