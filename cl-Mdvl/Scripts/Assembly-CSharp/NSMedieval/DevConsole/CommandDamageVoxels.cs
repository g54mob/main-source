using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Model.MapNew;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandDamageVoxels : ConsoleCommand
	{
		private bool active;

		private Ray ray;

		private RaycastHit hit;

		private GameObject sphere;

		private float damageVoxelRadius = 3f;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandDamageVoxels()
		{
			Command = "damageVoxel";
			Description = "Damage voxels around the cursor in a range.";
			Help = "Damage voxels around the cursor in a range.";
		}

		private void CommandMethod()
		{
			CheckInit();
			if (active)
			{
				sphere.SetActive(value: false);
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.TickEvent -= OnTick;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("DamageVoxel <color=red>disabled!</color>", ConsoleMessageType.Warning);
			}
			else
			{
				if (!active)
				{
					sphere.SetActive(value: true);
					active = true;
					MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
					MonoSingleton<DebugInputController>.Instance.TickEvent += OnTick;
				}
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("DamageVoxel Mode <color=lime>activated</color>!", ConsoleMessageType.Warning);
			}
		}

		private void OnTick(float dt)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out hit))
			{
				return;
			}
			Vec3Int vec3Int = hit.point.ToGridVec3Int(0.01f);
			if (GridDataIndexTools.InRange(vec3Int) && GridDataIndexTools.InRange(vec3Int.x, vec3Int.y - 1, vec3Int.z) && GridDataIndexTools.InRange(vec3Int.x, vec3Int.y + 1, vec3Int.z))
			{
				MapNode node = VillageManager.ActiveVillage.Map.GetNode(vec3Int.x, vec3Int.y - 1, vec3Int.z);
				VoxelType voxelType = node.VoxelType;
				string text = ((voxelType != null) ? ("(" + node.Health + " / " + voxelType.Health + ")") : string.Empty);
				List<string> list = new List<string>();
				Vec3Int vec3Int2 = vec3Int;
				list.Add("Position: " + vec3Int2.ToString());
				list.Add("Health: " + text);
				List<string> textLines = list;
				if (Input.GetMouseButton(0))
				{
					MonoSingleton<GroundManager>.Instance.DamageVoxel(hit.point, 100, 5f, 1f);
				}
				MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(textLines);
			}
			PositionSphere(vec3Int);
		}

		private void PositionSphere(Vec3Int gridPosition)
		{
			sphere.transform.position = new Vector3(gridPosition.x, gridPosition.y * World.MapBlockHeight, gridPosition.z);
			sphere.transform.localScale = Vector3.one * 2f * damageVoxelRadius;
		}

		private void CheckInit()
		{
			if (sphere == null)
			{
				sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				sphere.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				Object.Destroy(sphere.GetComponent<SphereCollider>());
			}
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod();
		}

		private void OnRightMouseDown()
		{
			CommandMethod();
		}
	}
}
