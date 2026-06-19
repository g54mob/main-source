#define PUG_ACHIEVEMENTS
using System;
using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MapMarkerUIElement : UIelement
{
	public MapMarkerType markerType;

	public UserMapMarkerType userMarkerType;

	public LocalizedString hoverString;

	public PlayerController player;

	public Entity mapMarkerEntity;

	public SpriteRenderer colorIcon;

	public SpriteRenderer miniMapColorIcon;

	public SpriteRenderer sr;

	public Sprite largeMapIcon;

	public Sprite largeMapIconInactive;

	public Sprite miniMapIcon;

	public Sprite miniMapIconInactive;

	private const string portalGoToTerm = "MapMarkers/portalGoToDesc";

	private const string portalNotReadyTerm = "MapMarkers/portalNotReadyDesc";

	private const string portalStandingAtTerm = "MapMarkers/portalStandingAtDesc";

	private const string mustBeAtPortalToTeleportTerm = "MapMarkers/mustBeAtPortalToTeleportDesc";

	private const string waypointNotReadyTerm = "MapMarkers/waypointNotReadyDesc";

	private const string waypointStandingAtTerm = "MapMarkers/waypointStandingAtDesc";

	private const string shrineTerm = "MapMarkers/ShrineDesc";

	private const string coreGuidanceTerm = "MapMarkers/TheCoreGuidance";

	public LocalizedString you = "MapMarkers/You";

	public LocalizedString deathMarkerThisPlayer = "MapMarkers/DeathMarkerThisPlayer";

	public LocalizedString nonLocalizedPlaceholder = "nonLocalizedPlaceholder";

	public List<Sprite> userMapMarkerSprites;

	public List<Sprite> userMapMarkerSmallSprites;

	public override TextAndFormatFields GetHoverTitle()
	{
		if (markerType == MapMarkerType.Ping || markerType == MapMarkerType.UserPlacedMarker)
		{
			return null;
		}
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		if (markerType == MapMarkerType.Player || markerType == MapMarkerType.PlayerGrave)
		{
			if (markerType == MapMarkerType.PlayerGrave)
			{
				if (player == null || player == Manager.main.player)
				{
					textAndFormatFields.text = deathMarkerThisPlayer.mTerm;
					textAndFormatFields.formatFields = Array.Empty<string>();
				}
				else
				{
					string playerName = player.playerName;
					textAndFormatFields.text = hoverString.mTerm;
					textAndFormatFields.formatFields = new string[1] { playerName };
				}
			}
			else
			{
				string playerName = ((!(player == null) && !(player == Manager.main.player)) ? player.playerName : ((string)you));
				textAndFormatFields.text = nonLocalizedPlaceholder.mTerm;
				textAndFormatFields.formatFields = new string[1] { playerName };
			}
			if (player != null)
			{
				textAndFormatFields.color = player.GetPlayerColor();
			}
		}
		else if (!string.IsNullOrEmpty(hoverString.mTerm))
		{
			textAndFormatFields.text = hoverString.mTerm;
		}
		return textAndFormatFields;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (mapMarkerEntity == Entity.Null)
		{
			return null;
		}
		PlayerController playerController = Manager.main.player;
		if (markerType == MapMarkerType.TitanShrine && playerController != null)
		{
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = "MapMarkers/ShrineDesc",
					color = new Color(0.886f, 0.631f, 0.173f)
				}
			};
		}
		if (markerType == MapMarkerType.CoreAttention && playerController != null)
		{
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = "MapMarkers/TheCoreGuidance",
					color = new Color(0.886f, 0.631f, 0.173f)
				}
			};
		}
		if ((markerType == MapMarkerType.Portal || markerType == MapMarkerType.Waypoint) && playerController != null)
		{
			bool flag = markerType == MapMarkerType.Waypoint;
			bool num = playerController.currentPortal != null;
			List<TextAndFormatFields> list = new List<TextAndFormatFields>();
			if (!num)
			{
				list.Add(new TextAndFormatFields
				{
					text = "MapMarkers/mustBeAtPortalToTeleportDesc",
					color = Manager.ui.brokenColor
				});
			}
			else if (playerController.currentPortal.WorldPosition.RoundToInt() == ExtensionMethods.RoundToInt(EntityUtility.GetComponentData<LocalTransform>(mapMarkerEntity, base.world).Position))
			{
				list.Add(new TextAndFormatFields
				{
					text = (flag ? "MapMarkers/waypointStandingAtDesc" : "MapMarkers/portalStandingAtDesc")
				});
			}
			else if (!MapMarkerIsActivated())
			{
				list.Add(new TextAndFormatFields
				{
					text = (flag ? "MapMarkers/waypointNotReadyDesc" : "MapMarkers/portalNotReadyDesc"),
					color = Manager.ui.brokenColor
				});
			}
			else
			{
				string[] formatFields = null;
				list.Add(new TextAndFormatFields
				{
					text = "MapMarkers/portalGoToDesc",
					color = Color.white * 0.99f,
					formatFields = formatFields,
					dontLocalizeFormatFields = true
				});
			}
			return list;
		}
		return base.GetHoverDescription();
	}

	private bool MapMarkerIsActivated()
	{
		if (EntityUtility.HasComponentData<MapMarkerActivatedCD>(mapMarkerEntity, base.world))
		{
			return EntityUtility.GetComponentData<MapMarkerActivatedCD>(mapMarkerEntity, base.world).Value;
		}
		return false;
	}

	private bool CanTeleport()
	{
		PlayerController playerController = Manager.main.player;
		if (playerController == null || playerController.currentPortal == null || !playerController.currentPortal.isActivated || !MapMarkerIsActivated())
		{
			return false;
		}
		if (!EntityUtility.HasComponentData<LocalTransform>(mapMarkerEntity, base.world))
		{
			Debug.LogError("Portal map marker entity had no position");
			return false;
		}
		Vector3Int vector3Int = playerController.currentPortal.WorldPosition.RoundToInt();
		Vector3Int vector3Int2 = ExtensionMethods.RoundToInt(EntityUtility.GetComponentData<LocalTransform>(mapMarkerEntity, base.world).Position);
		return vector3Int != vector3Int2;
	}

	private void OnEnable()
	{
		Init();
	}

	public void Init()
	{
		LateUpdate();
	}

	protected override void LateUpdate()
	{
		UpdateColor();
		if (markerType == MapMarkerType.UserPlacedMarker)
		{
			if (userMarkerType < UserMapMarkerType.Marker1 || userMarkerType > UserMapMarkerType.Marker4)
			{
				Debug.LogError($"Bad user marker type {(int)userMarkerType} in {base.name}");
			}
			else
			{
				sr.sprite = (Manager.ui.mapUI.IsShowingBigMap ? userMapMarkerSprites[(int)(userMarkerType - 2)] : userMapMarkerSmallSprites[(int)(userMarkerType - 2)]);
			}
		}
		else if (markerType == MapMarkerType.Portal || markerType == MapMarkerType.Waypoint)
		{
			bool flag = CanTeleport();
			sr.sprite = ((!flag) ? (Manager.ui.mapUI.IsShowingBigMap ? largeMapIconInactive : miniMapIconInactive) : (Manager.ui.mapUI.IsShowingBigMap ? largeMapIcon : miniMapIcon));
		}
		else if (markerType != MapMarkerType.Ping)
		{
			sr.sprite = (Manager.ui.mapUI.IsShowingBigMap ? largeMapIcon : miniMapIcon);
		}
		base.LateUpdate();
	}

	public void UpdateColor()
	{
		PlayerController playerController = ((player == null) ? Manager.main.player : player);
		if (!(playerController != null) || !(colorIcon != null))
		{
			return;
		}
		if (markerType == MapMarkerType.Ping)
		{
			sr.color = playerController.GetPlayerColor();
		}
		else if (Manager.ui.mapUI.IsShowingBigMap)
		{
			colorIcon.gameObject.SetActive(value: true);
			if (miniMapColorIcon != null)
			{
				miniMapColorIcon.gameObject.SetActive(value: false);
			}
			colorIcon.color = playerController.GetPlayerColor();
		}
		else
		{
			colorIcon.gameObject.SetActive(value: false);
			if (miniMapColorIcon != null)
			{
				miniMapColorIcon.gameObject.SetActive(value: true);
				miniMapColorIcon.color = playerController.GetPlayerColor();
			}
		}
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if ((markerType == MapMarkerType.Portal || markerType == MapMarkerType.Waypoint) && CanTeleport())
		{
			PlayerController playerController = Manager.main.player;
			playerController.currentPortal.TeleportEffects();
			float2 float5 = ((EntityUtility.GetObjectData(mapMarkerEntity, base.world).variation == 20) ? new float2(1f, 1f) : new float2(1f, -0.25f));
			playerController.QueueInputAction(new UIInputActionData
			{
				action = UIInputAction.Teleport,
				position = EntityUtility.GetComponentData<LocalTransform>(mapMarkerEntity, base.world).Position.ToFloat2() + float5
			});
			if (markerType == MapMarkerType.Waypoint || IsWaypointEntity(playerController.currentPortal.entity))
			{
				Manager.achievements.TriggerAchievement(AchievementID.UseWayPoint);
			}
			if (Manager.ui.isShowingMap)
			{
				Manager.ui.OnMapToggle();
			}
		}
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}

	private bool IsWaypointEntity(Entity entity)
	{
		return EntityUtility.HasComponentData<WayPointCD>(entity, base.world);
	}
}
