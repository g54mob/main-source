using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public static class RefiUtilities
{
	private static readonly Regex keywordRegex;

	public static Dictionary<string, string> keywordReplacements;

	private const string Alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";

	private const int BaseN = 32;

	private const int CodeLength = 6;

	private const int MaxSeed = 999999999;

	private static readonly long Capacity;

	private static readonly byte[] _secretKey;

	private const float PerpendicularPenalty = 1.6666666f;

	public static void AdjustSizeToSprite(Image image)
	{
	}

	public static bool IsMouseInsideWindow(float innerOffset = 0f)
	{
		return false;
	}

	public static Vector3 GetMouseBorderDirection(float innerOffset)
	{
		return default(Vector3);
	}

	public static string HighlightNumbers(string input)
	{
		return null;
	}

	private static string HighlightMatch(Match match)
	{
		return null;
	}

	public static string ToTitleCase(string input)
	{
		return null;
	}

	public static string FormatTooltip(string input)
	{
		return null;
	}

	public static string FormatNumber_From1k(long num, bool showComma = false)
	{
		return null;
	}

	public static string FormatNumber_From1m(long num, bool showComma = false)
	{
		return null;
	}

	public static string FormatNumber_From1b(long num, bool showComma = false)
	{
		return null;
	}

	public static void AccelerateParticleDisappearance(ParticleSystem particleSystem, float remainingTime_Min, float remainingTime_Max)
	{
	}

	public static void AddExtraMaterialToRenderer(Renderer renderer, Material extraMaterial)
	{
	}

	public static void RemoveExtraMaterialFromRenderer(Renderer renderer, string materialName)
	{
	}

	public static List<Vector3Int> GetAllGridPositionInCircleRange(Vector3 position, float range)
	{
		return null;
	}

	public static List<Vector3Int> GetAllGridPositionInSquareRange(Vector3 centerPos, int rangeX, int rangeZ)
	{
		return null;
	}

	public static string EncodeSeed(int seed)
	{
		return null;
	}

	public static int DecodeSeed(string code)
	{
		return 0;
	}

	public static int GameVersionToCode(string version)
	{
		return 0;
	}

	public static (int, int, int) GameCodeToVersion(int code)
	{
		return default((int, int, int));
	}

	private static byte[] BuildKey()
	{
		return null;
	}

	private static byte[] BuildBlob(List<int> list_Data)
	{
		return null;
	}

	private static byte[] ComputeHmac(byte[] message)
	{
		return null;
	}

	private static void SliceSignature(byte[] sig, out int a, out int b, out int c, out int d)
	{
		a = default(int);
		b = default(int);
		c = default(int);
		d = default(int);
	}

	public static Texture2D RenderTextureToTexture2D(RenderTexture rt)
	{
		return null;
	}

	public static byte[] Texture2DToJpgBytes(Texture2D src, int maxLongSide = 960, int jpgQuality = 85)
	{
		return null;
	}

	public static byte[] RenderTextureToJpgBytes(RenderTexture srcRT, int maxLongSide = 960, int jpgQuality = 85)
	{
		return null;
	}

	public static void RebuildNavigation(List<Selectable> selectables, RectTransform layoutTransform = null)
	{
	}

	private static Selectable FindBestCandidate(Selectable source, List<Selectable> targets, Vector2 direction)
	{
		return null;
	}

	public static void RebuildNavigationHorizontal(List<Selectable> selectables, RectTransform layoutTransform = null)
	{
	}

	public static void RebuildNavigationVertical(List<Selectable> selectables, RectTransform layoutTransform = null)
	{
	}

	public static T GetClosestItem<T>(Vector3 position, List<T> objects) where T : Component
	{
		return null;
	}

	public static Selectable SelectItemByInputAxisDirection(Vector3 selectPosition, List<Selectable> list_Candidates)
	{
		return null;
	}

	private static Selectable GetNodeByInputAxisDirection(Vector3 selectPosition, List<Selectable> list_Candidates)
	{
		return null;
	}

	public static void DrawVerticalDebugLine(Vector3 position, Color color, float length = 10f, float duration = 5f)
	{
	}
}
