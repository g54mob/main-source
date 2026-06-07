using System.Collections;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Boat")]
public class BoatCursorProperties : BuildableCursorProperties
{
	[SerializeField]
	private float _snappingDistance = 10f;

	private BoatPreview _boatPreview;

	private Boat _boat;

	public override void Activate()
	{
		base.Activate();
		_boatPreview = new BoatPreview(_buildable, _previewSettings, _visualIndex);
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
		bool flag = _boatPreview.ClosestMooringPoint != null && Community.PlayerCommunity.IsThereAMooringPointFree();
		_boatPreview.SetValid(flag);
		if (flag)
		{
			bool flag2 = ResourceManager.AreCommunityResourcesAvailable(_buildable.Properties.RequiredResources);
			_boatPreview.SetValid(flag2);
			if (flag2 && !EventSystem.current.IsPointerOverGameObject() && GetInteract() && BuildingDevTools.TryAutoSpawnResources(_buildable.Properties.RequiredResources))
			{
				Vector3 position = _boatPreview.Transform.transform.position;
				Quaternion rotation = _boatPreview.Transform.transform.rotation;
				Boat component = Buildable.Place(_buildable, position, rotation, _visualIndex, BuildingDevTools.InstantBuild).GetComponent<Boat>();
				_boatPreview.ClosestMooringPoint.LinkBoat(component);
				cursor.StartCoroutine(MoorBoat(_boatPreview.ClosestMooringPoint, component));
				cursor.Deactivate();
			}
		}
		static IEnumerator MoorBoat(MooringPoint mooringPoint, Boat boat)
		{
			yield return 0;
			mooringPoint.MoorBoat(boat);
		}
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
		if (mooringPoint == null || Vector3.Distance(mooringPoint.MooringTransform.position, position) > _snappingDistance)
		{
			return false;
		}
		preview.ClosestMooringPoint = mooringPoint;
		return true;
	}
}
