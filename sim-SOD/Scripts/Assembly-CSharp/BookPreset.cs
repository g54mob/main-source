using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "book_data", menuName = "Database/Book")]
public class BookPreset : SoCustomComparison
{
	public enum BookGenre
	{
		crime = 0,
		history = 1,
		esoteric = 2,
		romance = 3,
		medical = 4,
		science = 5,
		architecture = 6,
		sciFi = 7,
		memoir = 8,
		propaganda = 9,
		politics = 10,
		beauty = 11,
		food = 12,
		nature = 13,
		poetry = 14
	}

	public enum BookSeries
	{
		none = 0,
		detectiveGill = 1,
		talesOfTheHeart = 2,
		candorHistory = 3,
		customSeries1 = 4,
		customSeries2 = 5,
		customSeries3 = 6,
		customSeries4 = 7,
		customSeries5 = 8,
		customSeries6 = 9,
		customSeries7 = 10,
		customSeries8 = 11,
		customSeries9 = 12,
		customSeries10 = 13
	}

	public enum SpawnRules
	{
		onlyAtHome = 0,
		onlyAtWork = 1,
		homeOrWork = 2,
		secret = 3
	}

	[ReadOnly]
	public string bookName;

	[Header("Settings")]
	public string author;

	[ReorderableList]
	public List<BookGenre> genre;

	[Tooltip("Is this part of a series?")]
	public bool isSeries;

	[EnableIf("isSeries")]
	public BookSeries seriesTag;

	[EnableIf("isSeries")]
	public int seriesNumber;

	[Range(0f, 1f)]
	[Tooltip("How common this book is")]
	[Header("Ownership rules")]
	public float common;

	[Tooltip("How likely anyone is to own this...")]
	[Range(0f, 1f)]
	public float baseChance;

	[ReorderableList]
	public List<CharacterTrait.TraitPickRule> pickRules;

	[Tooltip("Rules for spawning this (when not on shelf).")]
	public SpawnRules spawnRule;

	[Header("Visuals")]
	public Mesh bookMesh;

	public Material bookMaterial;

	[Tooltip("Where the text is located in the DDS editor")]
	[Header("Text")]
	public string ddsMessage;
}
