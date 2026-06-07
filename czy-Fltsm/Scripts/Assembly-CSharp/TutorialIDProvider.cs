using System.Collections.Generic;
using UnityEngine;

public class TutorialIDProvider : MonoBehaviour
{
	[SerializeField]
	private TutorialID _tutorialId;

	private static List<TutorialIDProvider> _enabledProviders = new List<TutorialIDProvider>();

	public static TutorialID TutorialID
	{
		get
		{
			if (_enabledProviders.IsNullOrEmpty())
			{
				return TutorialID.None;
			}
			return _enabledProviders[_enabledProviders.Count - 1]._tutorialId;
		}
	}

	private void OnEnable()
	{
		_enabledProviders.Add(this);
	}

	private void OnDisable()
	{
		_enabledProviders.Remove(this);
	}
}
