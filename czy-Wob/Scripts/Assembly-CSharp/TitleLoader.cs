using System.Collections.Generic;
using UnityEngine;

public class TitleLoader : GenericGUIElementLoaderBase
{
	public float elementDelay = 0.1f;

	private float bounceTime = 0.75f;

	private float bounceScaleMultMin = 0.5f;

	private float bounceScaleMultMax = 1.5f;

	private int lettersLoaded;

	protected List<Segment> currentEases = new List<Segment>();

	private List<GameObject> childObjects = new List<GameObject>();

	private void Awake()
	{
		AwakeBehavior();
	}

	protected override void AwakeBehavior()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			childObjects.Add(child.gameObject);
			child.localScale = Vector3.zero;
		}
	}

	public override void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		lettersLoaded = 0;
		CancelCurrentEases();
		callback = loadCallback;
		float num = 0f;
		for (int i = 0; i < childObjects.Count; i++)
		{
			currentEases.Add(inchwormRef.RequestEaseToScale(childObjects[i], Vector3.one, scaleInTime, Inchworm.EaseStyle.ElasticOut, OnLetterLoadComplete, Inchworm.EasePriority.Normal, num));
			num += elementDelay;
		}
	}

	private void OnLetterLoadComplete()
	{
		lettersLoaded++;
		if (lettersLoaded >= childObjects.Count)
		{
			OnSelfLoadComplete();
		}
	}

	public void Bounce()
	{
		CancelCurrentEases();
		for (int i = 0; i < childObjects.Count; i++)
		{
			childObjects[i].transform.localScale *= Random.Range(bounceScaleMultMin, bounceScaleMultMax);
			currentEases.Add(inchwormRef.RequestEaseToScale(childObjects[i], Vector3.one, bounceTime, Inchworm.EaseStyle.ElasticOut));
		}
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
		lettersLoaded = childObjects.Count;
		callback = unloadCallback;
		float num = 0f;
		for (int num2 = childObjects.Count - 1; num2 >= 0; num2--)
		{
			currentEases.Add(inchwormRef.RequestEaseToScale(childObjects[num2], Vector3.zero, scaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnLetterUnloadComplete, Inchworm.EasePriority.Normal, num));
			num += elementDelay;
		}
	}

	private void OnLetterUnloadComplete()
	{
		lettersLoaded--;
		if (lettersLoaded <= 0)
		{
			OnUnloadComplete();
		}
	}
}
