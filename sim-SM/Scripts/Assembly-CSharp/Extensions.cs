using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public static class Extensions
{
	public delegate void ResetDelegate();

	private static readonly Regex AngleBracketRegex;

	private static System.Random random;

	public static string RandomString(this string str, int length)
	{
		return null;
	}

	public static string ToMoneyText(this float money, float fontSize, float decimalSizeRate = 0.6f)
	{
		return null;
	}

	public static void SetCollisions(this GameObject gameObject, bool willOpen)
	{
	}

	public static float TryParseToFloat(this string text)
	{
		return 0f;
	}

	public static string Raw(this string text)
	{
		return null;
	}

	public static string ToSprite(this string text)
	{
		return null;
	}

	public static string ToSprite(this int index)
	{
		return null;
	}

	public static CanvasGroup OpenAnimation(this CanvasGroup canvasGroup, float fadeIn, float fadeOut, float lifetime, ResetDelegate resetFunction, bool realTime = false)
	{
		return null;
	}

	public static List<T> AddUnique<T>(this List<T> list, T obj)
	{
		return null;
	}

	public static List<T> SafeRemove<T>(this List<T> list, T obj)
	{
		return null;
	}

	public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
	{
	}

	public static void AddRange(this IList list, IEnumerable items)
	{
	}

	public static LocalizationEntry LocalizationEntry(this DisplayType displayType)
	{
		return null;
	}

	public static LocalizationEntry LocalizationEntry(this CustomerSpeechType speechType)
	{
		return null;
	}

	public static LocalizationEntry LocalizationEntry(this InteractionWarningType warningType)
	{
		return null;
	}

	public static LocalizationEntry LocalizationEntry(this PlayerPaymentType paymentType)
	{
		return null;
	}

	public static bool HasHoldingInteraction(this InteractionType interactionType)
	{
		return false;
	}

	public static bool HasInstantInteraction(this InteractionType interactionType)
	{
		return false;
	}

	public static bool HasCustomInteraction(this InteractionType interactionType)
	{
		return false;
	}
}
