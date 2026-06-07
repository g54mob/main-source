using System.Collections.Generic;
using Client;
using UnityEngine;

namespace Motorways.Views
{
	public class MenuPlacementDefinition : MonoBehaviour, IView
	{
		public List<MenuScreenNode> menuPositions;

		public GameObject background;

		public SpriteRenderer grid;

		public void SetGridAlpha(float alpha)
		{
			grid.color = new Color(1f, 1f, 1f, alpha);
		}

		public Vector3 GetPositionFor(ScreenStack.MotorwaysScreen screen)
		{
			foreach (MenuScreenNode menuPosition in menuPositions)
			{
				if (menuPosition.screen == screen)
				{
					return menuPosition.transform.position;
				}
			}
			Diagnostics.FailAssert("A MenuScreenNode hasn't been set up for type {0}! Please set one up in the MenuDefinition prefab.", screen);
			return Vector3.zero;
		}

		public float GetZoomFor(ScreenStack.MotorwaysScreen screen)
		{
			foreach (MenuScreenNode menuPosition in menuPositions)
			{
				if (menuPosition.screen == screen)
				{
					return menuPosition.zoom;
				}
			}
			Diagnostics.FailAssert("A MenuScreenNode hasn't been set up for type {0}! Please set one up in the MenuDefinition prefab. Defaulting to 15 zoom.", screen);
			return 15f;
		}

		public bool IsInGameScreen(ScreenStack.MotorwaysScreen screen)
		{
			foreach (MenuScreenNode menuPosition in menuPositions)
			{
				if (menuPosition.screen == screen)
				{
					return menuPosition.IsInGameScreen;
				}
			}
			return false;
		}

		public Quaternion GetRotationFor(ScreenStack.MotorwaysScreen screen)
		{
			foreach (MenuScreenNode menuPosition in menuPositions)
			{
				if (menuPosition.screen == screen)
				{
					return menuPosition.transform.rotation;
				}
			}
			Diagnostics.FailAssert("A MenuScreenNode hasn't been set up for type {0}! Please set one up in the MenuDefinition prefab.", screen);
			return Quaternion.identity;
		}

		public MenuScreenNode GetNodeForScreenType(ScreenStack.MotorwaysScreen screen)
		{
			foreach (MenuScreenNode menuPosition in menuPositions)
			{
				if (menuPosition.screen == screen)
				{
					return menuPosition;
				}
			}
			return null;
		}

		public bool TransitionExists(ScreenStack.MotorwaysScreen start, ScreenStack.MotorwaysScreen end)
		{
			return GetNodeForScreenType(start).GetTransitionFor(end) != null;
		}

		public NodeConnection GetConnectionFrom(ScreenStack.MotorwaysScreen start, ScreenStack.MotorwaysScreen end)
		{
			MenuScreenNode nodeForScreenType = GetNodeForScreenType(start);
			MenuScreenNode.Transition transitionFor = nodeForScreenType.GetTransitionFor(end);
			if (transitionFor == null && (start == ScreenStack.MotorwaysScreen.None || end == ScreenStack.MotorwaysScreen.None))
			{
				return new NodeConnection
				{
					startNode = GetNodeForScreenType(start),
					endNode = GetNodeForScreenType(end)
				};
			}
			if (Diagnostics.Verify(transitionFor != null, "{0} does not have a transition to {1}! Add one to the `{2}` prefab", start, end, base.name))
			{
				return new NodeConnection
				{
					startNode = nodeForScreenType,
					entryHandle = transitionFor.entryHandle,
					exitHandle = transitionFor.exitHandle,
					endNode = transitionFor.endNode,
					duration = transitionFor.duration,
					cameraControl = transitionFor.cameraControl
				};
			}
			Diagnostics.FailAssert("There is no transitions from {0} to {1}, please add one in the `{2}` prefab.", start, end, base.name);
			return default(NodeConnection);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}
	}
}
