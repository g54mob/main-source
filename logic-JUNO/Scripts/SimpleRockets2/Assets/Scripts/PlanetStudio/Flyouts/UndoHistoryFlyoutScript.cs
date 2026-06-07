using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class UndoHistoryFlyoutScript : PlanetStudioFlyoutScript
	{
		public class UndoElement
		{
			public TextMeshProUGUI NameText { get; set; }

			public XmlElement RowElement { get; set; }

			public UndoStep UndoStep { get; }

			public UndoElement(UndoStep undoStep)
			{
				UndoStep = undoStep;
			}
		}

		private CelestialBodyDesignerScript _designer;

		private bool _refreshRequired;

		private UndoElement _selectedElement;

		public UndoElement SelectedUndo
		{
			get
			{
				return _selectedElement;
			}
			private set
			{
				if (_selectedElement != value)
				{
					if (_selectedElement != null)
					{
						_selectedElement.RowElement.RemoveClass("selected");
					}
					_selectedElement = value;
					if (_selectedElement != null)
					{
						_selectedElement.RowElement.AddClass("selected");
					}
				}
			}
		}

		public List<UndoElement> UndoElements { get; private set; } = new List<UndoElement>();

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_designer = base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript;
			base.PlanetStudioUI.UndoHistory.Changed += OnUndoHistoryChanged;
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			_selectedElement = null;
			foreach (UndoElement undoElement2 in UndoElements)
			{
				UnityEngine.Object.Destroy(undoElement2.RowElement.gameObject);
			}
			UndoElements.Clear();
			foreach (UndoStep undoStep in base.PlanetStudioUI.UndoHistory.UndoSteps)
			{
				UndoElement undoElement = new UndoElement(undoStep);
				UndoElements.Add(undoElement);
				CreateRowElement(undoElement);
				if (undoStep == base.PlanetStudioUI.UndoHistory.CurrentUndoStep)
				{
					SelectedUndo = undoElement;
				}
			}
			_refreshRequired = false;
		}

		protected override void Update()
		{
			base.Update();
			if (_refreshRequired)
			{
				RefreshUI();
			}
		}

		private void CreateRowElement(UndoElement undoElement)
		{
			XmlElement elementById = base.xmlLayout.GetElementById("row-template");
			XmlElement xmlElement = UiUtilities.CloneTemplate(elementById, elementById.parentElement);
			undoElement.NameText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("name");
			undoElement.NameText.text = undoElement.UndoStep.Description;
			undoElement.RowElement = xmlElement;
			xmlElement.transform.SetSiblingIndex(0);
		}

		private void OnListItemClicked(XmlElement rowElement)
		{
			UndoElement undoElement = UndoElements.Where((UndoElement x) => x.RowElement == rowElement).FirstOrDefault();
			base.PlanetStudioUI.Undo(undoElement.UndoStep);
		}

		private void OnUndoHistoryChanged(object sender, EventArgs e)
		{
			_refreshRequired = true;
		}
	}
}
