using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using SPACE_UTIL;

namespace SPACE_IP
{
	[DefaultExecutionOrder(-50)] // as long as loading is done for the Store.Ins before anything
	public class GameStore : MonoBehaviour
	{
		[SerializeField] InputActionAsset _inputActionAsset;
		public static InputActionAsset IA { get; private set; }
		// public static A AIns { get; private set; }
		public static PlayerStats playerStats;

		private void Awake()
		{
			Debug.Log(C.method(this));
			this.LoadAll();
		}

		void LoadAll()
		{
			if (this._inputActionAsset != null)
			{
				GameStore.IA = this._inputActionAsset; GameStore.IA.tryLoadBindingOverridesFromJson(LOG.LoadGameData(GameDataType.inputKeyBindings));
			}
			// GameStore.A = LOG.LoadGameData<A>(GameDataType.A);
			GameStore.playerStats = LOG.LoadGameData<PlayerStats>(GameDataType.playerStats);
		}
	}

	// ================= GLOBAL ENUM ==================== //

	// used as: LOG.LoadGameData(GameDataType.____);
	// used as: LOG.LoadGameData<T>(GameDataType.____);
	// used as: LOG.SaveGameData(GameDataType.____, JSON);
	public enum GameDataType 
	{
		inputKeyBindings,
		playerStats,
	}

	// used as: R.get<T>(RLoadType.____);// note that if type T cannot be casted over the Object being loaded -> error
	// used as: R.preloadAll(C.getEnumList<RLoadType>().map(_enum => (object)_enum).ToArray());
	// used as: R.logHierarchy();
	public enum RLoadType
	{
		prefab__cube,
	}
	// ================= GLOBAL ENUM ==================== //

	// ================= GLOBAL STORE ==================== //
	public class PlayerStats
	{
		public float gameTime = 0f;
		public List<float> HISTORY = new List<float>();
		public void SaveGameData()
		{
			LOG.SaveGameData(GameDataType.playerStats, this.ToJson());
		}
	}
	// ================= GLOBAL STORE ==================== //
}