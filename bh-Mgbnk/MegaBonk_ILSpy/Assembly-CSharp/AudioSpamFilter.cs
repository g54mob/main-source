using System.Collections.Generic;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class AudioSpamFilter : MonoBehaviour
{
	private class SpamFilterContainer
	{
		public bool isMuted;

		public float unmuteTime;

		public float lastPlayedTime;
	}

	public AudioSource audioSource;

	public RandomSfx randomSfx;

	private static Dictionary<string, SpamFilterContainer> spamFilter;

	public float spamDelay = 0.06f;

	private string id;

	private bool isStringInit;

	public float minVolumeMultiplier = 0.5f;

	public float maxInterval = 0.4f;

	public float overrideMinInterval;

	public void OnEnable()
	{
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_018d: Invalid comparison between F4 and I4
		//IL_01cb: Expected F4, but got O
		if (!isStringInit)
		{
			isStringInit = true;
			GameObject gameObject = base.gameObject;
			string text = gameObject.name;
			id = text;
		}
		if (!spamFilter.ContainsKey(id))
		{
			SpamFilterContainer value = new SpamFilterContainer();
			((Dictionary<object, object>)(object)spamFilter).Add((object)id, (object)value);
		}
		SpamFilterContainer spamFilterContainer = spamFilter.get_Item(id);
		if (!(spamFilterContainer.unmuteTime > MyTime.time))
		{
			SpamFilterContainer spamFilterContainer2 = spamFilter.get_Item(id);
			SpamFilterContainer spamFilterContainer3 = spamFilter.get_Item(id);
			spamFilterContainer3.lastPlayedTime = MyTime.time;
			SpamFilterContainer spamFilterContainer4 = spamFilter.get_Item(id);
			float unmuteTime = MyTime.time + spamDelay;
			spamFilterContainer4.unmuteTime = unmuteTime;
			float interval = MyTime.time - spamFilterContainer2.lastPlayedTime;
			audioSource.enabled = true;
			object obj = this + 48;
			object obj2 = this + 76;
			if (!(overrideMinInterval > 0f))
			{
				obj2 = obj;
			}
			bool log = default(bool);
			float volumeMultiplier = FindVolumeMultiplier((float)obj2, maxInterval, interval, minVolumeMultiplier, log);
			randomSfx.Play(0f, volumeMultiplier);
		}
		else
		{
			audioSource.Stop();
			audioSource.enabled = false;
		}
	}

	public static float FindVolumeMultiplier(float minInterval, float maxInterval, float interval, float minVolumeMultiplierValue, bool log = false)
	{
		//IL_01db: Invalid comparison between I4 and F4
		//IL_01a3: Expected F4, but got I4
		object obj = default(object);
		float num = default(float);
		float num2 = default(float);
		float num3 = default(float);
		if (obj != null)
		{
			string text = num.ToString();
			string text2 = num2.ToString();
			string text3 = num3.ToString();
			string text4 = "minInterval: " + text + ", maxInterval: " + text2 + ", interval: " + text3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		if (!(num2 > num3))
		{
			return 1f;
		}
		bool flag = obj == null;
		float num4 = num3 - num;
		float num5 = num2 - num;
		float t = num4 / num5;
		if (!flag)
		{
			float num6 = default(float);
			string text5 = num6.ToString();
			string text6 = "lerpValue: " + text5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			t = num6;
		}
		float num7 = Easing.OutCirc(t);
		float num8;
		if (!(0f > num7))
		{
			bool flag2 = !(num7 > 1f);
			num8 = num7;
			if (!flag2)
			{
				num8 = 1f;
			}
		}
		else
		{
			num8 = 0f;
		}
		float num9 = 1f - minVolumeMultiplierValue;
		float num10 = num9 * num8;
		return num10 + minVolumeMultiplierValue;
	}

	private void OnValidate()
	{
		AudioSource component = GetComponent<AudioSource>();
		audioSource = component;
		RandomSfx component2 = GetComponent<RandomSfx>();
		randomSfx = component2;
	}

	static AudioSpamFilter()
	{
		Dictionary<string, SpamFilterContainer> dictionary = new Dictionary<string, SpamFilterContainer>();
		spamFilter = dictionary;
	}
}
