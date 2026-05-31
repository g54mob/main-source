using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SwitchPages
{
	public string name;

	public RectTransform OnList;

	public RectTransform Content;

	[Header("Action")]
	public UnityEvent Action;
}
