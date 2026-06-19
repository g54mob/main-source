using System.Collections.Generic;
using ClockStone;
using I2.Loc;
using UnityEngine;

public class DogNoises : MonoBehaviour
{
	private string barkSound = "dog_bark";

	private string howlSound = "dog_howl";

	private string hurtSound = "dog_hurt";

	private string bumpSound = "dog_bump";

	private string biteSound = "dog_bite";

	private string gruntSound = "dog_grunt";

	private string growlSound = "dog_growl";

	private string sneezeSound = "dog_sneeze";

	private string snoringSound = "dog_snore";

	private string complainSound = "dog_complain";

	private string gruntDeepSound = "dog_grunt_deep";

	private string contentWhineSound = "dog_whine_content";

	private List<string> sharedVocalizationCategories = new List<string>();

	private float pitchMod;

	private float pitchModLowRange = 0.3f;

	private float pitchModHighRange = 0.3f;

	private int currentVoiceSetIndex = 1;

	private float perHeadDelayLow = 0.01f;

	private float perHeadDelayHigh = 0.0125f;

	private float loudDogMultiplier = 1.5f;

	private float quietDogMultiplier = 0.25f;

	private float[] clipData = new float[1024];

	private List<int> currentVocalizingHeads = new List<int>();

	private Dictionary<int, AudioObject> headIndexToVocalizationDict = new Dictionary<int, AudioObject>();

	private bool vocalizationAllowed = true;

	private bool isGhost;

	private float ghostReverbTimer = 1f;

	private float currentGhostReverbTimer;

	private float quietDogChanceMod = 0.5f;

	private LoudnessPersonalityType dogLoudness;

	private DogLooks looksRef;

	private FaceController faceRef;

	private void Awake()
	{
		sharedVocalizationCategories.Add(biteSound);
		sharedVocalizationCategories.Add(gruntSound);
		sharedVocalizationCategories.Add(sneezeSound);
		sharedVocalizationCategories.Add(gruntDeepSound);
	}

	private void Start()
	{
		looksRef = GetComponent<DogLooks>();
		faceRef = GetComponent<FaceController>();
		DoggyBrain component = GetComponent<DoggyBrain>();
		isGhost = component.IsGhost();
		dogLoudness = component.GetPersonality().GetLoudnessPersonalityType();
	}

	public void SetVocalizationAllowed(bool val)
	{
		vocalizationAllowed = val;
	}

	public void AssignVoiceSet()
	{
		MasterDogGene component = GetComponent<MasterDogGene>();
		bool domRecPropertyStatus = component.GetDomRecPropertyStatus(GeneticDomRecProperty.VOICE_HOARSE);
		bool flag = component.GetDomRecPropertyStatus(GeneticDomRecProperty.VOICE_PITCH_LOW);
		bool flag2 = component.GetDomRecPropertyStatus(GeneticDomRecProperty.VOICE_PITCH_HIGH);
		if (flag2 && flag)
		{
			flag = false;
			flag2 = false;
		}
		int index = (flag ? ((!domRecPropertyStatus) ? 1 : 5) : (flag2 ? ((!domRecPropertyStatus) ? 2 : 3) : (domRecPropertyStatus ? 4 : 0)));
		UpdateVoiceSetIndex(index);
	}

	public void UpdateVoiceSetIndex(int index)
	{
		currentVoiceSetIndex = index;
	}

	public int GetCurrentVoiceSetIndex()
	{
		return currentVoiceSetIndex;
	}

	public string GetCurrentVoiceSetName()
	{
		switch (currentVoiceSetIndex)
		{
		case 0:
			return ScriptLocalization.Genetics.DOMREC_PROP_STANDARD;
		case 1:
			return ScriptLocalization.Genetics.DOMREC_VOICE_LOW;
		case 2:
			return ScriptLocalization.Genetics.DOMREC_VOICE_HIGH;
		case 3:
			return ScriptLocalization.Genetics.DOMREC_VOICE_HIGH + ", " + ScriptLocalization.Genetics.DOMREC_VOICE_HOARSE;
		case 4:
			return ScriptLocalization.Genetics.DOMREC_VOICE_HOARSE;
		case 5:
			return ScriptLocalization.Genetics.DOMREC_VOICE_LOW + ", " + ScriptLocalization.Genetics.DOMREC_VOICE_HOARSE;
		default:
			return ScriptLocalization.Genetics.DOMREC_PROP_STANDARD;
		}
	}

