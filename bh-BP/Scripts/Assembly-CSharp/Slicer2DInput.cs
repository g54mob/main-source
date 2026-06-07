using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Slicer2DInput
{
	public delegate void InputCompleted();

	public bool visualsEnabled;

	public bool slicingEnabled;

	public bool released;

	public bool pressed;

	public bool holding;

	public bool clicked;

	public Vector2 position;

	public bool playing;

	public bool loop;

	public bool rawInput;

	public List<Slicer2DInputEvent> eventsPlaying;

	public List<Slicer2DInputEvent> eventsBank;

	public Slicer2DInputEvent currentEvent;

	public TimerHelper timer;

	public event InputCompleted controllerEvents
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void EventsCompleted()
	{
	}
}
