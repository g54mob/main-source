using System.Collections.Generic;
using UnityEngine;

namespace Systems.DialogSystem.Twine
{
	public class DialogueTwine
	{
		private readonly Dictionary<string, Node> _nodes;

		private string _title;

		private string _titleOfStartNode;

		private string Separator { get; set; }

		public DialogueTwine(TextAsset twineText)
		{
		}

		public Dictionary<string, Node> GetAllNodes()
		{
			return null;
		}

		public Node GetNode(string nodeTitle)
		{
			return null;
		}

		public bool ExistNode(string nodeTitle)
		{
			return false;
		}

		private void ParseTwineText(string twineText)
		{
		}

		private static string SkipPositionData(string currLineText)
		{
			return null;
		}

		private void SelectSeparator(string twineText)
		{
		}

		private static void ParseLines(string[] lines, List<Response> responses, List<Line> data)
		{
		}

		private static SpeechLine GetDialogLine(string text)
		{
			return null;
		}
	}
}
