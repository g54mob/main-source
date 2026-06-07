using UnityEngine;
using UnityEngine.UI;

public class CModSettings : MonoBehaviour
{
	public GameObject settingsRowContainer;

	public Toggle addToEditMenuToggle;

	public InputField menuInputField;

	public InspectorBool us_enemy;

	public InspectorBool us_impervious;

	public InspectorInt us_width;

	public InspectorInt us_length;

	public InspectorFloat us_height;

	public InspectorInt us_buildCost;

	public InspectorChoice us_buildWare;

	public InspectorFloat us_health;

	public InspectorBool us_movable;

	public InspectorBool us_canSpecifyTarget;

	public InspectorBool us_moveIgnoreLand;

	public InspectorBool us_onlyOnResource;

	public InspectorBool us_avoidContaminant;

	public InspectorBool us_destroyOnUnevenTerrain;

	public InspectorBool us_occupiesLand;

	public InspectorBool us_damagedByCreeper;

	public InspectorBool us_damagedByAntiCreeper;

	public InspectorBool us_creeperDamagesOnlyOnHeight;

	public InspectorBool us_connectable;

	public InspectorVector3 us_connectOffset;

	public InspectorBool us_requestPackets;

	public InspectorBool us_canPassPackets;

	public InspectorBool us_prebuilt;

	public InspectorInt us_stopsCreeper;

	public InspectorBool us_canStun;

	public InspectorVector3 us_targetMeOffset;

	public InspectorInt us_specialTarget;

	public InspectorBool us_canNullify;

	public InspectorBool us_canERN;

	public InspectorString us_editMenuName;

	public InspectorString us_playerMenuName;

	public InspectorChoice us_playerMenu;

	public InspectorBool us_selectable;

	public InspectorBool us_canRotate;

	public InspectorBool us_playerCanDestroy;

	public InspectorBool us_shakeCameraOnDestroy;

	public InspectorBool us_autoCollider;

	public InspectorVector3 us_colliderSize;

	public InspectorVector3 us_colliderCenter;

	public InspectorBool us_hasBuildBar;

	public InspectorVector3 us_buildBarOffset;

	public InspectorBool us_hasHealthBar;

	public InspectorVector3 us_healthBarOffset;

	public InspectorBool us_hasAmmoBar;

	public InspectorVector3 us_ammoBarOffset;

	public InspectorBool us_dragSelectable;

	public InspectorBool us_logDestroy;

	public InspectorBool us_includeInGameRecorder;

	public InspectorString us_destroyedSound;

	public InspectorString us_destroyedExplosion;

	public InspectorVector3 us_destroyedExplosionScale;

	public InspectorString us_popup0;

	public InspectorString us_popup1;

	public InspectorInt us_range;

	public InspectorFloat us_losTerrainHeightMod;

	public InspectorFloat us_maxAmmo;

	public InspectorChoice us_ammoWare;

	public InspectorBool us_canRequestAmmo;

	public InspectorVector3 us_fireOffset;

	public InspectorFloat us_ezRangeBoost;

	public InspectorFloat us_upgradeRangeBoost;

	public InspectorBool us_losEnabled;

	public InspectorBool us_losAlwaysShow;

	public InspectorBool us_losIgnoreTerrain;

	public InspectorBool us_losIndirect;

	public InspectorFloat us_losIndirectHeightOffset;

	public InspectorFloat us_losTargetHeightOffset;

	public void UpdatePreview()
	{
	}

	public void Refresh()
	{
	}

	public void OnApply()
	{
	}
}
