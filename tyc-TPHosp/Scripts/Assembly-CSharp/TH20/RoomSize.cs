using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomSize : MonoBehaviour
	{
		[SerializeField]
		private InWorldHUDElement _roomSizeWidth;

		[SerializeField]
		private InWorldHUDElement _roomSizeHeight;

		[SerializeField]
		private GameObject _measurementPrefab;

		[SerializeField]
		private TMP_Text _roomSizeWidthText;

		[SerializeField]
		private TMP_Text _roomSizeHeightText;

		private HUD _hud;

		private FloorPlan _floorPlan;

		private const int NumLines = 4;

		private RoomSizeMeasurement[] _measurements = new RoomSizeMeasurement[4];

		public void Initialise(HUD hud, FloorPlan floorPlan)
		{
			_hud = hud;
			_floorPlan = floorPlan;
			_hud.AddElement(_roomSizeWidth);
			_hud.AddElement(_roomSizeHeight);
			_roomSizeWidth.gameObject.SetActive(value: false);
			_roomSizeHeight.gameObject.SetActive(value: false);
			for (int i = 0; i < 4; i++)
			{
				GameObject gameObject = Object.Instantiate(_measurementPrefab);
				_measurements[i] = gameObject.GetComponent<RoomSizeMeasurement>();
				gameObject.SetActive(value: false);
			}
		}

		private void OnDestroy()
		{
			if (_roomSizeWidth != null && _roomSizeHeight != null)
			{
				_hud.RemoveElement(_roomSizeWidth);
				_hud.RemoveElement(_roomSizeHeight);
				Object.Destroy(_roomSizeWidth.gameObject);
				Object.Destroy(_roomSizeHeight.gameObject);
				for (int i = 0; i < 4; i++)
				{
					Object.Destroy(_measurements[i].gameObject);
				}
				_roomSizeWidth = null;
				_roomSizeHeight = null;
			}
		}

		private Vector3 GetCorner(ref Vector3[] corners, int index)
		{
			return corners[index & 3];
		}

		private void Update()
		{
			if (_floorPlan != null)
			{
				int lhs = _floorPlan.Width();
				int rhs = _floorPlan.Height();
				int num = (int)Camera.main.gameObject.transform.rotation.eulerAngles.y / 90;
				Vector3 anchorWorldPos = _floorPlan.GetAnchorWorldPos();
				Vector3 vector = new Vector3((float)(lhs - 1) * 2f, 0f, (float)(rhs - 1) * 2f);
				Vector3 vector2 = anchorWorldPos + vector;
				if ((num & 1) != 0)
				{
					MathUtils.Swap(ref lhs, ref rhs);
				}
				anchorWorldPos -= MathUtils.XZPlane * 2f * 0.8f;
				vector2 += MathUtils.XZPlane * 2f * 0.8f;
				Vector3[] corners = new Vector3[4]
				{
					new Vector3(vector2.x, 0f, anchorWorldPos.z),
					anchorWorldPos,
					new Vector3(anchorWorldPos.x, 0f, vector2.z),
					vector2
				};
				Vector3 corner = GetCorner(ref corners, num);
				Vector3 corner2 = GetCorner(ref corners, num + 1);
				Vector3 corner3 = GetCorner(ref corners, num + 2);
				Vector3 vector3 = (corner + corner2) * 0.5f;
				Vector3 vector4 = (corner2 + corner3) * 0.5f;
				_roomSizeWidth.Position = vector3;
				_roomSizeHeight.Position = vector4;
				_roomSizeWidthText.text = lhs.ToString();
				_roomSizeHeightText.text = rhs.ToString();
				SetArrow(_measurements[0], vector3, corner);
				SetArrow(_measurements[1], vector3, corner2);
				SetArrow(_measurements[2], vector4, corner2);
				SetArrow(_measurements[3], vector4, corner3);
				GameObjectUtils.SetActive(_roomSizeWidth.gameObject, isActive: true);
				GameObjectUtils.SetActive(_roomSizeHeight.gameObject, isActive: true);
			}
		}

		private void SetArrow(RoomSizeMeasurement measurement, Vector3 start, Vector3 end)
		{
			Vector3 normalized = (end - start).normalized;
			start += normalized * 0.5f;
			end -= normalized * 1f;
			measurement.SetPosition(start, end);
			GameObjectUtils.SetActive(measurement.gameObject, isActive: true);
		}
	}
}
