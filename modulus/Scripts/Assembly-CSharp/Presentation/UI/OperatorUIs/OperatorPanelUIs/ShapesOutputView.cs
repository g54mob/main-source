using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Data.Variables.Recipes;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class ShapesOutputView : MonoBehaviour
	{
		[Header("Input output View")]
		[SerializeField]
		private GameObject _panel;

		[SerializeField]
		private List<ModuleView> _inputModuleViews = new List<ModuleView>();

		[SerializeField]
		private List<ModuleView> _outputModuleViews = new List<ModuleView>();

		private readonly List<(ShapeResource, int)> _outputShapes = new List<(ShapeResource, int)>();

		private readonly List<(ShapeResource, int)> _inputShapes = new List<(ShapeResource, int)>();

		private readonly List<ShapeHashPair> _outputHashes = new List<ShapeHashPair>();

		private readonly List<ShapeHashPair> _inputHashes = new List<ShapeHashPair>();

		private readonly List<(ResourceDataSO, int)> _outputResources = new List<(ResourceDataSO, int)>();

		private readonly List<(ResourceDataSO, int)> _inputResources = new List<(ResourceDataSO, int)>();

		private FactoryObject _factoryObject;

		public bool SetContent(FactoryObject factoryObject, out int uniqueInputsCount, out int uniqueOutputsCount, out int totalOutputsCount)
		{
			_factoryObject = factoryObject;
			CleanUp();
			totalOutputsCount = 0;
			if (_factoryObject != null)
			{
				PopulateResourceLists(_factoryObject, out totalOutputsCount);
			}
			bool num = _outputShapes.Count > 0;
			if (num)
			{
				SetModuleViews(_inputModuleViews, _inputShapes);
				SetModuleViews(_outputModuleViews, _outputShapes);
			}
			uniqueInputsCount = _inputShapes.Count;
			uniqueOutputsCount = _outputShapes.Count;
			return num;
		}

		public bool SetContent(SerializedDictionary<ResourceDataSO, int> inputs, List<ResourceRecipe.Output> outputs)
		{
			CleanUp();
			foreach (KeyValuePair<ResourceDataSO, int> input in inputs)
			{
				_inputResources.Add((input.Key, input.Value));
			}
			for (int i = 0; i < outputs.Count; i++)
			{
				_outputResources.Add((outputs[i].resourceDataSO, outputs[i].OutputAmount));
			}
			_panel.SetActive(_outputResources.Count > 0);
			if (_panel.activeSelf)
			{
				SetModuleViews(_inputModuleViews, _inputResources);
				SetModuleViews(_outputModuleViews, _outputResources);
			}
			return true;
		}

		private void PopulateResourceLists(FactoryObject factoryObject, out int outputShapeCount)
		{
			outputShapeCount = 0;
			IResourceHolder resourceHolderBehaviour = factoryObject.GetResourceHolderBehaviour();
			if (resourceHolderBehaviour == null)
			{
				return;
			}
			foreach (Resource outputResource in resourceHolderBehaviour.GetOutputResources())
			{
				outputShapeCount++;
				ShapeResource shapeResource = (ShapeResource)outputResource;
				ShapeHashPair shapeHash = shapeResource.ShapeData.GetShapeHash();
				int num = _outputHashes.IndexOf(shapeHash);
				if (num > -1)
				{
					_outputShapes[num] = (_outputShapes[num].Item1, _outputShapes[num].Item2 + 1);
					continue;
				}
				_outputHashes.Add(shapeHash);
				_outputShapes.Add((shapeResource, 1));
			}
			foreach (ShapeResource inputResource in resourceHolderBehaviour.GetInputResources())
			{
				ShapeHashPair shapeHash2 = inputResource.ShapeData.GetShapeHash();
				int num = _inputHashes.IndexOf(shapeHash2);
				if (num > -1)
				{
					_inputShapes[num] = (_inputShapes[num].Item1, _inputShapes[num].Item2 + 1);
					continue;
				}
				_inputHashes.Add(shapeHash2);
				_inputShapes.Add((inputResource, 1));
			}
		}

		private void SetModuleViews(List<ModuleView> moduleViews, List<(ShapeResource, int)> shapes)
		{
			int num = 0;
			foreach (ModuleView moduleView in moduleViews)
			{
				if (num < shapes.Count)
				{
					moduleViews[num].RenderShape(shapes[num].Item1, shapes[num].Item2, moduleView);
				}
				else
				{
					moduleView.gameObject.SetActive(value: false);
				}
				num++;
			}
		}

		private void SetModuleViews(List<ModuleView> moduleViews, List<(ResourceDataSO, int)> resources)
		{
			int num = 0;
			foreach (ModuleView moduleView in moduleViews)
			{
				if (num < resources.Count)
				{
					moduleViews[num].SetResource(resources[num].Item1 as NonShapeResourceDataSO, resources[num].Item2);
				}
				else
				{
					moduleView.gameObject.SetActive(value: false);
				}
				num++;
			}
		}

		public void CleanUp()
		{
			foreach (ModuleView inputModuleView in _inputModuleViews)
			{
				inputModuleView.StopRenderingShape();
			}
			foreach (ModuleView outputModuleView in _outputModuleViews)
			{
				outputModuleView.StopRenderingShape();
			}
			CleanUp(_outputShapes, _outputHashes, _outputResources);
			CleanUp(_inputShapes, _inputHashes, _inputResources);
		}

		private void CleanUp(List<(ShapeResource, int)> shapes, List<ShapeHashPair> hashes, List<(ResourceDataSO, int)> resources)
		{
			shapes.Clear();
			hashes.Clear();
			resources.Clear();
		}
	}
}
