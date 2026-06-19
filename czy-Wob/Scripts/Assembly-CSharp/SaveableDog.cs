using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveableDog
{
	public SaveableDogGene dogGene;

	public ulong dogID;

	public string dogName;

	[NonSerialized]
	public Material bodyMainMat;

	[NonSerialized]
	public Texture bodyPatternTexture;

	public float bodyPatternAlpha;

	public float bodyPatternMetallic;

	public float bodyPatternSmoothness;

	public SerializableColor bodyPatternEmissionColor;

	public List<float> geneValueList;

	public SaveableDoggyBrain brain;

	public SaveableThumbSet thumbSet;

	public SaveableDogGut gut;

	public ulong? roomUID;

	public bool inWorld;

	public bool inCocoon;

	public float cocoonScale = 1f;

	public bool favorite;

	public DogLabelType labelType;

	public SaveablePoopController poop;

	public float currentEggTimer;

	public bool canStillLayEggs = true;

	public float currentCapsuleTimer;

	public SaveableDogProfile dogProfile;

	public SerializableVector3 bodyFrontPosition;

	public bool isGhost;

	public SaveableDog GetCopy()
	{
		SaveableDog saveableDog = new SaveableDog();
		if (dogGene != null)
		{
			saveableDog.dogGene = dogGene.GetCopy();
		}
		saveableDog.dogID = dogID;
		saveableDog.dogName = dogName;
		saveableDog.bodyPatternAlpha = bodyPatternAlpha;
		saveableDog.bodyPatternMetallic = bodyPatternMetallic;
		saveableDog.bodyPatternSmoothness = bodyPatternSmoothness;
		saveableDog.bodyPatternEmissionColor = bodyPatternEmissionColor.GetCopy();
		saveableDog.brain = brain.GetCopy();
		if (thumbSet != null)
		{
			saveableDog.thumbSet = thumbSet.GetCopy();
		}
		saveableDog.gut = gut.GetCopy();
		saveableDog.roomUID = roomUID;
		saveableDog.inWorld = inWorld;
		saveableDog.inCocoon = inCocoon;
		saveableDog.favorite = favorite;
		saveableDog.labelType = labelType;
		saveableDog.cocoonScale = cocoonScale;
		saveableDog.poop = poop.GetCopy();
		saveableDog.currentEggTimer = currentEggTimer;
		saveableDog.canStillLayEggs = canStillLayEggs;
		saveableDog.currentCapsuleTimer = currentCapsuleTimer;
		saveableDog.dogProfile = dogProfile.GetCopy();
		if (bodyFrontPosition != null)
		{
			saveableDog.bodyFrontPosition = bodyFrontPosition.GetCopy();
		}
		saveableDog.isGhost = isGhost;
		return saveableDog;
	}
}
