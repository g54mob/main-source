using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BuildingLandingPadModelSwitcher : MonoBehaviour
{
	[SerializeField]
	private List<Transform> _noCraneTransforms = new List<Transform>();

	[SerializeField]
	private List<Transform> _withCraneTransforms = new List<Transform>();

	[Button(null, EButtonEnableMode.Always)]
	public void SwitchToNoCrane()
	{
		foreach (Transform noCraneTransform in _noCraneTransforms)
		{
			noCraneTransform.gameObject.SetActive(value: true);
		}
		foreach (Transform withCraneTransform in _withCraneTransforms)
		{
			withCraneTransform.gameObject.SetActive(value: false);
		}
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SwitchToWithCrane()
	{
		foreach (Transform noCraneTransform in _noCraneTransforms)
		{
			noCraneTransform.gameObject.SetActive(value: false);
		}
		foreach (Transform withCraneTransform in _withCraneTransforms)
		{
			withCraneTransform.gameObject.SetActive(value: true);
		}
	}
}
