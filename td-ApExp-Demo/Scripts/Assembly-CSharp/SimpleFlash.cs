using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlash : MonoBehaviour
{
	[Tooltip("Material to switch to during the flash.")]
	[SerializeField]
	private Material flashMaterial;

	private float flashDuration = 0.1f;

	private float outlineStaticDuration = 0.125f;

	private Color critColor = ColorUtils.HexToColor("ce1919");

	private Color invulnerabilityColor = ColorUtils.HexToColor("12d7ff");

	private Color damageReductionColor = ColorUtils.HexToColor("12d7ff");

	[SerializeField]
	private List<SpriteRenderer> spriteRenderers;

	private Material[] originalMaterials;

	private Coroutine flashRoutine;

	private bool isFlashing;

	private Color previousOutlineColor;

	private Unit unit;

	private void Awake()
	{
		if (spriteRenderers == null)
		{
			spriteRenderers = new List<SpriteRenderer> { GetComponent<SpriteRenderer>() };
		}
		originalMaterials = new Material[spriteRenderers.Count];
		for (int i = 0; i < spriteRenderers.Count; i++)
		{
			originalMaterials[i] = spriteRenderers[i].material;
		}
		unit = base.gameObject.gameObject.GetComponent<Unit>();
	}

	public void AddSr(SpriteRenderer sr)
	{
		spriteRenderers.Add(sr);
		originalMaterials = new Material[spriteRenderers.Count];
		for (int i = 0; i < spriteRenderers.Count; i++)
		{
			originalMaterials[i] = spriteRenderers[i].material;
		}
	}

	public void Flash(FlashTypes type = FlashTypes.Regular)
	{
		if (flashRoutine != null)
		{
			StopCoroutine(flashRoutine);
		}
		if (FlashRoutine(type) != null)
		{
			flashRoutine = StartCoroutine(FlashRoutine(type));
		}
	}

	private IEnumerator FlashRoutine(FlashTypes type = FlashTypes.Regular)
	{
		if (base.gameObject.TryGetComponent<Outline>(out var component))
		{
			previousOutlineColor = component.currentColor;
		}
		switch (type)
		{
		case FlashTypes.Regular:
			foreach (SpriteRenderer spriteRenderer in spriteRenderers)
			{
				if ((bool)spriteRenderer && (bool)spriteRenderer.gameObject)
				{
					spriteRenderer.material = flashMaterial;
				}
			}
			isFlashing = true;
			break;
		case FlashTypes.Crit:
			if ((bool)component && !unit.IsHacked)
			{
				component.SetOutline(isActive: true, critColor);
			}
			isFlashing = false;
			break;
		case FlashTypes.ReducedDamage:
			foreach (SpriteRenderer spriteRenderer2 in spriteRenderers)
			{
				if ((bool)spriteRenderer2 && (bool)spriteRenderer2.gameObject)
				{
					spriteRenderer2.material = flashMaterial;
				}
			}
			isFlashing = true;
			break;
		case FlashTypes.Invulnerability:
			if ((bool)component && !unit.IsHacked)
			{
				component.SetOutline(isActive: true, invulnerabilityColor);
			}
			isFlashing = false;
			break;
		default:
			foreach (SpriteRenderer spriteRenderer3 in spriteRenderers)
			{
				if ((bool)spriteRenderer3 && (bool)spriteRenderer3.gameObject)
				{
					spriteRenderer3.material = flashMaterial;
				}
			}
			isFlashing = true;
			break;
		}
		if (isFlashing)
		{
			yield return new WaitForSeconds(flashDuration);
			for (int i = 0; i < spriteRenderers.Count; i++)
			{
				if ((bool)spriteRenderers[i] && (bool)spriteRenderers[i].gameObject)
				{
					spriteRenderers[i].material = originalMaterials[i];
				}
			}
			if (unit != null && !unit.IsHacked && base.gameObject.TryGetComponent<Outline>(out var component2))
			{
				component2.SetOutline(isActive: false, previousOutlineColor);
			}
		}
		else
		{
			yield return new WaitForSeconds(outlineStaticDuration);
			if (base.gameObject.TryGetComponent<Outline>(out var component3) && unit != null && !unit.IsHacked)
			{
				component3.SetOutline(isActive: false, previousOutlineColor);
			}
			for (int j = 0; j < spriteRenderers.Count; j++)
			{
				if ((bool)spriteRenderers[j] && (bool)spriteRenderers[j].gameObject)
				{
					spriteRenderers[j].material = originalMaterials[j];
				}
			}
		}
		flashRoutine = null;
	}
}
