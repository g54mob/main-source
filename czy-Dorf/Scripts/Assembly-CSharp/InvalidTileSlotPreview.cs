using DG.Tweening;
using UnityEngine;

public class InvalidTileSlotPreview : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer crossRenderer;

	[SerializeField]
	private MeshRenderer crossMeshRenderer;

	[SerializeField]
	private Material normalMaterial;

	[SerializeField]
	private Color invalidColor;

	private Sequence invalidHighlightTween;

	private float originalCrossScale;

	private void Awake()
	{
		originalCrossScale = (crossRenderer ? crossRenderer.transform.localScale.x : crossMeshRenderer.transform.localScale.x);
	}

	public void StartHighlighting()
	{
		if (!normalMaterial.HasProperty("_slotCol"))
		{
			Debug.Log($"material {normalMaterial} doesn't have property _slotCol");
		}
		Sequence sequence = invalidHighlightTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence);
		}
		invalidHighlightTween = DOTween.Sequence();
		if ((bool)crossRenderer)
		{
			TweenSettingsExtensions.Insert(invalidHighlightTween, 0f, TweenSettingsExtensions.OnComplete(TweenSettingsExtensions.From(ShortcutExtensions.DOColor(crossRenderer.material, normalMaterial.GetColor("_slotCol"), "_slotCol", 1f), invalidColor), delegate
			{
				crossRenderer.sharedMaterial = normalMaterial;
			}));
			TweenSettingsExtensions.Insert(invalidHighlightTween, 0f, TweenSettingsExtensions.From(ShortcutExtensions.DOScale(crossRenderer.transform, originalCrossScale, 1f), originalCrossScale * 1.3f));
		}
		else if ((bool)crossMeshRenderer)
		{
			TweenSettingsExtensions.Insert(invalidHighlightTween, 0f, TweenSettingsExtensions.OnComplete(TweenSettingsExtensions.From(ShortcutExtensions.DOColor(crossMeshRenderer.material, normalMaterial.GetColor("_slotCol"), "_slotCol", 1f), invalidColor), delegate
			{
				crossMeshRenderer.sharedMaterial = normalMaterial;
			}));
			TweenSettingsExtensions.Insert(invalidHighlightTween, 0f, TweenSettingsExtensions.From(ShortcutExtensions.DOScale(crossMeshRenderer.transform, originalCrossScale, 1f), originalCrossScale * 1.3f));
		}
	}

	public void StopHighlighting()
	{
		Sequence sequence = invalidHighlightTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence, complete: true);
		}
	}

	private void _003CStartHighlighting_003Eb__7_0()
	{
		crossRenderer.sharedMaterial = normalMaterial;
	}

	private void _003CStartHighlighting_003Eb__7_1()
	{
		crossMeshRenderer.sharedMaterial = normalMaterial;
	}
}
