using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Data.FactoryFloor.Resources;
using Data.Variables.Recipes;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class DyeMixerView : RecipeOperatorView
	{
		private const float PAINT_FILL_UP = -0.42f;

		private const float PAINT_FILL_DOWN = -1f;

		[SerializeField]
		private MeshRenderer _paintMeshRenderer;

		private bool _waitForNextResource;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnChangedRecipe.RegisterMainThread(OnRecipeChange);
			_behaviour.OnResourceCountUpdated.RegisterMainThread(OnResourceCountUpdated);
			_behaviour.OnOutputResource.RegisterMainThread(OnResourcePassed);
			OnRecipeChange(_behaviour.CurrentRecipe);
			AnimatePaintFill(hasPaint: false);
			_waitForNextResource = true;
		}

		private void OnResourcePassed(Resource arg1, int arg2)
		{
			AnimatePaintFill(hasPaint: false, delegate
			{
				if (IsRecipeComplete())
				{
					AnimatePaintFill(hasPaint: true);
				}
				else
				{
					_waitForNextResource = true;
				}
			});
		}

		private void OnResourceCountUpdated()
		{
			if (_waitForNextResource && IsRecipeComplete())
			{
				AnimatePaintFill(hasPaint: true);
				_waitForNextResource = false;
			}
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
				if (obj.Outputs[i].resourceDataSO is PaintResourceDataSO paintResourceDataSO)
				{
					_paintMeshRenderer.material.SetColor("_BaseColor", paintResourceDataSO.Color);
					break;
				}
			}
		}

		private void AnimatePaintFill(bool hasPaint, TweenCallback onComplete = null)
		{
			Vector4 endValue = new Vector4(0f, hasPaint ? (-0.42f) : (-1f), 0f, 0f);
			DOTween.To(() => _paintMeshRenderer.material.GetVector("_FillAmount"), delegate(Vector4 value)
			{
				_paintMeshRenderer.material.SetVector("_FillAmount", value);
			}, endValue, 0.5f).SetEase(Ease.OutBack).OnComplete(onComplete);
		}

		protected override void ResetView()
		{
			base.ResetView();
			if ((bool)_behaviour)
			{
				_behaviour.OnChangedRecipe.UnRegisterMainThread(OnRecipeChange);
				_behaviour.OnResourceCountUpdated.UnRegisterMainThread(OnResourceCountUpdated);
				_behaviour.OnOutputResource.UnRegisterMainThread(OnResourcePassed);
			}
		}
	}
}
