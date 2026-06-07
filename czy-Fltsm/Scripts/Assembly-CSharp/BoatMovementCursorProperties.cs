using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Boat Movement")]
public class BoatMovementCursorProperties : BuildableCursorProperties
{
	[SerializeField]
	private float _snappingDistance = 10f;

	private BoatPreview _boatPreview;

	private Boat _boat;

	public override void Activate()
	{
		base.Activate();
		_boatPreview = CreateBoatPreview(_buildable, _visualIndex);
		_boat = _buildable.GetComponent<Boat>();
		if (_boat == null)
		{
			Debugger.Error($"Passed a buildable to {base.name} that does not have a boat component.");
		}
		GameManager.UIManager.ShowFreeMooringPointIcon(show: true);
	}

	public override void DeactivateImmediately()
	{
		base.DeactivateImmediately();
		GameManager.UIManager.ShowFreeMooringPointIcon(show: false);
		_boatPreview.Destroy();
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		UpdateTransform(_boatPreview, CursorManager.BuildingPosition);
		bool flag = _boatPreview.ClosestMooringPoint != null;
		_boatPreview.SetValid(flag);
		if (flag && !EventSystem.current.IsPointerOverGameObject() && GetInteract())
		{
			if (_boat.TownMooringPoint != null)
			{
				_boat.TownMooringPoint.UnlinkBoat(_boat);
			}
			_boatPreview.ClosestMooringPoint.LinkBoat(_boat);
			Project project = new Project(GameManager.Settings.ProjectSettings.MooringProperties, _boat.gameObject);
			Community.PlayerCommunity.QueueProject(project);
			cursor.Deactivate();
		}
	}

	private BoatPreview CreateBoatPreview(Buildable buildable, int visualIndex)
	{
		return new BoatPreview(buildable, _previewSettings, visualIndex);
	}

	private void UpdateTransform(BoatPreview preview, Vector3 inputPosition)
	{
		Quaternion rotation = Quaternion.identity;
		Vector3 inputPosition2 = inputPosition;
		if (UpdateClosestMooringPoint(preview, inputPosition))
		{
			rotation = preview.ClosestMooringPoint.transform.rotation;
			inputPosition2 = preview.ClosestMooringPoint.ReturnBoatPosition(_boat.MooringOffset, inputPosition);
		}
		preview.Transform.transform.rotation = rotation;
		preview.Transform.transform.position = WorldManager.WaterAdjustedPosition(inputPosition2);
	}

	private bool UpdateClosestMooringPoint(BoatPreview preview, Vector3 position)
	{
		preview.ClosestMooringPoint = null;
		MooringPoint mooringPoint = Community.PlayerCommunity.ReturnClosestAvailableMooringPoint(position);
		if (mooringPoint == null)
		{
			return false;
		}
		if (mooringPoint.LinkedBoat == _boat)
		{
			return false;
		}
		if (Vector3.Distance(mooringPoint.MooringTransform.position, position) > _snappingDistance)
		{
			return false;
		}
		preview.ClosestMooringPoint = mooringPoint;
		return true;
	}
}
