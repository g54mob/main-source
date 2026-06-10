using System.Linq;
using System.Text;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.UI;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class DevVoxelInfoController : MonoSingleton<DevVoxelInfoController>
	{
		[SerializeField]
		private KeyCode offsetCtrlKey = KeyCode.LeftControl;

		[SerializeField]
		private KeyCode offsetUpKey = KeyCode.T;

		[SerializeField]
		private KeyCode offsetDownKey = KeyCode.G;

		[SerializeField]
		private KeyCode toggleInputKey = KeyCode.Y;

		[SerializeField]
		private KeyCode copyAllToClipboardKey = KeyCode.H;

		private Ray ray;

		private RaycastHit hit;

		private LayerMask layerMask;

		private Vector3 lastHitPoint = Vector3.zero;

		private Vec3Int hoverGridPosition = Vec3Int.zero;

		private DevVoxelInfo voxelInfo;

		private Vec3Int gridOffset = Vec3Int.zero;

		private bool updateInput = true;

		private bool isEnabled;

		private SelectableObject prevHoverObject;

		public Vector3 LastHitPoint => lastHitPoint;

		public Vec3Int GridOffset => gridOffset;

		public KeyCode OffsetCtrlKey => offsetCtrlKey;

		public KeyCode OffsetUpKey => offsetUpKey;

		public KeyCode OffsetDownKey => offsetDownKey;

		public KeyCode ToggleInputKey => toggleInputKey;

		public KeyCode CopyAllToClipboardKey => copyAllToClipboardKey;

		private void Start()
		{
			voxelInfo = new DevVoxelInfo();
			layerMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("BuildableSurface")) | (1 << LayerMask.NameToLayer("RaycastPlaneHelper"));
		}

		private void Update()
		{
			if (!isEnabled || !MonoSingleton<World>.IsInstantiated() || !MonoSingleton<InputManager>.Instance.InputEnabled)
			{
				return;
			}
			if (Input.GetKey(offsetCtrlKey))
			{
				if (updateInput)
				{
					if (Input.GetKeyDown(offsetUpKey))
					{
						gridOffset += Vec3Int.up;
					}
					else if (Input.GetKeyDown(offsetDownKey))
					{
						gridOffset -= Vec3Int.up;
					}
				}
				if (Input.GetKeyDown(toggleInputKey))
				{
					ToggleInput();
				}
				if (Input.GetKeyDown(copyAllToClipboardKey))
				{
					CopyVoxelInfoToClipboard();
				}
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (updateInput && Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask))
			{
				Vector3 worldPosition = (lastHitPoint = hit.point - hit.normal * 0.1f);
				worldPosition += Vector3.down * ((float)World.MapBlockHeight * 0.4f);
				Vec3Int rhs = GridUtils.GetGridPosition(worldPosition, 0.01f) + gridOffset;
				SelectableObject mouseHoverObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
				if (hoverGridPosition != rhs || mouseHoverObject != prevHoverObject)
				{
					hoverGridPosition = rhs;
					voxelInfo.GatherVoxelInfo(rhs, hit.point);
					MonoSingleton<DevVoxelInfoView>.Instance.HoverGridPositionChanged(voxelInfo);
					prevHoverObject = mouseHoverObject;
				}
			}
		}

		private void CopyVoxelInfoToClipboard()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < voxelInfo.Info.Count(); i++)
			{
				if (!voxelInfo.IsInfoLine[i])
				{
					stringBuilder.AppendLine(voxelInfo.Info[i]);
				}
			}
			GUIUtility.systemCopyBuffer = stringBuilder.ToString();
		}

		private void ToggleInput()
		{
			updateInput = !updateInput;
		}

		public void SetEnabled(bool active)
		{
			if (active != isEnabled)
			{
				MonoSingleton<DevVoxelInfoView>.Instance.ToggleDevVoxelInfoEvent(active);
			}
			isEnabled = active;
		}
	}
}
