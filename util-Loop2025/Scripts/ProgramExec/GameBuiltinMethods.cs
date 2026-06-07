// LABELED DIFF FOR GameBuiltinMethods.cs
// Replace the entire file with this updated version

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GptDeepResearch
{
	/*
        New system: Each scene provides a GameControllerBase implementation
        that registers scene-specific commands with this system
    */

	// REMOVE: Old IGameController interface - replaced with GameControllerBase

	// Add this class to handle built-in game functions
	public static class GameBuiltinMethods
	{
		// MODIFY: Replace gameController with scene-specific controller
		private static GameControllerBase sceneController;

		// ADD: Registration method for scene controllers
		public static void RegisterGameController(GameControllerBase controller)
		{
			sceneController = controller;
		}

		// ADD: Unregistration method
		public static void UnregisterGameController()
		{
			sceneController = null;
		}

		// ADD: Get current scene controller
		public static GameControllerBase GetCurrentController()
		{
			return sceneController;
		}

		// Update ExecuteBuiltinFunction method to handle coordinate normalization (around line 40):
		// replace GameBuiltinMethods.cs ExecuteBuiltinFunction method entirely:
		public static IEnumerator ExecuteBuiltinFunction(string functionName, object[] args, Action<object> setValue)
		{
			// Handle v2() builtin function - no try-catch needed
			if (functionName == "v2")
			{
				if (args.Length != 2)
					throw new Exception($"v2() takes exactly 2 arguments ({args.Length} given)");
				double x = NumericHelpers.ToDouble(args[0]);
				double y = NumericHelpers.ToDouble(args[1]);
				setValue(new V2Value(x, y));
				yield break;
			}

			// Pre-validate and normalize coordinates - let exceptions bubble up naturally
			(double x, double y) coords = (0, 0);
			bool needsCoordNormalization = false;

			// Determine if this function needs coordinate normalization
			switch (functionName.ToLower())
			{
				case "move":
				case "move_0":
				case "is_block":
				case "is_goal":
				case "can_move":
				case "can_move_0":
					needsCoordNormalization = true;
					break;
			}

			// Do coordinate normalization - let exceptions throw naturally
			if (needsCoordNormalization)
			{
				coords = CoordinateHelpers.NormalizeToXY(args);
			}

			// Handle coordinate-based functions with pre-normalized coordinates
			// NO TRY-CATCH around any yield statements
			switch (functionName.ToLower())
			{
				// Movement functions - use pre-normalized coordinates
				case "move":
				case "move_0":
					if (sceneController == null)
						throw new Exception($"No scene controller registered for function '{functionName}'");
					yield return HandleSceneCommand(functionName, new object[] { coords.x, coords.y }, setValue);
					break;

				// Position check functions - use pre-normalized coordinates  
				case "is_block":
				case "is_goal":
				case "can_move":
				case "can_move_0":
					if (sceneController == null)
						throw new Exception($"No scene controller registered for function '{functionName}'");
					yield return HandleSceneCommand(functionName, new object[] { coords.x, coords.y }, setValue);
					break;

				// Zero-argument functions that return V2Value
				case "get_pos":
				case "get_pos_0":
				case "get_goal":
				case "get_goal_0":
					if (sceneController != null)
					{
						// These should return V2Value instead of separate x,y
						yield return HandleSceneCommandReturnV2(functionName, args, setValue);
					}
					else
					{
						// Fallback for when no scene controller
						setValue(new V2Value(0, 0));
					}
					break;

				// Legacy functions that return single values
				case "get_pos_x":
				case "get_pos_y":
				case "inventory_count_0":
					if (sceneController != null)
					{
						yield return HandleSceneCommand(functionName, args, setValue);
					}
					else
					{
						setValue(0.0);
					}
					break;

				default:
					// Check if it's a scene-specific command
					if (sceneController != null && sceneController.HasCommand(functionName))
					{
						yield return HandleSceneCommand(functionName, args, setValue);
					}
					else
					{
						throw new Exception($"Unknown built-in function '{functionName}'");
					}
					break;
			}
		}

		// FIXED: Updated method to handle scene commands with new predicate signature
		// MODIFY HandleSceneCommand method (around line 70):
		private static IEnumerator HandleSceneCommand(string functionName, object[] args, Action<object> setValue)
		{
			if (sceneController == null)
			{
				throw new Exception($"No scene controller registered for function '{functionName}'");
			}

			// Check command type and execute accordingly
			if (sceneController.actionCommands.ContainsKey(functionName))
			{
				// Action command (no return value)
				yield return sceneController.ExecuteActionCommand(functionName, args);
				setValue(null);
			}
			else if (sceneController.predicateCommands.ContainsKey(functionName))
			{
				// Predicate command (returns bool)
				bool result = false;
				bool resultReceived = false;

				// Execute the predicate command with callback
				yield return sceneController.ExecutePredicateCommand(functionName, args, (bool predicateResult) =>
				{
					result = predicateResult;
					resultReceived = true;
				});

				// Wait for result if needed
				while (!resultReceived)
				{
					yield return null;
				}

				setValue(result);
			}
			// ADD: Handle value getter commands
			else if (sceneController.valueGetterCommands.ContainsKey(functionName))
			{
				// Value getter command (returns immediately)
				object result = sceneController.ExecuteValueGetterCommand(functionName, args);
				setValue(result);
			}
			else
			{
				throw new Exception($"Function '{functionName}' not found in scene controller");
			}
		}

		// Add new method to handle functions that should return V2Value:
		private static IEnumerator HandleSceneCommandReturnV2(string functionName, object[] args, Action<object> setValue)
		{
			if (sceneController == null)
			{
				throw new Exception($"No scene controller registered for function '{functionName}'");
			}

			// Check if it's a value getter that returns coordinates
			if (sceneController.valueGetterCommands.ContainsKey(functionName))
			{
				object result = sceneController.ExecuteValueGetterCommand(functionName, args);

				// Convert result to V2Value if it's coordinate data
				if (result is UnityEngine.Vector2 unityV2)
				{
					setValue(new V2Value(unityV2.x, unityV2.y));
				}
				else if (result is List<object> list && list.Count == 2)
				{
					double x = NumericHelpers.ToDouble(list[0]);
					double y = NumericHelpers.ToDouble(list[1]);
					setValue(new V2Value(x, y));
				}
				else
				{
					// Return as-is for non-coordinate data
					setValue(result);
				}
			}
			else
			{
				// Fall back to regular scene command handling
				yield return HandleSceneCommand(functionName, args, setValue);
			}
		}

		// In the IsBuiltinFunction method, add cases for get_pos and get_goal:
		public static bool IsBuiltinFunction(string functionName)
		{
			// Check both built-in and scene-specific functions
			switch (functionName.ToLower())
			{
				// Legacy built-ins
				case "move_0":
				case "collect_0":
				case "plant_0":
				case "can_move_0":
				case "inventory_count_0":
					return true;
				// Add case for v2:
				case "v2":
					return true;
				default:
					// Check scene controller
					return sceneController != null && sceneController.HasCommand(functionName);
			}
		}

		// ADD: Get all available commands for syntax highlighting
		public static System.Collections.Generic.List<string> GetAllAvailableCommands()
		{
			var commands = new System.Collections.Generic.List<string>();

			// Add legacy commands
			commands.AddRange(new[] { "move_0", "collect_0", "plant_0", "can_move_0", "inventory_count_0" });

			// Add scene-specific commands
			if (sceneController != null)
			{
				commands.AddRange(sceneController.GetAllCommandNames());
			}

			return commands;
		}

		// ADD: Scene reset functionality
		public static IEnumerator ResetScene()
		{
			if (sceneController != null)
			{
				yield return sceneController.SceneReset();
			}
		}
	}
}