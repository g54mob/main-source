using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Data;

[Serializable]
public class DataManagerSettings
{
	private TextAsset _AchievementDataJsonAsset;

	private TextAsset _ArcanaDataJsonAsset;

	private TextAsset _CharacterDataJsonAsset;

	private TextAsset _EnemyDataJsonAsset;

	private TextAsset _HitVfxDataJsonAsset;

	private TextAsset _ItemDataJsonAsset;

	private TextAsset _LimitBreakDataJsonAsset;

	private TextAsset _MusicDataJsonAsset;

	private TextAsset _PowerUpDataJsonAsset;

	private TextAsset _PropsDataJsonAsset;

	private TextAsset _SecretsDataJsonAsset;

	private TextAsset _StageDataJsonAsset;

	private TextAsset _WeaponDataJsonAsset;

	private TextAsset _AlbumDataJsonAsset;

	private TextAsset _CustomMerchantsDataJsonAsset;

	private TextAsset _AllCPUAsset;

	private TextAsset _AdventureDataJsonAsset;

	private TextAsset _AdventuresStageSetDataJsonAsset;

	private TextAsset _AdventuresStagesJsonAsset;

	private TextAsset _AdventuresMerchantsDataJsonAsset;

	public TextAsset AchievementDataJsonAsset => _AchievementDataJsonAsset;

	public TextAsset ArcanaDataJsonAsset => _ArcanaDataJsonAsset;

	public TextAsset CharacterDataJsonAsset => _CharacterDataJsonAsset;

	public TextAsset EnemyDataJsonAsset => _EnemyDataJsonAsset;

	public TextAsset HitVfxDataJsonAsset => _HitVfxDataJsonAsset;

	public TextAsset ItemDataJsonAsset => _ItemDataJsonAsset;

	public TextAsset LimitBreakDataJsonAsset => _LimitBreakDataJsonAsset;

	public TextAsset MusicDataJsonAsset => _MusicDataJsonAsset;

	public TextAsset PowerUpDataJsonAsset => _PowerUpDataJsonAsset;

	public TextAsset PropsDataJsonAsset => _PropsDataJsonAsset;

	public TextAsset SecretsDataJsonAsset => _SecretsDataJsonAsset;

	public TextAsset StageDataJsonAsset => _StageDataJsonAsset;

	public TextAsset WeaponDataJsonAsset => _WeaponDataJsonAsset;

	public TextAsset AdventureDataJsonAsset => _AdventureDataJsonAsset;

	public TextAsset AdventuresStageSetDataJsonAsset => _AdventuresStageSetDataJsonAsset;

	public TextAsset AdventuresStagesJsonAsset => _AdventuresStagesJsonAsset;

	public TextAsset AdventuresMerchantsDataJsonAsset => _AdventuresMerchantsDataJsonAsset;

	public TextAsset AlbumDataJsonAsset => _AlbumDataJsonAsset;

	public TextAsset CustomMerchantsDataJsonAsset => _CustomMerchantsDataJsonAsset;

	public TextAsset AllCPUAsset => _AllCPUAsset;

	public void AddToAssetList(List<TextAsset> assets, bool includeAdventures = false)
	{
		TextAsset achievementDataJsonAsset = _AchievementDataJsonAsset;
		if ((object)_AchievementDataJsonAsset != null && ((UnityEngine.Object)achievementDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset arcanaDataJsonAsset = _ArcanaDataJsonAsset;
		if ((object)_ArcanaDataJsonAsset != null && ((UnityEngine.Object)arcanaDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset characterDataJsonAsset = _CharacterDataJsonAsset;
		if ((object)_CharacterDataJsonAsset != null && ((UnityEngine.Object)characterDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset enemyDataJsonAsset = _EnemyDataJsonAsset;
		if ((object)_EnemyDataJsonAsset != null && ((UnityEngine.Object)enemyDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset hitVfxDataJsonAsset = _HitVfxDataJsonAsset;
		if ((object)_HitVfxDataJsonAsset != null && ((UnityEngine.Object)hitVfxDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset itemDataJsonAsset = _ItemDataJsonAsset;
		if ((object)_ItemDataJsonAsset != null && ((UnityEngine.Object)itemDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset limitBreakDataJsonAsset = _LimitBreakDataJsonAsset;
		if ((object)_LimitBreakDataJsonAsset != null && ((UnityEngine.Object)limitBreakDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset musicDataJsonAsset = _MusicDataJsonAsset;
		if ((object)_MusicDataJsonAsset != null && ((UnityEngine.Object)musicDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset powerUpDataJsonAsset = _PowerUpDataJsonAsset;
		if ((object)_PowerUpDataJsonAsset != null && ((UnityEngine.Object)powerUpDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset propsDataJsonAsset = _PropsDataJsonAsset;
		if ((object)_PropsDataJsonAsset != null && ((UnityEngine.Object)propsDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset secretsDataJsonAsset = _SecretsDataJsonAsset;
		if ((object)_SecretsDataJsonAsset != null && ((UnityEngine.Object)secretsDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset stageDataJsonAsset = _StageDataJsonAsset;
		if ((object)_StageDataJsonAsset != null && ((UnityEngine.Object)stageDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		TextAsset weaponDataJsonAsset = _WeaponDataJsonAsset;
		if ((object)_WeaponDataJsonAsset != null && ((UnityEngine.Object)weaponDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		if (_AlbumDataJsonAsset != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		if (_CustomMerchantsDataJsonAsset != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
		}
		if (includeAdventures)
		{
			if (_AdventureDataJsonAsset != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
			}
			if (_AdventuresStageSetDataJsonAsset != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
			}
			if (_AdventuresMerchantsDataJsonAsset != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C4330");
			}
		}
	}
}
