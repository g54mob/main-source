using System;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapUnit : MonoBehaviour
{
	public RawImage image;

	[NonSerialized]
	public UnitManager unit;

	private float t;

	private float blinkInterval;

	private bool _colorOn;

	private bool _blink;

	private Color _color;

	[NonSerialized]
	public int metaData;

	[NonSerialized]
	public int timeToEvent;

	private bool colorOn
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool blink
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public void Update()
	{
	}

	public void SetPosition(int cellX, int cellZ)
	{
	}

	public void SetImage(Texture2D tex)
	{
	}
}
