using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class QueryInputUtils : MonoBehaviour
{
	private string[] RICH_TEXT_TAGS = new string[30]
	{
		"align", "alpha", "color", "b", "i", "cspace", "font", "indent", "line-height", "line-indent",
		"link", "lowercase", "uppercase", "smallcaps", "margin", "mspace", "noparse", "nobr", "page", "pos",
		"size", "space", "sprite", "s", "u", "style", "sub", "sup", "voffset", "width"
	};

	public const string KEYWORD_COLOR = "purple";

	public const string STRING_COLOR = "blue";

	public const string NUMBER_COLOR = "#33CC37";

	public const string TABLE_COLOR = "orange";

	public const string COMMENT_COLOR = "grey";

	public const string COL_COLOR = "#fc574b";

	[SerializeField]
	private TMP_InputField queryInput;

	[SerializeField]
	private TextMeshProUGUI inputView;

	[SerializeField]
	private PanelManager tableManager;

	public static string contrabandUsed;

	private char[] ILLEGAL_CHARS = new char[4] { ';', '\r', '\v', '\f' };

	public void Start()
	{
		TMP_InputField tMP_InputField = queryInput;
		tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, (TMP_InputField.OnValidateInput)((string input, int charIndex, char addedChar) => ValidateInput(addedChar)));
	}

	public static List<string> GetQueryTables(string query, ICollection<string> tableNames)
	{
		HashSet<string> hashSet = new HashSet<string>();
		Tokenizer tokenizer = new Tokenizer(query);
		try
		{
			while (tokenizer.HasNextToken())
			{
				Token token = tokenizer.NextToken();
				if (tableNames.Contains(token.ToString(), StringComparer.OrdinalIgnoreCase))
				{
					hashSet.Add(token.ToString());
				}
			}
		}
		catch (Exception)
		{
		}
		List<string> list = new List<string>();
		IDbConnection connection = DatabaseUtils.GetConnection();
		foreach (string tableName in tableNames)
		{
			if (hashSet.Contains(tableName, StringComparer.OrdinalIgnoreCase))
			{
				list.AddRange(DatabaseUtils.GetTableColumnNames(connection, tableName));
			}
		}
		connection.Close();
		return list;
	}

	public void HighlightKeywords()
	{
		inputView.text = SanitizeInput(queryInput.text);
		ICollection<string> tableNames = tableManager.GetTableNames();
		ICollection<string> queryTables = GetQueryTables(inputView.text, tableNames);
		HighlightKeywords(inputView, tableNames, queryTables);
	}

	public static void HighlightKeywords(TextMeshProUGUI inputView, ICollection<string> tableNames, ICollection<string> columnNames)
	{
		contrabandUsed = null;
		bool flag = false;
		char c = '\0';
		for (int i = 0; i < inputView.text.Length; i++)
		{
			char c2 = inputView.text[i];
			char c3 = ((i < inputView.text.Length - 1) ? inputView.text[i + 1] : '\0');
			if (c2 == '/' && c3 == '*')
			{
				i += InsertStartColorTag(i, "grey", inputView);
				string text = "*/";
				for (; i < inputView.text.Length; i++)
				{
					if (i + text.Length < inputView.text.Length && inputView.text.Substring(i, text.Length).Equals(text))
					{
						string text2 = "</color>";
						inputView.text = inputView.text.Insert(i + text.Length, text2);
						i += text2.Length + text.Length;
						break;
					}
				}
			}
			else if ((c2 == '\'' || c2 == '"') && (c == '\0' || c2 == c))
			{
				int num = 0;
				string text3;
				if (flag)
				{
					text3 = "</color>";
					num = 1;
					c = '\0';
				}
				else
				{
					text3 = "<color=blue>";
					c = c2;
				}
				flag = !flag;
				inputView.text = inputView.text.Insert(i + num, text3);
				i += text3.Length;
			}
			else
			{
				if (flag)
				{
					continue;
				}
				bool flag2 = i + 1 < inputView.text.Length && char.IsDigit(inputView.text, i + 1);
				if ((i == 0 || IsNumericSeparator(inputView.text[i - 1])) && (char.IsDigit(c2) || (c2 == '.' && flag2)))
				{
					int num2 = 0;
					int num3 = 0;
					bool flag3 = true;
					bool flag4 = true;
					int index = i;
					for (; i < inputView.text.Length; i++)
					{
						char c4 = inputView.text[i];
						bool flag5 = i + 1 < inputView.text.Length;
						flag2 = flag5 && char.IsDigit(inputView.text, i + 1);
						bool flag6 = IsNumericSeparator(c4);
						bool flag7 = c4 == '.';
						bool flag8 = c4 == 'e' || c4 == 'E';
						bool flag9 = (c4 == '+' || c4 == '-') && flag5 && flag2 && i > 0 && (inputView.text[i - 1] == 'e' || inputView.text[i - 1] == 'E');
						bool flag10 = flag5 && (inputView.text[i + 1] == '+' || inputView.text[i + 1] == '-') && i + 2 < inputView.text.Length && char.IsDigit(inputView.text, i + 2);
						if (flag7)
						{
							if (num3 >= 1)
							{
								flag4 = false;
							}
							num2++;
						}
						else if (flag8)
						{
							num3++;
						}
						bool flag11 = char.IsDigit(c4) || (num2 <= 1 && flag7 && flag4) || (num3 <= 1 && flag8 && (flag2 || flag10));
						if (!flag6 && !flag11)
						{
							flag3 = false;
						}
						if ((flag6 && !flag9) || i + 1 >= inputView.text.Length)
						{
							if (flag3)
							{
								i += InsertStartColorTag(index, "#33CC37", inputView);
								string text4 = "</color>";
								inputView.text = inputView.text.Insert(i + ((!flag6) ? 1 : 0), text4);
								i += text4.Length;
							}
							break;
						}
					}
					continue;
				}
				int length = inputView.text.Substring(i).Length;
				foreach (string kEYWORD in QueryParser.KEYWORDS)
				{
					if (kEYWORD.Length <= length)
					{
						string text5 = inputView.text.Substring(i, kEYWORD.Length);
						bool num4 = i == 0 || IsKeywordSeparator(inputView.text[i - 1]);
						bool flag12 = i + text5.Length >= inputView.text.Length || IsKeywordSeparator(inputView.text[i + text5.Length]);
						if (num4 && flag12 && string.Equals(text5, kEYWORD, StringComparison.OrdinalIgnoreCase))
						{
							string text6 = "<color=purple>" + kEYWORD + "</color>";
							inputView.text = inputView.text.Substring(0, i) + text6 + inputView.text.Substring(i + text5.Length);
							i += text6.Length;
							break;
						}
					}
				}
				length = inputView.text.Substring(i).Length;
				foreach (string tableName in tableNames)
				{
					if (tableName.Length <= length)
					{
						string text7 = inputView.text.Substring(i, tableName.Length);
						bool num5 = i == 0 || IsTableSeparator(inputView.text[i - 1]);
						bool flag13 = i + text7.Length >= inputView.text.Length || IsTableSeparator(inputView.text[i + text7.Length]);
						if (num5 && flag13 && string.Equals(text7, tableName, StringComparison.OrdinalIgnoreCase))
						{
							string text8 = "<color=orange>" + text7 + "</color>";
							inputView.text = inputView.text.Substring(0, i) + text8 + inputView.text.Substring(i + text7.Length);
							i += text8.Length;
							break;
						}
					}
				}
				length = inputView.text.Substring(i).Length;
				foreach (string columnName in columnNames)
				{
					if (columnName.Length <= length)
					{
						string text9 = inputView.text.Substring(i, columnName.Length);
						bool num6 = i == 0 || IsTableSeparator(inputView.text[i - 1]);
						bool flag14 = i + text9.Length >= inputView.text.Length || IsTableSeparator(inputView.text[i + text9.Length]);
						if (num6 && flag14 && string.Equals(text9, columnName, StringComparison.OrdinalIgnoreCase))
						{
							string text10 = "<color=#fc574b>" + text9 + "</color>";
							inputView.text = inputView.text.Substring(0, i) + text10 + inputView.text.Substring(i + text9.Length);
							i += text10.Length;
							break;
						}
					}
				}
				length = inputView.text.Substring(i).Length;
				foreach (string iLLEGAL_MATERIAL in QueryParser.ILLEGAL_MATERIALS)
				{
					if (iLLEGAL_MATERIAL.Length <= length)
					{
						string text11 = inputView.text.Substring(i, iLLEGAL_MATERIAL.Length);
						bool num7 = i == 0 || IsKeywordSeparator(inputView.text[i - 1]);
						bool flag15 = i + text11.Length >= inputView.text.Length || IsKeywordSeparator(inputView.text[i + text11.Length]);
						if (num7 && flag15 && string.Equals(text11, iLLEGAL_MATERIAL, StringComparison.OrdinalIgnoreCase))
						{
							contrabandUsed = iLLEGAL_MATERIAL;
							break;
						}
					}
				}
			}
		}
	}

	private static bool IsNumericSeparator(char character)
	{
		string text = ",()+/*=-<>";
		if (!char.IsWhiteSpace(character))
		{
			return text.Contains(character.ToString() ?? "");
		}
		return true;
	}

	private static bool IsKeywordSeparator(char character)
	{
		string text = ",()*";
		if (!char.IsWhiteSpace(character))
		{
			return text.Contains(character.ToString() ?? "");
		}
		return true;
	}

	private static bool IsTableSeparator(char character)
	{
		string text = ",().";
		if (!char.IsWhiteSpace(character))
		{
			return text.Contains(character.ToString() ?? "");
		}
		return true;
	}

	private static int InsertStartColorTag(int index, string color, TextMeshProUGUI inputView)
	{
		string text = "<color=" + color + ">";
		inputView.text = inputView.text.Insert(index, text);
		return text.Length;
	}

	private char ValidateInput(char addedChar)
	{
		if (ILLEGAL_CHARS.Contains(addedChar) || IsCtrlEnter(addedChar))
		{
			return '\0';
		}
		return UIUtils.RemoveDiacritics(addedChar);
	}

	private bool IsCtrlEnter(char addedChar)
	{
		if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.V))
		{
			return addedChar == '\n';
		}
		return false;
	}

	private string SanitizeInput(string input)
	{
		string text = input;
		string[] rICH_TEXT_TAGS = RICH_TEXT_TAGS;
		foreach (string text2 in rICH_TEXT_TAGS)
		{
			text = Regex.Replace(text, "<(/?" + text2 + ".*)>", "?$1?", RegexOptions.IgnoreCase);
		}
		return text;
	}
}
