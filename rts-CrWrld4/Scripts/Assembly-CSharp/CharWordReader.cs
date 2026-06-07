using System.IO;
using UnityEngine;

public class CharWordReader
{
	public char[] word;

	public int wordSize;

	public bool endReached;

	private StreamReader reader;

	private int bufferSize;

	private char[] buffer;

	public char currentChar;

	private int currentPosition;

	private int maxPosition;

	public CharWordReader(StreamReader reader, int bufferSize)
	{
	}

	public void SkipWhitespaces()
	{
	}

	public void SkipWhitespaces(out bool newLinePassed)
	{
		newLinePassed = default(bool);
	}

	public void SkipUntilNewLine()
	{
	}

	public void ReadUntilWhiteSpace()
	{
	}

	public void ReadUntilNewLine()
	{
	}

	public bool Is(string other)
	{
		return false;
	}

	public string GetString(int startIndex = 0)
	{
		return null;
	}

	public Vector3 ReadVector()
	{
		return default(Vector3);
	}

	public int ReadInt()
	{
		return 0;
	}

	public float ReadFloat()
	{
		return 0f;
	}

	private float ReadFloatEnd()
	{
		return 0f;
	}

	private void SkipNewLineSymbols()
	{
	}

	public void MoveNext()
	{
	}
}
