using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class PugTextEffectEnunciateSyllables : PugTextEffect
{
	public delegate void NewLineDuringSyllableDelegate(int currentLine);

	private struct GlyphPopup
	{
		public int glyphIndex;

		public float startTime;
	}

	public bool skipSoundEffectsForDynamicTexts;

	public bool useUnscaledTime = true;

	public bool resetEffectOnEnable = true;

	public float glyphDuration = 0.4f;

	public float initialDelay = 1.5f;

	public float backtickDelay = 0.2f;

	public float starDelay = 0.5f;

	public float interWordDelay = 0.2f;

	public float interCharDelay = 1f / 30f;

	public NewLineDuringSyllableDelegate newLineDuringSyllableDelegate;

	public bool sound;

	public List<SfxUnityInspectorFriendlyID> soundEffects;

	public float pitch = 1f;

	public float pitchDev = 0.2f;

	public float volume = 1f;

	public bool playSyllableOnWords;

	public int charsBetweenSyllables = 2;

	public AnimationCurve yCurve;

	public AnimationCurve alphaCurve;

	private float speedMult = 1f;

	private List<GlyphPopup> glyphPopupFIFO = new List<GlyphPopup>();

	private NestedCoroutineWrapper co_scheduleGlyphAppear;

	private int previousIndex = -1;

	public bool done { get; set; }

	private float time
	{
		get
		{
			if (!useUnscaledTime)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}
	}

	public event Action onSyllable;

	public void SetSpeedUp(bool enable)
	{
		speedMult = ((!enable) ? 1 : 3);
	}

	public override void ResetEffect(bool rewind)
	{
		Clear();
		if (!base.enabled)
		{
			ShowAllGlyphs(show: false);
		}
		else if (!(base.text == null) && !string.IsNullOrWhiteSpace(base.text.displayedTextString))
		{
			ShowAllGlyphs(show: false);
			co_scheduleGlyphAppear.Start(Co_ScheduleGlyphAppear());
		}
	}

	public void FinishEffect()
	{
		StopPlaying();
		ShowAllGlyphs(show: true);
	}

	public void StopPlaying()
	{
		co_scheduleGlyphAppear.Stop();
		glyphPopupFIFO.Clear();
		done = true;
	}

	protected override void Awake()
	{
		base.Awake();
		co_scheduleGlyphAppear = new NestedCoroutineWrapper(this, "Enunciate", addAutoStopComponent: true);
	}

	private void OnEnable()
	{
		if (resetEffectOnEnable)
		{
			ResetEffect(rewind: true);
		}
	}

	private void OnDisable()
	{
		Clear();
		ShowAllGlyphs(show: false);
	}

	public override void PugTextEffectLateUpdate()
	{
		if (base.text.isUsingDynamicText)
		{
			return;
		}
		int num = 0;
		foreach (GlyphPopup item in glyphPopupFIFO)
		{
			if (base.text.TryGetGlyph(item.glyphIndex, out var glyph))
			{
				float startTime = item.startTime;
				float num2 = (time - startTime) / (glyphDuration / speedMult);
				glyph.gameObject.SetActive(value: true);
				float a = 1f;
				float num3 = 0f;
				float num4 = 1f;
				if (num2 < 1f)
				{
					a = alphaCurve.Evaluate(num2);
					num3 = yCurve.Evaluate(num2);
					num4 = 1f + Math.Abs(num3);
				}
				else
				{
					num++;
				}
				Transform obj = glyph.transform;
				obj.Translate(0f, num3, 0f);
				obj.localScale = new Vector3(glyph.transform.localScale.x, glyph.transform.localScale.y * num4, glyph.transform.localScale.z);
				glyph.color = new Color(glyph.color.r, glyph.color.g, glyph.color.b, a);
			}
		}
		if (num > 0)
		{
			glyphPopupFIFO.RemoveRange(0, num);
		}
	}

	private void ShowAllGlyphs(bool show)
	{
		if (base.text == null)
		{
			return;
		}
		float a = alphaCurve.Evaluate(1f);
		foreach (SpriteRenderer glyph in base.text.glyphs)
		{
			glyph.gameObject.SetActive(show);
			glyph.SetAlpha(a);
		}
	}

	private void Clear()
	{
		glyphPopupFIFO.Clear();
		co_scheduleGlyphAppear?.Stop();
		done = true;
	}

	private void OnSyllable()
	{
		if (base.text.isUsingDynamicText && skipSoundEffectsForDynamicTexts)
		{
			return;
		}
		if (sound)
		{
			int num = UnityEngine.Random.Range(0, soundEffects.Count);
			while (previousIndex == num && soundEffects.Count > 1)
			{
				num = UnityEngine.Random.Range(0, soundEffects.Count);
			}
			SfxUnityInspectorFriendlyID sfxUIFID = soundEffects[num];
			previousIndex = num;
			AudioManager.SfxMono(Manager.audio.InspectorFriendlySfxIDToSfxID(sfxUIFID), pitch: pitch * (1f + speedMult / 4f), pitchDev: pitchDev, volume: volume);
		}
		this.onSyllable?.Invoke();
	}

	private IEnumerator Co_ScheduleGlyphAppear()
	{
		done = false;
		string displayText = base.text.displayedTextString;
		int currentLineNumber = 0;
		newLineDuringSyllableDelegate?.Invoke(currentLineNumber);
		currentLineNumber++;
		if (initialDelay > 0f)
		{
			yield return Yielders.Pause(initialDelay);
		}
		glyphPopupFIFO.EnsureCapacity(base.text.glyphs.Count);
		int syllableSoundCounter = 0;
		bool newWord = true;
		int glyphIdx = 0;
		for (int i = 0; i < displayText.Length; i++)
		{
			float num;
			switch (displayText[i])
			{
			case '\t':
			case '\n':
			case '\r':
			case ' ':
				syllableSoundCounter = 0;
				num = interWordDelay;
				newWord = true;
				break;
			case '`':
				syllableSoundCounter = 0;
				num = backtickDelay;
				break;
			case '*':
				syllableSoundCounter = 0;
				num = starDelay;
				break;
			default:
				if (displayText[i] != '.')
				{
					if ((playSyllableOnWords && newWord) || (!playSyllableOnWords && syllableSoundCounter % charsBetweenSyllables == 0))
					{
						OnSyllable();
						newWord = false;
					}
					syllableSoundCounter++;
				}
				else
				{
					syllableSoundCounter = 0;
				}
				glyphPopupFIFO.Add(new GlyphPopup
				{
					glyphIndex = glyphIdx,
					startTime = time
				});
				num = interCharDelay;
				glyphIdx++;
				break;
			}
			num /= speedMult;
			if (num > 0f)
			{
				if (useUnscaledTime)
				{
					yield return Yielders.PauseUnscaled(num);
				}
				else
				{
					yield return Yielders.Pause(num);
				}
			}
			if (displayText[i] == '\n')
			{
				newLineDuringSyllableDelegate?.Invoke(currentLineNumber);
				currentLineNumber++;
			}
		}
		done = true;
	}
}
