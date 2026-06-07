using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextLoc : MonoBehaviour
{
	public bool Colon;

	public bool Caps;

	public bool RobustFormat;

	public bool RobustLoc;

	[NonSerialized]
	private string Original;

	[NonSerialized]
	private bool localized;

	public UnityEvent OnLocalized;

	private void OnEnable()
	{
		if (!localized)
		{
			Original = GetComponent<Text>().text;
			LocalizeThis();
			localized = true;
			OnLocalized.Invoke();
			UnityEngine.Object.Destroy(this);
		}
	}

	public void LocalizeThis()
	{
		string text = (RobustLoc ? Original.Trim().LocColor() : (RobustFormat ? Utilities.RobustStringFormat(Original, false, false) : Original.Trim().Loc()));
		if (Caps)
		{
			text = text.ToUpper();
		}
		if (Colon)
		{
			text += ":";
		}
		GetComponent<Text>().text = text;
	}
}
