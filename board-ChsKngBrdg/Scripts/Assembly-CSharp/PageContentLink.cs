using System.Collections;
using UnityEngine;

public class PageContentLink : MonoBehaviour
{
	private RuleBookScreenManager ruleBookScreenManager;

	private SoundManager soundManager;

	public SpriteRenderer linkSpriteRenderer;

	public RuleBookScreenData rulebookScreen;

	public RuleBookPage ruleBookPage;

	public ParticleSystem fogParticle;

	private bool isHovering;

	private bool isHighlighting;

	private Color originColor = Color.white;

	public AnimationCurve highlightCurve;

	public ObjectShake objectShake;

	private void Awake()
	{
		ruleBookScreenManager = Object.FindObjectOfType<RuleBookScreenManager>();
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	private void OnEnable()
	{
		if (ruleBookScreenManager.ruleBookFogManager.CheckIfPageIsFogged(ruleBookPage))
		{
			fogParticle.gameObject.SetActive(value: true);
			fogParticle.Play();
		}
		else
		{
			fogParticle.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (isHovering && !isHighlighting)
		{
			StartCoroutine(HoverHighlight());
		}
	}

	private void OnMouseDown()
	{
		ruleBookScreenManager.pageFlipInputBuffer.Clear();
		ruleBookScreenManager.FlipToSpecificPage(rulebookScreen);
		isHighlighting = false;
		linkSpriteRenderer.color = originColor;
	}

	private void OnMouseEnter()
	{
		StartHover();
	}

	private void OnMouseExit()
	{
		StopHover();
	}

	public void StartHover()
	{
		isHovering = true;
		ruleBookScreenManager.LeftFlipButton.enabled = false;
		ruleBookScreenManager.rightFlipButton.enabled = false;
		objectShake.StartCoroutine(objectShake.Shake(0.1f, 0.0125f));
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_rulebook_link_hover);
	}

	public void StopHover()
	{
		isHovering = false;
		ruleBookScreenManager.LeftFlipButton.enabled = true;
		ruleBookScreenManager.rightFlipButton.enabled = true;
	}

	public IEnumerator HoverHighlight()
	{
		isHighlighting = true;
		originColor = linkSpriteRenderer.color;
		float elapsedSeconds = 0f;
		while (elapsedSeconds < highlightCurve[highlightCurve.length - 1].time)
		{
			linkSpriteRenderer.color = new Color(linkSpriteRenderer.color.r, linkSpriteRenderer.color.g, linkSpriteRenderer.color.b, highlightCurve.Evaluate(elapsedSeconds));
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
		linkSpriteRenderer.color = originColor;
		isHighlighting = false;
	}
}
