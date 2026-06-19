using System;
using UnityEngine;

public class TableItem : MonoBehaviour
{
	public SpriteRenderer itemSR;

	public SpriteRenderer itemOverlaySR;

	public SpriteRenderer itemUnderlaySR;

	[HideInInspector]
	public SpriteSheetSkin spriteSheetSkin;

	public ColorReplacer colorReplacer;

	[NonSerialized]
	public bool hasObjectLight;

	public ManagedLight objectLight;

	public GameObject legendaryBeam;

	[NonSerialized]
	public ConditionID currentGlowCondition;

	[NonSerialized]
	public ObjectID currentItemIDShowing;

	public bool dontChangeSprite;

	private void Awake()
	{
		hasObjectLight = objectLight != null;
	}
}
