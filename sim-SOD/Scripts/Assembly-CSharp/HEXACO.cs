using System;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class HEXACO
{
	public int outputMin;

	public int outputMax;

	[Space(7f)]
	public bool enableFeminineMasculine;

	[Range(0f, 10f)]
	public int feminineMasculine;

	[InfoBox("Honesty-Humility (H): sincere, honest, faithful, loyal, modest/unassuming versus sly, deceitful, greedy, pretentious, hypocritical, boastful, pompous", EInfoBoxType.Normal)]
	[Space(7f)]
	public bool enableHumility;

	[Range(0f, 10f)]
	public int humility;

	[InfoBox("Emotionality (E): emotional, oversensitive, sentimental, fearful, anxious, vulnerable versus brave, tough, independent, self-assured, stable", EInfoBoxType.Normal)]
	[Space(7f)]
	public bool enableEmotionality;

	[Range(0f, 10f)]
	public int emotionality;

	[Space(7f)]
	[InfoBox("Extraversion (X): outgoing, lively, extraverted, sociable, talkative, cheerful, active versus shy, passive, withdrawn, introverted, quiet, reserved", EInfoBoxType.Normal)]
	public bool enableExtraversion;

	[Range(0f, 10f)]
	public int extraversion;

	[Space(7f)]
	[InfoBox("Agreeableness (A): patient, tolerant, peaceful, mild, agreeable, lenient, gentle versus ill-tempered, quarrelsome, stubborn, choleric", EInfoBoxType.Normal)]
	public bool enableAgreeableness;

	[Range(0f, 10f)]
	public int agreeableness;

	[Space(7f)]
	[InfoBox("Conscientiousness (C): organized, disciplined, diligent, careful, thorough, precise versus sloppy, negligent, reckless, lazy, irresponsible, absent-minded", EInfoBoxType.Normal)]
	public bool enableConscientiousness;

	[Range(0f, 10f)]
	public int conscientiousness;

	[Space(7f)]
	[InfoBox("Openness to Experience (O): intellectual, creative, unconventional, innovative, ironic versus shallow, unimaginative, conventional", EInfoBoxType.Normal)]
	public bool enableCreativity;

	[Range(0f, 10f)]
	public int creativity;
}
