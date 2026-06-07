using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookTransition : MonoBehaviour
{
	public enum Type
	{
		Roll = 0,
		TurnR = 1,
		TurnL = 2,
		FadeIn = 3,
		Bleed = 4,
		Open = 5,
		Drop = 6,
		Lift = 7
	}

	public Type type;

	public RawImage underRawImage;

	public RectTransform modelHolderRt;

	public RectTransform backgroundToHide;

	[Space]
	public RawImage fadeOverRawImage;

	private AnimationState modelAnimationState;

	private List<Material> pageMaterials = new List<Material>();

	private Material dustMaterial;

	private Transform specialTransform;

	private const float kRollRadius = 60f;

	private float t_;

	public float t
	{
		get
		{
			return t_;
		}
		set
		{
			t_ = value;
			if (type == Type.Roll)
			{
				Rect rect = (base.transform as RectTransform).rect;
				float x = Util.LerpScale(t_, 0f, 1f, rect.width + 60f, 0f) + 160f;
				modelHolderRt.anchoredPosition = new Vector3(x, 0f);
				{
					foreach (Material pageMaterial in pageMaterials)
					{
						pageMaterial.mainTextureOffset = new Vector2(Mathf.Lerp(60f / rect.width, -1f, t_) / 1.25f, 0f);
					}
					return;
				}
			}
			if (type == Type.TurnL || type == Type.TurnR)
			{
				if (!(modelAnimationState == null))
				{
					if (type == Type.TurnR)
					{
						modelAnimationState.normalizedTime = Mathf.Lerp(0f, 29f, t_) / 70f;
					}
					if (type == Type.TurnL)
					{
						modelAnimationState.normalizedTime = Mathf.Lerp(40f, 69f, t_) / 70f;
					}
				}
			}
			else if (type == Type.FadeIn)
			{
				fadeOverRawImage.color = new Color(1f, 1f, 1f, t);
				fadeOverRawImage.transform.localRotation = Quaternion.Euler(90f * (1f - t_), 0f, 0f);
			}
			else if (type == Type.Bleed)
			{
				underRawImage.material.SetFloat("_BleedTime", 0.8f * t_);
			}
			else if (type == Type.Open)
			{
				if (!(modelAnimationState == null))
				{
					modelAnimationState.normalizedTime = Mathf.Lerp(20f, 60f, t_) / 60f;
				}
			}
			else if (type == Type.Drop)
			{
				if (!(modelAnimationState == null))
				{
					float num = Mathf.Lerp(1f, 10f, t_);
					float num2 = Util.LerpScale(num, 3f, 8f, 1f, 0f);
					float num3 = Util.LerpScale(num, 1f, 2f, 0f, 1f);
					modelAnimationState.normalizedTime = num / 60f;
					dustMaterial.SetColor("_Color", num2 * Color.white);
					specialTransform.localRotation = Quaternion.Euler(Mathf.Lerp(-70f, 0f, num3), 0f, 0f);
				}
			}
			else if (type == Type.Lift && !(modelAnimationState == null))
			{
				float num4 = Util.SmoothStepEdges(0f, 1f, t_);
				modelAnimationState.normalizedTime = 0f;
				specialTransform.localRotation = Quaternion.Euler(Mathf.Lerp(60f, 0f, num4), Mathf.Lerp(-10f, 0f, num4), 0f);
			}
		}
	}

	public void Begin(Texture a, Texture b, Vector2 shift)
	{
		if (pageMaterials.Count == 0)
		{
			Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer renderer in componentsInChildren)
			{
				Material[] materials = renderer.materials;
				foreach (Material material in materials)
				{
					if (material.mainTexture.name == "Temp")
					{
						pageMaterials.Add(material);
					}
					else if (material.name.Contains("dust"))
					{
						dustMaterial = material;
					}
				}
			}
			if (type == Type.Bleed)
			{
				underRawImage.material = new Material(underRawImage.material);
			}
		}
		if (type == Type.Roll)
		{
			modelHolderRt.anchoredPosition = shift;
			foreach (Material pageMaterial in pageMaterials)
			{
				pageMaterial.mainTexture = b;
				pageMaterial.SetTextureScale("_BackTex", 4f * new Vector2(1.7777779f, 1f));
			}
			underRawImage.texture = a;
		}
		else if (type == Type.TurnL || type == Type.TurnR)
		{
			modelHolderRt.anchoredPosition = shift;
			Vector2 vector = new Vector2(shift.x / 640f, shift.y / 360f);
			foreach (Material pageMaterial2 in pageMaterials)
			{
				pageMaterial2.mainTexture = a;
				pageMaterial2.mainTextureOffset = vector;
				pageMaterial2.SetTexture("_BackTex", b);
				pageMaterial2.SetTextureOffset("_BackTex", vector);
			}
			if (modelAnimationState == null)
			{
				Animation componentInChildren = GetComponentInChildren<Animation>(true);
				if (componentInChildren != null)
				{
					modelAnimationState = componentInChildren["All"];
				}
			}
			underRawImage.texture = b;
		}
		else if (type == Type.FadeIn)
		{
			underRawImage.texture = a;
			fadeOverRawImage.texture = b;
		}
		else if (type == Type.Bleed)
		{
			underRawImage.texture = a;
			underRawImage.material.SetTexture("_OverTex", b);
			underRawImage.material.SetVector("_Shift", shift);
		}
		else if (type == Type.Open)
		{
			foreach (Material pageMaterial3 in pageMaterials)
			{
				pageMaterial3.mainTexture = b;
			}
			if (modelAnimationState == null)
			{
				Animation componentInChildren2 = GetComponentInChildren<Animation>(true);
				if (componentInChildren2 != null)
				{
					modelAnimationState = componentInChildren2["All"];
				}
			}
		}
		else if ((type == Type.Drop || type == Type.Lift) && modelAnimationState == null)
		{
			Animation componentInChildren3 = GetComponentInChildren<Animation>(true);
			modelAnimationState = componentInChildren3["All"];
			specialTransform = componentInChildren3.transform.FindDescendant("swing_base");
		}
		base.gameObject.SetActive(true);
		if (backgroundToHide != null)
		{
			backgroundToHide.gameObject.SetActive(false);
		}
	}

	public void Finish()
	{
		base.gameObject.SetActive(false);
		foreach (Material pageMaterial in pageMaterials)
		{
			pageMaterial.mainTexture = Texture2D.whiteTexture;
			if (pageMaterial.HasProperty("_BackTex"))
			{
				Texture texture = pageMaterial.GetTexture("_BackTex");
				if (texture != null && texture is RenderTexture)
				{
					pageMaterial.SetTexture("_BackTex", Texture2D.whiteTexture);
				}
			}
		}
		if (underRawImage != null)
		{
			underRawImage.texture = Texture2D.whiteTexture;
		}
		if (fadeOverRawImage != null)
		{
			fadeOverRawImage.texture = Texture2D.whiteTexture;
		}
		if (backgroundToHide != null)
		{
			backgroundToHide.gameObject.SetActive(true);
		}
	}
}
