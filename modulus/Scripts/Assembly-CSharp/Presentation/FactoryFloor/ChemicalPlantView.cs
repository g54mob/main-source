using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Data.FactoryFloor.Resources;
using Data.Variables.Recipes;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class ChemicalPlantView : RecipeOperatorView
	{
		[Serializable]
		private struct ResourceColor
		{
			public Color Color;

			public ResourceDataSO ResourceDataSO;
		}

		[SerializeField]
		private MeshRenderer _tankInput1;

		[SerializeField]
		private MeshRenderer _tankInput2;

		[SerializeField]
		private MeshRenderer _tankOutput;

		[SerializeField]
		private List<ResourceColor> _resourceColors = new List<ResourceColor>();

		private bool _waitForNextResource;

		private bool _outputTankFilled;

		private Dictionary<MeshRenderer, Tweener> _currentTweens = new Dictionary<MeshRenderer, Tweener>();

		private const float INPUT_PAINT_FILL_UP = 6.8f;

		private const float OUTPUT_PAINT_FILL_UP = 5.3f;

		private const float PAINT_FILL_DOWN = 2.8f;

		private const string COLOR_SHADER_PARAM = "_BaseColor";

		private const string FILL_SHADER_PARAM = "_FillAmount";

		protected override void Init()
		{
			base.Init();
			_behaviour.OnChangedRecipe.RegisterMainThread(OnRecipeChange);
			_behaviour.OnResourceAdded.RegisterMainThread(OnResourceAdded);
			_behaviour.OnOutputResource.RegisterMainThread(OnResourcePassed);
			OnRecipeChange(_behaviour.CurrentRecipe);
			AnimatePaintFill(_tankInput1, hasPaint: false, input: true);
			AnimatePaintFill(_tankInput2, hasPaint: false, input: true);
			AnimatePaintFill(_tankOutput, hasPaint: false, input: false);
			_outputTankFilled = false;
			_waitForNextResource = true;
		}

		private void OnResourcePassed(Resource resource, int index)
		{
			if (_outputTankFilled)
			{
				_outputTankFilled = false;
				AnimatePaintFill(_tankOutput, hasPaint: false, input: false, RetriggerCycleIfComplete);
			}
		}

		private void RetriggerCycleIfComplete()
		{
			if (IsRecipeComplete())
			{
				DoFullFillCycle();
			}
			else
			{
				_waitForNextResource = true;
			}
		}

		private void DoFullFillCycle()
		{
			AnimatePaintFill(_tankInput1, hasPaint: true, input: true);
			AnimatePaintFill(_tankInput2, hasPaint: true, input: true, delegate
			{
				FillOutputTank();
			});
		}

		private void FillOutputTank()
		{
			AnimatePaintFill(_tankInput1, hasPaint: false, input: true);
			AnimatePaintFill(_tankInput2, hasPaint: false, input: true);
			AnimatePaintFill(_tankOutput, hasPaint: true, input: false);
			_outputTankFilled = true;
		}

		private void OnResourceAdded(Resource resource, int inputIndex)
		{
			if (!_waitForNextResource)
			{
				return;
			}
			MeshRenderer meshRenderer = ((inputIndex == 0) ? _tankInput1 : _tankInput2);
			if (TryGetColorFromResource(resource.Data, out var color))
			{
				meshRenderer.material.SetColor("_BaseColor", color);
			}
			if (IsRecipeComplete())
			{
				AnimatePaintFill(meshRenderer, hasPaint: true, input: true, delegate
				{
					FillOutputTank();
					_waitForNextResource = false;
				});
			}
			else
			{
				AnimatePaintFill(meshRenderer, hasPaint: true, input: true);
			}
		}

		private bool TryGetColorFromResource(ResourceDataSO resourceData, out Color color)
		{
			foreach (ResourceColor resourceColor in _resourceColors)
			{
				if (resourceData == resourceColor.ResourceDataSO)
				{
					color = resourceColor.Color;
					return true;
				}
			}
			color = Color.black;
			return false;
		}

		private bool IsRecipeComplete()
		{
			for (int i = 0; i < _behaviour.CurrentRecipe.Inputs.Count; i++)
			{
				KeyValuePair<ResourceDataSO, int> keyValuePair = _behaviour.CurrentRecipe.Inputs.ElementAt(i);
				if (_behaviour.CurrentResources[i] < keyValuePair.Value)
				{
					return false;
				}
			}
			return true;
		}

		private void OnRecipeChange(ResourceRecipe obj)
		{
			for (int i = 0; i < obj.Outputs.Count; i++)
			{
				if (TryGetColorFromResource(obj.Outputs[i].resourceDataSO, out var color))
				{
					_tankOutput.material.SetColor("_BaseColor", color);
					break;
				}
			}
		}

		private void AnimatePaintFill(MeshRenderer meshRend, bool hasPaint, bool input, TweenCallback onComplete = null)
		{
			Vector4 endValue = new Vector4(0f, 2.8f, 0f, 0f);
			if (hasPaint)
			{
				if (input)
				{
					endValue.y = 6.8f;
				}
				else
				{
					endValue.y = 5.3f;
				}
			}
			if (!_currentTweens.ContainsKey(meshRend))
			{
				_currentTweens.Add(meshRend, null);
			}
			if (_currentTweens[meshRend] != null)
			{
				_currentTweens[meshRend].Kill();
			}
			TweenerCore<Vector4, Vector4, VectorOptions> value = DOTween.To(() => meshRend.material.GetVector("_FillAmount"), delegate(Vector4 value2)
			{
				meshRend.material.SetVector("_FillAmount", value2);
			}, endValue, 0.5f).SetEase(Ease.OutBack).OnComplete(onComplete);
			_currentTweens[meshRend] = value;
		}

		protected override void ResetView()
		{
			base.ResetView();
			if ((bool)_behaviour)
			{
				_behaviour.OnChangedRecipe.UnRegisterMainThread(OnRecipeChange);
				_behaviour.OnResourceAdded.UnRegisterMainThread(OnResourceAdded);
				_behaviour.OnOutputResource.UnRegisterMainThread(OnResourcePassed);
			}
		}
	}
}
