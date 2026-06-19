using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BuildingSelectorSymbol : MonoBehaviour
{
	public enum SelectorType
	{
		Extraction = 0,
		Connection = 1
	}

	public ParticleSystem ParticleSystem;

	public float FadeTime;

	public Tween Tween;

	public static List<GameObject> BuildingSelectorSymbols;

	public Material ExtractionMat;

	public Material ConnectionMat;

	private bool _isRemoving;

	public void Initiate(BuildingSelectorData data)
	{
	}

	public void Remove()
	{
	}

	private void OnDestroy()
	{
	}

	public static void WipeAll()
	{
	}

	public static Tween FadeStartColor(ParticleSystem ps, Color from, Color to, float duration)
	{
		return null;
	}
}
