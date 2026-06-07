using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CoredumpingGenerator
{
	public static byte[,] LogoData = new byte[8, 82]
	{
		{
			0, 1, 1, 1, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0
		},
		{
			1, 1, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 1, 0, 0, 0, 1, 1, 1, 1,
			0, 0, 1, 1, 1, 1, 1, 0, 0, 1,
			1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 0, 1, 1, 1, 1,
			1, 1, 1, 1, 0, 0, 0, 1, 1, 1,
			1, 1, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 1, 0, 0, 0, 1, 1, 1, 1,
			1, 0
		},
		{
			1, 1, 0, 0, 0, 0, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 0,
			0, 1, 1, 0, 0, 0, 1, 1, 0, 1,
			1, 0, 0, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 1,
			1, 0, 0, 1, 1, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 0,
			1, 1
		},
		{
			1, 1, 0, 0, 0, 0, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 0,
			0, 1, 1, 1, 1, 1, 1, 1, 0, 1,
			1, 0, 0, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 1,
			1, 0, 0, 1, 1, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 0,
			1, 1
		},
		{
			1, 1, 0, 0, 0, 0, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 0,
			0, 1, 1, 0, 0, 0, 0, 0, 0, 1,
			1, 0, 0, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 1,
			1, 0, 0, 1, 1, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 1, 1, 0, 0, 0,
			1, 1
		},
		{
			0, 1, 1, 1, 1, 1, 0, 0, 1, 1,
			1, 1, 1, 0, 0, 1, 1, 0, 0, 0,
			0, 0, 1, 1, 1, 1, 1, 0, 0, 1,
			1, 1, 1, 1, 1, 1, 0, 0, 1, 1,
			1, 1, 1, 0, 0, 1, 1, 0, 0, 1,
			1, 0, 0, 1, 1, 0, 1, 1, 1, 1,
			1, 1, 0, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 1, 0, 0, 1, 1, 1, 1,
			1, 1
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 1, 1, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 1
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 1, 1, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 1, 1, 1, 1,
			1, 0
		}
	};

	public static byte[,] LogoSquareData = new byte[6, 15]
	{
		{
			0, 1, 1, 1, 1, 1, 0, 1, 1, 1,
			1, 1, 0, 0, 0
		},
		{
			1, 1, 0, 0, 0, 0, 0, 1, 1, 0,
			0, 1, 1, 0, 0
		},
		{
			1, 1, 0, 0, 0, 0, 0, 1, 1, 0,
			0, 0, 1, 1, 0
		},
		{
			1, 1, 0, 0, 0, 0, 0, 1, 1, 0,
			0, 0, 1, 1, 0
		},
		{
			1, 1, 0, 0, 0, 0, 0, 1, 1, 0,
			0, 0, 1, 1, 0
		},
		{
			0, 1, 1, 1, 1, 1, 0, 1, 1, 1,
			1, 1, 1, 1, 0
		}
	};

	private static Dictionary<char, byte[]> CharToB = new Dictionary<char, byte[]>
	{
		{
			' ',
			new byte[5]
		},
		{
			'a',
			new byte[5] { 0, 0, 0, 0, 1 }
		},
		{
			'b',
			new byte[5] { 0, 0, 0, 1, 0 }
		},
		{
			'c',
			new byte[5] { 0, 0, 0, 1, 1 }
		},
		{
			'd',
			new byte[5] { 0, 0, 1, 0, 0 }
		},
		{
			'e',
			new byte[5] { 0, 0, 1, 0, 1 }
		},
		{
			'f',
			new byte[5] { 0, 0, 1, 1, 0 }
		},
		{
			'g',
			new byte[5] { 0, 0, 1, 1, 1 }
		},
		{
			'h',
			new byte[5] { 0, 1, 0, 0, 0 }
		},
		{
			'i',
			new byte[5] { 0, 1, 0, 0, 1 }
		},
		{
			'j',
			new byte[5] { 0, 1, 0, 1, 0 }
		},
		{
			'k',
			new byte[5] { 0, 1, 0, 1, 1 }
		},
		{
			'l',
			new byte[5] { 0, 1, 1, 0, 0 }
		},
		{
			'm',
			new byte[5] { 0, 1, 1, 0, 1 }
		},
		{
			'n',
			new byte[5] { 0, 1, 1, 1, 0 }
		},
		{
			'o',
			new byte[5] { 0, 1, 1, 1, 1 }
		},
		{
			'p',
			new byte[5] { 1, 0, 0, 0, 0 }
		},
		{
			'q',
			new byte[5] { 1, 0, 0, 0, 1 }
		},
		{
			'r',
			new byte[5] { 1, 0, 0, 1, 0 }
		},
		{
			's',
			new byte[5] { 1, 0, 0, 1, 1 }
		},
		{
			't',
			new byte[5] { 1, 0, 1, 0, 0 }
		},
		{
			'u',
			new byte[5] { 1, 0, 1, 0, 1 }
		},
		{
			'v',
			new byte[5] { 1, 0, 1, 1, 0 }
		},
		{
			'w',
			new byte[5] { 1, 0, 1, 1, 1 }
		},
		{
			'x',
			new byte[5] { 1, 1, 0, 0, 0 }
		},
		{
			'y',
			new byte[5] { 1, 1, 0, 0, 1 }
		},
		{
			'z',
			new byte[5] { 1, 1, 0, 1, 0 }
		}
	};

	public static void GenerateLogo(float width, float height, float spacingX, float spacingY, string msg, Action<Vector4, bool> builder, byte[,] pos)
	{
		int num = 0;
		byte[] array = StringToBit(msg);
		for (int i = 0; i < pos.GetLength(0); i++)
		{
			for (int j = 0; j < pos.GetLength(1); j++)
			{
				if (pos[i, j] != 0)
				{
					builder(new Vector4((float)j * (width + spacingX), (float)i * (height + spacingY), width, height), array[num % array.Length] == 1);
					num++;
				}
			}
		}
	}

	public static void GenerateLogo(float width, float height, float spacingX, float spacingY, string msg, Action<Vector4, bool> builder)
	{
		GenerateLogo(width, height, spacingX, spacingY, msg, builder, LogoData);
	}

	private static byte[] StringToBit(string msg)
	{
		List<byte> list = new List<byte>();
		string text = msg.ToLower();
		foreach (char key in text)
		{
			byte[] value = new byte[5];
			CharToB.TryGetValue(key, out value);
			list.AddRange(value);
		}
		return list.ToArray();
	}

	public static string BitToString(byte[] bits)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < bits.Length; i += 5)
		{
			byte[] tb = bits.Skip(i).Take(5).ToArray();
			KeyValuePair<char, byte[]> keyValuePair = CharToB.FirstOrDefault((KeyValuePair<char, byte[]> x) => x.Value.SequenceEqual(tb));
			if (keyValuePair.Key == '\0')
			{
				stringBuilder.Append('*');
			}
			else
			{
				stringBuilder.Append(keyValuePair.Key);
			}
		}
		return stringBuilder.ToString();
	}
}
