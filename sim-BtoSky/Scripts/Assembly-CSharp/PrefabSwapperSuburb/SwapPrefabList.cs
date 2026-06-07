using System;
using UnityEngine;

namespace PrefabSwapperSuburb
{
	public class SwapPrefabList : ScriptableObject
	{
		[Serializable]
		public class SwapPrefabProperties
		{
			public string prefabName;

			public string category;

			public string[] addAdditional;

			public string[] addAdditionalButtonName;

			public Vector3[] addAdditionalPos;

			public Vector3[] addAdditionalRot;

			public SwapPrefabProperties(string _PrefabName, string _Category, string[] _AddAdditional, string[] _AddAdditionalButtonName, Vector3[] _AddAdditionalPos, Vector3[] _AddAdditionalRot)
			{
				prefabName = _PrefabName;
				category = _Category;
				addAdditional = _AddAdditional;
				addAdditionalButtonName = _AddAdditionalButtonName;
				addAdditionalPos = _AddAdditionalPos;
				addAdditionalRot = _AddAdditionalRot;
			}
		}

		public static string[] prefabsFolders = new string[3] { "Assets/SuburbNeighborhoodHousePack/Prefabs/Building", "Assets/SuburbNeighborhoodHousePack/Prefabs/Ground", "Assets/SuburbNeighborhoodHousePack/Prefabs/Doors" };

