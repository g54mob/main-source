using System.Collections;
using UnityEngine;

public class Signal : MonoBehaviour
{
	public enum OverrideState
	{
		Automatic = 0,
		Green = 1,
		Red = 2
	}

	public RailTrack[] tracks;

	public Indicator greenLight;

	public Indicator redLight;

	public OverrideState manualOverride;

	private bool isInBlock;

	private void Start()
	{
	}

	private IEnumerator Tick()
	{
		yield return new WaitForSeconds(Random.Range(0f, 1f));
		while (true)
		{
			yield return WaitFor.Seconds(1f);
			Check();
		}
	}

	private void Update()
	{
		Check();
		UpdateLights();
	}

	private void Check()
	{
		if (manualOverride != OverrideState.Automatic)
		{
			isInBlock = manualOverride == OverrideState.Red;
		}
		else
		{
			if (tracks.Length == 0)
			{
				return;
			}
			for (int i = 0; i < tracks.Length; i++)
			{
				if (tracks[i].BogiesOnTrack().Count > 0)
				{
					isInBlock = tracks[i].BogiesOnTrack().Count > 0;
					return;
				}
			}
			isInBlock = false;
		}
	}

	private void UpdateLights()
	{
		if (isInBlock)
		{
			greenLight.Value = 0f;
			redLight.Value = 1f;
		}
		else
		{
			greenLight.Value = 1f;
			redLight.Value = 0f;
		}
	}
}
