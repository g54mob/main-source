using System.Collections.Generic;
using UnityEngine;

public class FrillsLoader : GenericGUIElementLoaderBase
{
	public GameObject top;

	public GameObject bot;

	public GameObject left;

	public GameObject right;

	private float easeDist = 5f;

	private float slideTime = 0.5f;

	private float bounceTime = 0.25f;

	private float bounceDist = 0.25f;

	private Inchworm.EaseStyle loadEaseStyle = Inchworm.EaseStyle.QuadraticOut;

	private int frillsLoaded;

	protected List<Segment> currentEases = new List<Segment>();

	protected override void AwakeBehavior()
	{
		top.SetActive(value: false);
		bot.SetActive(value: false);
		left.SetActive(value: false);
		right.SetActive(value: false);
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public override void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		frillsLoaded = 0;
		CancelCurrentEases();
		callback = loadCallback;
		top.SetActive(value: true);
		bot.SetActive(value: true);
		left.SetActive(value: true);
		right.SetActive(value: true);
		currentEases.Add(inchwormRef.RequestEase(top, new Vector3(0f, 0f - easeDist, 0f), slideTime, adjustStartingPos: true, loadEaseStyle, Inchworm.EaseType.Position, OnFrillLoadComplete));
		currentEases.Add(inchwormRef.RequestEase(bot, new Vector3(0f, easeDist, 0f), slideTime, adjustStartingPos: true, loadEaseStyle, Inchworm.EaseType.Position, OnFrillLoadComplete));
		currentEases.Add(inchwormRef.RequestEase(left, new Vector3(easeDist, 0f, 0f), slideTime, adjustStartingPos: true, loadEaseStyle, Inchworm.EaseType.Position, OnFrillLoadComplete));
		currentEases.Add(inchwormRef.RequestEase(right, new Vector3(0f - easeDist, 0f, 0f), slideTime, adjustStartingPos: true, loadEaseStyle, Inchworm.EaseType.Position, OnFrillLoadComplete));
	}

	public void Bounce()
	{
		CancelCurrentEases();
		currentEases.Add(inchwormRef.RequestEase(top, new Vector3(0f, 0f - bounceDist, 0f), bounceTime, adjustStartingPos: true, Inchworm.EaseStyle.Sin));
		currentEases.Add(inchwormRef.RequestEase(bot, new Vector3(0f, bounceDist, 0f), bounceTime, adjustStartingPos: true, Inchworm.EaseStyle.Sin));
		currentEases.Add(inchwormRef.RequestEase(left, new Vector3(bounceDist, 0f, 0f), bounceTime, adjustStartingPos: true, Inchworm.EaseStyle.Sin));
		currentEases.Add(inchwormRef.RequestEase(right, new Vector3(0f - bounceDist, 0f, 0f), bounceTime, adjustStartingPos: true, Inchworm.EaseStyle.Sin));
	}

	private void OnFrillLoadComplete()
	{
		frillsLoaded++;
		if (frillsLoaded >= 4)
		{
			OnSelfLoadComplete();
		}
	}

	protected override void OnSelfLoadComplete()
	{
		CancelCurrentEases();
		base.OnSelfLoadComplete();
	}

	private void CancelCurrentEases()
	{
		for (int num = currentEases.Count - 1; num >= 0; num--)
		{
			Segment segment = currentEases[num];
			inchwormRef.CancelAndFinishEase(ref segment);
			segment = null;
			currentEases.RemoveAt(num);
		}
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		CancelCurrentEases();
		frillsLoaded = 4;
		callback = unloadCallback;
		OnFrillUnloadComplete();
	}

	private void OnFrillUnloadComplete()
	{
		frillsLoaded--;
		if (frillsLoaded <= 0)
		{
			OnUnloadComplete();
		}
	}
}
