using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Tools.ObjectTransform;
using DG.Tweening;
using ModApi;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.PartProperties
{
	public class CrewCompartmentPartProperties : GenericPartPropertiesScript
	{
		private Toggle _changeExitPositionButton;

		private Toggle _changeExitRotationButton;

		private TextMeshProUGUI _changeExitRotationButtonLabel;

		private Transform _crewExit;

		private RotateGizmoWrapper _crewExitOrientationAdjustor;

		private TranslateGizmoWrapper _crewExitPositionAdjustor;

		private List<XmlElement> _crewList = new List<XmlElement>();

		private DesignerScript _designer;

		private PartPropertiesFlyoutScript _flyout;

		private CrewCompartmentData Data => base.CurrentPartModifier as CrewCompartmentData;

		public override void OnPartDeselected(IPartScript part)
		{
			base.OnPartDeselected(part);
			if (_changeExitRotationButton.isOn)
			{
				_changeExitRotationButton.isOn = false;
			}
			if (_changeExitPositionButton.isOn)
			{
				_changeExitPositionButton.isOn = false;
			}
		}

		public override bool OnPartSelected(IPartScript part)
		{
			bool result = base.OnPartSelected(part);
			if (Data != null)
			{
				RefreshList();
			}
			if (_changeExitRotationButton.isOn)
			{
				_changeExitRotationButton.isOn = false;
			}
			if (_changeExitPositionButton.isOn)
			{
				_changeExitPositionButton.isOn = false;
			}
			return result;
		}

		public void RefreshList()
		{
			foreach (XmlElement crew in _crewList)
			{
				UnityEngine.Object.Destroy(crew.gameObject);
			}
			_crewList.Clear();
			if (Data == null)
			{
				return;
			}
			foreach (EvaScript item in Data.Script.Crew)
			{
				XmlElement xmlElement = AddCrewMember(item);
				if (item == Data.Script.DesignerCrewHighlight)
				{
					Data.Script.DesignerCrewHighlight = null;
					CanvasGroup canvasGroup = xmlElement.gameObject.AddComponent<CanvasGroup>();
					canvasGroup.alpha = 0f;
					DOTween.To(() => canvasGroup.alpha, delegate(float x)
					{
						canvasGroup.alpha = x;
					}, 1f, 1f).OnComplete(delegate
					{
						UnityEngine.Object.Destroy(canvasGroup);
					});
				}
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_designer = base.Designer as DesignerScript;
			_flyout = base.Flyout as PartPropertiesFlyoutScript;
			XmlElement xmlElement = _flyout.CloneTemplateElement("template-toggle", base.transform);
			xmlElement.gameObject.AddComponent<PropertyRowScript>();
			xmlElement.GetElementByInternalId("toggle").Tooltip = "Allows adjusting the crew's rotation upon exit.";
			_changeExitRotationButton = xmlElement.GetElementByInternalId<Toggle>("toggle");
			_changeExitRotationButton.onValueChanged.AddListener(OnAdjustExitRotationClicked);
			_changeExitRotationButtonLabel = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_changeExitRotationButtonLabel.text = "Adjust exit rotation";
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/Prefabs/Eva/AstronautRigged");
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 11);
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].sharedMaterial = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/PartEditorGizmoOpaque");
			}
			_crewExitOrientationAdjustor = new RotateGizmoWrapper(_designer.GizmoCamera, gameObject);
			_crewExitOrientationAdjustor.Gizmo.AngleSnap = 15f;
			_crewExitOrientationAdjustor.Gizmo.GridSize = 0.05f;
			_crewExitOrientationAdjustor.AdjustmentEnded += OnCrewExitRotationEnded;
			xmlElement = _flyout.CloneTemplateElement("template-toggle", base.transform);
			xmlElement.gameObject.AddComponent<PropertyRowScript>();
			xmlElement.GetElementByInternalId("toggle").Tooltip = "Allows adjusting the crew's position upon exit.";
			_changeExitPositionButton = xmlElement.GetElementByInternalId<Toggle>("toggle");
			_changeExitPositionButton.onValueChanged.AddListener(OnAdjustExitPositionClicked);
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("label").text = "Adjust exit position";
			_crewExitPositionAdjustor = new TranslateGizmoWrapper(_designer.GizmoCamera, gameObject);
			_crewExitPositionAdjustor.AdjustmentEnded += OnCrewExitPositionEnded;
			_crewExitPositionAdjustor.Gizmo.GridSize = 0.05f;
		}

		protected override void Update()
		{
			base.Update();
			CrewCompartmentData data = Data;
			if (data != null && data.Script.RefreshPartPropertiesUI)
			{
				Data.Script.RefreshPartPropertiesUI = false;
				RefreshList();
				base.Flyout.RefreshUI();
			}
		}

		private static XmlElement CreateDeleteButton(Transform parent, PartPropertiesFlyoutScript flyout, string label, string buttonLabel, string toolTip, Action<XmlElement> onClick, Action<XmlElement> onLabelClicked)
		{
			XmlElement element = flyout.CloneTemplateElement("template-label-button", parent);
			element.gameObject.AddComponent<PropertyRowScript>();
			element.GetElementByInternalId("button").Tooltip = toolTip;
			element.GetElementByInternalId<Button>("button").onClick.AddListener(delegate
			{
				onClick(element);
			});
			element.GetElementByInternalId<TextMeshProUGUI>("buttonLabel").text = buttonLabel;
			if (onLabelClicked != null)
			{
				element.GetElementByInternalId("label").AddOnClickEvent(delegate
				{
					onLabelClicked(element);
				});
			}
			element.GetElementByInternalId<TextMeshProUGUI>("label").text = label;
			return element;
		}

		private XmlElement AddCrewMember(EvaScript crew)
		{
			XmlElement xmlElement = CreateDeleteButton(base.transform, _flyout, crew.Data.CrewName, "Remove", "Remove crew", delegate(XmlElement x)
			{
				Remove(crew, x);
			}, delegate
			{
				Game.Instance.Designer.SelectPart(crew.PartScript, null, justAdded: false);
			});
			_crewList.Add(xmlElement);
			return xmlElement;
		}

		private void OnAdjustExitPositionClicked(bool isChecked)
		{
			if (isChecked && _changeExitRotationButton.isOn)
			{
				_changeExitRotationButton.isOn = false;
			}
			OnCrewExitAdjustorToggled(isChecked, _crewExitPositionAdjustor);
		}

		private void OnAdjustExitRotationClicked(bool isChecked)
		{
			if (isChecked && _changeExitPositionButton.isOn)
			{
				_changeExitPositionButton.isOn = false;
			}
			OnCrewExitAdjustorToggled(isChecked, _crewExitOrientationAdjustor);
		}

		private void OnCrewExitAdjustorToggled(bool isChecked, IMovementGizmoWrapper adjustor)
		{
			if (_crewExit != null)
			{
				UnityEngine.Object.Destroy(_crewExit.gameObject);
			}
			if (isChecked)
			{
				_crewExit = new GameObject("CrewExit").transform;
				_crewExit.parent = Data.Script.transform;
				_crewExit.localPosition = Data.CrewExitPosition;
				_crewExit.localEulerAngles = Data.CrewExitRotation;
				if (!adjustor.IsShowing)
				{
					adjustor.Start(_crewExit, showAdjustmentGizmo: true);
				}
			}
			else if (adjustor.IsShowing)
			{
				adjustor.Stop();
			}
		}

		private void OnCrewExitPositionEnded(MovementGizmoWrapper<TranslateGizmo, TranslateGizmoAxisScript> source, Vector3 finalEulerAngles)
		{
			Data.CrewExitPosition = _crewExit.localPosition;
		}

		private void OnCrewExitRotationEnded(MovementGizmoWrapper<RotateGizmo, RotateGizmoAxisScript> source, Vector3 finalEulerAngles)
		{
			Data.CrewExitRotation = _crewExit.localEulerAngles;
		}

		private void Remove(EvaScript crew, XmlElement crewUi)
		{
			foreach (PartConnection partConnectionsBetweenPart in PartConnection.GetPartConnectionsBetweenParts(Data.Part, crew.PartScript.Data))
			{
				foreach (PartConnection symmetricPartConnection in Symmetry.GetSymmetricPartConnections(Data.Part.PartScript, partConnectionsBetweenPart, includeSourcePart: false))
				{
					symmetricPartConnection.DestroyConnection();
				}
				partConnectionsBetweenPart.DestroyConnection();
			}
			RefreshList();
			base.Flyout.RefreshUI();
		}
	}
}
