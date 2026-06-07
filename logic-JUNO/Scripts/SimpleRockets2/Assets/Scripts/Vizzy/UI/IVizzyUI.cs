using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Vizzy.UI.Elements;
using ModApi.Audio;
using ModApi.Craft.Program;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public interface IVizzyUI
	{
		Camera Camera { get; }

		RectTransform DragTransform { get; }

		FlightProgram FlightProgram { get; }

		bool Interactable { get; }

		INodeBuilder NodeBuilder { get; }

		RectTransform ProgramTransform { get; }

		BlockElementScript SelectedElement { get; set; }

		VizzyToolbox Toolbox { get; }

		BlockElementScript CreateElementForNode(ProgramNode programNode);

		void CreateUndoStep(string ignoreKey = null);

		void DisplayConnectionHint(Vector2 source, Vector2 target);

		void DragBegin(List<BlockElementScript> blocks, Vector2 position);

		void DragEnd(Vector2 position);

		void DragUpdate(Vector2 position);

		void HideConnectionHint();

		void ImportFlightProgram(XElement programXml);

		void LoadFlightProgram(XElement programXml);

		AudioSource PlaySound(AudioFile audioFile);

		XElement SaveFlightProgram();

		void ShowMessage(string message, float time = 7f);

		void ShowValidationError(string message);
	}
}
