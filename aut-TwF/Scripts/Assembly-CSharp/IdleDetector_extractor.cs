using UnityEngine;

[RequireComponent(typeof(Extractor))]
public class IdleDetector_extractor : IdleDetector
{
	private Extractor extractor;

	private void Awake()
	{
		extractor = GetComponent<Extractor>();
	}

	protected override void Start()
	{
		base.Start();
		extractor.onCurrentSourceChanged += OnExtractorSourceChanged;
	}

	private void OnExtractorSourceChanged(Source source)
	{
		if (!base.IsIdle && extractor.PlacementComponent.IsPlaced && !source)
		{
			InvokeOnStartIdle();
		}
		else if (base.IsIdle && (!extractor.PlacementComponent.IsPlaced || (bool)source))
		{
			InvokeOnStopIdle();
		}
	}
}