		public static SwapPrefabProperties[] swapPrefabProperties = new SwapPrefabProperties[177]
		{
			new SwapPrefabProperties("Wall_1st_½x", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_1x", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_1x_door", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_2x", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_door_A", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_door_B", "Walls 1st", new string[1] { "Window_blocker_door_B" }, new string[1] { "Window_blocker" }, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_door_C", "Walls 1st", new string[1] { "Window_blocker_door_C" }, new string[1] { "Window_blocker" }, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_bay_A", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.7f, 0.35f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_bay_B", "Walls 1st", new string[1] { "Window_blocker_window_bay_B" }, new string[1] { "Window_blocker" }, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_double_A", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.7f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_double_B", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.7f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_openable", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.7f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_single_A", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.7f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_single_B", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.7f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_single_C", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.7f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_3x_window_single_D", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_4x_door_garage", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_4x_window_double", "Walls 1st", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-2f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_5x_door_garage", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_corner_in", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_corner_in_patch", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_corner_out", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_1st_corner_out_patch", "Walls 1st", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_½x", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_1x", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_2x", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x_window_double_A", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x_window_double_B", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x_window_openable", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x_window_single_A", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x_window_single_B", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x_window_single_C", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_3x_window_single_D", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-1.5f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_4x_window_double", "Walls 2nd", new string[2] { "Window_blocker_curtains", "Window_blocker_blinds" }, new string[0], new Vector3[1]
			{
				new Vector3(-2f, 1.8f, -0.15f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_corner_in", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_corner_in_patch", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_corner_out", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_2nd_corner_out_patch", "Walls 2nd", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_½x", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_½x_end", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_1x", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_1x_door", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_1x_door_clothcloset", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_1x_end", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_2x", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_2x_door_double", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_3x", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_3x_door", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_3x_end", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_3x_end", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_5x_door", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_6x_fireplace", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_8x_door", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_column_half", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_corner", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_corner_out_patch", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_corner_T", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_halfheight_1x", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_halfheight_2x", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_halfheight_3x", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Wall_Interior_halfheight_pilar", "Walls Interior", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Stairs_main_L", "Stairs", new string[2] { "Floor_stairs_5x_3x", "Floor_stairs_5x_4x" }, new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Stairs_main_R", "Stairs", new string[2] { "Floor_stairs_5x_3x", "Floor_stairs_5x_4x" }, new string[0], new Vector3[1]
			{
				new Vector3(-5f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Stairs_basement", "Stairs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_½x_5x", "Floors", new string[1] { "Ceiling_½x_5x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_½x_7x", "Floors", new string[1] { "Ceiling_½x_7x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_½x_8x", "Floors", new string[1] { "Ceiling_½x_8x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_1x_3x", "Floors", new string[1] { "Ceiling_1x_3x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_1x_5x", "Floors", new string[1] { "Ceiling_1x_5x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_1x_7x", "Floors", new string[1] { "Ceiling_1x_7x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_1x_8x", "Floors", new string[1] { "Ceiling_1x_8x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_2x_2x", "Floors", new string[1] { "Ceiling_2x_2x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_2½x_2½x", "Floors", new string[1] { "Ceiling_2½x_2½x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_½x", "Floors", new string[1] { "Ceiling_3x_½x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_1x", "Floors", new string[1] { "Ceiling_3x_1x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_2x", "Floors", new string[1] { "Ceiling_3x_2x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_3x", "Floors", new string[1] { "Ceiling_3x_3x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_4x", "Floors", new string[1] { "Ceiling_3x_4x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_5x", "Floors", new string[1] { "Ceiling_3x_5x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_7x", "Floors", new string[1] { "Ceiling_3x_7x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_3x_8x", "Floors", new string[1] { "Ceiling_3x_8x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_4x_3x", "Floors", new string[1] { "Ceiling_4x_3x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_5x_3x", "Floors", new string[1] { "Ceiling_5x_3x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_5x_5x", "Floors", new string[1] { "Ceiling_5x_5x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Floor_12x_8x", "Floors", new string[1] { "Ceiling_12x_8x" }, new string[1] { "Ceiling" }, new Vector3[1]
			{
				new Vector3(0f, 3f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_½x_5x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_½x_7x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_½x_8x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_1x_3x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_1x_5x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_1x_7x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_1x_8x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_2x_2x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_2½x_2½x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_½x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_1x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_2x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_3x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_4x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_5x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_7x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_3x_8x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_4x_3x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_5x_3x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_5x_5x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ceiling_12x_8x", "Ceilings", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_5x", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_5x_end", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-5f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-5f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("Roof_5x_end_window", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-5f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-5f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("Roof_5x_patch", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_7x", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_7x_end", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-7f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-7f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("Roof_7x_end_window", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-7f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-7f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("Roof_7x_patch", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_8x", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_8x_corner", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_8x_end", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-8f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-8f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("Roof_8x_end_window", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-8f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-8f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("Roof_8x_patch", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_5x", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_5x_end", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-5f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-5f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_5x_patch", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_7x", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_7x_end", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-7f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-7f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_7x_patch", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_8x", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_8x_end", "Roofs", new string[4] { "Drainpipe_1story", "Drainpipe_1story", "Drainpipe_2story", "Drainpipe_2story" }, new string[4] { "Drainpipe 1story L", "Drainpipe 1story R", "Drainpipe 2story L", "Drainpipe 2story R" }, new Vector3[4]
			{
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-8f, 0f, 0f),
				new Vector3(0f, 0f, -0.5f),
				new Vector3(-8f, 0f, 0f)
			}, new Vector3[4]
			{
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f),
				new Vector3(0f, 90f, 0f),
				new Vector3(0f, -90f, 0f)
			}),
			new SwapPrefabProperties("RoofLow_8x_patch", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_extra_window_double", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Roof_extra_window_single", "Roofs", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_2x", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_2x_end_left", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_2x_end_right", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_4x", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_4x_end_left", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_4x_end_right", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_floor_1x_2x", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_floor_3x_2x", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_pilar", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_rail_1x", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_rail_1½x", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Porch_rail_2x", "Porch", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_1x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_4x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_4x_walkway", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_4x_walkway_double", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_8x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_8x_driveway", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_circle", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_corner_in", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_corner_out", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_end", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_parking_lot", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_garageramp_3x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_garageramp_5x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_driveway_piece", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Road_walkway_piece", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_1x4x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_2x4x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_2x8x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_4x8x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_8x8x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_20x20x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_45x45x", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_pool_4x8x_A", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Ground_pool_4x8x_B", "Ground", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_exterior_paneled", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_exterior_white", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_exterior_windowed", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_exterior_windowed_brown", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_interior", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_garage_3x", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_garage_brown_3x", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_garage_5x", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}),
			new SwapPrefabProperties("Door_garage_brown_5x", "Doors", new string[0], new string[0], new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			}, new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			})
		};
	}
}
