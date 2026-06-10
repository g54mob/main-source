using System;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

[Serializable]
public class Telephone
{
	[Header("Serialized Components")]
	public int number;

	public string numberString;

	public List<TelephoneController.PhoneCall> activeCall;

	[NonSerialized]
	[Header("Non-Serialized Components")]
	public bool setup;

	[NonSerialized]
	public NewGameLocation location;

	[NonSerialized]
	public Interactable interactable;

	[NonSerialized]
	public SpeechController speechController;

	[NonSerialized]
	public Human activeReceiver;

	[NonSerialized]
	public AudioController.LoopingSoundInfo dialTone;

	[NonSerialized]
	public EventInstance engaged;

	[NonSerialized]
	public EvidenceLocation locationEntry;

	[NonSerialized]
	public EvidenceTelephone telephoneEntry;

	public Telephone(Interactable newTelephone)
	{
	}

	public Telephone(Interactable newTelephone, int newNumber)
	{
	}

	public void LoadTelephoneNumber()
	{
	}

	public void GenerateTelephoneNumber()
	{
	}

	public List<int> GetInputCode()
	{
		return null;
	}

	public void CreateEvidence()
	{
	}

	public void StopActiveCall()
	{
	}

	public void SetActiveCall(TelephoneController.PhoneCall newCall)
	{
	}

	public void SetTelephoneAnswered(Human val)
	{
	}
}