	private void Update()
	{
		for (int num = currentVocalizingHeads.Count - 1; num >= 0; num--)
		{
			if (headIndexToVocalizationDict[currentVocalizingHeads[num]] == null)
			{
				headIndexToVocalizationDict.Remove(currentVocalizingHeads[num]);
				currentVocalizingHeads.RemoveAt(num);
			}
			else if (!UpdateVocalization(currentVocalizingHeads[num]))
			{
				headIndexToVocalizationDict.Remove(currentVocalizingHeads[num]);
				currentVocalizingHeads.RemoveAt(num);
			}
		}
	}

	private bool UpdateVocalization(int headIndex)
	{
		DogVocalizer dogVocalizer = null;
		AudioObject audioObject = headIndexToVocalizationDict[headIndex];
		if (audioObject != null)
		{
			dogVocalizer = faceRef.GetDogHeadForIndex(headIndex).vocalizationEffect;
		}
		if (audioObject != null && audioObject.IsPlaying())
		{
			MatchSoundToVisualEffect(headIndex);
			return true;
		}
		if (audioObject != null && isGhost && currentGhostReverbTimer > 0f)
		{
			currentGhostReverbTimer -= Time.deltaTime;
			dogVocalizer.UpdateEffect(0f, 0f);
			return true;
		}
		if (audioObject != null)
		{
			AudioHighPassFilter component = audioObject.GetComponent<AudioHighPassFilter>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
		dogVocalizer.UpdateEffect(0f, 0f);
		return false;
	}

	public void OnDie()
	{
		if (!(faceRef == null))
		{
			for (int i = 0; i < faceRef.GetNumberOfDogHeads(); i++)
			{
				faceRef.GetDogHeadForIndex(i).vocalizationEffect.Lock();
			}
		}
	}

	public string GetHowlID()
	{
		return howlSound;
	}

	public void StopCurrentVocalization()
	{
		for (int i = 0; i < currentVocalizingHeads.Count; i++)
		{
			AudioController.Stop(headIndexToVocalizationDict[currentVocalizingHeads[i]].audioID, 0.1f);
		}
		currentVocalizingHeads.Clear();
		headIndexToVocalizationDict.Clear();
	}

	public bool IsAnyVocalizationPlaying()
	{
		for (int i = 0; i < currentVocalizingHeads.Count; i++)
		{
			if (headIndexToVocalizationDict[currentVocalizingHeads[i]] != null)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsVocalizationPlaying(string soundID)
	{
		for (int i = 0; i < currentVocalizingHeads.Count; i++)
		{
			if (headIndexToVocalizationDict[currentVocalizingHeads[i]].audioID == soundID)
			{
				return true;
			}
		}
		return false;
	}

	public void OnDogHurt()
	{
		if (dogLoudness != LoudnessPersonalityType.QUIET || !(Random.value <= quietDogChanceMod))
		{
			RequestVocalization(hurtSound);
		}
	}

	public void OnDogBumped()
	{
		if (dogLoudness != LoudnessPersonalityType.QUIET || !(Random.value <= quietDogChanceMod))
		{
			RequestVocalization(bumpSound);
		}
	}

	public void RequestHowl()
	{
		RequestVocalization(howlSound);
	}

	public float GetHowlTimer()
	{
		float num = 0f;
		if (isGhost)
		{
			num = ghostReverbTimer;
		}
		return AudioController.GetAudioItem(GetUsableSFXName(howlSound)).subItems[0].Clip.length + num;
	}

	public void RequestBark()
	{
		RequestVocalization(barkSound);
	}

	public void RequestContentWhine()
	{
		if (dogLoudness != LoudnessPersonalityType.QUIET || !(Random.value <= quietDogChanceMod))
		{
			RequestVocalization(contentWhineSound);
		}
	}

	public void RequestBite()
	{
		RequestVocalization(biteSound);
	}

	public void RequestSneeze()
	{
		RequestVocalization(sneezeSound);
	}

	public void RequestSnore()
	{
		RequestVocalization(snoringSound);
	}

	public void RequestComplain()
	{
		if (dogLoudness != LoudnessPersonalityType.QUIET || !(Random.value <= quietDogChanceMod))
		{
			faceRef.RequestFace(Face.WINCE, 0.75f);
			RequestVocalization(complainSound);
		}
	}

	public void RequestGrunt(bool deep = false)
	{
		if (dogLoudness != LoudnessPersonalityType.QUIET || !(Random.value <= quietDogChanceMod))
		{
			if (deep)
			{
				RequestVocalization(gruntDeepSound);
			}
			else
			{
				RequestVocalization(gruntSound);
			}
		}
	}

	public void RequestGrowl(bool updateFace = true)
	{
		if (updateFace)
		{
			faceRef.RequestFace(Face.ANGRY, 0.75f);
		}
		RequestVocalization(growlSound);
	}

	private string GetUsableSFXName(string sfx)
	{
		string text = sfx;
		if (!sharedVocalizationCategories.Contains(sfx))
		{
			int num = currentVoiceSetIndex + 1;
			text = text + "_" + num;
		}
		return text;
	}

	private void RequestVocalization(string sfx)
	{
		if (IsAnyVocalizationPlaying() || !vocalizationAllowed)
		{
			return;
		}
		sfx = GetUsableSFXName(sfx);
		currentVocalizingHeads.Clear();
		headIndexToVocalizationDict.Clear();
		float num = 1f;
		if (dogLoudness == LoudnessPersonalityType.LOUD)
		{
			num *= loudDogMultiplier;
		}
		else if (dogLoudness == LoudnessPersonalityType.QUIET)
		{
			num *= quietDogMultiplier;
		}
		for (int i = 0; i < faceRef.GetNumberOfDogHeads(); i++)
		{
			if (isGhost && i > 0 && num > 0.5f)
			{
				num = 0.5f;
			}
			float delay = Random.Range(perHeadDelayLow, perHeadDelayHigh) * (float)i;
			AudioObject audioObject = AudioController.Play(sfx, faceRef.GetDogHeadForIndex(i).mouthTransform, num, delay);
			if (!(audioObject == null))
			{
				currentVocalizingHeads.Add(i);
				headIndexToVocalizationDict[i] = audioObject;
				AudioReverbFilter component = audioObject.gameObject.GetComponent<AudioReverbFilter>();
				if (component != null)
				{
					component.enabled = isGhost;
				}
				AudioChorusFilter component2 = audioObject.gameObject.GetComponent<AudioChorusFilter>();
				if (component2 != null)
				{
					component2.enabled = isGhost;
				}
				if (isGhost)
				{
					currentGhostReverbTimer = ghostReverbTimer;
				}
				audioObject.pitch += pitchMod;
				audioObject.pitch = Mathf.Clamp(audioObject.pitch, 1f - pitchModLowRange, 1f + pitchModHighRange);
				MatchSoundToVisualEffect(i);
			}
		}
	}

	public void GenerateSoundPalette()
	{
		float minDogScale = looksRef.GetMinDogScale();
		float maxDogScale = looksRef.GetMaxDogScale();
		float defaultDogScale = looksRef.GetDefaultDogScale();
		float num = Mathf.Clamp(base.transform.localScale.x, minDogScale, maxDogScale);
		if (num == defaultDogScale)
		{
			pitchMod = 0f;
		}
		else if (num < defaultDogScale)
		{
			float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(defaultDogScale - MathUtil.GetPercentageOfRange(num, looksRef.GetMinDogScale(), defaultDogScale), 0f, pitchModHighRange);
			pitchMod = valueOfRangePercentage;
		}
		else if (num > defaultDogScale)
		{
			float valueOfRangePercentage2 = MathUtil.GetValueOfRangePercentage(MathUtil.GetPercentageOfRange(num, defaultDogScale, looksRef.GetMaxDogScale()), 0f, pitchModLowRange);
			pitchMod = 0f - valueOfRangePercentage2;
		}
	}

	private void MatchSoundToVisualEffect(int headIndex)
	{
		AudioObject audioObject = headIndexToVocalizationDict[headIndex];
		if (audioObject == null || !audioObject.IsPlaying() || audioObject.subItem == null)
		{
			return;
		}
		if (audioObject != null)
		{
			DogVocalizer vocalizationEffect = faceRef.GetDogHeadForIndex(headIndex).vocalizationEffect;
			audioObject.primaryAudioSource.clip.GetData(clipData, audioObject.primaryAudioSource.timeSamples);
			float num = 0f;
			for (int i = 0; i < clipData.Length; i++)
			{
				num += Mathf.Abs(clipData[i]);
			}
			num /= (float)clipData.Length;
			vocalizationEffect.UpdateEffect(num, audioObject.audioTime / audioObject.clipLength);
		}
		else
		{
			Debug.LogError("No vocalizationEffect found for headIndex " + headIndex + " for dog: " + base.gameObject);
		}
	}
}
