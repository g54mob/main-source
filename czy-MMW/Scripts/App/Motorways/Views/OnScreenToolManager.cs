using System;
using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways.Views
{
	public class OnScreenToolManager : MonoBehaviour, IOnScreenToolManager, ICreatedInScopeHandler
	{
		[Dependency]
		private IScope _scope;

		private static readonly Vector2Int BaseResolution = new Vector2Int(1920, 1080);

		private readonly List<IOnScreenTool> _activeTools = new List<IOnScreenTool>();

		private OnScreenDebugToolsActivator _debugToolsActivator;

		private Matrix4x4 _scalingMatrix = Matrix4x4.identity;

		private Matrix4x4 _inverseScalingMatrix = Matrix4x4.identity;

		private Vector2Int _resolution = Vector2Int.zero;

		private void Awake()
		{
			if (!FeatureToggle.IsFeatureEnabled(Feature.OnScreenDebugTools))
			{
				base.enabled = false;
			}
		}

		public void Initialize(OnScreenDebugToolsActivator debugToolsActivator)
		{
			_debugToolsActivator = debugToolsActivator;
			base.enabled = _debugToolsActivator.AreToolsActive;
			OnScreenDebugToolsActivator debugToolsActivator2 = _debugToolsActivator;
			debugToolsActivator2.onActivationStatusChanged = (OnScreenDebugToolsActivator.ActivationStatusChange)Delegate.Combine(debugToolsActivator2.onActivationStatusChanged, (OnScreenDebugToolsActivator.ActivationStatusChange)delegate(bool isEnabled)
			{
				base.enabled = isEnabled;
			});
		}

		public void OnCreatedInScope(IScope scope)
		{
			_activeTools.Add(new OnScreenDebugRenderTool());
			_activeTools.Add(new OnScreenSaveTool(scope));
		}

		private void OnGUI()
		{
			if (_resolution.x != Screen.width || _resolution.y != Screen.height)
			{
				_resolution = new Vector2Int(Screen.width, Screen.height);
				Vector3 s = new Vector3((float)Screen.width / (float)BaseResolution.x, (float)Screen.height / (float)BaseResolution.y, 1f);
				_scalingMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, s);
				_inverseScalingMatrix = _scalingMatrix.inverse;
			}
			Matrix4x4 matrix = GUI.matrix;
			GUI.matrix = _scalingMatrix;
			foreach (IOnScreenTool activeTool in _activeTools)
			{
				activeTool.OnGUI(_scope);
			}
			GUI.matrix = matrix;
		}

		private void Update()
		{
			foreach (IOnScreenTool activeTool in _activeTools)
			{
				activeTool.Update();
			}
		}

		public bool IsPointInsideTool(Vector2 coordinates)
		{
			if (!base.enabled)
			{
				return false;
			}
			coordinates.y = (float)Screen.height - coordinates.y;
			coordinates = _inverseScalingMatrix * coordinates;
			foreach (IOnScreenTool activeTool in _activeTools)
			{
				if (activeTool.InputBlockingRect.Contains(coordinates))
				{
					return true;
				}
			}
			return false;
		}
	}
}
