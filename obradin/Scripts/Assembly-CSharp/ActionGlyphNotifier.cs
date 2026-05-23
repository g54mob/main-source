using System.Collections.Generic;
using UnityEngine;

public class ActionGlyphNotifier : MonoBehaviour
{
	private class Val
	{
		public float startTime = -100f;

		public int drivingAxisId;

		public bool blockedUntilRelease;

		public int charge;

		public bool inFlashTime
		{
			get
			{
				return Clock.menu.time < startTime + 0.75f;
			}
		}
	}

	public List<ActionGlyph> glyphs = new List<ActionGlyph>();

	public const float kSlowPeriod = 1f;

	public const float kFastPeriod = 0.25f;

	public const float kCount = 3f;

	private float preventFlashUntil;

	private Dictionary<int, Val> startTimes = new Dictionary<int, Val>();

	public bool globalHide { get; set; }

	public void Flash(int actionId, int drivingAxisId = -1)
	{
		Val val = GetVal(actionId, true);
		if (!(Clock.menu.time < preventFlashUntil) && !globalHide && !val.blockedUntilRelease && !val.inFlashTime)
		{
			val.charge = 0;
			val.startTime = Clock.menu.time;
			val.drivingAxisId = drivingAxisId;
			val.blockedUntilRelease = drivingAxisId >= 0;
		}
	}

	public void Charge(int actionId, int drivingAxisId)
	{
		Val val = GetVal(actionId, true);
		val.charge++;
		if (val.charge > 3)
		{
			val.charge = 0;
			Flash(actionId, drivingAxisId);
		}
	}

	public void AbortAll(float duration = 0f)
	{
		preventFlashUntil = Mathf.Max(preventFlashUntil, Clock.menu.time + duration);
		foreach (KeyValuePair<int, Val> startTime in startTimes)
		{
			startTime.Value.startTime = -100f;
			startTime.Value.charge = 0;
			startTime.Value.blockedUntilRelease = false;
		}
		foreach (ActionGlyph glyph in glyphs)
		{
			glyph.AbortNotify();
		}
	}

	public float GetStartTime(int actionId)
	{
		Val val = GetVal(actionId);
		return (val == null) ? (-100f) : val.startTime;
	}

	public bool IsActive(int actionId)
	{
		Val val = GetVal(actionId);
		if (val != null)
		{
			return !globalHide && val.inFlashTime;
		}
		return false;
	}

	private Val GetVal(int actionId, bool addIfMissing = false)
	{
		Val value = null;
		if (!startTimes.TryGetValue(actionId, out value) && addIfMissing)
		{
			value = new Val();
			startTimes.Add(actionId, value);
		}
		return value;
	}

	private void Update()
	{
		foreach (KeyValuePair<int, Val> startTime in startTimes)
		{
			if (startTime.Value.blockedUntilRelease && !RInput.GetAxisAsButton(startTime.Value.drivingAxisId))
			{
				startTime.Value.blockedUntilRelease = false;
			}
		}
	}
}
